using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Primitive;
using DevExpress.XtraGauges.Core.Model;

namespace XtraGauges_CustomDraw {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }

        Timer timer;
        int animationLockCounter = 0;
        bool enableCustomDraw = false;
        

        private void arcScaleBackgroundLayerComponent1_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if (enableCustomDraw) {
                RectangleF bounds = RectangleF.Inflate(e.Info.BoundBox, -15, -15);
                e.Context.Graphics.FillEllipse(Brushes.Black, bounds);
                bounds.Inflate(-2, -2);
                e.Context.Graphics.SetClip(new RectangleF(bounds.Left + bounds.Width * 0.5f,
                    bounds.Top, bounds.Width * 0.5f, bounds.Height));
                e.Context.Graphics.FillEllipse(Brushes.White, bounds);
                e.Context.Graphics.ResetClip();
                e.Context.Graphics.FillEllipse(Brushes.White, new RectangleF(bounds.Left +
                    +bounds.Width * 0.25f, bounds.Top, bounds.Width * 0.5f, bounds.Height * 0.5f));
                e.Context.Graphics.FillEllipse(Brushes.Black, new RectangleF(bounds.Left + bounds.Width * 0.25f,
                    bounds.Top + bounds.Height * 0.5f, bounds.Width * 0.5f, bounds.Height * 0.5f));
                e.Handled = true;
            }
        }

        private void arcScaleNeedleComponent1_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if (enableCustomDraw) {
                e.Context.Graphics.FillEllipse(Brushes.White, new RectangleF(50, 112.5f, 25, 25));
                e.Context.Graphics.FillEllipse(Brushes.Black, new RectangleF(175, 112.5f, 25, 25));
                e.Handled = true;
            }
        }

        private void arcScaleComponent1_CustomDrawElement(object sender, CustomDrawElementEventArgs e) {
            if (enableCustomDraw)
                e.Handled = true;
        }

        private void checkEdit1_CheckStateChanged(object sender, EventArgs e) {
            enableCustomDraw = checkEdit1.Checked;
            arcScaleBackgroundLayerComponent1.Self.ResetCache(CacheKeys.RenderedImage);
            gaugeControl1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e) {
            timer = new Timer();
            timer.Interval = 150;
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();
        }

        void OnTimerTick(object sender, EventArgs e) {
            if (animationLockCounter > 0) return;
            animationLockCounter++;
            arcScaleComponent1.Value = AnimateScaleValue(arcScaleComponent1, 0.05f);
            animationLockCounter--;
        }

        float AnimateScaleValue(IBaseScale scale, float factor) {
            Random random = new Random(DateTime.Now.Millisecond);
            float deviation = ((float)random.NextDouble() - scale.Percent);
            return (scale.Value + (scale.ScaleLength * factor) * deviation);
        }
    }

}
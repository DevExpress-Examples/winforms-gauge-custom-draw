Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraGauges.Core.Primitive
Imports DevExpress.XtraGauges.Core.Model

Namespace XtraGauges_CustomDraw
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private timer As Timer
        Private animationLockCounter As Integer = 0
        Private enableCustomDraw As Boolean = False


        Private Sub arcScaleBackgroundLayerComponent1_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs) _
        Handles arcScaleBackgroundLayerComponent1.CustomDrawElement
            If enableCustomDraw Then
                Dim bounds As RectangleF = RectangleF.Inflate(e.Info.BoundBox, -15, -15)
                e.Context.Graphics.FillEllipse(Brushes.Black, bounds)
                bounds.Inflate(-2, -2)
                e.Context.Graphics.SetClip(New RectangleF(bounds.Left + bounds.Width * 0.5F, bounds.Top, _
                                                          bounds.Width * 0.5F, bounds.Height))
                e.Context.Graphics.FillEllipse(Brushes.White, bounds)
                e.Context.Graphics.ResetClip()
                e.Context.Graphics.FillEllipse(Brushes.White, New RectangleF(bounds.Left + +bounds.Width * 0.25F, _
                                                                             bounds.Top, bounds.Width * 0.5F, bounds.Height * 0.5F))
                e.Context.Graphics.FillEllipse(Brushes.Black, New RectangleF(bounds.Left + bounds.Width * 0.25F, _
                                                                             bounds.Top + bounds.Height * 0.5F, bounds.Width * 0.5F, bounds.Height * 0.5F))
                e.Handled = True
            End If
        End Sub

        Private Sub arcScaleNeedleComponent1_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs) _
        Handles arcScaleNeedleComponent1.CustomDrawElement
            If enableCustomDraw Then
                e.Context.Graphics.FillEllipse(Brushes.White, New RectangleF(50, 112.5F, 25, 25))
                e.Context.Graphics.FillEllipse(Brushes.Black, New RectangleF(175, 112.5F, 25, 25))
                e.Handled = True
            End If
        End Sub

        Private Sub arcScaleComponent1_CustomDrawElement(ByVal sender As Object, ByVal e As CustomDrawElementEventArgs) _
        Handles arcScaleComponent1.CustomDrawElement
            If enableCustomDraw Then
                e.Handled = True
            End If
        End Sub

        Private Sub checkEdit1_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs) _
        Handles checkEdit1.CheckStateChanged
            enableCustomDraw = checkEdit1.Checked
            arcScaleBackgroundLayerComponent1.Self.ResetCache(CacheKeys.RenderedImage)
            gaugeControl1.Refresh()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            timer = New Timer()
            timer.Interval = 150
            AddHandler timer.Tick, AddressOf OnTimerTick
            timer.Start()
        End Sub

        Private Sub OnTimerTick(ByVal sender As Object, ByVal e As EventArgs)
            If animationLockCounter > 0 Then
                Return
            End If
            animationLockCounter += 1
            arcScaleComponent1.Value = AnimateScaleValue(arcScaleComponent1, 0.05F)
            animationLockCounter -= 1
        End Sub

        Private Function AnimateScaleValue(ByVal scale As IBaseScale, ByVal factor As Single) As Single
            Dim random As New Random(DateTime.Now.Millisecond)
            Dim deviation As Single = (CSng(random.NextDouble()) - scale.Percent)
            Return (scale.Value + (scale.ScaleLength * factor) * deviation)
        End Function
    End Class

End Namespace
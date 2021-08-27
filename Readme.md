<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128623751/11.2.11%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3955)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/XtraGauges_CustomDraw/Form1.cs) (VB: [Form1.vb](./VB/XtraGauges_CustomDraw/Form1.vb))
<!-- default file list end -->
# How to custom draw a gauge control 


<p>This example shows how to draw a custom appearance for a circular gauge. </p><p><br />
</p>


<h3>Description</h3>

<p>To accomplish this task,  the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXtraGaugesCoreModelBaseGauge_CustomDrawElementtopic"><u>BaseGauge.CustomDrawElement</u></a> event is handled for the <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraGaugesWinGaugesCircularArcScaleComponenttopic"><u>ArcScaleComponent</u></a>,  <a href="http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraGaugesWinGaugesCircularArcScaleNeedleComponenttopic"><u>ArcScaleNeedle</u></a> and  <a href="http://help.devexpress.com/#CoreLibraries/clsDevExpressXtraGaugesCoreModelArcScaleBackgroundLayertopic"><u>ArcScaleBackgroundLayer</u></a> objects of gauge elements.  </p><p>Run this application to compare the custom and default gauge appearances. To do this,  enable/disable the &quot;<strong>Handle CustomDraw event&quot;</strong> option.  </p><p>Note that  the gauge control is constantly animated  to show the appearance changes more vividly. </p><p><br />
</p>

<br/>



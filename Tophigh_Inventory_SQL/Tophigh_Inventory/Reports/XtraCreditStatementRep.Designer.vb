<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class XtraCreditStatementRep
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim ShapeRectangle1 As DevExpress.XtraPrinting.Shape.ShapeRectangle = New DevExpress.XtraPrinting.Shape.ShapeRectangle()
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.DetailBand1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.Date1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Description1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Debit1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.RTotal01 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.Section1 = New DevExpress.XtraReports.UI.SubBand()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.Text5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.ReportHeaderSection1 = New DevExpress.XtraReports.UI.SubBand()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrShape1 = New DevExpress.XtraReports.UI.XRShape()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Line13 = New DevExpress.XtraReports.UI.XRLine()
        Me.Text6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.pCust1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PrintDate2 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.Text7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeaderBand1 = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.Text1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Line12 = New DevExpress.XtraReports.UI.XRLine()
        Me.ReportFooterBand1 = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Line17 = New DevExpress.XtraReports.UI.XRLine()
        Me.Line19 = New DevExpress.XtraReports.UI.XRLine()
        Me.Text9 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageFooterBand1 = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.Box3 = New DevExpress.XtraReports.UI.XRCrossBandBox()
        Me.Box1 = New DevExpress.XtraReports.UI.XRCrossBandBox()
        Me.Line9 = New DevExpress.XtraReports.UI.XRCrossBandLine()
        Me.Line10 = New DevExpress.XtraReports.UI.XRCrossBandLine()
        Me.Line11 = New DevExpress.XtraReports.UI.XRCrossBandLine()
        Me.Box5 = New DevExpress.XtraReports.UI.XRCrossBandBox()
        Me.Balance = New DevExpress.XtraReports.UI.CalculatedField()
        Me.pCust = New DevExpress.XtraReports.Parameters.Parameter()
        Me.pComp = New DevExpress.XtraReports.Parameters.Parameter()
        Me.pCustAdd = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DsCreditStatement1 = New Tophigh_Inventory.dsCreditStatement()
        Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
        CType(Me.DsCreditStatement1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DetailBand1
        '
        Me.DetailBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Date1, Me.Description1, Me.Debit1, Me.RTotal01})
        Me.DetailBand1.HeightF = 21.0!
        Me.DetailBand1.KeepTogether = True
        Me.DetailBand1.Name = "DetailBand1"
        Me.DetailBand1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.DetailBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Date1
        '
        Me.Date1.BackColor = System.Drawing.Color.White
        Me.Date1.BorderColor = System.Drawing.Color.Black
        Me.Date1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Date1.BorderWidth = 1.0!
        Me.Date1.CanGrow = False
        Me.Date1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Date]")})
        Me.Date1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Date1.ForeColor = System.Drawing.Color.Black
        Me.Date1.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 0!)
        Me.Date1.Name = "Date1"
        Me.Date1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Date1.SizeF = New System.Drawing.SizeF(106.25!, 15.34722!)
        Me.Date1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.Date1.TextFormatString = "{0:dd-MM-yyyy}"
        '
        'Description1
        '
        Me.Description1.BackColor = System.Drawing.Color.White
        Me.Description1.BorderColor = System.Drawing.Color.Black
        Me.Description1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Description1.BorderWidth = 1.0!
        Me.Description1.CanGrow = False
        Me.Description1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Description]")})
        Me.Description1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Description1.ForeColor = System.Drawing.Color.Black
        Me.Description1.LocationFloat = New DevExpress.Utils.PointFloat(143.75!, 0!)
        Me.Description1.Name = "Description1"
        Me.Description1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Description1.SizeF = New System.Drawing.SizeF(275.0!, 15.34722!)
        Me.Description1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopJustify
        '
        'Debit1
        '
        Me.Debit1.BackColor = System.Drawing.Color.White
        Me.Debit1.BorderColor = System.Drawing.Color.Black
        Me.Debit1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Debit1.BorderWidth = 1.0!
        Me.Debit1.CanGrow = False
        Me.Debit1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Debit]")})
        Me.Debit1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.Debit1.ForeColor = System.Drawing.Color.Black
        Me.Debit1.LocationFloat = New DevExpress.Utils.PointFloat(429.1667!, 0!)
        Me.Debit1.Name = "Debit1"
        Me.Debit1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Debit1.SizeF = New System.Drawing.SizeF(127.0833!, 15.34722!)
        Me.Debit1.StylePriority.UseTextAlignment = False
        Me.Debit1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.Debit1.TextFormatString = "{0:n2}"
        '
        'RTotal01
        '
        Me.RTotal01.BackColor = System.Drawing.Color.White
        Me.RTotal01.BorderColor = System.Drawing.Color.Black
        Me.RTotal01.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.RTotal01.BorderWidth = 1.0!
        Me.RTotal01.CanGrow = False
        Me.RTotal01.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([Debit])")})
        Me.RTotal01.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.RTotal01.ForeColor = System.Drawing.Color.Black
        Me.RTotal01.LocationFloat = New DevExpress.Utils.PointFloat(566.6667!, 0!)
        Me.RTotal01.Name = "RTotal01"
        Me.RTotal01.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.RTotal01.SizeF = New System.Drawing.SizeF(182.2917!, 15.34722!)
        Me.RTotal01.StylePriority.UseTextAlignment = False
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.RTotal01.Summary = XrSummary1
        Me.RTotal01.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.RTotal01.TextFormatString = "{0:n2}"
        '
        'ReportHeaderBand1
        '
        Me.ReportHeaderBand1.HeightF = 0!
        Me.ReportHeaderBand1.Name = "ReportHeaderBand1"
        Me.ReportHeaderBand1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.ReportHeaderBand1.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.Section1, Me.ReportHeaderSection1})
        Me.ReportHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Section1
        '
        Me.Section1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel3, Me.XrPictureBox1, Me.Text5})
        Me.Section1.HeightF = 153.0!
        Me.Section1.KeepTogether = True
        Me.Section1.Name = "Section1"
        Me.Section1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Section1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel3
        '
        Me.XrLabel3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?pComp")})
        Me.XrLabel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 25.62501!)
        Me.XrLabel3.Multiline = True
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(325.0!, 117.375!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.Text = "XrLabel3"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(388.5417!, 36.45833!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(112.5!, 89.58333!)
        '
        'Text5
        '
        Me.Text5.BackColor = System.Drawing.Color.White
        Me.Text5.BorderColor = System.Drawing.Color.Black
        Me.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text5.BorderWidth = 1.0!
        Me.Text5.CanGrow = False
        Me.Text5.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Text5.ForeColor = System.Drawing.Color.Black
        Me.Text5.LocationFloat = New DevExpress.Utils.PointFloat(558.3333!, 91.66666!)
        Me.Text5.Name = "Text5"
        Me.Text5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text5.SizeF = New System.Drawing.SizeF(183.3333!, 32.01389!)
        Me.Text5.StylePriority.UseFont = False
        Me.Text5.Text = "Customer Statement"
        Me.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.XrLine1, Me.XrShape1, Me.XrLabel4, Me.XrLabel2, Me.Line13, Me.Text6, Me.pCust1, Me.PrintDate2, Me.Text7, Me.Text8})
        Me.ReportHeaderSection1.HeightF = 142.0!
        Me.ReportHeaderSection1.KeepTogether = True
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        Me.ReportHeaderSection1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.ReportHeaderSection1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine2
        '
        Me.XrLine2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(487.5!, 90.34723!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(254.1667!, 2.083332!)
        Me.XrLine2.StylePriority.UseBorders = False
        '
        'XrLine1
        '
        Me.XrLine1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(592.7083!, 75.0!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(2.083374!, 43.38888!)
        Me.XrLine1.StylePriority.UseBorders = False
        '
        'XrShape1
        '
        Me.XrShape1.LocationFloat = New DevExpress.Utils.PointFloat(485.4168!, 75.0!)
        Me.XrShape1.Name = "XrShape1"
        Me.XrShape1.Shape = ShapeRectangle1
        Me.XrShape1.SizeF = New System.Drawing.SizeF(256.2499!, 43.38888!)
        '
        'XrLabel4
        '
        Me.XrLabel4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?pCustAdd")})
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(31.25!, 44.70832!)
        Me.XrLabel4.Multiline = True
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(310.4167!, 88.62498!)
        Me.XrLabel4.Text = "XrLabel4"
        '
        'XrLabel2
        '
        Me.XrLabel2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([Debit])")})
        Me.XrLabel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(604.1667!, 101.8611!)
        Me.XrLabel2.Multiline = True
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(129.7917!, 16.52778!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.StylePriority.UseTextAlignment = False
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel2.Summary = XrSummary2
        Me.XrLabel2.Text = "XrLabel2"
        Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrLabel2.TextFormatString = "₵ {0:n2}"
        '
        'Line13
        '
        Me.Line13.BackColor = System.Drawing.Color.White
        Me.Line13.BorderColor = System.Drawing.Color.Black
        Me.Line13.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.Line13.BorderWidth = 1.0!
        Me.Line13.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Line13.ForeColor = System.Drawing.Color.Black
        Me.Line13.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 37.5!)
        Me.Line13.Name = "Line13"
        Me.Line13.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Line13.SizeF = New System.Drawing.SizeF(325.0!, 2.0!)
        '
        'Text6
        '
        Me.Text6.BackColor = System.Drawing.Color.White
        Me.Text6.BorderColor = System.Drawing.Color.Black
        Me.Text6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text6.BorderWidth = 1.0!
        Me.Text6.CanGrow = False
        Me.Text6.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text6.ForeColor = System.Drawing.Color.Black
        Me.Text6.LocationFloat = New DevExpress.Utils.PointFloat(33.33333!, 16.66667!)
        Me.Text6.Name = "Text6"
        Me.Text6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text6.SizeF = New System.Drawing.SizeF(83.33333!, 15.34722!)
        Me.Text6.StylePriority.UseTextAlignment = False
        Me.Text6.Text = "Customer : :"
        Me.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'pCust1
        '
        Me.pCust1.BackColor = System.Drawing.Color.White
        Me.pCust1.BorderColor = System.Drawing.Color.Black
        Me.pCust1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.pCust1.BorderWidth = 1.0!
        Me.pCust1.CanGrow = False
        Me.pCust1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?pCust")})
        Me.pCust1.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.pCust1.ForeColor = System.Drawing.Color.Black
        Me.pCust1.LocationFloat = New DevExpress.Utils.PointFloat(116.6667!, 16.66667!)
        Me.pCust1.Name = "pCust1"
        Me.pCust1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.pCust1.SizeF = New System.Drawing.SizeF(225.0!, 15.34722!)
        Me.pCust1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PrintDate2
        '
        Me.PrintDate2.BackColor = System.Drawing.Color.White
        Me.PrintDate2.BorderColor = System.Drawing.Color.Black
        Me.PrintDate2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PrintDate2.BorderWidth = 1.0!
        Me.PrintDate2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PrintDate2.ForeColor = System.Drawing.Color.Black
        Me.PrintDate2.LocationFloat = New DevExpress.Utils.PointFloat(506.25!, 101.8611!)
        Me.PrintDate2.Name = "PrintDate2"
        Me.PrintDate2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.PrintDate2.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.PrintDate2.SizeF = New System.Drawing.SizeF(86.45831!, 16.52777!)
        Me.PrintDate2.StylePriority.UseTextAlignment = False
        Me.PrintDate2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.PrintDate2.TextFormatString = "{0:dd-MM-yyyy}"
        '
        'Text7
        '
        Me.Text7.BackColor = System.Drawing.Color.White
        Me.Text7.BorderColor = System.Drawing.Color.Black
        Me.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text7.BorderWidth = 1.0!
        Me.Text7.CanGrow = False
        Me.Text7.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text7.ForeColor = System.Drawing.Color.Black
        Me.Text7.LocationFloat = New DevExpress.Utils.PointFloat(495.8333!, 75.0!)
        Me.Text7.Name = "Text7"
        Me.Text7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text7.SizeF = New System.Drawing.SizeF(83.33334!, 15.34722!)
        Me.Text7.StylePriority.UseTextAlignment = False
        Me.Text7.Text = "Date"
        Me.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'Text8
        '
        Me.Text8.BackColor = System.Drawing.Color.White
        Me.Text8.BorderColor = System.Drawing.Color.Black
        Me.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text8.BorderWidth = 1.0!
        Me.Text8.CanGrow = False
        Me.Text8.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text8.ForeColor = System.Drawing.Color.Black
        Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(604.1667!, 75.0!)
        Me.Text8.Name = "Text8"
        Me.Text8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text8.SizeF = New System.Drawing.SizeF(129.7917!, 15.34722!)
        Me.Text8.Text = "Amount Due"
        Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'PageHeaderBand1
        '
        Me.PageHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Text1, Me.Text2, Me.Text3, Me.Text4, Me.Line12})
        Me.PageHeaderBand1.HeightF = 56.16667!
        Me.PageHeaderBand1.Name = "PageHeaderBand1"
        Me.PageHeaderBand1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeaderBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text1
        '
        Me.Text1.BackColor = System.Drawing.Color.White
        Me.Text1.BorderColor = System.Drawing.Color.Black
        Me.Text1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text1.BorderWidth = 1.0!
        Me.Text1.CanGrow = False
        Me.Text1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text1.ForeColor = System.Drawing.Color.Black
        Me.Text1.LocationFloat = New DevExpress.Utils.PointFloat(25.0!, 37.77778!)
        Me.Text1.Name = "Text1"
        Me.Text1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text1.SizeF = New System.Drawing.SizeF(106.25!, 15.34722!)
        Me.Text1.Text = "Date"
        Me.Text1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text2
        '
        Me.Text2.BackColor = System.Drawing.Color.White
        Me.Text2.BorderColor = System.Drawing.Color.Black
        Me.Text2.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text2.BorderWidth = 1.0!
        Me.Text2.CanGrow = False
        Me.Text2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text2.ForeColor = System.Drawing.Color.Black
        Me.Text2.LocationFloat = New DevExpress.Utils.PointFloat(143.75!, 37.77778!)
        Me.Text2.Name = "Text2"
        Me.Text2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text2.SizeF = New System.Drawing.SizeF(275.0!, 15.34722!)
        Me.Text2.Text = "Transactions"
        Me.Text2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text3
        '
        Me.Text3.BackColor = System.Drawing.Color.White
        Me.Text3.BorderColor = System.Drawing.Color.Black
        Me.Text3.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text3.BorderWidth = 1.0!
        Me.Text3.CanGrow = False
        Me.Text3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text3.ForeColor = System.Drawing.Color.Black
        Me.Text3.LocationFloat = New DevExpress.Utils.PointFloat(429.1667!, 37.77778!)
        Me.Text3.Name = "Text3"
        Me.Text3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text3.SizeF = New System.Drawing.SizeF(127.0833!, 15.34722!)
        Me.Text3.Text = "Amount"
        Me.Text3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'Text4
        '
        Me.Text4.BackColor = System.Drawing.Color.White
        Me.Text4.BorderColor = System.Drawing.Color.Black
        Me.Text4.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text4.BorderWidth = 1.0!
        Me.Text4.CanGrow = False
        Me.Text4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text4.ForeColor = System.Drawing.Color.Black
        Me.Text4.LocationFloat = New DevExpress.Utils.PointFloat(577.0833!, 39.09721!)
        Me.Text4.Name = "Text4"
        Me.Text4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text4.SizeF = New System.Drawing.SizeF(171.8751!, 14.02779!)
        Me.Text4.Text = "Balance"
        Me.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'Line12
        '
        Me.Line12.BackColor = System.Drawing.Color.White
        Me.Line12.BorderColor = System.Drawing.Color.Black
        Me.Line12.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.Line12.BorderWidth = 1.0!
        Me.Line12.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Line12.ForeColor = System.Drawing.Color.Black
        Me.Line12.LocationFloat = New DevExpress.Utils.PointFloat(19.79167!, 54.16667!)
        Me.Line12.Name = "Line12"
        Me.Line12.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Line12.SizeF = New System.Drawing.SizeF(746.875!, 2.0!)
        '
        'ReportFooterBand1
        '
        Me.ReportFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.Line17, Me.Line19, Me.Text9})
        Me.ReportFooterBand1.HeightF = 139.2083!
        Me.ReportFooterBand1.KeepTogether = True
        Me.ReportFooterBand1.Name = "ReportFooterBand1"
        Me.ReportFooterBand1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.ReportFooterBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLabel1
        '
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRunningSum([Debit])")})
        Me.XrLabel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(590.625!, 114.4305!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(158.3334!, 18.19447!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.XrLabel1.Summary = XrSummary3
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrLabel1.TextFormatString = "₵ {0:n2}"
        '
        'Line17
        '
        Me.Line17.BackColor = System.Drawing.Color.White
        Me.Line17.BorderColor = System.Drawing.Color.Black
        Me.Line17.Borders = DevExpress.XtraPrinting.BorderSide.Left
        Me.Line17.BorderWidth = 1.0!
        Me.Line17.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Line17.ForeColor = System.Drawing.Color.Black
        Me.Line17.LineDirection = DevExpress.XtraReports.UI.LineDirection.Vertical
        Me.Line17.LocationFloat = New DevExpress.Utils.PointFloat(562.5!, 82.63889!)
        Me.Line17.Name = "Line17"
        Me.Line17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Line17.SizeF = New System.Drawing.SizeF(2.0!, 54.79167!)
        '
        'Line19
        '
        Me.Line19.BackColor = System.Drawing.Color.White
        Me.Line19.BorderColor = System.Drawing.Color.Black
        Me.Line19.Borders = DevExpress.XtraPrinting.BorderSide.Top
        Me.Line19.BorderWidth = 1.0!
        Me.Line19.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.Line19.ForeColor = System.Drawing.Color.Black
        Me.Line19.LocationFloat = New DevExpress.Utils.PointFloat(20.83333!, 110.7639!)
        Me.Line19.Name = "Line19"
        Me.Line19.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Line19.SizeF = New System.Drawing.SizeF(745.8333!, 2.0!)
        '
        'Text9
        '
        Me.Text9.BackColor = System.Drawing.Color.White
        Me.Text9.BorderColor = System.Drawing.Color.Black
        Me.Text9.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text9.BorderWidth = 1.0!
        Me.Text9.CanGrow = False
        Me.Text9.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text9.ForeColor = System.Drawing.Color.Black
        Me.Text9.LocationFloat = New DevExpress.Utils.PointFloat(625.0!, 91.66666!)
        Me.Text9.Name = "Text9"
        Me.Text9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text9.SizeF = New System.Drawing.SizeF(129.7917!, 15.34722!)
        Me.Text9.Text = "Balance Due"
        Me.Text9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'PageFooterBand1
        '
        Me.PageFooterBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.PageFooterBand1.HeightF = 44.95835!
        Me.PageFooterBand1.Name = "PageFooterBand1"
        Me.PageFooterBand1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooterBand1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrPageInfo1.LocationFloat = New DevExpress.Utils.PointFloat(665.625!, 10.00001!)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.SizeF = New System.Drawing.SizeF(100.0!, 23.0!)
        Me.XrPageInfo1.StylePriority.UseFont = False
        Me.XrPageInfo1.StylePriority.UseTextAlignment = False
        Me.XrPageInfo1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        Me.XrPageInfo1.TextFormatString = "Page {0} of {1}"
        '
        'Box3
        '
        Me.Box3.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Box3.BorderColor = System.Drawing.Color.Black
        Me.Box3.BorderWidth = 1.0!
        Me.Box3.EndBand = Me.ReportHeaderSection1
        Me.Box3.EndPointFloat = New DevExpress.Utils.PointFloat(25.0!, 141.6667!)
        Me.Box3.Name = "Box3"
        Me.Box3.StartBand = Me.ReportHeaderSection1
        Me.Box3.StartPointFloat = New DevExpress.Utils.PointFloat(25.0!, 8.333333!)
        Me.Box3.WidthF = 325.0!
        '
        'Box1
        '
        Me.Box1.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Box1.BorderColor = System.Drawing.Color.Black
        Me.Box1.BorderWidth = 1.0!
        Me.Box1.EndBand = Me.ReportFooterBand1
        Me.Box1.EndPointFloat = New DevExpress.Utils.PointFloat(19.79167!, 85.95828!)
        Me.Box1.Name = "Box1"
        Me.Box1.StartBand = Me.PageHeaderBand1
        Me.Box1.StartPointFloat = New DevExpress.Utils.PointFloat(19.79167!, 33.33333!)
        Me.Box1.WidthF = 746.875!
        '
        'Line9
        '
        Me.Line9.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Line9.EndBand = Me.ReportFooterBand1
        Me.Line9.EndPointFloat = New DevExpress.Utils.PointFloat(136.4583!, 85.95828!)
        Me.Line9.ForeColor = System.Drawing.Color.Black
        Me.Line9.Name = "Line9"
        Me.Line9.StartBand = Me.PageHeaderBand1
        Me.Line9.StartPointFloat = New DevExpress.Utils.PointFloat(136.4583!, 34.375!)
        Me.Line9.WidthF = 1.388889!
        '
        'Line10
        '
        Me.Line10.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Line10.EndBand = Me.ReportFooterBand1
        Me.Line10.EndPointFloat = New DevExpress.Utils.PointFloat(423.9583!, 85.95828!)
        Me.Line10.ForeColor = System.Drawing.Color.Black
        Me.Line10.Name = "Line10"
        Me.Line10.StartBand = Me.PageHeaderBand1
        Me.Line10.StartPointFloat = New DevExpress.Utils.PointFloat(423.9583!, 34.375!)
        Me.Line10.WidthF = 1.388889!
        '
        'Line11
        '
        Me.Line11.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Line11.EndBand = Me.ReportFooterBand1
        Me.Line11.EndPointFloat = New DevExpress.Utils.PointFloat(562.5!, 85.95828!)
        Me.Line11.ForeColor = System.Drawing.Color.Black
        Me.Line11.Name = "Line11"
        Me.Line11.StartBand = Me.PageHeaderBand1
        Me.Line11.StartPointFloat = New DevExpress.Utils.PointFloat(562.5!, 34.375!)
        Me.Line11.WidthF = 1.388889!
        '
        'Box5
        '
        Me.Box5.AnchorVertical = CType((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top Or DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom), DevExpress.XtraReports.UI.VerticalAnchorStyles)
        Me.Box5.BorderColor = System.Drawing.Color.Black
        Me.Box5.BorderWidth = 1.0!
        Me.Box5.EndBand = Me.ReportFooterBand1
        Me.Box5.EndPointFloat = New DevExpress.Utils.PointFloat(19.79167!, 139.6389!)
        Me.Box5.Name = "Box5"
        Me.Box5.StartBand = Me.ReportFooterBand1
        Me.Box5.StartPointFloat = New DevExpress.Utils.PointFloat(19.79167!, 82.63889!)
        Me.Box5.WidthF = 746.875!
        '
        'Balance
        '
        Me.Balance.Expression = "Iif(True, '', 'formula = Sum ({CreditStatement.Debit}) - Sum ({CreditStatement.Cr" &
    "edit})')"
        Me.Balance.Name = "Balance"
        '
        'pCust
        '
        Me.pCust.Description = "pCust"
        Me.pCust.Name = "pCust"
        Me.pCust.Visible = False
        '
        'pComp
        '
        Me.pComp.Description = "pComp"
        Me.pComp.Name = "pComp"
        Me.pComp.Visible = False
        '
        'pCustAdd
        '
        Me.pCustAdd.Description = "Enter pCustAdd:"
        Me.pCustAdd.Name = "pCustAdd"
        '
        'DsCreditStatement1
        '
        Me.DsCreditStatement1.DataSetName = "dsCreditStatement"
        Me.DsCreditStatement1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TopMarginBand1
        '
        Me.TopMarginBand1.HeightF = 25.0!
        Me.TopMarginBand1.Name = "TopMarginBand1"
        '
        'BottomMarginBand1
        '
        Me.BottomMarginBand1.HeightF = 25.0!
        Me.BottomMarginBand1.Name = "BottomMarginBand1"
        '
        'XtraCreditStatementRep
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailBand1, Me.ReportHeaderBand1, Me.PageHeaderBand1, Me.ReportFooterBand1, Me.PageFooterBand1, Me.TopMarginBand1, Me.BottomMarginBand1})
        Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Balance})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.DsCreditStatement1})
        Me.CrossBandControls.AddRange(New DevExpress.XtraReports.UI.XRCrossBandControl() {Me.Box3, Me.Box1, Me.Line9, Me.Line10, Me.Line11, Me.Box5})
        Me.DataMember = "CreditStatement"
        Me.DataSource = Me.DsCreditStatement1
        Me.Margins = New System.Drawing.Printing.Margins(25, 25, 25, 25)
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.pCust, Me.pComp, Me.pCustAdd})
        Me.Version = "18.2"
        CType(Me.DsCreditStatement1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents DetailBand1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents Date1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Description1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Debit1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents RTotal01 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents Section1 As DevExpress.XtraReports.UI.SubBand
    Friend WithEvents Text5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ReportHeaderSection1 As DevExpress.XtraReports.UI.SubBand
    Friend WithEvents Line13 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents Text6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents pCust1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PrintDate2 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents Text7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageHeaderBand1 As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents Text1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Line12 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents ReportFooterBand1 As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents Line17 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents Line19 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents Text9 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PageFooterBand1 As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents Box3 As DevExpress.XtraReports.UI.XRCrossBandBox
    Friend WithEvents Box1 As DevExpress.XtraReports.UI.XRCrossBandBox
    Friend WithEvents Line9 As DevExpress.XtraReports.UI.XRCrossBandLine
    Friend WithEvents Line10 As DevExpress.XtraReports.UI.XRCrossBandLine
    Friend WithEvents Line11 As DevExpress.XtraReports.UI.XRCrossBandLine
    Friend WithEvents Box5 As DevExpress.XtraReports.UI.XRCrossBandBox
    Friend WithEvents Balance As DevExpress.XtraReports.UI.CalculatedField
    Friend WithEvents pCust As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents pComp As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents pCustAdd As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents DsCreditStatement1 As dsCreditStatement
    Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrShape1 As DevExpress.XtraReports.UI.XRShape
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
End Class

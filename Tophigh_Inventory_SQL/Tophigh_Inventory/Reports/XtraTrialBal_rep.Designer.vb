<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class XtraTrialBal_rep
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
        Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.PrintTime1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PrintDate1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.MyAsOfDate1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.SumofCredit1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text6 = New DevExpress.XtraReports.UI.XRLabel()
        Me.SumofDebit1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
        Me.Text5 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
        Me.TotalDiff1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.MyAsOfDate = New DevExpress.XtraReports.Parameters.Parameter()
        Me.DsTrialBal1 = New Tophigh_Inventory.dsTrialBal()
        Me.pComp = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsTrialBal1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 37.5!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 25.00003!
        Me.Detail.Name = "Detail"
        '
        'XrTable1
        '
        Me.XrTable1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(785.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBorderDashStyle = False
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3, Me.XrTableCell4})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Code]")})
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.Weight = 0.58598722227060107R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Accounts]")})
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.Weight = 1.8917199396024085R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Debit]")})
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell3.StylePriority.UseTextAlignment = False
        Me.XrTableCell3.Text = "XrTableCell3"
        Me.XrTableCell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell3.TextFormatString = "{0:n2}"
        Me.XrTableCell3.Weight = 0.77176257090963385R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Credit]")})
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "XrTableCell4"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell4.TextFormatString = "{0:n2}"
        Me.XrTableCell4.Weight = 0.75053026721735672R
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3, Me.XrLabel1, Me.XrPictureBox1, Me.PrintTime1, Me.PrintDate1, Me.MyAsOfDate1, Me.Text8, Me.Text7})
        Me.ReportHeader.HeightF = 245.8333!
        Me.ReportHeader.Name = "ReportHeader"
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(8.500068!, 227.0833!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(763.5417!, 2.083344!)
        '
        'XrLabel1
        '
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?pComp")})
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(263.2085!, 10.00001!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(339.0416!, 143.8333!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(23.33333!, 33.29166!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(130.2083!, 109.4583!)
        '
        'PrintTime1
        '
        Me.PrintTime1.BackColor = System.Drawing.Color.White
        Me.PrintTime1.BorderColor = System.Drawing.Color.Black
        Me.PrintTime1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PrintTime1.BorderWidth = 1.0!
        Me.PrintTime1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PrintTime1.ForeColor = System.Drawing.Color.Black
        Me.PrintTime1.LocationFloat = New DevExpress.Utils.PointFloat(637.7084!, 204.8611!)
        Me.PrintTime1.Name = "PrintTime1"
        Me.PrintTime1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.PrintTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.PrintTime1.SizeF = New System.Drawing.SizeF(91.66666!, 15.34722!)
        Me.PrintTime1.StylePriority.UseFont = False
        Me.PrintTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.PrintTime1.TextFormatString = "{0:t}"
        '
        'PrintDate1
        '
        Me.PrintDate1.BackColor = System.Drawing.Color.White
        Me.PrintDate1.BorderColor = System.Drawing.Color.Black
        Me.PrintDate1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PrintDate1.BorderWidth = 1.0!
        Me.PrintDate1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PrintDate1.ForeColor = System.Drawing.Color.Black
        Me.PrintDate1.LocationFloat = New DevExpress.Utils.PointFloat(23.33339!, 204.8611!)
        Me.PrintDate1.Name = "PrintDate1"
        Me.PrintDate1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.PrintDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.PrintDate1.SizeF = New System.Drawing.SizeF(181.25!, 15.34721!)
        Me.PrintDate1.StylePriority.UseFont = False
        Me.PrintDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'MyAsOfDate1
        '
        Me.MyAsOfDate1.BackColor = System.Drawing.Color.White
        Me.MyAsOfDate1.BorderColor = System.Drawing.Color.Black
        Me.MyAsOfDate1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.MyAsOfDate1.BorderWidth = 1.0!
        Me.MyAsOfDate1.CanGrow = False
        Me.MyAsOfDate1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?MyAsOfDate")})
        Me.MyAsOfDate1.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.MyAsOfDate1.ForeColor = System.Drawing.Color.Black
        Me.MyAsOfDate1.LocationFloat = New DevExpress.Utils.PointFloat(377.9166!, 204.8611!)
        Me.MyAsOfDate1.Name = "MyAsOfDate1"
        Me.MyAsOfDate1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.MyAsOfDate1.SizeF = New System.Drawing.SizeF(108.3335!, 15.34721!)
        Me.MyAsOfDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        Me.MyAsOfDate1.TextFormatString = "{0:dd-MM-yyyy}"
        '
        'Text8
        '
        Me.Text8.BackColor = System.Drawing.Color.White
        Me.Text8.BorderColor = System.Drawing.Color.Black
        Me.Text8.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text8.BorderWidth = 1.0!
        Me.Text8.CanGrow = False
        Me.Text8.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Text8.ForeColor = System.Drawing.Color.Black
        Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(327.2915!, 204.8611!)
        Me.Text8.Name = "Text8"
        Me.Text8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text8.SizeF = New System.Drawing.SizeF(42.29167!, 15.34722!)
        Me.Text8.Text = "AS @"
        Me.Text8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Text7
        '
        Me.Text7.BackColor = System.Drawing.Color.White
        Me.Text7.BorderColor = System.Drawing.Color.Black
        Me.Text7.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text7.BorderWidth = 1.0!
        Me.Text7.CanGrow = False
        Me.Text7.Font = New System.Drawing.Font("Arial", 11.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Text7.ForeColor = System.Drawing.Color.Black
        Me.Text7.LocationFloat = New DevExpress.Utils.PointFloat(353.1248!, 169.7222!)
        Me.Text7.Name = "Text7"
        Me.Text7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text7.SizeF = New System.Drawing.SizeF(100.0!, 15.34722!)
        Me.Text7.Text = "Trial Balance"
        Me.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.PageHeader.HeightF = 25.0!
        Me.PageHeader.Name = "PageHeader"
        '
        'XrTable2
        '
        Me.XrTable2.BackColor = System.Drawing.Color.Navy
        Me.XrTable2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable2.ForeColor = System.Drawing.Color.White
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(785.0!, 25.0!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseForeColor = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.XrTableCell6, Me.XrTableCell7, Me.XrTableCell8})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Multiline = True
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell5.Text = "Account Code"
        Me.XrTableCell5.Weight = 0.58598722227060107R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.Multiline = True
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell6.Text = "Account Name"
        Me.XrTableCell6.Weight = 1.8917199396024085R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Multiline = True
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell7.StylePriority.UseTextAlignment = False
        Me.XrTableCell7.Text = "Debit"
        Me.XrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell7.Weight = 0.771763192923965R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.Multiline = True
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell8.StylePriority.UseTextAlignment = False
        Me.XrTableCell8.Text = "Credit"
        Me.XrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell8.Weight = 0.75052964520302545R
        '
        'ReportFooter
        '
        Me.ReportFooter.HeightF = 203.125!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SumofCredit1, Me.Text6, Me.SumofDebit1, Me.XrLine2, Me.Text5, Me.XrLine1, Me.TotalDiff1})
        Me.PageFooter.HeightF = 171.0833!
        Me.PageFooter.Name = "PageFooter"
        '
        'SumofCredit1
        '
        Me.SumofCredit1.BackColor = System.Drawing.Color.White
        Me.SumofCredit1.BorderColor = System.Drawing.Color.Black
        Me.SumofCredit1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.SumofCredit1.BorderWidth = 1.0!
        Me.SumofCredit1.CanGrow = False
        Me.SumofCredit1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Credit])")})
        Me.SumofCredit1.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.SumofCredit1.ForeColor = System.Drawing.Color.Black
        Me.SumofCredit1.LocationFloat = New DevExpress.Utils.PointFloat(632.2917!, 77.08334!)
        Me.SumofCredit1.Name = "SumofCredit1"
        Me.SumofCredit1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.SumofCredit1.SizeF = New System.Drawing.SizeF(143.75!, 16.52778!)
        Me.SumofCredit1.StylePriority.UseTextAlignment = False
        XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.SumofCredit1.Summary = XrSummary1
        Me.SumofCredit1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.SumofCredit1.TextFormatString = "{0:n2}"
        '
        'Text6
        '
        Me.Text6.BackColor = System.Drawing.Color.White
        Me.Text6.BorderColor = System.Drawing.Color.Black
        Me.Text6.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text6.BorderWidth = 1.0!
        Me.Text6.CanGrow = False
        Me.Text6.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Text6.ForeColor = System.Drawing.Color.Black
        Me.Text6.LocationFloat = New DevExpress.Utils.PointFloat(424.9998!, 77.08334!)
        Me.Text6.Name = "Text6"
        Me.Text6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text6.SizeF = New System.Drawing.SizeF(46.45833!, 15.34722!)
        Me.Text6.Text = "Totals :"
        Me.Text6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'SumofDebit1
        '
        Me.SumofDebit1.BackColor = System.Drawing.Color.White
        Me.SumofDebit1.BorderColor = System.Drawing.Color.Black
        Me.SumofDebit1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.SumofDebit1.BorderWidth = 1.0!
        Me.SumofDebit1.CanGrow = False
        Me.SumofDebit1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumSum([Debit])")})
        Me.SumofDebit1.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.SumofDebit1.ForeColor = System.Drawing.Color.Black
        Me.SumofDebit1.LocationFloat = New DevExpress.Utils.PointFloat(483.3332!, 77.08334!)
        Me.SumofDebit1.Name = "SumofDebit1"
        Me.SumofDebit1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.SumofDebit1.SizeF = New System.Drawing.SizeF(141.6667!, 16.52778!)
        Me.SumofDebit1.StylePriority.UseTextAlignment = False
        XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
        Me.SumofDebit1.Summary = XrSummary2
        Me.SumofDebit1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.SumofDebit1.TextFormatString = "{0:n2}"
        '
        'XrLine2
        '
        Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(587.5!, 151.2917!)
        Me.XrLine2.Name = "XrLine2"
        Me.XrLine2.SizeF = New System.Drawing.SizeF(189.5833!, 3.125!)
        '
        'Text5
        '
        Me.Text5.BackColor = System.Drawing.Color.White
        Me.Text5.BorderColor = System.Drawing.Color.Black
        Me.Text5.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Text5.BorderWidth = 1.0!
        Me.Text5.CanGrow = False
        Me.Text5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Text5.ForeColor = System.Drawing.Color.Black
        Me.Text5.LocationFloat = New DevExpress.Utils.PointFloat(583.3333!, 130.5139!)
        Me.Text5.Name = "Text5"
        Me.Text5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text5.SizeF = New System.Drawing.SizeF(63.125!, 15.34722!)
        Me.Text5.Text = "Total Diff :"
        Me.Text5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrLine1
        '
        Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(586.4583!, 120.9166!)
        Me.XrLine1.Name = "XrLine1"
        Me.XrLine1.SizeF = New System.Drawing.SizeF(189.5833!, 3.125!)
        '
        'TotalDiff1
        '
        Me.TotalDiff1.BackColor = System.Drawing.Color.White
        Me.TotalDiff1.BorderColor = System.Drawing.Color.Black
        Me.TotalDiff1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.TotalDiff1.BorderWidth = 1.0!
        Me.TotalDiff1.CanGrow = False
        Me.TotalDiff1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Sum([Debit]-[Credit])")})
        Me.TotalDiff1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.TotalDiff1.ForeColor = System.Drawing.Color.Black
        Me.TotalDiff1.LocationFloat = New DevExpress.Utils.PointFloat(650.0!, 130.5139!)
        Me.TotalDiff1.Name = "TotalDiff1"
        Me.TotalDiff1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.TotalDiff1.SizeF = New System.Drawing.SizeF(125.0!, 16.52778!)
        Me.TotalDiff1.StylePriority.UseTextAlignment = False
        Me.TotalDiff1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.TotalDiff1.TextFormatString = "{0:n2}"
        '
        'MyAsOfDate
        '
        Me.MyAsOfDate.Description = "Parameter1"
        Me.MyAsOfDate.Name = "MyAsOfDate"
        Me.MyAsOfDate.Type = GetType(Date)
        '
        'DsTrialBal1
        '
        Me.DsTrialBal1.DataSetName = "dsTrialBal"
        Me.DsTrialBal1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pComp
        '
        Me.pComp.Description = "Parameter1"
        Me.pComp.Name = "pComp"
        '
        'XtraTrialBal_rep
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.DsTrialBal1})
        Me.DataMember = "TrialBal"
        Me.DataSource = Me.DsTrialBal1
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(29, 36, 38, 100)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.MyAsOfDate, Me.pComp})
        Me.Version = "18.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsTrialBal1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents MyAsOfDate As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents DsTrialBal1 As dsTrialBal
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents PrintTime1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents PrintDate1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents MyAsOfDate1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents TotalDiff1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text6 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents SumofDebit1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents SumofCredit1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents pComp As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
End Class

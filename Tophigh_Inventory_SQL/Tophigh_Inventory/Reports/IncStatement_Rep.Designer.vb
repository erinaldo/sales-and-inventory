<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class IncStatement_Rep
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
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.MyAsOfDate1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text8 = New DevExpress.XtraReports.UI.XRLabel()
        Me.Text7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.PrintDate1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.PrintTime1 = New DevExpress.XtraReports.UI.XRPageInfo()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.ReportFooter = New DevExpress.XtraReports.UI.ReportFooterBand()
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
        Me.DsIncomeStatement1 = New Tophigh_Inventory.dsIncomeStatement()
        Me.pComp = New DevExpress.XtraReports.Parameters.Parameter()
        Me.MyAsOfDate = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsIncomeStatement1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 39.0!
        Me.TopMargin.Name = "TopMargin"
        '
        'BottomMargin
        '
        Me.BottomMargin.Name = "BottomMargin"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.HeightF = 26.04167!
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
        Me.XrTable1.SizeF = New System.Drawing.SizeF(765.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBorderDashStyle = False
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Accounts]")})
        Me.XrTableCell1.Multiline = True
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell1.Text = "XrTableCell1"
        Me.XrTableCell1.Weight = 1.455128173828125R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Amount]")})
        Me.XrTableCell2.Multiline = True
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "XrTableCell2"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell2.TextFormatString = "{0:n2}"
        Me.XrTableCell2.Weight = 0.544871826171875R
        '
        'ReportHeader
        '
        Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.MyAsOfDate1, Me.Text8, Me.Text7, Me.PrintDate1, Me.PrintTime1, Me.XrPictureBox1, Me.XrLabel1, Me.XrLine3})
        Me.ReportHeader.HeightF = 265.1667!
        Me.ReportHeader.Name = "ReportHeader"
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
        Me.MyAsOfDate1.LocationFloat = New DevExpress.Utils.PointFloat(363.6248!, 232.9444!)
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
        Me.Text8.LocationFloat = New DevExpress.Utils.PointFloat(312.9998!, 232.9444!)
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
        Me.Text7.LocationFloat = New DevExpress.Utils.PointFloat(236.7755!, 187.125!)
        Me.Text7.Name = "Text7"
        Me.Text7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.Text7.SizeF = New System.Drawing.SizeF(318.75!, 21.59723!)
        Me.Text7.StylePriority.UseFont = False
        Me.Text7.StylePriority.UseTextAlignment = False
        Me.Text7.Text = "Statement of Comprehensive Income"
        Me.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'PrintDate1
        '
        Me.PrintDate1.BackColor = System.Drawing.Color.White
        Me.PrintDate1.BorderColor = System.Drawing.Color.Black
        Me.PrintDate1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PrintDate1.BorderWidth = 1.0!
        Me.PrintDate1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PrintDate1.ForeColor = System.Drawing.Color.Black
        Me.PrintDate1.LocationFloat = New DevExpress.Utils.PointFloat(14.04165!, 232.9444!)
        Me.PrintDate1.Name = "PrintDate1"
        Me.PrintDate1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.PrintDate1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.PrintDate1.SizeF = New System.Drawing.SizeF(181.25!, 15.34721!)
        Me.PrintDate1.StylePriority.UseFont = False
        Me.PrintDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'PrintTime1
        '
        Me.PrintTime1.BackColor = System.Drawing.Color.White
        Me.PrintTime1.BorderColor = System.Drawing.Color.Black
        Me.PrintTime1.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PrintTime1.BorderWidth = 1.0!
        Me.PrintTime1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PrintTime1.ForeColor = System.Drawing.Color.Black
        Me.PrintTime1.LocationFloat = New DevExpress.Utils.PointFloat(628.4167!, 232.9444!)
        Me.PrintTime1.Name = "PrintTime1"
        Me.PrintTime1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.PrintTime1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.PrintTime1.SizeF = New System.Drawing.SizeF(91.66666!, 15.34722!)
        Me.PrintTime1.StylePriority.UseFont = False
        Me.PrintTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.PrintTime1.TextFormatString = "{0:t}"
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(14.04165!, 76.99998!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(130.2083!, 109.4583!)
        '
        'XrLabel1
        '
        Me.XrLabel1.ExpressionBindings.AddRange(New DevExpress.XtraReports.UI.ExpressionBinding() {New DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?pComp")})
        Me.XrLabel1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(233.6252!, 26.625!)
        Me.XrLabel1.Multiline = True
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(339.0416!, 143.8333!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLine3
        '
        Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0!, 255.1666!)
        Me.XrLine3.Name = "XrLine3"
        Me.XrLine3.SizeF = New System.Drawing.SizeF(763.5417!, 2.083344!)
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
        Me.XrTable2.SizeF = New System.Drawing.SizeF(763.5417!, 25.0!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseForeColor = False
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.XrTableCell4})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Multiline = True
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell3.Text = "Accounts"
        Me.XrTableCell3.Weight = 1.455128173828125R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.Multiline = True
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell4.StylePriority.UseTextAlignment = False
        Me.XrTableCell4.Text = "Amount"
        Me.XrTableCell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.XrTableCell4.Weight = 0.544871826171875R
        '
        'ReportFooter
        '
        Me.ReportFooter.HeightF = 173.9583!
        Me.ReportFooter.Name = "ReportFooter"
        '
        'PageFooter
        '
        Me.PageFooter.Name = "PageFooter"
        '
        'DsIncomeStatement1
        '
        Me.DsIncomeStatement1.DataSetName = "dsIncomeStatement"
        Me.DsIncomeStatement1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'pComp
        '
        Me.pComp.Description = "Parameter1"
        Me.pComp.Name = "pComp"
        '
        'MyAsOfDate
        '
        Me.MyAsOfDate.Description = "Parameter1"
        Me.MyAsOfDate.Name = "MyAsOfDate"
        Me.MyAsOfDate.Type = GetType(Date)
        '
        'IncStatement_Rep
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMargin, Me.BottomMargin, Me.Detail, Me.ReportHeader, Me.PageHeader, Me.ReportFooter, Me.PageFooter})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.DsIncomeStatement1})
        Me.DataMember = "IncomeStatement"
        Me.DataSource = Me.DsIncomeStatement1
        Me.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Margins = New System.Drawing.Printing.Margins(31, 54, 39, 100)
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.pComp, Me.MyAsOfDate})
        Me.Version = "18.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsIncomeStatement1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents ReportFooter As DevExpress.XtraReports.UI.ReportFooterBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents DsIncomeStatement1 As dsIncomeStatement
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents MyAsOfDate1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text8 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents Text7 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents PrintDate1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents PrintTime1 As DevExpress.XtraReports.UI.XRPageInfo
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    Friend WithEvents pComp As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents MyAsOfDate As DevExpress.XtraReports.Parameters.Parameter
End Class

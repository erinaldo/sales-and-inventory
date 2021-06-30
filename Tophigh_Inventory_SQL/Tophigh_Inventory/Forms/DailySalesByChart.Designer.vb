<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DailySalesByChart
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DailySalesByChart))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.PanelControl2 = New DevExpress.XtraEditors.PanelControl()
        Me.btnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtdateto = New System.Windows.Forms.DateTimePicker()
        Me.dtdatefrom = New System.Windows.Forms.DateTimePicker()
        Me.PrefbyproductBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsSalesPerfbychartproduct = New Tophigh_Inventory.dsSalesPerfbychartproduct()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.PivotGridControl1 = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.fieldDate1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldItems1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldQty1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldSalesPrice1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldAmount1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.fieldLocation1 = New DevExpress.XtraPivotGrid.PivotGridField()
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl2.SuspendLayout()
        CType(Me.PrefbyproductBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSalesPerfbychartproduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl2
        '
        Me.PanelControl2.Controls.Add(Me.btnRefresh)
        Me.PanelControl2.Controls.Add(Me.btnsearch)
        Me.PanelControl2.Controls.Add(Me.Label2)
        Me.PanelControl2.Controls.Add(Me.Label1)
        Me.PanelControl2.Controls.Add(Me.dtdateto)
        Me.PanelControl2.Controls.Add(Me.dtdatefrom)
        Me.PanelControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl2.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl2.Name = "PanelControl2"
        Me.PanelControl2.Size = New System.Drawing.Size(788, 38)
        Me.PanelControl2.TabIndex = 1
        '
        'btnRefresh
        '
        Me.btnRefresh.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refresh_16x16
        Me.btnRefresh.Location = New System.Drawing.Point(450, 10)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(78, 23)
        Me.btnRefresh.TabIndex = 5
        Me.btnRefresh.Text = "Refresh"
        '
        'btnsearch
        '
        Me.btnsearch.ImageOptions.Image = CType(resources.GetObject("btnsearch.ImageOptions.Image"), System.Drawing.Image)
        Me.btnsearch.Location = New System.Drawing.Point(366, 10)
        Me.btnsearch.Name = "btnsearch"
        Me.btnsearch.Size = New System.Drawing.Size(78, 23)
        Me.btnsearch.TabIndex = 4
        Me.btnsearch.Text = "Search"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(193, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Date To :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date From :"
        '
        'dtdateto
        '
        Me.dtdateto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdateto.Location = New System.Drawing.Point(251, 9)
        Me.dtdateto.Name = "dtdateto"
        Me.dtdateto.Size = New System.Drawing.Size(98, 21)
        Me.dtdateto.TabIndex = 1
        '
        'dtdatefrom
        '
        Me.dtdatefrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdatefrom.Location = New System.Drawing.Point(82, 9)
        Me.dtdatefrom.Name = "dtdatefrom"
        Me.dtdatefrom.Size = New System.Drawing.Size(95, 21)
        Me.dtdatefrom.TabIndex = 0
        '
        'PrefbyproductBindingSource
        '
        Me.PrefbyproductBindingSource.DataMember = "prefbyproduct"
        Me.PrefbyproductBindingSource.DataSource = Me.DsSalesPerfbychartproduct
        '
        'DsSalesPerfbychartproduct
        '
        Me.DsSalesPerfbychartproduct.DataSetName = "dsSalesPerfbychartproduct"
        Me.DsSalesPerfbychartproduct.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 38)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Chart1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PivotGridControl1)
        Me.SplitContainer1.Size = New System.Drawing.Size(788, 450)
        Me.SplitContainer1.SplitterDistance = 247
        Me.SplitContainer1.TabIndex = 2
        '
        'Chart1
        '
        ChartArea1.Name = "Daily Sales Performance"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Legend1.TitleAlignment = System.Drawing.StringAlignment.Far
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Series1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot
        Series1.ChartArea = "Daily Sales Performance"
        Series1.Color = System.Drawing.Color.Green
        Series1.IsXValueIndexed = True
        Series1.Legend = "Legend1"
        Series1.Name = "Sales"
        Series2.ChartArea = "Daily Sales Performance"
        Series2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Series2.Legend = "Legend1"
        Series2.Name = "Quantities"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Series.Add(Series2)
        Me.Chart1.Size = New System.Drawing.Size(788, 247)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Daily Sales Performance"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Title1.Name = "Daily Sales Performance"
        Title1.Text = "Daily Sales Performance"
        Me.Chart1.Titles.Add(Title1)
        '
        'PivotGridControl1
        '
        Me.PivotGridControl1.DataSource = Me.PrefbyproductBindingSource
        Me.PivotGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PivotGridControl1.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.fieldDate1, Me.fieldItems1, Me.fieldQty1, Me.fieldSalesPrice1, Me.fieldAmount1, Me.fieldLocation1})
        Me.PivotGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.PivotGridControl1.Name = "PivotGridControl1"
        Me.PivotGridControl1.Size = New System.Drawing.Size(788, 199)
        Me.PivotGridControl1.TabIndex = 0
        '
        'fieldDate1
        '
        Me.fieldDate1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldDate1.AreaIndex = 0
        Me.fieldDate1.Caption = "Date"
        Me.fieldDate1.FieldName = "Date"
        Me.fieldDate1.Name = "fieldDate1"
        '
        'fieldItems1
        '
        Me.fieldItems1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldItems1.AreaIndex = 1
        Me.fieldItems1.Caption = "Items"
        Me.fieldItems1.FieldName = "Items"
        Me.fieldItems1.Name = "fieldItems1"
        '
        'fieldQty1
        '
        Me.fieldQty1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldQty1.AreaIndex = 2
        Me.fieldQty1.Caption = "Qty"
        Me.fieldQty1.FieldName = "Qty"
        Me.fieldQty1.Name = "fieldQty1"
        '
        'fieldSalesPrice1
        '
        Me.fieldSalesPrice1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.fieldSalesPrice1.AreaIndex = 3
        Me.fieldSalesPrice1.Caption = "Sales Price"
        Me.fieldSalesPrice1.FieldName = "Sales Price"
        Me.fieldSalesPrice1.Name = "fieldSalesPrice1"
        '
        'fieldAmount1
        '
        Me.fieldAmount1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.fieldAmount1.AreaIndex = 0
        Me.fieldAmount1.Caption = "Amount"
        Me.fieldAmount1.FieldName = "Amount"
        Me.fieldAmount1.Name = "fieldAmount1"
        '
        'fieldLocation1
        '
        Me.fieldLocation1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.fieldLocation1.AreaIndex = 0
        Me.fieldLocation1.Caption = "Location"
        Me.fieldLocation1.FieldName = "Location"
        Me.fieldLocation1.Name = "fieldLocation1"
        '
        'DailySalesByChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 488)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PanelControl2)
        Me.MaximizeBox = False
        Me.Name = "DailySalesByChart"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Daily Sales By Chart"
        CType(Me.PanelControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl2.ResumeLayout(False)
        Me.PanelControl2.PerformLayout()
        CType(Me.PrefbyproductBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSalesPerfbychartproduct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PivotGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelControl2 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnsearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtdateto As DateTimePicker
    Friend WithEvents dtdatefrom As DateTimePicker
    Friend WithEvents btnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents DsSalesPerfbychartproduct As dsSalesPerfbychartproduct
    Friend WithEvents PrefbyproductBindingSource As BindingSource
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PivotGridControl1 As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents fieldDate1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldItems1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldQty1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldSalesPrice1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldAmount1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents fieldLocation1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
End Class

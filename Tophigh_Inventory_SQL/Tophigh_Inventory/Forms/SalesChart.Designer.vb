<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesChart
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series4 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series5 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series6 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series7 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series8 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series9 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series10 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series11 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series12 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvbestsell = New DevExpress.XtraGrid.GridControl()
        Me.BestproBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsBestPro = New Tophigh_Inventory.dsBestPro()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.monthlychart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.lblyears = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvbestsell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestproBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsBestPro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.monthlychart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackgroundWorker1
        '
        '
        'Timer1
        '
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1091, 756)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvbestsell)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1083, 730)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Best Selling Product by Location"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvbestsell
        '
        Me.dgvbestsell.DataSource = Me.BestproBindingSource
        Me.dgvbestsell.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvbestsell.Location = New System.Drawing.Point(3, 3)
        Me.dgvbestsell.MainView = Me.GridView1
        Me.dgvbestsell.Name = "dgvbestsell"
        Me.dgvbestsell.Size = New System.Drawing.Size(1077, 724)
        Me.dgvbestsell.TabIndex = 0
        Me.dgvbestsell.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'BestproBindingSource
        '
        Me.BestproBindingSource.DataMember = "best_pro"
        Me.BestproBindingSource.DataSource = Me.DsBestPro
        '
        'DsBestPro
        '
        Me.DsBestPro.DataSetName = "dsBestPro"
        Me.DsBestPro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colProduct, Me.colTotalQuantity, Me.colLocation})
        Me.GridView1.GridControl = Me.dgvbestsell
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colLocation, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'colProduct
        '
        Me.colProduct.FieldName = "Product"
        Me.colProduct.Name = "colProduct"
        Me.colProduct.Visible = True
        Me.colProduct.VisibleIndex = 0
        '
        'colTotalQuantity
        '
        Me.colTotalQuantity.FieldName = "TotalQuantity"
        Me.colTotalQuantity.Name = "colTotalQuantity"
        Me.colTotalQuantity.Visible = True
        Me.colTotalQuantity.VisibleIndex = 1
        '
        'colLocation
        '
        Me.colLocation.FieldName = "Location"
        Me.colLocation.Name = "colLocation"
        Me.colLocation.Visible = True
        Me.colLocation.VisibleIndex = 2
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LayoutControl1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1083, 730)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sales Performance Chart"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.monthlychart)
        Me.LayoutControl1.Controls.Add(Me.Panel1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1077, 724)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'monthlychart
        '
        ChartArea1.Name = "ChartArea1"
        Me.monthlychart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.monthlychart.Legends.Add(Legend1)
        Me.monthlychart.Location = New System.Drawing.Point(12, 52)
        Me.monthlychart.Name = "monthlychart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "January"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "February"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "March"
        Series4.ChartArea = "ChartArea1"
        Series4.Legend = "Legend1"
        Series4.Name = "April"
        Series5.ChartArea = "ChartArea1"
        Series5.Legend = "Legend1"
        Series5.Name = "May"
        Series6.ChartArea = "ChartArea1"
        Series6.Legend = "Legend1"
        Series6.Name = "June"
        Series7.ChartArea = "ChartArea1"
        Series7.Legend = "Legend1"
        Series7.Name = "July"
        Series8.ChartArea = "ChartArea1"
        Series8.Legend = "Legend1"
        Series8.Name = "August"
        Series9.ChartArea = "ChartArea1"
        Series9.Legend = "Legend1"
        Series9.Name = "September"
        Series10.ChartArea = "ChartArea1"
        Series10.Legend = "Legend1"
        Series10.Name = "October"
        Series11.ChartArea = "ChartArea1"
        Series11.Legend = "Legend1"
        Series11.Name = "November"
        Series12.ChartArea = "ChartArea1"
        Series12.Legend = "Legend1"
        Series12.Name = "December"
        Me.monthlychart.Series.Add(Series1)
        Me.monthlychart.Series.Add(Series2)
        Me.monthlychart.Series.Add(Series3)
        Me.monthlychart.Series.Add(Series4)
        Me.monthlychart.Series.Add(Series5)
        Me.monthlychart.Series.Add(Series6)
        Me.monthlychart.Series.Add(Series7)
        Me.monthlychart.Series.Add(Series8)
        Me.monthlychart.Series.Add(Series9)
        Me.monthlychart.Series.Add(Series10)
        Me.monthlychart.Series.Add(Series11)
        Me.monthlychart.Series.Add(Series12)
        Me.monthlychart.Size = New System.Drawing.Size(1053, 296)
        Me.monthlychart.TabIndex = 0
        Me.monthlychart.Text = "Chart1"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1053, 36)
        Me.Panel1.TabIndex = 1
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1077, 724)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.Panel1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1057, 40)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 340)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1057, 364)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.monthlychart
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 40)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1057, 300)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'lblyears
        '
        Me.lblyears.AutoSize = True
        Me.lblyears.Location = New System.Drawing.Point(605, 119)
        Me.lblyears.Name = "lblyears"
        Me.lblyears.Size = New System.Drawing.Size(38, 13)
        Me.lblyears.TabIndex = 1
        Me.lblyears.Text = "Label1"
        '
        'SalesChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 756)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblyears)
        Me.MaximizeBox = False
        Me.Name = "SalesChart"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sales Chart"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvbestsell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestproBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsBestPro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.monthlychart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvbestsell As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents BestproBindingSource As BindingSource
    Friend WithEvents DsBestPro As dsBestPro
    Friend WithEvents colProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLocation As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblyears As Label
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents monthlychart As DataVisualization.Charting.Chart
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class

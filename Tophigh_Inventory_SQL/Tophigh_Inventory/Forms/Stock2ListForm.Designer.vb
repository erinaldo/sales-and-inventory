<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock2ListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnsales = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnreport = New DevExpress.XtraEditors.SimpleButton()
        Me.btnadd = New DevExpress.XtraEditors.SimpleButton()
        Me.btnrecorder = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnrefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dgvstock2 = New DevExpress.XtraGrid.GridControl()
        Me.Store2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsStock2 = New Tophigh_Inventory.dsStock2()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colproduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colcurrent_qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colsales_price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvstock2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Store2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsStock2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnsales)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnreport)
        Me.Panel1.Controls.Add(Me.btnadd)
        Me.Panel1.Controls.Add(Me.btnrecorder)
        Me.Panel1.Controls.Add(Me.SimpleButton1)
        Me.Panel1.Controls.Add(Me.btnrefresh)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(705, 26)
        Me.Panel1.TabIndex = 0
        '
        'btnsales
        '
        Me.btnsales.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnsales.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.bosale_16x163
        Me.btnsales.Location = New System.Drawing.Point(178, 0)
        Me.btnsales.Name = "btnsales"
        Me.btnsales.Size = New System.Drawing.Size(80, 26)
        Me.btnsales.TabIndex = 5
        Me.btnsales.Text = "Sales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(44, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Stock List"
        '
        'btnreport
        '
        Me.btnreport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnreport.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.bosale_16x163
        Me.btnreport.Location = New System.Drawing.Point(258, 0)
        Me.btnreport.Name = "btnreport"
        Me.btnreport.Size = New System.Drawing.Size(100, 26)
        Me.btnreport.TabIndex = 3
        Me.btnreport.Text = "Sales Report"
        '
        'btnadd
        '
        Me.btnadd.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnadd.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.addnewdatasource_16x162
        Me.btnadd.Location = New System.Drawing.Point(358, 0)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(80, 26)
        Me.btnadd.TabIndex = 2
        Me.btnadd.Text = "Add New"
        '
        'btnrecorder
        '
        Me.btnrecorder.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnrecorder.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.boorderitem_16x162
        Me.btnrecorder.Location = New System.Drawing.Point(438, 0)
        Me.btnrecorder.Name = "btnrecorder"
        Me.btnrecorder.Size = New System.Drawing.Size(107, 26)
        Me.btnrecorder.TabIndex = 1
        Me.btnrecorder.Text = "Receive Order"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton1.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.historyitem_16x161
        Me.SimpleButton1.Location = New System.Drawing.Point(545, 0)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(80, 26)
        Me.SimpleButton1.TabIndex = 6
        Me.SimpleButton1.Text = "History"
        '
        'btnrefresh
        '
        Me.btnrefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnrefresh.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refresh_16x166
        Me.btnrefresh.Location = New System.Drawing.Point(625, 0)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(80, 26)
        Me.btnrefresh.TabIndex = 0
        Me.btnrefresh.Text = "Refresh"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 399)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(705, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dgvstock2
        '
        Me.dgvstock2.DataSource = Me.Store2BindingSource
        Me.dgvstock2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvstock2.Location = New System.Drawing.Point(0, 26)
        Me.dgvstock2.MainView = Me.GridView1
        Me.dgvstock2.Name = "dgvstock2"
        Me.dgvstock2.Size = New System.Drawing.Size(705, 373)
        Me.dgvstock2.TabIndex = 2
        Me.dgvstock2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'Store2BindingSource
        '
        Me.Store2BindingSource.DataMember = "store_2"
        Me.Store2BindingSource.DataSource = Me.DsStock2
        '
        'DsStock2
        '
        Me.DsStock2.DataSetName = "dsStock2"
        Me.DsStock2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colproduct, Me.colcurrent_qty, Me.colsales_price})
        Me.GridView1.GridControl = Me.dgvstock2
        Me.GridView1.Name = "GridView1"
        '
        'colproduct
        '
        Me.colproduct.Caption = "Product"
        Me.colproduct.FieldName = "product"
        Me.colproduct.Name = "colproduct"
        Me.colproduct.Visible = True
        Me.colproduct.VisibleIndex = 0
        '
        'colcurrent_qty
        '
        Me.colcurrent_qty.AppearanceCell.Options.UseTextOptions = True
        Me.colcurrent_qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colcurrent_qty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colcurrent_qty.AppearanceHeader.Options.UseTextOptions = True
        Me.colcurrent_qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colcurrent_qty.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colcurrent_qty.Caption = "Current Qty"
        Me.colcurrent_qty.FieldName = "current_qty"
        Me.colcurrent_qty.Name = "colcurrent_qty"
        Me.colcurrent_qty.Visible = True
        Me.colcurrent_qty.VisibleIndex = 1
        '
        'colsales_price
        '
        Me.colsales_price.AppearanceCell.Options.UseTextOptions = True
        Me.colsales_price.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colsales_price.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colsales_price.AppearanceHeader.Options.UseTextOptions = True
        Me.colsales_price.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colsales_price.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colsales_price.Caption = "Sales Price"
        Me.colsales_price.DisplayFormat.FormatString = "n2"
        Me.colsales_price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colsales_price.FieldName = "sales_price"
        Me.colsales_price.Name = "colsales_price"
        Me.colsales_price.Visible = True
        Me.colsales_price.VisibleIndex = 2
        '
        'Stock2ListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(705, 421)
        Me.Controls.Add(Me.dgvstock2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Stock2ListForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock 2 List"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvstock2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Store2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsStock2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnreport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnadd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnrecorder As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnrefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvstock2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Store2BindingSource As BindingSource
    Friend WithEvents DsStock2 As dsStock2
    Friend WithEvents colproduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colcurrent_qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colsales_price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnsales As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
End Class

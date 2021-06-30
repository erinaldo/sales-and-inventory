<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TestSubsriptionForm
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
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.lbldays = New System.Windows.Forms.Label()
        Me.sysdate = New System.Windows.Forms.DateTimePicker()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DsBestPro = New Tophigh_Inventory.dsBestPro()
        Me.BestproBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.colProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTotalQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colLocation = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsBestPro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BestproBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(12, 44)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(92, 20)
        Me.dtto.TabIndex = 0
        '
        'lbldays
        '
        Me.lbldays.AutoSize = True
        Me.lbldays.Location = New System.Drawing.Point(54, 83)
        Me.lbldays.Name = "lbldays"
        Me.lbldays.Size = New System.Drawing.Size(39, 13)
        Me.lbldays.TabIndex = 1
        Me.lbldays.Text = "Label1"
        '
        'sysdate
        '
        Me.sysdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.sysdate.Location = New System.Drawing.Point(12, 7)
        Me.sysdate.Name = "sysdate"
        Me.sysdate.Size = New System.Drawing.Size(92, 20)
        Me.sysdate.TabIndex = 2
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.BestproBindingSource
        Me.GridControl1.Location = New System.Drawing.Point(156, 30)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(428, 322)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colProduct, Me.colTotalQuantity, Me.colLocation})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.colLocation, DevExpress.Data.ColumnSortOrder.Ascending)})
        '
        'DsBestPro
        '
        Me.DsBestPro.DataSetName = "dsBestPro"
        Me.DsBestPro.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BestproBindingSource
        '
        Me.BestproBindingSource.DataMember = "best_pro"
        Me.BestproBindingSource.DataSource = Me.DsBestPro
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
        'TestSubsriptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(759, 364)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.sysdate)
        Me.Controls.Add(Me.lbldays)
        Me.Controls.Add(Me.dtto)
        Me.Name = "TestSubsriptionForm"
        Me.Text = "TestSubsriptionForm"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsBestPro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BestproBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents lbldays As Label
    Friend WithEvents sysdate As DateTimePicker
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BestproBindingSource As BindingSource
    Friend WithEvents DsBestPro As dsBestPro
    Friend WithEvents colProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTotalQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colLocation As DevExpress.XtraGrid.Columns.GridColumn
End Class

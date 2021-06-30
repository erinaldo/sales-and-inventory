<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StockManualCountForm
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.dtcntdate = New System.Windows.Forms.DateTimePicker()
        Me.dgvCount = New System.Windows.Forms.DataGridView()
        Me.cbolocation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txttotqty = New DevExpress.XtraEditors.TextEdit()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.txttotamt = New DevExpress.XtraEditors.TextEdit()
        Me.txtcogs = New DevExpress.XtraEditors.TextEdit()
        Me.txtinv = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.dgvCount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbolocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotqty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txttotamt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtcogs.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtinv.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.dtDate)
        Me.LayoutControl1.Controls.Add(Me.dtcntdate)
        Me.LayoutControl1.Controls.Add(Me.dgvCount)
        Me.LayoutControl1.Controls.Add(Me.cbolocation)
        Me.LayoutControl1.Controls.Add(Me.txttotqty)
        Me.LayoutControl1.Controls.Add(Me.txttotamt)
        Me.LayoutControl1.Controls.Add(Me.txtcogs)
        Me.LayoutControl1.Controls.Add(Me.txtinv)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem3, Me.LayoutControlItem2})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 143)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(702, 288)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(559, 12)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(131, 21)
        Me.dtDate.TabIndex = 16
        '
        'dtcntdate
        '
        Me.dtcntdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtcntdate.Location = New System.Drawing.Point(111, 256)
        Me.dtcntdate.Name = "dtcntdate"
        Me.dtcntdate.Size = New System.Drawing.Size(579, 21)
        Me.dtcntdate.TabIndex = 15
        '
        'dgvCount
        '
        Me.dgvCount.AllowUserToAddRows = False
        Me.dgvCount.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCount.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvCount.BackgroundColor = System.Drawing.Color.White
        Me.dgvCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCount.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvCount.Location = New System.Drawing.Point(12, 46)
        Me.dgvCount.Name = "dgvCount"
        Me.dgvCount.RowHeadersVisible = False
        Me.dgvCount.Size = New System.Drawing.Size(678, 220)
        Me.dgvCount.TabIndex = 9
        '
        'cbolocation
        '
        Me.cbolocation.Location = New System.Drawing.Point(77, 12)
        Me.cbolocation.Name = "cbolocation"
        Me.cbolocation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbolocation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbolocation.Size = New System.Drawing.Size(271, 20)
        Me.cbolocation.StyleController = Me.LayoutControl1
        Me.cbolocation.TabIndex = 10
        '
        'txttotqty
        '
        Me.txttotqty.EditValue = "0.00"
        Me.txttotqty.Location = New System.Drawing.Point(77, 256)
        Me.txttotqty.MenuManager = Me.RibbonControl1
        Me.txttotqty.Name = "txttotqty"
        Me.txttotqty.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txttotqty.Properties.Appearance.Options.UseFont = True
        Me.txttotqty.Properties.Appearance.Options.UseTextOptions = True
        Me.txttotqty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txttotqty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txttotqty.Properties.ReadOnly = True
        Me.txttotqty.Size = New System.Drawing.Size(613, 20)
        Me.txttotqty.StyleController = Me.LayoutControl1
        Me.txttotqty.TabIndex = 11
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 3
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(702, 143)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Update Stock"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.previous_16x16
        Me.BarButtonItem1.ImageOptions.LargeImage = Global.Tophigh_Inventory.My.Resources.Resources.previous_32x32
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Print Count History"
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.print_32x32
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage1.Name = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.BarButtonItem2)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 431)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(702, 31)
        '
        'txttotamt
        '
        Me.txttotamt.EditValue = "0.00"
        Me.txttotamt.Location = New System.Drawing.Point(83, 256)
        Me.txttotamt.MenuManager = Me.RibbonControl1
        Me.txttotamt.Name = "txttotamt"
        Me.txttotamt.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txttotamt.Properties.Appearance.Options.UseFont = True
        Me.txttotamt.Properties.Appearance.Options.UseTextOptions = True
        Me.txttotamt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txttotamt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txttotamt.Properties.ReadOnly = True
        Me.txttotamt.Size = New System.Drawing.Size(266, 20)
        Me.txttotamt.StyleController = Me.LayoutControl1
        Me.txttotamt.TabIndex = 12
        '
        'txtcogs
        '
        Me.txtcogs.Location = New System.Drawing.Point(111, 232)
        Me.txtcogs.MenuManager = Me.RibbonControl1
        Me.txtcogs.Name = "txtcogs"
        Me.txtcogs.Size = New System.Drawing.Size(579, 20)
        Me.txtcogs.StyleController = Me.LayoutControl1
        Me.txtcogs.TabIndex = 13
        '
        'txtinv
        '
        Me.txtinv.Location = New System.Drawing.Point(111, 256)
        Me.txtinv.MenuManager = Me.RibbonControl1
        Me.txtinv.Name = "txtinv"
        Me.txtinv.Size = New System.Drawing.Size(579, 20)
        Me.txtinv.StyleController = Me.LayoutControl1
        Me.txtinv.TabIndex = 14
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtcogs
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 220)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(682, 24)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtinv
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 244)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(682, 24)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 20)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.dtcntdate
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 244)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(682, 24)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(50, 20)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem8, Me.EmptySpaceItem3})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(702, 288)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.dgvCount
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(682, 224)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cbolocation
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(340, 24)
        Me.LayoutControlItem1.Text = "Location:"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(62, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(682, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txttotqty
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 244)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(682, 24)
        Me.LayoutControlItem2.Text = "Total Loss :"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(68, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txttotamt
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 244)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(341, 24)
        Me.LayoutControlItem3.Text = "Total Amount:"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(68, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 258)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(682, 10)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.dtDate
        Me.LayoutControlItem8.Location = New System.Drawing.Point(482, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem8.Text = "Count Date :"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(62, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(340, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(142, 24)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'StockManualCountForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 462)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.MaximizeBox = False
        Me.Name = "StockManualCountForm"
        Me.Ribbon = Me.RibbonControl1
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Inventory Stock Manual Counting"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.dgvCount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbolocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotqty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txttotamt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtcogs.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtinv.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dgvCount As DataGridView
    Friend WithEvents cbolocation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents txttotqty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txttotamt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtcogs As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtinv As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtcntdate As DateTimePicker
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
End Class

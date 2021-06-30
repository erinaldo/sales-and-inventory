<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddtoShelve
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddtoShelve))
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.txttype = New System.Windows.Forms.TextBox()
        Me.txtsaleprice = New System.Windows.Forms.TextBox()
        Me.txtreorder = New System.Windows.Forms.TextBox()
        Me.txtpcs = New System.Windows.Forms.TextBox()
        Me.txtqtyinbox = New System.Windows.Forms.TextBox()
        Me.txtucost = New System.Windows.Forms.TextBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btnAdd = New DevExpress.XtraBars.BarButtonItem()
        Me.btnRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.btnClose = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.rboUpdate = New System.Windows.Forms.RadioButton()
        Me.rboAdd = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbodestination = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbosource = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TID = New System.Windows.Forms.TextBox()
        Me.txttotpcs = New System.Windows.Forms.TextBox()
        Me.txtqtypcs = New System.Windows.Forms.TextBox()
        Me.txtmemprice = New System.Windows.Forms.TextBox()
        Me.cbodata = New System.Windows.Forms.TextBox()
        Me.txtqty = New System.Windows.Forms.TextBox()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbodestination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbosource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(188, 284)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(100, 21)
        Me.txtbarcode.TabIndex = 2
        '
        'txttype
        '
        Me.txttype.Location = New System.Drawing.Point(294, 284)
        Me.txttype.Name = "txttype"
        Me.txttype.Size = New System.Drawing.Size(100, 21)
        Me.txttype.TabIndex = 3
        '
        'txtsaleprice
        '
        Me.txtsaleprice.Location = New System.Drawing.Point(400, 284)
        Me.txtsaleprice.Name = "txtsaleprice"
        Me.txtsaleprice.Size = New System.Drawing.Size(100, 21)
        Me.txtsaleprice.TabIndex = 4
        '
        'txtreorder
        '
        Me.txtreorder.Location = New System.Drawing.Point(294, 311)
        Me.txtreorder.Name = "txtreorder"
        Me.txtreorder.Size = New System.Drawing.Size(100, 21)
        Me.txtreorder.TabIndex = 7
        Me.txtreorder.Text = "0"
        '
        'txtpcs
        '
        Me.txtpcs.Location = New System.Drawing.Point(188, 311)
        Me.txtpcs.Name = "txtpcs"
        Me.txtpcs.Size = New System.Drawing.Size(100, 21)
        Me.txtpcs.TabIndex = 6
        Me.txtpcs.Text = "0"
        '
        'txtqtyinbox
        '
        Me.txtqtyinbox.Location = New System.Drawing.Point(506, 284)
        Me.txtqtyinbox.Name = "txtqtyinbox"
        Me.txtqtyinbox.Size = New System.Drawing.Size(100, 21)
        Me.txtqtyinbox.TabIndex = 5
        '
        'txtucost
        '
        Me.txtucost.Location = New System.Drawing.Point(400, 311)
        Me.txtucost.Name = "txtucost"
        Me.txtucost.Size = New System.Drawing.Size(100, 21)
        Me.txtucost.TabIndex = 8
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(294, 255)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 21)
        Me.txtid.TabIndex = 11
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.btnAdd, Me.btnRefresh, Me.btnClose})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 4
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.Size = New System.Drawing.Size(820, 143)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        '
        'btnAdd
        '
        Me.btnAdd.Caption = "Add"
        Me.btnAdd.Id = 1
        Me.btnAdd.ImageOptions.Image = CType(resources.GetObject("btnAdd.ImageOptions.Image"), System.Drawing.Image)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnRefresh
        '
        Me.btnRefresh.Caption = "Refresh"
        Me.btnRefresh.Id = 2
        Me.btnRefresh.ImageOptions.Image = CType(resources.GetObject("btnRefresh.ImageOptions.Image"), System.Drawing.Image)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'btnClose
        '
        Me.btnClose.Caption = "Close"
        Me.btnClose.Id = 3
        Me.btnClose.ImageOptions.Image = CType(resources.GetObject("btnClose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2, Me.RibbonPageGroup3})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Files"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btnAdd)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btnRefresh)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ImageOptions.Image = CType(resources.GetObject("RibbonPageGroup3.ImageOptions.Image"), System.Drawing.Image)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btnClose)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 474)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(820, 31)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.rboUpdate)
        Me.PanelControl1.Controls.Add(Me.rboAdd)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.cbodestination)
        Me.PanelControl1.Controls.Add(Me.cbosource)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 443)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(820, 31)
        Me.PanelControl1.TabIndex = 17
        '
        'rboUpdate
        '
        Me.rboUpdate.AutoSize = True
        Me.rboUpdate.Location = New System.Drawing.Point(595, 8)
        Me.rboUpdate.Name = "rboUpdate"
        Me.rboUpdate.Size = New System.Drawing.Size(60, 17)
        Me.rboUpdate.TabIndex = 24
        Me.rboUpdate.TabStop = True
        Me.rboUpdate.Text = "Update"
        Me.rboUpdate.UseVisualStyleBackColor = True
        '
        'rboAdd
        '
        Me.rboAdd.AutoSize = True
        Me.rboAdd.Checked = True
        Me.rboAdd.Location = New System.Drawing.Point(521, 8)
        Me.rboAdd.Name = "rboAdd"
        Me.rboAdd.Size = New System.Drawing.Size(68, 17)
        Me.rboAdd.TabIndex = 23
        Me.rboAdd.TabStop = True
        Me.rboAdd.Text = "Add New"
        Me.rboAdd.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Destination :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Source  :"
        '
        'cbodestination
        '
        Me.cbodestination.Location = New System.Drawing.Point(337, 5)
        Me.cbodestination.Name = "cbodestination"
        Me.cbodestination.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbodestination.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbodestination.Size = New System.Drawing.Size(178, 20)
        Me.cbodestination.TabIndex = 20
        '
        'cbosource
        '
        Me.cbosource.Location = New System.Drawing.Point(66, 5)
        Me.cbosource.Name = "cbosource"
        Me.cbosource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbosource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbosource.Size = New System.Drawing.Size(189, 20)
        Me.cbosource.TabIndex = 19
        '
        'dgvData
        '
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvData.Location = New System.Drawing.Point(0, 143)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.Size = New System.Drawing.Size(820, 300)
        Me.dgvData.TabIndex = 18
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteRowToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(134, 26)
        '
        'DeleteRowToolStripMenuItem
        '
        Me.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem"
        Me.DeleteRowToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DeleteRowToolStripMenuItem.Text = "Delete Row"
        '
        'TID
        '
        Me.TID.Location = New System.Drawing.Point(400, 255)
        Me.TID.Name = "TID"
        Me.TID.Size = New System.Drawing.Size(100, 21)
        Me.TID.TabIndex = 21
        '
        'txttotpcs
        '
        Me.txttotpcs.Location = New System.Drawing.Point(506, 257)
        Me.txttotpcs.Name = "txttotpcs"
        Me.txttotpcs.Size = New System.Drawing.Size(100, 21)
        Me.txttotpcs.TabIndex = 22
        Me.txttotpcs.Text = "0"
        '
        'txtqtypcs
        '
        Me.txtqtypcs.Location = New System.Drawing.Point(506, 311)
        Me.txtqtypcs.Name = "txtqtypcs"
        Me.txtqtypcs.Size = New System.Drawing.Size(100, 21)
        Me.txtqtypcs.TabIndex = 23
        Me.txtqtypcs.Text = "0"
        '
        'txtmemprice
        '
        Me.txtmemprice.Location = New System.Drawing.Point(198, 338)
        Me.txtmemprice.Name = "txtmemprice"
        Me.txtmemprice.Size = New System.Drawing.Size(100, 21)
        Me.txtmemprice.TabIndex = 25
        '
        'cbodata
        '
        Me.cbodata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbodata.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cbodata.Location = New System.Drawing.Point(34, 214)
        Me.cbodata.Name = "cbodata"
        Me.cbodata.Size = New System.Drawing.Size(174, 21)
        Me.cbodata.TabIndex = 30
        Me.cbodata.Visible = False
        '
        'txtqty
        '
        Me.txtqty.Location = New System.Drawing.Point(416, 226)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(100, 21)
        Me.txtqty.TabIndex = 33
        '
        'AddtoShelve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(820, 505)
        Me.Controls.Add(Me.cbodata)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.txtid)
        Me.Controls.Add(Me.txtbarcode)
        Me.Controls.Add(Me.txttype)
        Me.Controls.Add(Me.txtsaleprice)
        Me.Controls.Add(Me.txtqtyinbox)
        Me.Controls.Add(Me.txtpcs)
        Me.Controls.Add(Me.txtreorder)
        Me.Controls.Add(Me.txtucost)
        Me.Controls.Add(Me.txttotpcs)
        Me.Controls.Add(Me.txtqtypcs)
        Me.Controls.Add(Me.TID)
        Me.Controls.Add(Me.txtmemprice)
        Me.Controls.Add(Me.txtqty)
        Me.Controls.Add(Me.RibbonControl1)
        Me.MaximizeBox = False
        Me.Name = "AddtoShelve"
        Me.Ribbon = Me.RibbonControl1
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "Add to Shelve"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cbodestination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbosource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents txttype As TextBox
    Friend WithEvents txtsaleprice As TextBox
    Friend WithEvents txtreorder As TextBox
    Friend WithEvents txtpcs As TextBox
    Friend WithEvents txtqtyinbox As TextBox
    Friend WithEvents txtucost As TextBox
    Friend WithEvents txtid As TextBox
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbodestination As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbosource As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents btnAdd As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btnClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents rboUpdate As RadioButton
    Friend WithEvents rboAdd As RadioButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TID As TextBox
    Friend WithEvents txttotpcs As TextBox
    Friend WithEvents txtqtypcs As TextBox
    Friend WithEvents txtmemprice As TextBox
    Friend WithEvents cbodata As TextBox
    Friend WithEvents txtqty As TextBox
End Class

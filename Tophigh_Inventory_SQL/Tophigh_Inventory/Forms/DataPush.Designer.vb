<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DataPush
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnPush = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotals = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbodestination = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cbosource = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cmdpush = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.cbodata = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.txttype = New System.Windows.Forms.TextBox()
        Me.txtsaleprice = New System.Windows.Forms.TextBox()
        Me.txtpcs = New System.Windows.Forms.TextBox()
        Me.txtreorder = New System.Windows.Forms.TextBox()
        Me.txtucost = New System.Windows.Forms.TextBox()
        Me.TID = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.cbodestination.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbosource.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbodata.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.Label5)
        Me.PanelControl1.Controls.Add(Me.dtDate)
        Me.PanelControl1.Controls.Add(Me.Label4)
        Me.PanelControl1.Controls.Add(Me.cbostatus)
        Me.PanelControl1.Controls.Add(Me.btnClose)
        Me.PanelControl1.Controls.Add(Me.btnPush)
        Me.PanelControl1.Controls.Add(Me.Label3)
        Me.PanelControl1.Controls.Add(Me.txtTotals)
        Me.PanelControl1.Controls.Add(Me.Label2)
        Me.PanelControl1.Controls.Add(Me.Label1)
        Me.PanelControl1.Controls.Add(Me.cbodestination)
        Me.PanelControl1.Controls.Add(Me.cbosource)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 376)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(724, 104)
        Me.PanelControl1.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(362, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Date:"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(406, 10)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(94, 21)
        Me.dtDate.TabIndex = 32
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(528, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Status :"
        '
        'cbostatus
        '
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"Pending", "Reverse"})
        Me.cbostatus.Location = New System.Drawing.Point(579, 61)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(130, 21)
        Me.cbostatus.TabIndex = 30
        '
        'btnClose
        '
        Me.btnClose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.cancel_32x326
        Me.btnClose.Location = New System.Drawing.Point(129, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(111, 42)
        Me.btnClose.TabIndex = 29
        Me.btnClose.Text = "Close"
        '
        'btnPush
        '
        Me.btnPush.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.previous_32x321
        Me.btnPush.Location = New System.Drawing.Point(12, 5)
        Me.btnPush.Name = "btnPush"
        Me.btnPush.Size = New System.Drawing.Size(111, 42)
        Me.btnPush.TabIndex = 27
        Me.btnPush.Text = "Transfer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(506, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Total value :"
        '
        'txtTotals
        '
        Me.txtTotals.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotals.Location = New System.Drawing.Point(579, 10)
        Me.txtTotals.Name = "txtTotals"
        Me.txtTotals.ReadOnly = True
        Me.txtTotals.Size = New System.Drawing.Size(130, 21)
        Me.txtTotals.TabIndex = 25
        Me.txtTotals.Text = "0.00"
        Me.txtTotals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Destination :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Source  :"
        '
        'cbodestination
        '
        Me.cbodestination.Location = New System.Drawing.Point(337, 63)
        Me.cbodestination.Name = "cbodestination"
        Me.cbodestination.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbodestination.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbodestination.Size = New System.Drawing.Size(178, 20)
        Me.cbodestination.TabIndex = 20
        '
        'cbosource
        '
        Me.cbosource.Location = New System.Drawing.Point(66, 63)
        Me.cbosource.Name = "cbosource"
        Me.cbosource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbosource.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbosource.Size = New System.Drawing.Size(189, 20)
        Me.cbosource.TabIndex = 19
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdpush, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(724, 25)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cmdpush
        '
        Me.cmdpush.Image = Global.Tophigh_Inventory.My.Resources.Resources.previous_32x32
        Me.cmdpush.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmdpush.Name = "cmdpush"
        Me.cmdpush.Size = New System.Drawing.Size(68, 22)
        Me.cmdpush.Text = "Transfer"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'dgvData
        '
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.GridColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.dgvData.Location = New System.Drawing.Point(0, 25)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.Size = New System.Drawing.Size(724, 351)
        Me.dgvData.TabIndex = 20
        '
        'cbodata
        '
        Me.cbodata.Location = New System.Drawing.Point(61, 102)
        Me.cbodata.Name = "cbodata"
        Me.cbodata.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbodata.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbodata.Size = New System.Drawing.Size(174, 20)
        Me.cbodata.TabIndex = 29
        Me.cbodata.Visible = False
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(318, 174)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 20)
        Me.txtid.TabIndex = 28
        '
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(212, 203)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(100, 20)
        Me.txtbarcode.TabIndex = 22
        '
        'txttype
        '
        Me.txttype.Location = New System.Drawing.Point(318, 203)
        Me.txttype.Name = "txttype"
        Me.txttype.Size = New System.Drawing.Size(100, 20)
        Me.txttype.TabIndex = 23
        '
        'txtsaleprice
        '
        Me.txtsaleprice.Location = New System.Drawing.Point(424, 203)
        Me.txtsaleprice.Name = "txtsaleprice"
        Me.txtsaleprice.Size = New System.Drawing.Size(100, 20)
        Me.txtsaleprice.TabIndex = 24
        '
        'txtpcs
        '
        Me.txtpcs.Location = New System.Drawing.Point(212, 230)
        Me.txtpcs.Name = "txtpcs"
        Me.txtpcs.Size = New System.Drawing.Size(100, 20)
        Me.txtpcs.TabIndex = 25
        Me.txtpcs.Text = "0"
        '
        'txtreorder
        '
        Me.txtreorder.Location = New System.Drawing.Point(318, 230)
        Me.txtreorder.Name = "txtreorder"
        Me.txtreorder.Size = New System.Drawing.Size(100, 20)
        Me.txtreorder.TabIndex = 26
        Me.txtreorder.Text = "0"
        '
        'txtucost
        '
        Me.txtucost.Location = New System.Drawing.Point(424, 230)
        Me.txtucost.Name = "txtucost"
        Me.txtucost.Size = New System.Drawing.Size(100, 20)
        Me.txtucost.TabIndex = 27
        '
        'TID
        '
        Me.TID.Location = New System.Drawing.Point(524, 294)
        Me.TID.Name = "TID"
        Me.TID.Size = New System.Drawing.Size(100, 20)
        Me.TID.TabIndex = 30
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'DataPush
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(724, 480)
        Me.Controls.Add(Me.cbodata)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.TID)
        Me.Controls.Add(Me.txtucost)
        Me.Controls.Add(Me.txtsaleprice)
        Me.Controls.Add(Me.txtreorder)
        Me.Controls.Add(Me.txtpcs)
        Me.Controls.Add(Me.txtbarcode)
        Me.Controls.Add(Me.txttype)
        Me.Controls.Add(Me.txtid)
        Me.MaximizeBox = False
        Me.Name = "DataPush"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Product Transfer"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        CType(Me.cbodestination.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbosource.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbodata.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotals As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbodestination As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cbosource As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents cmdpush As ToolStripButton
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents cbodata As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents txttype As TextBox
    Friend WithEvents txtsaleprice As TextBox
    Friend WithEvents txtpcs As TextBox
    Friend WithEvents txtreorder As TextBox
    Friend WithEvents txtucost As TextBox
    Friend WithEvents TID As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnPush As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents cbostatus As ComboBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents Label5 As Label
    Friend WithEvents dtDate As DateTimePicker
End Class

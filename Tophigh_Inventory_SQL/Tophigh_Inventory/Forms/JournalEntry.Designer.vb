<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JournalEntry
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtentdate = New DevExpress.XtraEditors.DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtentno = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnadd = New DevExpress.XtraEditors.SimpleButton()
        Me.txtdebit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboCreditAcc = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboaccount = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dgvjournal = New System.Windows.Forms.DataGridView()
        Me.txtaccnum = New System.Windows.Forms.TextBox()
        Me.txtcbank = New System.Windows.Forms.TextBox()
        Me.txtcreditcheck = New System.Windows.Forms.TextBox()
        Me.txtbank = New System.Windows.Forms.TextBox()
        Me.txtdebitchecck = New System.Windows.Forms.TextBox()
        Me.txtcredit = New System.Windows.Forms.TextBox()
        Me.txtcaccnum = New System.Windows.Forms.TextBox()
        Me.txtcrebal = New System.Windows.Forms.TextBox()
        Me.txtdebbal = New System.Windows.Forms.TextBox()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtentdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtentdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.dgvjournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtentdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtentno)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 95)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(0, 101)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(526, 158)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Journal Date :"
        '
        'dtentdate
        '
        Me.dtentdate.EditValue = Nothing
        Me.dtentdate.Location = New System.Drawing.Point(85, 57)
        Me.dtentdate.Name = "dtentdate"
        Me.dtentdate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.dtentdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtentdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtentdate.Size = New System.Drawing.Size(225, 20)
        Me.dtentdate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Journal # :"
        '
        'txtentno
        '
        Me.txtentno.Location = New System.Drawing.Point(85, 31)
        Me.txtentno.Name = "txtentno"
        Me.txtentno.ReadOnly = True
        Me.txtentno.Size = New System.Drawing.Size(116, 20)
        Me.txtentno.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnadd)
        Me.GroupBox3.Controls.Add(Me.txtdebit)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtdescription)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cboCreditAcc)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cboaccount)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(683, 94)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'btnadd
        '
        Me.btnadd.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.add_32x32
        Me.btnadd.Location = New System.Drawing.Point(565, 13)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(112, 60)
        Me.btnadd.TabIndex = 2
        Me.btnadd.Text = "Add toList"
        '
        'txtdebit
        '
        Me.txtdebit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdebit.Location = New System.Drawing.Point(450, 53)
        Me.txtdebit.Name = "txtdebit"
        Me.txtdebit.Size = New System.Drawing.Size(100, 20)
        Me.txtdebit.TabIndex = 7
        Me.txtdebit.Text = "0.00"
        Me.txtdebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(395, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Amount :"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(85, 53)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(304, 20)
        Me.txtdescription.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Description :"
        '
        'cboCreditAcc
        '
        Me.cboCreditAcc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCreditAcc.DropDownWidth = 300
        Me.cboCreditAcc.FormattingEnabled = True
        Me.cboCreditAcc.Location = New System.Drawing.Point(358, 18)
        Me.cboCreditAcc.Name = "cboCreditAcc"
        Me.cboCreditAcc.Size = New System.Drawing.Size(192, 21)
        Me.cboCreditAcc.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(293, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Credit A/c :"
        '
        'cboaccount
        '
        Me.cboaccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboaccount.DropDownWidth = 300
        Me.cboaccount.FormattingEnabled = True
        Me.cboaccount.Location = New System.Drawing.Point(85, 18)
        Me.cboaccount.Name = "cboaccount"
        Me.cboaccount.Size = New System.Drawing.Size(192, 21)
        Me.cboaccount.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Debit A/c :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dgvjournal)
        Me.GroupBox4.Controls.Add(Me.txtaccnum)
        Me.GroupBox4.Controls.Add(Me.txtcbank)
        Me.GroupBox4.Controls.Add(Me.txtcreditcheck)
        Me.GroupBox4.Controls.Add(Me.txtbank)
        Me.GroupBox4.Controls.Add(Me.txtdebitchecck)
        Me.GroupBox4.Controls.Add(Me.txtcredit)
        Me.GroupBox4.Controls.Add(Me.txtcaccnum)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 213)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(683, 154)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'dgvjournal
        '
        Me.dgvjournal.BackgroundColor = System.Drawing.Color.White
        Me.dgvjournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvjournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvjournal.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvjournal.Location = New System.Drawing.Point(3, 16)
        Me.dgvjournal.Name = "dgvjournal"
        Me.dgvjournal.RowHeadersVisible = False
        Me.dgvjournal.Size = New System.Drawing.Size(677, 135)
        Me.dgvjournal.TabIndex = 0
        '
        'txtaccnum
        '
        Me.txtaccnum.Location = New System.Drawing.Point(358, 99)
        Me.txtaccnum.Name = "txtaccnum"
        Me.txtaccnum.Size = New System.Drawing.Size(100, 20)
        Me.txtaccnum.TabIndex = 9
        '
        'txtcbank
        '
        Me.txtcbank.Location = New System.Drawing.Point(252, 63)
        Me.txtcbank.Name = "txtcbank"
        Me.txtcbank.Size = New System.Drawing.Size(100, 20)
        Me.txtcbank.TabIndex = 12
        '
        'txtcreditcheck
        '
        Me.txtcreditcheck.Location = New System.Drawing.Point(40, 63)
        Me.txtcreditcheck.Name = "txtcreditcheck"
        Me.txtcreditcheck.Size = New System.Drawing.Size(100, 20)
        Me.txtcreditcheck.TabIndex = 10
        '
        'txtbank
        '
        Me.txtbank.Location = New System.Drawing.Point(252, 99)
        Me.txtbank.Name = "txtbank"
        Me.txtbank.Size = New System.Drawing.Size(100, 20)
        Me.txtbank.TabIndex = 8
        '
        'txtdebitchecck
        '
        Me.txtdebitchecck.Location = New System.Drawing.Point(146, 99)
        Me.txtdebitchecck.Name = "txtdebitchecck"
        Me.txtdebitchecck.Size = New System.Drawing.Size(100, 20)
        Me.txtdebitchecck.TabIndex = 7
        '
        'txtcredit
        '
        Me.txtcredit.Location = New System.Drawing.Point(40, 99)
        Me.txtcredit.Name = "txtcredit"
        Me.txtcredit.Size = New System.Drawing.Size(100, 20)
        Me.txtcredit.TabIndex = 6
        Me.txtcredit.Text = "0.00"
        '
        'txtcaccnum
        '
        Me.txtcaccnum.Location = New System.Drawing.Point(146, 63)
        Me.txtcaccnum.Name = "txtcaccnum"
        Me.txtcaccnum.Size = New System.Drawing.Size(100, 20)
        Me.txtcaccnum.TabIndex = 11
        '
        'txtcrebal
        '
        Me.txtcrebal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcrebal.Location = New System.Drawing.Point(592, 373)
        Me.txtcrebal.Name = "txtcrebal"
        Me.txtcrebal.ReadOnly = True
        Me.txtcrebal.Size = New System.Drawing.Size(100, 20)
        Me.txtcrebal.TabIndex = 3
        Me.txtcrebal.Text = "0.00"
        Me.txtcrebal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtdebbal
        '
        Me.txtdebbal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdebbal.Location = New System.Drawing.Point(486, 373)
        Me.txtdebbal.Name = "txtdebbal"
        Me.txtdebbal.ReadOnly = True
        Me.txtdebbal.Size = New System.Drawing.Size(100, 20)
        Me.txtdebbal.TabIndex = 4
        Me.txtdebbal.Text = "0.00"
        Me.txtdebbal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnsave
        '
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.save_32x322
        Me.btnsave.Location = New System.Drawing.Point(438, 407)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(124, 39)
        Me.btnsave.TabIndex = 5
        Me.btnsave.Text = "Save"
        '
        'btnclose
        '
        Me.btnclose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.closeheaderandfooter_32x32
        Me.btnclose.Location = New System.Drawing.Point(568, 407)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(124, 39)
        Me.btnclose.TabIndex = 6
        Me.btnclose.Text = "Close"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'JournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(708, 450)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.txtdebbal)
        Me.Controls.Add(Me.txtcrebal)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "JournalEntry"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Journal Entry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtentdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtentdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.dgvjournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtentno As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtentdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cboCreditAcc As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboaccount As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtdebit As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtdescription As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnadd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dgvjournal As DataGridView
    Friend WithEvents txtcrebal As TextBox
    Friend WithEvents txtdebbal As TextBox
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtcredit As TextBox
    Friend WithEvents txtdebitchecck As TextBox
    Friend WithEvents txtbank As TextBox
    Friend WithEvents txtaccnum As TextBox
    Friend WithEvents txtcreditcheck As TextBox
    Friend WithEvents txtcaccnum As TextBox
    Friend WithEvents txtcbank As TextBox
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
End Class

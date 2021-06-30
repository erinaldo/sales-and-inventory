<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReceivedPushForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbolocation = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvRecTrans = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnReceive = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.btnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvRecTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(769, 31)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(272, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Receive Stock Transfer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbolocation)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 37)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 50)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Source :"
        '
        'cbolocation
        '
        Me.cbolocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbolocation.DropDownWidth = 300
        Me.cbolocation.FormattingEnabled = True
        Me.cbolocation.Location = New System.Drawing.Point(6, 19)
        Me.cbolocation.Name = "cbolocation"
        Me.cbolocation.Size = New System.Drawing.Size(283, 21)
        Me.cbolocation.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvRecTrans)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(745, 262)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details :"
        '
        'dgvRecTrans
        '
        Me.dgvRecTrans.AllowUserToAddRows = False
        Me.dgvRecTrans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRecTrans.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvRecTrans.BackgroundColor = System.Drawing.Color.White
        Me.dgvRecTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecTrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRecTrans.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvRecTrans.Location = New System.Drawing.Point(3, 16)
        Me.dgvRecTrans.Name = "dgvRecTrans"
        Me.dgvRecTrans.RowHeadersVisible = False
        Me.dgvRecTrans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecTrans.Size = New System.Drawing.Size(739, 243)
        Me.dgvRecTrans.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnReceive)
        Me.GroupBox3.Controls.Add(Me.btnReload)
        Me.GroupBox3.Controls.Add(Me.btnClose)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 361)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(769, 62)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'btnReceive
        '
        Me.btnReceive.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnReceive.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.fill_32x32
        Me.btnReceive.Location = New System.Drawing.Point(457, 16)
        Me.btnReceive.Name = "btnReceive"
        Me.btnReceive.Size = New System.Drawing.Size(103, 43)
        Me.btnReceive.TabIndex = 2
        Me.btnReceive.Text = "Receive"
        '
        'btnReload
        '
        Me.btnReload.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnReload.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refreshallpivottable_32x326
        Me.btnReload.Location = New System.Drawing.Point(560, 16)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(103, 43)
        Me.btnReload.TabIndex = 1
        Me.btnReload.Text = "Reload"
        '
        'btnClose
        '
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.close_32x324
        Me.btnClose.Location = New System.Drawing.Point(663, 16)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 43)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "Close"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.dtDate)
        Me.GroupBox4.Location = New System.Drawing.Point(402, 37)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(286, 50)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Receive Date :"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(6, 19)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(115, 20)
        Me.dtDate.TabIndex = 0
        '
        'ReceivedPushForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(769, 423)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.Name = "ReceivedPushForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Receiving Transfer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvRecTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cbolocation As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvRecTrans As DataGridView
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnClose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents btnReceive As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
End Class

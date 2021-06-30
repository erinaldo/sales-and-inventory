<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DependantsForm
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
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtnhis = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbodependent = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtrenew = New System.Windows.Forms.DateTimePicker()
        Me.dtdob = New System.Windows.Forms.DateTimePicker()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtdepid = New System.Windows.Forms.TextBox()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SimpleButton3
        '
        Me.SimpleButton3.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.save_32x32
        Me.SimpleButton3.Location = New System.Drawing.Point(110, 207)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(106, 43)
        Me.SimpleButton3.TabIndex = 11
        Me.SimpleButton3.Text = "Save"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Renewal Date :"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.close_32x324
        Me.SimpleButton1.Location = New System.Drawing.Point(334, 207)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(106, 43)
        Me.SimpleButton1.TabIndex = 12
        Me.SimpleButton1.Text = "Close"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(137, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(148, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Dependants Info"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 35)
        Me.Panel1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Full Name :"
        '
        'txtnhis
        '
        Me.txtnhis.Location = New System.Drawing.Point(93, 48)
        Me.txtnhis.Name = "txtnhis"
        Me.txtnhis.Size = New System.Drawing.Size(180, 20)
        Me.txtnhis.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbodependent)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtrenew)
        Me.GroupBox2.Controls.Add(Me.dtdob)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtfname)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtnhis)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 160)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dependant Info :"
        '
        'cbodependent
        '
        Me.cbodependent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbodependent.FormattingEnabled = True
        Me.cbodependent.Location = New System.Drawing.Point(93, 126)
        Me.cbodependent.Name = "cbodependent"
        Me.cbodependent.Size = New System.Drawing.Size(330, 21)
        Me.cbodependent.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Dependent :"
        '
        'dtrenew
        '
        Me.dtrenew.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtrenew.Location = New System.Drawing.Point(93, 100)
        Me.dtrenew.Name = "dtrenew"
        Me.dtrenew.Size = New System.Drawing.Size(108, 20)
        Me.dtrenew.TabIndex = 11
        '
        'dtdob
        '
        Me.dtdob.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdob.Location = New System.Drawing.Point(93, 74)
        Me.dtdob.Name = "dtdob"
        Me.dtdob.Size = New System.Drawing.Size(108, 20)
        Me.dtdob.TabIndex = 10
        '
        'txtfname
        '
        Me.txtfname.Location = New System.Drawing.Point(93, 22)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(330, 20)
        Me.txtfname.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Date of Birth :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "NHIS # :"
        '
        'txtdepid
        '
        Me.txtdepid.Location = New System.Drawing.Point(233, 219)
        Me.txtdepid.Name = "txtdepid"
        Me.txtdepid.Size = New System.Drawing.Size(84, 20)
        Me.txtdepid.TabIndex = 14
        '
        'SimpleButton2
        '
        Me.SimpleButton2.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refresh_32x32
        Me.SimpleButton2.Location = New System.Drawing.Point(222, 207)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(106, 43)
        Me.SimpleButton2.TabIndex = 13
        Me.SimpleButton2.Text = "Refresh"
        '
        'DependantsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(452, 259)
        Me.Controls.Add(Me.SimpleButton3)
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.SimpleButton2)
        Me.Controls.Add(Me.txtdepid)
        Me.MaximizeBox = False
        Me.Name = "DependantsForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dependants"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label5 As Label
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents txtnhis As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbodependent As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents dtrenew As DateTimePicker
    Friend WithEvents dtdob As DateTimePicker
    Friend WithEvents txtfname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtdepid As TextBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuppliersForm
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
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnrefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.txtgcode = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtweb = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtmobile = New System.Windows.Forms.TextBox()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.txtoffadd = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbotitle = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtlname = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtfname = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.txtcomp = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(266, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 23)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Supplier Info"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtcode
        '
        Me.txtcode.Location = New System.Drawing.Point(284, 29)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(100, 21)
        Me.txtcode.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Navy
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(688, 35)
        Me.Panel1.TabIndex = 9
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btnsave)
        Me.PanelControl1.Controls.Add(Me.btnrefresh)
        Me.PanelControl1.Controls.Add(Me.btnclose)
        Me.PanelControl1.Controls.Add(Me.txtcode)
        Me.PanelControl1.Controls.Add(Me.txtgcode)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelControl1.Location = New System.Drawing.Point(0, 239)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(688, 75)
        Me.PanelControl1.TabIndex = 8
        '
        'btnsave
        '
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.addnewdatasource_32x323
        Me.btnsave.Location = New System.Drawing.Point(271, 15)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(127, 48)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "Add"
        '
        'btnrefresh
        '
        Me.btnrefresh.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.recurrence_32x321
        Me.btnrefresh.Location = New System.Drawing.Point(404, 15)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(127, 48)
        Me.btnrefresh.TabIndex = 2
        Me.btnrefresh.Text = "Refresh"
        '
        'btnclose
        '
        Me.btnclose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.close_32x323
        Me.btnclose.Location = New System.Drawing.Point(537, 15)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(127, 48)
        Me.btnclose.TabIndex = 3
        Me.btnclose.Text = "Close"
        '
        'txtgcode
        '
        Me.txtgcode.Location = New System.Drawing.Point(414, 29)
        Me.txtgcode.Name = "txtgcode"
        Me.txtgcode.Size = New System.Drawing.Size(100, 21)
        Me.txtgcode.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(42, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Website :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(56, 126)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Email :"
        '
        'txtweb
        '
        Me.txtweb.Location = New System.Drawing.Point(100, 148)
        Me.txtweb.Name = "txtweb"
        Me.txtweb.Size = New System.Drawing.Size(219, 20)
        Me.txtweb.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(64, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Fax :"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(100, 123)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(219, 20)
        Me.txtemail.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(50, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Mobile :"
        '
        'txtfax
        '
        Me.txtfax.Location = New System.Drawing.Point(100, 97)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(219, 20)
        Me.txtfax.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(66, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Tel :"
        '
        'txtmobile
        '
        Me.txtmobile.Location = New System.Drawing.Point(100, 71)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(219, 20)
        Me.txtmobile.TabIndex = 7
        '
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(100, 45)
        Me.txttel.Name = "txttel"
        Me.txttel.Size = New System.Drawing.Size(219, 20)
        Me.txttel.TabIndex = 6
        '
        'txtoffadd
        '
        Me.txtoffadd.Location = New System.Drawing.Point(100, 19)
        Me.txtoffadd.Name = "txtoffadd"
        Me.txtoffadd.Size = New System.Drawing.Size(219, 20)
        Me.txtoffadd.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Office Address :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtweb)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.txtemail)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtfax)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtmobile)
        Me.GroupBox3.Controls.Add(Me.txttel)
        Me.GroupBox3.Controls.Add(Me.txtoffadd)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(345, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(338, 192)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Address :"
        '
        'cbotitle
        '
        Me.cbotitle.FormattingEnabled = True
        Me.cbotitle.Items.AddRange(New Object() {"Dr", "Mr", "Miss", "Mrs", "Madam", "Sister", "Brother"})
        Me.cbotitle.Location = New System.Drawing.Point(89, 97)
        Me.cbotitle.Name = "cbotitle"
        Me.cbotitle.Size = New System.Drawing.Size(121, 21)
        Me.cbotitle.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Title :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbotitle)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtlname)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtfname)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtmname)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 96)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(333, 137)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact Person :"
        '
        'txtlname
        '
        Me.txtlname.Location = New System.Drawing.Point(89, 71)
        Me.txtlname.Name = "txtlname"
        Me.txtlname.Size = New System.Drawing.Size(181, 20)
        Me.txtlname.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "First Name :"
        '
        'txtfname
        '
        Me.txtfname.Location = New System.Drawing.Point(89, 19)
        Me.txtfname.Name = "txtfname"
        Me.txtfname.Size = New System.Drawing.Size(181, 20)
        Me.txtfname.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Last Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Middle Name :"
        '
        'txtmname
        '
        Me.txtmname.Location = New System.Drawing.Point(89, 45)
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(181, 20)
        Me.txtmname.TabIndex = 2
        '
        'txtcomp
        '
        Me.txtcomp.Location = New System.Drawing.Point(12, 19)
        Me.txtcomp.Name = "txtcomp"
        Me.txtcomp.Size = New System.Drawing.Size(311, 20)
        Me.txtcomp.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtcomp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 49)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Company Info :"
        '
        'SuppliersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(688, 314)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "SuppliersForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Suppliers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.PanelControl1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label12 As Label
    Friend WithEvents txtcode As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnrefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtweb As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtemail As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtfax As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtmobile As TextBox
    Friend WithEvents txttel As TextBox
    Friend WithEvents txtoffadd As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbotitle As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtlname As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtfname As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtmname As TextBox
    Friend WithEvents txtcomp As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtgcode As TextBox
End Class

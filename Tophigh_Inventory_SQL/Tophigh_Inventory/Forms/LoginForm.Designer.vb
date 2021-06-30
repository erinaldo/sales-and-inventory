<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbolocation = New System.Windows.Forms.ComboBox()
        Me.btnok = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cborole = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbouser = New System.Windows.Forms.ComboBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtpassword)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbolocation)
        Me.GroupBox1.Controls.Add(Me.btnok)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cborole)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbouser)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 177)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(101, 42)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(154, 20)
        Me.txtpassword.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(41, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Location :"
        '
        'cbolocation
        '
        Me.cbolocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbolocation.DropDownWidth = 350
        Me.cbolocation.FormattingEnabled = True
        Me.cbolocation.Location = New System.Drawing.Point(101, 98)
        Me.cbolocation.Name = "cbolocation"
        Me.cbolocation.Size = New System.Drawing.Size(154, 21)
        Me.cbolocation.TabIndex = 3
        '
        'btnok
        '
        Me.btnok.ImageOptions.Image = CType(resources.GetObject("btnok.ImageOptions.Image"), System.Drawing.Image)
        Me.btnok.Location = New System.Drawing.Point(180, 125)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(75, 41)
        Me.btnok.TabIndex = 4
        Me.btnok.Text = "Login"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Role :"
        '
        'cborole
        '
        Me.cborole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cborole.DropDownWidth = 350
        Me.cborole.FormattingEnabled = True
        Me.cborole.Items.AddRange(New Object() {"Admin", "Assistant Admin", "Manager", "Cashier", "Sales Agent", "Store Keeper", "Accountant", "Driver", "Messenger"})
        Me.cborole.Location = New System.Drawing.Point(101, 71)
        Me.cborole.Name = "cborole"
        Me.cborole.Size = New System.Drawing.Size(154, 21)
        Me.cborole.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name :"
        '
        'cbouser
        '
        Me.cbouser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbouser.DropDownWidth = 350
        Me.cbouser.FormattingEnabled = True
        Me.cbouser.Location = New System.Drawing.Point(101, 15)
        Me.cbouser.Name = "cbouser"
        Me.cbouser.Size = New System.Drawing.Size(154, 21)
        Me.cbouser.TabIndex = 0
        '
        'LoginForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(297, 200)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cbolocation As ComboBox
    Friend WithEvents btnok As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents cborole As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbouser As ComboBox
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Stock2Form
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
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcost = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtdate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclear = New DevExpress.XtraEditors.SimpleButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtinv = New System.Windows.Forms.TextBox()
        Me.txtequ = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtprice)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbltime)
        Me.GroupBox1.Controls.Add(Me.txtcost)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtqty)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtproduct)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtdate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtinv)
        Me.GroupBox1.Controls.Add(Me.txtequ)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 155)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtprice
        '
        Me.txtprice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtprice.Location = New System.Drawing.Point(88, 124)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.Size = New System.Drawing.Size(95, 20)
        Me.txtprice.TabIndex = 9
        Me.txtprice.Text = "0.00"
        Me.txtprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Sales Price :"
        '
        'txtcost
        '
        Me.txtcost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcost.Location = New System.Drawing.Point(88, 98)
        Me.txtcost.Name = "txtcost"
        Me.txtcost.Size = New System.Drawing.Size(95, 20)
        Me.txtcost.TabIndex = 7
        Me.txtcost.Text = "0.00"
        Me.txtcost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Unit Cost :"
        '
        'txtqty
        '
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.Location = New System.Drawing.Point(88, 72)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(48, 20)
        Me.txtqty.TabIndex = 5
        Me.txtqty.Text = "0"
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Qty :"
        '
        'txtproduct
        '
        Me.txtproduct.Location = New System.Drawing.Point(88, 45)
        Me.txtproduct.Name = "txtproduct"
        Me.txtproduct.Size = New System.Drawing.Size(199, 20)
        Me.txtproduct.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Product :"
        '
        'dtdate
        '
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtdate.Location = New System.Drawing.Point(88, 19)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(95, 20)
        Me.dtdate.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnsave)
        Me.GroupBox2.Controls.Add(Me.btnclear)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(295, 48)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Location = New System.Drawing.Point(117, 127)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(49, 13)
        Me.lbltime.TabIndex = 2
        Me.lbltime.Text = "00:00:00"
        '
        'btnsave
        '
        Me.btnsave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.export_16x16
        Me.btnsave.Location = New System.Drawing.Point(142, 16)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(75, 29)
        Me.btnsave.TabIndex = 1
        Me.btnsave.Text = "Save"
        '
        'btnclear
        '
        Me.btnclear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclear.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.clearformatting_16x16
        Me.btnclear.Location = New System.Drawing.Point(217, 16)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(75, 29)
        Me.btnclear.TabIndex = 0
        Me.btnclear.Text = "Clear"
        '
        'Timer1
        '
        '
        'txtinv
        '
        Me.txtinv.Location = New System.Drawing.Point(114, 45)
        Me.txtinv.Name = "txtinv"
        Me.txtinv.Size = New System.Drawing.Size(69, 20)
        Me.txtinv.TabIndex = 2
        '
        'txtequ
        '
        Me.txtequ.Location = New System.Drawing.Point(189, 45)
        Me.txtequ.Name = "txtequ"
        Me.txtequ.Size = New System.Drawing.Size(63, 20)
        Me.txtequ.TabIndex = 10
        '
        'Stock2Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(316, 220)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Stock2Form"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtdate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents txtprice As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcost As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtqty As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtproduct As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lbltime As Label
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnclear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtequ As TextBox
    Friend WithEvents txtinv As TextBox
End Class

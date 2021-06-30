<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SalesForm
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnadd = New DevExpress.XtraEditors.SimpleButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtamount = New System.Windows.Forms.TextBox()
        Me.txtprice = New System.Windows.Forms.TextBox()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.cboproduct = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.btnreset = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvsales = New System.Windows.Forms.DataGridView()
        Me.txtcash = New System.Windows.Forms.TextBox()
        Me.txtclass = New System.Windows.Forms.TextBox()
        Me.txtrev = New System.Windows.Forms.TextBox()
        Me.txtcomp = New System.Windows.Forms.TextBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.btnsaveprint = New DevExpress.XtraEditors.SimpleButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtchange = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtreceived = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtnet = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnadd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtamount)
        Me.GroupBox1.Controls.Add(Me.txtprice)
        Me.GroupBox1.Controls.Add(Me.txtqty)
        Me.GroupBox1.Controls.Add(Me.cboproduct)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtid)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(534, 108)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Sales Box"
        '
        'btnadd
        '
        Me.btnadd.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.listbullets_16x16
        Me.btnadd.Location = New System.Drawing.Point(445, 74)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(85, 25)
        Me.btnadd.TabIndex = 11
        Me.btnadd.Text = "Add to List"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(379, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(325, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(23, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Qty"
        '
        'txtamount
        '
        Me.txtamount.Location = New System.Drawing.Point(461, 76)
        Me.txtamount.Name = "txtamount"
        Me.txtamount.Size = New System.Drawing.Size(54, 20)
        Me.txtamount.TabIndex = 8
        '
        'txtprice
        '
        Me.txtprice.BackColor = System.Drawing.Color.White
        Me.txtprice.Location = New System.Drawing.Point(376, 77)
        Me.txtprice.Name = "txtprice"
        Me.txtprice.ReadOnly = True
        Me.txtprice.Size = New System.Drawing.Size(64, 20)
        Me.txtprice.TabIndex = 7
        Me.txtprice.Text = "0.00"
        Me.txtprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqty
        '
        Me.txtqty.Location = New System.Drawing.Point(328, 77)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(42, 20)
        Me.txtqty.TabIndex = 6
        Me.txtqty.Text = "1"
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboproduct
        '
        Me.cboproduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboproduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboproduct.FormattingEnabled = True
        Me.cboproduct.Location = New System.Drawing.Point(9, 76)
        Me.cboproduct.Name = "cboproduct"
        Me.cboproduct.Size = New System.Drawing.Size(313, 21)
        Me.cboproduct.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Products"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(170, 26)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(97, 20)
        Me.dtDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(134, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date"
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Location = New System.Drawing.Point(59, 26)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(69, 20)
        Me.txtCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sales ID"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(376, 77)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(54, 20)
        Me.txtid.TabIndex = 13
        '
        'btnreset
        '
        Me.btnreset.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.reset2_16x16
        Me.btnreset.Location = New System.Drawing.Point(549, 81)
        Me.btnreset.Name = "btnreset"
        Me.btnreset.Size = New System.Drawing.Size(97, 25)
        Me.btnreset.TabIndex = 12
        Me.btnreset.Text = "Reset"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvsales)
        Me.GroupBox2.Controls.Add(Me.txtcash)
        Me.GroupBox2.Controls.Add(Me.txtclass)
        Me.GroupBox2.Controls.Add(Me.txtrev)
        Me.GroupBox2.Controls.Add(Me.txtcomp)
        Me.GroupBox2.Controls.Add(Me.lbltimer)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 183)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = " Details "
        '
        'dgvsales
        '
        Me.dgvsales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvsales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvsales.BackgroundColor = System.Drawing.Color.White
        Me.dgvsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvsales.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvsales.Location = New System.Drawing.Point(3, 16)
        Me.dgvsales.Name = "dgvsales"
        Me.dgvsales.RowHeadersVisible = False
        Me.dgvsales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvsales.Size = New System.Drawing.Size(527, 164)
        Me.dgvsales.TabIndex = 0
        '
        'txtcash
        '
        Me.txtcash.Location = New System.Drawing.Point(359, 57)
        Me.txtcash.Name = "txtcash"
        Me.txtcash.Size = New System.Drawing.Size(100, 20)
        Me.txtcash.TabIndex = 17
        '
        'txtclass
        '
        Me.txtclass.Location = New System.Drawing.Point(59, 57)
        Me.txtclass.Name = "txtclass"
        Me.txtclass.Size = New System.Drawing.Size(100, 20)
        Me.txtclass.TabIndex = 16
        '
        'txtrev
        '
        Me.txtrev.Location = New System.Drawing.Point(253, 57)
        Me.txtrev.Name = "txtrev"
        Me.txtrev.Size = New System.Drawing.Size(100, 20)
        Me.txtrev.TabIndex = 18
        '
        'txtcomp
        '
        Me.txtcomp.Location = New System.Drawing.Point(50, 96)
        Me.txtcomp.Name = "txtcomp"
        Me.txtcomp.Size = New System.Drawing.Size(100, 20)
        Me.txtcomp.TabIndex = 17
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(230, 103)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(49, 13)
        Me.lbltimer.TabIndex = 16
        Me.lbltimer.Text = "00:00:00"
        '
        'btnsaveprint
        '
        Me.btnsaveprint.Enabled = False
        Me.btnsaveprint.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.printer_16x16
        Me.btnsaveprint.Location = New System.Drawing.Point(549, 241)
        Me.btnsaveprint.Name = "btnsaveprint"
        Me.btnsaveprint.Size = New System.Drawing.Size(97, 55)
        Me.btnsaveprint.TabIndex = 17
        Me.btnsaveprint.Text = "Save | Print"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(546, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Change"
        '
        'txtchange
        '
        Me.txtchange.BackColor = System.Drawing.Color.White
        Me.txtchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchange.Location = New System.Drawing.Point(549, 215)
        Me.txtchange.Name = "txtchange"
        Me.txtchange.ReadOnly = True
        Me.txtchange.Size = New System.Drawing.Size(97, 20)
        Me.txtchange.TabIndex = 15
        Me.txtchange.Text = "0.00"
        Me.txtchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(546, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Amount Received"
        '
        'txtreceived
        '
        Me.txtreceived.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreceived.Location = New System.Drawing.Point(549, 176)
        Me.txtreceived.Name = "txtreceived"
        Me.txtreceived.Size = New System.Drawing.Size(97, 20)
        Me.txtreceived.TabIndex = 13
        Me.txtreceived.Text = "0.00"
        Me.txtreceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(546, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Net Total"
        '
        'txtnet
        '
        Me.txtnet.BackColor = System.Drawing.Color.White
        Me.txtnet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnet.Location = New System.Drawing.Point(549, 135)
        Me.txtnet.Name = "txtnet"
        Me.txtnet.ReadOnly = True
        Me.txtnet.Size = New System.Drawing.Size(97, 20)
        Me.txtnet.TabIndex = 11
        Me.txtnet.Text = "0.00"
        Me.txtnet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Timer1
        '
        '
        'SalesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(653, 308)
        Me.Controls.Add(Me.btnsaveprint)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtchange)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnreset)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtnet)
        Me.Controls.Add(Me.txtreceived)
        Me.Controls.Add(Me.Label6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "SalesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtamount As TextBox
    Friend WithEvents txtprice As TextBox
    Friend WithEvents txtqty As TextBox
    Friend WithEvents cboproduct As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dgvsales As DataGridView
    Friend WithEvents btnsaveprint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label8 As Label
    Friend WithEvents txtchange As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtreceived As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtnet As TextBox
    Friend WithEvents btnreset As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnadd As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtclass As TextBox
    Friend WithEvents txtrev As TextBox
    Friend WithEvents txtcash As TextBox
    Friend WithEvents lbltimer As Label
    Friend WithEvents txtcomp As TextBox
    Friend WithEvents Timer1 As Timer
End Class

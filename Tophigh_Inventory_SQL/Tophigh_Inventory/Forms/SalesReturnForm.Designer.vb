﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesReturnForm
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
        Me.txtvat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsubtot = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.LvHistory = New System.Windows.Forms.ListView()
        Me.txtdiscAcc = New System.Windows.Forms.TextBox()
        Me.txtcashAcc = New System.Windows.Forms.TextBox()
        Me.txtsalesAcc = New System.Windows.Forms.TextBox()
        Me.txtInvAcc = New System.Windows.Forms.TextBox()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtcogsAcc = New System.Windows.Forms.TextBox()
        Me.mTax = New System.Windows.Forms.TextBox()
        Me.txtDisc = New System.Windows.Forms.TextBox()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.txtutot = New System.Windows.Forms.TextBox()
        Me.lblzeros = New System.Windows.Forms.Label()
        Me.txtunitcost = New System.Windows.Forms.TextBox()
        Me.txtamt = New System.Windows.Forms.TextBox()
        Me.txtTax = New System.Windows.Forms.TextBox()
        Me.mDisc = New System.Windows.Forms.TextBox()
        Me.txtrate = New System.Windows.Forms.TextBox()
        Me.txtqty = New System.Windows.Forms.TextBox()
        Me.txtvatval = New System.Windows.Forms.TextBox()
        Me.txtTaxAcc = New System.Windows.Forms.TextBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.mDescript = New System.Windows.Forms.TextBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtsaldisc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtReceiptno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtSalesDate = New DevExpress.XtraEditors.DateEdit()
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mSaleNo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtcustid = New System.Windows.Forms.TextBox()
        Me.mCheck = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboPayMeth = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbodata = New System.Windows.Forms.ComboBox()
        Me.dgvsales = New System.Windows.Forms.DataGridView()
        Me.cbo_ret_py = New System.Windows.Forms.ComboBox()
        Me.cbo_re_cy = New System.Windows.Forms.ComboBox()
        Me.txt_net_poc = New System.Windows.Forms.TextBox()
        Me.lblyear2 = New System.Windows.Forms.Label()
        Me.dthistdate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnrefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.chkvat = New System.Windows.Forms.CheckBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtSalesDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtSalesDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtvat
        '
        Me.txtvat.BackColor = System.Drawing.Color.White
        Me.txtvat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvat.Location = New System.Drawing.Point(105, 69)
        Me.txtvat.Name = "txtvat"
        Me.txtvat.ReadOnly = True
        Me.txtvat.Size = New System.Drawing.Size(107, 20)
        Me.txtvat.TabIndex = 44
        Me.txtvat.Text = "0.00"
        Me.txtvat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(67, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "VAT"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 97)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(31, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Total"
        '
        'txtsubtot
        '
        Me.txtsubtot.BackColor = System.Drawing.Color.White
        Me.txtsubtot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtot.Location = New System.Drawing.Point(105, 39)
        Me.txtsubtot.Name = "txtsubtot"
        Me.txtsubtot.ReadOnly = True
        Me.txtsubtot.Size = New System.Drawing.Size(107, 20)
        Me.txtsubtot.TabIndex = 42
        Me.txtsubtot.Text = "0.00"
        Me.txtsubtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.Color.White
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(105, 95)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(107, 20)
        Me.txtTotal.TabIndex = 6
        Me.txtTotal.Text = "0.00"
        Me.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(50, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Subtotal"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.LvHistory)
        Me.GroupBox7.Controls.Add(Me.txtdiscAcc)
        Me.GroupBox7.Controls.Add(Me.txtcashAcc)
        Me.GroupBox7.Controls.Add(Me.txtsalesAcc)
        Me.GroupBox7.Controls.Add(Me.txtInvAcc)
        Me.GroupBox7.Controls.Add(Me.txtid)
        Me.GroupBox7.Controls.Add(Me.txtcogsAcc)
        Me.GroupBox7.Controls.Add(Me.mTax)
        Me.GroupBox7.Controls.Add(Me.txtDisc)
        Me.GroupBox7.Controls.Add(Me.lblTime)
        Me.GroupBox7.Controls.Add(Me.txtutot)
        Me.GroupBox7.Controls.Add(Me.lblzeros)
        Me.GroupBox7.Controls.Add(Me.txtunitcost)
        Me.GroupBox7.Controls.Add(Me.txtamt)
        Me.GroupBox7.Controls.Add(Me.txtTax)
        Me.GroupBox7.Controls.Add(Me.mDisc)
        Me.GroupBox7.Controls.Add(Me.txtrate)
        Me.GroupBox7.Controls.Add(Me.txtqty)
        Me.GroupBox7.Controls.Add(Me.txtvatval)
        Me.GroupBox7.Controls.Add(Me.txtTaxAcc)
        Me.GroupBox7.Location = New System.Drawing.Point(631, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(229, 478)
        Me.GroupBox7.TabIndex = 26
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Today's Sales Ret History :"
        '
        'LvHistory
        '
        Me.LvHistory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LvHistory.HideSelection = False
        Me.LvHistory.Location = New System.Drawing.Point(3, 16)
        Me.LvHistory.Name = "LvHistory"
        Me.LvHistory.Size = New System.Drawing.Size(223, 459)
        Me.LvHistory.TabIndex = 0
        Me.LvHistory.UseCompatibleStateImageBehavior = False
        '
        'txtdiscAcc
        '
        Me.txtdiscAcc.Location = New System.Drawing.Point(65, 296)
        Me.txtdiscAcc.Name = "txtdiscAcc"
        Me.txtdiscAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtdiscAcc.TabIndex = 36
        '
        'txtcashAcc
        '
        Me.txtcashAcc.Location = New System.Drawing.Point(7, 256)
        Me.txtcashAcc.Name = "txtcashAcc"
        Me.txtcashAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtcashAcc.TabIndex = 38
        '
        'txtsalesAcc
        '
        Me.txtsalesAcc.Location = New System.Drawing.Point(7, 215)
        Me.txtsalesAcc.Name = "txtsalesAcc"
        Me.txtsalesAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtsalesAcc.TabIndex = 40
        '
        'txtInvAcc
        '
        Me.txtInvAcc.Location = New System.Drawing.Point(113, 256)
        Me.txtInvAcc.Name = "txtInvAcc"
        Me.txtInvAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtInvAcc.TabIndex = 37
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(44, 30)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 20)
        Me.txtid.TabIndex = 21
        '
        'txtcogsAcc
        '
        Me.txtcogsAcc.Location = New System.Drawing.Point(113, 215)
        Me.txtcogsAcc.Name = "txtcogsAcc"
        Me.txtcogsAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtcogsAcc.TabIndex = 39
        '
        'mTax
        '
        Me.mTax.Location = New System.Drawing.Point(123, 173)
        Me.mTax.Name = "mTax"
        Me.mTax.Size = New System.Drawing.Size(100, 20)
        Me.mTax.TabIndex = 20
        Me.mTax.Text = "0.00"
        Me.mTax.Visible = False
        '
        'txtDisc
        '
        Me.txtDisc.Location = New System.Drawing.Point(6, 173)
        Me.txtDisc.Name = "txtDisc"
        Me.txtDisc.Size = New System.Drawing.Size(100, 20)
        Me.txtDisc.TabIndex = 19
        Me.txtDisc.Text = "0.00"
        Me.txtDisc.Visible = False
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(17, 144)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(49, 13)
        Me.lblTime.TabIndex = 14
        Me.lblTime.Text = "00:00:00"
        Me.lblTime.Visible = False
        '
        'txtutot
        '
        Me.txtutot.Location = New System.Drawing.Point(65, 141)
        Me.txtutot.Name = "txtutot"
        Me.txtutot.Size = New System.Drawing.Size(100, 20)
        Me.txtutot.TabIndex = 33
        '
        'lblzeros
        '
        Me.lblzeros.AutoSize = True
        Me.lblzeros.Location = New System.Drawing.Point(159, 144)
        Me.lblzeros.Name = "lblzeros"
        Me.lblzeros.Size = New System.Drawing.Size(28, 13)
        Me.lblzeros.TabIndex = 14
        Me.lblzeros.Text = "0.00"
        Me.lblzeros.Visible = False
        '
        'txtunitcost
        '
        Me.txtunitcost.Location = New System.Drawing.Point(123, 108)
        Me.txtunitcost.Name = "txtunitcost"
        Me.txtunitcost.Size = New System.Drawing.Size(100, 20)
        Me.txtunitcost.TabIndex = 16
        '
        'txtamt
        '
        Me.txtamt.Location = New System.Drawing.Point(6, 108)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Size = New System.Drawing.Size(100, 20)
        Me.txtamt.TabIndex = 15
        '
        'txtTax
        '
        Me.txtTax.Location = New System.Drawing.Point(123, 82)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(100, 20)
        Me.txtTax.TabIndex = 14
        Me.txtTax.Text = "0"
        '
        'mDisc
        '
        Me.mDisc.Location = New System.Drawing.Point(6, 82)
        Me.mDisc.Name = "mDisc"
        Me.mDisc.Size = New System.Drawing.Size(100, 20)
        Me.mDisc.TabIndex = 13
        Me.mDisc.Text = "0"
        '
        'txtrate
        '
        Me.txtrate.Location = New System.Drawing.Point(123, 52)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.Size = New System.Drawing.Size(100, 20)
        Me.txtrate.TabIndex = 4
        '
        'txtqty
        '
        Me.txtqty.Location = New System.Drawing.Point(6, 56)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(100, 20)
        Me.txtqty.TabIndex = 3
        Me.txtqty.Text = "1"
        '
        'txtvatval
        '
        Me.txtvatval.BackColor = System.Drawing.Color.White
        Me.txtvatval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvatval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvatval.Location = New System.Drawing.Point(65, 400)
        Me.txtvatval.Name = "txtvatval"
        Me.txtvatval.Size = New System.Drawing.Size(107, 20)
        Me.txtvatval.TabIndex = 45
        Me.txtvatval.Text = "0.00"
        Me.txtvatval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTaxAcc
        '
        Me.txtTaxAcc.Location = New System.Drawing.Point(65, 420)
        Me.txtTaxAcc.Name = "txtTaxAcc"
        Me.txtTaxAcc.Size = New System.Drawing.Size(122, 20)
        Me.txtTaxAcc.TabIndex = 46
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.mDescript)
        Me.GroupBox5.Location = New System.Drawing.Point(15, 308)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(267, 70)
        Me.GroupBox5.TabIndex = 27
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Brief Memo"
        '
        'mDescript
        '
        Me.mDescript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mDescript.Dock = System.Windows.Forms.DockStyle.Fill
        Me.mDescript.Location = New System.Drawing.Point(3, 16)
        Me.mDescript.Multiline = True
        Me.mDescript.Name = "mDescript"
        Me.mDescript.Size = New System.Drawing.Size(261, 51)
        Me.mDescript.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtsaldisc)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txtvat)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtsubtot)
        Me.GroupBox4.Controls.Add(Me.txtTotal)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Location = New System.Drawing.Point(395, 308)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(230, 124)
        Me.GroupBox4.TabIndex = 25
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Summary"
        '
        'txtsaldisc
        '
        Me.txtsaldisc.BackColor = System.Drawing.Color.White
        Me.txtsaldisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsaldisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsaldisc.Location = New System.Drawing.Point(105, 13)
        Me.txtsaldisc.Name = "txtsaldisc"
        Me.txtsaldisc.Size = New System.Drawing.Size(107, 20)
        Me.txtsaldisc.TabIndex = 44
        Me.txtsaldisc.Text = "0.00"
        Me.txtsaldisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Sales Discount"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtReceiptno)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtSalesDate)
        Me.GroupBox1.Controls.Add(Me.cboCustomer)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.mSaleNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(306, 113)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Info :"
        '
        'txtReceiptno
        '
        Me.txtReceiptno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtReceiptno.Location = New System.Drawing.Point(191, 81)
        Me.txtReceiptno.Name = "txtReceiptno"
        Me.txtReceiptno.Size = New System.Drawing.Size(100, 20)
        Me.txtReceiptno.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(188, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Receipt #"
        '
        'dtSalesDate
        '
        Me.dtSalesDate.EditValue = Nothing
        Me.dtSalesDate.Location = New System.Drawing.Point(63, 81)
        Me.dtSalesDate.Name = "dtSalesDate"
        Me.dtSalesDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.dtSalesDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtSalesDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtSalesDate.Size = New System.Drawing.Size(100, 20)
        Me.dtSalesDate.TabIndex = 11
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCustomer.BackColor = System.Drawing.Color.Snow
        Me.cboCustomer.DropDownWidth = 300
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(63, 23)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(228, 21)
        Me.cboCustomer.Sorted = True
        Me.cboCustomer.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Customer"
        '
        'mSaleNo
        '
        Me.mSaleNo.BackColor = System.Drawing.Color.White
        Me.mSaleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mSaleNo.Location = New System.Drawing.Point(63, 53)
        Me.mSaleNo.Name = "mSaleNo"
        Me.mSaleNo.ReadOnly = True
        Me.mSaleNo.Size = New System.Drawing.Size(100, 20)
        Me.mSaleNo.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Returns #"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(52, 133)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(111, 20)
        Me.txtName.TabIndex = 9
        Me.txtName.Visible = False
        '
        'txtNum
        '
        Me.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNum.Location = New System.Drawing.Point(30, 96)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(111, 20)
        Me.txtNum.TabIndex = 10
        Me.txtNum.Text = "0"
        Me.txtNum.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtcustid)
        Me.GroupBox2.Controls.Add(Me.mCheck)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.cboPayMeth)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(324, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(283, 112)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(86, 81)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(178, 22)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Cash Sales Return"
        '
        'txtcustid
        '
        Me.txtcustid.Location = New System.Drawing.Point(105, 83)
        Me.txtcustid.Name = "txtcustid"
        Me.txtcustid.Size = New System.Drawing.Size(159, 20)
        Me.txtcustid.TabIndex = 10
        Me.txtcustid.Visible = False
        '
        'mCheck
        '
        Me.mCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mCheck.Location = New System.Drawing.Point(105, 52)
        Me.mCheck.Name = "mCheck"
        Me.mCheck.Size = New System.Drawing.Size(159, 20)
        Me.mCheck.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Card or Check #"
        '
        'cboPayMeth
        '
        Me.cboPayMeth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPayMeth.FormattingEnabled = True
        Me.cboPayMeth.Items.AddRange(New Object() {"Cash", "Visa Card", "Master Card", "Cheque"})
        Me.cboPayMeth.Location = New System.Drawing.Point(105, 22)
        Me.cboPayMeth.Name = "cboPayMeth"
        Me.cboPayMeth.Size = New System.Drawing.Size(159, 21)
        Me.cboPayMeth.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Payment Method"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbodata)
        Me.GroupBox3.Controls.Add(Me.dgvsales)
        Me.GroupBox3.Controls.Add(Me.cbo_ret_py)
        Me.GroupBox3.Controls.Add(Me.cbo_re_cy)
        Me.GroupBox3.Controls.Add(Me.txt_net_poc)
        Me.GroupBox3.Controls.Add(Me.lblyear2)
        Me.GroupBox3.Controls.Add(Me.txtName)
        Me.GroupBox3.Controls.Add(Me.dthistdate)
        Me.GroupBox3.Controls.Add(Me.txtNum)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 131)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(611, 174)
        Me.GroupBox3.TabIndex = 24
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sales Item"
        '
        'cbodata
        '
        Me.cbodata.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbodata.DropDownWidth = 300
        Me.cbodata.FormattingEnabled = True
        Me.cbodata.Location = New System.Drawing.Point(30, 44)
        Me.cbodata.MaxDropDownItems = 20
        Me.cbodata.Name = "cbodata"
        Me.cbodata.Size = New System.Drawing.Size(172, 21)
        Me.cbodata.Sorted = True
        Me.cbodata.TabIndex = 1
        Me.cbodata.Visible = False
        '
        'dgvsales
        '
        Me.dgvsales.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvsales.GridColor = System.Drawing.SystemColors.Control
        Me.dgvsales.Location = New System.Drawing.Point(3, 16)
        Me.dgvsales.Name = "dgvsales"
        Me.dgvsales.RowHeadersVisible = False
        Me.dgvsales.Size = New System.Drawing.Size(605, 155)
        Me.dgvsales.TabIndex = 0
        '
        'cbo_ret_py
        '
        Me.cbo_ret_py.FormattingEnabled = True
        Me.cbo_ret_py.Location = New System.Drawing.Point(225, 106)
        Me.cbo_ret_py.Name = "cbo_ret_py"
        Me.cbo_ret_py.Size = New System.Drawing.Size(150, 21)
        Me.cbo_ret_py.TabIndex = 32
        '
        'cbo_re_cy
        '
        Me.cbo_re_cy.FormattingEnabled = True
        Me.cbo_re_cy.Location = New System.Drawing.Point(383, 106)
        Me.cbo_re_cy.Name = "cbo_re_cy"
        Me.cbo_re_cy.Size = New System.Drawing.Size(142, 21)
        Me.cbo_re_cy.TabIndex = 30
        '
        'txt_net_poc
        '
        Me.txt_net_poc.Location = New System.Drawing.Point(254, 133)
        Me.txt_net_poc.Name = "txt_net_poc"
        Me.txt_net_poc.Size = New System.Drawing.Size(100, 20)
        Me.txt_net_poc.TabIndex = 31
        Me.txt_net_poc.Text = "0.00"
        '
        'lblyear2
        '
        Me.lblyear2.AutoSize = True
        Me.lblyear2.Location = New System.Drawing.Point(77, 140)
        Me.lblyear2.Name = "lblyear2"
        Me.lblyear2.Size = New System.Drawing.Size(39, 13)
        Me.lblyear2.TabIndex = 4
        Me.lblyear2.Text = "Label4"
        '
        'dthistdate
        '
        Me.dthistdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dthistdate.Location = New System.Drawing.Point(381, 96)
        Me.dthistdate.Name = "dthistdate"
        Me.dthistdate.Size = New System.Drawing.Size(106, 20)
        Me.dthistdate.TabIndex = 33
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnsave)
        Me.GroupBox6.Controls.Add(Me.btnrefresh)
        Me.GroupBox6.Controls.Add(Me.btnclose)
        Me.GroupBox6.Location = New System.Drawing.Point(15, 432)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(613, 58)
        Me.GroupBox6.TabIndex = 28
        Me.GroupBox6.TabStop = False
        '
        'btnsave
        '
        Me.btnsave.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.save_32x32
        Me.btnsave.Location = New System.Drawing.Point(295, 16)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(105, 39)
        Me.btnsave.TabIndex = 2
        Me.btnsave.Text = "Save"
        '
        'btnrefresh
        '
        Me.btnrefresh.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnrefresh.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refreshallpivottable_32x322
        Me.btnrefresh.Location = New System.Drawing.Point(400, 16)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(105, 39)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "Refresh"
        '
        'btnclose
        '
        Me.btnclose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.close_32x32
        Me.btnclose.Location = New System.Drawing.Point(505, 16)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(105, 39)
        Me.btnclose.TabIndex = 0
        Me.btnclose.Text = "Close"
        '
        'chkvat
        '
        Me.chkvat.AutoSize = True
        Me.chkvat.Location = New System.Drawing.Point(298, 337)
        Me.chkvat.Name = "chkvat"
        Me.chkvat.Size = New System.Drawing.Size(89, 17)
        Me.chkvat.TabIndex = 29
        Me.chkvat.Text = "VAT Charges"
        Me.chkvat.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'SalesReturnForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(633, 501)
        Me.Controls.Add(Me.chkvat)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.Name = "SalesReturnForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cash Sales Return"
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtSalesDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtSalesDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtvat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtsubtot As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtid As TextBox
    Friend WithEvents mTax As TextBox
    Friend WithEvents txtDisc As TextBox
    Friend WithEvents lblTime As Label
    Friend WithEvents txtutot As TextBox
    Friend WithEvents lblzeros As Label
    Friend WithEvents txtunitcost As TextBox
    Friend WithEvents txtamt As TextBox
    Friend WithEvents txtTax As TextBox
    Friend WithEvents mDisc As TextBox
    Friend WithEvents txtrate As TextBox
    Friend WithEvents txtqty As TextBox
    Friend WithEvents LvHistory As ListView
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents mDescript As TextBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents mSaleNo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents mCheck As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cboPayMeth As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtsalesAcc As TextBox
    Friend WithEvents txtcogsAcc As TextBox
    Friend WithEvents txtcashAcc As TextBox
    Friend WithEvents txtInvAcc As TextBox
    Friend WithEvents txtdiscAcc As TextBox
    Friend WithEvents cbodata As ComboBox
    Friend WithEvents dgvsales As DataGridView
    Friend WithEvents cbo_ret_py As ComboBox
    Friend WithEvents cbo_re_cy As ComboBox
    Friend WithEvents txt_net_poc As TextBox
    Friend WithEvents lblyear2 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dtSalesDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents chkvat As CheckBox
    Friend WithEvents txtcustid As TextBox
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnrefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtvatval As TextBox
    Friend WithEvents txtTaxAcc As TextBox
    Friend WithEvents dthistdate As DateTimePicker
    Friend WithEvents txtsaldisc As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtReceiptno As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
End Class
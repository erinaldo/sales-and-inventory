<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class POSForm3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POSForm3))
        Me.cboCustomer = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.mSaleNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPayMeth = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvsales = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.chkvat = New System.Windows.Forms.CheckBox()
        Me.txt_net_poc = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtNum = New System.Windows.Forms.TextBox()
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
        Me.lblyear2 = New System.Windows.Forms.Label()
        Me.dthistdate = New System.Windows.Forms.DateTimePicker()
        Me.txtcustid = New System.Windows.Forms.TextBox()
        Me.txtsaldisc = New System.Windows.Forms.TextBox()
        Me.txtvat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsubtot = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtposition = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtemp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtempid = New System.Windows.Forms.TextBox()
        Me.txtref = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtSalesDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtqtycheck = New System.Windows.Forms.TextBox()
        Me.TID = New System.Windows.Forms.TextBox()
        Me.btnSearch = New DevExpress.XtraEditors.SimpleButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtmemid = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.rbomem = New System.Windows.Forms.RadioButton()
        Me.rbogen = New System.Windows.Forms.RadioButton()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtstock = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtproduct = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtcomp = New System.Windows.Forms.TextBox()
        Me.txtsyncode = New System.Windows.Forms.TextBox()
        Me.txtposid = New System.Windows.Forms.TextBox()
        Me.txtreceive = New System.Windows.Forms.TextBox()
        Me.txtchange = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.btnnew = New DevExpress.XtraEditors.SimpleButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvdrop = New DevExpress.XtraGrid.GridControl()
        Me.ProductpriceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DsProduct = New Tophigh_Inventory.dsProduct()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colProduct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colQtyonhand = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cbodata = New System.Windows.Forms.TextBox()
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.lvdrop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ProductpriceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsProduct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomer.BackColor = System.Drawing.Color.Snow
        Me.cboCustomer.DropDownWidth = 250
        Me.cboCustomer.FormattingEnabled = True
        Me.cboCustomer.Location = New System.Drawing.Point(81, 47)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(178, 21)
        Me.cboCustomer.Sorted = True
        Me.cboCustomer.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(855, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Sales Discount"
        '
        'mSaleNo
        '
        Me.mSaleNo.BackColor = System.Drawing.Color.White
        Me.mSaleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mSaleNo.Location = New System.Drawing.Point(95, 45)
        Me.mSaleNo.Name = "mSaleNo"
        Me.mSaleNo.ReadOnly = True
        Me.mSaleNo.Size = New System.Drawing.Size(129, 20)
        Me.mSaleNo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Current Date :"
        '
        'cboPayMeth
        '
        Me.cboPayMeth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPayMeth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayMeth.DropDownWidth = 250
        Me.cboPayMeth.FormattingEnabled = True
        Me.cboPayMeth.Items.AddRange(New Object() {"Cash", "Visa Card", "Master Card", "Cheque"})
        Me.cboPayMeth.Location = New System.Drawing.Point(701, 179)
        Me.cboPayMeth.Name = "cboPayMeth"
        Me.cboPayMeth.Size = New System.Drawing.Size(138, 21)
        Me.cboPayMeth.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(602, 182)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Payment Method :"
        '
        'dgvsales
        '
        Me.dgvsales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvsales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvsales.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgvsales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvsales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvsales.GridColor = System.Drawing.SystemColors.Control
        Me.dgvsales.Location = New System.Drawing.Point(3, 16)
        Me.dgvsales.Name = "dgvsales"
        Me.dgvsales.RowHeadersVisible = False
        Me.dgvsales.Size = New System.Drawing.Size(824, 226)
        Me.dgvsales.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Sales ID :"
        '
        'Timer1
        '
        '
        'chkvat
        '
        Me.chkvat.AutoSize = True
        Me.chkvat.Location = New System.Drawing.Point(692, 138)
        Me.chkvat.Name = "chkvat"
        Me.chkvat.Size = New System.Drawing.Size(89, 17)
        Me.chkvat.TabIndex = 37
        Me.chkvat.Text = "VAT Charges"
        Me.chkvat.UseVisualStyleBackColor = True
        '
        'txt_net_poc
        '
        Me.txt_net_poc.Location = New System.Drawing.Point(78, 87)
        Me.txt_net_poc.Name = "txt_net_poc"
        Me.txt_net_poc.Size = New System.Drawing.Size(100, 20)
        Me.txt_net_poc.TabIndex = 31
        Me.txt_net_poc.Text = "0.00"
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(139, 89)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(111, 20)
        Me.txtName.TabIndex = 9
        Me.txtName.Visible = False
        '
        'txtNum
        '
        Me.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNum.Location = New System.Drawing.Point(229, 62)
        Me.txtNum.Name = "txtNum"
        Me.txtNum.Size = New System.Drawing.Size(111, 20)
        Me.txtNum.TabIndex = 10
        Me.txtNum.Text = "0"
        Me.txtNum.Visible = False
        '
        'txtdiscAcc
        '
        Me.txtdiscAcc.Location = New System.Drawing.Point(345, 88)
        Me.txtdiscAcc.Name = "txtdiscAcc"
        Me.txtdiscAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtdiscAcc.TabIndex = 36
        '
        'txtcashAcc
        '
        Me.txtcashAcc.Location = New System.Drawing.Point(255, 139)
        Me.txtcashAcc.Name = "txtcashAcc"
        Me.txtcashAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtcashAcc.TabIndex = 38
        '
        'txtsalesAcc
        '
        Me.txtsalesAcc.Location = New System.Drawing.Point(256, 114)
        Me.txtsalesAcc.Name = "txtsalesAcc"
        Me.txtsalesAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtsalesAcc.TabIndex = 40
        '
        'txtInvAcc
        '
        Me.txtInvAcc.Location = New System.Drawing.Point(345, 62)
        Me.txtInvAcc.Name = "txtInvAcc"
        Me.txtInvAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtInvAcc.TabIndex = 37
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(144, 113)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 20)
        Me.txtid.TabIndex = 21
        '
        'txtcogsAcc
        '
        Me.txtcogsAcc.Location = New System.Drawing.Point(345, 37)
        Me.txtcogsAcc.Name = "txtcogsAcc"
        Me.txtcogsAcc.Size = New System.Drawing.Size(100, 20)
        Me.txtcogsAcc.TabIndex = 39
        '
        'mTax
        '
        Me.mTax.Location = New System.Drawing.Point(471, 61)
        Me.mTax.Name = "mTax"
        Me.mTax.Size = New System.Drawing.Size(100, 20)
        Me.mTax.TabIndex = 20
        Me.mTax.Text = "0.00"
        Me.mTax.Visible = False
        '
        'txtDisc
        '
        Me.txtDisc.Location = New System.Drawing.Point(344, 113)
        Me.txtDisc.Name = "txtDisc"
        Me.txtDisc.Size = New System.Drawing.Size(100, 20)
        Me.txtDisc.TabIndex = 19
        Me.txtDisc.Text = "0.00"
        Me.txtDisc.Visible = False
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(138, 48)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(49, 13)
        Me.lblTime.TabIndex = 14
        Me.lblTime.Text = "00:00:00"
        '
        'txtutot
        '
        Me.txtutot.Location = New System.Drawing.Point(144, 35)
        Me.txtutot.Name = "txtutot"
        Me.txtutot.Size = New System.Drawing.Size(100, 20)
        Me.txtutot.TabIndex = 33
        '
        'lblzeros
        '
        Me.lblzeros.AutoSize = True
        Me.lblzeros.Location = New System.Drawing.Point(72, 19)
        Me.lblzeros.Name = "lblzeros"
        Me.lblzeros.Size = New System.Drawing.Size(28, 13)
        Me.lblzeros.TabIndex = 14
        Me.lblzeros.Text = "0.00"
        Me.lblzeros.Visible = False
        '
        'txtunitcost
        '
        Me.txtunitcost.Location = New System.Drawing.Point(144, 87)
        Me.txtunitcost.Name = "txtunitcost"
        Me.txtunitcost.Size = New System.Drawing.Size(100, 20)
        Me.txtunitcost.TabIndex = 16
        '
        'txtamt
        '
        Me.txtamt.Location = New System.Drawing.Point(629, 77)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Size = New System.Drawing.Size(100, 20)
        Me.txtamt.TabIndex = 15
        '
        'txtTax
        '
        Me.txtTax.Location = New System.Drawing.Point(144, 139)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(100, 20)
        Me.txtTax.TabIndex = 14
        Me.txtTax.Text = "0"
        '
        'mDisc
        '
        Me.mDisc.Location = New System.Drawing.Point(33, 35)
        Me.mDisc.Name = "mDisc"
        Me.mDisc.Size = New System.Drawing.Size(100, 20)
        Me.mDisc.TabIndex = 13
        Me.mDisc.Text = "0"
        '
        'txtrate
        '
        Me.txtrate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrate.Location = New System.Drawing.Point(724, 13)
        Me.txtrate.Name = "txtrate"
        Me.txtrate.ReadOnly = True
        Me.txtrate.Size = New System.Drawing.Size(100, 20)
        Me.txtrate.TabIndex = 4
        Me.txtrate.Text = "0.00"
        Me.txtrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtqty
        '
        Me.txtqty.BackColor = System.Drawing.Color.Green
        Me.txtqty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtqty.ForeColor = System.Drawing.Color.Yellow
        Me.txtqty.Location = New System.Drawing.Point(724, 39)
        Me.txtqty.Name = "txtqty"
        Me.txtqty.Size = New System.Drawing.Size(100, 20)
        Me.txtqty.TabIndex = 3
        Me.txtqty.Text = "0"
        Me.txtqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtvatval
        '
        Me.txtvatval.BackColor = System.Drawing.Color.White
        Me.txtvatval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvatval.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvatval.Location = New System.Drawing.Point(255, 35)
        Me.txtvatval.Name = "txtvatval"
        Me.txtvatval.Size = New System.Drawing.Size(107, 20)
        Me.txtvatval.TabIndex = 45
        Me.txtvatval.Text = "0.00"
        Me.txtvatval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTaxAcc
        '
        Me.txtTaxAcc.Location = New System.Drawing.Point(78, 139)
        Me.txtTaxAcc.Name = "txtTaxAcc"
        Me.txtTaxAcc.Size = New System.Drawing.Size(122, 20)
        Me.txtTaxAcc.TabIndex = 46
        '
        'lblyear2
        '
        Me.lblyear2.AutoSize = True
        Me.lblyear2.Location = New System.Drawing.Point(257, 89)
        Me.lblyear2.Name = "lblyear2"
        Me.lblyear2.Size = New System.Drawing.Size(39, 13)
        Me.lblyear2.TabIndex = 4
        Me.lblyear2.Text = "Label4"
        '
        'dthistdate
        '
        Me.dthistdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dthistdate.Location = New System.Drawing.Point(144, 115)
        Me.dthistdate.Name = "dthistdate"
        Me.dthistdate.Size = New System.Drawing.Size(106, 20)
        Me.dthistdate.TabIndex = 33
        '
        'txtcustid
        '
        Me.txtcustid.Location = New System.Drawing.Point(33, 113)
        Me.txtcustid.Name = "txtcustid"
        Me.txtcustid.Size = New System.Drawing.Size(159, 20)
        Me.txtcustid.TabIndex = 10
        Me.txtcustid.Visible = False
        '
        'txtsaldisc
        '
        Me.txtsaldisc.BackColor = System.Drawing.Color.White
        Me.txtsaldisc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsaldisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsaldisc.Location = New System.Drawing.Point(858, 267)
        Me.txtsaldisc.Name = "txtsaldisc"
        Me.txtsaldisc.Size = New System.Drawing.Size(107, 20)
        Me.txtsaldisc.TabIndex = 44
        Me.txtsaldisc.Text = "0.00"
        Me.txtsaldisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtvat
        '
        Me.txtvat.BackColor = System.Drawing.Color.White
        Me.txtvat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtvat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvat.Location = New System.Drawing.Point(430, 100)
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
        Me.Label7.Location = New System.Drawing.Point(392, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "VAT"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(855, 336)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Net Total"
        '
        'txtsubtot
        '
        Me.txtsubtot.BackColor = System.Drawing.Color.White
        Me.txtsubtot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsubtot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsubtot.Location = New System.Drawing.Point(858, 313)
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
        Me.txtTotal.Location = New System.Drawing.Point(858, 355)
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
        Me.Label4.Location = New System.Drawing.Point(855, 294)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Subtotal"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtposition)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtemp)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtempid)
        Me.GroupBox1.Controls.Add(Me.txtref)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dtSalesDate)
        Me.GroupBox1.Controls.Add(Me.mSaleNo)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblTime)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 103)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaction :"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(318, 74)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(50, 13)
        Me.Label14.TabIndex = 20
        Me.Label14.Text = "Position :"
        '
        'txtposition
        '
        Me.txtposition.Location = New System.Drawing.Point(374, 70)
        Me.txtposition.Name = "txtposition"
        Me.txtposition.ReadOnly = True
        Me.txtposition.Size = New System.Drawing.Size(163, 20)
        Me.txtposition.TabIndex = 19
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(309, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "Employee :"
        '
        'txtemp
        '
        Me.txtemp.Location = New System.Drawing.Point(374, 44)
        Me.txtemp.Name = "txtemp"
        Me.txtemp.ReadOnly = True
        Me.txtemp.Size = New System.Drawing.Size(163, 20)
        Me.txtemp.TabIndex = 17
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(295, 24)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 13)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Employee ID :"
        '
        'txtempid
        '
        Me.txtempid.Location = New System.Drawing.Point(374, 19)
        Me.txtempid.Name = "txtempid"
        Me.txtempid.ReadOnly = True
        Me.txtempid.Size = New System.Drawing.Size(163, 20)
        Me.txtempid.TabIndex = 15
        '
        'txtref
        '
        Me.txtref.Location = New System.Drawing.Point(95, 71)
        Me.txtref.Name = "txtref"
        Me.txtref.Size = New System.Drawing.Size(92, 20)
        Me.txtref.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Reference No  : "
        '
        'dtSalesDate
        '
        Me.dtSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtSalesDate.Location = New System.Drawing.Point(95, 19)
        Me.dtSalesDate.Name = "dtSalesDate"
        Me.dtSalesDate.Size = New System.Drawing.Size(172, 20)
        Me.dtSalesDate.TabIndex = 6
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvsales)
        Me.GroupBox3.Controls.Add(Me.mTax)
        Me.GroupBox3.Controls.Add(Me.txtDisc)
        Me.GroupBox3.Controls.Add(Me.txtcogsAcc)
        Me.GroupBox3.Controls.Add(Me.lblyear2)
        Me.GroupBox3.Controls.Add(Me.txtInvAcc)
        Me.GroupBox3.Controls.Add(Me.txtdiscAcc)
        Me.GroupBox3.Controls.Add(Me.txt_net_poc)
        Me.GroupBox3.Controls.Add(Me.txtvat)
        Me.GroupBox3.Controls.Add(Me.txtcashAcc)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtcustid)
        Me.GroupBox3.Controls.Add(Me.txtsalesAcc)
        Me.GroupBox3.Controls.Add(Me.txtName)
        Me.GroupBox3.Controls.Add(Me.txtvatval)
        Me.GroupBox3.Controls.Add(Me.txtid)
        Me.GroupBox3.Controls.Add(Me.txtTaxAcc)
        Me.GroupBox3.Controls.Add(Me.dthistdate)
        Me.GroupBox3.Controls.Add(Me.txtutot)
        Me.GroupBox3.Controls.Add(Me.lblzeros)
        Me.GroupBox3.Controls.Add(Me.txtamt)
        Me.GroupBox3.Controls.Add(Me.txtqtycheck)
        Me.GroupBox3.Controls.Add(Me.txtNum)
        Me.GroupBox3.Controls.Add(Me.mDisc)
        Me.GroupBox3.Controls.Add(Me.chkvat)
        Me.GroupBox3.Controls.Add(Me.txtunitcost)
        Me.GroupBox3.Controls.Add(Me.txtTax)
        Me.GroupBox3.Controls.Add(Me.TID)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 294)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(830, 245)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Details"
        '
        'txtqtycheck
        '
        Me.txtqtycheck.Location = New System.Drawing.Point(629, 51)
        Me.txtqtycheck.Name = "txtqtycheck"
        Me.txtqtycheck.Size = New System.Drawing.Size(100, 20)
        Me.txtqtycheck.TabIndex = 59
        Me.txtqtycheck.Text = "0"
        '
        'TID
        '
        Me.TID.Location = New System.Drawing.Point(55, 129)
        Me.TID.Name = "TID"
        Me.TID.Size = New System.Drawing.Size(100, 20)
        Me.TID.TabIndex = 60
        '
        'btnSearch
        '
        Me.btnSearch.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnSearch.Appearance.Options.UseFont = True
        Me.btnSearch.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.search_16x16
        Me.btnSearch.Location = New System.Drawing.Point(709, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(119, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Product Search"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(378, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Product / Barcode :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(18, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(258, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Point Of Sale (POS) System - 3"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtmemid)
        Me.GroupBox7.Controls.Add(Me.Label17)
        Me.GroupBox7.Controls.Add(Me.cboCustomer)
        Me.GroupBox7.Controls.Add(Me.Label16)
        Me.GroupBox7.Controls.Add(Me.rbomem)
        Me.GroupBox7.Controls.Add(Me.rbogen)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Location = New System.Drawing.Point(567, 70)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(272, 103)
        Me.GroupBox7.TabIndex = 48
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Customer Info :"
        '
        'txtmemid
        '
        Me.txtmemid.Location = New System.Drawing.Point(81, 74)
        Me.txtmemid.Name = "txtmemid"
        Me.txtmemid.ReadOnly = True
        Me.txtmemid.Size = New System.Drawing.Size(178, 20)
        Me.txtmemid.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(15, 51)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Full Name :"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 78)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 13)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Member ID :"
        '
        'rbomem
        '
        Me.rbomem.AutoSize = True
        Me.rbomem.Location = New System.Drawing.Point(163, 23)
        Me.rbomem.Name = "rbomem"
        Me.rbomem.Size = New System.Drawing.Size(63, 17)
        Me.rbomem.TabIndex = 1
        Me.rbomem.TabStop = True
        Me.rbomem.Text = "Member"
        Me.rbomem.UseVisualStyleBackColor = True
        '
        'rbogen
        '
        Me.rbogen.AutoSize = True
        Me.rbogen.Checked = True
        Me.rbogen.Location = New System.Drawing.Point(95, 22)
        Me.rbogen.Name = "rbogen"
        Me.rbogen.Size = New System.Drawing.Size(62, 17)
        Me.rbogen.TabIndex = 1
        Me.rbogen.TabStop = True
        Me.rbogen.Text = "General"
        Me.rbogen.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(32, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 0
        Me.Label15.Text = "Type :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtdescription)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtstock)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtproduct)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtbarcode)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtqty)
        Me.GroupBox2.Controls.Add(Me.txtrate)
        Me.GroupBox2.Controls.Add(Me.txtcomp)
        Me.GroupBox2.Controls.Add(Me.txtsyncode)
        Me.GroupBox2.Controls.Add(Me.txtposid)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 206)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(830, 66)
        Me.GroupBox2.TabIndex = 50
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Product Info :"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(298, 16)
        Me.txtdescription.Multiline = True
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.ReadOnly = True
        Me.txtdescription.Size = New System.Drawing.Size(269, 44)
        Me.txtdescription.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(226, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Description :"
        '
        'txtstock
        '
        Me.txtstock.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtstock.Location = New System.Drawing.Point(576, 39)
        Me.txtstock.Name = "txtstock"
        Me.txtstock.ReadOnly = True
        Me.txtstock.Size = New System.Drawing.Size(100, 20)
        Me.txtstock.TabIndex = 8
        Me.txtstock.Text = "0"
        Me.txtstock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(573, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Current Stock"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(689, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 13)
        Me.Label20.TabIndex = 6
        Me.Label20.Text = "Qty :"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(657, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Sale Price :"
        '
        'txtproduct
        '
        Me.txtproduct.Location = New System.Drawing.Point(86, 39)
        Me.txtproduct.Name = "txtproduct"
        Me.txtproduct.ReadOnly = True
        Me.txtproduct.Size = New System.Drawing.Size(196, 20)
        Me.txtproduct.TabIndex = 3
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(30, 42)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Product :"
        '
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(86, 13)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.ReadOnly = True
        Me.txtbarcode.Size = New System.Drawing.Size(119, 20)
        Me.txtbarcode.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Product ID :"
        '
        'txtcomp
        '
        Me.txtcomp.Location = New System.Drawing.Point(321, 28)
        Me.txtcomp.Name = "txtcomp"
        Me.txtcomp.Size = New System.Drawing.Size(100, 20)
        Me.txtcomp.TabIndex = 11
        '
        'txtsyncode
        '
        Me.txtsyncode.Location = New System.Drawing.Point(427, 28)
        Me.txtsyncode.Name = "txtsyncode"
        Me.txtsyncode.Size = New System.Drawing.Size(100, 20)
        Me.txtsyncode.TabIndex = 12
        Me.txtsyncode.Text = "1"
        '
        'txtposid
        '
        Me.txtposid.Location = New System.Drawing.Point(330, 28)
        Me.txtposid.Name = "txtposid"
        Me.txtposid.Size = New System.Drawing.Size(197, 20)
        Me.txtposid.TabIndex = 4
        '
        'txtreceive
        '
        Me.txtreceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtreceive.Location = New System.Drawing.Point(858, 396)
        Me.txtreceive.Name = "txtreceive"
        Me.txtreceive.Size = New System.Drawing.Size(107, 20)
        Me.txtreceive.TabIndex = 51
        Me.txtreceive.Text = "0.00"
        Me.txtreceive.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtchange
        '
        Me.txtchange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtchange.Location = New System.Drawing.Point(858, 441)
        Me.txtchange.Name = "txtchange"
        Me.txtchange.Size = New System.Drawing.Size(110, 20)
        Me.txtchange.TabIndex = 52
        Me.txtchange.Text = "0.00"
        Me.txtchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(855, 378)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 54
        Me.Label23.Text = "Amt. Received"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(862, 420)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(44, 13)
        Me.Label24.TabIndex = 55
        Me.Label24.Text = "Change"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(9, 272)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(830, 15)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 58
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(9, 182)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(587, 18)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 57
        Me.PictureBox1.TabStop = False
        '
        'btnsave
        '
        Me.btnsave.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnsave.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnsave.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnsave.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.btnsave.Appearance.Options.UseBackColor = True
        Me.btnsave.Appearance.Options.UseFont = True
        Me.btnsave.Appearance.Options.UseForeColor = True
        Me.btnsave.Enabled = False
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.apply_32x323
        Me.btnsave.Location = New System.Drawing.Point(858, 478)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(110, 39)
        Me.btnsave.TabIndex = 2
        Me.btnsave.Text = "Save | Print"
        '
        'btnclose
        '
        Me.btnclose.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnclose.Appearance.BackColor2 = System.Drawing.Color.Red
        Me.btnclose.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnclose.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.btnclose.Appearance.Options.UseBackColor = True
        Me.btnclose.Appearance.Options.UseFont = True
        Me.btnclose.Appearance.Options.UseForeColor = True
        Me.btnclose.ImageOptions.Image = CType(resources.GetObject("btnclose.ImageOptions.Image"), System.Drawing.Image)
        Me.btnclose.Location = New System.Drawing.Point(858, 138)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(107, 62)
        Me.btnclose.TabIndex = 53
        Me.btnclose.Text = "Refresh"
        '
        'btnnew
        '
        Me.btnnew.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnnew.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnnew.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnnew.Appearance.ForeColor = System.Drawing.Color.White
        Me.btnnew.Appearance.Options.UseBackColor = True
        Me.btnnew.Appearance.Options.UseFont = True
        Me.btnnew.Appearance.Options.UseForeColor = True
        Me.btnnew.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.pencolor_32x32
        Me.btnnew.Location = New System.Drawing.Point(858, 72)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(107, 62)
        Me.btnnew.TabIndex = 51
        Me.btnnew.Text = "New"
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
        'lvdrop
        '
        Me.lvdrop.DataSource = Me.ProductpriceBindingSource
        Me.lvdrop.Location = New System.Drawing.Point(387, 43)
        Me.lvdrop.MainView = Me.GridView1
        Me.lvdrop.Name = "lvdrop"
        Me.lvdrop.Size = New System.Drawing.Size(451, 229)
        Me.lvdrop.TabIndex = 59
        Me.lvdrop.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        Me.lvdrop.Visible = False
        '
        'ProductpriceBindingSource
        '
        Me.ProductpriceBindingSource.DataMember = "product_price"
        Me.ProductpriceBindingSource.DataSource = Me.DsProduct
        '
        'DsProduct
        '
        Me.DsProduct.DataSetName = "dsProduct"
        Me.DsProduct.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colProduct, Me.colQtyonhand, Me.colPrice})
        Me.GridView1.GridControl = Me.lvdrop
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'colProduct
        '
        Me.colProduct.FieldName = "Product"
        Me.colProduct.Name = "colProduct"
        Me.colProduct.Visible = True
        Me.colProduct.VisibleIndex = 0
        Me.colProduct.Width = 190
        '
        'colQtyonhand
        '
        Me.colQtyonhand.AppearanceCell.Options.UseTextOptions = True
        Me.colQtyonhand.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colQtyonhand.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colQtyonhand.AppearanceHeader.Options.UseTextOptions = True
        Me.colQtyonhand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colQtyonhand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colQtyonhand.FieldName = "Qty on hand"
        Me.colQtyonhand.Name = "colQtyonhand"
        Me.colQtyonhand.Visible = True
        Me.colQtyonhand.VisibleIndex = 1
        '
        'colPrice
        '
        Me.colPrice.AppearanceCell.Options.UseTextOptions = True
        Me.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colPrice.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.colPrice.DisplayFormat.FormatString = "n2"
        Me.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colPrice.FieldName = "Price"
        Me.colPrice.Name = "colPrice"
        Me.colPrice.Visible = True
        Me.colPrice.VisibleIndex = 2
        Me.colPrice.Width = 40
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Navy
        Me.GroupBox4.Controls.Add(Me.cbodata)
        Me.GroupBox4.Controls.Add(Me.btnSearch)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(972, 57)
        Me.GroupBox4.TabIndex = 60
        Me.GroupBox4.TabStop = False
        '
        'cbodata
        '
        Me.cbodata.Location = New System.Drawing.Point(476, 19)
        Me.cbodata.Name = "cbodata"
        Me.cbodata.Size = New System.Drawing.Size(227, 20)
        Me.cbodata.TabIndex = 5
        '
        'POSForm3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(980, 543)
        Me.Controls.Add(Me.lvdrop)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtchange)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtsaldisc)
        Me.Controls.Add(Me.txtreceive)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtsubtot)
        Me.Controls.Add(Me.cboPayMeth)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "POSForm3"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Point Of Sale (POS) System"
        CType(Me.dgvsales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.lvdrop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ProductpriceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsProduct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCustomer As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents mSaleNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPayMeth As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvsales As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents chkvat As CheckBox
    Friend WithEvents txt_net_poc As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtNum As TextBox
    Friend WithEvents txtdiscAcc As TextBox
    Friend WithEvents txtcashAcc As TextBox
    Friend WithEvents txtsalesAcc As TextBox
    Friend WithEvents txtInvAcc As TextBox
    Friend WithEvents txtid As TextBox
    Friend WithEvents txtcogsAcc As TextBox
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
    Friend WithEvents txtvatval As TextBox
    Friend WithEvents txtTaxAcc As TextBox
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents lblyear2 As Label
    Friend WithEvents dthistdate As DateTimePicker
    Friend WithEvents txtcustid As TextBox
    Friend WithEvents txtsaldisc As TextBox
    Friend WithEvents txtvat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtsubtot As TextBox
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtposition As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtemp As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtempid As TextBox
    Friend WithEvents txtref As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents dtSalesDate As DateTimePicker
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents txtmemid As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents rbomem As RadioButton
    Friend WithEvents rbogen As RadioButton
    Friend WithEvents Label15 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtreceive As TextBox
    Friend WithEvents txtchange As TextBox
    Friend WithEvents btnSearch As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label3 As Label
    Friend WithEvents txtstock As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtproduct As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtbarcode As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnnew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtdescription As TextBox
    Friend WithEvents txtqtycheck As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtcomp As TextBox
    Friend WithEvents txtsyncode As TextBox
    Friend WithEvents TID As TextBox
    Friend WithEvents txtposid As TextBox
    Friend WithEvents lvdrop As DevExpress.XtraGrid.GridControl
    Friend WithEvents ProductpriceBindingSource As BindingSource
    Friend WithEvents DsProduct As dsProduct
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colProduct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colQtyonhand As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cbodata As TextBox
End Class

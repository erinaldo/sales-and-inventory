<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PayBillsForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PayBillsForm))
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnpay = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbopaystat = New System.Windows.Forms.ComboBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.mCheck = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.mBal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.mMemo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboAccount = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboMethod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PayDate = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblZeros = New System.Windows.Forms.Label()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvPayBill = New System.Windows.Forms.DataGridView()
        Me.lblpid = New System.Windows.Forms.Label()
        Me.lblyear = New System.Windows.Forms.Label()
        Me.txtpart = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtcheckbank = New System.Windows.Forms.TextBox()
        Me.txtbank = New System.Windows.Forms.TextBox()
        Me.cboPayAccount = New System.Windows.Forms.ComboBox()
        Me.txtAcNum = New System.Windows.Forms.TextBox()
        Me.lblcrerev = New System.Windows.Forms.Label()
        Me.txtupaid = New System.Windows.Forms.TextBox()
        Me.lbldebrev = New System.Windows.Forms.Label()
        Me.cboventname = New System.Windows.Forms.ComboBox()
        Me.txt_net_poc = New System.Windows.Forms.TextBox()
        Me.chkshowbills = New System.Windows.Forms.CheckBox()
        Me.cbo_re_cy = New System.Windows.Forms.ComboBox()
        Me.cbo_ret_py = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblAmtDue = New System.Windows.Forms.TextBox()
        Me.lbltotal = New System.Windows.Forms.TextBox()
        Me.DueBeforeDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCredit = New System.Windows.Forms.Label()
        Me.lblPaid = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Time_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvPayBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(93, 22)
        Me.ToolStripButton1.Text = "Print Statement"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(365, 78)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(81, 13)
        Me.Label11.TabIndex = 317
        Me.Label11.Text = "Payment Status"
        '
        'btncancel
        '
        Me.btncancel.Image = CType(resources.GetObject("btncancel.Image"), System.Drawing.Image)
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(63, 22)
        Me.btncancel.Text = "Cancel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnpay
        '
        Me.btnpay.Image = CType(resources.GetObject("btnpay.Image"), System.Drawing.Image)
        Me.btnpay.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnpay.Name = "btnpay"
        Me.btnpay.Size = New System.Drawing.Size(106, 22)
        Me.btnpay.Text = "Make Payment"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cbopaystat)
        Me.GroupBox2.Controls.Add(Me.lbltimer)
        Me.GroupBox2.Controls.Add(Me.mCheck)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.mBal)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.mMemo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboAccount)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cboMethod)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.PayDate)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.lblZeros)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 276)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(637, 104)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment"
        '
        'cbopaystat
        '
        Me.cbopaystat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbopaystat.FormattingEnabled = True
        Me.cbopaystat.Items.AddRange(New Object() {"Part Payment", "Paid"})
        Me.cbopaystat.Location = New System.Drawing.Point(452, 75)
        Me.cbopaystat.Name = "cbopaystat"
        Me.cbopaystat.Size = New System.Drawing.Size(174, 21)
        Me.cbopaystat.TabIndex = 316
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(577, 78)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(49, 13)
        Me.lbltimer.TabIndex = 315
        Me.lbltimer.Text = "00:00:00"
        Me.lbltimer.Visible = False
        '
        'mCheck
        '
        Me.mCheck.BackColor = System.Drawing.SystemColors.Window
        Me.mCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mCheck.Location = New System.Drawing.Point(74, 45)
        Me.mCheck.Name = "mCheck"
        Me.mCheck.Size = New System.Drawing.Size(264, 20)
        Me.mCheck.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 47)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Check No."
        '
        'mBal
        '
        Me.mBal.BackColor = System.Drawing.Color.White
        Me.mBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mBal.Location = New System.Drawing.Point(452, 47)
        Me.mBal.Name = "mBal"
        Me.mBal.ReadOnly = True
        Me.mBal.Size = New System.Drawing.Size(174, 22)
        Me.mBal.TabIndex = 11
        Me.mBal.Text = "0.00"
        Me.mBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(400, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Balance"
        '
        'mMemo
        '
        Me.mMemo.BackColor = System.Drawing.SystemColors.Window
        Me.mMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mMemo.Location = New System.Drawing.Point(74, 71)
        Me.mMemo.Name = "mMemo"
        Me.mMemo.Size = New System.Drawing.Size(264, 20)
        Me.mMemo.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Memo"
        '
        'cboAccount
        '
        Me.cboAccount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAccount.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccount.DropDownWidth = 350
        Me.cboAccount.FormattingEnabled = True
        Me.cboAccount.Location = New System.Drawing.Point(452, 17)
        Me.cboAccount.Name = "cboAccount"
        Me.cboAccount.Size = New System.Drawing.Size(174, 21)
        Me.cboAccount.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(399, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Account"
        '
        'cboMethod
        '
        Me.cboMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboMethod.BackColor = System.Drawing.SystemColors.Window
        Me.cboMethod.FormattingEnabled = True
        Me.cboMethod.Items.AddRange(New Object() {"Cash", "Check", "Visa Card"})
        Me.cboMethod.Location = New System.Drawing.Point(224, 19)
        Me.cboMethod.Name = "cboMethod"
        Me.cboMethod.Size = New System.Drawing.Size(114, 21)
        Me.cboMethod.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(177, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Method"
        '
        'PayDate
        '
        Me.PayDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.PayDate.Location = New System.Drawing.Point(74, 20)
        Me.PayDate.Name = "PayDate"
        Me.PayDate.Size = New System.Drawing.Size(97, 20)
        Me.PayDate.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Date"
        '
        'lblZeros
        '
        Me.lblZeros.AutoSize = True
        Me.lblZeros.BackColor = System.Drawing.SystemColors.Window
        Me.lblZeros.Location = New System.Drawing.Point(292, 73)
        Me.lblZeros.Name = "lblZeros"
        Me.lblZeros.Size = New System.Drawing.Size(28, 13)
        Me.lblZeros.TabIndex = 314
        Me.lblZeros.Text = "0.00"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.dgvPayBill)
        Me.GroupBox1.Controls.Add(Me.lblpid)
        Me.GroupBox1.Controls.Add(Me.lblyear)
        Me.GroupBox1.Controls.Add(Me.txtpart)
        Me.GroupBox1.Controls.Add(Me.txtID)
        Me.GroupBox1.Controls.Add(Me.txtcheckbank)
        Me.GroupBox1.Controls.Add(Me.txtbank)
        Me.GroupBox1.Controls.Add(Me.cboPayAccount)
        Me.GroupBox1.Controls.Add(Me.txtAcNum)
        Me.GroupBox1.Controls.Add(Me.lblcrerev)
        Me.GroupBox1.Controls.Add(Me.txtupaid)
        Me.GroupBox1.Controls.Add(Me.lbldebrev)
        Me.GroupBox1.Controls.Add(Me.cboventname)
        Me.GroupBox1.Controls.Add(Me.txt_net_poc)
        Me.GroupBox1.Controls.Add(Me.chkshowbills)
        Me.GroupBox1.Controls.Add(Me.cbo_re_cy)
        Me.GroupBox1.Controls.Add(Me.cbo_ret_py)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblAmtDue)
        Me.GroupBox1.Controls.Add(Me.lbltotal)
        Me.GroupBox1.Controls.Add(Me.DueBeforeDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboFilter)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblCredit)
        Me.GroupBox1.Controls.Add(Me.lblPaid)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(637, 222)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bills To Pay"
        '
        'dgvPayBill
        '
        Me.dgvPayBill.AllowUserToAddRows = False
        Me.dgvPayBill.BackgroundColor = System.Drawing.Color.White
        Me.dgvPayBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPayBill.GridColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvPayBill.Location = New System.Drawing.Point(6, 60)
        Me.dgvPayBill.Name = "dgvPayBill"
        Me.dgvPayBill.RowHeadersVisible = False
        Me.dgvPayBill.Size = New System.Drawing.Size(620, 126)
        Me.dgvPayBill.TabIndex = 7
        '
        'lblpid
        '
        Me.lblpid.AutoSize = True
        Me.lblpid.Location = New System.Drawing.Point(29, 117)
        Me.lblpid.Name = "lblpid"
        Me.lblpid.Size = New System.Drawing.Size(28, 13)
        Me.lblpid.TabIndex = 14
        Me.lblpid.Text = "Paid"
        '
        'lblyear
        '
        Me.lblyear.AutoSize = True
        Me.lblyear.Location = New System.Drawing.Point(538, 169)
        Me.lblyear.Name = "lblyear"
        Me.lblyear.Size = New System.Drawing.Size(39, 13)
        Me.lblyear.TabIndex = 271
        Me.lblyear.Text = "Label8"
        '
        'txtpart
        '
        Me.txtpart.Location = New System.Drawing.Point(140, 193)
        Me.txtpart.Name = "txtpart"
        Me.txtpart.Size = New System.Drawing.Size(100, 20)
        Me.txtpart.TabIndex = 313
        Me.txtpart.Text = "Part Payment"
        Me.txtpart.Visible = False
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(22, 84)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 309
        '
        'txtcheckbank
        '
        Me.txtcheckbank.Location = New System.Drawing.Point(175, 84)
        Me.txtcheckbank.Name = "txtcheckbank"
        Me.txtcheckbank.Size = New System.Drawing.Size(100, 20)
        Me.txtcheckbank.TabIndex = 314
        '
        'txtbank
        '
        Me.txtbank.Location = New System.Drawing.Point(390, 87)
        Me.txtbank.Name = "txtbank"
        Me.txtbank.Size = New System.Drawing.Size(100, 20)
        Me.txtbank.TabIndex = 316
        '
        'cboPayAccount
        '
        Me.cboPayAccount.FormattingEnabled = True
        Me.cboPayAccount.Location = New System.Drawing.Point(104, 117)
        Me.cboPayAccount.Name = "cboPayAccount"
        Me.cboPayAccount.Size = New System.Drawing.Size(171, 21)
        Me.cboPayAccount.TabIndex = 3
        '
        'txtAcNum
        '
        Me.txtAcNum.Location = New System.Drawing.Point(515, 84)
        Me.txtAcNum.Name = "txtAcNum"
        Me.txtAcNum.Size = New System.Drawing.Size(100, 20)
        Me.txtAcNum.TabIndex = 315
        '
        'lblcrerev
        '
        Me.lblcrerev.AutoSize = True
        Me.lblcrerev.Location = New System.Drawing.Point(346, 146)
        Me.lblcrerev.Name = "lblcrerev"
        Me.lblcrerev.Size = New System.Drawing.Size(45, 13)
        Me.lblcrerev.TabIndex = 276
        Me.lblcrerev.Text = "Label12"
        '
        'txtupaid
        '
        Me.txtupaid.Location = New System.Drawing.Point(13, 192)
        Me.txtupaid.Name = "txtupaid"
        Me.txtupaid.Size = New System.Drawing.Size(100, 20)
        Me.txtupaid.TabIndex = 312
        Me.txtupaid.Text = "Unpaid"
        Me.txtupaid.Visible = False
        '
        'lbldebrev
        '
        Me.lbldebrev.AutoSize = True
        Me.lbldebrev.Location = New System.Drawing.Point(278, 146)
        Me.lbldebrev.Name = "lbldebrev"
        Me.lbldebrev.Size = New System.Drawing.Size(45, 13)
        Me.lbldebrev.TabIndex = 275
        Me.lbldebrev.Text = "Label12"
        '
        'cboventname
        '
        Me.cboventname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboventname.DropDownWidth = 350
        Me.cboventname.FormattingEnabled = True
        Me.cboventname.Location = New System.Drawing.Point(317, 17)
        Me.cboventname.Name = "cboventname"
        Me.cboventname.Size = New System.Drawing.Size(221, 21)
        Me.cboventname.TabIndex = 311
        '
        'txt_net_poc
        '
        Me.txt_net_poc.Location = New System.Drawing.Point(189, 110)
        Me.txt_net_poc.Name = "txt_net_poc"
        Me.txt_net_poc.Size = New System.Drawing.Size(100, 20)
        Me.txt_net_poc.TabIndex = 273
        Me.txt_net_poc.Text = "0.00"
        '
        'chkshowbills
        '
        Me.chkshowbills.AutoSize = True
        Me.chkshowbills.Checked = True
        Me.chkshowbills.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkshowbills.Location = New System.Drawing.Point(7, 19)
        Me.chkshowbills.Name = "chkshowbills"
        Me.chkshowbills.Size = New System.Drawing.Size(74, 17)
        Me.chkshowbills.TabIndex = 310
        Me.chkshowbills.Text = "Show Bills"
        Me.chkshowbills.UseVisualStyleBackColor = True
        '
        'cbo_re_cy
        '
        Me.cbo_re_cy.FormattingEnabled = True
        Me.cbo_re_cy.Location = New System.Drawing.Point(452, 110)
        Me.cbo_re_cy.Name = "cbo_re_cy"
        Me.cbo_re_cy.Size = New System.Drawing.Size(142, 21)
        Me.cbo_re_cy.TabIndex = 272
        '
        'cbo_ret_py
        '
        Me.cbo_ret_py.FormattingEnabled = True
        Me.cbo_ret_py.Location = New System.Drawing.Point(295, 86)
        Me.cbo_ret_py.Name = "cbo_ret_py"
        Me.cbo_ret_py.Size = New System.Drawing.Size(150, 21)
        Me.cbo_ret_py.TabIndex = 274
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(101, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Date"
        '
        'lblAmtDue
        '
        Me.lblAmtDue.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblAmtDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmtDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmtDue.Location = New System.Drawing.Point(419, 192)
        Me.lblAmtDue.Name = "lblAmtDue"
        Me.lblAmtDue.ReadOnly = True
        Me.lblAmtDue.Size = New System.Drawing.Size(100, 21)
        Me.lblAmtDue.TabIndex = 16
        Me.lblAmtDue.Text = "0"
        Me.lblAmtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltotal
        '
        Me.lbltotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbltotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbltotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(526, 192)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.ReadOnly = True
        Me.lbltotal.Size = New System.Drawing.Size(100, 21)
        Me.lbltotal.TabIndex = 13
        Me.lbltotal.Text = "0"
        Me.lbltotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'DueBeforeDate
        '
        Me.DueBeforeDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DueBeforeDate.Location = New System.Drawing.Point(140, 16)
        Me.DueBeforeDate.Name = "DueBeforeDate"
        Me.DueBeforeDate.Size = New System.Drawing.Size(108, 20)
        Me.DueBeforeDate.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(367, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Totals"
        '
        'cboFilter
        '
        Me.cboFilter.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Location = New System.Drawing.Point(317, 17)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(129, 21)
        Me.cboFilter.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(255, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Filtered By"
        '
        'lblCredit
        '
        Me.lblCredit.AutoSize = True
        Me.lblCredit.Location = New System.Drawing.Point(534, 94)
        Me.lblCredit.Name = "lblCredit"
        Me.lblCredit.Size = New System.Drawing.Size(28, 13)
        Me.lblCredit.TabIndex = 17
        Me.lblCredit.Text = "0.00"
        '
        'lblPaid
        '
        Me.lblPaid.AutoSize = True
        Me.lblPaid.Location = New System.Drawing.Point(60, 153)
        Me.lblPaid.Name = "lblPaid"
        Me.lblPaid.Size = New System.Drawing.Size(28, 13)
        Me.lblPaid.TabIndex = 305
        Me.lblPaid.Text = "Paid"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnpay, Me.ToolStripSeparator2, Me.btncancel, Me.ToolStripSeparator3, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(659, 25)
        Me.ToolStrip1.TabIndex = 15
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Time_Timer
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni MT", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(242, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Payment of Bills"
        '
        'PayBillsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(659, 381)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "PayBillsForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pay Bills"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvPayBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Label11 As Label
    Friend WithEvents btncancel As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btnpay As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbopaystat As ComboBox
    Friend WithEvents lbltimer As Label
    Friend WithEvents mCheck As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents mBal As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents mMemo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cboAccount As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cboMethod As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents PayDate As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents lblZeros As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvPayBill As DataGridView
    Friend WithEvents lblpid As Label
    Friend WithEvents lblyear As Label
    Friend WithEvents txtpart As TextBox
    Friend WithEvents lblcrerev As Label
    Friend WithEvents txtupaid As TextBox
    Friend WithEvents lbldebrev As Label
    Friend WithEvents cboventname As ComboBox
    Friend WithEvents txt_net_poc As TextBox
    Friend WithEvents chkshowbills As CheckBox
    Friend WithEvents cbo_re_cy As ComboBox
    Friend WithEvents cbo_ret_py As ComboBox
    Friend WithEvents txtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblAmtDue As TextBox
    Friend WithEvents lbltotal As TextBox
    Friend WithEvents DueBeforeDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents cboFilter As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboPayAccount As ComboBox
    Friend WithEvents lblCredit As Label
    Friend WithEvents lblPaid As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Time_Timer As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents txtbank As TextBox
    Friend WithEvents txtAcNum As TextBox
    Friend WithEvents txtcheckbank As TextBox
End Class

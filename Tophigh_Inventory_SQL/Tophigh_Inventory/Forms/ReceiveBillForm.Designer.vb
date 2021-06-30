<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiveBillForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceiveBillForm))
        Me.dgvRecPay = New System.Windows.Forms.DataGridView()
        Me.lblcrerev = New System.Windows.Forms.Label()
        Me.lbldebrev = New System.Windows.Forms.Label()
        Me.cbo_re_cy = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboPay = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mRecRef = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.mRecDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mRecAmount = New System.Windows.Forms.TextBox()
        Me.cboRecFrom = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_net_poc = New System.Windows.Forms.TextBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbopaystatus = New System.Windows.Forms.ComboBox()
        Me.txtApplied = New System.Windows.Forms.TextBox()
        Me.txtAmtDue = New System.Windows.Forms.TextBox()
        Me.lbltimer = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cbocashonhand = New System.Windows.Forms.ComboBox()
        Me.PnlPOview = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_ret_py = New System.Windows.Forms.ComboBox()
        Me.lblZeros = New System.Windows.Forms.Label()
        Me.txtupay = New System.Windows.Forms.TextBox()
        Me.txtpartpay = New System.Windows.Forms.TextBox()
        Me.lblRec = New System.Windows.Forms.Label()
        Me.txtbank = New System.Windows.Forms.TextBox()
        Me.txtrecid = New System.Windows.Forms.TextBox()
        Me.lblyear = New System.Windows.Forms.Label()
        Me.lblReceived = New System.Windows.Forms.Label()
        Me.txtcheckbnk = New System.Windows.Forms.TextBox()
        Me.txtAcNum = New System.Windows.Forms.TextBox()
        Me.mMemo = New System.Windows.Forms.TextBox()
        Me.cboAR = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtBal = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btncancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Time_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.lblpaid = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnpayment = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.lblopen = New System.Windows.Forms.Label()
        Me.rbogen = New System.Windows.Forms.RadioButton()
        Me.rbomem = New System.Windows.Forms.RadioButton()
        CType(Me.dgvRecPay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PnlPOview.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRecPay
        '
        Me.dgvRecPay.AllowUserToAddRows = False
        Me.dgvRecPay.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecPay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecPay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecPay.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRecPay.GridColor = System.Drawing.Color.Blue
        Me.dgvRecPay.Location = New System.Drawing.Point(6, 12)
        Me.dgvRecPay.Name = "dgvRecPay"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRecPay.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRecPay.Size = New System.Drawing.Size(613, 118)
        Me.dgvRecPay.TabIndex = 17
        '
        'lblcrerev
        '
        Me.lblcrerev.AutoSize = True
        Me.lblcrerev.Location = New System.Drawing.Point(279, 103)
        Me.lblcrerev.Name = "lblcrerev"
        Me.lblcrerev.Size = New System.Drawing.Size(45, 13)
        Me.lblcrerev.TabIndex = 264
        Me.lblcrerev.Text = "Label12"
        '
        'lbldebrev
        '
        Me.lbldebrev.AutoSize = True
        Me.lbldebrev.Location = New System.Drawing.Point(171, 104)
        Me.lbldebrev.Name = "lbldebrev"
        Me.lbldebrev.Size = New System.Drawing.Size(45, 13)
        Me.lbldebrev.TabIndex = 263
        Me.lbldebrev.Text = "Label12"
        '
        'cbo_re_cy
        '
        Me.cbo_re_cy.FormattingEnabled = True
        Me.cbo_re_cy.Location = New System.Drawing.Point(23, 68)
        Me.cbo_re_cy.Name = "cbo_re_cy"
        Me.cbo_re_cy.Size = New System.Drawing.Size(142, 21)
        Me.cbo_re_cy.TabIndex = 262
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPay)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.mRecRef)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.mRecDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.mRecAmount)
        Me.GroupBox1.Controls.Add(Me.cboRecFrom)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 30)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(322, 148)
        Me.GroupBox1.TabIndex = 249
        Me.GroupBox1.TabStop = False
        '
        'cboPay
        '
        Me.cboPay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPay.DropDownWidth = 300
        Me.cboPay.FormattingEnabled = True
        Me.cboPay.Location = New System.Drawing.Point(96, 92)
        Me.cboPay.Name = "cboPay"
        Me.cboPay.Size = New System.Drawing.Size(203, 21)
        Me.cboPay.TabIndex = 32
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Reference:"
        '
        'mRecRef
        '
        Me.mRecRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mRecRef.Location = New System.Drawing.Point(97, 119)
        Me.mRecRef.Name = "mRecRef"
        Me.mRecRef.Size = New System.Drawing.Size(202, 20)
        Me.mRecRef.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(39, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Pay Into :"
        '
        'mRecDate
        '
        Me.mRecDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.mRecDate.Location = New System.Drawing.Point(97, 66)
        Me.mRecDate.Name = "mRecDate"
        Me.mRecDate.Size = New System.Drawing.Size(98, 20)
        Me.mRecDate.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Amount Paid:"
        '
        'mRecAmount
        '
        Me.mRecAmount.BackColor = System.Drawing.Color.White
        Me.mRecAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mRecAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mRecAmount.Location = New System.Drawing.Point(97, 42)
        Me.mRecAmount.Name = "mRecAmount"
        Me.mRecAmount.ReadOnly = True
        Me.mRecAmount.Size = New System.Drawing.Size(166, 20)
        Me.mRecAmount.TabIndex = 19
        Me.mRecAmount.Text = "0.00"
        Me.mRecAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboRecFrom
        '
        Me.cboRecFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRecFrom.DropDownWidth = 300
        Me.cboRecFrom.FormattingEnabled = True
        Me.cboRecFrom.Location = New System.Drawing.Point(97, 15)
        Me.cboRecFrom.Name = "cboRecFrom"
        Me.cboRecFrom.Size = New System.Drawing.Size(202, 21)
        Me.cboRecFrom.Sorted = True
        Me.cboRecFrom.TabIndex = 17
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Received From:"
        '
        'txt_net_poc
        '
        Me.txt_net_poc.Location = New System.Drawing.Point(174, 67)
        Me.txt_net_poc.Name = "txt_net_poc"
        Me.txt_net_poc.Size = New System.Drawing.Size(100, 20)
        Me.txt_net_poc.TabIndex = 262
        Me.txt_net_poc.Text = "0.00"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.cbopaystatus)
        Me.GroupBox3.Controls.Add(Me.txtApplied)
        Me.GroupBox3.Controls.Add(Me.txtAmtDue)
        Me.GroupBox3.Controls.Add(Me.lbltimer)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(356, 30)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(279, 99)
        Me.GroupBox3.TabIndex = 251
        Me.GroupBox3.TabStop = False
        '
        'cbopaystatus
        '
        Me.cbopaystatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cbopaystatus.BackColor = System.Drawing.Color.White
        Me.cbopaystatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbopaystatus.ForeColor = System.Drawing.Color.Black
        Me.cbopaystatus.FormattingEnabled = True
        Me.cbopaystatus.Items.AddRange(New Object() {"Part Payment", "Paid"})
        Me.cbopaystatus.Location = New System.Drawing.Point(106, 65)
        Me.cbopaystatus.Name = "cbopaystatus"
        Me.cbopaystatus.Size = New System.Drawing.Size(162, 21)
        Me.cbopaystatus.TabIndex = 232
        '
        'txtApplied
        '
        Me.txtApplied.BackColor = System.Drawing.Color.White
        Me.txtApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtApplied.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApplied.ForeColor = System.Drawing.Color.Black
        Me.txtApplied.Location = New System.Drawing.Point(168, 41)
        Me.txtApplied.Name = "txtApplied"
        Me.txtApplied.ReadOnly = True
        Me.txtApplied.Size = New System.Drawing.Size(100, 20)
        Me.txtApplied.TabIndex = 172
        Me.txtApplied.Text = "0.00"
        Me.txtApplied.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAmtDue
        '
        Me.txtAmtDue.BackColor = System.Drawing.Color.White
        Me.txtAmtDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmtDue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmtDue.ForeColor = System.Drawing.Color.Black
        Me.txtAmtDue.Location = New System.Drawing.Point(168, 15)
        Me.txtAmtDue.Name = "txtAmtDue"
        Me.txtAmtDue.ReadOnly = True
        Me.txtAmtDue.Size = New System.Drawing.Size(100, 20)
        Me.txtAmtDue.TabIndex = 161
        Me.txtAmtDue.Text = "0.00"
        Me.txtAmtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbltimer
        '
        Me.lbltimer.AutoSize = True
        Me.lbltimer.Location = New System.Drawing.Point(16, 24)
        Me.lbltimer.Name = "lbltimer"
        Me.lbltimer.Size = New System.Drawing.Size(49, 13)
        Me.lbltimer.TabIndex = 235
        Me.lbltimer.Text = "00:00:00"
        Me.lbltimer.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "Payment Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 43)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 13)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "Applied:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(93, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Balance Due:"
        '
        'cbocashonhand
        '
        Me.cbocashonhand.FormattingEnabled = True
        Me.cbocashonhand.Location = New System.Drawing.Point(441, 73)
        Me.cbocashonhand.Name = "cbocashonhand"
        Me.cbocashonhand.Size = New System.Drawing.Size(162, 21)
        Me.cbocashonhand.TabIndex = 257
        '
        'PnlPOview
        '
        Me.PnlPOview.Controls.Add(Me.rbomem)
        Me.PnlPOview.Controls.Add(Me.rbogen)
        Me.PnlPOview.Controls.Add(Me.Label1)
        Me.PnlPOview.Controls.Add(Me.Label12)
        Me.PnlPOview.Controls.Add(Me.GroupBox1)
        Me.PnlPOview.Controls.Add(Me.GroupBox2)
        Me.PnlPOview.Controls.Add(Me.mMemo)
        Me.PnlPOview.Controls.Add(Me.cboAR)
        Me.PnlPOview.Controls.Add(Me.GroupBox4)
        Me.PnlPOview.Controls.Add(Me.GroupBox3)
        Me.PnlPOview.Location = New System.Drawing.Point(0, 28)
        Me.PnlPOview.Name = "PnlPOview"
        Me.PnlPOview.Size = New System.Drawing.Size(642, 394)
        Me.PnlPOview.TabIndex = 270
        Me.PnlPOview.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Bodoni MT", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(273, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 19)
        Me.Label1.TabIndex = 263
        Me.Label1.Text = "Client Payment"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 328)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Brief memo"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvRecPay)
        Me.GroupBox2.Controls.Add(Me.lblcrerev)
        Me.GroupBox2.Controls.Add(Me.lbldebrev)
        Me.GroupBox2.Controls.Add(Me.txt_net_poc)
        Me.GroupBox2.Controls.Add(Me.cbo_re_cy)
        Me.GroupBox2.Controls.Add(Me.cbo_ret_py)
        Me.GroupBox2.Controls.Add(Me.lblZeros)
        Me.GroupBox2.Controls.Add(Me.txtupay)
        Me.GroupBox2.Controls.Add(Me.txtpartpay)
        Me.GroupBox2.Controls.Add(Me.lblRec)
        Me.GroupBox2.Controls.Add(Me.txtbank)
        Me.GroupBox2.Controls.Add(Me.txtrecid)
        Me.GroupBox2.Controls.Add(Me.lblyear)
        Me.GroupBox2.Controls.Add(Me.lblReceived)
        Me.GroupBox2.Controls.Add(Me.txtcheckbnk)
        Me.GroupBox2.Controls.Add(Me.txtAcNum)
        Me.GroupBox2.Controls.Add(Me.cbocashonhand)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 184)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(625, 138)
        Me.GroupBox2.TabIndex = 250
        Me.GroupBox2.TabStop = False
        '
        'cbo_ret_py
        '
        Me.cbo_ret_py.FormattingEnabled = True
        Me.cbo_ret_py.Location = New System.Drawing.Point(23, 34)
        Me.cbo_ret_py.Name = "cbo_ret_py"
        Me.cbo_ret_py.Size = New System.Drawing.Size(150, 21)
        Me.cbo_ret_py.TabIndex = 263
        '
        'lblZeros
        '
        Me.lblZeros.AutoSize = True
        Me.lblZeros.Location = New System.Drawing.Point(234, 103)
        Me.lblZeros.Name = "lblZeros"
        Me.lblZeros.Size = New System.Drawing.Size(28, 13)
        Me.lblZeros.TabIndex = 228
        Me.lblZeros.Text = "0.00"
        '
        'txtupay
        '
        Me.txtupay.Location = New System.Drawing.Point(254, 34)
        Me.txtupay.Name = "txtupay"
        Me.txtupay.Size = New System.Drawing.Size(100, 20)
        Me.txtupay.TabIndex = 237
        Me.txtupay.Text = "Unpaid"
        Me.txtupay.Visible = False
        '
        'txtpartpay
        '
        Me.txtpartpay.Location = New System.Drawing.Point(23, 95)
        Me.txtpartpay.Name = "txtpartpay"
        Me.txtpartpay.Size = New System.Drawing.Size(100, 20)
        Me.txtpartpay.TabIndex = 238
        Me.txtpartpay.Text = "Part Payment"
        Me.txtpartpay.Visible = False
        '
        'lblRec
        '
        Me.lblRec.AutoSize = True
        Me.lblRec.Location = New System.Drawing.Point(365, 34)
        Me.lblRec.Name = "lblRec"
        Me.lblRec.Size = New System.Drawing.Size(45, 13)
        Me.lblRec.TabIndex = 269
        Me.lblRec.Text = "RecPay"
        Me.lblRec.Visible = False
        '
        'txtbank
        '
        Me.txtbank.Location = New System.Drawing.Point(105, 42)
        Me.txtbank.Name = "txtbank"
        Me.txtbank.Size = New System.Drawing.Size(100, 20)
        Me.txtbank.TabIndex = 270
        '
        'txtrecid
        '
        Me.txtrecid.Location = New System.Drawing.Point(452, 34)
        Me.txtrecid.Name = "txtrecid"
        Me.txtrecid.Size = New System.Drawing.Size(100, 20)
        Me.txtrecid.TabIndex = 228
        '
        'lblyear
        '
        Me.lblyear.AutoSize = True
        Me.lblyear.Location = New System.Drawing.Point(514, 54)
        Me.lblyear.Name = "lblyear"
        Me.lblyear.Size = New System.Drawing.Size(39, 13)
        Me.lblyear.TabIndex = 262
        Me.lblyear.Text = "Label8"
        '
        'lblReceived
        '
        Me.lblReceived.AutoSize = True
        Me.lblReceived.Location = New System.Drawing.Point(479, 97)
        Me.lblReceived.Name = "lblReceived"
        Me.lblReceived.Size = New System.Drawing.Size(100, 13)
        Me.lblReceived.TabIndex = 268
        Me.lblReceived.Text = "Payment Received "
        Me.lblReceived.Visible = False
        '
        'txtcheckbnk
        '
        Me.txtcheckbnk.Location = New System.Drawing.Point(334, 97)
        Me.txtcheckbnk.Name = "txtcheckbnk"
        Me.txtcheckbnk.Size = New System.Drawing.Size(116, 20)
        Me.txtcheckbnk.TabIndex = 270
        '
        'txtAcNum
        '
        Me.txtAcNum.Location = New System.Drawing.Point(279, 68)
        Me.txtAcNum.Name = "txtAcNum"
        Me.txtAcNum.Size = New System.Drawing.Size(116, 20)
        Me.txtAcNum.TabIndex = 271
        '
        'mMemo
        '
        Me.mMemo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.mMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mMemo.Location = New System.Drawing.Point(11, 351)
        Me.mMemo.Name = "mMemo"
        Me.mMemo.Size = New System.Drawing.Size(268, 20)
        Me.mMemo.TabIndex = 253
        '
        'cboAR
        '
        Me.cboAR.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAR.FormattingEnabled = True
        Me.cboAR.Location = New System.Drawing.Point(293, 351)
        Me.cboAR.Name = "cboAR"
        Me.cboAR.Size = New System.Drawing.Size(121, 21)
        Me.cboAR.TabIndex = 256
        Me.cboAR.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.txtBal)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Location = New System.Drawing.Point(454, 328)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 53)
        Me.GroupBox4.TabIndex = 254
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Underpayment:"
        '
        'txtBal
        '
        Me.txtBal.BackColor = System.Drawing.Color.White
        Me.txtBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBal.ForeColor = System.Drawing.Color.Black
        Me.txtBal.Location = New System.Drawing.Point(65, 19)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.ReadOnly = True
        Me.txtBal.Size = New System.Drawing.Size(100, 20)
        Me.txtBal.TabIndex = 162
        Me.txtBal.Text = "0.00"
        Me.txtBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Amount:"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btncancel
        '
        Me.btncancel.Image = Global.Tophigh_Inventory.My.Resources.Resources.cancel_32x32
        Me.btncancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(63, 22)
        Me.btncancel.Text = "Cancel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'Time_Timer
        '
        '
        'lblpaid
        '
        Me.lblpaid.AutoSize = True
        Me.lblpaid.Location = New System.Drawing.Point(425, 191)
        Me.lblpaid.Name = "lblpaid"
        Me.lblpaid.Size = New System.Drawing.Size(28, 13)
        Me.lblpaid.TabIndex = 267
        Me.lblpaid.Text = "Paid"
        Me.lblpaid.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator1, Me.btnpayment, Me.ToolStripSeparator2, Me.btncancel, Me.ToolStripSeparator3, Me.btnPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(652, 25)
        Me.ToolStrip1.TabIndex = 265
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnpayment
        '
        Me.btnpayment.Image = CType(resources.GetObject("btnpayment.Image"), System.Drawing.Image)
        Me.btnpayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnpayment.Name = "btnpayment"
        Me.btnpayment.Size = New System.Drawing.Size(117, 22)
        Me.btnpayment.Text = "Receive Payment"
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.Tophigh_Inventory.My.Resources.Resources.print_32x32
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(109, 22)
        Me.btnPrint.Text = "Print Statement"
        '
        'lblopen
        '
        Me.lblopen.AutoSize = True
        Me.lblopen.Location = New System.Drawing.Point(353, 191)
        Me.lblopen.Name = "lblopen"
        Me.lblopen.Size = New System.Drawing.Size(33, 13)
        Me.lblopen.TabIndex = 266
        Me.lblopen.Text = "Close"
        Me.lblopen.Visible = False
        '
        'rbogen
        '
        Me.rbogen.AutoSize = True
        Me.rbogen.Checked = True
        Me.rbogen.Location = New System.Drawing.Point(375, 143)
        Me.rbogen.Name = "rbogen"
        Me.rbogen.Size = New System.Drawing.Size(62, 17)
        Me.rbogen.TabIndex = 265
        Me.rbogen.TabStop = True
        Me.rbogen.Text = "General"
        Me.rbogen.UseVisualStyleBackColor = True
        '
        'rbomem
        '
        Me.rbomem.AutoSize = True
        Me.rbomem.Location = New System.Drawing.Point(448, 143)
        Me.rbomem.Name = "rbomem"
        Me.rbomem.Size = New System.Drawing.Size(68, 17)
        Me.rbomem.TabIndex = 266
        Me.rbomem.TabStop = True
        Me.rbomem.Text = "Members"
        Me.rbomem.UseVisualStyleBackColor = True
        '
        'ReceiveBillForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(652, 423)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PnlPOview)
        Me.Controls.Add(Me.lblpaid)
        Me.Controls.Add(Me.lblopen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "ReceiveBillForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Receive Bill"
        CType(Me.dgvRecPay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PnlPOview.ResumeLayout(False)
        Me.PnlPOview.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvRecPay As DataGridView
    Friend WithEvents lblcrerev As Label
    Friend WithEvents lbldebrev As Label
    Friend WithEvents cbo_re_cy As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents mRecRef As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents mRecDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents mRecAmount As TextBox
    Friend WithEvents cboRecFrom As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txt_net_poc As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cbopaystatus As ComboBox
    Friend WithEvents txtApplied As TextBox
    Friend WithEvents txtAmtDue As TextBox
    Friend WithEvents lbltimer As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents cbocashonhand As ComboBox
    Friend WithEvents PnlPOview As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cbo_ret_py As ComboBox
    Friend WithEvents lblZeros As Label
    Friend WithEvents txtupay As TextBox
    Friend WithEvents txtpartpay As TextBox
    Friend WithEvents txtrecid As TextBox
    Friend WithEvents lblyear As Label
    Friend WithEvents mMemo As TextBox
    Friend WithEvents cboAR As ComboBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txtBal As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents btncancel As ToolStripButton
    Friend WithEvents btnpayment As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents Time_Timer As Timer
    Friend WithEvents lblRec As Label
    Friend WithEvents lblReceived As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblpaid As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents lblopen As Label
    Friend WithEvents txtcheckbnk As TextBox
    Friend WithEvents txtAcNum As TextBox
    Friend WithEvents txtbank As TextBox
    Friend WithEvents cboPay As ComboBox
    Friend WithEvents rbomem As RadioButton
    Friend WithEvents rbogen As RadioButton
End Class

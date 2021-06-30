<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReceiptForm
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
        Me.lblmonth = New System.Windows.Forms.Label()
        Me.EstimatePrintDocument = New System.Drawing.Printing.PrintDocument()
        Me.chkVisa = New System.Windows.Forms.CheckBox()
        Me.lblyears = New System.Windows.Forms.Label()
        Me.PnlPOview = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkFullPay = New System.Windows.Forms.CheckBox()
        Me.chkPartPay = New System.Windows.Forms.CheckBox()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.chkCheque = New System.Windows.Forms.CheckBox()
        Me.chkCash = New System.Windows.Forms.CheckBox()
        Me.txtDetials = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRecFrom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblzeros = New System.Windows.Forms.Label()
        Me.EstimatePrintDialog = New System.Windows.Forms.PrintDialog()
        Me.Time_Timer = New System.Windows.Forms.Timer(Me.components)
        Me.PnlPOview.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblmonth
        '
        Me.lblmonth.AutoSize = True
        Me.lblmonth.Location = New System.Drawing.Point(419, 323)
        Me.lblmonth.Name = "lblmonth"
        Me.lblmonth.Size = New System.Drawing.Size(45, 13)
        Me.lblmonth.TabIndex = 17
        Me.lblmonth.Text = "Label10"
        '
        'EstimatePrintDocument
        '
        '
        'chkVisa
        '
        Me.chkVisa.AutoSize = True
        Me.chkVisa.Location = New System.Drawing.Point(166, 197)
        Me.chkVisa.Name = "chkVisa"
        Me.chkVisa.Size = New System.Drawing.Size(71, 17)
        Me.chkVisa.TabIndex = 22
        Me.chkVisa.Text = "Visa Card"
        Me.chkVisa.UseVisualStyleBackColor = True
        '
        'lblyears
        '
        Me.lblyears.AutoSize = True
        Me.lblyears.Location = New System.Drawing.Point(402, 323)
        Me.lblyears.Name = "lblyears"
        Me.lblyears.Size = New System.Drawing.Size(45, 13)
        Me.lblyears.TabIndex = 16
        Me.lblyears.Text = "Label10"
        '
        'PnlPOview
        '
        Me.PnlPOview.Controls.Add(Me.chkVisa)
        Me.PnlPOview.Controls.Add(Me.PictureBox1)
        Me.PnlPOview.Controls.Add(Me.Label9)
        Me.PnlPOview.Controls.Add(Me.Label8)
        Me.PnlPOview.Controls.Add(Me.Label7)
        Me.PnlPOview.Controls.Add(Me.txtAmount)
        Me.PnlPOview.Controls.Add(Me.Label6)
        Me.PnlPOview.Controls.Add(Me.txtBal)
        Me.PnlPOview.Controls.Add(Me.Label4)
        Me.PnlPOview.Controls.Add(Me.chkFullPay)
        Me.PnlPOview.Controls.Add(Me.chkPartPay)
        Me.PnlPOview.Controls.Add(Me.txtCheque)
        Me.PnlPOview.Controls.Add(Me.chkCheque)
        Me.PnlPOview.Controls.Add(Me.chkCash)
        Me.PnlPOview.Controls.Add(Me.txtDetials)
        Me.PnlPOview.Controls.Add(Me.Label5)
        Me.PnlPOview.Controls.Add(Me.txtRecFrom)
        Me.PnlPOview.Controls.Add(Me.Label3)
        Me.PnlPOview.Controls.Add(Me.txtDate)
        Me.PnlPOview.Controls.Add(Me.Label2)
        Me.PnlPOview.Controls.Add(Me.txtNo)
        Me.PnlPOview.Controls.Add(Me.Label1)
        Me.PnlPOview.Location = New System.Drawing.Point(12, 12)
        Me.PnlPOview.Name = "PnlPOview"
        Me.PnlPOview.Size = New System.Drawing.Size(479, 300)
        Me.PnlPOview.TabIndex = 12
        Me.PnlPOview.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(19, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(176, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(145, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Payment Receipt"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(327, 268)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(133, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = ".........................................."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 265)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Sign :"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.White
        Me.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(102, 266)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.ReadOnly = True
        Me.txtAmount.Size = New System.Drawing.Size(123, 20)
        Me.txtAmount.TabIndex = 17
        Me.txtAmount.Text = "0.00"
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(27, 268)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Amount paid:"
        '
        'txtBal
        '
        Me.txtBal.BackColor = System.Drawing.Color.White
        Me.txtBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBal.Location = New System.Drawing.Point(338, 220)
        Me.txtBal.Name = "txtBal"
        Me.txtBal.ReadOnly = True
        Me.txtBal.Size = New System.Drawing.Size(121, 20)
        Me.txtBal.TabIndex = 15
        Me.txtBal.Text = "0.00"
        Me.txtBal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 224)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Balance:"
        '
        'chkFullPay
        '
        Me.chkFullPay.AutoSize = True
        Me.chkFullPay.Location = New System.Drawing.Point(26, 243)
        Me.chkFullPay.Name = "chkFullPay"
        Me.chkFullPay.Size = New System.Drawing.Size(86, 17)
        Me.chkFullPay.TabIndex = 13
        Me.chkFullPay.Text = "Full Payment"
        Me.chkFullPay.UseVisualStyleBackColor = True
        '
        'chkPartPay
        '
        Me.chkPartPay.AutoSize = True
        Me.chkPartPay.Location = New System.Drawing.Point(26, 220)
        Me.chkPartPay.Name = "chkPartPay"
        Me.chkPartPay.Size = New System.Drawing.Size(89, 17)
        Me.chkPartPay.TabIndex = 12
        Me.chkPartPay.Text = "Part Payment"
        Me.chkPartPay.UseVisualStyleBackColor = True
        '
        'txtCheque
        '
        Me.txtCheque.BackColor = System.Drawing.Color.White
        Me.txtCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheque.Location = New System.Drawing.Point(243, 194)
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.ReadOnly = True
        Me.txtCheque.Size = New System.Drawing.Size(216, 20)
        Me.txtCheque.TabIndex = 11
        '
        'chkCheque
        '
        Me.chkCheque.AutoSize = True
        Me.chkCheque.Location = New System.Drawing.Point(82, 197)
        Me.chkCheque.Name = "chkCheque"
        Me.chkCheque.Size = New System.Drawing.Size(83, 17)
        Me.chkCheque.TabIndex = 10
        Me.chkCheque.Text = "Cheque No."
        Me.chkCheque.UseVisualStyleBackColor = True
        '
        'chkCash
        '
        Me.chkCash.AutoSize = True
        Me.chkCash.Location = New System.Drawing.Point(26, 197)
        Me.chkCash.Name = "chkCash"
        Me.chkCash.Size = New System.Drawing.Size(50, 17)
        Me.chkCash.TabIndex = 9
        Me.chkCash.Text = "Cash"
        Me.chkCash.UseVisualStyleBackColor = True
        '
        'txtDetials
        '
        Me.txtDetials.BackColor = System.Drawing.Color.White
        Me.txtDetials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDetials.Location = New System.Drawing.Point(122, 143)
        Me.txtDetials.Multiline = True
        Me.txtDetials.Name = "txtDetials"
        Me.txtDetials.ReadOnly = True
        Me.txtDetials.Size = New System.Drawing.Size(337, 45)
        Me.txtDetials.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 146)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Being Payment for"
        '
        'txtRecFrom
        '
        Me.txtRecFrom.BackColor = System.Drawing.Color.White
        Me.txtRecFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRecFrom.Location = New System.Drawing.Point(108, 117)
        Me.txtRecFrom.Name = "txtRecFrom"
        Me.txtRecFrom.ReadOnly = True
        Me.txtRecFrom.Size = New System.Drawing.Size(351, 20)
        Me.txtRecFrom.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Received From :"
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.Color.White
        Me.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDate.Location = New System.Drawing.Point(338, 91)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(121, 20)
        Me.txtDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date:"
        '
        'txtNo
        '
        Me.txtNo.BackColor = System.Drawing.Color.White
        Me.txtNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNo.Location = New System.Drawing.Point(108, 89)
        Me.txtNo.Name = "txtNo"
        Me.txtNo.ReadOnly = True
        Me.txtNo.Size = New System.Drawing.Size(117, 20)
        Me.txtNo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No."
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Location = New System.Drawing.Point(402, 323)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(45, 13)
        Me.lbltime.TabIndex = 15
        Me.lbltime.Text = "Label10"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(368, 318)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(123, 23)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblzeros
        '
        Me.lblzeros.AutoSize = True
        Me.lblzeros.Location = New System.Drawing.Point(419, 323)
        Me.lblzeros.Name = "lblzeros"
        Me.lblzeros.Size = New System.Drawing.Size(28, 13)
        Me.lblzeros.TabIndex = 14
        Me.lblzeros.Text = "0.00"
        '
        'EstimatePrintDialog
        '
        Me.EstimatePrintDialog.UseEXDialog = True
        '
        'Time_Timer
        '
        '
        'ReceiptForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 347)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblmonth)
        Me.Controls.Add(Me.lblyears)
        Me.Controls.Add(Me.PnlPOview)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lblzeros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ReceiptForm"
        Me.Text = "Receipt"
        Me.PnlPOview.ResumeLayout(False)
        Me.PnlPOview.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblmonth As Label
    Friend WithEvents EstimatePrintDocument As Printing.PrintDocument
    Friend WithEvents chkVisa As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblyears As Label
    Friend WithEvents PnlPOview As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkFullPay As CheckBox
    Friend WithEvents chkPartPay As CheckBox
    Friend WithEvents txtCheque As TextBox
    Friend WithEvents chkCheque As CheckBox
    Friend WithEvents chkCash As CheckBox
    Friend WithEvents txtDetials As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRecFrom As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDate As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lbltime As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblzeros As Label
    Friend WithEvents EstimatePrintDialog As PrintDialog
    Friend WithEvents Time_Timer As Timer
End Class

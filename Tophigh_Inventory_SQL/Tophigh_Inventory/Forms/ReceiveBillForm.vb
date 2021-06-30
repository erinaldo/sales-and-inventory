Public Class ReceiveBillForm

    Dim csal As New InvoiceClass

    Private Sub ReceiveBillForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            csal.FillgenName()
            csal.FillOnHand()
            csal.GetAccount()
            csal.FillAR()
            csal.LoadRecBills()

            mRecDate.Format = DateTimePickerFormat.Custom
            mRecDate.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvRecPay_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecPay.CellClick
        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecPay.CellLeave
        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_RowPostPaint(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles dgvRecPay.RowPostPaint
        Try

            Using b As SolidBrush = New SolidBrush(dgvRecPay.RowHeadersDefaultCellStyle.ForeColor)
                e.Graphics.DrawString(e.RowIndex.ToString(System.Globalization.CultureInfo.CurrentUICulture),
                                       dgvRecPay.DefaultCellStyle.Font,
                                       b,
                                       e.RowBounds.Location.X + 20,
                                       e.RowBounds.Location.Y + 4)
            End Using

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboRecFrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboRecFrom.TextChanged
        Try
            csal.LoadRecBills()
            If rbogen.Checked = True Then
                csal.GetGenID()
            Else
                csal.GetID()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnpayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpayment.Click

        Try
            mRecDate.Format = DateTimePickerFormat.Custom
            mRecDate.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try
        Try
            If cboRecFrom.Text = "" Then
                MessageBox.Show("Select a customer")
                cboRecFrom.Focus()
                Exit Sub
            End If

            If cbopaystatus.Text = "" Then
                MessageBox.Show("Select payment status")
                cbopaystatus.Focus()
                Exit Sub
            End If

            If cboPay.Text = "" = True Then
                MessageBox.Show("Select payment method")
                cboPay.Focus()
                Exit Sub
            End If


            If cboPay.Text = "Check" = True Then
                If mRecRef.Text = "" Then
                    MessageBox.Show("Type in check number")
                    mRecRef.Focus()
                    Exit Sub
                End If
            End If

            If cboPay.Text = "Visa Card" = True Then
                If mRecRef.Text = "" Then
                    MessageBox.Show("Type in card number")
                    mRecRef.Focus()
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try

        Try

            ReceiptForm.txtRecFrom.Text = cboRecFrom.Text

            ReceiptForm.txtAmount.Text = mRecAmount.Text

            ReceiptForm.txtDetials.Text = mMemo.Text

            ReceiptForm.txtDate.Text = mRecDate.Text

            ReceiptForm.txtBal.Text = txtAmtDue.Text

            If cboPay.Text = "Check" Then

                ReceiptForm.chkCheque.Checked = True

                ReceiptForm.txtCheque.Text = mRecRef.Text

            ElseIf cboPay.Text = "Cash" Then

                ReceiptForm.chkCash.Checked = True

            Else

                ReceiptForm.chkVisa.Checked = True

                ReceiptForm.txtCheque.Text = mRecRef.Text

            End If

            If cbopaystatus.Text = "Part Payment" Then

                ReceiptForm.chkPartPay.Checked = True

            Else

                ReceiptForm.chkFullPay.Checked = True

            End If

        Catch ex As Exception

        End Try

        If txtcheckbnk.Text = "Bank" = True Then
            csal.InsertBank()
        End If

        Try
            csal.UpdateBills()
        Catch ex As Exception

        End Try

        ReceiptForm.ShowDialog()

        ClearRecpay()

    End Sub

    Private Sub Time_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time_Timer.Tick
        Try
            lbltimer.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub


    Private Sub mRecAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mRecAmount.TextChanged
        Try
            mRecAmount.Text = Format(mRecAmount.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecPay.CellEndEdit

        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtAmtDue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmtDue.TextChanged
        Try
            txtAmtDue.Text = Format(txtAmtDue.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtApplied_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApplied.TextChanged
        Try
            txtApplied.Text = Format(txtApplied.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBal.TextChanged
        Try
            txtBal.Text = Format(txtBal.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ClearRecpay()
        Try
            cboRecFrom.Text = ""
            cbopaystatus.Text = ""
            cboPay.Text = ""
            txtAmtDue.Text = "0.00"
            txtAmtDue.Text = "0.00"
            txtBal.Text = "0.00"
            txtrecid.Text = ""
            mMemo.Clear()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            ClearRecpay()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            If cboRecFrom.Text = "" Then
                MsgBox("Select Customer name")
                cboRecFrom.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        Try
            If txtrecid.Text = "" Then
                MsgBox("Please select customer name")
                cboRecFrom.Focus()
                Exit Sub
            Else
                CustomerStatementForm.txtCust.Text = cboRecFrom.Text
                CustomerStatementForm.txtNum.Text = txtrecid.Text
            End If
        Catch ex As Exception

        End Try

        CustomerStatementForm.Show()
        CustomerStatementForm.MdiParent = MainForm
        CustomerStatementForm.BringToFront()

    End Sub

    Private Sub cbocashonhand_TextChanged(sender As Object, e As EventArgs) Handles cbocashonhand.TextChanged
        Try
            txtbank.Text = ""
            txtAcNum.Text = ""
            txtcheckbnk.Text = ""
            csal.GetBank()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcheckbnk_TextChanged(sender As Object, e As EventArgs) Handles txtcheckbnk.TextChanged
        Try
            If txtcheckbnk.Text = "Bank" = True Then
                csal.bankNumAcc()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboPayMeth_TextChanged(sender As Object, e As EventArgs) Handles cboPay.TextChanged
        Try
            cbocashonhand.Text = cboPay.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecPay.CellEnter
        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_Click(sender As Object, e As EventArgs) Handles dgvRecPay.Click
        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecPay_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvRecPay.CellBeginEdit
        Try

            dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")
            dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            mRecAmount.Text = csal.TotalAmt

            txtApplied.Text = csal.TotalAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvRecPay.Rows.Count - 1

                txtAmtDue.Text = csal.TotalAmtDue - csal.TotalAmt

                txtBal.Text = csal.TotalAmtDue - csal.TotalAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbogen_CheckedChanged(sender As Object, e As EventArgs) Handles rbogen.CheckedChanged
        Try
            cboRecFrom.Text = ""
            csal.FillgenName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbomem_CheckedChanged(sender As Object, e As EventArgs) Handles rbomem.CheckedChanged
        Try
            cboRecFrom.Text = ""
            csal.FillCustName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboRecFrom_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRecFrom.SelectedIndexChanged
        Try
            csal.LoadRecBills()
            If rbogen.Checked = True Then
                csal.GetGenID()
            Else
                csal.GetID()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
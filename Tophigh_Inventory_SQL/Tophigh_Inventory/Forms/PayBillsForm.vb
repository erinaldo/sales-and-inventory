Public Class PayBillsForm

    Dim spb As New SuppliersClass

    Private Sub PayBillsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            spb.LoadPayBills()
            spb.GetAccount()
            spb.FillAPs()
            spb.FillSup()

            DueBeforeDate.Format = DateTimePickerFormat.Custom
            DueBeforeDate.CustomFormat = "yyyy-MM-dd"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboventname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboventname.TextChanged
        Try
            spb.Getpayventid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtID.TextChanged
        Try
            spb.LoadPayBills()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboFilter_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter.TextChanged
        Try
            spb.Getpaycusttid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPayBill_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayBill.CellClick
        Try

            dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

            lbltotal.Text = spb.TotalPayAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvPayBill.Rows.Count - 1

                lblAmtDue.Text = spb.TotalPayAmtDue - spb.TotalPayAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPayBill_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayBill.CellEndEdit
        Try

            dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

            lbltotal.Text = spb.TotalPayAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvPayBill.Rows.Count - 1

                lblAmtDue.Text = spb.TotalPayAmtDue - spb.TotalPayAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPayBill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPayBill.Click
        Try

            dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

            lbltotal.Text = spb.TotalPayAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvPayBill.Rows.Count - 1

                lblAmtDue.Text = spb.TotalPayAmtDue - spb.TotalPayAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPayBill_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvPayBill.Leave
        Try

            dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

            lbltotal.Text = spb.TotalPayAmt

        Catch ex As Exception

        End Try

        Try

            Dim i As Integer = 0

            For i = 0 To dgvPayBill.Rows.Count - 1

                lblAmtDue.Text = spb.TotalPayAmtDue - spb.TotalPayAmt

            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblAmtDue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAmtDue.TextChanged
        Try
            lblAmtDue.Text = Format(lblAmtDue.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbltotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltotal.TextChanged
        Try
            lbltotal.Text = Format(lbltotal.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mBal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mBal.TextChanged
        Try
            mBal.Text = Format(mBal.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAccount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccount.TextChanged
        Try
            spb.bankNumAcc()
            spb.GetBank()
            mBal.Text = 0
            spb.GetSum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnpay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpay.Click
        Try
            PayDate.Format = DateTimePickerFormat.Custom
            PayDate.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try

        Try
            If cboAccount.Text = "" Then
                MsgBox("Please select account pay from")
                cboAccount.Focus()
                Exit Sub
            End If

            If cbopaystat.Text = "" Then
                MsgBox("Please select payment status")
                cbopaystat.Focus()
                Exit Sub
            End If

            If cboMethod.Text = "" Then
                MsgBox("Please select payment method")
                cboMethod.Focus()
                Exit Sub
            End If

            If mMemo.Text = "" Then
                MsgBox("Please enter a brief memo")
                mMemo.Focus()
                Exit Sub
            End If

        Catch ex As Exception

        End Try

        If txtcheckbank.Text = "bank" = True Then
            spb.InsertBank()
        End If

        Try
            spb.UpdateAPBills()
            spb.CheckStoreStock()
            spb.CheckWarehStock()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Time_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Time_Timer.Tick
        Try
            lbltimer.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub

    Public Sub clearme()
        Try
            cboFilter.Text = ""
            cboventname.Text = ""
            cboMethod.Text = ""
            cboAccount.Text = ""
            cbopaystat.Text = ""
            mBal.Text = 0
            mCheck.Text = ""
            mMemo.Text = ""
            txtID.Text = ""
            lblAmtDue.Text = 0
            lbltotal.Text = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Try
            clearme()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            If cboventname.Text = "" Then
                MsgBox("Select Supplier name")
                cboventname.Focus()
                Exit Sub
            End If

        Catch ex As Exception

        End Try

        Try

            SuppliersStatementForm.txtCust.Text = cboventname.Text
            SuppliersStatementForm.txtNum.Text = txtID.Text

        Catch ex As Exception

        End Try


        SuppliersStatementForm.Show()
        SuppliersStatementForm.MdiParent = MainForm
        SuppliersStatementForm.BringToFront()

    End Sub

    Private Sub cboAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccount.SelectedIndexChanged

    End Sub

    Private Sub txtcheckbank_TextChanged(sender As Object, e As EventArgs) Handles txtcheckbank.TextChanged

    End Sub

    Private Sub DgvPayBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPayBill.CellContentClick

    End Sub

    Private Sub cboventname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboventname.SelectedIndexChanged

    End Sub
End Class
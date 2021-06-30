Public Class SearchCustomerStatementForm

    Dim csal As New InvoiceClass

    Private Sub SearchCustomerStatementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            csal.FillCustName()
            csal.CompInfo()
            csal.Getlocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        Try
            If cboCust.Text = "" Then
                MsgBox("Please select a customer")
                cboCust.Focus()
                Exit Sub
            End If
        Catch ex As Exception

        End Try
        Try
            txtCust.Text = cboCust.Text
            txtNum.Text = txtid.Text
        Catch ex As Exception

        End Try
        Try
            txtCust.Text = cboCust.Text
            csal.GetSchStateCustInfo()
            csal.GetBalance()
            csal.GetSearchCustStatement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCust_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust.TextChanged
        Try
            csal.GetSchSearchCustID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchCustomerStatementForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAmtDue_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAmtDue.TextChanged
        Try
            txtAmtDue.Text = Format(txtAmtDue.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged
        Try
            csal.GetSchStateCustInfo()
        Catch ex As Exception

        End Try
    End Sub

End Class
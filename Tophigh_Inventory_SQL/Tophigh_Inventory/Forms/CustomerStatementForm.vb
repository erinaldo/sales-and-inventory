Public Class CustomerStatementForm

    Dim csal As New InvoiceClass

    Private Sub CustomerStatementForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            csal.FillgenName()
            csal.CompInfo()
            csal.GetStateCustInfo()
            csal.GetBalance()
            csal.CustStatement()

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
            csal.SearchCustStatement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCust_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust.TextChanged
        Try
            If rbomem.Checked = True Then
                csal.GetSearchCustID()
            Else
                csal.GetGenSearchCustID()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CustomerStatementForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
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
            If rbomem.Checked = True Then
                csal.GetStateCustInfo()
            Else
                csal.GetGenStateCustInfo()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCust.SelectedIndexChanged
        Try
            If rbomem.Checked = True Then
                csal.GetSearchCustID()
            Else
                csal.GetGenSearchCustID()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbogen_CheckedChanged(sender As Object, e As EventArgs) Handles rbogen.CheckedChanged
        Try
            If rbogen.Checked = True Then
                txtNum.Text = ""
                csal.FillgenName()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbomem_CheckedChanged(sender As Object, e As EventArgs) Handles rbomem.CheckedChanged
        Try
            If rbomem.Checked = True Then
                txtNum.Text = ""
                csal.FillCustName()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
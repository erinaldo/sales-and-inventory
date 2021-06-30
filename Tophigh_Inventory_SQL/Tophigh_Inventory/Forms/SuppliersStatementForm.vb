Public Class SuppliersStatementForm

    Dim spb As New SuppliersClass

    Private Sub SuppliersStatementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            spb.FillSup()
            spb.CompInfo()
            spb.DebCustStatement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
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
            dtSearch.Format = DateTimePickerFormat.Custom
            dtSearch.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try
        Try
            spb.SearchDebCustStatement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCust_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCust.TextChanged
        Try
            txtCust.Text = cboCust.Text
            spb.GetCustID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SuppliersStatementForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNum_TextChanged(sender As Object, e As EventArgs) Handles txtNum.TextChanged
        Try
            spb.GetCustdebInfo()
        Catch ex As Exception

        End Try
    End Sub

End Class

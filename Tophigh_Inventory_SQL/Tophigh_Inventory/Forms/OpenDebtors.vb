Public Class OpenDebtors

    Dim csal As New InvoiceClass

    Private Sub OpenDebtors_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            csal.OpenDebtorsList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            csal.OpenDebtorsList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenDebtors_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
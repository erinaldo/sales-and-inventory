Public Class BankSetupForm

    Dim bnk As New BankClass

    Private Sub BankSetupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            bnk.FillSaleNo()
            bnk.Getslocation()
            bnk.Getequity()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnaddacc_Click(sender As Object, e As EventArgs) Handles btnaddacc.Click
        Try

            dtDate.Format = DateTimePickerFormat.Custom
            dtDate.CustomFormat = "yyyy-MM-dd"

            bnk.InsertChart()
            bnk.InsertBank()
            bnk.InsertjvBank()
            bnk.InsertEquity()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Try
            bnk.clearData()
        Catch ex As Exception

        End Try
    End Sub
End Class
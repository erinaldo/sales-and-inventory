Public Class SalesbyCustomer

    Dim csal As New CashSalesClass

    Private Sub SalesbyCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            csal.CompInfo()
            csal.GetSalesbyCust()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesbyCustomer_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            csal.GetSalesbyCust()
        Catch ex As Exception

        End Try
    End Sub
End Class
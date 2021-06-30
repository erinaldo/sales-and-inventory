Public Class StoreStockListForm

    Dim itm As New ItemsClass

    Private Sub StoreStockListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetCuststoreInfo()
            itm.GetstoreList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StoreStockListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 16
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            itm.GetstoreList()
        Catch ex As Exception

        End Try
    End Sub
End Class

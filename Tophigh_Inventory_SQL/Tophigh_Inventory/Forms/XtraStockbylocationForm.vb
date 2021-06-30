Public Class XtraStockbylocationForm

    Dim itm As New ItemsClass

    Private Sub XtraStockbylocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.CompInfo()
            itm.Getstockbylocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraStockbylocationForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            itm.Getstockbylocation()
        Catch ex As Exception

        End Try
    End Sub
End Class
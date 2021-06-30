Public Class XtraPurchsebySupForm

    Dim itm As New ItemsClass

    Private Sub XtraPurchsebySupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.CompPurInfo()
            itm.GetPurchasebySup()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefesh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefesh.ItemClick
        Try
            itm.GetPurchasebySup()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraPurchsebySupForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
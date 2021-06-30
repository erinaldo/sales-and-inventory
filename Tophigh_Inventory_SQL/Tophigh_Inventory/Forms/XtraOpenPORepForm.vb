Public Class XtraOpenPORepForm

    Dim itm As New ItemsClass

    Private Sub XtraOpenPORepForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.CompInfo()
            itm.GetOpenPO()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraOpenPORepForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            itm.GetOpenPO()
        Catch ex As Exception

        End Try
    End Sub
End Class
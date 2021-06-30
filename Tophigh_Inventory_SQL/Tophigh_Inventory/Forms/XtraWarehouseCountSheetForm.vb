Public Class XtraWarehouseCountSheetForm

    Dim itm As New ItemsClass

    Private Sub XtraWarehouseCountSheetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.CompInfoCntSheet()
            itm.GetWarehouseCntSheet()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try
            itm.GetWarehouseCntSheet()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraWarehouseCountSheetForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
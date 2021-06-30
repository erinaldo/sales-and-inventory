Public Class AjustStoreItems

    Dim itm As New ItemsClass
    Dim index As Integer
    Private Sub AjustStoreItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetCountlocation()
            itm.FillCombo()
            itm.AdjustStoreItems()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnupdate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnupdate.ItemClick
        Try
            itm.UpdateAdjustStoreQty()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btndelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btndelete.ItemClick
        Try
            Dim ans As String
            ans = MsgBox("Are sure you want to delete this item", vbYesNo)
            If ans = vbYes Then
                itm.DeleteStore()
            Else
                Exit Sub
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            itm.AdjustStoreItems()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cbolocation_TextChanged(sender As Object, e As EventArgs) Handles cbolocation.TextChanged
        Try
            itm.AdjustStoreItems()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvAdjust_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjust.CellContentClick

    End Sub

    Private Sub dgvAdjust_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAdjust.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvAdjust.Rows(e.RowIndex)
                txtid.Text = row.Cells(0).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbosearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosearch.SelectedIndexChanged
        Try
            itm.SearchAdjustStoreItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosearch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbosearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                itm.SearchAdjustStoreItems()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosearch_TextChanged(sender As Object, e As EventArgs) Handles cbosearch.TextChanged
        Try
            itm.SearchAdjustStoreItems()
        Catch ex As Exception

        End Try
    End Sub
End Class
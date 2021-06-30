Public Class AdjustItems

    Dim itm As New ItemsClass
    Dim index As Integer

    Private Sub AdjustItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetCountlocation()
            itm.AdjustWareItems()
            itm.FillCombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_TextChanged(sender As Object, e As EventArgs) Handles cbolocation.TextChanged
        Try
            itm.AdjustWareItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAjust_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAjust.ItemClick

        Try

            expdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            expdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            expdate.Properties.Mask.UseMaskAsDisplayFormat = True
            expdate.Properties.CharacterCasing = CharacterCasing.Upper

            dgvAdjust.AllowUserToAddRows = False
            itm.UpdateAdjustWareQtyText()
            'itm.UpdateAdjustWareQty()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvAdjust_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjust.CellClick
        Try

            index = e.RowIndex

            Dim selectedRow As DataGridViewRow

            selectedRow = dgvAdjust.Rows(index)

            txtid.Text = selectedRow.Cells(0).Value.ToString()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btndelete.ItemClick
        Try
            Dim ans As String
            ans = MsgBox("Are sure you want to delete this item", vbYesNo)
            If ans = vbYes Then
                itm.DeleteWare()
            Else
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            itm.AdjustWareItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAdjust_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAdjust.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvAdjust.Rows(e.RowIndex)
                txtdelid.Text = row.Cells(0).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbosearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbosearch.SelectedIndexChanged
        Try
            itm.SearchtWareItems()
            itm.FillSearchDataBox()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosearch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbosearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                itm.SearchtWareItems()
                itm.FillSearchDataBox()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAdjust_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjust.CellContentClick

    End Sub

    Private Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged
        'Try
        '    MsgBox(txtid.Text)
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cbosearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbosearch.KeyPress

    End Sub
End Class
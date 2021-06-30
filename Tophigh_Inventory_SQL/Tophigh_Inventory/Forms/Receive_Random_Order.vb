
Public Class Receive_Random_Order

    Dim itm As New ItemsClass
    Dim index As Integer

    Private Sub Receive_Random_Order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Timer1.Start()
            itm.GetCountlocation()
            itm.ReceiveWareItems()
            itm.FillCombo()
            dtDate.EditValue = Date.Now
            dtDate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtDate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtDate.Properties.CharacterCasing = CharacterCasing.Upper
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_TextChanged(sender As Object, e As EventArgs) Handles cbolocation.TextChanged
        Try
            itm.ReceiveWareItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAjust_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAjust.ItemClick
        Try

            dtDate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtDate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtDate.Properties.CharacterCasing = CharacterCasing.Upper

            itm.InsertReceiveNewHist()
            itm.UpdateAdjustReceWareQty()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAdjust_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdjust.CellClick
        Try

            index = e.RowIndex

            Dim selectedRow As DataGridViewRow

            selectedRow = dgvAdjust.Rows(index)

            txtid.Text = selectedRow.Cells(1).Value.ToString()

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
            itm.SearchReceWareItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosearch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbosearch.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                itm.SearchReceWareItems()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbolocation.SelectedIndexChanged
        Try
            itm.ReceiveWareItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lbltimer.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub
End Class

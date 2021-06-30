Public Class StockManualCountForm

    Dim itm As New ItemsClass

    Private Sub StockManualCountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetCntInv()
            itm.GetCntcogs()
            itm.GetCountlocation()
            itm.loadInvCount()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_TextChanged(sender As Object, e As EventArgs) Handles cbolocation.TextChanged
        Try
            itm.loadInvCount()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCount_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvCount.CellBeginEdit
        Try
            itm.CountCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCount_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCount.CellEndEdit
        Try
            itm.CountCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCount_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCount.CellLeave
        Try
            itm.CountCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCount_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCount.CellEnter
        Try
            itm.CountCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Try
            dtDate.Format = DateTimePickerFormat.Custom
            dtDate.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try
        Try
            itm.InsertManuCount()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCount_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCount.CellValueChanged
        Try

            If e.RowIndex >= 0 AndAlso (e.ColumnIndex = 3 OrElse e.ColumnIndex = 4) Then

                With dgvCount.Rows(e.RowIndex)
                    Try
                        .Cells(5).Value = CInt(.Cells(3).Value) - CDbl(.Cells(4).Value)
                    Catch
                        .Cells(6).Value = "?"
                    End Try
                End With

            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
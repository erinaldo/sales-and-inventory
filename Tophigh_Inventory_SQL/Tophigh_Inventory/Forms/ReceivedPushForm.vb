Public Class ReceivedPushForm

    Dim itm As New ItemsClass
    Private Sub ReceivedPushForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.Getlocation()
            itm.loadPushData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbolocation.SelectedIndexChanged
        Try
            itm.loadPushData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_TextChanged(sender As Object, e As EventArgs) Handles cbolocation.TextChanged
        Try
            itm.loadPushData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvRecTrans.CellBeginEdit
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecTrans.CellClick
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecTrans.CellEndEdit
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecTrans.CellEnter
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecTrans.CellLeave
        Try
            ' itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRecTrans.CellValueChanged
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvRecTrans_Click(sender As Object, e As EventArgs) Handles dgvRecTrans.Click
        Try
            'itm.CalPushgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        Try
            dtDate.Format = DateTimePickerFormat.Custom
            dtDate.CustomFormat = "yyyy-MM-dd"
        Catch ex As Exception

        End Try
        Try
            itm.UpdatePushData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            itm.loadPushData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
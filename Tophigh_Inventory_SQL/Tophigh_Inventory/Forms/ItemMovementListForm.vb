Public Class ItemMovementListForm

    Dim itm As New ItemsClass

    Private Sub ItemMovementListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetStockMovement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            itm.GetStockMovement()
        Catch ex As Exception

        End Try
    End Sub
End Class
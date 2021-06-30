Public Class LowStockForm

    Dim itm As New ItemsClass

    Private Sub LowStockForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.GetStockleve()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            itm.GetStockleve()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Try
            XtraPuchaseOrderForm.Show()
            XtraPuchaseOrderForm.MdiParent = MainForm
            XtraPuchaseOrderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReceOrder_Click(sender As Object, e As EventArgs) Handles btnReceOrder.Click
        Try
            XtraReceiveOderForm.Show()
            XtraReceiveOderForm.MdiParent = MainForm
            XtraReceiveOderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub
End Class
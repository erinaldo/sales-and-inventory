Public Class Stock2ListForm

    Dim stk As New Stock2Class

    Private Sub Stock2ListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            stk.LoadAvialStock
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            Stock2Form.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            stk.LoadAvialStock()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreport_Click(sender As Object, e As EventArgs) Handles btnreport.Click
        Try
            SalesReportForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsales_Click(sender As Object, e As EventArgs) Handles btnsales.Click
        Try
            SalesForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrecorder_Click(sender As Object, e As EventArgs) Handles btnrecorder.Click
        Try
            ReceiveOrders2Form.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Stock2HistoryForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class
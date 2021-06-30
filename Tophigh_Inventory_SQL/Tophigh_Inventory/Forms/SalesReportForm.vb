Public Class SalesReportForm

    Dim inv As New Stock2Class
    Private Sub SalesReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            inv.GetSalesOrederData()

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            inv.GetSalesOrederData()

        Catch ex As Exception

        End Try
    End Sub
End Class
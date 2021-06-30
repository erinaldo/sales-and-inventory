Public Class SalesOrderReportForm

    Dim pos As New POSClass
    Private Sub SalesOrderReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pos.GetSalesOrederData()

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesOrderReportForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            pos.GetSalesOrederData()
        Catch ex As Exception

        End Try
    End Sub
End Class
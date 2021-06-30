Public Class CSalesReportForm

    Dim csal As New POSClass

    Private Sub CSalesReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            csal.CompInfo()
            csal.GetGeneralDailySales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GeneralDailyCashSales_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            csal.GetGeneralDailySales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            dtdatefrom.Format = DateTimePickerFormat.Custom
            dtdatefrom.CustomFormat = "yyyy-MM-dd"

            dtdateto.Format = DateTimePickerFormat.Custom
            dtdateto.CustomFormat = "yyyy-MM-dd"

            csal.GetGeneralDailySalesByDate()
        Catch ex As Exception

        End Try
    End Sub

End Class
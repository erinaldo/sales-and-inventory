Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts

Public Class DailySalesByChart

    Dim csal As New CashSalesClass

    Private Sub DailySalesByChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            csal.SalesPerformancebychart()
            csal.SalesPerformancechart()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DailySalesByChart_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            csal.SalesPerformancebychartDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            csal.SalesPerformancebychart()
            csal.SalesPerformancechart()
        Catch ex As Exception

        End Try
    End Sub

End Class
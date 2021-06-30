Imports System.IO
Imports System.Text

Public Class StockTransferReportForm

    Dim itm As New ItemsClass

    Private Declare Function ShellEx Lib "shell32.dll" Alias "ShellExecuteA" (
        ByVal hWnd As Integer, ByVal lpOperation As String,
        ByVal lpFile As String, ByVal lpParameters As String,
        ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer

    Private Sub StockTransferReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.loadPushReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StockTransferReportForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            itm.loadPushReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            itm.ExportToPDF()
        Catch ex As Exception

        End Try
    End Sub
End Class
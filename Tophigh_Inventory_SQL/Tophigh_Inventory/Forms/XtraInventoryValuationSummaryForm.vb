Public Class XtraInventoryValuationSummaryForm

    Dim rpt As New ItemsClass

    Private Sub XtraInventoryValuationSummaryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            rpt.CompInfo()
            rpt.GetInvValSum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraInventoryValuationSummaryForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            rpt.CompInfo()
            rpt.GetInvValSum()
        Catch ex As Exception

        End Try
    End Sub
End Class
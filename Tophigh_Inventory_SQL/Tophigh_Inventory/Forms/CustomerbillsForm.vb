Public Class CustomerbillsForm

    Dim inv As New InvoiceClass

    Private Sub CustomerbillsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            inv.CompInfo()
            inv.GetOpenInvoice()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CustomerbillsForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            inv.GetOpenInvoice()
        Catch ex As Exception

        End Try
    End Sub
End Class
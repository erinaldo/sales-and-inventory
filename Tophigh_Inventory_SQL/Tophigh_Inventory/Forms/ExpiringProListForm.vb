Public Class ExpiringProListForm

    Dim itm As New ItemsClass

    Private Sub ExpiringProListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.loadExpiredPro()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExpiringProListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrintt_Click(sender As Object, e As EventArgs) Handles btnPrintt.Click

    End Sub
End Class
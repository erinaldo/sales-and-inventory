Public Class BGForm
    Private Sub BGForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BGForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class LoginForm

    Dim usr As New SettingsClass

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            usr.FillUser()
            usr.Filllocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Try
            usr.LoginDatabase()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbolocation_KeyDown(sender As Object, e As KeyEventArgs) Handles cbolocation.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btnok.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpassword.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btnok.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            StartUpForm.Show()
            StartUpForm.Close()
            StartUpForm.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbouser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbouser.SelectedIndexChanged

    End Sub
End Class
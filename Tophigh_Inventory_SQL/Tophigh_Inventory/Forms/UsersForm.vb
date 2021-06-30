Public Class UsersForm

    Dim usr As New SettingsClass

    Private Sub UsersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            usr.FillUser()
            usr.Filllocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click
        Try
            If cbouser.Text = "" Then
                MsgBox("Select user")
                cbouser.Focus()
                Exit Sub
            End If

            If txtpassword.Text = "" Then
                MsgBox("Type in user password")
                txtpassword.Focus()
                Exit Sub
            End If

            If cborole.Text = "" Then
                MsgBox("Select user role")
                cborole.Focus()
                Exit Sub
            End If

            If cbolocation.Text = "" Then
                MsgBox("Select user location")
                cbolocation.Focus()
                Exit Sub
            End If

            usr.InsertUsers()
        Catch ex As Exception

        End Try
    End Sub
End Class
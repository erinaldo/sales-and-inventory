Public Class AddLocationForm

    Dim st As New SettingsClass
    Private Sub AddLocationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            If txtlocation.Text = "" = True Then
                MsgBox("Enter location")
                txtlocation.Focus()
                Exit Sub
            End If

            If txtarea.Text = "" = True Then
                MsgBox("Enter Area")
                txtarea.Focus()
                Exit Sub
            End If
            st.InsertLocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class
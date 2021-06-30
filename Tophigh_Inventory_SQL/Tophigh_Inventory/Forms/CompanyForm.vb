Public Class CompanyForm

    Dim cmp As New CompanyClass

    Private Sub CompanyForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmp.Filllocation()
            cmp.showcomp()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            cmp.CheckComp()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Try
            cmp.ClearData()
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

    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnload.Click
        Try

            Dim result As DialogResult = OpenFiles.ShowDialog
            If result = DialogResult.OK Then
                If (OpenFiles.FileName IsNot Nothing) Or (OpenFiles.FileName <> String.Empty) Then

                    piclogo.Image = Image.FromFile(OpenFiles.FileName)
                    txtfilename.Text = OpenFiles.FileName

                End If
            End If

        Catch ex As Exception

        End Try


    End Sub
End Class
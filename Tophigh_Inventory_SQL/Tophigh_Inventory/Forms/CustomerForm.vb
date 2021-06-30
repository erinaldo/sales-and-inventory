Public Class CustomerForm

    Dim cus As New CustomerClass

    Private Sub CustomerForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cus.autogenerate_ID()
            cus.GetSupData()
            cus.GetSupAddData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            dtdob.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdob.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdob.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdob.Properties.CharacterCasing = CharacterCasing.Upper

            dtrenew.Format = DateTimePickerFormat.Custom
            dtrenew.CustomFormat = "yyyy-MM-dd"

            If txtcomp.Text = "" = True Then
                MsgBox("Please enter customer and contact persosn info")
                txtcomp.Focus()
                Exit Sub
            End If

            If txtmobile.Text = "" = True Then
                MsgBox("Please enter mobile number")
                txtmobile.Focus()
                Exit Sub
            End If

            cus.checkcust()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            cus.ClearData()
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

    Private Sub txtgcode_TextChanged(sender As Object, e As EventArgs) Handles txtgcode.TextChanged
        Try
            cus.GetSupData()
            cus.GetSupAddData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnload_Click(sender As Object, e As EventArgs) Handles btnload.Click
        Try

            Dim result As DialogResult = OpenFile.ShowDialog
            If result = DialogResult.OK Then
                If (OpenFile.FileName IsNot Nothing) Or (OpenFile.FileName <> String.Empty) Then

                    custpic.Image = Image.FromFile(OpenFile.FileName)
                    txtpicname.Text = OpenFile.FileName

                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            DependantsForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class
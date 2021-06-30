Public Class CategoryForm

    Dim st As New SettingsClass
    Dim sy As New SyncInClass
    Private Sub CategoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If txtcate.Text = "" = True Then
                MsgBox("Enter category")
                txtcate.Focus()
                Exit Sub
            Else
                st.InsertCate()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcate_KeyDown(sender As Object, e As KeyEventArgs) Handles txtcate.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If txtcate.Text = "" = True Then
                    MsgBox("Enter category")
                    txtcate.Focus()
                    Exit Sub
                Else
                    st.InsertCate()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
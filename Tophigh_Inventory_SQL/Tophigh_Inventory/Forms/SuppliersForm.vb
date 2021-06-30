Public Class SuppliersForm

    Dim sup As New SuppliersClass
    Private Sub SuppliersForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            sup.autogenerate_ID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

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

            sup.checkcust()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            sup.ClearData()
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
            sup.GetSupData()
            sup.GetSupAddData()
        Catch ex As Exception

        End Try
    End Sub
End Class
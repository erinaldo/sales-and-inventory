Public Class DependantsForm

    Dim cus As New CustomerClass

    Private Sub DependantsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cus.getdependents()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try

            dtdob.Format = DateTimePickerFormat.Custom
            dtdob.CustomFormat = "yyyy-MM-dd"

            dtrenew.Format = DateTimePickerFormat.Custom
            dtrenew.CustomFormat = "yyyy-MM-dd"

            If cbodependent.Text = "" = True Then
                MsgBox("Select Dependent")
                cbodependent.Focus()
                Exit Sub
            End If

            If txtfname.Text = "" = True Then
                MsgBox("SEnter full name")
                txtfname.Focus()
                Exit Sub
            End If

            If txtnhis.Text = "" = True Then
                MsgBox("SEnter NHIS Number")
                txtnhis.Focus()
                Exit Sub
            End If

            cus.InsertDependants()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            txtdepid.Text = ""
            txtfname.Text = ""
            txtnhis.Text = ""
            cbodependent.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodependent_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodependent.SelectedIndexChanged
        Try
            cus.Getcustid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodependent_TextChanged(sender As Object, e As EventArgs) Handles cbodependent.TextChanged
        Try
            cus.Getcustid()
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class MoveToStoreForm

    Dim itm As New ItemsClass

    Private Sub MoveToStoreForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.Addbulktostore()
            itm.Getlocation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try

            dtdate.Format = DateTimePickerFormat.Custom
            dtdate.CustomFormat = "yyyy-MM-dd"

            If cbowarelocation.Text = "" = True Then
                MsgBox("Select warehouse location")
                cbowarelocation.Focus()
                Exit Sub
            End If

            If cbostorelocation.Text = "" = True Then
                MsgBox("Select store location")
                cbostorelocation.Focus()
                Exit Sub
            End If

            itm.UpdateMoveQty()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbowarelocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbowarelocation.SelectedIndexChanged

    End Sub
End Class
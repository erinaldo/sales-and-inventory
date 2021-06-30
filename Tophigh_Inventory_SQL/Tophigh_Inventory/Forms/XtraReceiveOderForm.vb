Public Class XtraReceiveOderForm

    Dim itm As New ItemsClass

    Private Sub XtraReceiveOderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.FillBookNo()
            itm.GetRecInv()
            itm.GetRecPayable()
            itm.FillSup()
            itm.Getlocation()
            itm.loadRecitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboRecFrom_TextChanged(sender As Object, e As EventArgs) Handles cboRecFrom.TextChanged
        Try
            itm.GetMyID2()
            itm.loadRecitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsupid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsupid.TextChanged
        Try
            itm.GetCustInfo2()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReceive_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvReceive.CellBeginEdit
        Try
            itm.RecCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReceive_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceive.CellEndEdit
        Try
            itm.RecCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReceive_Click(sender As Object, e As EventArgs) Handles dgvReceive.Click
        Try
            itm.RecCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReceive_Enter(sender As Object, e As EventArgs) Handles dgvReceive.Enter
        Try
            itm.RecCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvReceive_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceive.RowLeave
        Try
            itm.RecCalgird()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        itm.RecCalgird()

        dtpodate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
        dtpodate.Properties.Mask.EditMask = "yyyy-MM-dd"
        dtpodate.Properties.Mask.UseMaskAsDisplayFormat = True
        dtpodate.Properties.CharacterCasing = CharacterCasing.Upper

        Try

            If txtponum.Text = "" = True Then
                MsgBox("Enter P.O Number")
                txtponum.Focus()
                Exit Sub
            End If

            If dtpodate.Text = "" = True Then
                MsgBox("Enter P.O Receieved Date")
                dtpodate.Focus()
                Exit Sub
            End If

            If dtduedate.Text = "" = True Then
                MsgBox("Enter P.O Payment Due Date")
                dtduedate.Focus()
                Exit Sub
            End If

            If txtcomment.Text = "" = True Then
                MsgBox("Enter P.O comment")
                txtcomment.Focus()
                Exit Sub
            End If

            If cbolocation.Text = "" = True Then
                MsgBox("Select Warehoue location")
                cbolocation.Focus()
                Exit Sub
            End If

            itm.InsertRecItems()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub dgvReceive_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReceive.CellContentClick

    End Sub
End Class
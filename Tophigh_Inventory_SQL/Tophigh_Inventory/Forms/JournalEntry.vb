Public Class JournalEntry

    Dim jv As New JournalsClass
    Private rowIndex As Integer = 0
    Dim index As Integer

    Private Sub JournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtcaccnum.Text = "kofi"
            txtaccnum.Text = "kofi"
            txtbank.Text = "kofi"
            txtcbank.Text = "kofi"
            txtdebitchecck.Text = "kofi"
            jv.FillBookNo()
            jv.GetAccount()
            jv.LoadGridView()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try

            dtentdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtentdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtentdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtentdate.Properties.CharacterCasing = CharacterCasing.Upper

            If dtentdate.Text = "" Then
                MsgBox("Enter journal date")
                dtentdate.Focus()
                Exit Sub
            End If

            If cboaccount.Text = "" Then
                MsgBox("Select journal Account")
                cboaccount.Focus()
                Exit Sub
            End If

            If cboCreditAcc.Text = "" Then
                MsgBox("Select journal Credit Account")
                cboCreditAcc.Focus()
                Exit Sub
            End If

            If txtdescription.Text = "" Then
                MsgBox("Enter journal details")
                txtdescription.Focus()
                Exit Sub
            End If

            If txtdebit.Text = "0.00" Then
                MsgBox("Enter an amount for the journal entry")
                txtdebit.Focus()
                Exit Sub
            End If

            If txtdebit.Text = "0" Then
                MsgBox("Enter an amount for the journal entry")
                txtdebit.Focus()
                Exit Sub
            End If

            If txtdebit.Text = "" Then
                MsgBox("Enter an amount for the journal entry")
                txtdebit.Focus()
                Exit Sub
            End If

            If txtdebitchecck.Text = "" Then
                txtdebitchecck.Text = "kofi"
            End If

            jv.GetData()
            jv.CalGridData()
            jv.FillBookNo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboaccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboaccount.SelectedIndexChanged
        Try
            jv.GetCheck()
            jv.Getbankdatdeb()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCreditAcc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCreditAcc.SelectedIndexChanged
        Try
            jv.GetCreditCheck()
            jv.Getbankdatcred()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdebit_Leave(sender As Object, e As EventArgs) Handles txtdebit.Leave
        Try
            txtdebit.Text = Format(txtdebit.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdescription_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdescription.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                btnadd.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            dtentdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtentdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtentdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtentdate.Properties.CharacterCasing = CharacterCasing.Upper

            jv.InsertBank()

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

    Private Sub txtdebit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtdebit.KeyDown
        Try

            If txtdebitchecck.Text = "" Then
                txtdebitchecck.Text = "kofi"
            End If

            If e.KeyCode = Keys.Enter Then
                btnadd.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvjournal_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvjournal.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.dgvjournal.Rows(e.RowIndex).Selected = True
            Me.rowIndex = e.RowIndex
            Me.dgvjournal.CurrentCell = Me.dgvjournal.Rows(e.RowIndex).Cells(1)
            Me.ContextMenuStrip1.Show(Me.dgvjournal, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        If Not Me.dgvjournal.Rows(Me.rowIndex).IsNewRow Then
            Me.dgvjournal.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub


End Class
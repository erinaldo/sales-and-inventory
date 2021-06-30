Public Class AddtoShelve

    Dim itm As New ItemsClass
    Dim rowIndex As Integer = 0
    Dim index As Integer
    Private Sub AddtoShelve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.Getshelflocation()
            itm.fillautocompletetextbox()
            itm.LoadBatchGridView()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Show_Combobox(ByVal iRowIndex As Integer, ByVal iColumnIndex As Integer)

        Try

            ' DESCRIPTION: SHOW THE COMBO BOX IN THE SELECTED CELL OF THE GRID.
            ' PARAMETERS: iRowIndex - THE ROW ID OF THE GRID.
            '             iColumnIndex - THE COLUMN ID OF THE GRID.

            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim Width As Integer = 0
            Dim height As Integer = 0

            ' GET THE ACTIVE CELL'S DIMENTIONS TO BIND THE COMBOBOX WITH IT.
            Dim rect As Rectangle = dgvData.GetCellDisplayRectangle(iColumnIndex, iRowIndex, False)
            x = rect.X + dgvData.Left
            y = rect.Y + dgvData.Top

            Width = rect.Width
            height = rect.Height

            With cbodata
                .SetBounds(x, y, Width, height)
                .Visible = True
                .Focus()
            End With

        Catch oEX As Exception

        End Try

    End Sub

    Private Sub dgvData_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellClick

        Try

            index = e.RowIndex

            Dim selectedRow As DataGridViewRow

            selectedRow = dgvData.Rows(index)

            TID.Text = selectedRow.Cells(0).Value.ToString()

        Catch ex As Exception

        End Try

        Try

            If dgvData.Columns(dgvData.CurrentCell.ColumnIndex).Name = "Product" Then
                dgvData.CurrentCell = dgvData.Rows(dgvData.CurrentRow.Index).Cells(dgvData.CurrentCell.ColumnIndex)

                ' SHOW COMBOBOX.
                Show_Combobox(dgvData.CurrentRow.Index, dgvData.CurrentCell.ColumnIndex)
                SendKeys.Send("{F4}")               ' DROP DOWN THE LIST.
            Else
                If dgvData.CurrentCell.ColumnIndex = dgvData.ColumnCount Then             ' CHECK IF ITS THE LAST COLUMN
                    dgvData.CurrentCell = dgvData.Rows(dgvData.CurrentCell.RowIndex).Cells(0)    ' GO TO THE FIRST COLUMN, NEXT ROW.
                Else
                    dgvData.CurrentCell = dgvData.Rows(dgvData.CurrentRow.Index).Cells(dgvData.CurrentCell.ColumnIndex)     ' NEXT COLUMN.
                End If
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvData_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvData.CellBeginEdit
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellDoubleClick
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvData_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEndEdit
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvData_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellEnter
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvData_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvData.CellLeave
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvData_Click(sender As Object, e As EventArgs) Handles dgvData.Click
        Try
            itm.CalBatchGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdd.ItemClick
        Try

            dgvData.AllowUserToAddRows = False

            If cbosource.Text = "" = True Then
                MsgBox("select data source")
                cbosource.Focus()
                Exit Sub
            End If

            If cbodestination.Text = "" = True Then
                MsgBox("select data destination")
                cbodestination.Focus()
                Exit Sub
            End If

            If rboAdd.Checked = True Then
                itm.insertBatchshelve()
            Else
                itm.updateBatchshelve()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        If Not Me.dgvData.Rows(Me.rowIndex).IsNewRow Then
            Me.dgvData.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub

    Private Sub dgvData_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvData.CellMouseUp
        Try

            If e.Button = MouseButtons.Right Then
                Me.dgvData.Rows(e.RowIndex).Selected = True
                Me.rowIndex = e.RowIndex
                Me.dgvData.CurrentCell = Me.dgvData.Rows(e.RowIndex).Cells(1)
                Me.ContextMenuStrip1.Show(Me.dgvData, e.Location)
                ContextMenuStrip1.Show(Cursor.Position)
            End If

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub Update_DgvDataRow()
    '    Try

    '        Dim newDataRow As DataGridViewRow = dgvData.Rows(index)
    '        ' get data from textboxes to the row
    '        newDataRow.Cells(0).Value = txtid.Text
    '        newDataRow.Cells(1).Value = cbodata.Text
    '        newDataRow.Cells(2).Value = txtsaleprice.Text
    '        newDataRow.Cells(3).Value = txtmemprice.Text
    '        newDataRow.Cells(4).Value = txtqtypcs.Text
    '        newDataRow.Cells(5).Value = txtpcs.Text
    '        newDataRow.Cells(6).Value = txtreorder.Text
    '        newDataRow.Cells(7).Value = txtbarcode.Text
    '        newDataRow.Cells(8).Value = txttype.Text
    '        newDataRow.Cells(9).Value = txtucost.Text
    '        newDataRow.Cells(10).Value = txtqtyinbox.Text
    '        newDataRow.Cells(11).Value = txttotpcs.Text

    '        cbodata.Text = ""
    '        cbodata.Visible = False

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub btnClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClose.ItemClick
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            itm.GetAvialqty()
            itm.Checkshelfitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_KeyDown(sender As Object, e As KeyEventArgs) Handles cbodata.KeyDown
        Try
            If e.KeyCode = Keys.Enter = True Then

                cbodata.Visible = False
                    itm.GetBatchData()

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class XtraPuchaseOrderForm

    Dim pur As New ItemsClass

    Private Sub XtraPuchaseOrderForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pur.FillSup()
        pur.LoadGridView()
        pur.FillCombo()
        pur.FillSaleNo()
    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            pur.FillDataBox()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPoOrder_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPoOrder.CellClick
        Try

            If dgvPoOrder.Columns(dgvPoOrder.CurrentCell.ColumnIndex).Name = "Items" Then
                dgvPoOrder.CurrentCell = dgvPoOrder.Rows(dgvPoOrder.CurrentRow.Index).Cells(dgvPoOrder.CurrentCell.ColumnIndex)

                ' SHOW COMBOBOX.
                Show_Combobox(dgvPoOrder.CurrentRow.Index, dgvPoOrder.CurrentCell.ColumnIndex)
                SendKeys.Send("{F4}")               ' DROP DOWN THE LIST.
            Else
                If dgvPoOrder.CurrentCell.ColumnIndex = dgvPoOrder.ColumnCount Then             ' CHECK IF ITS THE LAST COLUMN
                    dgvPoOrder.CurrentCell = dgvPoOrder.Rows(dgvPoOrder.CurrentCell.RowIndex).Cells(0)    ' GO TO THE FIRST COLUMN, NEXT ROW.
                Else
                    dgvPoOrder.CurrentCell = dgvPoOrder.Rows(dgvPoOrder.CurrentRow.Index).Cells(dgvPoOrder.CurrentCell.ColumnIndex)     ' NEXT COLUMN.
                End If
            End If

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
            Dim rect As Rectangle = dgvPoOrder.GetCellDisplayRectangle(iColumnIndex, iRowIndex, False)
            x = rect.X + dgvPoOrder.Left
            y = rect.Y + dgvPoOrder.Top

            Width = rect.Width
            height = rect.Height

            With cbodata
                .SetBounds(x, y, Width, height)
                .Visible = True
                .Focus()
            End With

        Catch oEX As Exception
            Call MsgBox(oEX.Message)
        End Try

    End Sub

    Private Sub cbodata_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cbodata.KeyDown
        Try
            If e.KeyCode = Keys.Enter = True Then
                cbodata.Visible = False
                pur.GetData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles mRate.TextChanged
        Try
            mRate.Text = Format(mRate.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub mAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles mAmount.TextChanged
        Try
            mAmount.Text = Format(mAmount.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosup_TextChanged(sender As Object, e As System.EventArgs) Handles cbosup.TextChanged
        Try
            pur.GetMyID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsupid_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtsupid.TextChanged
        Try
            pur.GetCustInfo()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvPoOrder_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPoOrder.CellBeginEdit
        Try
            pur.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPoOrder_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPoOrder.CellLeave
        Try
            pur.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPoOrder_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPoOrder.CellEndEdit
        Try
            pur.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txttotal_TextChanged(sender As Object, e As EventArgs) Handles txttotal.TextChanged
        Try
            txttotal.Text = Format(txttotal.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            dtorderdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtorderdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtorderdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtorderdate.Properties.CharacterCasing = CharacterCasing.Upper

            pur.InsertPO()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        pur.ClearData()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        Me.Dispose()
    End Sub
End Class
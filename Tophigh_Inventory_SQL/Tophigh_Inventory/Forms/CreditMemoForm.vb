Public Class CreditMemoForm

    Dim cm As New CreditMemoClass
    Private rowIndex As Integer = 0
    Dim index As Integer

    Private Sub CreditMemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dtSalesDate.DateTime = Date.Now
            dthistdate.Format = DateTimePickerFormat.Custom
            dthistdate.CustomFormat = "yyyy-MM-dd"
            cm.CompInfo()
            cm.GetCogs()
            cm.GetDiscAcc()
            cm.GetInvAcc()
            cm.GetSales()
            cm.GetTaxAcc()
            cm.LoadGridView()
            cm.GetCash()
            cm.FillCombo()
            cm.FillSaleNo()
            cm.FillCustName()
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellClick

        Try

            index = e.RowIndex

            Dim selectedRow As DataGridViewRow

            selectedRow = dgvsales.Rows(index)

            TID.Text = selectedRow.Cells(0).Value.ToString()

        Catch ex As Exception

        End Try


        Try

            If dgvsales.Columns(dgvsales.CurrentCell.ColumnIndex).Name = "Items" Then
                dgvsales.CurrentCell = dgvsales.Rows(dgvsales.CurrentRow.Index).Cells(dgvsales.CurrentCell.ColumnIndex)

                ' SHOW COMBOBOX.
                Show_Combobox(dgvsales.CurrentRow.Index, dgvsales.CurrentCell.ColumnIndex)
                SendKeys.Send("{F4}")               ' DROP DOWN THE LIST.
            Else
                If dgvsales.CurrentCell.ColumnIndex = dgvsales.ColumnCount Then             ' CHECK IF ITS THE LAST COLUMN
                    dgvsales.CurrentCell = dgvsales.Rows(dgvsales.CurrentCell.RowIndex).Cells(0)    ' GO TO THE FIRST COLUMN, NEXT ROW.
                Else
                    dgvsales.CurrentCell = dgvsales.Rows(dgvsales.CurrentRow.Index).Cells(dgvsales.CurrentCell.ColumnIndex)     ' NEXT COLUMN.
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
            Dim rect As Rectangle = dgvsales.GetCellDisplayRectangle(iColumnIndex, iRowIndex, False)
            x = rect.X + dgvsales.Left
            y = rect.Y + dgvsales.Top

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

    Private Sub cbodata_KeyDown(sender As Object, e As KeyEventArgs) Handles cbodata.KeyDown
        Try
            If e.KeyCode = Keys.Enter = True Then
                'If TID.Text = "" = False Then
                'cbodata.Visible = False
                'Update_DgvDataRow()
                'Else
                cbodata.Visible = False
                    cm.GetData()
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            cm.CheckData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvsales.CellBeginEdit
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEndEdit
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEnter
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellLeave
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Click(sender As Object, e As EventArgs) Handles dgvsales.Click
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Enter(sender As Object, e As EventArgs) Handles dgvsales.Enter
        Try
            cm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsubtot_TextChanged(sender As Object, e As EventArgs) Handles txtsubtot.TextChanged
        Try

            Dim subt As Double = txtsubtot.Text
            Dim calres As Double = subt
            txtTotal.Text = calres

        Catch ex As Exception

        End Try

        Try
            If chkvat.Checked = True Then

                cm.GetVatValue()

                Dim vatval As Double = txtvatval.Text
                Dim subt As Double = txtsubtot.Text
                Dim calres As Double = (subt * vatval) / 100
                txtvat.Text = calres

            Else
                txtvatval.Text = "0.00"
                Dim vatval As Double = txtvatval.Text
                Dim subt As Double = txtsubtot.Text
                Dim calres As Double = (subt * vatval) / 100
                txtvat.Text = calres
                Exit Sub
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtvat_TextChanged(sender As Object, e As EventArgs) Handles txtvat.TextChanged
        Try
            Dim vtot As Double = txtvat.Text
            Dim ftot As Double = txtsubtot.Text
            Dim res As Double = ftot + vtot
            txtTotal.Text = res
            txtvat.Text = Format(txtvat.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCustomer_TextChanged(sender As Object, e As EventArgs) Handles cboCustomer.TextChanged
        Try
            cm.Getcustid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lblTime.Text = TimeString.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            dtSalesDate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtSalesDate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtSalesDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtSalesDate.Properties.CharacterCasing = CharacterCasing.Upper

            dtshipdate.Format = DateTimePickerFormat.Custom
            dtshipdate.CustomFormat = "yyyy-MM-dd"

            If cboTerms.Text = "" = True Then
                MsgBox("Payment Terms required")
                cboTerms.Focus()
                Exit Sub
            End If

            If mDescript.Text = "" = True Then
                MsgBox("Please enter a brief memo")
                mDescript.Focus()
                Exit Sub
            End If

            If txtPO.Text = "" = True Then
                MsgBox("Please enter P.O Number")
                txtPO.Focus()
                Exit Sub
            End If

            If cboTerms.Text = "" = True Then
                MsgBox("Please select payment terms")
                cboTerms.Focus()
                Exit Sub
            End If

            If txtInvNo.Text = "" = True Then
                MsgBox("Please enter invoice number")
                txtInvNo.Focus()
                Exit Sub
            End If

            cm.InsertCashSales()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkvat_CheckedChanged(sender As Object, e As EventArgs) Handles chkvat.CheckedChanged
        Try
            If chkvat.Checked = True Then

                cm.GetVatValue()

                Dim vatval As Double = txtvatval.Text
                Dim subt As Double = txtsubtot.Text
                Dim calres As Double = (subt * vatval) / 100
                txtvat.Text = calres

            Else
                txtvatval.Text = "0.00"
                Dim vatval As Double = txtvatval.Text
                Dim subt As Double = txtsubtot.Text
                Dim calres As Double = (subt * vatval) / 100
                txtvat.Text = calres
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotal.TextChanged
        Try
            txtTotal.Text = Format(txtTotal.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcustid_TextChanged(sender As Object, e As EventArgs) Handles txtcustid.TextChanged
        Try
            cm.GetCustInfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellMouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvsales.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Me.dgvsales.Rows(e.RowIndex).Selected = True
            Me.rowIndex = e.RowIndex
            Me.dgvsales.CurrentCell = Me.dgvsales.Rows(e.RowIndex).Cells(1)
            Me.ContextMenuStrip1.Show(Me.dgvsales, e.Location)
            ContextMenuStrip1.Show(Cursor.Position)
        End If
    End Sub

    Private Sub ContextMenuStrip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContextMenuStrip1.Click
        If Not Me.dgvsales.Rows(Me.rowIndex).IsNewRow Then
            Me.dgvsales.Rows.RemoveAt(Me.rowIndex)
        End If
    End Sub

    'Private Sub Update_DgvDataRow()
    '    Try

    '        Dim newDataRow As DataGridViewRow = dgvsales.Rows(Index)
    '        ' get data from textboxes to the row
    '        newDataRow.Cells(0).Value = txtid.Text
    '        newDataRow.Cells(1).Value = txtName.Text
    '        newDataRow.Cells(2).Value = txtqty.Text
    '        newDataRow.Cells(3).Value = txtrate.Text
    '        newDataRow.Cells(4).Value = txtamt.Text
    '        newDataRow.Cells(5).Value = txtunitcost.Text
    '        newDataRow.Cells(6).Value = txtutot.Text

    '        cbodata.Text = ""
    '        TID.Text = ""

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub cbodata_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbodata.SelectedIndexChanged

    End Sub

    Private Sub dgvsales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellContentClick

    End Sub
End Class
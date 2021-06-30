Public Class POSForm3

    Dim csal As New POSClass3
    Private rowIndex As Integer = 0
    Dim index As Integer

    Private Sub POSForm3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbodata.Focus()
            csal.GetPOStNum()
            dthistdate.Format = DateTimePickerFormat.Custom
            dthistdate.CustomFormat = "yyyy-MM-dd"
            txtemp.Text = MainForm.lbluser.Text
            txtposition.Text = MainForm.txtrole.Text
            cboCustomer.Text = "Walk in Customer"
            csal.GetCogs()
            csal.GetDiscAcc()
            csal.GetInvAcc()
            csal.GetSales()
            csal.GetTaxAcc()
            csal.LoadGridView()
            csal.GetCash()
            csal.FillCombo()
            csal.FillSaleNo()
            csal.FillCustName()
            csal.CompInfo()
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
            csal.CalGridData()
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

        End Try

    End Sub

    Private Sub cbodata_KeyDown(sender As Object, e As KeyEventArgs) Handles cbodata.KeyDown
        Try
            If e.KeyCode = Keys.Enter = True Then

                csal.GetData()
                lvdrop.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvsales.CellBeginEdit
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEndEdit
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEnter
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellLeave
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellValueChanged
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Click(sender As Object, e As EventArgs) Handles dgvsales.Click
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Enter(sender As Object, e As EventArgs) Handles dgvsales.Enter
        Try
            csal.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsubtot_TextChanged(sender As Object, e As EventArgs) Handles txtsubtot.TextChanged
        Try

            txtsubtot.Text = Format(txtsubtot.Text, "standard")

            Dim subt As Double = txtsubtot.Text
            Dim dicmin As Double = txtsaldisc.Text
            Dim calres As Double = subt - dicmin
            txtTotal.Text = calres

            Dim ft As Double = txtTotal.Text
            Dim rec As Double = txtreceive.Text
            Dim rels As Double = rec - ft
            txtchange.Text = rels

        Catch ex As Exception

        End Try

        Try
            If chkvat.Checked = True Then

                csal.GetVatValue()

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
            Dim dicmin As Double = txtsaldisc.Text
            Dim res As Double = (ftot + vtot) - dicmin
            txtTotal.Text = res
            txtvat.Text = Format(txtvat.Text, "standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCustomer_TextChanged(sender As Object, e As EventArgs) Handles cboCustomer.TextChanged
        Try
            csal.Getcustid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            'lblTime.Text = TimeString.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            csal.FillSaleNo()

            dtSalesDate.Format = DateTimePickerFormat.Custom
            dtSalesDate.CustomFormat = "yyyy-MM-dd"

            csal.CalGridData()

            If cboPayMeth.Text = "" = True Then
                MsgBox("Payment method required")
                cboPayMeth.Focus()
                Exit Sub
            End If

            If txtreceive.Text = "0.00" Or txtreceive.Text = "0" Or txtreceive.Text = "" = True Then
                MsgBox("Please enter amount received")
                txtreceive.Focus()
                Exit Sub
            End If

            csal.FillSaleNo()

            If rbomem.Checked = True Then
                csal.InsertMemsCashSales()
            Else
                csal.InsertCashSales()
            End If

            csal.CheckStoreStock()
            csal.CheckWarehStock()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkvat_CheckedChanged(sender As Object, e As EventArgs) Handles chkvat.CheckedChanged
        Try
            If chkvat.Checked = True Then

                csal.GetVatValue()

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

            Dim ft As Double = txtTotal.Text
            Dim rec As Double = txtreceive.Text
            Dim rels As Double = rec - ft
            txtchange.Text = rels

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsaldisc_Leave(sender As Object, e As EventArgs) Handles txtsaldisc.Leave
        Try
            Dim subt As Double = txtsubtot.Text
            Dim dicmin As Double = txtsaldisc.Text
            Dim calres As Double = subt - dicmin
            txtTotal.Text = calres
            txtsaldisc.Text = Format(txtsaldisc.Text, "standard")
        Catch ex As Exception

        End Try

        Try
            If chkvat.Checked = True Then

                csal.GetVatValue()

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

        Try
            Dim ft As Double = txtTotal.Text
            Dim rec As Double = txtreceive.Text
            Dim rels As Double = rec - ft
            txtchange.Text = rels
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtreceive_TextChanged(sender As Object, e As EventArgs) Handles txtreceive.TextChanged
        Try
            Dim ft As Double = txtTotal.Text
            Dim rec As Double = txtreceive.Text
            Dim rels As Double = rec - ft
            txtchange.Text = rels
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtchange_TextChanged(sender As Object, e As EventArgs) Handles txtchange.TextChanged
        Try
            txtchange.Text = Format(txtchange.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtreceive_Leave(sender As Object, e As EventArgs) Handles txtreceive.Leave
        Try
            txtreceive.Text = Format(txtreceive.Text, "Standard")

            If txtchange.Text < "0.00" = True Then
                MsgBox("Amount tendered is below net total")
                txtreceive.Text = "0"
                btnsave.Enabled = False
                txtreceive.Focus()
                Exit Sub
            ElseIf txtchange.Text < "0" = True Then
                MsgBox("Amount tendered is below net total")
                txtreceive.Text = "0"
                btnsave.Enabled = False
                txtreceive.Focus()
                Exit Sub
            Else
                btnsave.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtreceive_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreceive.KeyDown
        Try

            If e.KeyCode = Keys.Enter Then
                If txtchange.Text < "0.00" = True Then
                    MsgBox("Amount tendered is below net total")
                ElseIf txtchange.Text < "0" = True Then
                    MsgBox("Amount tendered is below net total")
                End If

                If txtreceive.Text < txtTotal.Text Then
                    MsgBox("Amount tendered is below net total")
                    txtreceive.Text = "0"
                    btnsave.Enabled = False
                    txtreceive.Focus()
                    Exit Sub

                    csal.CalGridData()

                    If cboPayMeth.Text = "" = True Then
                        MsgBox("Payment method required")
                        cboPayMeth.Focus()
                        Exit Sub
                    End If

                    csal.InsertCashSales()
                    csal.CheckStoreStock()
                    csal.CheckWarehStock()

                Else

                    btnsave.Enabled = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtrate_TextChanged(sender As Object, e As EventArgs) Handles txtrate.TextChanged
        Try
            txtrate.Text = Format(txtrate.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            csal.CheckData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtqtycheck_TextChanged(sender As Object, e As EventArgs) Handles txtqtycheck.TextChanged
        Try
            Dim ValueTo As Integer = Convert.ToInt32(txtstock.Text)
            Dim ValueFrom As Integer = Convert.ToInt32(txtqtycheck.Text)

            If ValueTo < ValueFrom = True Then
                txtqty.BackColor = Color.Red
                txtqty.ForeColor = Color.Yellow
                MsgBox("You can't sell more than what you have")
                txtqty.Text = "1"
                Exit Sub
            Else
                txtqty.BackColor = Color.Green
                txtqty.ForeColor = Color.Yellow
            End If

            Dim qtyval As Integer = txtqty.Text
            Dim rateval As Double = txtrate.Text
            Dim resval As Double = qtyval * rateval
            txtamt.Text = resval

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            csal.GetPOStNum()
            dthistdate.Format = DateTimePickerFormat.Custom
            dthistdate.CustomFormat = "yyyy-MM-dd"
            txtemp.Text = MainForm.lbluser.Text
            txtposition.Text = MainForm.txtrole.Text
            cboCustomer.Text = "Walk in Customer"
            csal.GetCogs()
            csal.GetDiscAcc()
            csal.GetInvAcc()
            csal.GetSales()
            csal.GetTaxAcc()
            csal.GetCash()
            csal.FillCombo()
            csal.FillSaleNo()
            csal.FillCustName()
            csal.CompInfo()
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        Try
            csal.NewData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged
        Try
            txtqtycheck.Text = txtqty.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtqty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtqty.KeyDown
        Try
            If e.KeyCode = Keys.Enter = True Then
                'If TID.Text = "" = False Then
                '    'Update_DgvDataRow()
                'Else
                csal.GetData()
                'End If
            End If
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

    Private Sub rbogen_CheckedChanged(sender As Object, e As EventArgs) Handles rbogen.CheckedChanged
        Try
            If rbogen.Checked = True Then
                csal.FillSaleNo()
                csal.FillCustName()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Rbomem_CheckedChanged(sender As Object, e As EventArgs) Handles rbomem.CheckedChanged
        Try
            If rbomem.Checked = True Then
                csal.FillMemSaleNo()
                csal.FillMembers()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Cbodata_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            csal.CheckMember()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtamt_TextChanged(sender As Object, e As EventArgs) Handles txtamt.TextChanged
        Try
            txtamt.Text = Format(txtamt.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub Update_DgvDataRow()
    '    Try

    '        Dim newDataRow As DataGridViewRow = dgvsales.Rows(index)
    '        ' get data from textboxes to the row
    '        newDataRow.Cells(0).Value = txtid.Text
    '        newDataRow.Cells(1).Value = txtName.Text
    '        newDataRow.Cells(2).Value = txtqty.Text
    '        newDataRow.Cells(3).Value = txtrate.Text
    '        newDataRow.Cells(4).Value = txtamt.Text
    '        newDataRow.Cells(5).Value = txtunitcost.Text
    '        newDataRow.Cells(6).Value = txtutot.Text
    '        newDataRow.Cells(7).Value = txtsyncode.Text

    '        cbodata.Text = ""
    '        TID.Text = ""

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub dgvsales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellContentClick

    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            csal.CheckMember()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbodata.KeyPress
        Try
            csal.AutoCompleteList()
            If cbodata.Text = "" = True Then
                lvdrop.Visible = False
            Else
                lvdrop.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lvdrop_Click(sender As Object, e As EventArgs) Handles lvdrop.Click
        Try
            cbodata.Text = GridView1.Columns.View.GetFocusedRowCellValue("Product")
            cbodata.Focus()
            lvdrop.Visible = False
        Catch ex As Exception

        End Try
    End Sub

End Class
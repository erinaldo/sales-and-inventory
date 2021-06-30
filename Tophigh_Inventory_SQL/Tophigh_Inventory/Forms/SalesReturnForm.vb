Public Class SalesReturnForm

    Dim csal As New SalesReturnClass

    Private Sub SalesReturnForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
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
            dtSalesDate.DateTime = Date.Now
            dthistdate.Format = DateTimePickerFormat.Custom
            dthistdate.CustomFormat = "yyyy-MM-dd"
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellClick
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
                cbodata.Visible = False
                csal.GetData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            csal.CheckData()
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

            Dim subt As Double = txtsubtot.Text
            Dim dicmin As Double = txtsaldisc.Text
            Dim calres As Double = subt - dicmin
            txtTotal.Text = calres

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

            If cboPayMeth.Text = "" = True Then
                MsgBox("Payment method required")
                cboPayMeth.Focus()
                Exit Sub
            End If

            If mDescript.Text = "" = True Then
                MsgBox("Please enter a brief memo")
                mDescript.Focus()
                Exit Sub
            End If

            If txtReceiptno.Text = "" = True Then
                MsgBox("Please enter a brief memo")
                txtReceiptno.Focus()
                Exit Sub
            End If

            csal.InsertCashSales()

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

    End Sub

End Class

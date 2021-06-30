Public Class DebitMemoForm

    Dim dm As New DebitMemoClass
    Private rowIndex As Integer = 0
    Dim index As Integer

    Private Sub DebitMemoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            dm.CompInfo()
            dm.GetInvAcc()
            dm.LoadGridView()
            dm.GetCash()
            dm.FillCombo()
            dm.FillSaleNo()
            dm.FillBookNo()
            dm.FillCustName()
            dtSalesDate.DateTime = Date.Now
            dthistdate.Format = DateTimePickerFormat.Custom
            dthistdate.CustomFormat = "yyyy-MM-dd"
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
                    dm.GetData()
                'End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbodata_TextChanged(sender As Object, e As EventArgs) Handles cbodata.TextChanged
        Try
            dm.CheckData()
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

    Private Sub dgvsales_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvsales.CellBeginEdit
        Try
            dm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEndEdit
        Try
            dm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEnter
        Try
            dm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellLeave
        Try
            dm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Click(sender As Object, e As EventArgs) Handles dgvsales.Click
        Try
            dm.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_Enter(sender As Object, e As EventArgs) Handles dgvsales.Enter
        Try
            dm.CalGridData()
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
            dm.Getcustid()
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

            dm.InsertCashSales()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkvat_CheckedChanged(sender As Object, e As EventArgs) Handles chkvat.CheckedChanged
        Try
            If chkvat.Checked = True Then

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
            txtinwords.Text = ConvertNumberToENG(txtTotal.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcustid_TextChanged(sender As Object, e As EventArgs) Handles txtcustid.TextChanged
        Try
            dm.GetCustInfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            dm.InsertSupInv()
        Catch ex As Exception

        End Try
    End Sub

    Private Function ConvertNumberToENG(ByVal amount As String) As String

        Dim dollars, cents, temp
        Dim decimalPlace, count
        Dim place(9) As String
        place(2) = " Thousand "
        place(3) = " Million "
        place(4) = " Billion "
        place(5) = " Trillion "

        ' String representation of amount.
        amount = amount.Trim()
        amount = amount.Replace(",", "")
        ' Position of decimal place 0 if none.
        decimalPlace = amount.IndexOf(".")
        ' Convert cents and set string amount to dollar amount.
        If decimalPlace > 0 Then
            cents = GetTens(amount.Substring(decimalPlace + 1).PadRight(2, "0").Substring(0, 2))
            amount = amount.Substring(0, decimalPlace).Trim()
        End If

        count = 1
        Do While amount <> ""
            temp = GetHundreds(amount.Substring(Math.Max(amount.Length, 3) - 3))
            If temp <> "" Then dollars = temp & place(count) & dollars
            If amount.Length > 3 Then
                amount = amount.Substring(0, amount.Length - 3)
            Else
                amount = ""
            End If
            count = count + 1
        Loop

        Select Case dollars
            Case ""
                dollars = "No GHS"
            Case "One"
                dollars = "One GHS"
            Case Else
                dollars = dollars & " GHS"
        End Select

        Select Case cents
            Case ""
                cents = " "
            Case "One"
                cents = " "
            Case Else
                cents = " and " & cents & " "
        End Select

        ConvertNumberToENG = dollars & cents
    End Function

    ' Converts a number from 100-999 into text
    Function GetHundreds(ByVal amount As String) As String
        Dim Result As String
        If Not Integer.Parse(amount) = 0 Then
            amount = amount.PadLeft(3, "0")
            ' Convert the hundreds place.
            If amount.Substring(0, 1) <> "0" Then
                Result = GetDigit(amount.Substring(0, 1)) & " Hundred "
            End If
            ' Convert the tens and ones place.
            If amount.Substring(1, 1) <> "0" Then
                Result = Result & GetTens(amount.Substring(1))
            Else
                Result = Result & GetDigit(amount.Substring(2))
            End If
            GetHundreds = Result
        End If
    End Function

    ' Converts a number from 10 to 99 into text.
    Private Function GetTens(ByRef TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If TensText.StartsWith("1") Then   ' If value between 10-19...
            Select Case Integer.Parse(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Integer.Parse(TensText.Substring(0, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit(TensText.Substring(1, 1))  ' Retrieve ones place.
        End If
        GetTens = Result
    End Function

    ' Converts a number from 1 to 9 into text.
    Private Function GetDigit(ByRef Digit As String) As String
        Select Case Integer.Parse(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function

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

    '        cbodata.Text = ""
    '        TID.Text = ""

    '    Catch ex As Exception

    '    End Try
    'End Sub


End Class
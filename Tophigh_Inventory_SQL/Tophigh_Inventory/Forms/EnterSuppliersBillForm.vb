Public Class EnterSuppliersBillForm

    Dim spb As New SuppliersClass

    Private Sub EnterSuppliersBillForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            spb.FillBookNo()
            spb.FillSup()
            spb.CompInfo()
            spb.GetAPayable()
            spb.LoadBillsView()
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSupplier_TextChanged(sender As Object, e As EventArgs) Handles cboSupplier.TextChanged
        Try
            spb.GetSupid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsupid_TextChanged(sender As Object, e As EventArgs) Handles txtsupid.TextChanged
        Try
            spb.GetCustInfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBills_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvBills.CellBeginEdit
        Try
            spb.Calgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarSave.ItemClick
        Try

            dtBillDate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtBillDate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtBillDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtBillDate.Properties.CharacterCasing = CharacterCasing.Upper

            dtDueDate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtDueDate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtDueDate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtDueDate.Properties.CharacterCasing = CharacterCasing.Upper

            If cboSupplier.Text = "" Then
                MsgBox("Please select Supplier from the list")
                cboSupplier.Focus()
                Exit Sub
            End If

            If dtBillDate.Text = "" Then
                MsgBox("Please enter or select date")
                dtBillDate.Focus()
                Exit Sub
            End If

            If dtBillDate.Text = "" Then
                MsgBox("Please enter or select bill date")
                dtBillDate.Focus()
                Exit Sub
            End If

            If cboTerms.Text = "" Then
                MsgBox("Please select payment terms")
                cboTerms.Focus()
                Exit Sub
            End If

            spb.FillBookNo()
            spb.InsertSupInv()
            spb.Insertexpbill()
            spb.Insertdebitstat()
            spb.InsertExpenseBill()
            spb.CheckStoreStock()
            spb.CheckWarehStock()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarClose.ItemClick
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBills_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellEndEdit
        Try
            dgvBills.Columns(2).DefaultCellStyle.Format = "n2"
            spb.Calgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBills_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellEnter
        Try
            dgvBills.Columns(2).DefaultCellStyle.Format = "n2"
            spb.Calgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBills_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBills.CellLeave
        Try
            dgvBills.Columns(2).DefaultCellStyle.Format = "n2"
            spb.Calgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvBills_Click(sender As Object, e As EventArgs) Handles dgvBills.Click
        Try
            dgvBills.Columns(2).DefaultCellStyle.Format = "n2"
            spb.Calgrid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            txttime.Text = TimeString.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnClear.ItemClick
        Try
            spb.RefreshData()
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

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        Try
            txtinwords.Text = ""
            Dim word As String = ConvertNumberToENG(txtAmount.Text)
            txtinwords.Text = word.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtAmount_EditValueChanged(sender As Object, e As EventArgs) Handles txtAmount.EditValueChanged
        Try
            txtinwords.Text = ""
            Dim word As String = ConvertNumberToENG(txtAmount.Text)
            txtinwords.Text = word.ToString
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class SalesForm

    Dim inv As New Stock2Class

    Private Sub SalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            inv.GetSalesNum()
            inv.GetProducts()
            inv.GetCashAcc()
            inv.GetIncomeAcc()
            inv.LoadGridView()
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboproduct_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboproduct.SelectedIndexChanged
        Try
            inv.FillDataBox()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboproduct_TextChanged(sender As Object, e As EventArgs) Handles cboproduct.TextChanged
        Try
            inv.FillDataBox()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lbltimer.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtqty_Leave(sender As Object, e As EventArgs) Handles txtqty.Leave
        Try
            Dim tot1 As Double = txtprice.Text
            Dim tot2 As Double = txtqty.Text
            Dim results As Double = tot1 * tot2
            txtamount.Text = results
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellContentClick
        Try
            inv.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEndEdit
        Try
            inv.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellEnter
        Try
            inv.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvsales.CellLeave
        Try
            inv.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvsales_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvsales.MouseClick
        Try
            inv.CalGridData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Try
            inv.GetData()
            cboproduct.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        Try
            cboproduct.Text = ""
            txtqty.Text = "1"
            txtprice.Text = "0.00"
            txtamount.Text = "0.00"
            inv.GetSalesNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtreceived_Leave(sender As Object, e As EventArgs) Handles txtreceived.Leave
        Try

            txtreceived.Text = Format(txtreceived.Text, "Standard")

            Dim ft As Double = txtnet.Text
            Dim rec As Double = txtreceived.Text
            Dim rels As Double = rec - ft
            txtchange.Text = rels

            If rec < ft Then
                btnsaveprint.Enabled = False
                MsgBox("Amount entered is below net total")
                txtreceived.Focus()
                Exit Sub
            ElseIf rec > ft Or rec = ft Then
                btnsaveprint.Enabled = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsaveprint_Click(sender As Object, e As EventArgs) Handles btnsaveprint.Click
        Try
            dtDate.Format = DateTimePickerFormat.Custom
            dtDate.CustomFormat = "yyyy-MM-dd"

            inv._saleId = txtCode.Text
            inv._sale_date = dtDate.Value
            inv._amt_rec = txtreceived.Text
            inv._change = txtchange.Text
            inv._pup_class = txtclass.Text
            inv._users = MainForm.lbluser.Text
            inv._cashname = txtcash.Text
            inv._debit = txtnet.Text
            inv._timer = lbltimer.Text
            inv._location = MainForm.lbllocation.Text
            inv._revname = txtrev.Text
            inv._comp = txtcomp.Text

            inv.InsertCashSales()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtchange_TextChanged(sender As Object, e As EventArgs) Handles txtchange.TextChanged
        Try
            txtchange.Text = Format(txtchange.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

End Class
Public Class Stock2Form

    Dim stk As New stock2class
    Private Sub Stock2Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            stk.GetInv()
            stk.GetOp()
            txtinv.Text = stk._inv_acc
            txtequ.Text = stk._equ_acc
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try

            dtdate.Format = DateTimePickerFormat.Custom
            dtdate.CustomFormat = "yyyy-MM-dd"

            If txtproduct.Text = "" Then
                MsgBox("Enter product name")
                txtproduct.Focus()
                Exit Sub
            End If

            stk._hist_date = dtdate.Value
            stk._product = txtproduct.Text
            stk.current_qty = txtqty.Text
            stk._unit_cost = txtcost.Text
            stk._sales_price = txtprice.Text
            stk.ent_time = lbltime.Text
            stk._sys_user = MainForm.lbluser.Text
            stk._user_location = MainForm.lbllocation.Text
            stk._inv_acc = txtinv.Text
            stk._equ_acc = txtequ.Text

            stk.AddNewWarehouse()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lbltime.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Try
            txtproduct.Text = ""
            txtqty.Text = "0"
            txtcost.Text = "0.00"
            txtprice.Text = "0.00"
        Catch ex As Exception

        End Try
    End Sub

End Class
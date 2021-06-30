Public Class XtraItemsForm

    Dim pritm As New ItemsClass

    Private Sub XtraItemsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pritm.FillCate()
            pritm.FillSup()
            pritm.GetInv()
            pritm.GetOp()
            pritm.GetType()
            pritm.Getlocation()
            Timer1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            dtmanudate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtmanudate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtmanudate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtmanudate.Properties.CharacterCasing = CharacterCasing.Upper

            dtexpirdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtexpirdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtexpirdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtexpirdate.Properties.CharacterCasing = CharacterCasing.Upper

            dtpurchasedate.Format = DateTimePickerFormat.Custom
            dtpurchasedate.CustomFormat = "yyyy-MM-dd"

            pritm.insert_stock_hist()
            pritm.AddNewWarehouse()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            pritm.Cleartext()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtunitcost_Leave(sender As Object, e As EventArgs) Handles txtunitcost.Leave
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtsalesprice_Leave(sender As Object, e As EventArgs) Handles txtsalesprice.Leave
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub totpieces()

        Try

            Dim t1 As Integer = txtqtybox.Text
            Dim t2 As Integer = txtqtyin.Text
            Dim t3 As Integer = txtpiece.Text
            Dim t4 As Integer = (t2 * t1) + t3

            txttotP.Text = t4

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtqtybox_TextChanged(sender As Object, e As EventArgs) Handles txtqtybox.TextChanged
        Try
            totpieces()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtpiece_TextChanged(sender As Object, e As EventArgs) Handles txtpiece.TextChanged
        Try
            totpieces()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtqtyin_TextChanged(sender As Object, e As EventArgs) Handles txtqtyin.TextChanged
        Try
            totpieces()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            lbltimer.Text = TimeString
        Catch ex As Exception

        End Try
    End Sub
End Class
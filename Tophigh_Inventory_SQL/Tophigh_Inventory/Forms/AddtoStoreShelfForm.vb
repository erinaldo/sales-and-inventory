Public Class AddtoStoreShelfForm

    Dim itm As New ItemsClass

    Private Sub AddtoStoreShelfForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.Getshelflocation()
            itm.FillStoreShelfCombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitems_TextChanged(sender As Object, e As EventArgs) Handles cboitems.TextChanged
        Try
            itm.FillCurStock()
            itm.shelfCheckitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnadd_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnadd.ItemClick
        Try

            dtdate.Format = DateTimePickerFormat.Custom
            dtdate.CustomFormat = "yyyy-MM-dd"

            If txtorderpoint.Text = "0" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If txtbarcode.Text = "" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If txtitemtype.Text = "" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If cboitems.Text = "" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If txtsaleprice.Text = "0.00" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If cbostorelocation.Text = "" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            If cbowarelocation.Text = "" = True Then
                MsgBox("Please check if all entries is correct.")
                Exit Sub
                cboitems.Properties.AllowFocused = True
            End If

            itm.CheckmyShlev()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncancel.ItemClick
        Try
            itm.ClearShelve()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboitems.SelectedIndexChanged
        Try
            itm.FillCurStock()
            itm.shelfCheckitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtmemprice_TextChanged(sender As Object, e As EventArgs) Handles txtmemprice.TextChanged
        Try
            txtmemprice.Text = Format(txtmemprice.Text, "Standard")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtitemtype_TextChanged(sender As Object, e As EventArgs) Handles txtitemtype.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        Try
            'MsgBox(txtID.Text)
        Catch ex As Exception

        End Try
    End Sub
End Class
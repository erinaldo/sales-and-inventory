Public Class DeffectiveItemsForm

    Dim itm As New ItemsClass

    Private Sub DeffectiveItemsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.Getlocation()
            itm.FillCombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboitems_TextChanged(sender As Object, e As EventArgs) Handles cboitems.TextChanged
        Try
            itm.MyCheckitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSave.ItemClick
        Try

            txtmdate.Format = DateTimePickerFormat.Custom
            txtmdate.CustomFormat = "yyyy-MM-dd"

            txtedate.Format = DateTimePickerFormat.Custom
            txtedate.CustomFormat = "yyyy-MM-dd"

            txtpdate.Format = DateTimePickerFormat.Custom
            txtpdate.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try
        Try
            itm.insertdeffectitems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCancel.ItemClick
        Try
            itm.ClearDefect()
        Catch ex As Exception

        End Try
    End Sub
End Class
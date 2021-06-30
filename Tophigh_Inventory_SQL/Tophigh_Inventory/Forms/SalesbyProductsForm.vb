Public Class SalesbyProductsForm

    Dim csal As New POSClass
    Private Sub SalesbyProductsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            csal.CompInfo()
            csal.GetSalesbyItems()
            csal.FillDirectCombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesbyItems_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            csal.GetSalesbyItems()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            If cboproduct.Text = "" = False Then
                csal.GetSalesByDateProd()
            Else
                csal.GetSalesByDate()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
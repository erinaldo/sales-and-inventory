Public Class ProductListingForm

    Dim pl As New ItemsClass

    Private Sub ProductListingForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pl.GetProductList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProductListingForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
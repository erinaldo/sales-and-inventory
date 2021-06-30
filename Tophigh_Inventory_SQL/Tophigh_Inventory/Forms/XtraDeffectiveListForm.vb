Public Class XtraDeffectiveListForm

    Dim itm As New ItemsClass

    Private Sub XtraDeffectiveListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            itm.LoadDeffectiveList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            itm.LoadDeffectiveList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            DeffectiveItemsForm.Show()
            DeffectiveItemsForm.MdiParent = MainForm
            DeffectiveItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraDeffectiveListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
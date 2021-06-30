Public Class OtherCustListForm

    Dim cus As New CustomerClass

    Private Sub OtherCustListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cus.LoadOtherCustList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OtherCustListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            cus.LoadOtherCustList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

    End Sub

    Private Sub dgvEmpList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpList.CellContentClick

    End Sub
End Class
Public Class ItemsList

    Dim csal As New InvoiceClass

    Private Sub ItemsList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            If MainForm.txtrole.Text = "Admin" = True Then
                csal.LoadAdminCount()
                csal.GetItemListAdmin()
            Else
                csal.LoadStoreCount()
                csal.GetItemList()
            End If

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ItemsList_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            csal.GetItemList()
        Catch ex As Exception

        End Try
    End Sub
End Class
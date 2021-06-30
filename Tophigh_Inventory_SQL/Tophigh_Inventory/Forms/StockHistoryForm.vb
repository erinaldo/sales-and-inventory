Public Class StockHistoryForm

    Dim stk As New ItemsClass
    Private Sub StockHistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            stk.GetStockHistory()

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub StockHistoryForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub
End Class
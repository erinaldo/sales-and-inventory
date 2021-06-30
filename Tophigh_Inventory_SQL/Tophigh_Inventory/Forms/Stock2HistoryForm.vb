Public Class Stock2HistoryForm

    Dim stk As New Stock2Class

    Private Sub Stock2HistoryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            stk.GetStockHistory()
        Catch ex As Exception

        End Try
    End Sub
End Class
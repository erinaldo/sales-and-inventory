Public Class SalesChart

    Dim csal As New CashSalesClass

    Private Sub SalesChart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim YearTrial = Year(Now)
            lblyears.Text = YearTrial

            csal.GetSalesbyYear()
            csal.GetSalesbylocations()
            csal.GetFastmovingproducts()

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesChart_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
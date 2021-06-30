Public Class IncomeStatementForm

    Dim inc As New IncomeStatementClass

    Private Sub IncomeStatementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtAsOfDate.Text = Date.Now.Date
            inc.CompInfo()
            inc.IncomeReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub IncomeStatementForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try


            dtdatefrom.Format = DateTimePickerFormat.Custom
            dtdatefrom.CustomFormat = "yyyy-MM-dd"

            dtdateto.Format = DateTimePickerFormat.Custom
            dtdateto.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

        Try
            inc.IncomeDate()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtdateto.ValueChanged
        Try
            txtAsOfDate.Text = dtdateto.Value.Date
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try
            txtAsOfDate.Text = Date.Now.Date
            inc.IncomeReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
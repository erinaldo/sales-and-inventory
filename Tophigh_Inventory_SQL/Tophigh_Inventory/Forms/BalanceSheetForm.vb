Public Class BalanceSheetForm

    Dim bal As New BalanceSheetClass

    Private Sub BalanceSheetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtAsOfDate.Text = Date.Now.Date
            bal.CompInfo()
            bal.BalanceSheetReport()
        Catch ex As Exception

        End Try

        Try


            dtPrevFrom.Format = DateTimePickerFormat.Custom
            dtPrevFrom.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BalanceSheetForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

            Dim today = dtdatefrom.Value

            dtPrevYear.Value = today

            Dim Mytoday = dtPrevYear.Value
            Dim Youanswer = Mytoday.AddMonths(-1)

            dtPrevYear.Value = Youanswer


            Dim Youtoday = dtPrevYear.Value
            Dim YouDays = Youtoday.AddDays(30)

            dtPrevYear.Value = YouDays

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

            Dim years As Integer = dtdateto.Value.ToString("yyyy")
            lblYear.Text = years
            lblPrevYear.Text = years - 1

        Catch ex As Exception

        End Try

        Try
            bal.BalanceSheetDate()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtdateto.ValueChanged
        Try

            Dim today = dtdatefrom.Value

            dtPrevYear.Value = today

            Dim Mytoday = dtPrevYear.Value
            Dim Youanswer = Mytoday.AddMonths(-1)

            dtPrevYear.Value = Youanswer


            Dim Youtoday = dtPrevYear.Value
            Dim YouDays = Youtoday.AddDays(30)

            dtPrevYear.Value = YouDays

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

            dtPrevDateTo.Format = DateTimePickerFormat.Custom
            dtPrevDateTo.CustomFormat = "yyyy-MM-dd"

            Dim years As Integer = dtdateto.Value.ToString("yyyy")
            lblYear.Text = years
            lblPrevYear.Text = years - 1

            txtAsOfDate.Text = dtdateto.Value.Date

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtdatefrom.ValueChanged
        Try

            Dim todays = dtdatefrom.Value
            Dim Myanswers = todays.AddYears(-1)
            dtPrevDateFrom.Value = Myanswers

            dtPrevDateFrom.Format = DateTimePickerFormat.Custom
            dtPrevDateFrom.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try
            txtAsOfDate.Text = Date.Now.Date
            bal.BalanceSheetReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
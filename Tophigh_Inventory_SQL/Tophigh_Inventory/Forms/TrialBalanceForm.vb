Public Class TrialBalanceForm

    Dim tb As New TrialBalClass

    Private Sub TrialBalanceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtAsOfDate.Text = Date.Now.Date
            tb.CompInfo()
            tb.TrialBalReport()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrialBalanceForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        Try

            txtcheckme.Text = btnsearch.Text

            Dim month As Integer = dtdateto.Value.Month
            lblMonths.Text = month

            Dim years As Integer = dtdateto.Value.ToString("yyyy")
            lblMyYear.Text = years

        Catch ex As Exception

        End Try

        Try

            dtdatefrom.Format = DateTimePickerFormat.Custom
            dtdatefrom.CustomFormat = "yyyy-MM-dd"

            dtdateto.Format = DateTimePickerFormat.Custom
            dtdateto.CustomFormat = "yyyy-MM-dd"

            tb.CompInfo()

        Catch ex As Exception

        End Try

        Try

            Dim today = dtdatefrom.Value

            dtPrevYear.Value = today

            Dim Myanswer = today.AddMonths(-1)
            dtPrevYear.Value = Myanswer

            Dim Youtoday = dtPrevYear.Value
            Dim YouDays = Youtoday.AddDays(30)

            dtPrevYear.Value = YouDays

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

            tb.TrialBalDate()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub dtDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtdateto.ValueChanged

        Try
            txtAsOfDate.Text = dtdateto.Value.Date
        Catch ex As Exception

        End Try

        Try

            Dim month As Integer = dtdateto.Value.Month
            lblMonths.Text = month

            Dim years As Integer = dtdateto.Value.ToString("yyyy")
            lblMyYear.Text = years

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DtDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtdatefrom.ValueChanged

        Try

            Dim today = dtdatefrom.Value

            dtPrevYear.Value = today

            Dim Myanswer = today.AddMonths(-1)
            dtPrevYear.Value = Myanswer

            Dim Youtoday = dtPrevYear.Value
            Dim YouDays = Youtoday.AddDays(30)

            dtPrevYear.Value = YouDays

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"


            Dim todays = dtdatefrom.Value
            Dim Myanswers = todays.AddYears(-1)
            dtPrevDateFrom.Value = Myanswers

            dtPrevDateFrom.Format = DateTimePickerFormat.Custom
            dtPrevDateFrom.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try
            txtAsOfDate.Text = Date.Now.Date
            tb.TrialBalReport()
        Catch ex As Exception

        End Try
    End Sub
End Class
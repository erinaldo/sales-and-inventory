Public Class ChangeInEquityForm

    Dim cheq As New ChangeInEquityClass

    Private Sub ChangeInEquityForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            txtAsOfDate.Text = Date.Now.Date

            cheq.CompInfo()
            cheq.ChangeInEquityReport()
        Catch ex As Exception

        End Try

        Try


            dtPrevFrom.Format = DateTimePickerFormat.Custom
            dtPrevFrom.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try


    End Sub

    Private Sub ChangeInEquityForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try

            Dim yr2 = dtdatefrom.Value.Year
            lblintyear2.Text = yr2

            lblintyear1.Text = lblintyear2.Text - 1

            Dim today = dtdatefrom.Value
            Dim Myanswer = today.AddYears(-1)
            dtDateFro2017.Value = Myanswer

            dtDateFro2017.Format = DateTimePickerFormat.Custom
            dtDateFro2017.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

        Try

            Dim today = dtdateto.Value
            Dim Myanswer = today.AddYears(-2)
            dtDateTo2016.Value = Myanswer

            dtDateTo2016.Format = DateTimePickerFormat.Custom
            dtDateTo2016.CustomFormat = "yyyy-MM-dd"

            Dim todays = dtdateto.Value
            Dim Myanswers = today.AddYears(-1)
            dtDateTo2017.Value = Myanswers

            dtDateTo2017.Format = DateTimePickerFormat.Custom
            dtDateTo2017.CustomFormat = "yyyy-MM-dd"

            txtAsOfDate.Text = dtdateto.Value.Date

        Catch ex As Exception

        End Try

        Try

            dtdatefrom.Format = DateTimePickerFormat.Custom
            dtdatefrom.CustomFormat = "yyyy-MM-dd"

            dtdateto.Format = DateTimePickerFormat.Custom
            dtdateto.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

        Try

            Dim today = dtdateto.Value
            Dim Myanswer = today.AddYears(-1)
            dtPrevYear.Value = Myanswer

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

        Try
            cheq.ChangeInEquityDate()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtdateto.ValueChanged
        Try

            Dim today = dtdateto.Value
            Dim Myanswer = today.AddYears(-2)
            dtDateTo2016.Value = Myanswer

            dtDateTo2016.Format = DateTimePickerFormat.Custom
            dtDateTo2016.CustomFormat = "yyyy-MM-dd"

            Dim todays = dtdateto.Value
            Dim Myanswers = today.AddYears(-1)
            dtDateTo2017.Value = Myanswers

            dtDateTo2017.Format = DateTimePickerFormat.Custom
            dtDateTo2017.CustomFormat = "yyyy-MM-dd"

            txtAsOfDate.Text = dtdateto.Value.Date

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtdatefrom.ValueChanged

        Try

            Dim today = dtdatefrom.Value
            Dim Myanswer = today.AddYears(-1)
            dtDateFro2017.Value = Myanswer

            dtDateFro2017.Format = DateTimePickerFormat.Custom
            dtDateFro2017.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try

            txtAsOfDate.Text = Date.Now.Date

            cheq.ChangeInEquityReport()

        Catch ex As Exception

        End Try
    End Sub
End Class
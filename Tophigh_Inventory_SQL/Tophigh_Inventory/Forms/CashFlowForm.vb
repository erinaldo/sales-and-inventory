Public Class CashFlowForm

    Dim chf As New CashFlowClass

    Private Sub CashFlowForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            txtAsOfDate.Text = Date.Now.Date

            chf.CompInfo()
            chf.CashFlowReport()
        Catch ex As Exception

        End Try

        Try


            dtPrePrevTo.Format = DateTimePickerFormat.Custom
            dtPrePrevTo.CustomFormat = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CashFlowForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
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

            Dim today = dtdateto.Value
            Dim Myanswer = today.AddYears(-1)
            dtPrevYear.Value = Myanswer

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

            Dim years As Integer = dtdateto.Value.ToString("yyyy")
            lblYear.Text = years
            lblPrevYear.Text = years - 1

        Catch ex As Exception

        End Try

        Try
            chf.CashFlowDate()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dtDateTo_ValueChanged(sender As Object, e As EventArgs) Handles dtdateto.ValueChanged
        Try

            Dim today = dtdateto.Value
            Dim Myanswer = today.AddYears(-1)
            Dim Myanswers = today.AddYears(-2)
            dtPrevYear.Value = Myanswer
            dtPrePrevTo.Value = Myanswers

            dtPrevYear.Format = DateTimePickerFormat.Custom
            dtPrevYear.CustomFormat = "yyyy-MM-dd"

            dtPrePrevTo.Format = DateTimePickerFormat.Custom
            dtPrePrevTo.CustomFormat = "yyyy-MM-dd"

            txtAsOfDate.Text = dtdateto.Value.Date

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtDateFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtdatefrom.ValueChanged
        Try

            Dim today = dtdatefrom.Value
            Dim Myanswer = today.AddYears(-1)

            dtPrevDateFrom.Value = Myanswer

            dtPrevDateFrom.Format = DateTimePickerFormat.Custom
            dtPrevDateFrom.CustomFormat = "yyyy-MM-dd"


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRefresh.ItemClick
        Try

            txtAsOfDate.Text = Date.Now.Date

            chf.CashFlowReport()

        Catch ex As Exception

        End Try
    End Sub
End Class
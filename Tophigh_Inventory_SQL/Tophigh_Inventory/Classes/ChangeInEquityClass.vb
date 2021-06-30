Imports System.Configuration
Imports System.Data.SqlClient

Public Class ChangeInEquityClass

    Public Sub ChangeInEquityReport()

        Try

            Dim YearTrial = Year(Now)
            ChangeInEquityForm.lblYear.Text = YearTrial
            ChangeInEquityForm.lblPrevYear2017.Text = YearTrial - 1
            ChangeInEquityForm.lblPrevYear2016.Text = YearTrial - 2

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetEqityChangeCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@PrevDate2016", SqlDbType.Int).Value = ChangeInEquityForm.lblPrevYear2016.Text
                    cmd.Parameters.Add("@PrevDate2017", SqlDbType.Int).Value = ChangeInEquityForm.lblPrevYear2017.Text
                    cmd.Parameters.Add("@Date2018", SqlDbType.Int).Value = ChangeInEquityForm.lblYear.Text
                    sda.SelectCommand = cmd
                    Using dsChangeEquity As New DataSet

                        sda.Fill(dsChangeEquity, "GetEqityChangeCurYear")

                        Dim report As New ChangeEquityRep
                        report.DataSource = dsChangeEquity
                        report.DataMember = "ChangeEquity"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = ChangeInEquityForm.txtComp.Text
                        report.MyAsofDate.Value = ChangeInEquityForm.txtAsOfDate.Text
                        report.myCurDate.Value = ChangeInEquityForm.lblYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.CreateDocument()
                        ChangeInEquityForm.TrialBalViewer.DocumentSource = report
                        ChangeInEquityForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub


    Public Sub ChangeInEquityDate()

        Try

            Dim YearTrial = Year(Now)
            ChangeInEquityForm.lblYear.Text = YearTrial
            ChangeInEquityForm.lblPrevYear2017.Text = YearTrial - 1
            ChangeInEquityForm.lblPrevYear2016.Text = YearTrial - 2

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetEqityChangeByDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@PrevDate2016", SqlDbType.Date).Value = ChangeInEquityForm.dtDateTo2016.Text
                    cmd.Parameters.Add("@PrevDatefrom2017", SqlDbType.Date).Value = ChangeInEquityForm.dtDateFro2017.Text
                    cmd.Parameters.Add("@PrevDateTo2017", SqlDbType.Date).Value = ChangeInEquityForm.dtDateTo2017.Text
                    cmd.Parameters.Add("@DateCurFro2018", SqlDbType.Date).Value = ChangeInEquityForm.dtdatefrom.Text
                    cmd.Parameters.Add("@DateCurTo2018", SqlDbType.Date).Value = ChangeInEquityForm.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsChangeEquity As New DataSet

                        sda.Fill(dsChangeEquity, "GetEqityChangeByDate")

                        Dim report As New ChangeEquityRep
                        report.DataSource = dsChangeEquity
                        report.DataMember = "ChangeEquity"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = ChangeInEquityForm.txtComp.Text
                        report.MyAsofDate.Value = ChangeInEquityForm.txtAsOfDate.Text
                        report.myCurDate.Value = ChangeInEquityForm.lblYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.CreateDocument()
                        ChangeInEquityForm.TrialBalViewer.DocumentSource = report
                        ChangeInEquityForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Public Sub CompInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select com_name,street,city,country,phone,email,website from company_t"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, strt, cty, cunt, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("com_name")
                strt = dr.Item("street")
                cty = dr.Item("city")
                cunt = dr.Item("country")
                WorkFon = dr.Item("phone")
                email = dr.Item("email")
                web = dr.Item("website")

                ChangeInEquityForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class

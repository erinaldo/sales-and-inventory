Imports System.Configuration
Imports System.Data.SqlClient

Public Class BalanceSheetClass

    Public Sub BalanceSheetReport()

        Try

            Dim YearTrial = Year(Now)
            BalanceSheetForm.lblYear.Text = YearTrial
            BalanceSheetForm.lblPrevYear.Text = YearTrial - 1
            BalanceSheetForm.lblPrevYear2017.Text = YearTrial - 1
            BalanceSheetForm.lblPrevYear2016.Text = YearTrial - 2

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetBalShtCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@CurDate", SqlDbType.BigInt).Value = BalanceSheetForm.lblYear.Text
                    sda.SelectCommand = cmd
                    Using dsBalanceSheet As New DataSet

                        sda.Fill(dsBalanceSheet, "GetBalShtCurYear")

                        Dim report As New BalanceSheetRep
                        report.DataSource = dsBalanceSheet
                        report.DataMember = "BalanceSheet"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = BalanceSheetForm.txtComp.Text
                        report.MyAsofDate.Value = BalanceSheetForm.txtAsOfDate.Text
                        report.myCurDate.Value = BalanceSheetForm.lblYear.Text
                        report.myPrevDate.Value = BalanceSheetForm.lblPrevYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.myPrevDate.Visible = False
                        report.CreateDocument()
                        BalanceSheetForm.TrialBalViewer.DocumentSource = report
                        BalanceSheetForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try


    End Sub


    Public Sub BalanceSheetDate()

        Try

            Dim CurYear As Integer = BalanceSheetForm.dtdateto.Value.Year
            Dim PrevYear As Integer = BalanceSheetForm.dtPrevDateTo.Value.Year

            BalanceSheetForm.lblPrevYear2017.Text = CurYear
            BalanceSheetForm.lblPrevYear2016.Text = PrevYear

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetBalShtByDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = BalanceSheetForm.dtdatefrom.Text
                    cmd.Parameters.Add("@Dateto", SqlDbType.Date).Value = BalanceSheetForm.dtdateto.Text
                    cmd.Parameters.Add("@PrevDate", SqlDbType.Date).Value = BalanceSheetForm.dtPrevDateFrom.Text
                    cmd.Parameters.Add("@PrevDateto", SqlDbType.Date).Value = BalanceSheetForm.dtPrevYear.Text
                    sda.SelectCommand = cmd
                    Using dsBalanceSheet As New DataSet

                        sda.Fill(dsBalanceSheet, "GetBalShtByDate")

                        Dim report As New BalanceSheetRep
                        report.DataSource = dsBalanceSheet
                        report.DataMember = "BalanceSheet"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = BalanceSheetForm.txtComp.Text
                        report.MyAsofDate.Value = BalanceSheetForm.txtAsOfDate.Text
                        report.myCurDate.Value = BalanceSheetForm.lblYear.Text
                        report.myPrevDate.Value = BalanceSheetForm.lblPrevYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.myPrevDate.Visible = False
                        report.CreateDocument()
                        BalanceSheetForm.TrialBalViewer.DocumentSource = report
                        BalanceSheetForm.TrialBalViewer.Refresh()


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

                BalanceSheetForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class


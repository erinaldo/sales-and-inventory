Imports System.Configuration
Imports System.Data.SqlClient

Public Class CashFlowClass

    Public Sub CashFlowReport()

        Try

            Dim YearTrial = Year(Now)
            CashFlowForm.lblYear.Text = YearTrial
            CashFlowForm.lblPrevYear.Text = YearTrial - 1
            CashFlowForm.lblPrePrevYear.Text = YearTrial - 2

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetCashFlowCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Dateto", SqlDbType.Int).Value = CashFlowForm.lblYear.Text
                    cmd.Parameters.Add("@PrevDateto", SqlDbType.Int).Value = CashFlowForm.lblPrevYear.Text
                    cmd.Parameters.Add("@PrePrevDateto", SqlDbType.Int).Value = CashFlowForm.lblPrePrevYear.Text
                    sda.SelectCommand = cmd
                    Using dsCashFlow As New DataSet

                        sda.Fill(dsCashFlow, "GetCashFlowCurYear")

                        Dim report As New CashFlowRep
                        report.DataSource = dsCashFlow
                        report.DataMember = "CashFlow"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = CashFlowForm.txtComp.Text
                        report.MyAsofDate.Value = CashFlowForm.txtAsOfDate.Text
                        report.myCurDate.Value = CashFlowForm.lblYear.Text
                        report.myPrevDate.Value = CashFlowForm.lblPrevYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.myPrevDate.Visible = False
                        report.CreateDocument()
                        CashFlowForm.TrialBalViewer.DocumentSource = report
                        CashFlowForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub


    Public Sub CashFlowDate()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetCashFlowByDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = CashFlowForm.dtdatefrom.Text
                    cmd.Parameters.Add("@Dateto", SqlDbType.Date).Value = CashFlowForm.dtdateto.Text
                    cmd.Parameters.Add("@PrevDate", SqlDbType.Date).Value = CashFlowForm.dtPrevDateFrom.Text
                    cmd.Parameters.Add("@PrevDateto", SqlDbType.Date).Value = CashFlowForm.dtPrevYear.Text
                    cmd.Parameters.Add("@PrePrevDateto", SqlDbType.Date).Value = CashFlowForm.dtPrePrevTo.Text
                    sda.SelectCommand = cmd
                    Using dsCashFlow As New DataSet

                        sda.Fill(dsCashFlow, "GetCashFlowByDate")

                        Dim report As New CashFlowRep
                        report.DataSource = dsCashFlow
                        report.DataMember = "CashFlow"
                        ' Obtain a parameter, and set its value.
                        report.MyComp.Value = CashFlowForm.txtComp.Text
                        report.MyAsofDate.Value = CashFlowForm.txtAsOfDate.Text
                        report.myCurDate.Value = CashFlowForm.lblYear.Text
                        report.myPrevDate.Value = CashFlowForm.lblPrevYear.Text
                        ' Hide the Parameters UI from end-users.
                        report.MyComp.Visible = False
                        report.MyAsofDate.Visible = False
                        report.myCurDate.Visible = False
                        report.myPrevDate.Visible = False
                        report.CreateDocument()
                        CashFlowForm.TrialBalViewer.DocumentSource = report
                        CashFlowForm.TrialBalViewer.Refresh()

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

                CashFlowForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class

Imports System.Configuration
Imports System.Data.SqlClient

Public Class IncomeStatementClass

    Public Sub IncomeReport()

        Try

            Dim YearTrial = Year(Now)
            IncomeStatementForm.lblYear.Text = YearTrial

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetIncStaCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Dateto", SqlDbType.Int).Value = IncomeStatementForm.lblYear.Text
                    sda.SelectCommand = cmd
                    Using dsIncomeStatement As New DataSet

                        sda.Fill(dsIncomeStatement, "GetIncStaCurYear")

                        Dim report As New IncStatement_Rep
                        report.DataSource = dsIncomeStatement
                        report.DataMember = "IncomeStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = IncomeStatementForm.txtComp.Text
                        report.MyAsOfDate.Value = IncomeStatementForm.txtAsOfDate.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.MyAsOfDate.Visible = False
                        report.CreateDocument()
                        IncomeStatementForm.TrialBalViewer.DocumentSource = report
                        IncomeStatementForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub


    Public Sub IncomeDate()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetIncStatbydate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = IncomeStatementForm.dtdatefrom.Text
                    cmd.Parameters.Add("@Dateto", SqlDbType.Date).Value = IncomeStatementForm.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsIncomeStatement As New DataSet

                        sda.Fill(dsIncomeStatement, "GetIncStatbydate")

                        Dim report As New IncStatement_Rep
                        report.DataSource = dsIncomeStatement
                        report.DataMember = "IncomeStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = IncomeStatementForm.txtComp.Text
                        report.MyAsOfDate.Value = IncomeStatementForm.txtAsOfDate.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.MyAsOfDate.Visible = False
                        report.CreateDocument()
                        IncomeStatementForm.TrialBalViewer.DocumentSource = report
                        IncomeStatementForm.TrialBalViewer.Refresh()


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

                IncomeStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub


End Class

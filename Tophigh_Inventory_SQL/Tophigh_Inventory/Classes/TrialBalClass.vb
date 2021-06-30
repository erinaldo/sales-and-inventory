Imports System.Configuration
Imports System.Data.SqlClient

Public Class TrialBalClass

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable

    Public Sub TrialBalReport()

        Try

            Dim YearTrial = Year(Now)
            TrialBalanceForm.lblYear.Text = YearTrial

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetTrialBalCurYear")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Dateto", SqlDbType.Int).Value = TrialBalanceForm.lblYear.Text
                    sda.SelectCommand = cmd
                    Using dsTrialBal As New DataSet

                        sda.Fill(dsTrialBal, "GetTrialBalCurYear")

                        Dim report As New XtraTrialBal_rep
                        report.DataSource = dsTrialBal
                        report.DataMember = "TrialBal"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = TrialBalanceForm.txtComp.Text
                        report.MyAsOfDate.Value = TrialBalanceForm.txtAsOfDate.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.MyAsOfDate.Visible = False
                        report.CreateDocument()
                        TrialBalanceForm.TrialBalViewer.DocumentSource = report
                        TrialBalanceForm.TrialBalViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Public Sub TrialBalDate()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetTrialBalByDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = TrialBalanceForm.dtdatefrom.Text
                    cmd.Parameters.Add("@Dateto", SqlDbType.Date).Value = TrialBalanceForm.dtdateto.Text
                    cmd.Parameters.Add("@PrevDateto", SqlDbType.Date).Value = TrialBalanceForm.dtPrevYear.Text
                    sda.SelectCommand = cmd
                    Using dsTrialBal As New DataSet

                        sda.Fill(dsTrialBal, "GetTrialBalByDate")

                        Dim report As New XtraTrialBal_rep
                        report.DataSource = dsTrialBal
                        report.DataMember = "TrialBal"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = TrialBalanceForm.txtComp.Text
                        report.MyAsOfDate.Value = TrialBalanceForm.txtAsOfDate.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.MyAsOfDate.Visible = False
                        report.CreateDocument()
                        TrialBalanceForm.TrialBalViewer.DocumentSource = report
                        TrialBalanceForm.TrialBalViewer.Refresh()


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

                TrialBalanceForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub


End Class

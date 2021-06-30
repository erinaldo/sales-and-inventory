Imports System.Configuration
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports DevExpress.Utils
Imports System
Imports System.Data
Imports System.Windows.Forms.DataVisualization.Charting
Imports Series = System.Windows.Forms.DataVisualization.Charting.Series
Public Class BankClass

    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String
    Dim sBuilder As SqlCommandBuilder
    Dim sTable As DataTable

    Dim dtInvoice As New DataTable("dtInvoice")

    Dim index As Integer

    Shared random As New Random()

    Public Sub FillSaleNo()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(coa_code)from chart_of_account_t where coa_sub_group='ASS'"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                BankSetupForm.txtcode.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                BankSetupForm.txtcode.Text = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertChart()

        InsertTemp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertChart"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = BankSetupForm.txtcode.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankSetupForm.txtaccname.Text
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = BankSetupForm.rbobank.Text
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = "ASS"
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = "BS"
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = "CABNE"
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "bank"
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertTemp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "inserTemp"}
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankSetupForm.txtaccname.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertBank()

        Try

            InsertOpenBal()

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = BankSetupForm.dtDate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = BankSetupForm.txtaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = BankSetupForm.txtaccnum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = BankSetupForm.txtnote.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = BankSetupForm.txtopenbal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = BankSetupForm.txtbankname.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertOpenBal()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbankObal"}
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = BankSetupForm.txtbankname.Text
            cmd.Parameters.Add("@account", SqlDbType.VarChar).Value = BankSetupForm.txtaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = BankSetupForm.txtaccnum.Text
            cmd.Parameters.Add("@openbal", SqlDbType.Float).Value = BankSetupForm.txtopenbal.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = BankSetupForm.cbolocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertjvBank()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankSetupForm.dtDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankSetupForm.txtaccname.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = BankSetupForm.txtopenbal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = BankSetupForm.cbolocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertEquity()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankSetupForm.dtDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankSetupForm.txtequity.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = BankSetupForm.txtopenbal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = BankSetupForm.cbolocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

        clearData()

    End Sub

    Public Sub Getequity()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='cp'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                BankSetupForm.txtequity.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getslocation()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT location FROM location_v group by location", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("location").ToString)
            End While
            rd.Close()
            conn.Close()

            BankSetupForm.cbolocation.Properties.Items.Clear()
            BankSetupForm.cbolocation.Properties.Items.Add("")
            BankSetupForm.cbolocation.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub clearData()
        Try
            BankSetupForm.txtnote.Text = ""
            BankSetupForm.txtaccname.Text = ""
            BankSetupForm.txtaccnum.Text = ""
            BankSetupForm.txtbankname.Text = ""
            BankSetupForm.txtopenbal.Text = "0.00"
            BankSetupForm.cbolocation.Text = ""

        Catch ex As Exception

        End Try
    End Sub

    Public Sub GetBankStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetBankbyAccBnk")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = bankstatement.cbobank.Text
                    cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = bankstatement.cboaccount.Text
                    sda.SelectCommand = cmd
                    Using dsbankstatement As New DataSet

                        sda.Fill(dsbankstatement, "GetBankbyAccBnk")

                        Dim report As New bankstatementRep
                        report.DataSource = dsbankstatement
                        report.DataMember = "bank"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = bankstatement.txtcomp.Text
                        report.pBank.Value = bankstatement.cbobank.Text
                        report.pAccNum.Value = bankstatement.txtaccnum.Text
                        report.pAccName.Value = bankstatement.cboaccount.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pBank.Visible = False
                        report.pAccNum.Visible = False
                        report.pAccName.Visible = False

                        report.CreateDocument()
                        bankstatement.StatementViewer.DocumentSource = report
                        bankstatement.StatementViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetBankStatementbyDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetBankbyAccBnkbDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = bankstatement.cbobank.Text
                    cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = bankstatement.cboaccount.Text
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = bankstatement.datefrom.Text
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = bankstatement.dateto.Text
                    sda.SelectCommand = cmd
                    Using dsbankstatement As New DataSet

                        sda.Fill(dsbankstatement, "GetBankbyAccBnkbDate")

                        Dim report As New bankstatementRep
                        report.DataSource = dsbankstatement
                        report.DataMember = "bank"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = bankstatement.txtcomp.Text
                        report.pBank.Value = bankstatement.cbobank.Text
                        report.pAccNum.Value = bankstatement.txtaccnum.Text
                        report.pAccName.Value = bankstatement.cboaccount.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pBank.Visible = False
                        report.pAccNum.Visible = False
                        report.pAccName.Visible = False

                        report.CreateDocument()
                        bankstatement.StatementViewer.DocumentSource = report
                        bankstatement.StatementViewer.Refresh()


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetBanks()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT bank FROM bank_t group by bank", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("bank").ToString)
            End While
            rd.Close()
            conn.Close()

            bankstatement.cbobank.Properties.Items.Clear()
            bankstatement.cbobank.Properties.Items.AddRange(names.ToArray)

            Transferforms.cbobnkfrom.Properties.Items.Clear()
            Transferforms.cbobnkfrom.Properties.Items.AddRange(names.ToArray)

            Transferforms.cbobnkto.Properties.Items.Clear()
            Transferforms.cbobnkto.Properties.Items.AddRange(names.ToArray)

            Deposit.cbobank.Properties.Items.Clear()
            Deposit.cbobank.Properties.Items.AddRange(names.ToArray)

            BankReconciliation.cbobank.Properties.Items.Clear()
            BankReconciliation.cbobank.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetAccName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT accname FROM bank_t group by accname", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("accname").ToString)
            End While
            rd.Close()
            conn.Close()

            bankstatement.cboaccount.Properties.Items.Clear()
            bankstatement.cboaccount.Properties.Items.AddRange(names.ToArray)

            Transferforms.cboAccFrom.Properties.Items.Clear()
            Transferforms.cboAccFrom.Properties.Items.AddRange(names.ToArray)

            Transferforms.cboAccTo.Properties.Items.Clear()
            Transferforms.cboAccTo.Properties.Items.AddRange(names.ToArray)

            Deposit.cboaccount.Properties.Items.Clear()
            Deposit.cboaccount.Properties.Items.AddRange(names.ToArray)

            BankReconciliation.cboaccname.Properties.Items.Clear()
            BankReconciliation.cboaccname.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetEquAccName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT Accounts FROM coa_v group by Accounts", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("Accounts").ToString)
            End While
            rd.Close()
            conn.Close()

            Deposit.cboequity.Properties.Items.Clear()
            Deposit.cboequity.Properties.Items.AddRange(names.ToArray)

            BankReconciliation.cboinexp.Properties.Items.Clear()
            BankReconciliation.cboinexp.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCheckAcc()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_sub_group from chart_of_account_t Where coa_name='" & BankReconciliation.cboinexp.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                BankReconciliation.txtcheck.Text = dr.Item("coa_sub_group")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetAccNum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select accnum from bank_t Where accname='" & bankstatement.cboaccount.Text & "' AND bank='" & bankstatement.cbobank.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                bankstatement.txtaccnum.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetBankReconAccNum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select accnum from bank_t Where accname='" & BankReconciliation.cboaccname.Text & "' AND bank='" & BankReconciliation.cbobank.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                BankReconciliation.txtaccnum.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetBankOpenBal()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select openbal from bank_open_bal_t Where account='" & BankReconciliation.cboaccname.Text & "' AND bank='" & BankReconciliation.cbobank.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                BankReconciliation.txtopenbal.Text = dr.Item("openbal")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetBankCurBal()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select sum(debit - credit) As Total  from bank_t Where accname='{0}' and bank='{1}'", BankReconciliation.cboaccname.Text, BankReconciliation.cbobank.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                BankReconciliation.txtcurbal.Text = dr.Item("Total")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetDepAccNum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select accnum from bank_t Where accname='" & Deposit.cboaccount.Text & "' AND bank='" & Deposit.cbobank.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Deposit.txtaccnum.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub CompInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select com_name,street,city,country,phone,email,website from company_t"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, strt, cty, cunt, WorkFon, email, web As String
            Const Empty As String = "  "

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("com_name")
                strt = dr.Item("street")
                cty = dr.Item("city")
                cunt = dr.Item("country")
                WorkFon = dr.Item("phone")
                email = dr.Item("email")
                web = dr.Item("website")

                bankstatement.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertBankTransfrom()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = Transferforms.dtdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = Transferforms.cboAccFrom.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = Transferforms.txtAccNumFrom.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = Transferforms.txtMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = Transferforms.txtAmt.Text
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = Transferforms.cbobnkfrom.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertBankTransTo()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = Transferforms.dtdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = Transferforms.cboAccTo.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = Transferforms.txtAccNumTo.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = Transferforms.txtMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = Transferforms.txtAmt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = Transferforms.cbobnkto.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertTransdebit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = Transferforms.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = Transferforms.cboAccTo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = Transferforms.txtAmt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertTransCredit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = Transferforms.dtdate.Text.Trim()
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = Transferforms.cboAccFrom.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = Transferforms.txtAmt.Text.Trim()
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

        clearMeData()

    End Sub

    Public Sub GetFromAccNum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select accnum from bank_t Where accname='" & Transferforms.cboAccFrom.Text & "' AND bank='" & Transferforms.cbobnkfrom.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Transferforms.txtAccNumFrom.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetToAccNum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select accnum from bank_t Where accname='" & Transferforms.cboAccTo.Text & "' AND bank='" & Transferforms.cbobnkto.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Transferforms.txtAccNumTo.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub clearMeData()

        Try
            Transferforms.cbobnkto.Text = ""
            Transferforms.cboAccFrom.Text = ""
            Transferforms.cboAccTo.Text = ""
            Transferforms.cbobnkfrom.Text = ""
            Transferforms.txtAmt.Text = "0.00"
            Transferforms.txtMemo.Text = ""
        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertBankDepodit()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = Deposit.dtdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = Deposit.cboaccount.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = Deposit.txtaccnum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = Deposit.txtMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = Deposit.txtamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = Deposit.cbobank.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertDepositdebit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = Deposit.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = Deposit.cboaccount.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = Deposit.txtamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertDepositcredit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = Deposit.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = Deposit.cboequity.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = Deposit.txtamt.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

        ClearDeposit()

    End Sub

    Public Sub ClearDeposit()
        Try
            Deposit.cboequity.Text = ""
            Deposit.cboaccount.Text = ""
            Deposit.cbobank.Text = ""
            Deposit.txtaccnum.Text = ""
            Deposit.txtamt.Text = "0.00"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub InsertBankRecoDebit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = BankReconciliation.cboaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = BankReconciliation.txtaccnum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = BankReconciliation.txtmemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = BankReconciliation.cbobank.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertBankRecoCredit()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = BankReconciliation.cboaccname.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = BankReconciliation.txtaccnum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = BankReconciliation.txtmemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = BankReconciliation.cbobank.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertTransBnkReconCredit()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankReconciliation.cboinexp.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

        clearRecon()

    End Sub

    Public Sub InsertTransBnkReconDebit()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankReconciliation.cboaccname.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try


    End Sub

    Public Sub InsertTransBnkReconCredit1()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankReconciliation.cboaccname.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try

        clearRecon()


    End Sub

    Public Sub InsertTransBnkReconDebit1()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = BankReconciliation.dtdate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = BankReconciliation.cboinexp.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = BankReconciliation.txtamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

        Catch ex As Exception

        End Try


    End Sub

    Public Sub clearRecon()

        Try
            BankReconciliation.cboaccname.Text = ""
            BankReconciliation.cbobank.Text = ""
            BankReconciliation.cboinexp.Text = ""
            BankReconciliation.txtaccnum.Text = ""
            BankReconciliation.txtamt.Text = "0.00"
            BankReconciliation.txtcurbal.Text = "0.00"
            BankReconciliation.txtmemo.Text = ""
            BankReconciliation.txtopenbal.Text = "0.00"
            BankReconciliation.txtcheck.Text = "0.00"
        Catch ex As Exception

        End Try

    End Sub

End Class

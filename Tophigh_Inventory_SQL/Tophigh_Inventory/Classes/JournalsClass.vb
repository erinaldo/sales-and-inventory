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
Imports DevExpress.XtraReports.UI

Public Class JournalsClass

    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String
    Dim sBuilder As SqlCommandBuilder
    Dim sTable As DataTable

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sDs As DataSet

    Shared random As New Random()

    Dim dtJournal As New DataTable("dtJournal")

    Dim index As Integer

    Public Sub GetCustNum()

        Try

            Dim i As Integer
            For i = 0 To 1000
                JournalEntry.txtentno.Text = (Convert.ToString(random.Next(10000, 20000)))
            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillBookNo()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(cash_code)from journal_voucher_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                JournalEntry.txtentno.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                JournalEntry.txtentno.Text = number
            End If

            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetAccount()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select coa_name from chart_of_account_t", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("coa_name").ToString)
            End While
            rd.Close()
            conn.Close()

            JournalEntry.cboaccount.Items.Clear()
            JournalEntry.cboaccount.Items.Add("")
            JournalEntry.cboaccount.Items.AddRange(names.ToArray)

            JournalEntry.cboCreditAcc.Items.Clear()
            JournalEntry.cboCreditAcc.Items.Add("")
            JournalEntry.cboCreditAcc.Items.AddRange(names.ToArray)

        Catch ex As System.Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub Getbankdatdeb()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select bank,accnum from bank_t where accname='" & JournalEntry.cboaccount.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                JournalEntry.txtbank.Text = dr.Item("bank")
                JournalEntry.txtaccnum.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getbankdatcred()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select bank,accnum from bank_t where accname='" & JournalEntry.cboCreditAcc.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                JournalEntry.txtcbank.Text = dr.Item("bank")
                JournalEntry.txtcaccnum.Text = dr.Item("accnum")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCheck()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_cogm from chart_of_account_t where coa_name='" & JournalEntry.cboaccount.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                JournalEntry.txtdebitchecck.Text = dr.Item("coa_cogm")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCreditCheck()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_cogm from chart_of_account_t where coa_name='" & JournalEntry.cboCreditAcc.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                JournalEntry.txtcreditcheck.Text = dr.Item("coa_cogm")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadGridView()

        Try

            dtJournal.Columns.Add("Date".ToString, GetType(String))
            dtJournal.Columns.Add("Account".ToString, GetType(String))
            dtJournal.Columns.Add("Description".ToString, GetType(String))
            dtJournal.Columns.Add("Debit".ToString, GetType(String))
            dtJournal.Columns.Add("Credit".ToString, GetType(String))
            dtJournal.Columns.Add("Check".ToString, GetType(String))
            dtJournal.Columns.Add("Bank".ToString, GetType(String))
            dtJournal.Columns.Add("AcNum".ToString, GetType(String))

            JournalEntry.dgvjournal.ReadOnly = True
            JournalEntry.dgvjournal.DataSource = dtJournal
            JournalEntry.dgvjournal.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            JournalEntry.dgvjournal.Columns(0).Width = 100
            JournalEntry.dgvjournal.Columns(1).Width = 167
            JournalEntry.dgvjournal.Columns(2).Width = 205
            JournalEntry.dgvjournal.Columns(3).Width = 100
            JournalEntry.dgvjournal.Columns(4).Width = 100
            JournalEntry.dgvjournal.Columns(5).Visible = False
            JournalEntry.dgvjournal.Columns(6).Visible = False
            JournalEntry.dgvjournal.Columns(7).Visible = False

            JournalEntry.dgvjournal.ForeColor = Color.Black

            JournalEntry.dgvjournal.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            JournalEntry.dgvjournal.DefaultCellStyle.SelectionForeColor = Color.Black
            JournalEntry.dgvjournal.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            JournalEntry.dgvjournal.AllowUserToResizeColumns = False
            JournalEntry.dgvjournal.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            JournalEntry.dgvjournal.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetData()

        Try


            If JournalEntry.dtentdate.Text <> "" AndAlso JournalEntry.cboaccount.Text <> "" AndAlso JournalEntry.txtdescription.Text <> "" AndAlso JournalEntry.txtdebit.Text <> "" AndAlso JournalEntry.txtcredit.Text <> "" AndAlso JournalEntry.txtdebitchecck.Text <> "" AndAlso JournalEntry.txtbank.Text <> "" AndAlso JournalEntry.txtaccnum.Text <> "" Then
                dtJournal.Rows.Add(JournalEntry.dtentdate.Text, JournalEntry.cboaccount.Text, JournalEntry.txtdescription.Text, JournalEntry.txtdebit.Text, JournalEntry.txtcredit.Text, JournalEntry.txtdebitchecck.Text, JournalEntry.txtbank.Text, JournalEntry.txtaccnum.Text)
            End If

            GetCredtData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCredtData()

        Try


            If JournalEntry.dtentdate.Text <> "" AndAlso JournalEntry.cboCreditAcc.Text <> "" AndAlso JournalEntry.txtdescription.Text <> "" AndAlso JournalEntry.txtcredit.Text <> "" AndAlso JournalEntry.txtdebit.Text <> "" AndAlso JournalEntry.txtdebitchecck.Text <> "" AndAlso JournalEntry.txtcbank.Text <> "" AndAlso JournalEntry.txtcaccnum.Text <> "" Then
                dtJournal.Rows.Add(JournalEntry.dtentdate.Text, JournalEntry.cboCreditAcc.Text, JournalEntry.txtdescription.Text, JournalEntry.txtcredit.Text, JournalEntry.txtdebit.Text, JournalEntry.txtcreditcheck.Text, JournalEntry.txtcbank.Text, JournalEntry.txtcaccnum.Text)
            End If

            JournalEntry.cboaccount.Text = ""
            JournalEntry.cboCreditAcc.Text = ""
            JournalEntry.txtdescription.Text = ""
            JournalEntry.txtdebit.Text = "0.00"
            JournalEntry.txtcredit.Text = "0.00"
            JournalEntry.txtdebitchecck.Text = ""
            JournalEntry.txtcreditcheck.Text = ""
            JournalEntry.txtcaccnum.Text = "kofi"
            JournalEntry.txtaccnum.Text = "kofi"
            JournalEntry.txtbank.Text = "kofi"
            JournalEntry.txtcbank.Text = "kofi"
            JournalEntry.txtdebitchecck.Text = "kofi"

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try


            Dim totalDeb As Double
            Dim totalCred As Double

            For i As Double = 0 To JournalEntry.dgvjournal.Rows.Count - 1
                totalDeb += JournalEntry.dgvjournal.Rows(i).Cells("Debit").Value
                totalCred += JournalEntry.dgvjournal.Rows(i).Cells("Credit").Value
            Next i

            JournalEntry.txtdebbal.Text = totalDeb.ToString("n2")
            JournalEntry.txtcrebal.Text = totalCred.ToString("n2")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearJv()
        Try

            JournalEntry.cboaccount.Text = ""
            JournalEntry.txtdescription.Text = ""
            JournalEntry.txtdebit.Text = ""
            JournalEntry.txtcredit.Text = ""
            JournalEntry.txtdebitchecck.Text = ""
            JournalEntry.txtcaccnum.Text = "kofi"
            JournalEntry.txtaccnum.Text = "kofi"
            JournalEntry.txtbank.Text = "kofi"
            JournalEntry.txtcbank.Text = "kofi"

        Catch ex As Exception

        End Try
    End Sub

    Public Sub InsertBank()

        Try

            JournalEntry.dgvjournal.AllowUserToAddRows = False

            Dim dgvdate, dgvacc, dgvdesc, dgvdeb, dgvcred, dgvchecck, dgvbnk, dgvacnum As String

            Dim TotalRecords As Integer = JournalEntry.dgvjournal.RowCount - 1

            For i As Integer = 0 To TotalRecords

                dgvdate = JournalEntry.dgvjournal.Rows(i).Cells(0).Value
                dgvacc = JournalEntry.dgvjournal.Rows(i).Cells(1).Value
                dgvdesc = JournalEntry.dgvjournal.Rows(i).Cells(2).Value
                dgvdeb = JournalEntry.dgvjournal.Rows(i).Cells(3).Value
                dgvcred = JournalEntry.dgvjournal.Rows(i).Cells(4).Value
                dgvchecck = JournalEntry.dgvjournal.Rows(i).Cells(5).Value
                dgvbnk = JournalEntry.dgvjournal.Rows(i).Cells(6).Value
                dgvacnum = JournalEntry.dgvjournal.Rows(i).Cells(7).Value

                If JournalEntry.dgvjournal.Rows(i).Cells(5).Value = "bank" Then

                    Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
                    cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = dgvdate.Trim
                    cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = dgvacc.Trim
                    cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = dgvacnum.Trim
                    cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = dgvdesc.Trim
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvdeb.Trim
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcred.Trim
                    cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = dgvbnk.Trim
                    cmd.Connection = cnn

                    Try
                        cnn.Open()
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception

                    Finally

                        cnn.Close()
                        cnn.Dispose()
                    End Try

                End If

            Next

        Catch ex As Exception

        End Try

        InsertJV()

    End Sub

    Public Sub InsertJV()

        Try

            Dim dgvdate, dgvacc, dgvdeb, dgvcred As String

            For i As Integer = 0 To JournalEntry.dgvjournal.Rows.Count - 1

                dgvdate = JournalEntry.dgvjournal.Rows(i).Cells(0).Value
                dgvacc = JournalEntry.dgvjournal.Rows(i).Cells(1).Value
                dgvdeb = JournalEntry.dgvjournal.Rows(i).Cells(3).Value
                dgvcred = JournalEntry.dgvjournal.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = JournalEntry.txtentno.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = dgvdate.Trim
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = dgvacc.Trim
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvdeb.Trim
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcred.Trim
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

            Next

        Catch ex As Exception

        End Try

        JournalEntry.Close()
        JournalEntry.Dispose()

        JournalEntry.Show()
        JournalEntry.MdiParent = MainForm
        JournalEntry.BringToFront()

    End Sub

End Class

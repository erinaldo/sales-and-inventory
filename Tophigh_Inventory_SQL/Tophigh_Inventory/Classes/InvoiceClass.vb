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
Imports DevExpress.Xpf.Printing
Imports DevExpress.XtraPrinting

Public Class InvoiceClass

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

    Dim dtInvoice As New DataTable("dtInvoice")

    Dim index As Integer

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub Getmemid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cust_id as id from customer_v Where contactperson='" & convertQuotes(CreditSalesForm.cboMemsName.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtcusid.Text = dr.Item("id")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub
    Public Sub LoadStoreCount()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select count(pro_descrip) as list from shelve_t where location = '" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ItemsList.lblcount.Text = dr.Item("list")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadAdminCount()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select count(pro_descrip) as list from shelve_t "), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ItemsList.lblcount.Text = dr.Item("list")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub
    Public Sub GetAccount()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select Accounts from coa_v", conn) With {.CommandTimeout = 60}
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

            ReceiveBillForm.cboPay.Items.Clear()
            ReceiveBillForm.cboPay.Items.Add("")
            ReceiveBillForm.cboPay.Items.AddRange(names.ToArray)

        Catch ex As System.Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace:  {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub FillCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from shelve_t where location='" & convertQuotes(MainForm.txtlocation.Text) & "'", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("pro_descrip").ToString)
            End While
            rd.Close()
            conn.Close()

            CreditSalesForm.cbodata.Items.Clear()
            CreditSalesForm.cbodata.Items.Add("")
            CreditSalesForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckMember()
        Try
            If CreditSalesForm.rbogen.Checked = True Then
                CheckData()
            Else
                CheckMemData()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CheckData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                FillDataBoxBarcode()

            Else

                FillDataBox()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub CheckMemData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                FillMemDataBoxBarcode()

            Else

                FillmemDataBox()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where pro_descrip='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtid.Text = dr.Item("pro_id")
                CreditSalesForm.txtName.Text = dr.Item("pro_descrip")
                CreditSalesForm.txtamt.Text = dr.Item("sales_price")
                CreditSalesForm.txtrate.Text = dr.Item("sales_price")
                CreditSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditSalesForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillmemDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where pro_descrip='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtid.Text = dr.Item("pro_id")
                CreditSalesForm.txtName.Text = dr.Item("pro_descrip")
                CreditSalesForm.txtamt.Text = dr.Item("mem_sales_price")
                CreditSalesForm.txtrate.Text = dr.Item("mem_sales_price")
                CreditSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditSalesForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtid.Text = dr.Item("pro_id")
                CreditSalesForm.txtName.Text = dr.Item("pro_descrip")
                CreditSalesForm.txtamt.Text = dr.Item("sales_price")
                CreditSalesForm.txtrate.Text = dr.Item("sales_price")
                CreditSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditSalesForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillMemDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='" & convertQuotes(CreditSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtid.Text = dr.Item("pro_id")
                CreditSalesForm.txtName.Text = dr.Item("pro_descrip")
                CreditSalesForm.txtamt.Text = dr.Item("mem_sales_price")
                CreditSalesForm.txtrate.Text = dr.Item("mem_sales_price")
                CreditSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditSalesForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadHistory()

        Try

            CreditSalesForm.LvHistory.Clear()

            CreditSalesForm.LvHistory.View = View.Details
            CreditSalesForm.LvHistory.GridLines = True
            CreditSalesForm.LvHistory.FullRowSelect = True

            Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim strQ As String = String.Format("SELECT  full_name as [Full Name], nhis_num AS [NHIS] FROM dependant_t  WHERE cust_code ='" & CreditSalesForm.txtcusid.Text & "'")
            cmd = New SqlCommand(strQ, conn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "dependant_t")

            Dim i As Integer = 0
            Dim j As Integer = 0

            ' adding the columns in ListView
            For i = 0 To ds.Tables(0).Columns.Count - 1

                CreditSalesForm.LvHistory.Columns.Add(ds.Tables(0).Columns(i).ColumnName)

            Next

            'Now adding the Items in Listview
            For i = 0 To ds.Tables(0).Rows.Count - 1

                For j = 0 To ds.Tables(0).Columns.Count - 1

                    itemcoll(j) = ds.Tables(0).Rows(i)(j).ToString()

                Next

                Dim lvi As New ListViewItem(itemcoll)
                CreditSalesForm.LvHistory.Items.Add(lvi)
                CreditSalesForm.LvHistory.Columns(0).Width = 130
                CreditSalesForm.LvHistory.Columns(1).Width = 100

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadGridView()

        Try

            dtInvoice.Columns.Add("ID".ToString, GetType(String))
            dtInvoice.Columns.Add("Items".ToString, GetType(String))
            dtInvoice.Columns.Add("Qty".ToString, GetType(String))
            dtInvoice.Columns.Add("Rate".ToString, GetType(String))
            dtInvoice.Columns.Add("Amount".ToString, GetType(String))
            dtInvoice.Columns.Add("unitcost".ToString, GetType(String))
            dtInvoice.Columns.Add("COSGTotal".ToString, GetType(String))

            CreditSalesForm.dgvsales.ReadOnly = False
            CreditSalesForm.dgvsales.DataSource = dtInvoice
            CreditSalesForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            CreditSalesForm.dgvsales.Columns(0).Width = 50
            CreditSalesForm.dgvsales.Columns(1).Width = 240
            CreditSalesForm.dgvsales.Columns(2).Width = 100
            CreditSalesForm.dgvsales.Columns(3).Width = 120
            CreditSalesForm.dgvsales.Columns(4).Width = 140
            CreditSalesForm.dgvsales.Columns(5).Visible = False
            CreditSalesForm.dgvsales.Columns(6).Visible = False
            CreditSalesForm.dgvsales.Columns(0).Visible = False
            CreditSalesForm.dgvsales.Columns(3).ReadOnly = True

            CreditSalesForm.dgvsales.ForeColor = Color.Black

            CreditSalesForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            CreditSalesForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            CreditSalesForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            CreditSalesForm.dgvsales.AllowUserToResizeColumns = False
            CreditSalesForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            CreditSalesForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            CreditSalesForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertCreditStatement()
            InsertCreditBills()

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                dgvItem = CreditSalesForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = CreditSalesForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = CreditSalesForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = CreditSalesForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCreditSalesData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = CreditSalesForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = CreditSalesForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = CreditSalesForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = CreditSalesForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = CreditSalesForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = CreditSalesForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
                cmd.Parameters.Add("@inwords", SqlDbType.VarChar).Value = CreditSalesForm.txttoword.Text.Trim()
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

        PrintDirectInvoice()

        CreditSalesForm.Close()
        CreditSalesForm.Dispose()

        MainForm.btnInv.PerformClick()

    End Sub

    Public Sub InsertMemCashSales()

        Try

            CreditSalesForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertMemCreditStatement()
            InsertCreditBills()

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                dgvItem = CreditSalesForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = CreditSalesForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = CreditSalesForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = CreditSalesForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCreditSalesMemData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = CreditSalesForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = CreditSalesForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = CreditSalesForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = CreditSalesForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = CreditSalesForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = CreditSalesForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
                cmd.Parameters.Add("@inwords", SqlDbType.VarChar).Value = CreditSalesForm.txttoword.Text.Trim()
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

        PrintMemDirectInvoice()

        CreditSalesForm.Close()
        CreditSalesForm.Dispose()

        MainForm.btnInv.PerformClick()

    End Sub

    Public Sub InsertCogs()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                dgvcogstot = CreditSalesForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditSalesForm.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
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

    End Sub

    Public Sub InsertInv()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                dgvcogstot = CreditSalesForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditSalesForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
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

    End Sub

    Public Sub InsertCash()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditSalesForm.txtcashAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditSalesForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
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

    Public Sub InsertIncome()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditSalesForm.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = CreditSalesForm.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
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

    Public Sub InsertTaxPay()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditSalesForm.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = CreditSalesForm.txtvat.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
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

    Public Sub InsertCreditStatement()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text.Trim()
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = CreditSalesForm.mDescript.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditSalesForm.txtTotal.Text.Trim()
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = CreditSalesForm.cboCustomer.Text.Trim()
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

    Public Sub InsertMemCreditStatement()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text.Trim()
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = CreditSalesForm.cboMemsName.Text + " " + CreditSalesForm.mDescript.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditSalesForm.txtTotal.Text.Trim()
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = CreditSalesForm.cboCustomer.Text.Trim()
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

    Public Sub InsertCreditBills()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditBills"}
            cmd.Parameters.Add("@cust", SqlDbType.VarChar).Value = CreditSalesForm.cboCustomer.Text.Trim()
            cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = CreditSalesForm.dtSalesDate.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditSalesForm.txtTotal.Text.Trim()
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
            cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = CreditSalesForm.lblTime.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Parameters.Add("@bal_due", SqlDbType.Float).Value = "0"
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

    Public Sub GetData()

        Try


            If CreditSalesForm.txtid.Text <> "" AndAlso CreditSalesForm.txtName.Text <> "" AndAlso CreditSalesForm.txtqty.Text <> "" AndAlso CreditSalesForm.txtrate.Text <> "" AndAlso CreditSalesForm.txtamt.Text <> "" AndAlso CreditSalesForm.txtunitcost.Text <> "" AndAlso CreditSalesForm.txtutot.Text <> "" Then
                dtInvoice.Rows.Add(CreditSalesForm.txtid.Text, CreditSalesForm.txtName.Text, CreditSalesForm.txtqty.Text, CreditSalesForm.txtrate.Text, CreditSalesForm.txtamt.Text, CreditSalesForm.txtunitcost.Text, CreditSalesForm.txtutot.Text)
            End If

            CreditSalesForm.txtName.Text = ""
            CreditSalesForm.txtid.Text = ""
            CreditSalesForm.cbodata.Text = ""
            CreditSalesForm.txtqty.Text = "1"
            CreditSalesForm.txtrate.Text = ""
            CreditSalesForm.txtamt.Text = ""
            CreditSalesForm.txtunitcost.Text = ""
            CreditSalesForm.txtutot.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CreditSalesForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = CreditSalesForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                CreditSalesForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CreditSalesForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = CreditSalesForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                CreditSalesForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To CreditSalesForm.dgvsales.Rows.Count - 1
                totalSum += CreditSalesForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            CreditSalesForm.txtsubtot.Text = totalSum.ToString("n2")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub calrecgrid()

        Try

            Dim totalSum As Double

            For i As Double = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
                totalSum += ReceiveBillForm.dgvRecPay.Rows(i).Cells("Amt.Due").Value
            Next i

            ReceiveBillForm.txtAmtDue.Text = totalSum.ToString("n2")
            ReceiveBillForm.txtBal.Text = totalSum.ToString("n2")

            ReceiveBillForm.dgvRecPay.Columns("Amt.Due").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillSaleNo()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(cash_num)from credit_sales_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                CreditSalesForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                CreditSalesForm.mSaleNo.Text = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()
        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillMemSaleNo()

        Try

            Dim conString As New SqlConnection
            Dim cmd As New SqlCommand
            conString.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            cmd.Connection = conString
            conString.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(cash_num)from credit_sales_mems_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                CreditSalesForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                CreditSalesForm.mSaleNo.Text = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()
        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillCustName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select supplier from customer_v group by supplier", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("supplier").ToString)
            End While
            rd.Close()
            conn.Close()

            CreditSalesForm.cboCustomer.Items.Clear()
            CreditSalesForm.cboCustomer.Items.Add("")
            CreditSalesForm.cboCustomer.Items.AddRange(names.ToArray)

            ReceiveBillForm.cboRecFrom.Items.Clear()
            ReceiveBillForm.cboRecFrom.Items.Add("")
            ReceiveBillForm.cboRecFrom.Items.AddRange(names.ToArray)

            CustomerStatementForm.cboCust.Items.Clear()
            CustomerStatementForm.cboCust.Items.Add("")
            CustomerStatementForm.cboCust.Items.AddRange(names.ToArray)

            SearchCustomerStatementForm.cboCust.Items.Clear()
            SearchCustomerStatementForm.cboCust.Items.Add("")
            SearchCustomerStatementForm.cboCust.Items.AddRange(names.ToArray)

        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub FillContName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select contactperson from customer_v", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("contactperson").ToString)
            End While
            rd.Close()
            conn.Close()

            CreditSalesForm.cboMemsName.Items.Clear()
            CreditSalesForm.cboMemsName.Items.Add("")
            CreditSalesForm.cboMemsName.Items.AddRange(names.ToArray)

            ReceiveBillForm.cboRecFrom.Items.Clear()
            ReceiveBillForm.cboRecFrom.Items.Add("")
            ReceiveBillForm.cboRecFrom.Items.AddRange(names.ToArray)

            CustomerStatementForm.cboCust.Items.Clear()
            CustomerStatementForm.cboCust.Items.Add("")
            CustomerStatementForm.cboCust.Items.AddRange(names.ToArray)

            SearchCustomerStatementForm.cboCust.Items.Clear()
            SearchCustomerStatementForm.cboCust.Items.Add("")
            SearchCustomerStatementForm.cboCust.Items.AddRange(names.ToArray)

        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub FillCompName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select supplier from customer_v group by supplier", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("supplier").ToString)
            End While
            rd.Close()
            conn.Close()

            CreditSalesForm.cboCustomer.Items.Clear()
            CreditSalesForm.cboCustomer.Items.Add("")
            CreditSalesForm.cboCustomer.Items.AddRange(names.ToArray)

        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub FillgenName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select customer from other_cust_v group by supplier", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("customer").ToString)
            End While
            rd.Close()
            conn.Close()

            CreditSalesForm.cboCustomer.Items.Clear()
            CreditSalesForm.cboCustomer.Items.Add("")
            CreditSalesForm.cboCustomer.Items.AddRange(names.ToArray)

            ReceiveBillForm.cboRecFrom.Items.Clear()
            ReceiveBillForm.cboRecFrom.Items.Add("")
            ReceiveBillForm.cboRecFrom.Items.AddRange(names.ToArray)

            CustomerStatementForm.cboCust.Items.Clear()
            CustomerStatementForm.cboCust.Items.Add("")
            CustomerStatementForm.cboCust.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCash()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='ar'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtcashAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetSales()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='inc'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtsalesAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCogs()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='cogs'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtcogsAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvAcc()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtInvAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetDiscAcc()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='sd'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtdiscAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetTaxAcc()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_type='Income Tax Payable'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try

            If CreditSalesForm.rbomem.Checked = True Then

                Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

                conString.Open()

                Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(CreditSalesForm.cboCustomer.Text) & "'"), .Connection = conString}

                Dim dr As SqlDataReader = cm.ExecuteReader

                If dr.HasRows Then

                    dr.Read()

                    CreditSalesForm.txtcustid.Text = dr.Item("id")

                    dr.Close()

                End If

            Else

                Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

                conString.Open()

                Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from other_cust_v Where customer='" & convertQuotes(CreditSalesForm.cboCustomer.Text) & "'"), .Connection = conString}

                Dim dr As SqlDataReader = cm.ExecuteReader

                If dr.HasRows Then

                        dr.Read()

                        CreditSalesForm.txtcustid.Text = dr.Item("cust_id")

                        dr.Close()

                    End If


        End If

        Catch oEX As Exception

        End Try


    End Sub

    Public Sub GetVatValue()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from vat_t"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditSalesForm.txtvatval.Text = dr.Item("vat_num")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetMemCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,office_add,mobile,email_add,website from customer_v Where id='{0}'", CreditSalesForm.txtcustid.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim FName, LName, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                FName = dr.Item("supplier")
                LName = dr.Item("office_add")
                WorkFon = dr.Item("mobile")
                email = dr.Item("email_add")
                web = dr.Item("website")

                CreditSalesForm.txtAddress.Text = FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CustomerStatementForm.txtCustAdd.Text = FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select customer,mobile,address from other_cust_v Where cust_id='" & convertQuotes(CreditSalesForm.txtcustid.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, FName, LName As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("customer")
                FName = dr.Item("mobile")
                LName = dr.Item("address")

                CreditSalesForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName
                CustomerStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetStateCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,office_add,mobile,email_add,website from customer_v Where id='" & convertQuotes(CustomerStatementForm.txtNum.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim FName, LName, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                FName = dr.Item("supplier")
                LName = dr.Item("office_add")
                WorkFon = dr.Item("mobile")
                email = dr.Item("email_add")
                web = dr.Item("website")

                CustomerStatementForm.txtCustAdd.Text = FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetGenStateCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select customer,mobile,address from other_cust_v Where cust_id='" & convertQuotes(CustomerStatementForm.txtNum.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim FName, LName, WorkFon As String

            If dr.HasRows Then

                dr.Read()

                FName = dr.Item("customer")
                LName = dr.Item("address")
                WorkFon = dr.Item("mobile")


                CustomerStatementForm.txtCustAdd.Text = FName + Environment.NewLine + LName + Environment.NewLine + WorkFon

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub


    Public Sub PrintDirectInvoice()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyID")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = CreditSalesForm.txtcomp.Text
                        report.Parameters("pCust").Value = CreditSalesForm.txtAddress.Text
                        report.Parameters("pNum").Value = CreditSalesForm.mSaleNo.Text
                        report.Parameters("pDate").Value = CreditSalesForm.dtSalesDate.Text
                        report.Parameters("pVat").Value = CreditSalesForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("pComp").Visible = False
                        report.Parameters("pCust").Visible = False
                        report.Parameters("pNum").Visible = False
                        report.Parameters("pDate").Visible = False
                        report.Parameters("pVat").Visible = False
                        ' Create report document.

                        report.PrinterName = DefaultPrinter
                        report.CreateDocument()
                        report.PrintingSystem.ShowMarginsWarning = False
                        report.Print()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrintMemDirectInvoice()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("MemInvoicebyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditSalesForm.mSaleNo.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "MemInvoicebyID")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = CreditSalesForm.txtcomp.Text
                        report.Parameters("pCust").Value = CreditSalesForm.txtAddress.Text
                        report.Parameters("pNum").Value = CreditSalesForm.mSaleNo.Text
                        report.Parameters("pDate").Value = CreditSalesForm.dtSalesDate.Text
                        report.Parameters("pVat").Value = CreditSalesForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("pComp").Visible = False
                        report.Parameters("pCust").Visible = False
                        report.Parameters("pNum").Visible = False
                        report.Parameters("pDate").Visible = False
                        report.Parameters("pVat").Visible = False
                        ' Create report document.

                        report.PrinterName = DefaultPrinter
                        report.CreateDocument()
                        report.PrintingSystem.ShowMarginsWarning = False
                        report.Print()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrintingSystem_StartPrint(ByVal sender As Object, ByVal e As DevExpress.XtraPrinting.PrintDocumentEventArgs)
        e.PrintDocument.PrinterSettings.Copies = 2
    End Sub

    Public Sub GetInvoicebyID()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = SalesInvoiceForm.txtnum.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = SalesInvoiceForm.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyID")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesInvoiceForm.txtcomp.Text
                        report.pCust.Value = SalesInvoiceForm.txtcust.Text
                        report.pNum.Value = SalesInvoiceForm.txtnum.Text
                        report.pDate.Value = SalesInvoiceForm.txtdate.Text
                        report.pVat.Value = SalesInvoiceForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        SalesInvoiceForm.InvoiceViewer.DocumentSource = report
                        SalesInvoiceForm.InvoiceViewer.Refresh()

                        SalesInvoiceForm.txtInvNo.Text = ""
                        SalesInvoiceForm.cbolocation.Text = ""
                        SalesInvoiceForm.rboinv.Checked = True
                        SalesInvoiceForm.rbodate.Checked = False

                        SalesInvoiceForm.txtcomp.Text = ""
                        SalesInvoiceForm.txtnum.Text = ""
                        SalesInvoiceForm.txtdate.Text = ""
                        SalesInvoiceForm.txtvat.Text = ""


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetMemInvoicebyID()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("MemInvoicebyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = MembersSalesInvoiceForm.txtnum.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MembersSalesInvoiceForm.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "MemInvoicebyID")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = MembersSalesInvoiceForm.txtcomp.Text
                        report.pCust.Value = MembersSalesInvoiceForm.txtcust.Text
                        report.pNum.Value = MembersSalesInvoiceForm.txtnum.Text
                        report.pDate.Value = MembersSalesInvoiceForm.txtdate.Text
                        report.pVat.Value = MembersSalesInvoiceForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        MembersSalesInvoiceForm.InvoiceViewer.DocumentSource = report
                        MembersSalesInvoiceForm.InvoiceViewer.Refresh()

                        MembersSalesInvoiceForm.txtInvNo.Text = ""
                        MembersSalesInvoiceForm.cbolocation.Text = ""
                        MembersSalesInvoiceForm.rboinv.Checked = True
                        MembersSalesInvoiceForm.rbodate.Checked = False

                        MembersSalesInvoiceForm.txtcomp.Text = ""
                        MembersSalesInvoiceForm.txtnum.Text = ""
                        MembersSalesInvoiceForm.txtdate.Text = ""
                        MembersSalesInvoiceForm.txtvat.Text = ""


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetInvoicIDbyID()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_t Where cash_num='" & convertQuotes(SalesInvoiceForm.txtInvNo.Text) & "' AND location='" & convertQuotes(SalesInvoiceForm.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesInvoiceForm.txtnum.Text = dr.Item("cash_num")
                SalesInvoiceForm.txtdate.Text = dr.Item("cash_date")
                SalesInvoiceForm.txtvat.Text = dr.Item("vat")
                SalesInvoiceForm.txtcustname.Text = dr.Item("customer")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetMemInvoicIDbyID()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_mems_t Where cash_num='{0}' AND location='" & convertQuotes(MembersSalesInvoiceForm.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer", MembersSalesInvoiceForm.txtInvNo.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MembersSalesInvoiceForm.txtnum.Text = dr.Item("cash_num")
                MembersSalesInvoiceForm.txtdate.Text = dr.Item("cash_date")
                MembersSalesInvoiceForm.txtvat.Text = dr.Item("vat")
                MembersSalesInvoiceForm.txtcustname.Text = dr.Item("customer")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(MembersSalesInvoiceForm.txtcustname.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MembersSalesInvoiceForm.txtcustid.Text = dr.Item("id")

                GetInvoicebyID()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetOtherInvcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from other_cust_v Where customer='" & convertQuotes(SalesInvoiceForm.txtcustname.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesInvoiceForm.txtcustid.Text = dr.Item("cust_id")

                GetInvoicebyID()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from customer_v Where id='{0}'", MembersSalesInvoiceForm.txtcustid.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, FName, LName, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("contactperson")
                FName = dr.Item("supplier")
                LName = dr.Item("office_add")
                WorkFon = dr.Item("mobile")
                email = dr.Item("email_add")
                web = dr.Item("website")

                MembersSalesInvoiceForm.txtcust.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetOtherInvCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select customer,mobile,address from other_cust_v Where cust_id='{0}'", SalesInvoiceForm.txtcustid.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, FName, LName As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("customer")
                FName = dr.Item("address")
                LName = dr.Item("mobile")

                SalesInvoiceForm.txtcust.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvoicebyDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = SalesInvoiceForm.dtDate.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = SalesInvoiceForm.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyDate")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesInvoiceForm.txtcomp.Text
                        report.pCust.Value = SalesInvoiceForm.txtcust.Text
                        report.pNum.Value = SalesInvoiceForm.txtnum.Text
                        report.pDate.Value = SalesInvoiceForm.txtdate.Text
                        report.pVat.Value = SalesInvoiceForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        SalesInvoiceForm.InvoiceViewer.DocumentSource = report
                        SalesInvoiceForm.InvoiceViewer.Refresh()

                        SalesInvoiceForm.txtInvNo.Text = ""
                        SalesInvoiceForm.cbolocation.Text = ""
                        SalesInvoiceForm.rboinv.Checked = True
                        SalesInvoiceForm.rbodate.Checked = False

                        SalesInvoiceForm.txtcomp.Text = ""
                        SalesInvoiceForm.txtnum.Text = ""
                        SalesInvoiceForm.txtdate.Text = ""
                        SalesInvoiceForm.txtvat.Text = ""

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetMemInvoicebyDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("MemInvoicebyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = MembersSalesInvoiceForm.dtDate.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MembersSalesInvoiceForm.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "MemInvoicebyDate")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = MembersSalesInvoiceForm.txtcomp.Text
                        report.pCust.Value = MembersSalesInvoiceForm.txtcust.Text
                        report.pNum.Value = MembersSalesInvoiceForm.txtnum.Text
                        report.pDate.Value = MembersSalesInvoiceForm.txtdate.Text
                        report.pVat.Value = MembersSalesInvoiceForm.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        MembersSalesInvoiceForm.InvoiceViewer.DocumentSource = report
                        MembersSalesInvoiceForm.InvoiceViewer.Refresh()

                        MembersSalesInvoiceForm.txtInvNo.Text = ""
                        MembersSalesInvoiceForm.cbolocation.Text = ""
                        MembersSalesInvoiceForm.rboinv.Checked = True
                        MembersSalesInvoiceForm.rbodate.Checked = False

                        MembersSalesInvoiceForm.txtcomp.Text = ""
                        MembersSalesInvoiceForm.txtnum.Text = ""
                        MembersSalesInvoiceForm.txtdate.Text = ""
                        MembersSalesInvoiceForm.txtvat.Text = ""

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetInvoicIDbyDate()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_t Where cash_date='{0}' AND location='" & convertQuotes(SalesInvoiceForm.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer", SalesInvoiceForm.dtDate.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesInvoiceForm.txtnum.Text = dr.Item("cash_num")
                SalesInvoiceForm.txtdate.Text = dr.Item("cash_date")
                SalesInvoiceForm.txtvat.Text = dr.Item("vat")
                SalesInvoiceForm.txtcustname.Text = dr.Item("customer")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetMemInvoicIDbyDate()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_mems_t Where cash_date='{0}' AND location='" & convertQuotes(MembersSalesInvoiceForm.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer", MembersSalesInvoiceForm.dtDate.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MembersSalesInvoiceForm.txtnum.Text = dr.Item("cash_num")
                MembersSalesInvoiceForm.txtdate.Text = dr.Item("cash_date")
                MembersSalesInvoiceForm.txtvat.Text = dr.Item("vat")
                MembersSalesInvoiceForm.txtcustname.Text = dr.Item("customer")

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

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("com_name")
                strt = dr.Item("street")
                cty = dr.Item("city")
                cunt = dr.Item("country")
                WorkFon = dr.Item("phone")
                email = dr.Item("email")
                web = dr.Item("website")

                MembersSalesInvoiceForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesInvoiceForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CreditSalesForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CustomerStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SearchCustomerStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CustomerbillsForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getlocation()

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

            MembersSalesInvoiceForm.cbolocation.Items.Clear()
            MembersSalesInvoiceForm.cbolocation.Items.Add("")
            MembersSalesInvoiceForm.cbolocation.Items.AddRange(names.ToArray)

            SalesInvoiceForm.cbolocation.Items.Clear()
            SalesInvoiceForm.cbolocation.Items.Add("")
            SalesInvoiceForm.cbolocation.Items.AddRange(names.ToArray)

            SearchCustomerStatementForm.cbolocation.Items.Clear()
            SearchCustomerStatementForm.cbolocation.Items.Add("")
            SearchCustomerStatementForm.cbolocation.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillOnHand()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT Accounts FROM coa_v", conn) With {.CommandTimeout = 60}
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

            ReceiveBillForm.cbocashonhand.Items.Clear()
            ReceiveBillForm.cbocashonhand.Items.Add("")
            ReceiveBillForm.cbocashonhand.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub bankNumAcc()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select accnum,bank from bank_t where accname='" & convertQuotes(ReceiveBillForm.cbocashonhand.Text) & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ReceiveBillForm.txtAcNum.Text = dr.Item("accnum")
                ReceiveBillForm.txtbank.Text = dr.Item("bank")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetBank()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_cogm from chart_of_account_t where coa_name='" & convertQuotes(ReceiveBillForm.cbocashonhand.Text) & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ReceiveBillForm.txtcheckbnk.Text = dr.Item("coa_cogm")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillAR()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_name from chart_of_account_t where coa_cogm='ar'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                ReceiveBillForm.cboAR.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadRecBills()

        Try
            If ReceiveBillForm.txtrecid.Text = "" Then
                Try

                    ReceiveBillForm.dgvRecPay.Columns.Clear()

                    Dim constring As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Using con As New SqlConnection(constring)
                        Using cmd As New SqlCommand("SELECT bill_id AS ID, ent_date AS Date, debit AS [Orig.Amt], SUM(debit - credit) AS [Amt.Due], bal_due AS Payment FROM bills_t WHERE cust = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "' AND (credit < debit) GROUP BY bill_id, ent_date, debit, bal_due", con)
                            cmd.CommandType = CommandType.Text
                            Using sda As New SqlDataAdapter(cmd)
                                Using dt As New DataTable()
                                    sda.Fill(dt)
                                    ReceiveBillForm.dgvRecPay.DataSource = dt

                                    Dim chk As New DataGridViewCheckBoxColumn()
                                    chk.HeaderText = "Check Data"
                                    chk.Name = "chk"

                                    ReceiveBillForm.dgvRecPay.Columns.Insert(0, chk)

                                    ReceiveBillForm.dgvRecPay.Columns(3).DefaultCellStyle.Format = ("n2")
                                    ReceiveBillForm.dgvRecPay.Columns(4).DefaultCellStyle.Format = ("n2")
                                    ReceiveBillForm.dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")

                                    ReceiveBillForm.dgvRecPay.Columns(0).Width = 70
                                    ReceiveBillForm.dgvRecPay.Columns(1).Width = 40
                                    ReceiveBillForm.dgvRecPay.Columns(2).Width = 80
                                    ReceiveBillForm.dgvRecPay.Columns(3).Width = 126
                                    ReceiveBillForm.dgvRecPay.Columns(4).Width = 126
                                    ReceiveBillForm.dgvRecPay.Columns(5).Width = 126

                                    For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
                                        ReceiveBillForm.dgvRecPay.Rows(i).Cells("Payment").Value = "0.00"
                                    Next

                                End Using
                            End Using
                        End Using
                    End Using

                Catch ex As Exception

                End Try
            Else
                Try

                    ReceiveBillForm.dgvRecPay.Columns.Clear()

                    Dim constring As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Using con As New SqlConnection(constring)
                        Using cmd As New SqlCommand("SELECT bill_id AS ID, ent_date AS Date, debit AS [Orig.Amt], SUM(debit - credit) AS [Amt.Due], bal_due AS Payment FROM bills_t WHERE cust = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "' AND (credit < debit) GROUP BY bill_id, ent_date, debit, bal_due", con)
                            cmd.CommandType = CommandType.Text
                            Using sda As New SqlDataAdapter(cmd)
                                Using dt As New DataTable()
                                    sda.Fill(dt)
                                    ReceiveBillForm.dgvRecPay.DataSource = dt

                                    Dim chk As New DataGridViewCheckBoxColumn()
                                    chk.HeaderText = "Check Data"
                                    chk.Name = "chk"

                                    ReceiveBillForm.dgvRecPay.Columns.Insert(0, chk)

                                    ReceiveBillForm.dgvRecPay.Columns(3).DefaultCellStyle.Format = ("n2")
                                    ReceiveBillForm.dgvRecPay.Columns(4).DefaultCellStyle.Format = ("n2")
                                    ReceiveBillForm.dgvRecPay.Columns(5).DefaultCellStyle.Format = ("n2")

                                    ReceiveBillForm.dgvRecPay.Columns(0).Width = 70
                                    ReceiveBillForm.dgvRecPay.Columns(1).Width = 40
                                    ReceiveBillForm.dgvRecPay.Columns(2).Width = 80
                                    ReceiveBillForm.dgvRecPay.Columns(3).Width = 126
                                    ReceiveBillForm.dgvRecPay.Columns(4).Width = 126
                                    ReceiveBillForm.dgvRecPay.Columns(5).Width = 126

                                    For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
                                        ReceiveBillForm.dgvRecPay.Rows(i).Cells("Payment").Value = "0.00"
                                    Next

                                    ReceiveBillForm.dgvRecPay.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                    ReceiveBillForm.dgvRecPay.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                                    ReceiveBillForm.dgvRecPay.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                                End Using
                            End Using
                        End Using
                    End Using

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT id from beneficiary WHERE supplier = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "' group by id"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                ReceiveBillForm.txtrecid.Text = sdr.Item("id")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetGenID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT cust_id from other_cust_v WHERE customer = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "'"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                ReceiveBillForm.txtrecid.Text = sdr.Item("cust_id")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Function TotalAmt() As Double

        Dim tot As Double = 0
        Dim i As Integer = 0
        For i = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
            tot = tot + Convert.ToDouble(ReceiveBillForm.dgvRecPay.Rows(i).Cells("Payment").Value)
        Next i
        Return tot

    End Function

    Public Function TotalAmtDue() As Double

        Dim tot As Double = 0
        Dim i As Integer = 0
        For i = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
            tot = tot + Convert.ToDouble(ReceiveBillForm.dgvRecPay.Rows(i).Cells("Amt.Due").Value)
        Next i
        Return tot

    End Function

    Public Sub InsertReceipt()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim connection As SqlConnection = New SqlConnection(connetionString)
            Dim adapter As New SqlDataAdapter
            Const sql As String = "insert into receipt_t (num_int) values(@num_int)"

            connection.Open()

            Dim sqltrans As SqlTransaction = connection.BeginTransaction()

            Try

                Dim cmd As SqlCommand = connection.CreateCommand()

                'insert product
                cmd.Parameters.Add("@num_int", SqlDbType.Int).Value = ReceiptForm.txtNo.Text.Trim()

                cmd.CommandText = sql
                cmd.Transaction = sqltrans
                cmd.ExecuteNonQuery()

                'commit trans
                sqltrans.Commit()

            Catch oex As System.Data.SqlClient.SqlException

                'Rollbacktransaction
                sqltrans.Rollback()

                MessageBox.Show(String.Format("Transactionrolledback{0}{1}", ControlChars.Lf, oex.Message), "RollbackTransaction", MessageBoxButtons.OK)

            Catch ex As System.Exception

            Finally

                'Close connection
                connection.Close()

            End Try

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
            cmd.CommandText = "select MAX(num)from receipt_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                ReceiptForm.txtNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                ReceiptForm.txtNo.Text = number
            End If

            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub UpdateShelfQty()

        Try

            Dim dgvid, dgvqty As String

            For i As Integer = 0 To CreditSalesForm.dgvsales.Rows.Count - 1

                dgvid = CreditSalesForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = CreditSalesForm.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShQty"}
                cmd.Parameters.Add("@pieces", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvid.Trim()
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

    End Sub

    Public Sub UpdateBills()

        Try

            Dim dgvID, dgvPro As String

            For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count

                dgvID = ReceiveBillForm.dgvRecPay.Rows(i).Cells(1).Value
                dgvPro = ReceiveBillForm.dgvRecPay.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateBills"}
                cmd.Parameters.Add("@bill_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.VarChar).Value = dgvPro.Trim()
                cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = ReceiveBillForm.cbopaystatus.Text.Trim()
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

            Next

        Catch ex As Exception

        End Try

        InsertRecPayCreditStatement()

        CheckBills()

        'insert cash on hand
        InsertCashonHand()

    End Sub

    Public Sub InsertRecPayCreditStatement()

        Try

            Dim dgvPro As String

            Dim TotalRecords As Integer = ReceiveBillForm.dgvRecPay.RowCount - 1

            For i As Integer = 0 To TotalRecords


                dgvPro = ReceiveBillForm.dgvRecPay.Rows(i).Cells(5).Value

                If ReceiveBillForm.dgvRecPay.Rows(i).Cells(0).Value = True Then


                    Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCreditStatemnt"}
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = ReceiveBillForm.mRecDate.Text.Trim()
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = ReceiveBillForm.cboRecFrom.Text + "," + " " + ReceiveBillForm.mMemo.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvPro * -1
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = ReceiveBillForm.cboRecFrom.Text.Trim()
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

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckBills()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * from bills_t WHERE debit = credit and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                UpdateBillsStatus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdateBillsStatus()

        Try

            Dim dgvID, dgvPro As String

            For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count

                dgvID = ReceiveBillForm.dgvRecPay.Rows(i).Cells(3).Value
                dgvPro = ReceiveBillForm.dgvRecPay.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateBillsStatus"}
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvID.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvPro.Trim()
                cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = ReceiveBillForm.lblpaid.Text.Trim()
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

    End Sub

    Public Sub InsertCashonHand()

        Try

            Dim dgvID, dgvPro, dgvDes As String

            For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count

                dgvID = ReceiveBillForm.dgvRecPay.Rows(i).Cells(1).Value
                dgvPro = ReceiveBillForm.dgvRecPay.Rows(i).Cells(2).Value
                dgvDes = ReceiveBillForm.dgvRecPay.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = ReceiveBillForm.mRecDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ReceiveBillForm.cboPay.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvDes.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = ReceiveBillForm.lbltimer.Text.Trim()
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

        'insert A/R
        InsertRecPayment()

    End Sub

    Public Sub InsertRecPayment()

        Try

            Dim dgvID, dgvPro, dgvDes As String

            For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count

                dgvID = ReceiveBillForm.dgvRecPay.Rows(i).Cells(1).Value
                dgvPro = ReceiveBillForm.dgvRecPay.Rows(i).Cells(2).Value
                dgvDes = ReceiveBillForm.dgvRecPay.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = ReceiveBillForm.mRecDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = ReceiveBillForm.cboAR.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvDes.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = ReceiveBillForm.lbltimer.Text.Trim()
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

    End Sub

    Public Sub GetBalance()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select sum(debit)  as debit from credit_statement_t where cust_name='" & convertQuotes(CustomerStatementForm.cboCust.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CustomerStatementForm.txtAmtDue.Text = dr.Item("debit")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub CustStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetCustStatement")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = CustomerStatementForm.txtCust.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsCreditStatement As New DataSet

                        sda.Fill(dsCreditStatement, "GetCustStatement")

                        Dim report As New XtraCreditStatementRep
                        report.DataSource = dsCreditStatement
                        report.DataMember = "CreditStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = CustomerStatementForm.txtComp.Text
                        report.pCust.Value = CustomerStatementForm.txtCust.Text
                        report.pCustAdd.Value = CustomerStatementForm.txtCustAdd.Text

                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pCustAdd.Visible = False

                        report.CreateDocument()
                        CustomerStatementForm.CustStateViewer.DocumentSource = report
                        CustomerStatementForm.CustStateViewer.Refresh()


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub SearchCustStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetCustStatementbyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = CustomerStatementForm.txtCust.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsCreditStatement As New DataSet

                        sda.Fill(dsCreditStatement, "GetCustStatementbyDate")

                        Dim report As New XtraCreditStatementRep
                        report.DataSource = dsCreditStatement
                        report.DataMember = "CreditStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = CustomerStatementForm.txtComp.Text
                        report.pCust.Value = CustomerStatementForm.txtCust.Text
                        report.pCustAdd.Value = CustomerStatementForm.txtCustAdd.Text

                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pCustAdd.Visible = False

                        report.CreateDocument()
                        CustomerStatementForm.CustStateViewer.DocumentSource = report
                        CustomerStatementForm.CustStateViewer.Refresh()


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSearchCustID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT id from customer_v WHERE supplier = '" & convertQuotes(CustomerStatementForm.cboCust.Text) & "' group by supplier"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                CustomerStatementForm.txtNum.Text = sdr.Item("id")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetGenSearchCustID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT cust_id from other_cust_v WHERE customer = '" & convertQuotes(CustomerStatementForm.cboCust.Text) & "' group by supplier"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                CustomerStatementForm.txtNum.Text = sdr.Item("cust_id")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSchStateCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from customer_v Where id='" & convertQuotes(SearchCustomerStatementForm.txtNum.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader
            Dim Comp, FName, LName, WorkFon, email, web As String

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("contactperson")
                FName = dr.Item("supplier")
                LName = dr.Item("office_add")
                WorkFon = dr.Item("mobile")
                email = dr.Item("email_add")
                web = dr.Item("website")

                SearchCustomerStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetSchBalance()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select sum(debit)  as debit from credit_statement_t where cust_name='" & convertQuotes(SearchCustomerStatementForm.cboCust.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SearchCustomerStatementForm.txtAmtDue.Text = dr.Item("debit")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetSchSearchCustID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT id from customer_v WHERE supplier = '" & convertQuotes(SearchCustomerStatementForm.cboCust.Text) & "' group by supplier"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                SearchCustomerStatementForm.txtNum.Text = sdr.Item("id")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSearchCustStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetCustStatementbyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = SearchCustomerStatementForm.txtCust.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = SearchCustomerStatementForm.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsCreditStatement As New DataSet

                        sda.Fill(dsCreditStatement, "GetCustStatementbyDate")

                        Dim report As New XtraCreditStatementRep
                        report.DataSource = dsCreditStatement
                        report.DataMember = "CreditStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SearchCustomerStatementForm.txtComp.Text
                        report.pCust.Value = SearchCustomerStatementForm.txtCust.Text
                        report.pCustAdd.Value = SearchCustomerStatementForm.txtCustAdd.Text

                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pCustAdd.Visible = False

                        report.CreateDocument()
                        SearchCustomerStatementForm.CustStateViewer.DocumentSource = report
                        SearchCustomerStatementForm.CustStateViewer.Refresh()


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub OpenDebtorsList()

        Try

            OpenDebtors.dgvOpenDebtors.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetOpenDebtors", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            OpenDebtors.dgvOpenDebtors.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetItemList()

        Try


            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetShelvelistbyloca")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    ItemsList.dgvitemlist.DataSource = dt

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Public Sub GetItemListAdmin()

        Try


            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cmd As SqlCommand = New SqlCommand("GetShelvelistbyAdmin")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter(cmd)
                    cmd.Connection = con
                    sda.SelectCommand = cmd

                    Dim dt As New DataTable()
                    sda.Fill(dt)
                    ItemsList.dgvitemlist.DataSource = dt

                End Using
            End Using

        Catch oex As Exception

        End Try

    End Sub

    Public Sub InsertBank()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = ReceiveBillForm.mRecDate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = ReceiveBillForm.cbocashonhand.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = ReceiveBillForm.txtAcNum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = ReceiveBillForm.mMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = ReceiveBillForm.mRecAmount.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = ReceiveBillForm.txtbank.Text
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

    Public Sub GetOpenInvoice()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsOpenBills As New DataSet
            Const sql As String = "GetOpenDebtors"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsOpenBills, "GetOpenDebtors")
            cnn.Close()

            Dim report As New CustOpenBillReport
            report.DataSource = dsOpenBills
            report.DataMember = "GetOpenDebtors"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = CustomerbillsForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False

            report.CreateDocument()
            CustomerbillsForm.CustStateViewer.DocumentSource = report
            CustomerbillsForm.CustStateViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub


End Class

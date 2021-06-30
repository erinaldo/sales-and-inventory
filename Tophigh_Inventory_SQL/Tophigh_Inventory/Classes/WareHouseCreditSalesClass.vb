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

Public Class WareHouseCreditSalesClass

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

    Public Sub FillCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from ware_house_t where location='" & convertQuotes(MainForm.txtlocation.Text) & "'", conn) With {.CommandTimeout = 60}
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

            WCRForm.cbodata.Items.Clear()
            WCRForm.cbodata.Items.Add("")
            WCRForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(WCRForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

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

    Public Sub FillDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select pro_id,pro_descrip,sum(whole_sales_price * qtyinbox) as rate,unit_cost,qtyinbox,whole_sales_price from ware_house_t Where pro_descrip='" & convertQuotes(WCRForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'group by pro_id,pro_descrip,unit_cost,qtyinbox,whole_sales_price,whole_sales_price"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                WCRForm.txtid.Text = dr.Item("pro_id")
                WCRForm.txtName.Text = dr.Item("pro_descrip")
                WCRForm.txtamt.Text = dr.Item("rate")
                WCRForm.txtrate.Text = dr.Item("rate")
                WCRForm.txtunitcost.Text = dr.Item("unit_cost")
                WCRForm.txtutot.Text = dr.Item("unit_cost")
                WCRForm.txtqtyin.Text = dr.Item("qtyinbox")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select pro_id,pro_descrip,sum(whole_sales_price * qtyinbox) as rate,unit_cost,qtyinbox,whole_sales_price from ware_house_t Where bar_code='" & convertQuotes(WCRForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'group by pro_id,pro_descrip,unit_cost,qtyinbox,whole_sales_price,whole_sales_price"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                WCRForm.txtid.Text = dr.Item("pro_id")
                WCRForm.txtName.Text = dr.Item("pro_descrip")
                WCRForm.txtamt.Text = dr.Item("rate")
                WCRForm.txtrate.Text = dr.Item("rate")
                WCRForm.txtunitcost.Text = dr.Item("unit_cost")
                WCRForm.txtutot.Text = dr.Item("unit_cost")
                WCRForm.txtqtyin.Text = dr.Item("qtyinbox")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadHistory()

        Try

            WCRForm.LvHistory.Clear()

            WCRForm.LvHistory.View = View.Details
            WCRForm.LvHistory.GridLines = True
            WCRForm.LvHistory.FullRowSelect = True

            Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim strQ As String = String.Format("SELECT  items AS Items, SUM(qty) AS Qty FROM credit_sales_warehouse_t  WHERE (cash_date = '" & WCRForm.dthistdate.Text & "') GROUP BY items")
            cmd = New SqlCommand(strQ, conn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "credit_sales_warehouse_t")

            Dim i As Integer = 0
            Dim j As Integer = 0

            ' adding the columns in ListView
            For i = 0 To ds.Tables(0).Columns.Count - 1

                WCRForm.LvHistory.Columns.Add(ds.Tables(0).Columns(i).ColumnName)

            Next

            'Now adding the Items in Listview
            For i = 0 To ds.Tables(0).Rows.Count - 1

                For j = 0 To ds.Tables(0).Columns.Count - 1

                    itemcoll(j) = ds.Tables(0).Rows(i)(j).ToString()

                Next

                Dim lvi As New ListViewItem(itemcoll)
                WCRForm.LvHistory.Items.Add(lvi)
                WCRForm.LvHistory.Columns(0).Width = 130
                WCRForm.LvHistory.Columns(1).Width = 100

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
            dtInvoice.Columns.Add("Qty In".ToString, GetType(String))
            dtInvoice.Columns.Add("Total Qty In".ToString, GetType(String))

            WCRForm.dgvsales.ReadOnly = False
            WCRForm.dgvsales.DataSource = dtInvoice
            WCRForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            WCRForm.dgvsales.Columns(0).Width = 50
            WCRForm.dgvsales.Columns(1).Width = 240
            WCRForm.dgvsales.Columns(2).Width = 100
            WCRForm.dgvsales.Columns(3).Width = 120
            WCRForm.dgvsales.Columns(4).Width = 140
            WCRForm.dgvsales.Columns(5).Visible = False
            WCRForm.dgvsales.Columns(6).Visible = False
            WCRForm.dgvsales.Columns(7).Visible = False
            WCRForm.dgvsales.Columns(8).Visible = False
            WCRForm.dgvsales.Columns(0).Visible = False
            WCRForm.dgvsales.Columns(3).ReadOnly = True

            WCRForm.dgvsales.ForeColor = Color.Black

            WCRForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            WCRForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            WCRForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            WCRForm.dgvsales.AllowUserToResizeColumns = False
            WCRForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            WCRForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            WCRForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertCreditStatement()
            InsertCreditBills()

            Dim dgvItem, dgvqty, dgvrate, dgvamount, dgvqtygvn As String

            For i As Integer = 0 To WCRForm.dgvsales.Rows.Count - 1

                dgvItem = WCRForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = WCRForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = WCRForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = WCRForm.dgvsales.Rows(i).Cells(4).Value
                dgvqtygvn = WCRForm.dgvsales.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCreditSalesWareData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = WCRForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = WCRForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = WCRForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = WCRForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = WCRForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = WCRForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = WCRForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
                cmd.Parameters.Add("@inwords", SqlDbType.VarChar).Value = WCRForm.txttoword.Text.Trim()
                cmd.Parameters.Add("@tot_qty_gvn", SqlDbType.Float).Value = dgvqtygvn.Trim()
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
        PrintDirectInvoice()

        WCRForm.Close()
        WCRForm.Dispose()

        MainForm.btnWHCreditSales.PerformClick()

    End Sub

    Public Sub InsertCogs()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To WCRForm.dgvsales.Rows.Count - 1

                dgvcogstot = WCRForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = WCRForm.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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

            For i As Integer = 0 To WCRForm.dgvsales.Rows.Count - 1

                dgvcogstot = WCRForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = WCRForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = WCRForm.txtcashAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = WCRForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = WCRForm.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = WCRForm.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = WCRForm.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = WCRForm.txtvat.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text.Trim()
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = WCRForm.mDescript.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = WCRForm.txtTotal.Text.Trim()
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = WCRForm.cboCustomer.Text.Trim()
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
            cmd.Parameters.Add("@cust", SqlDbType.VarChar).Value = WCRForm.cboCustomer.Text.Trim()
            cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = WCRForm.dtSalesDate.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = WCRForm.txtTotal.Text.Trim()
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
            cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = WCRForm.lblTime.Text
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

            If WCRForm.txtid.Text <> "" AndAlso WCRForm.txtName.Text <> "" AndAlso WCRForm.txtqty.Text <> "" AndAlso WCRForm.txtrate.Text <> "" AndAlso WCRForm.txtamt.Text <> "" AndAlso WCRForm.txtunitcost.Text <> "" AndAlso WCRForm.txtutot.Text <> "" AndAlso WCRForm.txtqtyin.Text <> "" Then
                dtInvoice.Rows.Add(WCRForm.txtid.Text, WCRForm.txtName.Text, WCRForm.txtqty.Text, WCRForm.txtrate.Text, WCRForm.txtamt.Text, WCRForm.txtunitcost.Text, WCRForm.txtutot.Text, WCRForm.txtqtyin.Text)
            End If

            WCRForm.txtName.Text = ""
            WCRForm.txtid.Text = ""
            WCRForm.cbodata.Text = ""
            WCRForm.txtqty.Text = "1"
            WCRForm.txtrate.Text = ""
            WCRForm.txtamt.Text = ""
            WCRForm.txtunitcost.Text = ""
            WCRForm.txtutot.Text = ""
            WCRForm.txtqtyin.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To WCRForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = WCRForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = WCRForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                WCRForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To WCRForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = WCRForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = WCRForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                WCRForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k


        Catch ex As Exception

        End Try

        Try

            For g As Double = 0 To WCRForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = WCRForm.dgvsales.Rows(g).Cells("Qty").Value
                Dim icell5 As Double = WCRForm.dgvsales.Rows(g).Cells("Qty In").Value

                Dim icellResultCost As Double = icell2 * icell5

                WCRForm.dgvsales.Rows(g).Cells("Total Qty In").Value = icellResultCost.ToString("n2")

            Next g


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To WCRForm.dgvsales.Rows.Count - 1
                totalSum += WCRForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            WCRForm.txtsubtot.Text = totalSum.ToString("n2")

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
            cmd.CommandText = "select MAX(cash_num)from credit_sales_warehouse_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                WCRForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                WCRForm.mSaleNo.Text = number
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
        Dim cmd As New SqlCommand("select supplier from customer_v", conn) With {.CommandTimeout = 60}
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

            WCRForm.cboCustomer.Items.Clear()
            WCRForm.cboCustomer.Items.Add("")
            WCRForm.cboCustomer.Items.AddRange(names.ToArray)

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

    Public Sub GetCash()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='ar'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                WCRForm.txtcashAcc.Text = dr.Item("coa_name")

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

                WCRForm.txtsalesAcc.Text = dr.Item("coa_name")

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

                WCRForm.txtcogsAcc.Text = dr.Item("coa_name")

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

                WCRForm.txtInvAcc.Text = dr.Item("coa_name")

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

                WCRForm.txtdiscAcc.Text = dr.Item("coa_name")

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

                WCRForm.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(WCRForm.cboCustomer.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                WCRForm.txtcustid.Text = dr.Item("id")

                dr.Close()

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

                WCRForm.txtvatval.Text = dr.Item("vat_num")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from customer_v Where id='{0}'", WCRForm.txtcustid.Text), .Connection = conString}

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

                WCRForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CustomerStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetStateCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from customer_v Where id='{0}'", CustomerStatementForm.txtNum.Text), .Connection = conString}

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

                CustomerStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyIDWare")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = WCRForm.mSaleNo.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyIDWare")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = WCRForm.txtcomp.Text
                        report.Parameters("pCust").Value = WCRForm.txtAddress.Text
                        report.Parameters("pNum").Value = WCRForm.mSaleNo.Text
                        report.Parameters("pDate").Value = WCRForm.dtSalesDate.Text
                        report.Parameters("pVat").Value = WCRForm.txtvat.Text
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

    Public Sub GetInvoicebyID()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyIDWare")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = Invoice.txtnum.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = Invoice.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyIDWare")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = Invoice.txtcomp.Text
                        report.pCust.Value = Invoice.txtcust.Text
                        report.pNum.Value = Invoice.txtnum.Text
                        report.pDate.Value = Invoice.txtdate.Text
                        report.pVat.Value = Invoice.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        Invoice.InvoiceViewer.DocumentSource = report
                        Invoice.InvoiceViewer.Refresh()

                        Invoice.txtInvNo.Text = ""
                        Invoice.cbolocation.Text = ""
                        Invoice.rboinv.Checked = True
                        Invoice.rbodate.Checked = False

                        Invoice.txtcomp.Text = ""
                        Invoice.txtnum.Text = ""
                        Invoice.txtdate.Text = ""
                        Invoice.txtvat.Text = ""


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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_warehouse_t Where cash_num='{0}' AND location='" & convertQuotes(Invoice.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer", Invoice.txtInvNo.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Invoice.txtnum.Text = dr.Item("cash_num")
                Invoice.txtdate.Text = dr.Item("cash_date")
                Invoice.txtvat.Text = dr.Item("vat")
                Invoice.txtcustname.Text = dr.Item("customer")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(Invoice.txtcustname.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Invoice.txtcustid.Text = dr.Item("id")

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from customer_v Where id='" & convertQuotes(Invoice.txtcustid.Text) & "'"), .Connection = conString}

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

                Invoice.txtcust.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvoicebyDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("InvoicebyDateWare")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_date", SqlDbType.Int).Value = Invoice.dtDate.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = Invoice.cbolocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "InvoicebyDateWare")

                        Dim report As New XtraInvoice
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = Invoice.txtcomp.Text
                        report.pCust.Value = Invoice.txtcust.Text
                        report.pNum.Value = Invoice.txtnum.Text
                        report.pDate.Value = Invoice.txtdate.Text
                        report.pVat.Value = Invoice.txtvat.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pNum.Visible = False
                        report.pDate.Visible = False
                        report.pVat.Visible = False
                        report.CreateDocument()
                        Invoice.InvoiceViewer.DocumentSource = report
                        Invoice.InvoiceViewer.Refresh()

                        Invoice.txtInvNo.Text = ""
                        Invoice.cbolocation.Text = ""
                        Invoice.rboinv.Checked = True
                        Invoice.rbodate.Checked = False

                        Invoice.txtcomp.Text = ""
                        Invoice.txtnum.Text = ""
                        Invoice.txtdate.Text = ""
                        Invoice.txtvat.Text = ""

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select cash_num,cash_date,vat,customer from credit_sales_warehouse_t Where cash_date='{0}' AND location='" & convertQuotes(Invoice.cbolocation.Text) & "' group by cash_num,cash_date,vat,customer", Invoice.dtDate.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Invoice.txtnum.Text = dr.Item("cash_num")
                Invoice.txtdate.Text = dr.Item("cash_date")
                Invoice.txtvat.Text = dr.Item("vat")
                Invoice.txtcustname.Text = dr.Item("customer")

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

                Invoice.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                WCRForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CustomerStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SearchCustomerStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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

            Invoice.cbolocation.Items.Clear()
            Invoice.cbolocation.Items.Add("")
            Invoice.cbolocation.Items.AddRange(names.ToArray)

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

    Public Sub GetPCash()

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

            ReceiveBillForm.cboPay.Items.Clear()
            ReceiveBillForm.cboPay.Items.Add("")
            ReceiveBillForm.cboPay.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadRecBills()

        Try
            If ReceiveBillForm.txtrecid.Text = "" Then
                Try

                    ReceiveBillForm.dgvRecPay.Columns.Clear()

                    Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim sql As String = String.Format("SELECT bill_id AS ID, ent_date AS Date, debit AS [Orig.Amt], SUM(debit - credit) AS [Amt.Due], bal_due AS Payment FROM bills_t WHERE cust = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "' AND (credit < debit) GROUP BY bill_id, ent_date, debit, bal_due")
                    Dim connection As New SqlConnection(connectionString)
                    connection.Open()
                    sCommand = New SqlCommand(sql, connection)
                    sAdapter = New SqlDataAdapter(sCommand)
                    sBuilder = New SqlCommandBuilder(sAdapter)
                    sDs = New DataSet()
                    sAdapter.Fill(sDs, "bills_t")
                    sTable = sDs.Tables("bills_t")
                    connection.Close()
                    ReceiveBillForm.dgvRecPay.DataSource = sDs.Tables("bills_t")

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

                Catch ex As Exception

                End Try
            Else
                Try

                    ReceiveBillForm.dgvRecPay.Columns.Clear()

                    Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim sql As String = String.Format("SELECT bill_id AS ID, ent_date AS Date, debit AS [Orig.Amt], SUM(debit - credit) AS [Amt.Due], bal_due AS Payment FROM bills_t WHERE cust = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "' AND (credit < debit) GROUP BY bill_id, ent_date, debit, bal_due")
                    Dim connection As New SqlConnection(connectionString)
                    connection.Open()
                    sCommand = New SqlCommand(sql, connection)
                    sAdapter = New SqlDataAdapter(sCommand)
                    sBuilder = New SqlCommandBuilder(sAdapter)
                    sDs = New DataSet()
                    sAdapter.Fill(sDs, "bills_t")
                    sTable = sDs.Tables("bills_t")
                    connection.Close()
                    ReceiveBillForm.dgvRecPay.DataSource = sDs.Tables("bills_t")

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

                    Try

                        For i As Integer = 0 To ReceiveBillForm.dgvRecPay.Rows.Count - 1
                            ReceiveBillForm.dgvRecPay.Rows(i).Cells("Payment").Value = "0.00"
                        Next

                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT ID from beneficiary WHERE supplier = '" & convertQuotes(ReceiveBillForm.cboRecFrom.Text) & "'"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                ReceiveBillForm.txtrecid.Text = sdr.Item("ID")

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

            Dim dgvid, dgvqty, dgvpcs As String

            For i As Integer = 0 To WCRForm.dgvsales.Rows.Count

                dgvid = WCRForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = WCRForm.dgvsales.Rows(i).Cells(8).Value
                dgvpcs = WCRForm.dgvsales.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateWareQty"}
                cmd.Parameters.Add("@totpieces_out", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pieces_out", SqlDbType.Float).Value = dgvpcs.Trim()
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
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = ReceiveBillForm.mMemo.Text.Trim()
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
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT id from customer_v WHERE supplier = '" & convertQuotes(CustomerStatementForm.cboCust.Text) & "'"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                CustomerStatementForm.txtNum.Text = sdr.Item("id")

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

                SearchCustomerStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT id from customer_v WHERE supplier = '" & convertQuotes(SearchCustomerStatementForm.cboCust.Text) & "'"), con)
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

End Class

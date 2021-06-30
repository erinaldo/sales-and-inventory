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
Imports System.Globalization
Imports CrystalDecisions.[Shared].Json

Public Class CashSalesClass

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

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function
    Public Sub GetCustNum()

        Try

            Dim i As Integer
            For i = 0 To 1000
                CashSalesForm.txtsync_code.Text = (Convert.ToString(random.Next(10000, 20000)))
            Next

        Catch ex As Exception

        End Try

    End Sub

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

            CashSalesForm.cbodata.Items.Clear()
            CashSalesForm.cbodata.Items.Add("")
            CashSalesForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDirectCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from ware_house_t", conn) With {.CommandTimeout = 60}
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

            SalesbyItems.cboproduct.Items.Clear()
            SalesbyItems.cboproduct.Items.Add("")
            SalesbyItems.cboproduct.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckData()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(CashSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select pro_id,pro_descrip,sum(whole_sales_price * qtyinbox) as rate,unit_cost,qtyinbox,whole_sales_price from ware_house_t Where pro_descrip='" & convertQuotes(CashSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "' group by pro_id,pro_descrip,unit_cost,qtyinbox,whole_sales_price,whole_sales_price"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CashSalesForm.txtid.Text = dr.Item("pro_id")
                CashSalesForm.txtName.Text = dr.Item("pro_descrip")
                CashSalesForm.txtamt.Text = dr.Item("rate")
                CashSalesForm.txtrate.Text = dr.Item("rate")
                CashSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CashSalesForm.txtutot.Text = dr.Item("unit_cost")
                CashSalesForm.txtqtyin.Text = dr.Item("qtyinbox")
                CashSalesForm.txtrate2.Text = dr.Item("whole_sales_price")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select pro_id,pro_descrip,sum(whole_sales_price * qtyinbox) as rate,unit_cost,qtyinbox,whole_sales_price from ware_house_t Where bar_code='" & convertQuotes(CashSalesForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'group by pro_id,pro_descrip,unit_cost,qtyinbox,whole_sales_price,whole_sales_price"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CashSalesForm.txtid.Text = dr.Item("pro_id")
                CashSalesForm.txtName.Text = dr.Item("pro_descrip")
                CashSalesForm.txtamt.Text = dr.Item("rate")
                CashSalesForm.txtrate.Text = dr.Item("rate")
                CashSalesForm.txtunitcost.Text = dr.Item("unit_cost")
                CashSalesForm.txtutot.Text = dr.Item("unit_cost")
                CashSalesForm.txtqtyin.Text = dr.Item("qtyinbox")
                CashSalesForm.txtrate2.Text = dr.Item("whole_sales_price")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoadHistory()

        Try

            CashSalesForm.LvHistory.Clear()

            CashSalesForm.LvHistory.View = View.Details
            CashSalesForm.LvHistory.GridLines = True
            CashSalesForm.LvHistory.FullRowSelect = True

            Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim strQ As String = String.Format("SELECT  items AS Items, SUM(qty) AS Qty FROM cash_sales_warehouse_t  WHERE (cash_date = '" & CashSalesForm.dthistdate.Text & "') GROUP BY items")
            cmd = New SqlCommand(strQ, conn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "cash_sales_warehouse_t")

            Dim i As Integer = 0
            Dim j As Integer = 0

            ' adding the columns in ListView
            For i = 0 To ds.Tables(0).Columns.Count - 1

                CashSalesForm.LvHistory.Columns.Add(ds.Tables(0).Columns(i).ColumnName)

            Next

            'Now adding the Items in Listview
            For i = 0 To ds.Tables(0).Rows.Count - 1

                For j = 0 To ds.Tables(0).Columns.Count - 1

                    itemcoll(j) = ds.Tables(0).Rows(i)(j).ToString()

                Next

                Dim lvi As New ListViewItem(itemcoll)
                CashSalesForm.LvHistory.Items.Add(lvi)
                CashSalesForm.LvHistory.Columns(0).Width = 130
                CashSalesForm.LvHistory.Columns(1).Width = 100

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
            dtInvoice.Columns.Add("Rate 2".ToString, GetType(String))

            CashSalesForm.dgvsales.ReadOnly = False
            CashSalesForm.dgvsales.DataSource = dtInvoice
            CashSalesForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            CashSalesForm.dgvsales.Columns(0).Visible = False
            CashSalesForm.dgvsales.Columns(1).Width = 240
            CashSalesForm.dgvsales.Columns(2).Width = 100
            CashSalesForm.dgvsales.Columns(3).Width = 120
            CashSalesForm.dgvsales.Columns(4).Width = 140
            CashSalesForm.dgvsales.Columns(5).Visible = False
            CashSalesForm.dgvsales.Columns(6).Visible = False
            CashSalesForm.dgvsales.Columns(7).Visible = False
            CashSalesForm.dgvsales.Columns(8).Visible = False
            CashSalesForm.dgvsales.Columns(9).Visible = False
            CashSalesForm.dgvsales.Columns(10).Visible = False
            CashSalesForm.dgvsales.Columns(3).ReadOnly = True

            CashSalesForm.dgvsales.ForeColor = Color.Black

            CashSalesForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            CashSalesForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            CashSalesForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            CashSalesForm.dgvsales.AllowUserToResizeColumns = False
            CashSalesForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            CashSalesForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            CashSalesForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertSalesDisc()

            Dim dgvItem, dgvqty, dgvrate, dgvamount, dgvqtygvn As String

            For i As Integer = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                dgvItem = CashSalesForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = CashSalesForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = CashSalesForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = CashSalesForm.dgvsales.Rows(i).Cells(4).Value
                dgvqtygvn = CashSalesForm.dgvsales.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCashSalesWareData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = CashSalesForm.cboPayMeth.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = CashSalesForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@sale_disc", SqlDbType.Float).Value = CashSalesForm.txtsaldisc.Text.Trim()
                cmd.Parameters.Add("@nettotal", SqlDbType.Float).Value = CashSalesForm.txtTotal.Text.Trim()
                cmd.Parameters.Add("@amt_rece", SqlDbType.Float).Value = CashSalesForm.txtreceive.Text.Trim()
                cmd.Parameters.Add("@amt_change", SqlDbType.Float).Value = CashSalesForm.txtchange.Text.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = CashSalesForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = CashSalesForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@card_check_num", SqlDbType.VarChar).Value = CashSalesForm.mCheck.Text.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
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

        PrintDirectPOS()
        PrintDirectPOS()

    End Sub

    Public Sub InsertCogs()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                dgvcogstot = CashSalesForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CashSalesForm.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
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

            For i As Integer = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                dgvcogstot = CashSalesForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CashSalesForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CashSalesForm.cboPayMeth.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CashSalesForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CashSalesForm.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = CashSalesForm.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
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

    Public Sub InsertSalesDisc()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@p_cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@p_jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@p_coa_name", SqlDbType.VarChar).Value = CashSalesForm.txtdiscAcc.Text
            cmd.Parameters.Add("@p_debit", SqlDbType.Float).Value = CashSalesForm.txtsaldisc.Text
            cmd.Parameters.Add("@p_credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@p_ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
            cmd.Parameters.Add("@p_location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CashSalesForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CashSalesForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CashSalesForm.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = CashSalesForm.txtvat.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CashSalesForm.lblTime.Text
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

    Public Sub UpdateShelfQty()

        Try

            Dim dgvid, dgvqty, dgvpcs As String

            For i As Integer = 0 To CashSalesForm.dgvsales.Rows.Count

                dgvid = CashSalesForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = CashSalesForm.dgvsales.Rows(i).Cells(2).Value
                dgvpcs = CashSalesForm.dgvsales.Rows(i).Cells(2).Value

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

    Public Sub GetData()


        Try


            If CashSalesForm.txtid.Text <> "" AndAlso CashSalesForm.txtName.Text <> "" AndAlso CashSalesForm.txtqty.Text <> "" AndAlso CashSalesForm.txtrate.Text <> "" AndAlso CashSalesForm.txtamt.Text <> "" AndAlso CashSalesForm.txtunitcost.Text <> "" AndAlso CashSalesForm.txtutot.Text <> "" AndAlso CashSalesForm.txtqtyin.Text <> "" AndAlso CashSalesForm.txtrate2.Text <> "" Then
                dtInvoice.Rows.Add(CashSalesForm.txtid.Text, CashSalesForm.txtName.Text, CashSalesForm.txtqty.Text, CashSalesForm.txtrate.Text, CashSalesForm.txtamt.Text, CashSalesForm.txtunitcost.Text, CashSalesForm.txtutot.Text, CashSalesForm.txtqtyin.Text, CashSalesForm.txtrate2.Text)
            End If

            CashSalesForm.txtName.Text = ""
            CashSalesForm.txtid.Text = ""
            CashSalesForm.cbodata.Text = ""
            CashSalesForm.txtqty.Text = "1"
            CashSalesForm.txtrate.Text = ""
            CashSalesForm.txtamt.Text = ""
            CashSalesForm.txtunitcost.Text = ""
            CashSalesForm.txtutot.Text = ""
            CashSalesForm.txtrate2.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CashSalesForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = CashSalesForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                CashSalesForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j

        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CashSalesForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = CashSalesForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                CashSalesForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k


        Catch ex As Exception

        End Try

        Try

            For g As Double = 0 To CashSalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CashSalesForm.dgvsales.Rows(g).Cells("Qty").Value
                Dim icell5 As Double = CashSalesForm.dgvsales.Rows(g).Cells("Qty In").Value

                Dim icellResultCost As Double = icell2 * icell5

                CashSalesForm.dgvsales.Rows(g).Cells("Total Qty In").Value = icellResultCost.ToString("n2")

            Next g


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To CashSalesForm.dgvsales.Rows.Count - 1
                totalSum += CashSalesForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            CashSalesForm.txtsubtot.Text = totalSum.ToString("n2")

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
            cmd.CommandText = "select MAX(cash_num)from cash_sales_warehouse_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                CashSalesForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                CashSalesForm.mSaleNo.Text = number
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
        Dim cmd As New SqlCommand("select supplier from beneficiary", conn) With {.CommandTimeout = 60}
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

            CashSalesForm.cboCustomer.Items.Clear()
            CashSalesForm.cboCustomer.Items.Add("")
            CashSalesForm.cboCustomer.Items.AddRange(names.ToArray)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub GetCash()

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

            CashSalesForm.cboPayMeth.Items.Clear()
            CashSalesForm.cboPayMeth.Items.Add("")
            CashSalesForm.cboPayMeth.Items.AddRange(names.ToArray)

        Catch ex As Exception

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

                CashSalesForm.txtsalesAcc.Text = dr.Item("coa_name")

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

                CashSalesForm.txtcogsAcc.Text = dr.Item("coa_name")

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

                CashSalesForm.txtInvAcc.Text = dr.Item("coa_name")

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

                CashSalesForm.txtdiscAcc.Text = dr.Item("coa_name")

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

                CashSalesForm.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(CashSalesForm.cboCustomer.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CashSalesForm.txtcustid.Text = dr.Item("id")

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

                CashSalesForm.txtvatval.Text = dr.Item("vat_num")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetSalesbyCust()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetWareSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetWareSalesbycustomers")
            cnn.Close()

            Dim report As New XtraSalesbycustomer
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = SalesbyCustomer.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            SalesbyCustomer.SalesbycustViewer.DocumentSource = report
            SalesbyCustomer.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesbyItems()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetWareSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetWareSalesbycustomers")
            cnn.Close()

            Dim report As New XtraSalesbyItems1
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = SalesbyItems.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            SalesbyItems.SalesbycustViewer.DocumentSource = report
            SalesbyItems.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesByDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetWareSaleitembyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_datefrom", SqlDbType.Date).Value = SalesbyItems.dtdatefrom.Text
                    cmd.Parameters.Add("@cash_dateto", SqlDbType.Date).Value = SalesbyItems.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetWareSaleitembyDate")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesbyItems.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        SalesbyItems.SalesbycustViewer.DocumentSource = report
                        SalesbyItems.SalesbycustViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesByDateProd()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetWareSaleitembyDateProd")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("p_cash_datefrom", SqlDbType.Date).Value = SalesbyItems.dtdatefrom.Text
                    cmd.Parameters.Add("p_cash_dateto", SqlDbType.Date).Value = SalesbyItems.dtdateto.Text
                    cmd.Parameters.Add("p_pro_descrip", SqlDbType.VarChar).Value = SalesbyItems.cboproduct.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetWareSaleitembyDateProd")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesbyItems.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        SalesbyItems.SalesbycustViewer.DocumentSource = report
                        SalesbyItems.SalesbycustViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesbyPayment()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetWareSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetWareSalesbycustomers")
            cnn.Close()

            Dim report As New XtraSalesbypaymentRep
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = SalesbyPayment.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            SalesbyPayment.SalesbycustViewer.DocumentSource = report
            SalesbyPayment.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetGeneralDailySales()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetWareSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetWareSalesbycustomers")
            cnn.Close()

            Dim report As New XtraDailySalesReport
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = GeneralDailyCashSales.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            GeneralDailyCashSales.SalesbycustViewer.DocumentSource = report
            GeneralDailyCashSales.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetGeneralDailySalesByDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetWareSalesbycustomersbydate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = GeneralDailyCashSales.dtdatefrom.Text
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = GeneralDailyCashSales.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetWareSalesbycustomersbydate")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = GeneralDailyCashSales.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        GeneralDailyCashSales.SalesbycustViewer.DocumentSource = report
                        GeneralDailyCashSales.SalesbycustViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

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

                SalesbyItems.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesbyCustomer.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesbyPayment.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                GeneralDailyCashSales.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CashSalesForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesbyYear()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSalesbymonth")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@yearint", SqlDbType.Int).Value = SalesChart.lblyears.Text
                    sda.SelectCommand = cmd
                    Using dsmonts As New DataSet

                        sda.Fill(dsmonts, "GetSalesbymonth")

                        SalesChart.monthlychart.Series("January").XValueMember = "Months"
                        SalesChart.monthlychart.Series("January").YValueMembers = "Jan"

                        SalesChart.monthlychart.Series("February").XValueMember = "Months"
                        SalesChart.monthlychart.Series("February").YValueMembers = "Feb"

                        SalesChart.monthlychart.Series("March").XValueMember = "Months"
                        SalesChart.monthlychart.Series("March").YValueMembers = "Mar"

                        SalesChart.monthlychart.Series("April").XValueMember = "Months"
                        SalesChart.monthlychart.Series("April").YValueMembers = "Apr"

                        SalesChart.monthlychart.Series("May").XValueMember = "Months"
                        SalesChart.monthlychart.Series("May").YValueMembers = "May"

                        SalesChart.monthlychart.Series("June").XValueMember = "Months"
                        SalesChart.monthlychart.Series("June").YValueMembers = "June"

                        SalesChart.monthlychart.Series("July").XValueMember = "Months"
                        SalesChart.monthlychart.Series("July").YValueMembers = "Jul"

                        SalesChart.monthlychart.Series("August").XValueMember = "Months"
                        SalesChart.monthlychart.Series("August").YValueMembers = "Aug"

                        SalesChart.monthlychart.Series("September").XValueMember = "Months"
                        SalesChart.monthlychart.Series("September").YValueMembers = "Sep"

                        SalesChart.monthlychart.Series("October").XValueMember = "Months"
                        SalesChart.monthlychart.Series("October").YValueMembers = "Oct"

                        SalesChart.monthlychart.Series("November").XValueMember = "Months"
                        SalesChart.monthlychart.Series("November").YValueMembers = "Nov"

                        SalesChart.monthlychart.Series("December").XValueMember = "Months"
                        SalesChart.monthlychart.Series("December").YValueMembers = "Dece"

                        SalesChart.monthlychart.DataSource = dsmonts.Tables("GetSalesbymonth")

                    End Using
                End Using
            End Using

            Dim strConn As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Dim conn As New SqlConnection(strConn)

            Dim sqlProducts As String = "Select * FROM sales_by_month_v where Year ='" & SalesChart.lblyears.Text & "'"
            Dim da As New SqlDataAdapter(sqlProducts, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "sales_by_month_v")

            SalesChart.monthlychart.Series("January").XValueMember = "Jan"
            SalesChart.monthlychart.Series("January").YValueMembers = "Jan"

            SalesChart.monthlychart.Series("February").XValueMember = "Feb"
            SalesChart.monthlychart.Series("February").YValueMembers = "Feb"

            SalesChart.monthlychart.Series("March").XValueMember = "Mar"
            SalesChart.monthlychart.Series("March").YValueMembers = "Mar"

            SalesChart.monthlychart.Series("April").XValueMember = "Apr"
            SalesChart.monthlychart.Series("April").YValueMembers = "Apr"

            SalesChart.monthlychart.Series("May").XValueMember = "May"
            SalesChart.monthlychart.Series("May").YValueMembers = "May"

            SalesChart.monthlychart.Series("June").XValueMember = "Jun"
            SalesChart.monthlychart.Series("June").YValueMembers = "Jun"

            SalesChart.monthlychart.Series("July").XValueMember = "Jul"
            SalesChart.monthlychart.Series("July").YValueMembers = "Jul"

            SalesChart.monthlychart.Series("August").XValueMember = "Aug"
            SalesChart.monthlychart.Series("August").YValueMembers = "Aug"

            SalesChart.monthlychart.Series("September").XValueMember = "Sept"
            SalesChart.monthlychart.Series("September").YValueMembers = "Sept"

            SalesChart.monthlychart.Series("October").XValueMember = "Oct"
            SalesChart.monthlychart.Series("October").YValueMembers = "Oct"

            SalesChart.monthlychart.Series("November").XValueMember = "Nov"
            SalesChart.monthlychart.Series("November").YValueMembers = "Nov"

            SalesChart.monthlychart.Series("December").XValueMember = "Dec"
            SalesChart.monthlychart.Series("December").YValueMembers = "Dec"

            SalesChart.monthlychart.DataSource = ds.Tables("sales_by_month_v")

        Catch ex As Exception

        End Try


    End Sub

    Public Sub GetSalesbylocations()

        Try

            SalesChart.dgvbestsell.RefreshDataSource()


            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetBestSellingProductbyLocation", Connection)

            ' Create and fill a dataset. 
            Dim dsBestPro As New DataSet()
            Adapter.Fill(dsBestPro)

            ' Specify the data source for the grid control. 
            SalesChart.dgvbestsell.DataSource = dsBestPro.Tables(0)


            ' Make the grid read-only.
            SalesChart.GridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            SalesChart.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            SalesChart.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus


        Catch ex As Exception

        End Try


    End Sub

    Public Sub GetFastmovingproducts()

        Try

            Dim strConn As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Dim conn As New SqlConnection(strConn)

            Dim sqlProducts As String = "Select * FROM getfastmovingitems"
            Dim da As New SqlDataAdapter(sqlProducts, conn)
            Dim ds As New DataSet()
            da.Fill(ds, "getfastmovingitems")

            'SalesChart.Chart1.Series("Products").XValueMember = "Products"
            'SalesChart.Chart1.Series("Products").YValueMembers = "Qty"

            'SalesChart.Chart1.DataSource = ds.Tables("getfastmovingitems")

        Catch ex As Exception

        End Try


    End Sub

    Public Sub CheckStoreStock()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT pro_descrip AS Items, pieces AS Qty, re_point AS [Re-order Point], location AS [Location] FROM   shelve_t WHERE  (re_point = pieces) OR (re_point > pieces) GROUP BY pro_descrip, pieces, re_point, location"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MainForm.btnstorestockalert.ForeColor = Color.Red
                MainForm.btnstorestockalert.ImageOptions.Image = Tophigh_Inventory.My.Resources.warning_32x32

            Else

                MainForm.btnstorestockalert.ForeColor = Color.Black
                MainForm.btnstorestockalert.ImageOptions.Image = Tophigh_Inventory.My.Resources.apply_32x32

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckWarehStock()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT  pro_descrip as Items,unit_cost as Cost, totpcs as [Total Remaining],re_point as [Re-Order Point] FROM  low_stock_v WHERE  (re_point = totpcs) OR (re_point > totpcs)"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MainForm.btncriticalproduct.ForeColor = Color.Red
                MainForm.btncriticalproduct.ImageOptions.Image = Tophigh_Inventory.My.Resources.warning_32x32

            Else

                MainForm.btncriticalproduct.ForeColor = Color.Black
                MainForm.btncriticalproduct.ImageOptions.Image = Tophigh_Inventory.My.Resources.apply_32x32

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearData()

        Try

            CashSalesForm.cboCustomer.Text = ""
            CashSalesForm.cboPayMeth.Text = ""
            CashSalesForm.mDescript.Clear()
            CashSalesForm.txtsaldisc.Text = "0.00"
            CashSalesForm.txtsubtot.Text = "0.00"
            CashSalesForm.txtTotal.Text = "0.00"
            CashSalesForm.txtreceive.Text = "0.00"
            CashSalesForm.txtchange.Text = "0.00"
            CashSalesForm.dgvsales.Columns.Clear()

            CashSalesForm.Close()
            CashSalesForm.Dispose()

            MainForm.btnsales.PerformClick()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrintDirectPOS()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetWarePOSReceipt")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = MainForm.txtwarecashid.Text
                    sda.SelectCommand = cmd
                    Using dsposPrint As New DataSet

                        sda.Fill(dsposPrint, "GetWarePOSReceipt")

                        Dim report As New EpsonReceiptReport
                        report.DataSource = dsposPrint
                        report.DataMember = "POS"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("mycomp").Value = CashSalesForm.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("mycomp").Visible = False
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

        CashSalesForm.Close()
        CashSalesForm.Dispose()

        MainForm.btnWholeCash.PerformClick()

    End Sub

End Class

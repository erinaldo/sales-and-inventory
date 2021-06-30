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
Imports MySql.Data.MySqlClient

Public Class POSClass2

    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String
    Dim sBuilder As SqlCommandBuilder
    Dim sTable As DataTable

    Dim objConn As New MySqlConnection
    Dim objCmd As New MySqlCommand
    Dim dtAdapter As New MySqlDataAdapter

    Dim objConns As New SqlConnection
    Dim objCmds As New SqlCommand
    Dim dtAdapters As New SqlDataAdapter

    Dim ds1 As New DataSet
    Dim dt1 As DataTable
    Dim ds2 As New DataSet
    Dim dt2 As DataTable
    Dim strConSrc, strConDest, strSQL1, strSQL2 As String

    Dim dtInvoice As New DataTable("dtInvoice")

    Dim index As Integer

    Shared random As New Random()

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub GetPOStNum()

        Try

            Dim xCharArray() As Char = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray
            Dim xNoArray() As Char = "0123456789".ToCharArray
            Dim xGenerator As System.Random = New System.Random()
            Dim xStr As String = String.Empty

            While xStr.Length < 6

                If xGenerator.Next(0, 2) = 0 Then
                    xStr &= xCharArray(xGenerator.Next(0, xCharArray.Length))
                Else
                    xStr &= xNoArray(xGenerator.Next(0, xNoArray.Length))
                End If

            End While

            POSForm2.txtposid.Text = xStr

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from ware_house_t where location ='" & convertQuotes(MainForm.txtlocation.Text) & "'group by pro_descrip", conn) With {.CommandTimeout = 60}
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

            'POSForm2.cbodata.Items.Clear()
            'POSForm2.cbodata.Items.Add("")
            'POSForm2.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDirectCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from ware_house_t where location ='" & convertQuotes(MainForm.txtlocation.Text) & "'group by pro_descrip", conn) With {.CommandTimeout = 60}
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

            SalesbyProductsForm.cboproduct.Items.Clear()
            SalesbyProductsForm.cboproduct.Items.Add("")
            SalesbyProductsForm.cboproduct.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckMember()
        Try
            If POSForm2.rbogen.Checked = True Then
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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where bar_code='" & convertQuotes(POSForm2.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where bar_code='" & convertQuotes(POSForm2.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                FillMemDataBoxBarcode()

            Else

                FillMemDataBox()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where pro_descrip like '%" & convertQuotes(POSForm2.cbodata.Text) & "%' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                POSForm2.txtid.Text = dr.Item("pro_id")
                POSForm2.txtName.Text = dr.Item("pro_descrip")
                POSForm2.txtproduct.Text = dr.Item("pro_descrip")
                POSForm2.txtamt.Text = dr.Item("sales_price")
                POSForm2.txtrate.Text = dr.Item("sales_price")
                POSForm2.txtunitcost.Text = dr.Item("unit_cost")
                POSForm2.txtutot.Text = dr.Item("unit_cost")
                POSForm2.txtbarcode.Text = dr.Item("bar_code")
                POSForm2.txtstock.Text = dr.Item("avlpcs")
                POSForm2.txtqty.Text = "1"

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where bar_code='" & convertQuotes(POSForm2.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                POSForm2.txtid.Text = dr.Item("pro_id")
                POSForm2.txtName.Text = dr.Item("pro_descrip")
                POSForm2.txtproduct.Text = dr.Item("pro_descrip")
                POSForm2.txtamt.Text = dr.Item("sales_price")
                POSForm2.txtrate.Text = dr.Item("sales_price")
                POSForm2.txtunitcost.Text = dr.Item("unit_cost")
                POSForm2.txtutot.Text = dr.Item("unit_cost")
                POSForm2.txtbarcode.Text = dr.Item("bar_code")
                POSForm2.txtstock.Text = dr.Item("avlpcs")
                POSForm2.txtqty.Text = "1"

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillMemDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where pro_descrip like '%" & convertQuotes(POSForm2.cbodata.Text) & "%' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                POSForm2.txtid.Text = dr.Item("pro_id")
                POSForm2.txtName.Text = dr.Item("pro_descrip")
                POSForm2.txtproduct.Text = dr.Item("pro_descrip")
                POSForm2.txtamt.Text = dr.Item("mem_sales_price")
                POSForm2.txtrate.Text = dr.Item("mem_sales_price")
                POSForm2.txtunitcost.Text = dr.Item("unit_cost")
                POSForm2.txtutot.Text = dr.Item("unit_cost")
                POSForm2.txtbarcode.Text = dr.Item("bar_code")
                POSForm2.txtstock.Text = dr.Item("avlpcs")
                POSForm2.txtqty.Text = "1"

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillMemDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where bar_code='" & convertQuotes(POSForm2.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                POSForm2.txtid.Text = dr.Item("pro_id")
                POSForm2.txtName.Text = dr.Item("pro_descrip")
                POSForm2.txtproduct.Text = dr.Item("pro_descrip")
                POSForm2.txtamt.Text = dr.Item("mem_sales_price")
                POSForm2.txtrate.Text = dr.Item("mem_sales_price")
                POSForm2.txtunitcost.Text = dr.Item("unit_cost")
                POSForm2.txtutot.Text = dr.Item("unit_cost")
                POSForm2.txtbarcode.Text = dr.Item("bar_code")
                POSForm2.txtstock.Text = dr.Item("avlpcs")
                POSForm2.txtqty.Text = "1"

                dr.Close()

            End If

        Catch oEX As Exception

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
            dtInvoice.Columns.Add("Sync".ToString, GetType(String))

            POSForm2.dgvsales.ReadOnly = False
            POSForm2.dgvsales.DataSource = dtInvoice
            POSForm2.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            POSForm2.dgvsales.Columns(5).Visible = False
            POSForm2.dgvsales.Columns(6).Visible = False
            POSForm2.dgvsales.Columns(0).Visible = False
            POSForm2.dgvsales.Columns(7).Visible = False
            POSForm2.dgvsales.Columns(3).ReadOnly = True

            POSForm2.dgvsales.ForeColor = Color.Black

            POSForm2.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            POSForm2.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            POSForm2.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            POSForm2.dgvsales.AllowUserToResizeColumns = False
            POSForm2.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            POSForm2.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrintDirectPOSMems()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetMemsPOSReceipt")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@pos_id", SqlDbType.VarChar).Value = POSForm2.txtposid.Text
                    sda.SelectCommand = cmd
                    Using dsposPrint As New DataSet

                        sda.Fill(dsposPrint, "GetMemsPOSReceipt")

                        Dim report As New EpsonReceiptReport
                        report.DataSource = dsposPrint
                        report.DataMember = "POS"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("mycomp").Value = POSForm2.txtcomp.Text
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

        POSForm2.Close()
        POSForm2.Dispose()

        MainForm.SimpleButton2.PerformClick()

    End Sub

    Public Sub PrintDirectPOS()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetPOSReceipt")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@pos_id", SqlDbType.VarChar).Value = POSForm2.txtposid.Text
                    sda.SelectCommand = cmd
                    Using dsposPrint As New DataSet

                        sda.Fill(dsposPrint, "GetPOSReceipt")

                        Dim report As New EpsonReceiptReport
                        report.DataSource = dsposPrint
                        report.DataMember = "POS"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("mycomp").Value = POSForm2.txtcomp.Text
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

        POSForm2.Close()
        POSForm2.Dispose()

        MainForm.SimpleButton2.PerformClick()

    End Sub

    'Public Sub SyncCashSales_t()


    '    Try

    '        Dim objConn As New MySqlConnection
    '        Dim objCmd As New MySqlCommand
    '        Dim dtAdapter As New MySqlDataAdapter

    '        Dim objConns As New SqlConnection
    '        Dim objCmds As New SqlCommand
    '        Dim dtAdapters As New SqlDataAdapter

    '        Dim ds1 As New DataSet
    '        Dim dt1 As DataTable
    '        Dim ds2 As New DataSet
    '        Dim dt2 As DataTable
    '        Dim strConSrc, strConDest, strSQL1, strSQL2 As String


    '        strConSrc = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
    '        strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

    '        strSQL1 = "Select * FROM cash_sales_t"
    '        strSQL2 = "Select * FROM cash_sales_t"

    '        objConns.ConnectionString = strConSrc
    '        With objCmds
    '            .Connection = objConns
    '            .CommandText = strSQL1
    '            .CommandType = CommandType.Text
    '        End With
    '        dtAdapters.SelectCommand = objCmds

    '        dtAdapters.Fill(ds1)
    '        dt1 = ds1.Tables(0)

    '        objConn.ConnectionString = strConDest
    '        With objCmd
    '            .Connection = objConn
    '            .CommandText = strSQL2
    '            .CommandType = CommandType.Text
    '        End With
    '        dtAdapter.SelectCommand = objCmd

    '        dtAdapter.Fill(ds2)
    '        dt2 = ds2.Tables(0)

    '        Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("sale_disc").ToString().Trim().ToLower() = r2("sale_disc").ToString().Trim().ToLower() AndAlso r("nettotal").ToString().Trim().ToLower() = r2("nettotal").ToString().Trim().ToLower() AndAlso r("amt_rece").ToString().Trim().ToLower() = r2("amt_rece").ToString().Trim().ToLower() AndAlso r("amt_change").ToString().Trim().ToLower() = r2("amt_change").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("card_check_num").ToString().Trim().ToLower() = r2("card_check_num").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

    '        For j As Integer = 0 To dt3.Rows.Count - 1

    '            Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
    '            Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into cash_sales_temp_t (cash_num, cash_date, pay_meth, items, qty, rate, vat, amount, sale_disc, nettotal, amt_rece, amt_change, ent_time, customer, `user`, sales_descript, card_check_num, location, syncode) values(@cash_num, @cash_date, @pay_meth, @items, @qty, @rate, @vat, @amount, @sale_disc, @nettotal, @amt_rece, @amt_change, @ent_time, @customer, @user, @sales_descript, @card_check_num, @location, @syncode)"}
    '            cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
    '            cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
    '            cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
    '            cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
    '            cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
    '            cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
    '            cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
    '            cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
    '            cmd.Parameters.Add("@sale_disc", MySqlDbType.VarChar).Value = dt3.Rows(j)("sale_disc")
    '            cmd.Parameters.Add("@nettotal", MySqlDbType.Float).Value = dt3.Rows(j)("nettotal")
    '            cmd.Parameters.Add("@amt_rece", MySqlDbType.Float).Value = dt3.Rows(j)("amt_rece")
    '            cmd.Parameters.Add("@amt_change", MySqlDbType.Float).Value = dt3.Rows(j)("amt_change")
    '            cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
    '            cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
    '            cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
    '            cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
    '            cmd.Parameters.Add("@card_check_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("card_check_num")
    '            cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
    '            cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
    '            cmd.Connection = cnn

    '            cnn.Open()
    '            cmd.ExecuteNonQuery()
    '            objConn.Close()
    '            cnn.Close()

    '        Next

    '    Catch ex As Exception

    '    End Try

    'End Sub

    Public Sub InsertCashSales()

        Try


            POSForm2.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertSalesDisc()

            Dim dgvItem, dgvqty, dgvrate, dgvamount, dgvsync As String

            For i As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                dgvItem = POSForm2.dgvsales.Rows(i).Cells(1).Value
                dgvqty = POSForm2.dgvsales.Rows(i).Cells(2).Value
                dgvrate = POSForm2.dgvsales.Rows(i).Cells(3).Value
                dgvamount = POSForm2.dgvsales.Rows(i).Cells(4).Value
                dgvsync = POSForm2.dgvsales.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCashSalesData"}
                cmd.Parameters.Add("@pos_id", SqlDbType.VarChar).Value = POSForm2.txtposid.Text.Trim()
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = POSForm2.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = POSForm2.cboPayMeth.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = POSForm2.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@sale_disc", SqlDbType.Float).Value = POSForm2.txtsaldisc.Text.Trim()
                cmd.Parameters.Add("@nettotal", SqlDbType.Float).Value = POSForm2.txtTotal.Text.Trim()
                cmd.Parameters.Add("@amt_rece", SqlDbType.Float).Value = POSForm2.txtreceive.Text.Trim()
                cmd.Parameters.Add("@amt_change", SqlDbType.Float).Value = POSForm2.txtchange.Text.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = POSForm2.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = "Todays Sales @ '" & POSForm2.lblTime.Text & "'"
                cmd.Parameters.Add("@card_check_num", SqlDbType.VarChar).Value = POSForm2.txtref.Text.Trim()
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

        'SyncCashSales_t

        PrintDirectPOS()

    End Sub

    Public Sub InsertMemsCashSales()

        Try

            POSForm2.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertSalesDisc()

            Dim dgvItem, dgvqty, dgvrate, dgvamount, dgvsync As String

            For i As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                dgvItem = POSForm2.dgvsales.Rows(i).Cells(1).Value
                dgvqty = POSForm2.dgvsales.Rows(i).Cells(2).Value
                dgvrate = POSForm2.dgvsales.Rows(i).Cells(3).Value
                dgvamount = POSForm2.dgvsales.Rows(i).Cells(4).Value
                dgvsync = POSForm2.dgvsales.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCashSalesMems"}
                cmd.Parameters.Add("@pos_id", SqlDbType.VarChar).Value = POSForm2.txtposid.Text.Trim()
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = POSForm2.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = POSForm2.cboPayMeth.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = POSForm2.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@sale_disc", SqlDbType.Float).Value = POSForm2.txtsaldisc.Text.Trim()
                cmd.Parameters.Add("@nettotal", SqlDbType.Float).Value = POSForm2.txtTotal.Text.Trim()
                cmd.Parameters.Add("@amt_rece", SqlDbType.Float).Value = POSForm2.txtreceive.Text.Trim()
                cmd.Parameters.Add("@amt_change", SqlDbType.Float).Value = POSForm2.txtchange.Text.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = POSForm2.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = "Todays Sales @ '" & POSForm2.lblTime.Text & "'"
                cmd.Parameters.Add("@card_check_num", SqlDbType.VarChar).Value = POSForm2.txtref.Text.Trim()
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

        PrintDirectPOSMems()

    End Sub

    Public Sub InsertCogs()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                dgvcogstot = POSForm2.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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

            For i As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                dgvcogstot = POSForm2.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.cboPayMeth.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = POSForm2.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = POSForm2.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.txtdiscAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = POSForm2.txtsaldisc.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = POSForm2.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = POSForm2.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = POSForm2.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = POSForm2.txtvat.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = POSForm2.lblTime.Text
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

            Dim dgvid, dgvqty As String

            For i As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                dgvid = POSForm2.dgvsales.Rows(i).Cells(0).Value
                dgvqty = POSForm2.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShQty"}
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.BigInt).Value = dgvid.Trim()
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

            If POSForm2.txtid.Text <> "" AndAlso POSForm2.txtName.Text <> "" AndAlso POSForm2.txtqty.Text <> "" AndAlso POSForm2.txtrate.Text <> "" AndAlso POSForm2.txtamt.Text <> "" AndAlso POSForm2.txtunitcost.Text <> "" AndAlso POSForm2.txtutot.Text <> "" AndAlso POSForm2.txtsyncode.Text <> "" Then
                dtInvoice.Rows.Add(POSForm2.txtid.Text, POSForm2.txtName.Text, POSForm2.txtqty.Text, POSForm2.txtrate.Text, POSForm2.txtamt.Text, POSForm2.txtunitcost.Text, POSForm2.txtutot.Text, POSForm2.txtsyncode.Text)
            End If

            POSForm2.txtName.Text = ""
            POSForm2.txtid.Text = ""
            POSForm2.cbodata.Text = ""
            POSForm2.txtqty.Text = "1"
            POSForm2.txtrate.Text = "0.00"
            POSForm2.txtamt.Text = ""
            POSForm2.txtunitcost.Text = ""
            POSForm2.txtutot.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                Dim icell2 As Double = POSForm2.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = POSForm2.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                POSForm2.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try

            For k As Integer = 0 To POSForm2.dgvsales.Rows.Count - 1

                Dim icell2 As Double = POSForm2.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = POSForm2.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                POSForm2.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k

        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Decimal = 0 To POSForm2.dgvsales.Rows.Count - 1
                totalSum += POSForm2.dgvsales.Rows(i).Cells("Amount").Value
            Next

            POSForm2.txtsubtot.Text = totalSum.ToString("n2")

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
            cmd.CommandText = "select MAX(cash_num)from cash_sales_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                POSForm2.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                POSForm2.mSaleNo.Text = number
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
            cmd.CommandText = "select MAX(cash_num)from cash_sales_mems_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                POSForm2.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                POSForm2.mSaleNo.Text = number
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
        Dim cmd As New SqlCommand("select customer from other_cust_v", conn) With {.CommandTimeout = 60}
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

            POSForm2.cboCustomer.Items.Clear()
            POSForm2.cboCustomer.Items.Add("Walk in Customer")
            POSForm2.cboCustomer.Items.AddRange(names.ToArray)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillMembers()

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

            POSForm2.cboCustomer.Items.Clear()
            POSForm2.cboCustomer.Items.Add("")
            POSForm2.cboCustomer.Items.AddRange(names.ToArray)
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

            POSForm2.cboPayMeth.Items.Clear()
            POSForm2.cboPayMeth.Items.Add("")
            POSForm2.cboPayMeth.Items.AddRange(names.ToArray)

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

                POSForm2.txtsalesAcc.Text = dr.Item("coa_name")

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

                POSForm2.txtcogsAcc.Text = dr.Item("coa_name")

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

                POSForm2.txtInvAcc.Text = dr.Item("coa_name")

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

                POSForm2.txtdiscAcc.Text = dr.Item("coa_name")

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

                POSForm2.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from customer_v Where supplier='" & convertQuotes(POSForm2.cboCustomer.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                POSForm2.txtcustid.Text = dr.Item("id")

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

                POSForm2.txtvatval.Text = dr.Item("vat_num")

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
            Const sql As String = "GetSalesbyProducts"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetSalesbyProducts")
            cnn.Close()

            Dim report As New XtraSalesbyItems1
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = CSalesbyItemsForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            SalesbyProductsForm.SalesbycustViewer.DocumentSource = report
            SalesbyProductsForm.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesByDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSaleitembyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_datefrom", SqlDbType.Date).Value = SalesbyProductsForm.dtdatefrom.Text
                    cmd.Parameters.Add("@cash_dateto", SqlDbType.Date).Value = SalesbyProductsForm.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetSaleitembyDate")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesbyProductsForm.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        SalesbyProductsForm.SalesbycustViewer.DocumentSource = report
                        SalesbyProductsForm.SalesbycustViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesByDateProd()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSaleitembyDateProd")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_datefrom", SqlDbType.Date).Value = SalesbyProductsForm.dtdatefrom.Text
                    cmd.Parameters.Add("@cash_dateto", SqlDbType.Date).Value = SalesbyProductsForm.dtdateto.Text
                    cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = SalesbyProductsForm.cboproduct.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetSaleitembyDateProd")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SalesbyProductsForm.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        SalesbyProductsForm.SalesbycustViewer.DocumentSource = report
                        SalesbyProductsForm.SalesbycustViewer.Refresh()

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
            Const sql As String = "GetSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetSalesbycustomers")
            cnn.Close()

            Dim report As New XtraSalesbypaymentRep
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = CSalesbyPaymentForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            CSalesbyPaymentForm.SalesbycustViewer.DocumentSource = report
            CSalesbyPaymentForm.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetGeneralDailySales()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetSalesbycustomers"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetSalesbycustomers")
            cnn.Close()

            Dim report As New XtraDailySalesReport
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = CSalesReportForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            CSalesReportForm.SalesbycustViewer.DocumentSource = report
            CSalesReportForm.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetMemGeneralDailySales()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsSalesbycustomer As New DataSet
            Const sql As String = "GetSalesbycustomersMem"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsSalesbycustomer, "GetSalesbycustomersMem")
            cnn.Close()

            Dim report As New XtraDailySalesReport
            report.DataSource = dsSalesbycustomer
            report.DataMember = "salesbycustomer"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = MembersCashSalesReportForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            MembersCashSalesReportForm.SalesbycustViewer.DocumentSource = report
            MembersCashSalesReportForm.SalesbycustViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub


    Public Sub GetGeneralDailySalesByDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSalesbycustomersbydate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = CSalesReportForm.dtdatefrom.Text
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = CSalesReportForm.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetSalesbycustomersbydate")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = CSalesReportForm.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        CSalesReportForm.SalesbycustViewer.DocumentSource = report
                        CSalesReportForm.SalesbycustViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetMemGeneralDailySalesByDate()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSalesbycustomersMembydate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@datefrom", SqlDbType.Date).Value = MembersCashSalesReportForm.dtdatefrom.Text
                    cmd.Parameters.Add("@dateto", SqlDbType.Date).Value = MembersCashSalesReportForm.dtdateto.Text
                    sda.SelectCommand = cmd
                    Using dsSalesbycustomer As New DataSet

                        sda.Fill(dsSalesbycustomer, "GetSalesbycustomersMembydate")

                        Dim report As New XtraDailySalesReport
                        report.DataSource = dsSalesbycustomer
                        report.DataMember = "salesbycustomer"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = MembersCashSalesReportForm.txtcomp.Text
                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.CreateDocument()
                        MembersCashSalesReportForm.SalesbycustViewer.DocumentSource = report
                        MembersCashSalesReportForm.SalesbycustViewer.Refresh()

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

                MembersCashSalesReportForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                POSForm2.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesbyItems.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesbyCustomer.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SalesbyPayment.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                CSalesReportForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetFastMoveitems()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim conn As New SqlConnection(conString)
            Dim ds As New DataSet()

            Try
                conn.Open()
                Dim cmd As New SqlCommand("Select * FROM GetFastMovingItems ", conn)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                da.Fill(ds, "GetFastMovingItems")
                'SalesChart.Chart1.DataSource = ds.Tables("GetFastMovingItems")

                'SalesChart.Chart1.Series("Products").XValueMember = "Products"
                'SalesChart.Chart1.Series("Products").YValueMembers = "Qty"

                '' Set chart type like Bar chart, Pie chart 
                'SalesChart.Chart1.Series("Products").ChartType = SeriesChartType.Area
                '' To show chart value           
                'SalesChart.Chart1.Series("Products").IsValueShownAsLabel = True


                'Exception Message
            Catch ex As Exception
            Finally

                conn.Close()
                conn.Dispose()

            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesbylocation()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim conn As New SqlConnection(conString)
            Dim ds As New DataSet()

            Try
                conn.Open()
                Dim cmd As New SqlCommand("Select * FROM sales_by_location_v", conn)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                da.Fill(ds, "sales_by_location_v")
                'SalesChart.Chart2.DataSource = ds.Tables("sales_by_location_v")

                'SalesChart.Chart2.Series("Locations").XValueMember = "location"
                'SalesChart.Chart2.Series("Locations").YValueMembers = "Sales"

                '' Set chart type like Bar chart, Pie chart 
                'SalesChart.Chart2.Series("Locations").ChartType = SeriesChartType.Pie
                '' To show chart value           
                'SalesChart.Chart2.Series("Locations").IsValueShownAsLabel = True


                'Exception Message
            Catch ex As Exception
            Finally

                conn.Close()
                conn.Dispose()

            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesbyYear()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim conn As New SqlConnection(conString)
            Dim ds As New DataSet()

            Try
                conn.Open()
                Dim cmd As New SqlCommand("Select * FROM sales_analysis_temp_v", conn)
                Dim da As New SqlDataAdapter()
                da.SelectCommand = cmd
                da.Fill(ds, "sales_analysis_temp_v")
                'SalesChart.Chart3.DataSource = ds.Tables("sales_analysis_temp_v")

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Jan"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Feb"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Mar"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Apr"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "May"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "June"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Jul"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Aug"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Sep"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Oct"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Nov"

                'SalesChart.Chart3.Series("Year").XValueMember = "Year"
                'SalesChart.Chart3.Series("Year").YValueMembers = "Dec"

                '' Set chart type like Bar chart, Pie chart 
                'SalesChart.Chart3.Series("Sales by Month").ChartType = SeriesChartType.Pie
                '' To show chart value           
                'SalesChart.Chart3.Series("Sales by Month").IsValueShownAsLabel = True


                'Exception Message
            Catch ex As Exception
            Finally

                conn.Close()
                conn.Dispose()

            End Try

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

    Public Sub NewData()

        Try

            POSForm2.txtName.Text = ""
            POSForm2.txtid.Text = ""
            POSForm2.cbodata.Text = ""
            POSForm2.txtqty.Text = "1"
            POSForm2.txtrate.Text = "0.00"
            POSForm2.txtamt.Text = ""
            POSForm2.txtunitcost.Text = ""
            POSForm2.txtutot.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Public Sub AutoCompleteList()

        Try

            POSForm2.lvdrop.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("Select pro_descrip as Product,avlpcs as [Qty on hand],sales_price as Price from low_stock_v Where pro_descrip like '%" & convertQuotes(POSForm2.cbodata.Text) & "%' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'", Connection)

            ' Create and fill a dataset. 
            Dim dsProduct As New DataSet()
            Adapter.Fill(dsProduct)

            ' Specify the data source for the grid control. 
            POSForm2.lvdrop.DataSource = dsProduct.Tables(0)

            ' Make the grid read-only.
            POSForm2.GridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            POSForm2.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            POSForm2.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        Catch oex As Exception

        End Try

    End Sub

End Class


Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Data
Imports System.Reflection
Imports ClosedXML.Excel
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports MySql.Data.MySqlClient

Public Class ItemsClass

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim dtInvoice As New DataTable("dtInvoice")
    Dim dtShelBatch As New DataTable("dtShelBatch")

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

    Private Index As Integer = 0

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub GetInv()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraItemsForm.cboinv.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetOp()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='cp'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraItemsForm.cboop.Text = dr.Item("coa_name")

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

            XtraItemsForm.cbolocation.Properties.Items.Clear()
            XtraItemsForm.cbolocation.Properties.Items.Add("")
            XtraItemsForm.cbolocation.Properties.Items.AddRange(names.ToArray)

            DeffectiveItemsForm.cbolocation.Properties.Items.Clear()
            DeffectiveItemsForm.cbolocation.Properties.Items.Add("")
            DeffectiveItemsForm.cbolocation.Properties.Items.AddRange(names.ToArray)

            XtraReceiveOderForm.cbolocation.Properties.Items.Clear()
            XtraReceiveOderForm.cbolocation.Properties.Items.Add("")
            XtraReceiveOderForm.cbolocation.Properties.Items.AddRange(names.ToArray)

            ReceivedPushForm.cbolocation.Items.Clear()
            ReceivedPushForm.cbolocation.Items.Add("")
            ReceivedPushForm.cbolocation.Items.AddRange(names.ToArray)

            MoveToStoreForm.cbowarelocation.Items.Clear()
            MoveToStoreForm.cbowarelocation.Items.Add("")
            MoveToStoreForm.cbowarelocation.Items.AddRange(names.ToArray)

            MoveToStoreForm.cbostorelocation.Items.Clear()
            MoveToStoreForm.cbostorelocation.Items.Add("")
            MoveToStoreForm.cbostorelocation.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillSup()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT supplier FROM beneficiary group by supplier", conn) With {.CommandTimeout = 60}
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

            XtraItemsForm.cbosupplier.Properties.Items.Clear()
            XtraItemsForm.cbosupplier.Properties.Items.Add("")
            XtraItemsForm.cbosupplier.Properties.Items.AddRange(names.ToArray)

            XtraPuchaseOrderForm.cbosup.Properties.Items.Clear()
            XtraPuchaseOrderForm.cbosup.Properties.Items.Add("")
            XtraPuchaseOrderForm.cbosup.Properties.Items.AddRange(names.ToArray)

            XtraReceiveOderForm.cboRecFrom.Properties.Items.Clear()
            XtraReceiveOderForm.cboRecFrom.Properties.Items.Add("")
            XtraReceiveOderForm.cboRecFrom.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCate()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT categories FROM category_t", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("categories").ToString)
            End While
            rd.Close()
            conn.Close()

            XtraItemsForm.cbotype.Properties.Items.Clear()
            XtraItemsForm.cbotype.Properties.Items.Add("")
            XtraItemsForm.cbotype.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub AddNewWarehouse()

        Try

            Dim t1 As Integer = XtraItemsForm.txtqtybox.Text
            Dim t2 As Integer = XtraItemsForm.txtqtyin.Text
            Dim t3 As Integer = XtraItemsForm.txtpiece.Text
            Dim t4 As Integer = (t2 * t1) + t3

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertwarehouse"}
            cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = XtraItemsForm.cbotype.Text.Trim()
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = XtraItemsForm.txtbarcode.Text.Trim()
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = XtraItemsForm.txtprodescrip.Text.Trim()
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = XtraItemsForm.txtunitcost.Text.Trim()
            cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = XtraItemsForm.txtsalesprice.Text.Trim()
            cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = XtraItemsForm.txtmemprice.Text.Trim()
            cmd.Parameters.Add("@whole_sales_price", SqlDbType.Float).Value = XtraItemsForm.txtwhsl.Text.Trim()
            cmd.Parameters.Add("@qty_ctn", SqlDbType.Float).Value = XtraItemsForm.txtqtybox.Text.Trim()
            cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = XtraItemsForm.txtpiece.Text.Trim()
            cmd.Parameters.Add("@re_point", SqlDbType.Float).Value = XtraItemsForm.txtreoder.Text.Trim()
            cmd.Parameters.Add("@qtyinbox", SqlDbType.Float).Value = XtraItemsForm.txtqtyin.Text.Trim()
            cmd.Parameters.Add("@totpieces", SqlDbType.Float).Value = t4
            cmd.Parameters.Add("@manufac_date", SqlDbType.Date).Value = XtraItemsForm.dtmanudate.Text.Trim()
            cmd.Parameters.Add("@expiry_date", SqlDbType.Date).Value = XtraItemsForm.dtexpirdate.Text.Trim()
            cmd.Parameters.Add("@supplier", SqlDbType.VarChar).Value = XtraItemsForm.cbosupplier.Text.Trim()
            cmd.Parameters.Add("@purchase_date", SqlDbType.Date).Value = XtraItemsForm.dtpurchasedate.Text.Trim()
            cmd.Parameters.Add("@qty_out", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@totpieces_out", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@pieces_out", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraItemsForm.cbolocation.Text.Trim()
            cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = "0"
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            InsertMoveToShelv()

            'SyncShelve_t()

            InsertinvDebit()
            InsertopCredit()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub insert_stock_hist()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into stock_history_t (hist_date,product,qtyonhand,qty,ent_time,sys_user,user_location) Values(@hist_date,@product,@qtyonhand,@qty,@ent_time,@sys_user,@user_location)"}
            cmd.Parameters.Add("@hist_date", SqlDbType.Date).Value = XtraItemsForm.dtpurchasedate.Text.Trim()
            cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = XtraItemsForm.txtprodescrip.Text.Trim()
            cmd.Parameters.Add("@qtyonhand", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@qty", SqlDbType.Float).Value = XtraItemsForm.txttotP.Text.Trim()
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = XtraItemsForm.lbltimer.Text.Trim()
            cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
            cmd.Parameters.Add("@user_location", SqlDbType.VarChar).Value = MainForm.lbllocation.Text.Trim()
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    'Public Sub SyncShelve_t()


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

    '        strSQL1 = "SELECT  *  FROM   shelve_t"
    '        strSQL2 = "SELECT  *  FROM   shelve_t"

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

    '        Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("pro_id").ToString().Trim().ToLower() = r2("pro_id").ToString().Trim().ToLower() AndAlso r("wp_pro_id").ToString().Trim().ToLower() = r2("wp_pro_id").ToString().Trim().ToLower() AndAlso r("cate").ToString().Trim().ToLower() = r2("cate").ToString().Trim().ToLower() AndAlso r("bar_code").ToString().Trim().ToLower() = r2("bar_code").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("sales_price").ToString().Trim().ToLower() = r2("sales_price").ToString().Trim().ToLower() AndAlso r("mem_sales_price").ToString().Trim().ToLower() = r2("mem_sales_price").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("pieces").ToString().Trim().ToLower() = r2("pieces").ToString().Trim().ToLower() AndAlso r("re_point").ToString().Trim().ToLower() = r2("re_point").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

    '        For j As Int32 = 0 To dt3.Rows.Count - 1

    '            Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
    '            Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into shelve_temp_t (wp_pro_id,cate, bar_code, pro_descrip, sales_price, mem_sales_price, unit_cost, pieces, re_point, location, syncode) values(@wp_pro_id,@cate, @bar_code, @pro_descrip, @sales_price, @mem_sales_price, @unit_cost, @pieces, @re_point, @location, @syncode)"}
    '            cmd.Parameters.Add("@wp_pro_id", MySqlDbType.Int32).Value = dt3.Rows(j)("wp_pro_id")
    '            cmd.Parameters.Add("@cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cate")
    '            cmd.Parameters.Add("@bar_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("bar_code")
    '            cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
    '            cmd.Parameters.Add("@sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("sales_price")
    '            cmd.Parameters.Add("@mem_sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("mem_sales_price")
    '            cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
    '            cmd.Parameters.Add("@pieces", MySqlDbType.Float).Value = dt3.Rows(j)("pieces")
    '            cmd.Parameters.Add("@re_point", MySqlDbType.Float).Value = dt3.Rows(j)("re_point")
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

    '    SyncWareHouse_t()

    'End Sub


    Public Sub SyncWareHouse_t()


        Try

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


            strConSrc = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

            strSQL1 = "SELECT  * FROM  ware_house_t"
            strSQL2 = "SELECT  * FROM  ware_house_t"

            objConns.ConnectionString = strConSrc
            With objCmds
                .Connection = objConns
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapters.SelectCommand = objCmds

            dtAdapters.Fill(ds1)
            dt1 = ds1.Tables(0)

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds2)
            dt2 = ds2.Tables(0)

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("pro_id").ToString().Trim().ToLower() = r2("pro_id").ToString().Trim().ToLower() AndAlso r("cate").ToString().Trim().ToLower() = r2("cate").ToString().Trim().ToLower() AndAlso r("bar_code").ToString().Trim().ToLower() = r2("bar_code").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("sales_price").ToString().Trim().ToLower() = r2("sales_price").ToString().Trim().ToLower() AndAlso r("mem_sales_price").ToString().Trim().ToLower() = r2("mem_sales_price").ToString().Trim().ToLower() AndAlso r("whole_sales_price").ToString().Trim().ToLower() = r2("whole_sales_price").ToString().Trim().ToLower() AndAlso r("qty_ctn").ToString().Trim().ToLower() = r2("qty_ctn").ToString().Trim().ToLower() AndAlso r("pieces").ToString().Trim().ToLower() = r2("pieces").ToString().Trim().ToLower() AndAlso r("re_point").ToString().Trim().ToLower() = r2("re_point").ToString().Trim().ToLower() AndAlso r("qtyinbox").ToString().Trim().ToLower() = r2("qtyinbox").ToString().Trim().ToLower() AndAlso r("totpieces").ToString().Trim().ToLower() = r2("totpieces").ToString().Trim().ToLower() AndAlso r("manufac_date").ToString().Trim().ToLower() = r2("manufac_date").ToString().Trim().ToLower() AndAlso r("expiry_date").ToString().Trim().ToLower() = r2("expiry_date").ToString().Trim().ToLower() AndAlso r("supplier").ToString().Trim().ToLower() = r2("supplier").ToString().Trim().ToLower() AndAlso r("purchase_date").ToString().Trim().ToLower() = r2("purchase_date").ToString().Trim().ToLower() AndAlso r("qty_out").ToString().Trim().ToLower() = r2("qty_out").ToString().Trim().ToLower() AndAlso r("totpieces_out").ToString().Trim().ToLower() = r2("totpieces_out").ToString().Trim().ToLower() AndAlso r("pieces_out").ToString().Trim().ToLower() = r2("pieces_out").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("adjust_qty").ToString().Trim().ToLower() = r2("adjust_qty").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into ware_house_temp_t (cate, bar_code, pro_descrip, unit_cost, sales_price, mem_sales_price, whole_sales_price, qty_ctn, pieces, re_point, qtyinbox, totpieces, manufac_date, expiry_date, supplier, purchase_date, qty_out, totpieces_out,  pieces_out, location, adjust_qty, syncode) values(@cate, @bar_code, @pro_descrip, @unit_cost, @sales_price, @mem_sales_price, @whole_sales_price, @qty_ctn, @pieces, @re_point, @qtyinbox, @totpieces, @manufac_date, @expiry_date, @supplier, @purchase_date, @qty_out, @totpieces_out,  @pieces_out, @location, @adjust_qty, @syncode)"}
                cmd.Parameters.Add("@cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cate")
                cmd.Parameters.Add("@bar_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("bar_code")
                cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("sales_price")
                cmd.Parameters.Add("@mem_sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("mem_sales_price")
                cmd.Parameters.Add("@whole_sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("whole_sales_price")
                cmd.Parameters.Add("@qty_ctn", MySqlDbType.Float).Value = dt3.Rows(j)("qty_ctn")
                cmd.Parameters.Add("@pieces", MySqlDbType.Float).Value = dt3.Rows(j)("pieces")
                cmd.Parameters.Add("@re_point", MySqlDbType.Float).Value = dt3.Rows(j)("re_point")
                cmd.Parameters.Add("@qtyinbox", MySqlDbType.Float).Value = dt3.Rows(j)("qtyinbox")
                cmd.Parameters.Add("@totpieces", MySqlDbType.Float).Value = dt3.Rows(j)("totpieces")
                cmd.Parameters.Add("@manufac_date", MySqlDbType.Date).Value = dt3.Rows(j)("manufac_date")
                cmd.Parameters.Add("@expiry_date", MySqlDbType.Date).Value = dt3.Rows(j)("expiry_date")
                cmd.Parameters.Add("@supplier", MySqlDbType.VarChar).Value = dt3.Rows(j)("supplier")
                cmd.Parameters.Add("@purchase_date", MySqlDbType.Date).Value = dt3.Rows(j)("purchase_date")
                cmd.Parameters.Add("@qty_out", MySqlDbType.Float).Value = dt3.Rows(j)("qty_out")
                cmd.Parameters.Add("@totpieces_out", MySqlDbType.Float).Value = dt3.Rows(j)("totpieces_out")
                cmd.Parameters.Add("@pieces_out", MySqlDbType.Float).Value = dt3.Rows(j)("pieces_out")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@adjust_qty", MySqlDbType.Float).Value = dt3.Rows(j)("adjust_qty")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try


    End Sub


    Public Sub InsertMoveToShelv()

        Try

            Dim t1 As Integer = XtraItemsForm.txtqtybox.Text
            Dim t2 As Integer = XtraItemsForm.txtqtyin.Text
            Dim t3 As Integer = XtraItemsForm.txtpiece.Text
            Dim t4 As Integer = (t2 * t1) + t3

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertMoveToShelve"}
            cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = XtraItemsForm.cbotype.Text.Trim()
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = XtraItemsForm.txtbarcode.Text.Trim()
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = XtraItemsForm.txtprodescrip.Text.Trim()
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = XtraItemsForm.txtunitcost.Text.Trim()
            cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = XtraItemsForm.txtsalesprice.Text.Trim()
            cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = XtraItemsForm.txtmemprice.Text.Trim()
            cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = t4
            cmd.Parameters.Add("@new_date", SqlDbType.Date).Value = XtraItemsForm.dtpurchasedate.Text.Trim()
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "new"
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertMoveToShelv_temp()

        Try

            MoveToStoreForm.dgvbulk.AllowUserToAddRows = False

            Dim dgvcate, dgvbar, dgvpro, dgvprice, dgvucost, dgvmemprice, dgvqty, dgvreorder As String

            For i As Integer = 0 To MoveToStoreForm.dgvbulk.Rows.Count - 1

                dgvcate = MoveToStoreForm.dgvbulk.Rows(i).Cells(2).Value
                dgvbar = MoveToStoreForm.dgvbulk.Rows(i).Cells(3).Value
                dgvpro = MoveToStoreForm.dgvbulk.Rows(i).Cells(4).Value
                dgvprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(6).Value
                dgvucost = MoveToStoreForm.dgvbulk.Rows(i).Cells(5).Value
                dgvmemprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(7).Value
                dgvqty = MoveToStoreForm.dgvbulk.Rows(i).Cells(9).Value
                dgvreorder = MoveToStoreForm.dgvbulk.Rows(i).Cells(10).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into move_to_shelve_temp_t (cate,bar_code,pro_descrip,sales_price,mem_sales_price,unit_cost,pieces,re_order,status,loca) values(@cate,@bar_code,@pro_descrip,@sales_price,@mem_sales_price,@unit_cost,@pieces,@re_order,@status,@loca)"}
                cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = dgvcate.Trim()
                cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = dgvbar.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim()
                cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@re_order", SqlDbType.Float).Value = dgvreorder.Trim()
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "new"
                cmd.Parameters.Add("@loca", SqlDbType.VarChar).Value = MoveToStoreForm.cbostorelocation.Text.Trim()
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                cnn.Close()

            Next i

        Catch ex As Exception

        End Try

        DeleteMoveZero()


    End Sub

    Public Sub InsertinvDebit()

        Try

            Dim t1 As Integer = XtraItemsForm.txtqtybox.Text
            Dim t2 As Integer = XtraItemsForm.txtqtyin.Text
            Dim t3 As Integer = XtraItemsForm.txtpiece.Text
            Dim t4 As Integer = (t1 * t2) + t3
            Dim t5 As Double = XtraItemsForm.txtunitcost.Text
            Dim t6 As Double = t5 * t4

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = XtraItemsForm.dtpurchasedate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = XtraItemsForm.cboinv.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = t6
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraItemsForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertopCredit()

        Try

            Dim t1 As Integer = XtraItemsForm.txtqtybox.Text
            Dim t2 As Integer = XtraItemsForm.txtqtyin.Text
            Dim t3 As Integer = XtraItemsForm.txtpiece.Text
            Dim t4 As Integer = (t1 * t2) + t3
            Dim t5 As Double = XtraItemsForm.txtunitcost.Text
            Dim t6 As Double = t5 * t4

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = XtraItemsForm.dtpurchasedate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = XtraItemsForm.cboop.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = t6
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraItemsForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            Cleartext()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Cleartext()

        Try

            XtraItemsForm.cbotype.Text = ""
            XtraItemsForm.txtbarcode.Text = ""
            XtraItemsForm.txtprodescrip.Text = ""
            XtraItemsForm.txtunitcost.Text = "0.00"
            XtraItemsForm.txtsalesprice.Text = "0.00"
            XtraItemsForm.txtwhsl.Text = "0.00"
            XtraItemsForm.txtqtybox.Text = "0"
            XtraItemsForm.txtpiece.Text = "0"
            XtraItemsForm.txtreoder.Text = "0"
            XtraItemsForm.txtqtyin.Text = "0"
            XtraItemsForm.dtmanudate.Text = ""
            XtraItemsForm.dtexpirdate.Text = ""
            XtraItemsForm.cbosupplier.Text = ""
            XtraItemsForm.cbolocation.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadAvialStock()

        Try

            XtraStockAvialableForm.dgvStockAvial.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("SELECT pro_descrip AS Product, unit_cost AS [Unit Cost], sales_price AS [Sale Price], totpcs AS [Total Pieces], p_cost AS [Cost Value], Sales_Value AS [Sales Value], Profit_Margin AS [Profit Margin] FROM low_stock_v where location = '" & MainForm.txtlocation.Text & "'", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            XtraStockAvialableForm.dgvStockAvial.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadCount()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select count(pro_descrip) as list from ware_house_t where location = '" & MainForm.txtlocation.Text & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraStockAvialableForm.lblcount.Text = dr.Item("list")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub


    Public Sub LoadDeffectiveList()

        Try

            XtraDeffectiveListForm.dgvDeffitemslist.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("Getdeffectitemlist", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            XtraDeffectiveListForm.dgvDeffitemslist.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadGridView()

        Try

            dtInvoice.Columns.Add("ID".ToString, GetType(String))
            dtInvoice.Columns.Add("Items".ToString, GetType(String))
            dtInvoice.Columns.Add("Qty".ToString, GetType(String))
            dtInvoice.Columns.Add("Pcs".ToString, GetType(String))
            dtInvoice.Columns.Add("Unit Price".ToString, GetType(String))
            dtInvoice.Columns.Add("Amount".ToString, GetType(String))
            dtInvoice.Columns.Add("Qtyin".ToString, GetType(String))

            XtraPuchaseOrderForm.dgvPoOrder.ReadOnly = False
            XtraPuchaseOrderForm.dgvPoOrder.DataSource = dtInvoice
            XtraPuchaseOrderForm.dgvPoOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            XtraPuchaseOrderForm.dgvPoOrder.Columns(1).Width = 260
            XtraPuchaseOrderForm.dgvPoOrder.Columns(2).Width = 70
            XtraPuchaseOrderForm.dgvPoOrder.Columns(3).Width = 70
            XtraPuchaseOrderForm.dgvPoOrder.Columns(4).Width = 138
            XtraPuchaseOrderForm.dgvPoOrder.Columns(5).Width = 138

            XtraPuchaseOrderForm.dgvPoOrder.Columns(1).ReadOnly = True
            XtraPuchaseOrderForm.dgvPoOrder.Columns(4).ReadOnly = True
            XtraPuchaseOrderForm.dgvPoOrder.Columns(5).ReadOnly = True
            XtraPuchaseOrderForm.dgvPoOrder.Columns(6).Visible = False
            XtraPuchaseOrderForm.dgvPoOrder.Columns(0).Visible = False

            XtraPuchaseOrderForm.dgvPoOrder.ForeColor = Color.Black

            XtraPuchaseOrderForm.dgvPoOrder.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            XtraPuchaseOrderForm.dgvPoOrder.DefaultCellStyle.SelectionForeColor = Color.Black
            XtraPuchaseOrderForm.dgvPoOrder.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            XtraPuchaseOrderForm.dgvPoOrder.AllowUserToResizeColumns = False
            XtraPuchaseOrderForm.dgvPoOrder.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            XtraPuchaseOrderForm.dgvPoOrder.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetData()

        Try

            If XtraPuchaseOrderForm.txtproid.Text <> "" AndAlso XtraPuchaseOrderForm.cbodata.Text <> "" AndAlso XtraPuchaseOrderForm.mQyt.Text <> "" AndAlso XtraPuchaseOrderForm.txtpcs.Text <> "" AndAlso XtraPuchaseOrderForm.mRate.Text <> "" AndAlso XtraPuchaseOrderForm.mAmount.Text <> "" AndAlso XtraPuchaseOrderForm.txtqtyin.Text <> "" Then
                dtInvoice.Rows.Add(XtraPuchaseOrderForm.txtproid.Text, XtraPuchaseOrderForm.cbodata.Text, XtraPuchaseOrderForm.mQyt.Text, XtraPuchaseOrderForm.txtpcs.Text, XtraPuchaseOrderForm.mRate.Text, XtraPuchaseOrderForm.mAmount.Text, XtraPuchaseOrderForm.txtqtyin.Text)
            End If

            XtraPuchaseOrderForm.txtproid.Text = ""
            XtraPuchaseOrderForm.mRate.Text = ""
            XtraPuchaseOrderForm.mAmount.Text = ""
            XtraPuchaseOrderForm.cbodata.Text = ""
            XtraPuchaseOrderForm.txtqtyin.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To XtraPuchaseOrderForm.dgvPoOrder.Rows.Count - 1

                Dim icell5 As Double = XtraPuchaseOrderForm.dgvPoOrder.CurrentRow.Cells(6).Value
                Dim icell1 As Double = XtraPuchaseOrderForm.dgvPoOrder.CurrentRow.Cells(2).Value
                Dim icell2 As Double = XtraPuchaseOrderForm.dgvPoOrder.CurrentRow.Cells(3).Value
                Dim icell3 As Double = XtraPuchaseOrderForm.dgvPoOrder.CurrentRow.Cells(4).Value

                Dim icellResultCost As Double = ((icell5 * icell1) + icell2) * icell3

                XtraPuchaseOrderForm.dgvPoOrder.CurrentRow.Cells(5).Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To XtraPuchaseOrderForm.dgvPoOrder.Rows.Count - 1
                totalSum += XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells("Amount").Value
            Next i


            XtraPuchaseOrderForm.txttotal.Text = totalSum.ToString("n2")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCombo()

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

            XtraPuchaseOrderForm.cbodata.Items.Clear()
            XtraPuchaseOrderForm.cbodata.Items.Add("")
            XtraPuchaseOrderForm.cbodata.Items.AddRange(names.ToArray)

            DeffectiveItemsForm.cboitems.Properties.Items.Clear()
            DeffectiveItemsForm.cboitems.Properties.Items.Add("")
            DeffectiveItemsForm.cboitems.Properties.Items.AddRange(names.ToArray)

            AdjustItems.cbosearch.Items.Clear()
            AdjustItems.cbosearch.Items.Add("")
            AdjustItems.cbosearch.Items.AddRange(names.ToArray)

            AjustStoreItems.cbosearch.Items.Clear()
            AjustStoreItems.cbosearch.Items.Add("")
            AjustStoreItems.cbosearch.Items.AddRange(names.ToArray)

            Receive_Random_Order.cbosearch.Items.Clear()
            Receive_Random_Order.cbosearch.Items.Add("")
            Receive_Random_Order.cbosearch.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataBox()

        Try


            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select pro_id,unit_cost,qtyinbox from ware_house_t Where pro_descrip Like '%" & convertQuotes(XtraPuchaseOrderForm.cbodata.Text) & "%' GROUP BY pro_id,unit_cost,qtyinbox")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            XtraPuchaseOrderForm.txtproid.Text = sdr.Item("pro_id")
                            XtraPuchaseOrderForm.mRate.Text = sdr.Item("unit_cost")
                            XtraPuchaseOrderForm.mAmount.Text = sdr.Item("unit_cost")
                            XtraPuchaseOrderForm.txtqtyin.Text = sdr.Item("qtyinbox")

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillCurStock()

        Try


            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select totpcs from low_stock_v Where pro_descrip Like '%" & convertQuotes(AddtoStoreShelfForm.cboitems.Text) & "%'")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            AddtoStoreShelfForm.txtcurstock.Text = sdr.Item("totpcs")

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

        Catch oEX As Exception

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
            cmd.CommandText = "select MAX(po_num)from purchase_order_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                XtraPuchaseOrderForm.txtpono.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                XtraPuchaseOrderForm.txtpono.Text = number
            End If
            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearData()

        Try

            XtraPuchaseOrderForm.cbosup.Text = ""
            XtraPuchaseOrderForm.txtpono.Text = ""
            XtraPuchaseOrderForm.txtAddress.Text = ""
            XtraPuchaseOrderForm.txtmemo.Text = ""
            XtraPuchaseOrderForm.txttotal.Text = "0.00"
            dtInvoice.Clear()
            FillSaleNo()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertPO()

        Try

            XtraPuchaseOrderForm.dgvPoOrder.AllowUserToAddRows = False

            Dim dgvID, dgvItem, dgvqty, dgvpcs, dgvrate, dgvdisc, dgvqtyin As String

            For i As Integer = 0 To XtraPuchaseOrderForm.dgvPoOrder.Rows.Count - 1

                dgvID = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(0).Value
                dgvItem = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(1).Value
                dgvqty = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(2).Value
                dgvpcs = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(3).Value
                dgvrate = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(4).Value
                dgvdisc = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(5).Value
                dgvqtyin = XtraPuchaseOrderForm.dgvPoOrder.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertPO"}
                cmd.Parameters.Add("@po_date", SqlDbType.Date).Value = XtraPuchaseOrderForm.dtorderdate.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = XtraPuchaseOrderForm.txtpono.Text.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pcs", SqlDbType.Int).Value = dgvpcs.Trim()
                cmd.Parameters.Add("@unit_price", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvdisc.Trim()
                cmd.Parameters.Add("@tot_cost", SqlDbType.Float).Value = XtraPuchaseOrderForm.txttotal.Text.Trim()
                cmd.Parameters.Add("@po_note", SqlDbType.VarChar).Value = XtraPuchaseOrderForm.txtmemo.Text.Trim()
                cmd.Parameters.Add("@qtyin", SqlDbType.Int).Value = dgvqtyin.Trim()
                cmd.Parameters.Add("@vend", SqlDbType.VarChar).Value = XtraPuchaseOrderForm.cbosup.Text.Trim()
                cmd.Parameters.Add("@po_status", SqlDbType.VarChar).Value = XtraPuchaseOrderForm.cbostaus.Text.Trim()
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

        XtraPuchaseOrderForm.Close()
        XtraPuchaseOrderForm.Dispose()

        XtraStockAvialableForm.btnOrder.PerformClick()

    End Sub

    Public Sub GetMyID()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select ID from beneficiary where supplier='{0}'", XtraPuchaseOrderForm.cbosup.Text.Trim), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraPuchaseOrderForm.txtsupid.Text = dr.Item("ID")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetMyID2()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select ID from beneficiary where supplier='{0}'", XtraReceiveOderForm.cboRecFrom.Text.Trim), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraReceiveOderForm.txtsupid.Text = dr.Item("ID")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='{1}'", XtraPuchaseOrderForm.txtsupid.Text, XtraPuchaseOrderForm.cbosup.Text), .Connection = conString}

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

                XtraPuchaseOrderForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfo2()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='{1}'", XtraReceiveOderForm.txtsupid.Text, XtraReceiveOderForm.cboRecFrom.Text), .Connection = conString}

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

                XtraReceiveOderForm.txtaddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvValSum()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsInventValue As New DataSet
            Const sql As String = "InventValSummary"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsInventValue, "InventValSummary")
            cnn.Close()

            Dim report As New XtraInventValSum
            report.DataSource = dsInventValue
            report.DataMember = "valuationsummary"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = XtraInventoryValuationSummaryForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            XtraInventoryValuationSummaryForm.InvValSumViewer.DocumentSource = report
            XtraInventoryValuationSummaryForm.InvValSumViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getstockbylocation()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsWarehousestockbylocation As New DataSet
            Const sql As String = "GetStockbylocation"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsWarehousestockbylocation, "GetStockbylocation")
            cnn.Close()

            Dim report As New XtraStockbylocation
            report.DataSource = dsWarehousestockbylocation
            report.DataMember = "warelocation"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = XtraStockbylocationForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            XtraStockbylocationForm.StockLocationViewer.DocumentSource = report
            XtraStockbylocationForm.StockLocationViewer.Refresh()

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

                XtraInventoryValuationSummaryForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                XtraStockbylocationForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                XtraOpenPORepForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub insertdeffectitems()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertDeffectiveitems"}
            cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = DeffectiveItemsForm.txttype.Text
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = DeffectiveItemsForm.txtbarcode.Text
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = DeffectiveItemsForm.cboitems.Text
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = DeffectiveItemsForm.txtucost.Text
            cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = DeffectiveItemsForm.txtqty.Text
            cmd.Parameters.Add("@manufac_date", SqlDbType.Date).Value = DeffectiveItemsForm.txtedate.Text
            cmd.Parameters.Add("@expiry_date", SqlDbType.Date).Value = DeffectiveItemsForm.txtmdate.Text
            cmd.Parameters.Add("@supplier", SqlDbType.VarChar).Value = DeffectiveItemsForm.txtsup.Text
            cmd.Parameters.Add("@purchase_date", SqlDbType.Date).Value = DeffectiveItemsForm.txtpdate.Text
            cmd.Parameters.Add("@reasons", SqlDbType.VarChar).Value = DeffectiveItemsForm.txtreason.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DeffectiveItemsForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            ClearDefect()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearDefect()

        Try

            DeffectiveItemsForm.txttype.Text = ""
            DeffectiveItemsForm.txtbarcode.Text = ""
            DeffectiveItemsForm.txtucost.Text = "0.00"
            DeffectiveItemsForm.txtqty.Text = "0"
            DeffectiveItemsForm.txtpdate.Text = ""
            DeffectiveItemsForm.txtsup.Text = ""
            DeffectiveItemsForm.txtmdate.Text = ""
            DeffectiveItemsForm.txtedate.Text = ""
            DeffectiveItemsForm.txtreason.Text = ""
            DeffectiveItemsForm.cboitems.Text = ""
            DeffectiveItemsForm.cbolocation.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Public Sub showProductData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslist"}
            'insert product
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = DeffectiveItemsForm.cboitems.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                DeffectiveItemsForm.txttype.Text = dr.Item("cate")
                DeffectiveItemsForm.txtbarcode.Text = dr.Item("bar_code")
                DeffectiveItemsForm.txtucost.Text = dr.Item("unit_cost")
                DeffectiveItemsForm.txtmdate.Value = dr.Item("manufac_date")
                DeffectiveItemsForm.txtedate.Value = dr.Item("expiry_date")
                DeffectiveItemsForm.txtsup.Text = dr.Item("supplier")
                DeffectiveItemsForm.txtpdate.Value = dr.Item("purchase_date")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub showProductDatabar()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslistbarcode"}
            'insert product
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = DeffectiveItemsForm.cboitems.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                DeffectiveItemsForm.txttype.Text = dr.Item("cate")
                DeffectiveItemsForm.txtbarcode.Text = dr.Item("bar_code")
                DeffectiveItemsForm.txtucost.Text = dr.Item("unit_cost")
                DeffectiveItemsForm.txtmdate.Value = dr.Item("manufac_date")
                DeffectiveItemsForm.txtedate.Value = dr.Item("expiry_date")
                DeffectiveItemsForm.txtsup.Text = dr.Item("supplier")
                DeffectiveItemsForm.txtpdate.Value = dr.Item("purchase_date")
                DeffectiveItemsForm.cboitems.Text = dr.Item("pro_descrip")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub MyCheckitems()

        Try


            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select * from ware_house_t where pro_descrip Like '%" & convertQuotes(DeffectiveItemsForm.cboitems.Text) & "%'")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            showProductData()

                        Else

                            showProductDatabar()

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

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
            cmd.CommandText = "select MAX(stcode)from sup_inv_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                XtraReceiveOderForm.txtcode.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                XtraReceiveOderForm.txtcode.Text = number
            End If

            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub loadRecitems()

        XtraReceiveOderForm.dgvReceive.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = String.Format("SELECT id,pro_id,items AS Items, qty AS Qty, pcs AS Pcs, unit_price AS [Unit Price],SUM((qty * qtyin + pcs) * unit_price) AS Amount, qtyin FROM purchase_order_t WHERE vend = '{0}' AND po_status='Pending' GROUP BY id, pro_id, items, qty, pcs, unit_price, qtyin", XtraReceiveOderForm.cboRecFrom.Text)
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "purchase_order_t")
            sTable = sDs.Tables("purchase_order_t")
            connection.Close()
            XtraReceiveOderForm.dgvReceive.DataSource = sDs.Tables("purchase_order_t")

            Dim stu As New DataGridViewComboBoxColumn()
            stu.HeaderText = "Status"
            stu.Name = "stu"
            stu.Items.Add("Pending")
            stu.Items.Add("Received")
            stu.Items.Add("Canceled")
            stu.FlatStyle = FlatStyle.Standard
            stu.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

            XtraReceiveOderForm.dgvReceive.Columns.Insert(7, stu)

            XtraReceiveOderForm.dgvReceive.Columns(5).DefaultCellStyle.Format = "n2"
            XtraReceiveOderForm.dgvReceive.Columns(6).DefaultCellStyle.Format = "n2".ToString

            XtraReceiveOderForm.dgvReceive.Columns(2).Width = 250
            XtraReceiveOderForm.dgvReceive.Columns(3).Width = 50
            XtraReceiveOderForm.dgvReceive.Columns(4).Width = 50
            XtraReceiveOderForm.dgvReceive.Columns(5).Width = 100
            XtraReceiveOderForm.dgvReceive.Columns(6).Width = 140
            XtraReceiveOderForm.dgvReceive.Columns(7).Width = 140
            XtraReceiveOderForm.dgvReceive.Columns(0).Visible = False
            XtraReceiveOderForm.dgvReceive.Columns(1).Visible = False
            XtraReceiveOderForm.dgvReceive.Columns(8).Visible = False
            XtraReceiveOderForm.dgvReceive.Columns(2).ReadOnly = True
            XtraReceiveOderForm.dgvReceive.Columns(5).ReadOnly = True

        Catch ex As Exception

        End Try

    End Sub

    Public Sub RecCalgird()

        Try

            For i As Integer = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count

                Dim icell5 As Integer = XtraReceiveOderForm.dgvReceive.Rows(i).Cells("qtyin").Value
                Dim icell1 As Integer = XtraReceiveOderForm.dgvReceive.Rows(i).Cells("Qty").Value
                Dim icell2 As Integer = XtraReceiveOderForm.dgvReceive.Rows(i).Cells("Pcs").Value
                Dim icell3 As Decimal = XtraReceiveOderForm.dgvReceive.Rows(i).Cells("Unit Price").Value

                Dim icellResultCost As Decimal = ((icell1 * icell5) + icell2) * icell3

                XtraReceiveOderForm.dgvReceive.Rows(i).Cells("Amount").Value = icellResultCost.ToString("n2").ToString

            Next

        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For Each dgvRow As DataGridViewRow In XtraReceiveOderForm.dgvReceive.Rows
                If dgvRow.Cells(7).Value = "Received" Then
                    totalSum += (dgvRow.Cells("Amount").Value)
                End If
            Next


            XtraReceiveOderForm.txttot.Text = totalSum.ToString("n2")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetRecData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetPOData"}
            'insert product
            cmd.Parameters.Add("@vend", SqlDbType.VarChar).Value = XtraReceiveOderForm.cboRecFrom.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                XtraReceiveOderForm.txtponum.Text = dr.Item("po_num")
                XtraReceiveOderForm.dtpodate.Text = dr.Item("po_date")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertRecItems()

        Try

            XtraReceiveOderForm.dgvReceive.AllowUserToAddRows = False

            InsertSupInv()
            InsertRecinv()
            InserRecPayable()
            Insertexpbill()
            Insertdebitstat()
            UpdateWareQty()
            UpdatePurOrder()

            Dim dgvItem, dgvqty, dgvpcs, dgvrate, dgvdamt, dgvdsta, dgvqtyin As String

            For i As Integer = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count - 1

                dgvItem = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(2).Value
                dgvqty = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(3).Value
                dgvpcs = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(4).Value
                dgvrate = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(5).Value
                dgvdamt = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(6).Value
                dgvdsta = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(7).Value
                dgvqtyin = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertRecPur"}
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pcs", SqlDbType.Int).Value = dgvpcs.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@amt", SqlDbType.Float).Value = dgvdamt.Trim()
                cmd.Parameters.Add("@totamt", SqlDbType.Float).Value = XtraReceiveOderForm.txttot.Text.Trim()
                cmd.Parameters.Add("@qtyin", SqlDbType.Int).Value = dgvqtyin.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = XtraReceiveOderForm.txtponum.Text.Trim()
                cmd.Parameters.Add("@comment", SqlDbType.VarChar).Value = XtraReceiveOderForm.txtcomment.Text.Trim()
                cmd.Parameters.Add("@vend_id", SqlDbType.Int).Value = XtraReceiveOderForm.txtsupid.Text.Trim()
                cmd.Parameters.Add("@rec_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraReceiveOderForm.cbolocation.Text.Trim()
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = dgvdsta.Trim()
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

        DeletePurData()

        XtraReceiveOderForm.Close()
        XtraReceiveOderForm.Dispose()

        XtraStockAvialableForm.btnReceOrder.PerformClick()

    End Sub

    Public Sub GetOpenPO()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsOpenPO As New DataSet
            Const sql As String = "GetOpenPO"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsOpenPO, "GetOpenPO")
            cnn.Close()

            Dim report As New XtraOpenPOrep
            report.DataSource = dsOpenPO
            report.DataMember = "openpos"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = XtraOpenPORepForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            XtraOpenPORepForm.OpenPOViewer.DocumentSource = report
            XtraOpenPORepForm.OpenPOViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetRecInv()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraReceiveOderForm.txtinv.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetRecPayable()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='ap'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                XtraReceiveOderForm.txtpayable.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertRecinv()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = XtraReceiveOderForm.txtinv.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = XtraReceiveOderForm.txttot.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraReceiveOderForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InserRecPayable()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = XtraReceiveOderForm.txtpayable.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = XtraReceiveOderForm.txttot.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraReceiveOderForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            Cleartext()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Insertexpbill()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertAPBill"}
            cmd.Parameters.Add("@cust_id", SqlDbType.Int).Value = XtraReceiveOderForm.txtsupid.Text
            cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text
            cmd.Parameters.Add("@debit", SqlDbType.VarChar).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = XtraReceiveOderForm.txttot.Text
            cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
            cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraReceiveOderForm.cbolocation.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = XtraReceiveOderForm.cboRecFrom.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception

        End Try

    End Sub

    Public Sub InsertSupInv()

        Try

            Dim dgvAcc, dgvdesc As String

            For i As Integer = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count

                dgvAcc = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(1).Value
                dgvdesc = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertSupInv"}
                cmd.Parameters.Add("@stcode", SqlDbType.Int).Value = XtraReceiveOderForm.txtcode.Text
                cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text
                cmd.Parameters.Add("@duedate", SqlDbType.VarChar).Value = XtraReceiveOderForm.dtduedate.Text
                cmd.Parameters.Add("@terms", SqlDbType.VarChar).Value = "Due on receipt"
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvAcc.Trim
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = dgvAcc.Trim
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvdesc.Trim()
                cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = XtraReceiveOderForm.cboRecFrom.Text
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

        Catch oex As Exception

        End Try

    End Sub

    Public Sub Insertdebitstat()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertDebitStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = XtraReceiveOderForm.dtpodate.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = "Purchase of items from'" & XtraReceiveOderForm.cboRecFrom.Text & "'"
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = XtraReceiveOderForm.txttot.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = XtraReceiveOderForm.txtsupid.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = XtraReceiveOderForm.cbolocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception

        End Try

    End Sub

    Private Sub DeletePurData()

        Try

            Dim connetionString As String
            Dim connection As SqlConnection
            Dim adapter As New SqlDataAdapter
            Dim sql As String
            connetionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            connection = New SqlConnection(connetionString)
            sql = "DeletePurRec"
            Try
                connection.Open()
                adapter.DeleteCommand = connection.CreateCommand
                adapter.DeleteCommand.CommandText = sql
                adapter.DeleteCommand.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Catch oex As Exception

        End Try

    End Sub

    Public Sub GetPurchasebySup()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsItemsbySup As New DataSet
            Const sql As String = "GetPurchaseBySups"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsItemsbySup, "GetPurchaseBySups")
            cnn.Close()

            Dim report As New XtraPurchbySup
            report.DataSource = dsItemsbySup
            report.DataMember = "itemspurbysups"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = XtraPurchsebySupForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            XtraPurchsebySupForm.PurSupViewer.DocumentSource = report
            XtraPurchsebySupForm.PurSupViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CompPurInfo()

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

                XtraPurchsebySupForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadInvCount()

        StockManualCountForm.dgvCount.Columns.Clear()

        Try

            Dim objConn As New SqlConnection
            Dim objCmd As New SqlCommand
            Dim dtAdapter As New SqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT pro_id AS ID, pro_descrip AS Items, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) AS Cost, totpcs AS [Qty on Pc],sum(qty_ctn - qty_ctn) as [Total Count] FROM  low_stock_v WHERE location = '" & convertQuotes(StockManualCountForm.cbolocation.Text) & "' group by pro_id, pro_descrip, unit_cost, totpcs"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            objConn.Close()


            StockManualCountForm.dgvCount.DataSource = dt1

            Dim stu As New DataGridViewTextBoxColumn()
            stu.HeaderText = "Total Diff"
            stu.Name = "stu"

            Dim amt As New DataGridViewTextBoxColumn()
            amt.HeaderText = "Amount"
            amt.Name = "amt"

            StockManualCountForm.dgvCount.Columns.Insert(5, stu)
            StockManualCountForm.dgvCount.Columns.Insert(6, stu)

            StockManualCountForm.dgvCount.Columns(0).ReadOnly = True
            StockManualCountForm.dgvCount.Columns(1).ReadOnly = True
            StockManualCountForm.dgvCount.Columns(2).ReadOnly = True
            StockManualCountForm.dgvCount.Columns(3).ReadOnly = True
            StockManualCountForm.dgvCount.Columns(5).ReadOnly = True
            StockManualCountForm.dgvCount.Columns(6).Visible = False

            StockManualCountForm.dgvCount.Columns(2).DefaultCellStyle.Format = "n2"

            CountCalgird()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CountCalgird()

        Try

            For j As Double = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count

                Dim icell2 As Double = StockManualCountForm.dgvCount.Rows(j).Cells("Cost").Value
                Dim icell5 As Double = StockManualCountForm.dgvCount.Rows(j).Cells("Total Diff").Value

                Dim icellResultCostamt As Double = icell2 * icell5

                StockManualCountForm.dgvCount.Rows(j).Cells("Amount").Value = icellResultCostamt.ToString("n2")

            Next

        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double
            Dim totalqty As Double

            For Each dgvRow As DataGridViewRow In StockManualCountForm.dgvCount.Rows

                totalSum += (dgvRow.Cells("Amount").Value)

                totalqty += (dgvRow.Cells("Total Diff").Value)

            Next

            StockManualCountForm.txttotamt.Text = totalSum.ToString("n2")

            StockManualCountForm.txttotqty.Text = totalqty.ToString()


        Catch ex As Exception

        End Try

    End Sub

    Public Sub AdjustWareItems()

        AdjustItems.dgvAdjust.Columns.Clear()

        Try


            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = String.Format(CultureInfo.CurrentCulture, "Select pro_id As ID, pro_descrip As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price], CAST(CONVERT(varchar, CAST(mem_sales_price AS money), 1) AS varchar) As [Members Price], CAST(CONVERT(varchar, CAST(whole_sales_price AS money), 1) AS varchar) As [Whole Sale Price], totpcs As [Qty On Hand],sum(totpcs-totpcs) As Adjustment,expiry_date as [Expiry Date] FROM  low_stock_v WHERE location =  '" & convertQuotes(AdjustItems.cbolocation.Text) & "' group by pro_id, pro_descrip, unit_cost, totpcs,sales_price,mem_sales_price,whole_sales_price,expiry_date")
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "low_stock_v")
            sTable = sDs.Tables("low_stock_v")
            connection.Close()
            AdjustItems.dgvAdjust.DataSource = sDs.Tables("low_stock_v")

            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "Select"
            checkBoxColumn.Width = 30
            checkBoxColumn.Name = "checkBoxColumn"
            AdjustItems.dgvAdjust.Columns.Insert(9, checkBoxColumn)

            AdjustItems.dgvAdjust.Columns(0).ReadOnly = True
            AdjustItems.dgvAdjust.Columns(6).ReadOnly = True
            AdjustItems.dgvAdjust.Columns(8).DefaultCellStyle.Format = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ReceiveWareItems()

        Receive_Random_Order.dgvAdjust.Columns.Clear()

        Try

            Dim objConn As New SqlConnection
            Dim objCmd As New SqlCommand
            Dim dtAdapter As New SqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConSrc, strSQL1 As String

            strConSrc = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "Select pro_id As ID, pro_descrip As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price],  CAST(CONVERT(varchar, CAST(mem_sales_price AS money), 1) AS varchar) As [Members Price], CAST(CONVERT(varchar, CAST(whole_sales_price AS money), 1) AS varchar) As [Whole Sale Price], totpcs As [Qty On Hand],sum(totpcs-totpcs) As [Qty Received],cate,bar_code FROM  low_stock_v WHERE location = '" & convertQuotes(Receive_Random_Order.cbolocation.Text) & "' group by pro_id, pro_descrip, unit_cost, totpcs,sales_price,cate,bar_code,mem_sales_price,whole_sales_price"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)
            Receive_Random_Order.dgvAdjust.DataSource = dt1

            Receive_Random_Order.dgvAdjust.Columns(1).ReadOnly = True
            Receive_Random_Order.dgvAdjust.Columns(8).Visible = False
            Receive_Random_Order.dgvAdjust.Columns(9).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Public Sub SearchtWareItems()

        AdjustItems.dgvAdjust.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "Select pro_id As ID, pro_descrip As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price], CAST(CONVERT(varchar, CAST(mem_sales_price AS money), 1) AS varchar) As [Members Price], CAST(CONVERT(varchar, CAST(whole_sales_price AS money), 1) AS varchar) As [Whole Sale Price], totpcs As [Qty On Hand],sum(totpcs-totpcs) As Adjustment,expiry_date as [Expiry Date] FROM  low_stock_v WHERE pro_descrip like '%" & convertQuotes(AdjustItems.cbosearch.Text) & "%' AND location = '" & convertQuotes(AdjustItems.cbolocation.Text) & "' group by pro_id, pro_descrip, unit_cost, totpcs,sales_price,mem_sales_price,whole_sales_price,expiry_date"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "low_stock_v")
            sTable = sDs.Tables("low_stock_v")
            connection.Close()
            AdjustItems.dgvAdjust.DataSource = sDs.Tables("low_stock_v")

            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = "Select"
            checkBoxColumn.Width = 30
            checkBoxColumn.Name = "checkBoxColumn"
            AdjustItems.dgvAdjust.Columns.Insert(9, checkBoxColumn)

            AdjustItems.dgvAdjust.Columns(0).ReadOnly = True
            AdjustItems.dgvAdjust.Columns(6).ReadOnly = True
            AdjustItems.dgvAdjust.Columns(8).DefaultCellStyle.Format = "yyyy-MM-dd"

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillSearchDataBox()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from low_stock_v Where pro_descrip like '%" & convertQuotes(AdjustItems.cbosearch.Text) & "%' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                AdjustItems.txtproid.Text = dr.Item("pro_id")
                AdjustItems.txtproduct.Text = dr.Item("pro_descrip")
                AdjustItems.txtucost.Text = dr.Item("unit_cost")
                AdjustItems.txtsprice.Text = dr.Item("sales_price")
                AdjustItems.txtmprice.Text = dr.Item("mem_sales_price")
                AdjustItems.txtwprice.Text = dr.Item("whole_sales_price")
                AdjustItems.txtonhand.Text = dr.Item("avlpcs")
                AdjustItems.expdate.Text = dr.Item("expiry_date")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub SearchReceWareItems()

        Receive_Random_Order.dgvAdjust.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "Select pro_id As ID, pro_descrip As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price],  CAST(CONVERT(varchar, CAST(mem_sales_price AS money), 1) AS varchar) As [Members Price], CAST(CONVERT(varchar, CAST(whole_sales_price AS money), 1) AS varchar) As [Whole Sale Price], totpcs As [Qty On Hand],sum(totpcs-totpcs) As [Qty Received],cate,bar_code FROM  low_stock_v WHERE pro_descrip like '%" & convertQuotes(Receive_Random_Order.cbosearch.Text) & "%' AND location = '" & convertQuotes(Receive_Random_Order.cbolocation.Text) & "' group by pro_id, pro_descrip, unit_cost, totpcs,sales_price,cate,bar_code,mem_sales_price,whole_sales_price"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "low_stock_v")
            sTable = sDs.Tables("low_stock_v")
            connection.Close()
            Receive_Random_Order.dgvAdjust.DataSource = sDs.Tables("low_stock_v")

            Receive_Random_Order.dgvAdjust.Columns(1).ReadOnly = True
            Receive_Random_Order.dgvAdjust.Columns(8).Visible = False
            Receive_Random_Order.dgvAdjust.Columns(9).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertReceiveNew()

        Try

            Receive_Random_Order.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvcost, dgvprice, dgvmemprice, dgvwhoprice, dgvcate, dgvbar As String

            For i As Integer = 0 To Receive_Random_Order.dgvAdjust.Rows.Count - 1

                dgvID = Receive_Random_Order.dgvAdjust.Rows(i).Cells(1).Value
                dgvcost = Receive_Random_Order.dgvAdjust.Rows(i).Cells(2).Value
                dgvprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(3).Value
                dgvmemprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(4).Value
                dgvwhoprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(5).Value
                dgvqty = Receive_Random_Order.dgvAdjust.Rows(i).Cells(7).Value
                dgvcate = Receive_Random_Order.dgvAdjust.Rows(i).Cells(8).Value
                dgvbar = Receive_Random_Order.dgvAdjust.Rows(i).Cells(9).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertMoveToShelve"}
                cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = dgvcate.Trim()
                cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = dgvbar.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvID.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvcost.Trim()
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@new_date", SqlDbType.Date).Value = Receive_Random_Order.dtDate.Text.Trim()
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = "new"
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


        ReceiveWareItems()

        DeleteMoveZero()

    End Sub

    Public Sub InsertReceiveNewHist()

        Try

            Receive_Random_Order.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvonhand As String

            For i As Integer = 0 To Receive_Random_Order.dgvAdjust.Rows.Count - 1

                dgvID = Receive_Random_Order.dgvAdjust.Rows(i).Cells(1).Value
                dgvonhand = Receive_Random_Order.dgvAdjust.Rows(i).Cells(6).Value
                dgvqty = Receive_Random_Order.dgvAdjust.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into stock_history_t (hist_date,product,qtyonhand,qty,ent_time,sys_user,user_location) Values(@hist_date,@product,@qtyonhand,@qty,@ent_time,@sys_user,@user_location)"}
                cmd.Parameters.Add("@hist_date", SqlDbType.Date).Value = Receive_Random_Order.dtDate.Text
                cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = dgvID.Trim
                cmd.Parameters.Add("@qtyonhand", SqlDbType.Float).Value = dgvonhand.Trim
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvqty
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = Receive_Random_Order.lbltimer.Text
                cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = MainForm.lbluser.Text
                cmd.Parameters.Add("@user_location", SqlDbType.VarChar).Value = MainForm.lbllocation.Text
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


    Public Sub DeleteMoveZero()

        Dim connetionString As String
        Dim connection As SqlConnection
        Dim adapter As New SqlDataAdapter
        Dim sql As String
        connetionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
        connection = New SqlConnection(connetionString)
        sql = "delete from move_to_shelve_t where pieces = '0'"
        Try
            connection.Open()
            adapter.DeleteCommand = connection.CreateCommand
            adapter.DeleteCommand.CommandText = sql
            adapter.DeleteCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try

        DeleteMoveshelvetemp()

    End Sub

    Public Sub DeleteMoveshelvetemp()

        Dim connetionString As String
        Dim connection As SqlConnection
        Dim adapter As New SqlDataAdapter
        Dim sql As String
        connetionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
        connection = New SqlConnection(connetionString)
        sql = "delete from move_to_shelve_temp_t"
        Try
            connection.Open()
            adapter.DeleteCommand = connection.CreateCommand
            adapter.DeleteCommand.CommandText = sql
            adapter.DeleteCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try

        Addbulktostore()

    End Sub

    Public Sub DeleteWare()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromWarehouse"}
            cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = AdjustItems.txtid.Text
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

        AdjustWareItems()

    End Sub

    Public Sub GetCountlocation()

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

            StockManualCountForm.cbolocation.Properties.Items.Clear()
            StockManualCountForm.cbolocation.Properties.Items.Add("")
            StockManualCountForm.cbolocation.Properties.Items.AddRange(names.ToArray)

            AdjustItems.cbolocation.Properties.Items.Clear()
            AdjustItems.cbolocation.Properties.Items.Add("")
            AdjustItems.cbolocation.Properties.Items.AddRange(names.ToArray)

            AjustStoreItems.cbolocation.Properties.Items.Clear()
            AjustStoreItems.cbolocation.Properties.Items.Add("")
            AjustStoreItems.cbolocation.Properties.Items.AddRange(names.ToArray)

            Receive_Random_Order.cbolocation.Properties.Items.Clear()
            Receive_Random_Order.cbolocation.Properties.Items.Add("")
            Receive_Random_Order.cbolocation.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertManuCount()

        Try

            StockManualCountForm.dgvCount.AllowUserToAddRows = False

            InsertCountCogs()
            InserCountInv()
            UpdateWareQtyout()

            Dim dgvItems, dgvcost, dgvqty, dgvqtycnt As String

            For i As Integer = 0 To StockManualCountForm.dgvCount.Rows.Count - 1

                dgvItems = StockManualCountForm.dgvCount.Rows(i).Cells(1).Value
                dgvcost = StockManualCountForm.dgvCount.Rows(i).Cells(2).Value
                dgvqty = StockManualCountForm.dgvCount.Rows(i).Cells(3).Value
                dgvqtycnt = StockManualCountForm.dgvCount.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InserManuCounthis"}
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvItems.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvcost.Trim()
                cmd.Parameters.Add("@totonpc", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@totpcscnt", SqlDbType.Float).Value = dgvqtycnt.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = StockManualCountForm.cbolocation.Text.Trim()
                cmd.Parameters.Add("@count_date", SqlDbType.Date).Value = StockManualCountForm.dtDate.Text.Trim()
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

        StockManualCountForm.Close()
        StockManualCountForm.Dispose()

        MainForm.btnInvManuCount.PerformClick()

    End Sub


    Public Sub GetCntInv()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                StockManualCountForm.txtinv.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCntcogs()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='cogs'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                StockManualCountForm.txtcogs.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCountCogs()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = StockManualCountForm.dtDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = StockManualCountForm.txtcogs.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = StockManualCountForm.txttotamt.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = StockManualCountForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InserCountInv()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = StockManualCountForm.dtDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = StockManualCountForm.txtinv.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = StockManualCountForm.txttotamt.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = "00:00:00"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = StockManualCountForm.cbolocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

            Cleartext()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetStockleve()

        Try

            LowStockForm.dgvlowstock.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetReorderItems", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            LowStockForm.dgvlowstock.DataSource = SourceDataSet.Tables(0)


        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetWarehouseCntSheet()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsManualCountSheet As New DataSet
            Const sql As String = "GetManualCountSheet"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsManualCountSheet, "GetManualCountSheet")
            cnn.Close()

            Dim report As New XtraCountSheet
            report.DataSource = dsManualCountSheet
            report.DataMember = "countsheet"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = XtraWarehouseCountSheetForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            XtraWarehouseCountSheetForm.CountSheetViewer.DocumentSource = report
            XtraWarehouseCountSheetForm.CountSheetViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CompInfoCntSheet()

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

                XtraWarehouseCountSheetForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getshelflocation()

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

            AddtoStoreShelfForm.cbowarelocation.Properties.Items.Clear()
            AddtoStoreShelfForm.cbowarelocation.Properties.Items.Add("")
            AddtoStoreShelfForm.cbowarelocation.Properties.Items.AddRange(names.ToArray)

            AddtoStoreShelfForm.cbostorelocation.Properties.Items.Clear()
            AddtoStoreShelfForm.cbostorelocation.Properties.Items.Add("")
            AddtoStoreShelfForm.cbostorelocation.Properties.Items.AddRange(names.ToArray)

            AddtoShelve.cbosource.Properties.Items.Clear()
            AddtoShelve.cbosource.Properties.Items.Add("")
            AddtoShelve.cbosource.Properties.Items.AddRange(names.ToArray)

            AddtoShelve.cbodestination.Properties.Items.Clear()
            AddtoShelve.cbodestination.Properties.Items.Add("")
            AddtoShelve.cbodestination.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillStoreShelfCombo()

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

            AddtoStoreShelfForm.cboitems.Properties.Items.Clear()
            AddtoStoreShelfForm.cboitems.Properties.Items.Add("")
            AddtoStoreShelfForm.cboitems.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub fillautocompletetextbox()

        Try

            Using con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
                Dim cd As New SqlCommand("select pro_descrip from ware_house_t", con)
                con.Open()
                Dim reader As SqlDataReader = cd.ExecuteReader()
                Dim MyCollection As New AutoCompleteStringCollection()
                While reader.Read()
                    MyCollection.Add(reader.GetString(0))
                End While
                AddtoShelve.cbodata.AutoCompleteCustomSource = MyCollection
                con.Close()
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub shelfCheckitems()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select * from ware_house_t where pro_descrip Like '%" & convertQuotes(AddtoStoreShelfForm.cboitems.Text) & "%'")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            WaretoshelveData()

                        Else

                            WaretoshelveDatabar()

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Checkshelfitems()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select * from ware_house_t where pro_descrip Like '%" & convertQuotes(AddtoShelve.cbodata.Text) & "%'")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            Waretoshelve()
                        Else

                            Waretoshelvebar()

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetAvialqty()

        Try

            Dim conString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            Using con As SqlConnection = New SqlConnection(conString)
                Using cmd As SqlCommand = New SqlCommand("select totpcs from low_stock_v where pro_descrip Like '%" & convertQuotes(AddtoShelve.cbodata.Text) & "%'")
                    cmd.CommandType = CommandType.Text
                    cmd.Connection = con
                    con.Open()
                    Using sdr As SqlDataReader = cmd.ExecuteReader()
                        If sdr.HasRows Then

                            sdr.Read()

                            AddtoShelve.txtqty.Text = sdr.Item("totpcs")

                            sdr.Close()

                        End If
                    End Using
                    con.Close()
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WaretoshelveData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslist"}
            'insert product
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                AddtoStoreShelfForm.txtID.Text = dr.Item("pro_id")
                AddtoStoreShelfForm.txtitemtype.Text = dr.Item("cate")
                AddtoStoreShelfForm.txtbarcode.Text = dr.Item("bar_code")
                AddtoStoreShelfForm.txtsaleprice.Text = dr.Item("sales_price")
                AddtoStoreShelfForm.txtmemprice.Text = dr.Item("mem_sales_price")
                AddtoStoreShelfForm.txtucost.Text = dr.Item("unit_cost")
                AddtoStoreShelfForm.txtqtyin.Text = dr.Item("qtyinbox")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try


    End Sub

    Public Sub Waretoshelve()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslist"}
            'insert product
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = AddtoShelve.cbodata.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                AddtoShelve.txtid.Text = dr.Item("pro_id")
                AddtoShelve.txttype.Text = dr.Item("cate")
                AddtoShelve.txtbarcode.Text = dr.Item("bar_code")
                AddtoShelve.txtsaleprice.Text = dr.Item("sales_price")
                AddtoShelve.txtmemprice.Text = dr.Item("mem_sales_price")
                AddtoShelve.txtucost.Text = dr.Item("unit_cost")
                AddtoShelve.txtqtyinbox.Text = dr.Item("qtyinbox")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Waretoshelvebar()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslistbarcode"}
            'insert product
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = AddtoShelve.cbodata.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                AddtoShelve.txtid.Text = dr.Item("pro_id")
                AddtoShelve.txttype.Text = dr.Item("cate")
                AddtoShelve.txtbarcode.Text = dr.Item("bar_code")
                AddtoShelve.txtsaleprice.Text = dr.Item("sales_price")
                AddtoShelve.txtmemprice.Text = dr.Item("mem_sales_price")
                AddtoShelve.txtucost.Text = dr.Item("unit_cost")
                AddtoShelve.txtqtyinbox.Text = dr.Item("qtyinbox")
                AddtoShelve.cbodata.Text = dr.Item("pro_descrip")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub WaretoshelveDatabar()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Getitemslistbarcode"}
            'insert product
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                AddtoStoreShelfForm.txtID.Text = dr.Item("pro_id")
                AddtoStoreShelfForm.txtitemtype.Text = dr.Item("cate")
                AddtoStoreShelfForm.txtbarcode.Text = dr.Item("bar_code")
                AddtoStoreShelfForm.txtsaleprice.Text = dr.Item("sales_price")
                AddtoStoreShelfForm.txtmemprice.Text = dr.Item("mem_sales_price")
                AddtoStoreShelfForm.txtucost.Text = dr.Item("unit_cost")
                AddtoStoreShelfForm.txtqtyin.Text = dr.Item("qtyinbox")
                AddtoStoreShelfForm.cboitems.Text = dr.Item("pro_descrip")

            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Sub CheckmyShlev()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckShelve"}
            'insert product
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                insertmovement()
                udpateshelve()

            Else

                insertmovement()
                insertshelve()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub insertmovement()

        Dim t1 As Integer = AddtoStoreShelfForm.txtqty.Text
        Dim t2 As Integer = AddtoStoreShelfForm.txtqtyin.Text
        Dim t3 As Integer = AddtoStoreShelfForm.txtpcs.Text
        Dim t4 As Integer = (t2 * t1) + t3

        Try
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertitemmove"}
            cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Parameters.Add("@items_description", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Parameters.Add("@qty", SqlDbType.Float).Value = t4
            cmd.Parameters.Add("@itemfrom", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cbowarelocation.Text
            cmd.Parameters.Add("@itemto", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cbostorelocation.Text
            cmd.Parameters.Add("@move_date", SqlDbType.Date).Value = AddtoStoreShelfForm.dtdate.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub insertshelve()

        Try

            updateshstore()

            Dim t1 As Integer = AddtoStoreShelfForm.txtqty.Text
            Dim t2 As Integer = AddtoStoreShelfForm.txtqtyin.Text
            Dim t3 As Integer = AddtoStoreShelfForm.txtpcs.Text
            Dim t4 As Integer = (t2 * t1) + t3

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertShelve"}
            cmd.Parameters.Add("@wp_pro_id", SqlDbType.Int).Value = AddtoStoreShelfForm.txtID.Text
            cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = AddtoStoreShelfForm.txtitemtype.Text
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = AddtoStoreShelfForm.txtbarcode.Text
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cboitems.Text
            cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = AddtoStoreShelfForm.txtsaleprice.Text
            cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = AddtoStoreShelfForm.txtmemprice.Text
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = AddtoStoreShelfForm.txtucost.Text
            cmd.Parameters.Add("@pieces", SqlDbType.Int).Value = t4
            cmd.Parameters.Add("@re_point", SqlDbType.Int).Value = AddtoStoreShelfForm.txtorderpoint.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cbostorelocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

        'SyncShelve_t()

        ClearShelve()

    End Sub

    Public Sub ClearShelve()

        Try

            AddtoStoreShelfForm.txtorderpoint.Text = "0"
            AddtoStoreShelfForm.txtqty.Text = "0"
            AddtoStoreShelfForm.txtqtyin.Text = "0"
            AddtoStoreShelfForm.txtpcs.Text = "0"
            AddtoStoreShelfForm.txtsaleprice.Text = "0.00"
            AddtoStoreShelfForm.txtitemtype.Text = ""
            AddtoStoreShelfForm.txtbarcode.Text = ""
            AddtoStoreShelfForm.cbowarelocation.Text = ""
            AddtoStoreShelfForm.cbostorelocation.Text = ""
            AddtoStoreShelfForm.cboitems.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetstoreList()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsStoreInvList As New DataSet
            Const sql As String = "GetShelvelist"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsStoreInvList, "GetShelvelist")
            cnn.Close()

            Dim report As New XtraStoreListRep
            report.DataSource = dsStoreInvList
            report.DataMember = "storelist"
            ' Obtain a parameter, and set its value.
            report.pComp.Value = StoreStockListForm.txtcomp.Text
            ' Hide the Parameters UI from end-users.
            report.pComp.Visible = False
            report.CreateDocument()
            StoreStockListForm.StoreViewer.DocumentSource = report
            StoreStockListForm.StoreViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCuststoreInfo()

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

                StoreStockListForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + Environment.NewLine + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetStockMovement()

        Try

            ItemMovementListForm.dgvMovement.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetItemMovement", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            ItemMovementListForm.dgvMovement.DataSource = SourceDataSet.Tables(0)


        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetStoreReorderpoint()

        Try

            StoreLowStockAlert.dgvlowstore.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetStoreReorderItems", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            StoreLowStockAlert.dgvlowstore.DataSource = SourceDataSet.Tables(0)


        Catch ex As Exception

        End Try

    End Sub

    Public Sub AdjustStoreItems()

        AjustStoreItems.dgvAdjust.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "SELECT pro_id AS ID, pro_descrip AS Items,CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) AS [Sales Price], pieces AS [Qty on Hand],sum(pieces-pieces) as Adjustment FROM  shelve_t WHERE location = '" & convertQuotes(AjustStoreItems.cbolocation.Text) & "' group by pro_id, pro_descrip, pieces,sales_price"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "shelve_t")
            sTable = sDs.Tables("shelve_t")
            connection.Close()
            AjustStoreItems.dgvAdjust.DataSource = sDs.Tables("shelve_t")

            AjustStoreItems.dgvAdjust.Columns(1).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(2).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(0).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(3).ReadOnly = True


        Catch ex As Exception

        End Try

    End Sub


    Public Sub SearchAdjustStoreItems()

        AjustStoreItems.dgvAdjust.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "SELECT pro_id AS ID, pro_descrip AS Items,CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) AS [Sales Price], pieces AS [Qty on Hand],sum(pieces-pieces) as Adjustment FROM  shelve_t WHERE pro_descrip like '%" & convertQuotes(AjustStoreItems.cbosearch.Text) & "%' AND location = '" & convertQuotes(AjustStoreItems.cbolocation.Text) & "' group by pro_id, pro_descrip, pieces,sales_price"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "shelve_t")
            sTable = sDs.Tables("shelve_t")
            connection.Close()
            AjustStoreItems.dgvAdjust.DataSource = sDs.Tables("shelve_t")

            AjustStoreItems.dgvAdjust.Columns(1).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(2).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(0).ReadOnly = True
            AjustStoreItems.dgvAdjust.Columns(3).ReadOnly = True


        Catch ex As Exception

        End Try

    End Sub


    Public Sub DeleteStore()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromStore"}
            cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = AjustStoreItems.txtid.Text
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

        AdjustStoreItems()

    End Sub

    Public Sub CheckStoreStock()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT * FROM   shelve_t WHERE  (re_point = pieces) OR (re_point > pieces)"), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT  * FROM  low_stock_v WHERE  (re_point = totpcs) OR (re_point > totpcs)"), .Connection = conString}

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

    Public Sub CheckStockPush()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT * FROM  pust_items_t WHERE location = '" & convertQuotes(MainForm.txtlocation.Text) & "' AND push_status ='Pending'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MainForm.btnStkTrans.ForeColor = Color.Red
                MainForm.btnStkTrans.ImageOptions.Image = Tophigh_Inventory.My.Resources.bocontact_32x32
                MainForm.Timer1.Stop()
                MainForm.btnStkTrans.ImageOptions.Image = Tophigh_Inventory.My.Resources.newmail_32x32
                MainForm.Timer1.Start()
            Else

                MainForm.btnStkTrans.ForeColor = Color.Black
                MainForm.btnStkTrans.ImageOptions.Image = Tophigh_Inventory.My.Resources.newmail_32x32

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckStockExpiryDate()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select * from ware_house_t pt where DATEADD(month, -6, expiry_date) <= GETDATE()"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                MainForm.btnExpired.ForeColor = Color.Red
                MainForm.btnExpired.ImageOptions.Image = Tophigh_Inventory.My.Resources.warning_32x32
            Else

                MainForm.btnExpired.ForeColor = Color.Black
                MainForm.btnExpired.ImageOptions.Image = Tophigh_Inventory.My.Resources.apply_32x321

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadBatchGridView()

        Try

            dtShelBatch.Columns.Add("ID".ToString, GetType(String))
            dtShelBatch.Columns.Add("Product".ToString, GetType(String))
            dtShelBatch.Columns.Add("Sale Price".ToString, GetType(String))
            dtShelBatch.Columns.Add("Members Price".ToString, GetType(String))
            dtShelBatch.Columns.Add("Current Qty".ToString, GetType(String))
            dtShelBatch.Columns.Add("Pcs".ToString, GetType(String))
            dtShelBatch.Columns.Add("Order Point".ToString, GetType(String))
            dtShelBatch.Columns.Add("Barcode".ToString, GetType(String))
            dtShelBatch.Columns.Add("Type".ToString, GetType(String))
            dtShelBatch.Columns.Add("Unit".ToString, GetType(String))
            dtShelBatch.Columns.Add("Qtyin".ToString, GetType(String))
            dtShelBatch.Columns.Add("QtyOut".ToString, GetType(String))

            AddtoShelve.dgvData.ReadOnly = False
            AddtoShelve.dgvData.DataSource = dtShelBatch
            AddtoShelve.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            AddtoShelve.dgvData.Columns(1).Width = 318
            AddtoShelve.dgvData.Columns(2).Width = 100
            AddtoShelve.dgvData.Columns(3).Width = 100
            AddtoShelve.dgvData.Columns(4).Width = 100
            AddtoShelve.dgvData.Columns(5).Width = 100

            AddtoShelve.dgvData.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AddtoShelve.dgvData.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AddtoShelve.dgvData.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AddtoShelve.dgvData.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            AddtoShelve.dgvData.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            AddtoShelve.dgvData.Columns(0).Visible = False
            AddtoShelve.dgvData.Columns(7).Visible = False
            AddtoShelve.dgvData.Columns(8).Visible = False
            AddtoShelve.dgvData.Columns(9).Visible = False
            AddtoShelve.dgvData.Columns(10).Visible = False
            AddtoShelve.dgvData.Columns(11).Visible = False

            AddtoShelve.dgvData.ForeColor = Color.Black

            AddtoShelve.dgvData.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            AddtoShelve.dgvData.DefaultCellStyle.SelectionForeColor = Color.Black
            AddtoShelve.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            AddtoShelve.dgvData.AllowUserToResizeColumns = False
            AddtoShelve.dgvData.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            AddtoShelve.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetBatchData()

        Try

            If AddtoShelve.txtid.Text <> "" AndAlso AddtoShelve.cbodata.Text <> "" AndAlso AddtoShelve.txtsaleprice.Text <> "" AndAlso AddtoShelve.txtmemprice.Text <> "" AndAlso AddtoShelve.txtqty.Text <> "" AndAlso AddtoShelve.txtpcs.Text <> "" AndAlso AddtoShelve.txtreorder.Text <> "" AndAlso AddtoShelve.txtbarcode.Text <> "" AndAlso AddtoShelve.txttype.Text <> "" AndAlso AddtoShelve.txttotpcs.Text <> "" AndAlso AddtoShelve.txtqtyinbox.Text <> "" AndAlso AddtoShelve.txtpcs.Text <> "" Then
                dtShelBatch.Rows.Add(AddtoShelve.txtid.Text, AddtoShelve.cbodata.Text, AddtoShelve.txtsaleprice.Text, AddtoShelve.txtmemprice.Text, AddtoShelve.txtqty.Text, AddtoShelve.txtpcs.Text, AddtoShelve.txtreorder.Text, AddtoShelve.txtbarcode.Text, AddtoShelve.txttype.Text, AddtoShelve.txtucost.Text, AddtoShelve.txtqtyinbox.Text, AddtoShelve.txttotpcs.Text)
            End If

            AddtoShelve.txtid.Text = ""
            AddtoShelve.cbodata.Text = ""
            AddtoShelve.txtsaleprice.Text = ""
            AddtoShelve.txtbarcode.Text = ""
            AddtoShelve.txttype.Text = ""
            AddtoShelve.txtucost.Text = ""
            AddtoShelve.txtqtyinbox.Text = ""

            CalBatchGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalBatchGridData()

        Try

            For j As Integer = 0 To AddtoShelve.dgvData.Rows.Count - 1

                Dim icell10 As Integer = AddtoShelve.dgvData.Rows(j).Cells("Qtyin").Value
                Dim icell4 As Integer = AddtoShelve.dgvData.Rows(j).Cells("Qty by Ctn").Value
                Dim icell5 As Integer = AddtoShelve.dgvData.Rows(j).Cells("Pcs").Value

                Dim icellResultCost As Double = (icell4 * icell10) + icell5

                AddtoShelve.dgvData.Rows(j).Cells("QtyOut").Value = icellResultCost.ToString

            Next j


        Catch ex As Exception

        End Try

        Try


        Catch ex As Exception

        End Try

    End Sub

    Public Sub insertBatchshelve()

        Try

            AddtoShelve.dgvData.AllowUserToAddRows = False

            insertBatchmovement()

            Dim dgvid, dgvcat, dgvbarcod, dgvpro, dgvsalep, dgvmemp, dgvucost, dgvpieces, dgvpoint As String

            For i As Integer = 0 To AddtoShelve.dgvData.Rows.Count - 1
                dgvid = AddtoShelve.dgvData.Rows(i).Cells(0).Value
                dgvcat = AddtoShelve.dgvData.Rows(i).Cells(8).Value
                dgvbarcod = AddtoShelve.dgvData.Rows(i).Cells(7).Value
                dgvpro = AddtoShelve.dgvData.Rows(i).Cells(1).Value
                dgvsalep = AddtoShelve.dgvData.Rows(i).Cells(2).Value
                dgvmemp = AddtoShelve.dgvData.Rows(i).Cells(3).Value
                dgvucost = AddtoShelve.dgvData.Rows(i).Cells(9).Value
                dgvpieces = AddtoShelve.dgvData.Rows(i).Cells(5).Value
                dgvpoint = AddtoShelve.dgvData.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertShelve"}
                cmd.Parameters.Add("@wp_pro_id", SqlDbType.Int).Value = dgvid.Trim()
                cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = dgvcat.Trim()
                cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = dgvbarcod.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvsalep.Trim()
                cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = dgvmemp.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim()
                cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = dgvpieces.Trim()
                cmd.Parameters.Add("@re_point", SqlDbType.Float).Value = dgvpoint.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoShelve.cbodestination.Text
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

        updatesBatchhstore()

    End Sub

    Public Sub insertBatchmovement()

        Try

            insertmovement()

            AddtoShelve.dgvData.AllowUserToAddRows = False

            Dim dgvcat, dgvbarcod, dgvpro, dgvsalep, dgvucost, dgvpieces, dgvpoint As String

            For i As Integer = 0 To AddtoShelve.dgvData.Rows.Count

                dgvcat = AddtoShelve.dgvData.Rows(i).Cells(7).Value
                dgvbarcod = AddtoShelve.dgvData.Rows(i).Cells(6).Value
                dgvpro = AddtoShelve.dgvData.Rows(i).Cells(1).Value
                dgvsalep = AddtoShelve.dgvData.Rows(i).Cells(2).Value
                dgvucost = AddtoShelve.dgvData.Rows(i).Cells(8).Value
                dgvpieces = AddtoShelve.dgvData.Rows(i).Cells(10).Value
                dgvpoint = AddtoShelve.dgvData.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertitemmove"}
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = dgvbarcod.Trim
                cmd.Parameters.Add("@items_description", SqlDbType.VarChar).Value = dgvpro.Trim
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvpieces.Trim
                cmd.Parameters.Add("@itemfrom", SqlDbType.VarChar).Value = AddtoShelve.cbosource.Text
                cmd.Parameters.Add("@itemto", SqlDbType.VarChar).Value = AddtoShelve.cbodestination.Text
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

    Public Sub loadPushData()

        ReceivedPushForm.dgvRecTrans.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "SELECT pro_id,cate as Category,bar_code as Barcode,pro_descrip AS Product,sales_price AS [Sale Price], unit_cost AS [Unit Cost], pieces AS [Qty Transferred] FROM pust_items_t WHERE psuh_from = '" & convertQuotes(ReceivedPushForm.cbolocation.Text) & "' AND push_status='Pending' GROUP BY pro_id,cate,bar_code,pro_descrip,sales_price,unit_cost,pieces"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "pust_items_t")
            sTable = sDs.Tables("pust_items_t")
            connection.Close()
            ReceivedPushForm.dgvRecTrans.DataSource = sDs.Tables("pust_items_t")

            Dim qtyrec As New DataGridViewTextBoxColumn()
            qtyrec.HeaderText = "Qty Received"
            qtyrec.Name = "qtyrec"

            Dim stu As New DataGridViewComboBoxColumn()
            stu.HeaderText = "Status"
            stu.Name = "stu"
            stu.Items.Add("Pending")
            stu.Items.Add("Received")
            stu.Items.Add("Canceled")
            stu.FlatStyle = FlatStyle.Standard
            stu.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox

            ReceivedPushForm.dgvRecTrans.Columns.Insert(7, qtyrec)
            ReceivedPushForm.dgvRecTrans.Columns.Insert(8, stu)

            ReceivedPushForm.dgvRecTrans.Columns(0).Visible = False
            ReceivedPushForm.dgvRecTrans.Columns(1).Visible = False
            ReceivedPushForm.dgvRecTrans.Columns(2).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalPushgird()

        Try

            For i As Double = 0 To ReceivedPushForm.dgvRecTrans.Rows.Count - 1

                Dim icell3 As Double = ReceivedPushForm.dgvRecTrans.Rows(i).Cells("Qty Transferred").Value
                Dim icell4 As Double = ReceivedPushForm.dgvRecTrans.Rows(i).Cells("Qty Received").Value

                Dim icellResultCost As Double = icell3 - icell4

                ReceivedPushForm.dgvRecTrans.Rows(i).Cells("Total Diffenece").Value = icellResultCost

            Next

        Catch ex As Exception

        End Try

    End Sub


    Public Sub loadPushReport()

        StockTransferReportForm.dgvPushRep.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "GetStockPushRep"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "GetStockPushRep")
            sTable = sDs.Tables("GetStockPushRep")
            connection.Close()
            StockTransferReportForm.dgvPushRep.DataSource = sDs.Tables("GetStockPushRep")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadExpiredPro()

        ExpiringProListForm.dgvEmpList.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "GetExpiringProduct"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "GetExpiringProduct")
            sTable = sDs.Tables("GetExpiringProduct")
            connection.Close()
            ExpiringProListForm.dgvEmpList.DataSource = sDs.Tables("GetExpiringProduct")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetProductList()

        Try

            Dim cnn As SqlConnection
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim dsProductList As New DataSet
            Const sql As String = "StockListing"

            cnn = New SqlConnection(connectionString)
            cnn.Open()

            Dim dscmd As New SqlDataAdapter(sql, cnn)
            dscmd.Fill(dsProductList, "StockListing")
            cnn.Close()

            Dim report As New ProductListReport
            report.DataSource = dsProductList
            report.DataMember = "StockListing"
            ' Obtain a parameter, and set its value.

            ' Hide the Parameters UI from end-users.

            report.CreateDocument()
            ProductListingForm.PlistViewer.DocumentSource = report
            ProductListingForm.PlistViewer.Refresh()

        Catch ex As Exception

        End Try

    End Sub



    Public Sub ExportToPDF()

        'Creating iTextSharp Table from the DataTable data
        Dim pdfTable As New PdfPTable(StockTransferReportForm.dgvPushRep.ColumnCount)
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 100
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1

        'Adding Header row
        For Each column As DataGridViewColumn In StockTransferReportForm.dgvPushRep.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            pdfTable.AddCell(cell)
        Next

        'Adding DataRow
        For Each row As DataGridViewRow In StockTransferReportForm.dgvPushRep.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(cell.Value.ToString())
            Next
        Next

        'Exporting to PDF
        Dim folderPath As String = "C:\Stock_Trans_PDFs\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & "Stock_Trans_List.pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using

    End Sub

    Public Sub Addbulktostore()

        MoveToStoreForm.dgvbulk.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "SELECT pro_id,id, cate, bar_code, pro_descrip AS Products,CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) AS [Unit Cost],CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) AS [Sales Price],CAST(CONVERT(varchar, CAST(mem_sales_price AS money), 1) AS varchar) AS [Members Price], pieces AS [New Qty Added],sum(pieces-pieces) as [Qty to Move],sum(pieces-pieces) as [Re-Order Point],syncode FROM  move_to_shelve_v where pieces > '0' group by pro_id,id, cate, bar_code, pro_descrip,pieces,syncode,unit_cost,sales_price,mem_sales_price"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "move_to_shelve_v")
            sTable = sDs.Tables("move_to_shelve_v")
            connection.Close()
            MoveToStoreForm.dgvbulk.DataSource = sDs.Tables("move_to_shelve_v")

            MoveToStoreForm.dgvbulk.Columns(2).Visible = False
            MoveToStoreForm.dgvbulk.Columns(3).Visible = False
            MoveToStoreForm.dgvbulk.Columns(0).Visible = False
            MoveToStoreForm.dgvbulk.Columns(8).ReadOnly = True
            MoveToStoreForm.dgvbulk.Columns(11).Visible = False

        Catch ex As Exception

        End Try

    End Sub

    Public Sub insertmovebulkshelve()

        Try

            MoveToStoreForm.dgvbulk.AllowUserToAddRows = False

            Dim dgvid, dgvcate, dgvbar, dgvpro, dgvprice, dgvucost, dgvmemprice, dgvqty, dgvreorder As String

            For i As Integer = 0 To MoveToStoreForm.dgvbulk.Rows.Count - 1

                dgvid = MoveToStoreForm.dgvbulk.Rows(i).Cells(1).Value
                dgvcate = MoveToStoreForm.dgvbulk.Rows(i).Cells(2).Value
                dgvbar = MoveToStoreForm.dgvbulk.Rows(i).Cells(3).Value
                dgvpro = MoveToStoreForm.dgvbulk.Rows(i).Cells(4).Value
                dgvprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(6).Value
                dgvucost = MoveToStoreForm.dgvbulk.Rows(i).Cells(5).Value
                dgvmemprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(7).Value
                dgvqty = MoveToStoreForm.dgvbulk.Rows(i).Cells(9).Value
                dgvreorder = MoveToStoreForm.dgvbulk.Rows(i).Cells(10).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertShelve"}
                cmd.Parameters.Add("@wp_pro_id", SqlDbType.Int).Value = dgvid.Trim()
                cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = dgvcate.Trim()
                cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = dgvbar.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim()
                cmd.Parameters.Add("@pieces", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@re_point", SqlDbType.Int).Value = dgvreorder.Trim()
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MoveToStoreForm.cbostorelocation.Text
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        UpdateMoveQty()

    End Sub

    Public Sub DeleteMoveware()

        Dim connetionString As String
        Dim connection As SqlConnection
        Dim adapter As New SqlDataAdapter
        Dim sql As String
        connetionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
        connection = New SqlConnection(connetionString)
        sql = "delete from move_to_shelve_t where pieces = '0'"
        Try
            connection.Open()
            adapter.DeleteCommand = connection.CreateCommand
            adapter.DeleteCommand.CommandText = sql
            adapter.DeleteCommand.ExecuteNonQuery()

        Catch ex As Exception

        End Try


        MoveToStoreForm.Close()
        MoveToStoreForm.Dispose()

        MainForm.BarButtonItem3.PerformClick()

    End Sub

    Public Sub updatesBatchhstore()

        Try

            AddtoShelve.dgvData.AllowUserToAddRows = False

            Dim dgvid, dgvpcs As String

            For i As Integer = 0 To AddtoShelve.dgvData.Rows.Count

                dgvid = AddtoShelve.dgvData.Rows(i).Cells(0).Value
                dgvpcs = AddtoShelve.dgvData.Rows(i).Cells(5).Value


                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update  ware_house_t set qty_out = qty_out + @qty_out,pieces_out = pieces_out + @pieces_out,totpieces_out = totpieces_out + @totpieces_out where pro_id = @pro_id and [location] = @location"}
                cmd.Parameters.Add("@qty_out", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@pieces_out", SqlDbType.Float).Value = dgvpcs.Trim
                cmd.Parameters.Add("@totpieces_out", SqlDbType.Float).Value = dgvpcs.Trim
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvid.Trim
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoShelve.cbosource.Text
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

        'SyncShelve_t()

        AddtoShelve.Close()
        AddtoShelve.Dispose()

        MainForm.AddBulktoStore.PerformClick()

    End Sub

    Public Sub UpdateAdjustStorePrice()

        Try

            AdjustItems.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvcost, dgvprice, dgvmemprice As String

            For i As Integer = 0 To AdjustItems.dgvAdjust.Rows.Count

                dgvID = AdjustItems.dgvAdjust.Rows(i).Cells(0).Value
                dgvcost = AdjustItems.dgvAdjust.Rows(i).Cells(2).Value
                dgvprice = AdjustItems.dgvAdjust.Rows(i).Cells(3).Value
                dgvmemprice = AdjustItems.dgvAdjust.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update shelve_t set sales_price = @sales_price, unit_cost = @unit_cost, mem_sales_price = @mem_sales_price where wp_pro_id = @wp_pro_id"}
                cmd.Parameters.AddWithValue("@unit_cost", SqlDbType.Float).Value = dgvcost
                cmd.Parameters.AddWithValue("@sales_price", SqlDbType.Float).Value = dgvprice
                cmd.Parameters.AddWithValue("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice
                cmd.Parameters.AddWithValue("@wp_pro_id", SqlDbType.BigInt).Value = dgvID
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next

        Catch ex As Exception

        End Try

        AdjustWareItems()

    End Sub

    Public Sub UpdateAdjustStoreQty()

        Try

            AjustStoreItems.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty As String

            For i As Integer = 0 To AjustStoreItems.dgvAdjust.Rows.Count - 1

                dgvID = AjustStoreItems.dgvAdjust.Rows(i).Cells(0).Value
                dgvqty = AjustStoreItems.dgvAdjust.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateAdjustStore"}
                cmd.Parameters.Add("@pieces", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next i

        Catch ex As Exception

        End Try

        AdjustStoreItems()

    End Sub

    Public Sub UpdatePushData()

        Try

            ReceivedPushForm.dgvRecTrans.AllowUserToAddRows = False

            Dim dgvID, dgvqtc, dgvsta As String

            For i As Integer = 0 To ReceivedPushForm.dgvRecTrans.Rows.Count

                dgvID = ReceivedPushForm.dgvRecTrans.Rows(i).Cells(0).Value
                dgvqtc = ReceivedPushForm.dgvRecTrans.Rows(i).Cells(7).Value
                dgvsta = ReceivedPushForm.dgvRecTrans.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdatePushData"}
                cmd.Parameters.Add("@qty_rece", SqlDbType.Float).Value = dgvqtc.Trim()
                cmd.Parameters.Add("@push_status", SqlDbType.VarChar).Value = dgvsta.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.BigInt).Value = dgvID.Trim()
                cmd.Parameters.Add("@psuh_from", SqlDbType.VarChar).Value = ReceivedPushForm.cbolocation.Text
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

            Next i

        Catch ex As Exception

        End Try

        UpdateRecPushData()

    End Sub

    Public Sub UpdateRecPushData()

        Try

            ReceivedPushForm.dgvRecTrans.AllowUserToAddRows = False

            Dim dgvpro, dgvqtc As String

            For i As Integer = 0 To ReceivedPushForm.dgvRecTrans.Rows.Count

                dgvpro = ReceivedPushForm.dgvRecTrans.Rows(i).Cells(3).Value
                dgvqtc = ReceivedPushForm.dgvRecTrans.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelveRecPush"}
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvqtc.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
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

            Next i

        Catch ex As Exception

        End Try

        ReceivedPushForm.Close()
        ReceivedPushForm.Dispose()

    End Sub

    Public Sub UpdateWareQty()

        Try

            Dim dgvID, dgvqty, dgvpcs As String

            For i As Integer = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count - 1

                dgvID = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(1).Value
                dgvqty = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(3).Value
                dgvpcs = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Updatewarehouse"}
                cmd.Parameters.AddWithValue("@qty_ctn", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@pieces", SqlDbType.Float).Value = dgvpcs.Trim()
                cmd.Parameters.AddWithValue("@pro_id", SqlDbType.BigInt).Value = dgvID.Trim()
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

    Public Sub UpdatePurOrder()

        Try

            Dim dgvID, dgvdsta As String

            For i As Integer = 0 To XtraReceiveOderForm.dgvReceive.Rows.Count - 1

                dgvID = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(0).Value
                dgvdsta = XtraReceiveOderForm.dgvReceive.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdatePO"}
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = dgvID.Trim()
                cmd.Parameters.Add("@po_status", SqlDbType.VarChar).Value = dgvdsta.Trim()
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

    Public Sub UpdateWareQtyout()

        Try

            StockManualCountForm.dgvCount.AllowUserToAddRows = False

            Dim dgvID, dgvqty As String

            For i As Integer = 0 To StockManualCountForm.dgvCount.Rows.Count - 1

                dgvID = StockManualCountForm.dgvCount.Rows(i).Cells(0).Value
                dgvqty = StockManualCountForm.dgvCount.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateCountwarehouse"}
                cmd.Parameters.Add("@totpieces_out", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvID.Trim()
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

    Public Sub UpdateMoveQty()

        Try

            MoveToStoreForm.dgvbulk.AllowUserToAddRows = False

            Dim dgvID, dgvqty As String

            For i As Integer = 0 To MoveToStoreForm.dgvbulk.Rows.Count - 1

                dgvID = MoveToStoreForm.dgvbulk.Rows(i).Cells(0).Value
                dgvqty = MoveToStoreForm.dgvbulk.Rows(i).Cells(9).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateMoveShelve"}
                cmd.Parameters.AddWithValue("@pieces", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@pro_id", SqlDbType.BigInt).Value = dgvID.Trim()
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

        UpdateMovewareQtyReduce()

    End Sub

    Public Sub UpdateMovewareQtyReduce()

        Try

            MoveToStoreForm.dgvbulk.AllowUserToAddRows = False

            Dim dgvpro, dgvqty, dgvmemprice, dgvprice, dgvucost As String

            For i As Integer = 0 To MoveToStoreForm.dgvbulk.Rows.Count - 1

                dgvpro = MoveToStoreForm.dgvbulk.Rows(i).Cells(1).Value
                dgvprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(6).Value
                dgvucost = MoveToStoreForm.dgvbulk.Rows(i).Cells(5).Value
                dgvmemprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(7).Value
                dgvqty = MoveToStoreForm.dgvbulk.Rows(i).Cells(9).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateReduceWareQty"}
                cmd.Parameters.AddWithValue("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim()
                cmd.Parameters.AddWithValue("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.AddWithValue("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.AddWithValue("@adjust_qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@pro_id", SqlDbType.Int).Value = dgvpro.Trim()
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

        UpdateMoveShelveQty()

    End Sub

    Public Sub UpdateMoveShelveQty()

        Try

            MoveToStoreForm.dgvbulk.AllowUserToAddRows = False

            Dim dgvpro, dgvqty, dgvmemprice, dgvprice, dgvucost As String

            For i As Integer = 0 To MoveToStoreForm.dgvbulk.Rows.Count - 1

                dgvpro = MoveToStoreForm.dgvbulk.Rows(i).Cells(4).Value
                dgvprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(6).Value
                dgvucost = MoveToStoreForm.dgvbulk.Rows(i).Cells(5).Value
                dgvmemprice = MoveToStoreForm.dgvbulk.Rows(i).Cells(7).Value
                dgvqty = MoveToStoreForm.dgvbulk.Rows(i).Cells(9).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateMyShelve"}
                cmd.Parameters.AddWithValue("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim()
                cmd.Parameters.AddWithValue("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.AddWithValue("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.AddWithValue("@pieces", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
                cmd.Parameters.AddWithValue("@location", SqlDbType.VarChar).Value = MoveToStoreForm.cbostorelocation.Text.Trim()
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

        InsertMoveToShelv_temp()

    End Sub

    Public Sub udpateshelve()

        Try

            updateshstore()

            Dim t1 As Integer = AddtoStoreShelfForm.txtqty.Text
            Dim t2 As Integer = AddtoStoreShelfForm.txtqtyin.Text
            Dim t3 As Integer = AddtoStoreShelfForm.txtpcs.Text
            Dim t4 As Integer = (t2 * t1) + t3

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelve"}
            cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = t4
            cmd.Parameters.Add("@wp_pro_id", SqlDbType.Int).Value = AddtoStoreShelfForm.txtID.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cbostorelocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

        'SyncShelve_t()

        ClearShelve()

    End Sub


    Protected Sub updateshstore()

        Try

            Dim t1 As Integer = AddtoStoreShelfForm.txtqty.Text
            Dim t2 As Integer = AddtoStoreShelfForm.txtqtyin.Text
            Dim t3 As Integer = AddtoStoreShelfForm.txtpcs.Text
            Dim t4 As Integer = (t2 * t1) + t3

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShStore"}
            cmd.Parameters.Add("@qty_out", SqlDbType.Float).Value = AddtoStoreShelfForm.txtqty.Text
            cmd.Parameters.Add("@pieces_out", SqlDbType.Float).Value = AddtoStoreShelfForm.txtpcs.Text
            cmd.Parameters.Add("@totpieces_out", SqlDbType.Float).Value = t4
            cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = AddtoStoreShelfForm.txtID.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoStoreShelfForm.cbowarelocation.Text
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub updateBatchshelve()

        Try

            AddtoShelve.dgvData.AllowUserToAddRows = False

            insertBatchmovement()

            Dim dgvpro, dgvpieces As String

            For i As Integer = 0 To AddtoShelve.dgvData.Rows.Count - 1

                dgvpro = AddtoShelve.dgvData.Rows(i).Cells(0).Value
                dgvpieces = AddtoShelve.dgvData.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelve"}
                cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = dgvpieces.Trim
                cmd.Parameters.Add("@wp_pro_id", SqlDbType.BigInt).Value = dgvpro.Trim
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = AddtoShelve.cbodestination.Text
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next i

        Catch ex As Exception

        End Try

        updatesBatchhstore()

    End Sub

    Public Sub UpdateAdjustWareQty()

        Try

            AdjustItems.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvcost, dgvprice, dgvmemprice, dgvwhoprice, dgvdate As String

            For i As Integer = 0 To AdjustItems.dgvAdjust.Rows.Count

                dgvID = AdjustItems.dgvAdjust.Rows(i).Cells(0).Value
                dgvcost = AdjustItems.dgvAdjust.Rows(i).Cells(2).Value
                dgvprice = AdjustItems.dgvAdjust.Rows(i).Cells(3).Value
                dgvmemprice = AdjustItems.dgvAdjust.Rows(i).Cells(4).Value
                dgvwhoprice = AdjustItems.dgvAdjust.Rows(i).Cells(5).Value
                dgvqty = AdjustItems.dgvAdjust.Rows(i).Cells(7).Value
                dgvdate = AdjustItems.dgvAdjust.Rows(i).Cells(8).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update ware_house_t set  unit_cost = @unit_cost , sales_price = @sales_price, mem_sales_price = @mem_sales_price,whole_sales_price = @whole_sales_price,expiry_date = @expiry_date, adjust_qty = adjust_qty + @adjust_qty where pro_id = @pro_id"}
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvcost
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvprice
                cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice
                cmd.Parameters.Add("@whole_sales_price", SqlDbType.Float).Value = dgvwhoprice
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvqty
                cmd.Parameters.Add("@expiry_date", SqlDbType.Date).Value = dgvdate
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvID
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception

                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next i

        Catch ex As Exception

        End Try

        UpdateAdjustStorePrice()

        'SyncShelve_t()

    End Sub

    Public Sub UpdateAdjustWareQtyText()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update ware_house_t set pro_descrip = @pro_descrip, unit_cost = @unit_cost , sales_price = @sales_price, mem_sales_price = @mem_sales_price,whole_sales_price = @whole_sales_price,expiry_date = @expiry_date, adjust_qty = adjust_qty + @adjust_qty where pro_id = @pro_id"}
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = AdjustItems.txtproduct.Text
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = AdjustItems.txtucost.Text
            cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = AdjustItems.txtsprice.Text
            cmd.Parameters.Add("@mem_sales_price", SqlDbType.Float).Value = AdjustItems.txtmprice.Text
            cmd.Parameters.Add("@whole_sales_price", SqlDbType.Float).Value = AdjustItems.txtwprice.Text
            cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = AdjustItems.txtqtyadjust.Text
            cmd.Parameters.Add("@expiry_date", SqlDbType.Date).Value = AdjustItems.expdate.Text
            cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = AdjustItems.txtproid.Text
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

        AdjustItems.txtqtyadjust.Text = "0"
        SearchtWareItems()
        FillSearchDataBox()
        FillCombo()
    End Sub

    Public Sub UpdateAdjustWareID()

        Try

            AdjustItems.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvpro As String

            For i As Integer = 0 To AdjustItems.dgvAdjust.Rows.Count

                dgvID = AdjustItems.dgvAdjust.Rows(i).Cells(0).Value
                dgvpro = AdjustItems.dgvAdjust.Rows(i).Cells(1).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelveWareID"}
                cmd.Parameters.Add("@wp_pro_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim()
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdateAdjustReceWareQty()

        Try

            Receive_Random_Order.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvpro, dgvcost, dgvprice, dgvmemprice, dgvwhoprice As String

            For i As Integer = 0 To Receive_Random_Order.dgvAdjust.Rows.Count - 1

                dgvID = Receive_Random_Order.dgvAdjust.Rows(i).Cells(0).Value
                dgvpro = Receive_Random_Order.dgvAdjust.Rows(i).Cells(1).Value
                dgvcost = Receive_Random_Order.dgvAdjust.Rows(i).Cells(2).Value
                dgvprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(3).Value
                dgvmemprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(4).Value
                dgvwhoprice = Receive_Random_Order.dgvAdjust.Rows(i).Cells(5).Value
                dgvqty = Receive_Random_Order.dgvAdjust.Rows(i).Cells(7).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update ware_house_t set  unit_cost = @unit_cost , sales_price = @sales_price, mem_sales_price = @mem_sales_price,whole_sales_price = @whole_sales_price, adjust_qty = adjust_qty + @adjust_qty where pro_id = @pro_id"}
                cmd.Parameters.AddWithValue("@unit_cost", SqlDbType.Float).Value = dgvcost.Trim()
                cmd.Parameters.AddWithValue("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.AddWithValue("@mem_sales_price", SqlDbType.Float).Value = dgvmemprice.Trim()
                cmd.Parameters.AddWithValue("@whole_sales_price", SqlDbType.Float).Value = dgvwhoprice.Trim()
                cmd.Parameters.AddWithValue("@adjust_qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@pro_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Connection = cnn
                Try
                    cnn.Open()
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                Finally

                    cnn.Close()
                    cnn.Dispose()
                End Try

            Next

        Catch ex As Exception

        End Try


        InsertReceiveNew()

    End Sub

    Public Sub GetStockHistory()

        Try

            StockHistoryForm.dgvHistory.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetStockHistory", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            StockHistoryForm.dgvHistory.DataSource = SourceDataSet.Tables(0)

            ' Make the grid read-only.
            StockHistoryForm.GridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            StockHistoryForm.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            StockHistoryForm.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus


        Catch ex As Exception

        End Try

    End Sub

End Class

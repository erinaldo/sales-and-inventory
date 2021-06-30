Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class SyncInClass

    Dim MySyncOut As New SyncOutClass

    Public Sub SyncBankObal_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM   bank_open_bal_t"
            strSQL2 = "SELECT  * FROM   bank_open_bal_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("bank").ToString().Trim().ToLower() = r2("bank").ToString().Trim().ToLower() AndAlso r("account").ToString().Trim().ToLower() = r2("account").ToString().Trim().ToLower() AndAlso r("accnum").ToString().Trim().ToLower() = r2("accnum").ToString().Trim().ToLower() AndAlso r("openbal").ToString().Trim().ToLower() = r2("openbal").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into bank_open_bal_temp_t (bank, account, accnum, openbal, location, syncode) values(@bank, @account, @accnum, @openbal, @location, @syncode)"}
                cmd.Parameters.Add("@bank", MySqlDbType.VarChar).Value = dt3.Rows(j)("bank")
                cmd.Parameters.Add("@account", MySqlDbType.VarChar).Value = dt3.Rows(j)("account")
                cmd.Parameters.Add("@accnum", MySqlDbType.VarChar).Value = dt3.Rows(j)("accnum")
                cmd.Parameters.Add("@openbal", MySqlDbType.Float).Value = dt3.Rows(j)("openbal")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_bank_open_bal_temp_t()

    End Sub

    Public Sub Delete_bank_open_bal_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM bank_open_bal_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bank_open_bal_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncBank_t()

    End Sub

    Public Sub SyncBank_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  bank_t"
            strSQL2 = "SELECT  * FROM  bank_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("depdate").ToString().Trim().ToLower() = r2("depdate").ToString().Trim().ToLower() AndAlso r("accname").ToString().Trim().ToLower() = r2("accname").ToString().Trim().ToLower() AndAlso r("accnum").ToString().Trim().ToLower() = r2("accnum").ToString().Trim().ToLower() AndAlso r("details").ToString().Trim().ToLower() = r2("details").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("bank").ToString().Trim().ToLower() = r2("bank").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into bank_temp_t (depdate, accname, accnum, details, debit, credit, bank, syncode) values(@depdate, @accname, @accnum, @details, @debit, @credit, @bank, @syncode)"}
                cmd.Parameters.Add("@depdate", MySqlDbType.Date).Value = dt3.Rows(j)("depdate")
                cmd.Parameters.Add("@accname", MySqlDbType.VarChar).Value = dt3.Rows(j)("accname")
                cmd.Parameters.Add("@accnum", MySqlDbType.VarChar).Value = dt3.Rows(j)("accnum")
                cmd.Parameters.Add("@details", MySqlDbType.VarChar).Value = dt3.Rows(j)("details")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@bank", MySqlDbType.VarChar).Value = dt3.Rows(j)("bank")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_bank_temp_t()

    End Sub

    Public Sub Delete_bank_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM bank_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bank_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncBills_t()

    End Sub

    Public Sub SyncBills_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  bills_t"
            strSQL2 = "SELECT  * FROM  bills_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("bill_id").ToString().Trim().ToLower() = r2("bill_id").ToString().Trim().ToLower() AndAlso r("cust").ToString().Trim().ToLower() = r2("cust").ToString().Trim().ToLower() AndAlso r("ent_date").ToString().Trim().ToLower() = r2("ent_date").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("bill_status").ToString().Trim().ToLower() = r2("bill_status").ToString().Trim().ToLower() AndAlso r("timer").ToString().Trim().ToLower() = r2("timer").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("bal_due").ToString().Trim().ToLower() = r2("bal_due").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into bills_temp_t (cust, ent_date, debit, credit, bill_status, timer, location, bal_due, syncode) values(@cust, @ent_date, @debit, @credit, @bill_status, @timer, @location, @bal_due, @syncode)"}
                cmd.Parameters.Add("@cust", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust")
                cmd.Parameters.Add("@ent_date", MySqlDbType.Date).Value = dt3.Rows(j)("ent_date")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@bill_status", MySqlDbType.VarChar).Value = dt3.Rows(j)("bill_status")
                cmd.Parameters.Add("@timer", MySqlDbType.VarChar).Value = dt3.Rows(j)("timer")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@bal_due", MySqlDbType.Float).Value = dt3.Rows(j)("bal_due")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_bills_temp_t()

    End Sub

    Public Sub Delete_bills_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM bills_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bills_temp_t where bill_id = @bill_id"}
                cmd.Parameters.Add("@bill_id", MySqlDbType.Int32).Value = dt1.Rows(k)("bill_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCashSalesMems_t()

    End Sub

    Public Sub SyncCashSalesMems_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "Select * FROM cash_sales_mems_t"
            strSQL2 = "Select * FROM cash_sales_mems_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("sale_disc").ToString().Trim().ToLower() = r2("sale_disc").ToString().Trim().ToLower() AndAlso r("nettotal").ToString().Trim().ToLower() = r2("nettotal").ToString().Trim().ToLower() AndAlso r("amt_rece").ToString().Trim().ToLower() = r2("amt_rece").ToString().Trim().ToLower() AndAlso r("amt_change").ToString().Trim().ToLower() = r2("amt_change").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("card_check_num").ToString().Trim().ToLower() = r2("card_check_num").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into cash_sales_mems_temp_t (cash_num,cash_date,pay_meth,items,qty,rate,vat,amount,sale_disc,amt_rece,amt_change,ent_time,customer,`user`,sales_descript,card_check_num,`location`,syncode) values(@cash_num,@cash_date,@pay_meth,@items,@qty,@rate,@vat,@amount,@sale_disc,@amt_rece,@amt_change,@ent_time,@customer,@user,@sales_descript,@card_check_num,@location,@syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@sale_disc", MySqlDbType.VarChar).Value = dt3.Rows(j)("sale_disc")
                cmd.Parameters.Add("@nettotal", MySqlDbType.Float).Value = dt3.Rows(j)("nettotal")
                cmd.Parameters.Add("@amt_rece", MySqlDbType.Float).Value = dt3.Rows(j)("amt_rece")
                cmd.Parameters.Add("@amt_change", MySqlDbType.Float).Value = dt3.Rows(j)("amt_change")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@card_check_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("card_check_num")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_cash_sales_mems_temp_t()

    End Sub

    Public Sub Delete_cash_sales_mems_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM cash_sales_mems_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_mems_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCashSales_t()

    End Sub
    Public Sub SyncCashSales_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "Select * FROM cash_sales_t"
            strSQL2 = "Select * FROM cash_sales_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("sale_disc").ToString().Trim().ToLower() = r2("sale_disc").ToString().Trim().ToLower() AndAlso r("nettotal").ToString().Trim().ToLower() = r2("nettotal").ToString().Trim().ToLower() AndAlso r("amt_rece").ToString().Trim().ToLower() = r2("amt_rece").ToString().Trim().ToLower() AndAlso r("amt_change").ToString().Trim().ToLower() = r2("amt_change").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("card_check_num").ToString().Trim().ToLower() = r2("card_check_num").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into cash_sales_temp_t (cash_num, cash_date, pay_meth, items, qty, rate, vat, amount, sale_disc, nettotal, amt_rece, amt_change, ent_time, customer, `user`, sales_descript, card_check_num, location, syncode) values(@cash_num, @cash_date, @pay_meth, @items, @qty, @rate, @vat, @amount, @sale_disc, @nettotal, @amt_rece, @amt_change, @ent_time, @customer, @user, @sales_descript, @card_check_num, @location, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@sale_disc", MySqlDbType.VarChar).Value = dt3.Rows(j)("sale_disc")
                cmd.Parameters.Add("@nettotal", MySqlDbType.Float).Value = dt3.Rows(j)("nettotal")
                cmd.Parameters.Add("@amt_rece", MySqlDbType.Float).Value = dt3.Rows(j)("amt_rece")
                cmd.Parameters.Add("@amt_change", MySqlDbType.Float).Value = dt3.Rows(j)("amt_change")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@card_check_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("card_check_num")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_cash_sales_temp_t()

    End Sub

    Public Sub Delete_cash_sales_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "Select * FROM cash_sales_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCashSalesWarehouse_t()

    End Sub

    Public Sub SyncCashSalesWarehouse_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "Select * FROM cash_sales_warehouse_t"
            strSQL2 = "Select * FROM cash_sales_warehouse_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("sale_disc").ToString().Trim().ToLower() = r2("sale_disc").ToString().Trim().ToLower() AndAlso r("amt_rece").ToString().Trim().ToLower() = r2("amt_rece").ToString().Trim().ToLower() AndAlso r("amt_change").ToString().Trim().ToLower() = r2("amt_change").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("card_check_num").ToString().Trim().ToLower() = r2("card_check_num").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("tot_qty_gvn").ToString().Trim().ToLower() = r2("tot_qty_gvn").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into cash_sales_warehouse_temp_t (cash_num,cash_date,pay_meth,items,qty,rate,vat,amount,sale_disc,amt_rece,amt_change,ent_time,customer,`user`,sales_descript,card_check_num,`location`,tot_qty_gvn,syncode) values(@cash_num,@cash_date,@pay_meth,@items,@qty,@rate,@vat,@amount,@sale_disc,@amt_rece,@amt_change,@ent_time,@customer,@user,@sales_descript,@card_check_num,@location,@tot_qty_gvn,@syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@sale_disc", MySqlDbType.VarChar).Value = dt3.Rows(j)("sale_disc")
                cmd.Parameters.Add("@amt_rece", MySqlDbType.Float).Value = dt3.Rows(j)("amt_rece")
                cmd.Parameters.Add("@amt_change", MySqlDbType.Float).Value = dt3.Rows(j)("amt_change")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@card_check_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("card_check_num")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@tot_qty_gvn", MySqlDbType.Float).Value = dt3.Rows(j)("tot_qty_gvn")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_cash_sales_warehouse_temp_t()

    End Sub

    Public Sub Delete_cash_sales_warehouse_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "Select * FROM cash_sales_warehouse_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_warehouse_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCategory_t()

    End Sub
    Public Sub SyncCategory_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM category_t"
            strSQL2 = "SELECT * FROM category_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("categories").ToString().Trim().ToLower() = r2("categories").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into category_temp_t (categories,syncode) values(@categories,@syncode)"}
                cmd.Parameters.Add("@categories", MySqlDbType.VarChar).Value = dt3.Rows(j)("categories")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next


        Catch ex As Exception

        End Try

        Delete_category_temp_t()

    End Sub

    Public Sub Delete_category_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "Select * FROM category_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from category_temp_t where id = @id"}
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = dt1.Rows(k)("Id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncChartofAccount_t()

    End Sub

    Public Sub SyncChartofAccount_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM  chart_of_account_t"
            strSQL2 = "SELECT * FROM  chart_of_account_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("coa_id").ToString().Trim().ToLower() = r2("coa_id").ToString().Trim().ToLower() AndAlso r("coa_code").ToString().Trim().ToLower() = r2("coa_code").ToString().Trim().ToLower() AndAlso r("coa_name").ToString().Trim().ToLower() = r2("coa_name").ToString().Trim().ToLower() AndAlso r("coa_group").ToString().Trim().ToLower() = r2("coa_group").ToString().Trim().ToLower() AndAlso r("coa_sub_group").ToString().Trim().ToLower() = r2("coa_sub_group").ToString().Trim().ToLower() AndAlso r("coa_cate").ToString().Trim().ToLower() = r2("coa_cate").ToString().Trim().ToLower() AndAlso r("coa_cf").ToString().Trim().ToLower() = r2("coa_cf").ToString().Trim().ToLower() AndAlso r("coa_ocbfy").ToString().Trim().ToLower() = r2("coa_ocbfy").ToString().Trim().ToLower() AndAlso r("coa_cogm").ToString().Trim().ToLower() = r2("coa_cogm").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into chart_of_account_temp_t (coa_code, coa_name, coa_group, coa_sub_group, coa_cate, coa_cf, coa_ocbfy, coa_cogm, syncode) values(@coa_code, @coa_name, @coa_group, @coa_sub_group, @coa_cate, @coa_cf, @coa_ocbfy, @coa_cogm, @syncode)"}
                cmd.Parameters.Add("@coa_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_code")
                cmd.Parameters.Add("@coa_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_name")
                cmd.Parameters.Add("@coa_group", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_group")
                cmd.Parameters.Add("@coa_sub_group", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_sub_group")
                cmd.Parameters.Add("@coa_cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_cate")
                cmd.Parameters.Add("@coa_cf", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_cf")
                cmd.Parameters.Add("@coa_ocbfy", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_ocbfy")
                cmd.Parameters.Add("@coa_cogm", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_cogm")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_chart_of_account_temp_t()

    End Sub

    Public Sub Delete_chart_of_account_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT * FROM chart_of_account_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from chart_of_account_temp_t where coa_id = @coa_id"}
                cmd.Parameters.Add("@coa_id", MySqlDbType.Int32).Value = dt1.Rows(k)("coa_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCompany_t()

    End Sub

    Public Sub SyncCompany_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM   company_t"
            strSQL2 = "SELECT  * FROM   company_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("comp_id").ToString().Trim().ToLower() = r2("comp_id").ToString().Trim().ToLower() AndAlso r("com_name").ToString().Trim().ToLower() = r2("com_name").ToString().Trim().ToLower() AndAlso r("street").ToString().Trim().ToLower() = r2("street").ToString().Trim().ToLower() AndAlso r("city").ToString().Trim().ToLower() = r2("city").ToString().Trim().ToLower() AndAlso r("zip_code").ToString().Trim().ToLower() = r2("zip_code").ToString().Trim().ToLower() AndAlso r("country").ToString().Trim().ToLower() = r2("country").ToString().Trim().ToLower() AndAlso r("phone").ToString().Trim().ToLower() = r2("phone").ToString().Trim().ToLower() AndAlso r("email").ToString().Trim().ToLower() = r2("email").ToString().Trim().ToLower() AndAlso r("website").ToString().Trim().ToLower() = r2("website").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("comp_logo").ToString().Trim().ToLower() = r2("comp_logo").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into company_temp_t (com_name, street, city, zip_code, country, phone, email, website, location, comp_logo, syncode) values(@com_name, @street, @city, @zip_code, @country, @phone, @email, @website, @location, @comp_logo, @syncode)"}
                cmd.Parameters.Add("@com_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("com_name")
                cmd.Parameters.Add("@street", MySqlDbType.VarChar).Value = dt3.Rows(j)("street")
                cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = dt3.Rows(j)("city")
                cmd.Parameters.Add("@zip_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("zip_code")
                cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = dt3.Rows(j)("country")
                cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = dt3.Rows(j)("phone")
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dt3.Rows(j)("email")
                cmd.Parameters.Add("@website", MySqlDbType.VarChar).Value = dt3.Rows(j)("website")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@comp_logo", MySqlDbType.LongBlob).Value = dt3.Rows(j)("comp_logo")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_company_temp_t()

    End Sub

    Public Sub Delete_company_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM company_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from company_temp_t where comp_id = @comp_id"}
                cmd.Parameters.Add("@comp_id", MySqlDbType.Int32).Value = dt1.Rows(k)("comp_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncComp_logo_t()

    End Sub

    Public Sub SyncComp_logo_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM comp_logo_t"
            strSQL2 = "SELECT * FROM comp_logo_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("com_name").ToString().Trim().ToLower() = r2("com_name").ToString().Trim().ToLower() AndAlso r("comp_logo").ToString().Trim().ToLower() = r2("comp_logo").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into comp_logo_temp_t (com_name,comp_logo,syncode) values(@com_name,@comp_logo,@syncode)"}
                cmd.Parameters.Add("@com_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("com_name")
                cmd.Parameters.Add("@comp_logo", MySqlDbType.LongBlob).Value = dt3.Rows(j)("comp_logo")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next


        Catch ex As Exception

        End Try

        Delete_comp_logo_temp_t()

    End Sub

    Public Sub Delete_comp_logo_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "Select * FROM comp_logo_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from comp_logo_temp_t where id = @id"}
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = dt1.Rows(k)("Id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCreditMemo_t()

    End Sub

    Public Sub SyncCreditMemo_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   credit_memo_t"
            strSQL2 = "SELECT  *  FROM   credit_memo_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("ship_date").ToString().Trim().ToLower() = r2("ship_date").ToString().Trim().ToLower() AndAlso r("pay_terms").ToString().Trim().ToLower() = r2("pay_terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into credit_memo_temp_t (cash_num, po_num, cash_date, ship_date, pay_terms, items, qty, rate, vat, amount, ent_time, customer, user, sales_descript, location, syncode) values(@cash_num, @po_num, @cash_date, @ship_date, @pay_terms, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @location, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@ship_date", MySqlDbType.Date).Value = dt3.Rows(j)("ship_date")
                cmd.Parameters.Add("@pay_terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_credit_memo_temp_t()

    End Sub

    Public Sub Delete_credit_memo_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM credit_memo_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_memo_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCreditSalesMems_t()

    End Sub

    Public Sub SyncCreditSalesMems_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   credit_sales_mems_t"
            strSQL2 = "SELECT  *  FROM   credit_sales_mems_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("ship_date").ToString().Trim().ToLower() = r2("ship_date").ToString().Trim().ToLower() AndAlso r("pay_terms").ToString().Trim().ToLower() = r2("pay_terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("inwords").ToString().Trim().ToLower() = r2("inwords").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into credit_sales_mems_temp_t (cash_num, po_num, cash_date, ship_date, pay_terms, items, qty, rate, vat, amount, ent_time, customer, user, sales_descript, location, inwords, syncode) values(@cash_num, @po_num, @cash_date, @ship_date, @pay_terms, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @location, @inwords, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@ship_date", MySqlDbType.Date).Value = dt3.Rows(j)("ship_date")
                cmd.Parameters.Add("@pay_terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@inwords", MySqlDbType.VarChar).Value = dt3.Rows(j)("inwords")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_credit_sales_mems_temp_t()

    End Sub

    Public Sub Delete_credit_sales_mems_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM credit_sales_mems_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_mems_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCreditSales_t()

    End Sub

    Public Sub SyncCreditSales_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   credit_sales_t"
            strSQL2 = "SELECT  *  FROM   credit_sales_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("ship_date").ToString().Trim().ToLower() = r2("ship_date").ToString().Trim().ToLower() AndAlso r("pay_terms").ToString().Trim().ToLower() = r2("pay_terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("inwords").ToString().Trim().ToLower() = r2("inwords").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into credit_sales_temp_t (cash_num, po_num, cash_date, ship_date, pay_terms, items, qty, rate, vat, amount, ent_time, customer, user, sales_descript, location, inwords, syncode) values(@cash_num, @po_num, @cash_date, @ship_date, @pay_terms, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @location, @inwords, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@ship_date", MySqlDbType.Date).Value = dt3.Rows(j)("ship_date")
                cmd.Parameters.Add("@pay_terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@inwords", MySqlDbType.VarChar).Value = dt3.Rows(j)("inwords")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_credit_sales_temp_t()

    End Sub

    Public Sub Delete_credit_sales_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM credit_sales_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCreditSalesWarehouse_t()

    End Sub

    Public Sub SyncCreditSalesWarehouse_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   credit_sales_warehouse_t"
            strSQL2 = "SELECT  *  FROM   credit_sales_warehouse_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("ship_date").ToString().Trim().ToLower() = r2("ship_date").ToString().Trim().ToLower() AndAlso r("pay_terms").ToString().Trim().ToLower() = r2("pay_terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("inwords").ToString().Trim().ToLower() = r2("inwords").ToString().Trim().ToLower() AndAlso r("tot_qty_gvn").ToString().Trim().ToLower() = r2("tot_qty_gvn").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into credit_sales_warehouse_temp_t (cash_num, po_num, cash_date, ship_date, pay_terms, items, qty, rate, vat, amount, ent_time, customer, `user`, sales_descript, location, inwords, tot_qty_gvn, syncode) values(@cash_num, @po_num, @cash_date, @ship_date, @pay_terms, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @location, @inwords, @tot_qty_gvn, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@ship_date", MySqlDbType.Date).Value = dt3.Rows(j)("ship_date")
                cmd.Parameters.Add("@pay_terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@inwords", MySqlDbType.VarChar).Value = dt3.Rows(j)("inwords")
                cmd.Parameters.Add("@tot_qty_gvn", MySqlDbType.Float).Value = dt3.Rows(j)("tot_qty_gvn")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_credit_sales_warehouse_temp_t()

    End Sub

    Public Sub Delete_credit_sales_warehouse_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM credit_sales_warehouse_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_warehouse_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCreditStatement_t()

    End Sub

    Public Sub SyncCreditStatement_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  credit_statement_t"
            strSQL2 = "SELECT  * FROM  credit_statement_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("stid").ToString().Trim().ToLower() = r2("stid").ToString().Trim().ToLower() AndAlso r("st_date").ToString().Trim().ToLower() = r2("st_date").ToString().Trim().ToLower() AndAlso r("description").ToString().Trim().ToLower() = r2("description").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("cust_name").ToString().Trim().ToLower() = r2("cust_name").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into credit_statement_t (st_date,`description`,debit,credit,cust_name,`location`,syncode) values(@st_date,@description,@debit,@credit,@cust_name,@location,@syncode)"}
                cmd.Parameters.Add("@st_date", MySqlDbType.Date).Value = dt3.Rows(j)("st_date")
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = dt3.Rows(j)("description")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@cust_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_name")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_credit_statement_temp_t()

    End Sub

    Public Sub Delete_credit_statement_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM credit_statement_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_statement_temp_t where stid = @stid"}
                cmd.Parameters.Add("@stid", MySqlDbType.Int32).Value = dt1.Rows(k)("stid")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCustomersAddress_t()

    End Sub

    Public Sub SyncCustomersAddress_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  customers_address_t"
            strSQL2 = "SELECT  * FROM  customers_address_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("cust_code").ToString().Trim().ToLower() = r2("cust_code").ToString().Trim().ToLower() AndAlso r("office_add").ToString().Trim().ToLower() = r2("office_add").ToString().Trim().ToLower() AndAlso r("land_line").ToString().Trim().ToLower() = r2("land_line").ToString().Trim().ToLower() AndAlso r("mobile").ToString().Trim().ToLower() = r2("mobile").ToString().Trim().ToLower() AndAlso r("fax_num").ToString().Trim().ToLower() = r2("fax_num").ToString().Trim().ToLower() AndAlso r("email_add").ToString().Trim().ToLower() = r2("email_add").ToString().Trim().ToLower() AndAlso r("website").ToString().Trim().ToLower() = r2("website").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into customers_address_temp_t (cust_code, office_add, land_line, mobile, fax_num, email_add, website, syncode) values(@cust_code, @office_add, @land_line, @mobile, @fax_num, @email_add, @website, @syncode)"}
                cmd.Parameters.Add("@cust_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_code")
                cmd.Parameters.Add("@office_add", MySqlDbType.VarChar).Value = dt3.Rows(j)("office_add")
                cmd.Parameters.Add("@land_line", MySqlDbType.VarChar).Value = dt3.Rows(j)("land_line")
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = dt3.Rows(j)("mobile")
                cmd.Parameters.Add("@fax_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("fax_num")
                cmd.Parameters.Add("@email_add", MySqlDbType.VarChar).Value = dt3.Rows(j)("email_add")
                cmd.Parameters.Add("@website", MySqlDbType.VarChar).Value = dt3.Rows(j)("website")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_customers_address_temp_t()

    End Sub

    Public Sub Delete_customers_address_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM customers_address_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from customers_address_temp_t where cust_id = @cust_id"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cust_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncCustomers_t()

    End Sub

    Public Sub SyncCustomers_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  customers_t"
            strSQL2 = "SELECT  * FROM  customers_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("cust_code").ToString().Trim().ToLower() = r2("cust_code").ToString().Trim().ToLower() AndAlso r("fname").ToString().Trim().ToLower() = r2("fname").ToString().Trim().ToLower() AndAlso r("mid_name").ToString().Trim().ToLower() = r2("mid_name").ToString().Trim().ToLower() AndAlso r("lname").ToString().Trim().ToLower() = r2("lname").ToString().Trim().ToLower() AndAlso r("title").ToString().Trim().ToLower() = r2("title").ToString().Trim().ToLower() AndAlso r("supname").ToString().Trim().ToLower() = r2("supname").ToString().Trim().ToLower() AndAlso r("cust_pic").ToString().Trim().ToLower() = r2("cust_pic").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into customers_temp_t (cust_code, fname, mid_name, lname, title, supname, cust_pic, syncode) values(@cust_code, @fname, @mid_name, @lname, @title, @supname, @cust_pic, @syncode)"}
                cmd.Parameters.Add("@cust_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_code")
                cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = dt3.Rows(j)("fname")
                cmd.Parameters.Add("@mid_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("mid_name")
                cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = dt3.Rows(j)("lname")
                cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = dt3.Rows(j)("title")
                cmd.Parameters.Add("@supname", MySqlDbType.VarChar).Value = dt3.Rows(j)("supname")
                cmd.Parameters.Add("@cust_pic", MySqlDbType.LongBlob).Value = dt3.Rows(j)("cust_pic")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_customers_temp_t()

    End Sub

    Public Sub Delete_customers_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM customers_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from customers_temp_t where cust_id = @cust_id"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cust_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncDebitMemo_t()

    End Sub

    Public Sub SyncDebitMemo_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String


            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   debit_memo_t"
            strSQL2 = "SELECT  *  FROM   debit_memo_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("ship_date").ToString().Trim().ToLower() = r2("ship_date").ToString().Trim().ToLower() AndAlso r("pay_terms").ToString().Trim().ToLower() = r2("pay_terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into debit_memo_temp_t (cash_num, po_num, cash_date, ship_date, pay_terms, items, qty, rate, vat, amount, ent_time, customer, `user`, sales_descript, location, syncode) values(@cash_num, @po_num, @cash_date, @ship_date, @pay_terms, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @location, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@ship_date", MySqlDbType.Date).Value = dt3.Rows(j)("ship_date")
                cmd.Parameters.Add("@pay_terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_debit_memo_temp_t()

    End Sub

    Private Sub Delete_debit_memo_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM debit_memo_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from debit_memo_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncDebitStatement_t()

    End Sub

    Public Sub SyncDebitStatement_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM  debit_statement_t"
            strSQL2 = "SELECT * FROM  debit_statement_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("stid").ToString().Trim().ToLower() = r2("stid").ToString().Trim().ToLower() AndAlso r("st_date").ToString().Trim().ToLower() = r2("st_date").ToString().Trim().ToLower() AndAlso r("description").ToString().Trim().ToLower() = r2("description").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("cust_name").ToString().Trim().ToLower() = r2("cust_name").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into debit_statement_temp_t (st_date, description, debit, credit, cust_name, location, syncode) values(@st_date, @description, @debit, @credit, @cust_name, @location, @syncode)"}
                cmd.Parameters.Add("@st_date", MySqlDbType.Date).Value = dt3.Rows(j)("st_date")
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = dt3.Rows(j)("description")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@cust_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_name")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_debit_statement_temp_t()

    End Sub

    Private Sub Delete_debit_statement_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM debit_statement_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from debit_statement_temp_t where stid = @stid"}
                cmd.Parameters.Add("@stid", MySqlDbType.Int32).Value = dt1.Rows(k)("stid")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncDeffectiveItems_t()

    End Sub

    Public Sub SyncDeffectiveItems_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT   * FROM  deffective_items_t"
            strSQL2 = "SELECT   * FROM  deffective_items_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("cate").ToString().Trim().ToLower() = r2("cate").ToString().Trim().ToLower() AndAlso r("bar_code").ToString().Trim().ToLower() = r2("bar_code").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("pieces").ToString().Trim().ToLower() = r2("pieces").ToString().Trim().ToLower() AndAlso r("manufac_date").ToString().Trim().ToLower() = r2("manufac_date").ToString().Trim().ToLower() AndAlso r("expiry_date").ToString().Trim().ToLower() = r2("expiry_date").ToString().Trim().ToLower() AndAlso r("supplier").ToString().Trim().ToLower() = r2("supplier").ToString().Trim().ToLower() AndAlso r("purchase_date").ToString().Trim().ToLower() = r2("purchase_date").ToString().Trim().ToLower() AndAlso r("reasons").ToString().Trim().ToLower() = r2("reasons").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into deffective_items_temp_t (cate, bar_code, pro_descrip, unit_cost, pieces, manufac_date, expiry_date, supplier, purchase_date, reasons, location, syncode) values(@cate, @bar_code, @pro_descrip, @unit_cost, @pieces, @manufac_date, @expiry_date, @supplier, @purchase_date, @reasons, @location, @syncode)"}
                cmd.Parameters.Add("@cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cate")
                cmd.Parameters.Add("@bar_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("bar_code")
                cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@pieces", MySqlDbType.Float).Value = dt3.Rows(j)("pieces")
                cmd.Parameters.Add("@manufac_date", MySqlDbType.Date).Value = dt3.Rows(j)("manufac_date")
                cmd.Parameters.Add("@expiry_date", MySqlDbType.Date).Value = dt3.Rows(j)("expiry_date")
                cmd.Parameters.Add("@supplier", MySqlDbType.VarChar).Value = dt3.Rows(j)("supplier")
                cmd.Parameters.Add("@purchase_date", MySqlDbType.Date).Value = dt3.Rows(j)("purchase_date")
                cmd.Parameters.Add("@reasons", MySqlDbType.VarChar).Value = dt3.Rows(j)("reasons")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_deffective_items_temp_t()

    End Sub

    Private Sub Delete_deffective_items_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM deffective_items_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from deffective_items_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncEmpAddress_t()

    End Sub

    Public Sub SyncEmpAddress_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT   * FROM  emp_address_t"
            strSQL2 = "SELECT   * FROM  emp_address_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("emp_id").ToString().Trim().ToLower() = r2("emp_id").ToString().Trim().ToLower() AndAlso r("add_1").ToString().Trim().ToLower() = r2("add_1").ToString().Trim().ToLower() AndAlso r("city").ToString().Trim().ToLower() = r2("city").ToString().Trim().ToLower() AndAlso r("country").ToString().Trim().ToLower() = r2("country").ToString().Trim().ToLower() AndAlso r("mobile").ToString().Trim().ToLower() = r2("mobile").ToString().Trim().ToLower() AndAlso r("email").ToString().Trim().ToLower() = r2("email").ToString().Trim().ToLower() AndAlso r("next_of_kin").ToString().Trim().ToLower() = r2("next_of_kin").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into emp_address_temp_t (emp_id, add_1, city, country, mobile, email, next_of_kin, syncode) values(@emp_id, @add_1, @city, @country, @mobile, @email, @next_of_kin, @syncode)"}
                cmd.Parameters.Add("@emp_id", MySqlDbType.VarChar).Value = dt3.Rows(j)("emp_id")
                cmd.Parameters.Add("@add_1", MySqlDbType.VarChar).Value = dt3.Rows(j)("add_1")
                cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = dt3.Rows(j)("city")
                cmd.Parameters.Add("@country", MySqlDbType.VarChar).Value = dt3.Rows(j)("country")
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = dt3.Rows(j)("mobile")
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dt3.Rows(j)("email")
                cmd.Parameters.Add("@next_of_kin", MySqlDbType.VarChar).Value = dt3.Rows(j)("next_of_kin")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_emp_address_temp_t()

    End Sub

    Private Sub Delete_emp_address_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM emp_address_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_address_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncEmpInfo_t()

    End Sub

    Public Sub SyncEmpInfo_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  emp_info_t"
            strSQL2 = "SELECT  * FROM  emp_info_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("emp_id").ToString().Trim().ToLower() = r2("emp_id").ToString().Trim().ToLower() AndAlso r("fname").ToString().Trim().ToLower() = r2("fname").ToString().Trim().ToLower() AndAlso r("mname").ToString().Trim().ToLower() = r2("mname").ToString().Trim().ToLower() AndAlso r("lname").ToString().Trim().ToLower() = r2("lname").ToString().Trim().ToLower() AndAlso r("dob").ToString().Trim().ToLower() = r2("dob").ToString().Trim().ToLower() AndAlso r("gender").ToString().Trim().ToLower() = r2("gender").ToString().Trim().ToLower() AndAlso r("id_type").ToString().Trim().ToLower() = r2("id_type").ToString().Trim().ToLower() AndAlso r("id_no").ToString().Trim().ToLower() = r2("id_no").ToString().Trim().ToLower() AndAlso r("designation").ToString().Trim().ToLower() = r2("designation").ToString().Trim().ToLower() AndAlso r("comments").ToString().Trim().ToLower() = r2("comments").ToString().Trim().ToLower() AndAlso r("photo").ToString().Trim().ToLower() = r2("photo").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Integer = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into emp_info_temp_t (emp_id, fname, mname, lname, dob, gender, id_type, id_no, designation, comments, photo, syncode) values(@emp_id, @fname, @mname, @lname, @dob, @gender, @id_type, @id_no, @designation, @comments, @photo, @syncode)"}
                cmd.Parameters.Add("@emp_id", MySqlDbType.VarChar).Value = dt3.Rows(j)("emp_id")
                cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = dt3.Rows(j)("fname")
                cmd.Parameters.Add("@mname", MySqlDbType.VarChar).Value = dt3.Rows(j)("mname")
                cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = dt3.Rows(j)("lname")
                cmd.Parameters.Add("@dob", MySqlDbType.Date).Value = dt3.Rows(j)("dob")
                cmd.Parameters.Add("@gender", MySqlDbType.VarChar).Value = dt3.Rows(j)("gender")
                cmd.Parameters.Add("@id_type", MySqlDbType.VarChar).Value = dt3.Rows(j)("id_type")
                cmd.Parameters.Add("@id_no", MySqlDbType.VarChar).Value = dt3.Rows(j)("id_no")
                cmd.Parameters.Add("@designation", MySqlDbType.VarChar).Value = dt3.Rows(j)("designation")
                cmd.Parameters.Add("@comments", MySqlDbType.VarChar).Value = dt3.Rows(j)("comments")
                cmd.Parameters.Add("@photo", MySqlDbType.LongBlob).Value = dt3.Rows(j)("photo")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_emp_info_temp_t()

    End Sub

    Private Sub Delete_emp_info_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM emp_info_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_info_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncEmpSal_t()

    End Sub

    Public Sub SyncEmpSal_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  emp_sal_t"
            strSQL2 = "SELECT  * FROM  emp_sal_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("emp_id").ToString().Trim().ToLower() = r2("emp_id").ToString().Trim().ToLower() AndAlso r("bisac_sal").ToString().Trim().ToLower() = r2("bisac_sal").ToString().Trim().ToLower() AndAlso r("allowances").ToString().Trim().ToLower() = r2("allowances").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into emp_sal_temp_t (emp_id, bisac_sal, allowances, syncode) values(@emp_id, @bisac_sal, @allowances, @syncode)"}
                cmd.Parameters.Add("@emp_id", MySqlDbType.VarChar).Value = dt3.Rows(j)("emp_id")
                cmd.Parameters.Add("@bisac_sal", MySqlDbType.Float).Value = dt3.Rows(j)("bisac_sal")
                cmd.Parameters.Add("@allowances", MySqlDbType.Float).Value = dt3.Rows(j)("allowances")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_emp_sal_temp_t()

    End Sub

    Private Sub Delete_emp_sal_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM emp_sal_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_sal_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncExpenseBills_t()

    End Sub

    Public Sub SyncExpenseBills_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  expense_bills_t"
            strSQL2 = "SELECT  * FROM  expense_bills_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("bill_id").ToString().Trim().ToLower() = r2("bill_id").ToString().Trim().ToLower() AndAlso r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("ent_date").ToString().Trim().ToLower() = r2("ent_date").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("bill_status").ToString().Trim().ToLower() = r2("bill_status").ToString().Trim().ToLower() AndAlso r("timer").ToString().Trim().ToLower() = r2("timer").ToString().Trim().ToLower() AndAlso r("bal_due").ToString().Trim().ToLower() = r2("bal_due").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("cust_name").ToString().Trim().ToLower() = r2("cust_name").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "Insert Into expense_bills_temp_t (cust_id,ent_date,debit,credit,bill_status,timer,bal_due,cust_name,location,syncode) values(@cust_id,@ent_date,@debit,@credit,@bill_status,@timer,@bal_due,@cust_name,@location,@syncode)"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_id")
                cmd.Parameters.Add("@ent_date", MySqlDbType.Date).Value = dt3.Rows(j)("ent_date")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@bill_status", MySqlDbType.VarChar).Value = dt3.Rows(j)("bill_status")
                cmd.Parameters.Add("@timer", MySqlDbType.VarChar).Value = dt3.Rows(j)("timer")
                cmd.Parameters.Add("@bal_due", MySqlDbType.Float).Value = dt3.Rows(j)("bal_due")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@cust_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_name")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_expense_bills_temp_t()

    End Sub

    Private Sub Delete_expense_bills_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM expense_bills_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from expense_bills_temp_t where bill_id = @bill_id"}
                cmd.Parameters.Add("@bill_id", MySqlDbType.Int32).Value = dt1.Rows(k)("bill_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncItemMovement_t()

    End Sub

    Public Sub SyncItemMovement_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM  item_movement_t"
            strSQL2 = "SELECT * FROM  item_movement_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("barcode").ToString().Trim().ToLower() = r2("barcode").ToString().Trim().ToLower() AndAlso r("items_description").ToString().Trim().ToLower() = r2("items_description").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("itemfrom").ToString().Trim().ToLower() = r2("itemfrom").ToString().Trim().ToLower() AndAlso r("itemto").ToString().Trim().ToLower() = r2("itemto").ToString().Trim().ToLower() AndAlso r("move_date").ToString().Trim().ToLower() = r2("move_date").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into item_movement_temp_t (barcode, items_description, qty, itemfrom, itemto, move_date, syncode) values(@barcode, @items_description, @qty, @itemfrom, @itemto, @move_date, @syncode)"}
                cmd.Parameters.Add("@barcode", MySqlDbType.VarChar).Value = dt3.Rows(j)("barcode")
                cmd.Parameters.Add("@items_description", MySqlDbType.VarChar).Value = dt3.Rows(j)("items_description")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@itemfrom", MySqlDbType.VarChar).Value = dt3.Rows(j)("itemfrom")
                cmd.Parameters.Add("@itemto", MySqlDbType.VarChar).Value = dt3.Rows(j)("itemto")
                cmd.Parameters.Add("@move_date", MySqlDbType.Date).Value = dt3.Rows(j)("move_date")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_item_movement_temp_t()

    End Sub

    Private Sub Delete_item_movement_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM item_movement_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from item_movement_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncJournalVoucher_t()

    End Sub

    Public Sub SyncJournalVoucher_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  journal_voucher_t"
            strSQL2 = "SELECT  * FROM  journal_voucher_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("jv_id").ToString().Trim().ToLower() = r2("jv_id").ToString().Trim().ToLower() AndAlso r("cash_code").ToString().Trim().ToLower() = r2("cash_code").ToString().Trim().ToLower() AndAlso r("jv_date").ToString().Trim().ToLower() = r2("jv_date").ToString().Trim().ToLower() AndAlso r("coa_name").ToString().Trim().ToLower() = r2("coa_name").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into journal_voucher_temp_t (cash_code, jv_date, coa_name, debit, credit, ent_time, location, syncode) values(@cash_code, @jv_date, @coa_name, @debit, @credit, @ent_time, @location, @syncode)"}
                cmd.Parameters.Add("@cash_code", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_code")
                cmd.Parameters.Add("@jv_date", MySqlDbType.Date).Value = dt3.Rows(j)("jv_date")
                cmd.Parameters.Add("@coa_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_name")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_journal_voucher_temp_t()

    End Sub

    Private Sub Delete_journal_voucher_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM journal_voucher_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from journal_voucher_temp_t where jv_id = @jv_id"}
                cmd.Parameters.Add("@jv_id", MySqlDbType.Int32).Value = dt1.Rows(k)("jv_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncLocaArea_t()

    End Sub

    Public Sub SyncLocaArea_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  loca_area_t"
            strSQL2 = "SELECT  * FROM  loca_area_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("locations").ToString().Trim().ToLower() = r2("locations").ToString().Trim().ToLower() AndAlso r("areas").ToString().Trim().ToLower() = r2("areas").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into loca_area_temp_t (locations, areas, syncode) values(@locations, @areas, @syncode)"}
                cmd.Parameters.Add("@locations", MySqlDbType.VarChar).Value = dt3.Rows(j)("locations")
                cmd.Parameters.Add("@areas", MySqlDbType.VarChar).Value = dt3.Rows(j)("areas")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_loca_area_temp_t()

    End Sub

    Private Sub Delete_loca_area_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM loca_area_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from loca_area_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncOtherCust_t()

    End Sub

    Public Sub SyncOtherCust_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT * FROM  other_cust_t"
            strSQL2 = "SELECT * FROM  other_cust_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("fname").ToString().Trim().ToLower() = r2("fname").ToString().Trim().ToLower() AndAlso r("mid_name").ToString().Trim().ToLower() = r2("mid_name").ToString().Trim().ToLower() AndAlso r("lname").ToString().Trim().ToLower() = r2("lname").ToString().Trim().ToLower() AndAlso r("title").ToString().Trim().ToLower() = r2("title").ToString().Trim().ToLower() AndAlso r("mobile").ToString().Trim().ToLower() = r2("mobile").ToString().Trim().ToLower() AndAlso r("address").ToString().Trim().ToLower() = r2("address").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into other_cust_temp_t (fname, mid_name, lname, title, mobile, address, syncode) values(@fname, @mid_name, @lname, @title, @mobile, @address, @syncode)"}
                cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = dt3.Rows(j)("fname")
                cmd.Parameters.Add("@mid_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("mid_name")
                cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = dt3.Rows(j)("lname")
                cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = dt3.Rows(j)("title")
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = dt3.Rows(j)("mobile")
                cmd.Parameters.Add("@address", MySqlDbType.VarChar).Value = dt3.Rows(j)("address")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_other_cust_temp_t()

    End Sub

    Private Sub Delete_other_cust_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM other_cust_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from other_cust_temp_t where cust_id = @cust_id"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cust_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncPurchaseOrder_t()

    End Sub

    Public Sub SyncPurchaseOrder_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  purchase_order_t"
            strSQL2 = "SELECT  * FROM  purchase_order_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("po_date").ToString().Trim().ToLower() = r2("po_date").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("pro_id").ToString().Trim().ToLower() = r2("pro_id").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("pcs").ToString().Trim().ToLower() = r2("pcs").ToString().Trim().ToLower() AndAlso r("unit_price").ToString().Trim().ToLower() = r2("unit_price").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("tot_cost").ToString().Trim().ToLower() = r2("tot_cost").ToString().Trim().ToLower() AndAlso r("po_note").ToString().Trim().ToLower() = r2("po_note").ToString().Trim().ToLower() AndAlso r("qtyin").ToString().Trim().ToLower() = r2("qtyin").ToString().Trim().ToLower() AndAlso r("vend").ToString().Trim().ToLower() = r2("vend").ToString().Trim().ToLower() AndAlso r("po_status").ToString().Trim().ToLower() = r2("po_status").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into purchase_order_temp_t (po_date, po_num, pro_id, items, qty, pcs, unit_price, amount, tot_cost, po_note, qtyin, vend, po_status, syncode) values(@po_date, @po_num, @pro_id, @items, @qty, @pcs, @unit_price, @amount, @tot_cost, @po_note, @qtyin, @vend, @po_status, @syncode)"}
                cmd.Parameters.Add("@po_date", MySqlDbType.Date).Value = dt3.Rows(j)("po_date")
                cmd.Parameters.Add("@po_num", MySqlDbType.Int32).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = dt3.Rows(j)("pro_id")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@pcs", MySqlDbType.Float).Value = dt3.Rows(j)("pcs")
                cmd.Parameters.Add("@unit_price", MySqlDbType.Float).Value = dt3.Rows(j)("unit_price")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@tot_cost", MySqlDbType.Float).Value = dt3.Rows(j)("tot_cost")
                cmd.Parameters.Add("@po_note", MySqlDbType.VarChar).Value = dt3.Rows(j)("po_note")
                cmd.Parameters.Add("@qtyin", MySqlDbType.Float).Value = dt3.Rows(j)("qtyin")
                cmd.Parameters.Add("@vend", MySqlDbType.VarChar).Value = dt3.Rows(j)("vend")
                cmd.Parameters.Add("@po_status", MySqlDbType.VarChar).Value = dt3.Rows(j)("po_status")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_purchase_order_temp_t()

    End Sub

    Private Sub Delete_purchase_order_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM purchase_order_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_order_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncPurchaseReturn_t()

    End Sub

    Public Sub SyncPurchaseReturn_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM  purchase_return_t"
            strSQL2 = "SELECT  *  FROM  purchase_return_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into purchase_return_temp_t (cash_num, cash_date, pay_meth, items, qty, rate, amount, ent_time, customer, user, location, syncode) values(@cash_num, @cash_date, @pay_meth, @items, @qty, @rate, @amount, @ent_time, @customer, @user, @location, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_purchase_return_temp_t()

    End Sub

    Private Sub Delete_purchase_return_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM purchase_return_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_return_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncPurchase_t()

    End Sub

    Public Sub SyncPurchase_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  purchase_t"
            strSQL2 = "SELECT  * FROM  purchase_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("pcs").ToString().Trim().ToLower() = r2("pcs").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("amt").ToString().Trim().ToLower() = r2("amt").ToString().Trim().ToLower() AndAlso r("totamt").ToString().Trim().ToLower() = r2("totamt").ToString().Trim().ToLower() AndAlso r("qtyin").ToString().Trim().ToLower() = r2("qtyin").ToString().Trim().ToLower() AndAlso r("po_num").ToString().Trim().ToLower() = r2("po_num").ToString().Trim().ToLower() AndAlso r("comment").ToString().Trim().ToLower() = r2("comment").ToString().Trim().ToLower() AndAlso r("vend_id").ToString().Trim().ToLower() = r2("vend_id").ToString().Trim().ToLower() AndAlso r("rec_date").ToString().Trim().ToLower() = r2("rec_date").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("status").ToString().Trim().ToLower() = r2("status").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into purchase_temp_t (items, qty, pcs, unit_cost, amt, totamt, qtyin, po_num, comment, vend_id, rec_date, location, status, syncode) values(@items, @qty, @pcs, @unit_cost, @amt, @totamt, @qtyin, @po_num, @comment, @vend_id, @rec_date, @location, @status, @syncode)"}
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@pcs", MySqlDbType.Float).Value = dt3.Rows(j)("pcs")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@amt", MySqlDbType.Float).Value = dt3.Rows(j)("amt")
                cmd.Parameters.Add("@totamt", MySqlDbType.Float).Value = dt3.Rows(j)("totamt")
                cmd.Parameters.Add("@qtyin", MySqlDbType.Float).Value = dt3.Rows(j)("qtyin")
                cmd.Parameters.Add("@po_num", MySqlDbType.Float).Value = dt3.Rows(j)("po_num")
                cmd.Parameters.Add("@comment", MySqlDbType.VarChar).Value = dt3.Rows(j)("comment")
                cmd.Parameters.Add("@vend_id", MySqlDbType.Int32).Value = dt3.Rows(j)("vend_id")
                cmd.Parameters.Add("@rec_date", MySqlDbType.Date).Value = dt3.Rows(j)("rec_date")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = dt3.Rows(j)("status")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_purchase_temp_t()

    End Sub

    Private Sub Delete_purchase_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM purchase_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncPustItems_t()

    End Sub

    Public Sub SyncPustItems_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT   * FROM  pust_items_t"
            strSQL2 = "SELECT   * FROM  pust_items_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("pro_id").ToString().Trim().ToLower() = r2("pro_id").ToString().Trim().ToLower() AndAlso r("cate").ToString().Trim().ToLower() = r2("cate").ToString().Trim().ToLower() AndAlso r("bar_code").ToString().Trim().ToLower() = r2("bar_code").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("sales_price").ToString().Trim().ToLower() = r2("sales_price").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("pieces").ToString().Trim().ToLower() = r2("pieces").ToString().Trim().ToLower() AndAlso r("re_point").ToString().Trim().ToLower() = r2("re_point").ToString().Trim().ToLower() AndAlso r("psuh_from").ToString().Trim().ToLower() = r2("psuh_from").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("push_status").ToString().Trim().ToLower() = r2("push_status").ToString().Trim().ToLower() AndAlso r("qty_rece").ToString().Trim().ToLower() = r2("qty_rece").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into pust_items_temp_t (cate, bar_code, pro_descrip, sales_price, unit_cost, pieces, re_point, psuh_from, location, push_status, qty_rece, syncode) values(@cate, @bar_code, @pro_descrip, @sales_price, @unit_cost, @pieces, @re_point, @psuh_from, @location, @push_status, @qty_rece, @syncode)"}
                cmd.Parameters.Add("@cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cate")
                cmd.Parameters.Add("@bar_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("bar_code")
                cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
                cmd.Parameters.Add("@sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("sales_price")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@pieces", MySqlDbType.Float).Value = dt3.Rows(j)("pieces")
                cmd.Parameters.Add("@re_point", MySqlDbType.Float).Value = dt3.Rows(j)("re_point")
                cmd.Parameters.Add("@psuh_from", MySqlDbType.VarChar).Value = dt3.Rows(j)("psuh_from")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@push_status", MySqlDbType.VarChar).Value = dt3.Rows(j)("push_status")
                cmd.Parameters.Add("@qty_rece", MySqlDbType.Float).Value = dt3.Rows(j)("qty_rece")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_pust_items_temp_t()

    End Sub

    Private Sub Delete_pust_items_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM pust_items_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from pust_items_temp_t where pro_id = @pro_id"}
                cmd.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = dt1.Rows(k)("pro_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncReceipt_t()

    End Sub

    Public Sub SyncReceipt_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  receipt_t"
            strSQL2 = "SELECT  * FROM  receipt_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("num").ToString().Trim().ToLower() = r2("num").ToString().Trim().ToLower() AndAlso r("num_int").ToString().Trim().ToLower() = r2("num_int").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert into receipt_temp_t (num_int, syncode) values(@num_int, @syncode)"}
                cmd.Parameters.Add("@num_int", MySqlDbType.Int32).Value = dt3.Rows(j)("num_int")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_receipt_temp_t()

    End Sub

    Private Sub Delete_receipt_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM receipt_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from receipt_temp_t where num = @num"}
                cmd.Parameters.Add("@num", MySqlDbType.Int32).Value = dt1.Rows(k)("num")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncSalesReturn_t()

    End Sub

    Public Sub SyncSalesReturn_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM   sales_return_t"
            strSQL2 = "SELECT  * FROM   sales_return_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cash_id").ToString().Trim().ToLower() = r2("cash_id").ToString().Trim().ToLower() AndAlso r("cash_num").ToString().Trim().ToLower() = r2("cash_num").ToString().Trim().ToLower() AndAlso r("cash_date").ToString().Trim().ToLower() = r2("cash_date").ToString().Trim().ToLower() AndAlso r("pay_meth").ToString().Trim().ToLower() = r2("pay_meth").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("qty").ToString().Trim().ToLower() = r2("qty").ToString().Trim().ToLower() AndAlso r("rate").ToString().Trim().ToLower() = r2("rate").ToString().Trim().ToLower() AndAlso r("vat").ToString().Trim().ToLower() = r2("vat").ToString().Trim().ToLower() AndAlso r("amount").ToString().Trim().ToLower() = r2("amount").ToString().Trim().ToLower() AndAlso r("ent_time").ToString().Trim().ToLower() = r2("ent_time").ToString().Trim().ToLower() AndAlso r("customer").ToString().Trim().ToLower() = r2("customer").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("sales_descript").ToString().Trim().ToLower() = r2("sales_descript").ToString().Trim().ToLower() AndAlso r("card_check_num").ToString().Trim().ToLower() = r2("card_check_num").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into sales_return_temp_t (cash_num, cash_date, pay_meth, items, qty, rate, vat, amount, ent_time, customer, `user`, sales_descript, card_check_num, location, syncode) values(@cash_num, @cash_date, @pay_meth, @items, @qty, @rate, @vat, @amount, @ent_time, @customer, @user, @sales_descript, @card_check_num, @location, @syncode)"}
                cmd.Parameters.Add("@cash_num", MySqlDbType.Int32).Value = dt3.Rows(j)("cash_num")
                cmd.Parameters.Add("@cash_date", MySqlDbType.Date).Value = dt3.Rows(j)("cash_date")
                cmd.Parameters.Add("@pay_meth", MySqlDbType.VarChar).Value = dt3.Rows(j)("pay_meth")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@qty", MySqlDbType.Float).Value = dt3.Rows(j)("qty")
                cmd.Parameters.Add("@rate", MySqlDbType.Float).Value = dt3.Rows(j)("rate")
                cmd.Parameters.Add("@vat", MySqlDbType.Float).Value = dt3.Rows(j)("vat")
                cmd.Parameters.Add("@amount", MySqlDbType.Float).Value = dt3.Rows(j)("amount")
                cmd.Parameters.Add("@ent_time", MySqlDbType.VarChar).Value = dt3.Rows(j)("ent_time")
                cmd.Parameters.Add("@customer", MySqlDbType.VarChar).Value = dt3.Rows(j)("customer")
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@sales_descript", MySqlDbType.VarChar).Value = dt3.Rows(j)("sales_descript")
                cmd.Parameters.Add("@card_check_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("card_check_num")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_sales_return_temp_t()

    End Sub

    Private Sub Delete_sales_return_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM sales_return_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from sales_return_temp_t where cash_id = @cash_id"}
                cmd.Parameters.Add("@cash_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cash_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncShelve_t()

    End Sub

    Public Sub SyncShelve_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   shelve_t"
            strSQL2 = "SELECT  *  FROM   shelve_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("pro_id").ToString().Trim().ToLower() = r2("pro_id").ToString().Trim().ToLower() AndAlso r("cate").ToString().Trim().ToLower() = r2("cate").ToString().Trim().ToLower() AndAlso r("bar_code").ToString().Trim().ToLower() = r2("bar_code").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("sales_price").ToString().Trim().ToLower() = r2("sales_price").ToString().Trim().ToLower() AndAlso r("mem_sales_price").ToString().Trim().ToLower() = r2("mem_sales_price").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("pieces").ToString().Trim().ToLower() = r2("pieces").ToString().Trim().ToLower() AndAlso r("re_point").ToString().Trim().ToLower() = r2("re_point").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into shelve_temp_t (cate, bar_code, pro_descrip, sales_price, mem_sales_price, unit_cost, pieces, re_point, location, syncode) values(@cate, @bar_code, @pro_descrip, @sales_price, @mem_sales_price, @unit_cost, @pieces, @re_point, @location, @syncode)"}
                cmd.Parameters.Add("@cate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cate")
                cmd.Parameters.Add("@bar_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("bar_code")
                cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
                cmd.Parameters.Add("@sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("sales_price")
                cmd.Parameters.Add("@mem_sales_price", MySqlDbType.Float).Value = dt3.Rows(j)("mem_sales_price")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@pieces", MySqlDbType.Float).Value = dt3.Rows(j)("pieces")
                cmd.Parameters.Add("@re_point", MySqlDbType.VarChar).Value = dt3.Rows(j)("re_point")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_shelve_temp_t()

    End Sub

    Private Sub Delete_shelve_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM shelve_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from shelve_temp_t where pro_id = @pro_id"}
                cmd.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = dt1.Rows(k)("pro_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncSupInv_t()

    End Sub

    Public Sub SyncSupInv_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  sup_inv_t"
            strSQL2 = "SELECT  * FROM  sup_inv_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("stcode").ToString().Trim().ToLower() = r2("stcode").ToString().Trim().ToLower() AndAlso r("st_date").ToString().Trim().ToLower() = r2("st_date").ToString().Trim().ToLower() AndAlso r("duedate").ToString().Trim().ToLower() = r2("duedate").ToString().Trim().ToLower() AndAlso r("terms").ToString().Trim().ToLower() = r2("terms").ToString().Trim().ToLower() AndAlso r("items").ToString().Trim().ToLower() = r2("items").ToString().Trim().ToLower() AndAlso r("description").ToString().Trim().ToLower() = r2("description").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("cust_name").ToString().Trim().ToLower() = r2("cust_name").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("inwords").ToString().Trim().ToLower() = r2("inwords").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into sup_inv_temp_t (stcode, st_date, duedate, terms, items, description, credit, cust_name, location, inwords, syncode) values(@stcode, @st_date, @duedate, @terms, @items, @description, @credit, @cust_name, @location, @inwords, @syncode)"}
                cmd.Parameters.Add("@stcode", MySqlDbType.Int32).Value = dt3.Rows(j)("stcode")
                cmd.Parameters.Add("@st_date", MySqlDbType.Date).Value = dt3.Rows(j)("st_date")
                cmd.Parameters.Add("@duedate", MySqlDbType.Date).Value = dt3.Rows(j)("duedate")
                cmd.Parameters.Add("@terms", MySqlDbType.VarChar).Value = dt3.Rows(j)("terms")
                cmd.Parameters.Add("@items", MySqlDbType.VarChar).Value = dt3.Rows(j)("items")
                cmd.Parameters.Add("@description", MySqlDbType.VarChar).Value = dt3.Rows(j)("description")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@cust_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_name")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@inwords", MySqlDbType.VarChar).Value = dt3.Rows(j)("inwords")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_sup_inv_temp_t()

    End Sub

    Private Sub Delete_sup_inv_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM sup_inv_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from sup_inv_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncSupplierAddress_t()

    End Sub

    Public Sub SyncSupplierAddress_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  supplier_address_t"
            strSQL2 = "SELECT  * FROM  supplier_address_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("cust_code").ToString().Trim().ToLower() = r2("cust_code").ToString().Trim().ToLower() AndAlso r("office_add").ToString().Trim().ToLower() = r2("office_add").ToString().Trim().ToLower() AndAlso r("land_line").ToString().Trim().ToLower() = r2("land_line").ToString().Trim().ToLower() AndAlso r("mobile").ToString().Trim().ToLower() = r2("mobile").ToString().Trim().ToLower() AndAlso r("fax_num").ToString().Trim().ToLower() = r2("fax_num").ToString().Trim().ToLower() AndAlso r("email_add").ToString().Trim().ToLower() = r2("email_add").ToString().Trim().ToLower() AndAlso r("website").ToString().Trim().ToLower() = r2("website").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into supplier_address_temp_t (cust_code, office_add, land_line, mobile, fax_num, email_add, website, syncode) values(@cust_code, @office_add, @land_line, @mobile, @fax_num, @email_add, @website, @syncode)"}
                cmd.Parameters.Add("@cust_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_code")
                cmd.Parameters.Add("@office_add", MySqlDbType.VarChar).Value = dt3.Rows(j)("office_add")
                cmd.Parameters.Add("@land_line", MySqlDbType.VarChar).Value = dt3.Rows(j)("land_line")
                cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = dt3.Rows(j)("mobile")
                cmd.Parameters.Add("@fax_num", MySqlDbType.VarChar).Value = dt3.Rows(j)("fax_num")
                cmd.Parameters.Add("@email_add", MySqlDbType.VarChar).Value = dt3.Rows(j)("email_add")
                cmd.Parameters.Add("@website", MySqlDbType.VarChar).Value = dt3.Rows(j)("website")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_supplier_address_temp_t()

    End Sub

    Private Sub Delete_supplier_address_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM supplier_address_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from supplier_address_temp_t where cust_id = @cust_id"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cust_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncSupplier_t()

    End Sub

    Public Sub SyncSupplier_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  supplier_t"
            strSQL2 = "SELECT  * FROM  supplier_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("cust_id").ToString().Trim().ToLower() = r2("cust_id").ToString().Trim().ToLower() AndAlso r("cust_code").ToString().Trim().ToLower() = r2("cust_code").ToString().Trim().ToLower() AndAlso r("fname").ToString().Trim().ToLower() = r2("fname").ToString().Trim().ToLower() AndAlso r("mid_name").ToString().Trim().ToLower() = r2("mid_name").ToString().Trim().ToLower() AndAlso r("lname").ToString().Trim().ToLower() = r2("lname").ToString().Trim().ToLower() AndAlso r("title").ToString().Trim().ToLower() = r2("title").ToString().Trim().ToLower() AndAlso r("supname").ToString().Trim().ToLower() = r2("supname").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into supplier_temp_t (cust_code, fname, mid_name, lname, title, supname, syncode) values(@cust_code, @fname, @mid_name, @lname, @title, @supname, @syncode)"}
                cmd.Parameters.Add("@cust_code", MySqlDbType.VarChar).Value = dt3.Rows(j)("cust_code")
                cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = dt3.Rows(j)("fname")
                cmd.Parameters.Add("@mid_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("mid_name")
                cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = dt3.Rows(j)("lname")
                cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = dt3.Rows(j)("title")
                cmd.Parameters.Add("@supname", MySqlDbType.VarChar).Value = dt3.Rows(j)("supname")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_supplier_temp_t()

    End Sub

    Private Sub Delete_supplier_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM supplier_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from supplier_temp_t where cust_id = @cust_id"}
                cmd.Parameters.Add("@cust_id", MySqlDbType.Int32).Value = dt1.Rows(k)("cust_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncTemp_t()

    End Sub

    Public Sub SyncTemp_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  temp_t"
            strSQL2 = "SELECT  * FROM  temp_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("temp_id").ToString().Trim().ToLower() = r2("temp_id").ToString().Trim().ToLower() AndAlso r("coa_name").ToString().Trim().ToLower() = r2("coa_name").ToString().Trim().ToLower() AndAlso r("debit").ToString().Trim().ToLower() = r2("debit").ToString().Trim().ToLower() AndAlso r("credit").ToString().Trim().ToLower() = r2("credit").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into temp_temp_t (coa_name, debit, credit, syncode) values(@coa_name, @debit, @credit, @syncode)"}
                cmd.Parameters.Add("@coa_name", MySqlDbType.VarChar).Value = dt3.Rows(j)("coa_name")
                cmd.Parameters.Add("@debit", MySqlDbType.Float).Value = dt3.Rows(j)("debit")
                cmd.Parameters.Add("@credit", MySqlDbType.Float).Value = dt3.Rows(j)("credit")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_temp_temp_t()

    End Sub

    Private Sub Delete_temp_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM temp_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from temp_temp_t where temp_id = @temp_id"}
                cmd.Parameters.Add("@temp_id", MySqlDbType.Int32).Value = dt1.Rows(k)("temp_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncUserControl_t()

    End Sub

    Public Sub SyncUserControl_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM   user_control_t"
            strSQL2 = "SELECT  * FROM   user_control_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("user").ToString().Trim().ToLower() = r2("user").ToString().Trim().ToLower() AndAlso r("chrt").ToString().Trim().ToLower() = r2("chrt").ToString().Trim().ToLower() AndAlso r("demo").ToString().Trim().ToLower() = r2("demo").ToString().Trim().ToLower() AndAlso r("cremo").ToString().Trim().ToLower() = r2("cremo").ToString().Trim().ToLower() AndAlso r("jent").ToString().Trim().ToLower() = r2("jent").ToString().Trim().ToLower() AndAlso r("recpay").ToString().Trim().ToLower() = r2("recpay").ToString().Trim().ToLower() AndAlso r("paybill").ToString().Trim().ToLower() = r2("paybill").ToString().Trim().ToLower() AndAlso r("bnk").ToString().Trim().ToLower() = r2("bnk").ToString().Trim().ToLower() AndAlso r("pos").ToString().Trim().ToLower() = r2("pos").ToString().Trim().ToLower() AndAlso r("csale").ToString().Trim().ToLower() = r2("csale").ToString().Trim().ToLower() AndAlso r("cstate").ToString().Trim().ToLower() = r2("cstate").ToString().Trim().ToLower() AndAlso r("debrep").ToString().Trim().ToLower() = r2("debrep").ToString().Trim().ToLower() AndAlso r("adstoqty").ToString().Trim().ToLower() = r2("adstoqty").ToString().Trim().ToLower() AndAlso r("posord").ToString().Trim().ToLower() = r2("posord").ToString().Trim().ToLower() AndAlso r("billtac").ToString().Trim().ToLower() = r2("billtac").ToString().Trim().ToLower() AndAlso r("adware").ToString().Trim().ToLower() = r2("adware").ToString().Trim().ToLower() AndAlso r("adstore").ToString().Trim().ToLower() = r2("adstore").ToString().Trim().ToLower() AndAlso r("addef").ToString().Trim().ToLower() = r2("addef").ToString().Trim().ToLower() AndAlso r("adjuwareqty").ToString().Trim().ToLower() = r2("adjuwareqty").ToString().Trim().ToLower() AndAlso r("mcunt").ToString().Trim().ToLower() = r2("mcunt").ToString().Trim().ToLower() AndAlso r("whsales").ToString().Trim().ToLower() = r2("whsales").ToString().Trim().ToLower() AndAlso r("invtrep").ToString().Trim().ToLower() = r2("invtrep").ToString().Trim().ToLower() AndAlso r("purep").ToString().Trim().ToLower() = r2("purep").ToString().Trim().ToLower() AndAlso r("salrep").ToString().Trim().ToLower() = r2("salrep").ToString().Trim().ToLower() AndAlso r("finstate").ToString().Trim().ToLower() = r2("finstate").ToString().Trim().ToLower() AndAlso r("sett").ToString().Trim().ToLower() = r2("sett").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into user_control_temp_t (user, chrt, demo, cremo, jent, recpay, paybill, bnk, pos, csale, cstate, debrep, adstoqty, posord, billtac, adware, adstore, addef, adjuwareqty, mcunt, whsales, invtrep, purep, salrep, finstate, sett, syncode) values(@user, @chrt, @demo, @cremo, @jent, @recpay, @paybill, @bnk, @pos, @csale, @cstate, @debrep, @adstoqty, @posord, @billtac, @adware, @adstore, @addef, @adjuwareqty, @mcunt, @whsales, @invtrep, @purep, @salrep, @finstate, @sett, @syncode)"}
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = dt3.Rows(j)("user")
                cmd.Parameters.Add("@chrt", MySqlDbType.VarChar).Value = dt3.Rows(j)("chrt")
                cmd.Parameters.Add("@demo", MySqlDbType.VarChar).Value = dt3.Rows(j)("demo")
                cmd.Parameters.Add("@cremo", MySqlDbType.VarChar).Value = dt3.Rows(j)("cremo")
                cmd.Parameters.Add("@jent", MySqlDbType.VarChar).Value = dt3.Rows(j)("jent")
                cmd.Parameters.Add("@recpay", MySqlDbType.VarChar).Value = dt3.Rows(j)("recpay")
                cmd.Parameters.Add("@paybill", MySqlDbType.VarChar).Value = dt3.Rows(j)("paybill")
                cmd.Parameters.Add("@bnk", MySqlDbType.VarChar).Value = dt3.Rows(j)("bnk")
                cmd.Parameters.Add("@pos", MySqlDbType.VarChar).Value = dt3.Rows(j)("pos")
                cmd.Parameters.Add("@csale", MySqlDbType.VarChar).Value = dt3.Rows(j)("csale")
                cmd.Parameters.Add("@cstate", MySqlDbType.VarChar).Value = dt3.Rows(j)("cstate")
                cmd.Parameters.Add("@debrep", MySqlDbType.VarChar).Value = dt3.Rows(j)("debrep")
                cmd.Parameters.Add("@adstoqty", MySqlDbType.VarChar).Value = dt3.Rows(j)("adstoqty")
                cmd.Parameters.Add("@posord", MySqlDbType.VarChar).Value = dt3.Rows(j)("posord")
                cmd.Parameters.Add("@billtac", MySqlDbType.VarChar).Value = dt3.Rows(j)("billtac")
                cmd.Parameters.Add("@adware", MySqlDbType.VarChar).Value = dt3.Rows(j)("adware")
                cmd.Parameters.Add("@adstore", MySqlDbType.VarChar).Value = dt3.Rows(j)("adstore")
                cmd.Parameters.Add("@addef", MySqlDbType.VarChar).Value = dt3.Rows(j)("addef")
                cmd.Parameters.Add("@adjuwareqty", MySqlDbType.VarChar).Value = dt3.Rows(j)("adjuwareqty")
                cmd.Parameters.Add("@mcunt", MySqlDbType.VarChar).Value = dt3.Rows(j)("mcunt")
                cmd.Parameters.Add("@whsales", MySqlDbType.VarChar).Value = dt3.Rows(j)("whsales")
                cmd.Parameters.Add("@invtrep", MySqlDbType.VarChar).Value = dt3.Rows(j)("invtrep")
                cmd.Parameters.Add("@purep", MySqlDbType.VarChar).Value = dt3.Rows(j)("purep")
                cmd.Parameters.Add("@salrep", MySqlDbType.VarChar).Value = dt3.Rows(j)("salrep")
                cmd.Parameters.Add("@finstate", MySqlDbType.VarChar).Value = dt3.Rows(j)("finstate")
                cmd.Parameters.Add("@sett", MySqlDbType.VarChar).Value = dt3.Rows(j)("sett")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_user_control_temp_t()

    End Sub

    Private Sub Delete_user_control_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM user_control_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from user_control_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncUsers_t()

    End Sub

    Public Sub SyncUsers_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  users_t"
            strSQL2 = "SELECT  * FROM  users_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("username").ToString().Trim().ToLower() = r2("username").ToString().Trim().ToLower() AndAlso r("password").ToString().Trim().ToLower() = r2("password").ToString().Trim().ToLower() AndAlso r("userrole").ToString().Trim().ToLower() = r2("userrole").ToString().Trim().ToLower() AndAlso r("userlocation").ToString().Trim().ToLower() = r2("userlocation").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into users_temp_t (username, password, userrole, userlocation, syncode) values(@username, @password, @userrole, @userlocation, @syncode)"}
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = dt3.Rows(j)("username")
                cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = dt3.Rows(j)("password")
                cmd.Parameters.Add("@userrole", MySqlDbType.VarChar).Value = dt3.Rows(j)("userrole")
                cmd.Parameters.Add("@userlocation", MySqlDbType.VarChar).Value = dt3.Rows(j)("userlocation")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_users_temp_t()

    End Sub

    Private Sub Delete_users_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM users_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from users_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncVat_t()

    End Sub

    Public Sub SyncVat_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  vat_t"
            strSQL2 = "SELECT  * FROM  vat_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("vat_num").ToString().Trim().ToLower() = r2("vat_num").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insert into vat_temp_t (vat_num, syncode) values(@vat_num, @syncode)"}
                cmd.Parameters.Add("@vat_num", MySqlDbType.Float).Value = dt3.Rows(j)("vat_num")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_vat_temp_t()

    End Sub

    Private Sub Delete_vat_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM vat_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from vat_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncWareHouse_t()

    End Sub

    Public Sub SyncWareHouse_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  * FROM  ware_house_t"
            strSQL2 = "SELECT  * FROM  ware_house_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

        Catch ex As System.Exception

        End Try

        Delete_ware_house_temp_t()

    End Sub

    Private Sub Delete_ware_house_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM ware_house_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from ware_house_temp_t where pro_id = @pro_id"}
                cmd.Parameters.Add("@pro_id", MySqlDbType.Int32).Value = dt1.Rows(k)("pro_id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        SyncWarehouseManualCountHis_t()

    End Sub

    Public Sub SyncWarehouseManualCountHis_t()


        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim ds2 As New DataSet
            Dim dt2 As DataTable
            Dim strConSrc, strConDest, strSQL1, strSQL2 As String

            strConSrc = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString
            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "SELECT  *  FROM   warehouse_manual_count_his_t"
            strSQL2 = "SELECT  *  FROM   warehouse_manual_count_his_t"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("id").ToString().Trim().ToLower() = r2("id").ToString().Trim().ToLower() AndAlso r("pro_descrip").ToString().Trim().ToLower() = r2("pro_descrip").ToString().Trim().ToLower() AndAlso r("unit_cost").ToString().Trim().ToLower() = r2("unit_cost").ToString().Trim().ToLower() AndAlso r("totonpc").ToString().Trim().ToLower() = r2("totonpc").ToString().Trim().ToLower() AndAlso r("totpcscnt").ToString().Trim().ToLower() = r2("totpcscnt").ToString().Trim().ToLower() AndAlso r("location").ToString().Trim().ToLower() = r2("location").ToString().Trim().ToLower() AndAlso r("count_date").ToString().Trim().ToLower() = r2("count_date").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into warehouse_manual_count_his_temp_t (pro_descrip, unit_cost, totonpc, totpcscnt, location, count_date, syncode) values(@pro_descrip, @unit_cost, @totonpc, @totpcscnt, @location, @count_date, @syncode)"}
                cmd.Parameters.Add("@pro_descrip", MySqlDbType.VarChar).Value = dt3.Rows(j)("pro_descrip")
                cmd.Parameters.Add("@unit_cost", MySqlDbType.Float).Value = dt3.Rows(j)("unit_cost")
                cmd.Parameters.Add("@totonpc", MySqlDbType.Float).Value = dt3.Rows(j)("totonpc")
                cmd.Parameters.Add("@totpcscnt", MySqlDbType.Float).Value = dt3.Rows(j)("totpcscnt")
                cmd.Parameters.Add("@location", MySqlDbType.VarChar).Value = dt3.Rows(j)("location")
                cmd.Parameters.Add("@count_date", MySqlDbType.Date).Value = dt3.Rows(j)("count_date")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_warehouse_manual_count_his_temp_t()

    End Sub

    Private Sub Delete_warehouse_manual_count_his_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM warehouse_manual_count_his_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For k As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from warehouse_manual_count_his_temp_t where id = @id"}
                cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = dt1.Rows(k)("id")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        MySyncOut.SyncBankObal_t()

    End Sub


End Class

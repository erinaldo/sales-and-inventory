
Imports System.Configuration
Imports MySql.Data.MySqlClient
Public Class SyncDeletedDataInClass

    Dim MySyncDel As New SyncDeletedDataOutClass

    Public Sub SyncDeletedDataIn()

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

            strSQL1 = "SELECT  *  FROM   delete_data_t"
            strSQL2 = "SELECT  *  FROM   delete_data_t"

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

            Dim dt3 As DataTable = (From r In dt1.AsEnumerable() Where Not dt2.AsEnumerable().Any(Function(r2) r("del_description").ToString().Trim().ToLower() = r2("del_description").ToString().Trim().ToLower() AndAlso r("syncode").ToString().Trim().ToLower() = r2("syncode").ToString().Trim().ToLower()) Select r).CopyToDataTable()

            For j As Int32 = 0 To dt3.Rows.Count - 1

                Dim cnn As MySqlConnection = New MySqlConnection(strConDest)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into delete_data_temp_t (del_description, syncode) values(@del_description, @syncode)"}
                cmd.Parameters.Add("@del_description", MySqlDbType.VarChar).Value = dt3.Rows(j)("del_description")
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt3.Rows(j)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As System.Exception

        End Try

        Delete_bank_open_bal_t()

    End Sub

    Public Sub Delete_bank_open_bal_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bank_open_bal_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_bank_t()

    End Sub

    Public Sub Delete_bank_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bank_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from bills_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_mems_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from cash_sales_warehouse_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from category_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from chart_of_account_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from comp_logo_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from company_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_memo_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_mems_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_sales_warehouse_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from credit_statement_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from customers_address_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from customers_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from debit_memo_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from debit_statement_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from deffective_items_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_address_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_info_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from emp_sal_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from expense_bills_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from item_movement_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from journal_voucher_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from loca_area_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from other_cust_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_order_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_return_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from purchase_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from pust_items_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from receipt_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from sales_return_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from shelve_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from sup_inv_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from supplier_address_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from supplier_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from temp_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from user_control_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from users_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from vat_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from ware_house_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

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

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

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
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from warehouse_manual_count_his_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(k)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_delete_data_temp()

    End Sub

    Private Sub Delete_delete_data_temp()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL2 = "SELECT  * FROM delete_data_temp_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For p As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from delete_data_temp_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(p)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        Delete_On_delete_data_t()

    End Sub

    Private Sub Delete_On_delete_data_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

            strSQL2 = "SELECT  * FROM delete_data_t"

            objConn.ConnectionString = strConDest
            With objCmd
                .Connection = objConn
                .CommandText = strSQL2
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)

            For p As Integer = 0 To dt1.Rows.Count - 1

                Dim connetionString As String = strConDest
                Dim cnn As MySqlConnection = New MySqlConnection(connetionString)
                Dim cmd As New MySqlCommand() With {.CommandType = CommandType.Text, .CommandText = "delete from delete_data_t where syncode = @syncode"}
                cmd.Parameters.Add("@syncode", MySqlDbType.VarChar).Value = dt1.Rows(p)("syncode")
                cmd.Connection = cnn

                cnn.Open()
                cmd.ExecuteNonQuery()
                objConn.Close()
                cnn.Close()

            Next

        Catch ex As Exception

        End Try

        MySyncDel.SyncDeletedDataOut()

    End Sub

End Class

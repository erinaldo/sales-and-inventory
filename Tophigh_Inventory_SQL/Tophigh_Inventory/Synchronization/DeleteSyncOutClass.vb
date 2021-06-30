Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class DeleteSyncOutClass

    Dim MySyncInDel As New SyncDeletedDataInClass

    Public Sub Delete_bank_open_bal_temp_t()

        Try

            Dim objConn As New MySqlConnection
            Dim objCmd As New MySqlCommand
            Dim dtAdapter As New MySqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConDest, strSQL2 As String

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

            strConDest = ConfigurationManager.ConnectionStrings("OnSvr").ConnectionString

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

        MySyncInDel.SyncDeletedDataIn()

    End Sub

End Class

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

Public Class SalesReturnClass

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

    Public Sub FillCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select pro_descrip from shelve_t where location='" & MainForm.txtlocation.Text & "'", conn) With {.CommandTimeout = 60}
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

            SalesReturnForm.cbodata.Items.Clear()
            SalesReturnForm.cbodata.Items.Add("")
            SalesReturnForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='{0}' and location='{1}'", SalesReturnForm.cbodata.Text, MainForm.txtlocation.Text), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where pro_descrip='{0}' AND location='{1}'", SalesReturnForm.cbodata.Text, MainForm.txtlocation.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesReturnForm.txtid.Text = dr.Item("pro_id")
                SalesReturnForm.txtName.Text = dr.Item("pro_descrip")
                SalesReturnForm.txtamt.Text = dr.Item("sales_price")
                SalesReturnForm.txtrate.Text = dr.Item("sales_price")
                SalesReturnForm.txtunitcost.Text = dr.Item("unit_cost")
                SalesReturnForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from shelve_t Where bar_code='{0}' AND location='{1}'", SalesReturnForm.cbodata.Text, MainForm.txtlocation.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesReturnForm.txtid.Text = dr.Item("pro_id")
                SalesReturnForm.txtName.Text = dr.Item("pro_descrip")
                SalesReturnForm.txtamt.Text = dr.Item("sales_price")
                SalesReturnForm.txtrate.Text = dr.Item("sales_price")
                SalesReturnForm.txtunitcost.Text = dr.Item("unit_cost")
                SalesReturnForm.txtutot.Text = dr.Item("unit_cost")

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

            SalesReturnForm.dgvsales.ReadOnly = False
            SalesReturnForm.dgvsales.DataSource = dtInvoice
            SalesReturnForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            SalesReturnForm.dgvsales.Columns(0).Width = 50
            SalesReturnForm.dgvsales.Columns(1).Width = 240
            SalesReturnForm.dgvsales.Columns(2).Width = 100
            SalesReturnForm.dgvsales.Columns(3).Width = 120
            SalesReturnForm.dgvsales.Columns(4).Width = 140
            SalesReturnForm.dgvsales.Columns(5).Visible = False
            SalesReturnForm.dgvsales.Columns(6).Visible = False
            SalesReturnForm.dgvsales.Columns(0).Visible = False
            SalesReturnForm.dgvsales.Columns(3).ReadOnly = True

            SalesReturnForm.dgvsales.ForeColor = Color.Black

            SalesReturnForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            SalesReturnForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            SalesReturnForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            SalesReturnForm.dgvsales.AllowUserToResizeColumns = False
            SalesReturnForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            SalesReturnForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            SalesReturnForm.dgvsales.AllowUserToAddRows = False

            InsertCashSalesReturns()
            UpdateShelfQty()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()
            InsertSalesDisc()

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                dgvItem = SalesReturnForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = SalesReturnForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = SalesReturnForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = SalesReturnForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertSalesReturnsData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = SalesReturnForm.cboPayMeth.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = SalesReturnForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = SalesReturnForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = SalesReturnForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@card_check_num", SqlDbType.VarChar).Value = SalesReturnForm.mCheck.Text.Trim()
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

        SalesReturnForm.Close()
        SalesReturnForm.Dispose()

        MainForm.btnSalesRet.PerformClick()

    End Sub

    Public Sub InsertCashSalesReturns()

        Try


            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                dgvItem = SalesReturnForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = SalesReturnForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = SalesReturnForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = SalesReturnForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCashSalesData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = SalesReturnForm.txtReceiptno.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = SalesReturnForm.cboPayMeth.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty * -1
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = SalesReturnForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount * -1
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = SalesReturnForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = SalesReturnForm.mDescript.Text.Trim()
                cmd.Parameters.Add("@card_check_num", SqlDbType.VarChar).Value = SalesReturnForm.mCheck.Text.Trim()
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

    End Sub

    Public Sub InsertCogs()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                dgvcogstot = SalesReturnForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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

            For i As Integer = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                dgvcogstot = SalesReturnForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.cboPayMeth.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = SalesReturnForm.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = SalesReturnForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.txtdiscAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = SalesReturnForm.txtsaldisc.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = SalesReturnForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = SalesReturnForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = SalesReturnForm.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = SalesReturnForm.txtvat.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = SalesReturnForm.lblTime.Text
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

            For i As Integer = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                dgvid = SalesReturnForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = SalesReturnForm.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelveSalesReturn"}
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

    Public Sub GetData()

        Try


            If SalesReturnForm.txtid.Text <> "" AndAlso SalesReturnForm.txtName.Text <> "" AndAlso SalesReturnForm.txtqty.Text <> "" AndAlso SalesReturnForm.txtrate.Text <> "" AndAlso SalesReturnForm.txtamt.Text <> "" AndAlso SalesReturnForm.txtunitcost.Text <> "" AndAlso SalesReturnForm.txtutot.Text <> "" Then
                dtInvoice.Rows.Add(SalesReturnForm.txtid.Text, SalesReturnForm.txtName.Text, SalesReturnForm.txtqty.Text, SalesReturnForm.txtrate.Text, SalesReturnForm.txtamt.Text, SalesReturnForm.txtunitcost.Text, SalesReturnForm.txtutot.Text)
            End If

            SalesReturnForm.txtName.Text = ""
            SalesReturnForm.txtid.Text = ""
            SalesReturnForm.cbodata.Text = ""
            SalesReturnForm.txtqty.Text = "1"
            SalesReturnForm.txtrate.Text = ""
            SalesReturnForm.txtamt.Text = ""
            SalesReturnForm.txtunitcost.Text = ""
            SalesReturnForm.txtutot.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = SalesReturnForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = SalesReturnForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                SalesReturnForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j

        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To SalesReturnForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = SalesReturnForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = SalesReturnForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                SalesReturnForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To SalesReturnForm.dgvsales.Rows.Count - 1
                totalSum += SalesReturnForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            SalesReturnForm.txtsubtot.Text = totalSum.ToString("n2")

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
            cmd.CommandText = "select MAX(cash_num)from sales_Return_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                SalesReturnForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                SalesReturnForm.mSaleNo.Text = number
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

            SalesReturnForm.cboCustomer.Items.Clear()
            SalesReturnForm.cboCustomer.Items.Add("")
            SalesReturnForm.cboCustomer.Items.AddRange(names.ToArray)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub GetCash()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("SELECT coa_name FROM paymeth_v", conn) With {.CommandTimeout = 60}
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

            SalesReturnForm.cboPayMeth.Items.Clear()
            SalesReturnForm.cboPayMeth.Items.Add("")
            SalesReturnForm.cboPayMeth.Items.AddRange(names.ToArray)

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

                SalesReturnForm.txtsalesAcc.Text = dr.Item("coa_name")

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

                SalesReturnForm.txtcogsAcc.Text = dr.Item("coa_name")

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

                SalesReturnForm.txtInvAcc.Text = dr.Item("coa_name")

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

                SalesReturnForm.txtdiscAcc.Text = dr.Item("coa_name")

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

                SalesReturnForm.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from beneficiary Where supplier='{0}'", SalesReturnForm.cboCustomer.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesReturnForm.txtcustid.Text = dr.Item("id")

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

                SalesReturnForm.txtvatval.Text = dr.Item("vat_num")

                dr.Close()

            End If

        Catch oEX As Exception

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

End Class

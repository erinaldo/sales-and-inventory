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

Public Class CreditMemoClass

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

            CreditMemoForm.cbodata.Items.Clear()
            CreditMemoForm.cbodata.Items.Add("")
            CreditMemoForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(CreditMemoForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where pro_descrip='" & convertQuotes(CreditMemoForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditMemoForm.txtid.Text = dr.Item("pro_id")
                CreditMemoForm.txtName.Text = dr.Item("pro_descrip")
                CreditMemoForm.txtamt.Text = dr.Item("whole_sales_price")
                CreditMemoForm.txtrate.Text = dr.Item("whole_sales_price")
                CreditMemoForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditMemoForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(CreditMemoForm.cbodata.Text) & "' and location='" & convertQuotes(MainForm.txtlocation.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditMemoForm.txtid.Text = dr.Item("pro_id")
                CreditMemoForm.txtName.Text = dr.Item("pro_descrip")
                CreditMemoForm.txtamt.Text = dr.Item("whole_sales_price")
                CreditMemoForm.txtrate.Text = dr.Item("whole_sales_price")
                CreditMemoForm.txtunitcost.Text = dr.Item("unit_cost")
                CreditMemoForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            CreditMemoForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCreditSales()
            InsertCogs()
            InsertInv()
            InsertCash()
            InsertIncome()

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                dgvItem = CreditMemoForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = CreditMemoForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = CreditMemoForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = CreditMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCreditMemoData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = CreditMemoForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = CreditMemoForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = CreditMemoForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = CreditMemoForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = CreditMemoForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = CreditMemoForm.mDescript.Text.Trim()
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


        PrintDirectInvoice()

        CreditMemoForm.Close()
        CreditMemoForm.Dispose()

        MainForm.btnCreditmemo.PerformClick()

    End Sub

    Public Sub InsertCreditSales()

        Try

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                dgvItem = CreditMemoForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = CreditMemoForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = CreditMemoForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = CreditMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertCreditSalesData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditMemoForm.txtInvNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = CreditMemoForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = CreditMemoForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = CreditMemoForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty * -1
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = CreditMemoForm.txtvat.Text * -1
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount * -1
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = CreditMemoForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = CreditMemoForm.mDescript.Text.Trim()
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

            For i As Integer = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                dgvcogstot = CreditMemoForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditMemoForm.txtcogsAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text
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

            For i As Integer = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                dgvcogstot = CreditMemoForm.dgvsales.Rows(i).Cells(6).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditMemoForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditMemoForm.txtcashAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = CreditMemoForm.txtTotal.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditMemoForm.txtsalesAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditMemoForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = CreditMemoForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = CreditMemoForm.txtTaxAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = CreditMemoForm.txtvat.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = CreditMemoForm.lblTime.Text
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

            For i As Integer = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                dgvid = CreditMemoForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = CreditMemoForm.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelveQtyRet"}
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvqty.Trim()
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


            If CreditMemoForm.txtid.Text <> "" AndAlso CreditMemoForm.txtName.Text <> "" AndAlso CreditMemoForm.txtqty.Text <> "" AndAlso CreditMemoForm.txtrate.Text <> "" AndAlso CreditMemoForm.txtamt.Text <> "" AndAlso CreditMemoForm.txtunitcost.Text <> "" AndAlso CreditMemoForm.txtutot.Text <> "" Then
                dtInvoice.Rows.Add(CreditMemoForm.txtid.Text, CreditMemoForm.txtName.Text, CreditMemoForm.txtqty.Text, CreditMemoForm.txtrate.Text, CreditMemoForm.txtamt.Text, CreditMemoForm.txtunitcost.Text, CreditMemoForm.txtutot.Text)
            End If

            CreditMemoForm.txtName.Text = ""
            CreditMemoForm.txtid.Text = ""
            CreditMemoForm.cbodata.Text = ""
            CreditMemoForm.txtqty.Text = "1"
            CreditMemoForm.txtrate.Text = ""
            CreditMemoForm.txtamt.Text = ""
            CreditMemoForm.txtunitcost.Text = ""
            CreditMemoForm.txtutot.Text = ""

            CalGridData()

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

            CreditMemoForm.dgvsales.ReadOnly = False
            CreditMemoForm.dgvsales.DataSource = dtInvoice
            CreditMemoForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            CreditMemoForm.dgvsales.Columns(0).Width = 50
            CreditMemoForm.dgvsales.Columns(1).Width = 240
            CreditMemoForm.dgvsales.Columns(2).Width = 100
            CreditMemoForm.dgvsales.Columns(3).Width = 120
            CreditMemoForm.dgvsales.Columns(4).Width = 140
            CreditMemoForm.dgvsales.Columns(5).Visible = False
            CreditMemoForm.dgvsales.Columns(6).Visible = False
            CreditMemoForm.dgvsales.Columns(0).Visible = False
            CreditMemoForm.dgvsales.Columns(3).ReadOnly = True

            CreditMemoForm.dgvsales.ForeColor = Color.Black

            CreditMemoForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            CreditMemoForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            CreditMemoForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            CreditMemoForm.dgvsales.AllowUserToResizeColumns = False
            CreditMemoForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            CreditMemoForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CreditMemoForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = CreditMemoForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                CreditMemoForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To CreditMemoForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = CreditMemoForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = CreditMemoForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                CreditMemoForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k


        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To CreditMemoForm.dgvsales.Rows.Count - 1
                totalSum += CreditMemoForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            CreditMemoForm.txtsubtot.Text = totalSum.ToString("n2")

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
            cmd.CommandText = "select MAX(cash_num)from credit_memo_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                CreditMemoForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                CreditMemoForm.mSaleNo.Text = number
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
        Dim cmd As New SqlCommand("select supplier from beneficiary group by supplier", conn) With {.CommandTimeout = 60}
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

            CreditMemoForm.cboCustomer.Items.Clear()
            CreditMemoForm.cboCustomer.Items.Add("")
            CreditMemoForm.cboCustomer.Items.AddRange(names.ToArray)

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

                CreditMemoForm.txtcashAcc.Text = dr.Item("coa_name")

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

                CreditMemoForm.txtsalesAcc.Text = dr.Item("coa_name")

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

                CreditMemoForm.txtcogsAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetInvAcc()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='Inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditMemoForm.txtInvAcc.Text = dr.Item("coa_name")

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

                CreditMemoForm.txtdiscAcc.Text = dr.Item("coa_name")

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

                CreditMemoForm.txtTaxAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from beneficiary Where supplier='" & convertQuotes(CreditMemoForm.cboCustomer.Text) & "'group by supplier"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CreditMemoForm.txtcustid.Text = dr.Item("id")

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

                CreditMemoForm.txtvatval.Text = dr.Item("vat_num")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='" & convertQuotes(CreditMemoForm.cboCustomer.Text) & "'", CreditMemoForm.txtcustid.Text), .Connection = conString}

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

                CreditMemoForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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
            Const Empty As String = "  "

            If dr.HasRows Then

                dr.Read()

                Comp = dr.Item("com_name")
                strt = dr.Item("street")
                cty = dr.Item("city")
                cunt = dr.Item("country")
                WorkFon = dr.Item("phone")
                email = dr.Item("email")
                web = dr.Item("website")

                CreditMemoForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrintDirectInvoice()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName


            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("CreditMemoID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = CreditMemoForm.mSaleNo.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "CreditMemoID")

                        Dim report As New CreditMemo
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = CreditMemoForm.txtcomp.Text
                        report.Parameters("pCust").Value = CreditMemoForm.txtAddress.Text
                        report.Parameters("pNum").Value = CreditMemoForm.mSaleNo.Text
                        report.Parameters("pDate").Value = CreditMemoForm.dtSalesDate.Text
                        report.Parameters("pVat").Value = CreditMemoForm.txtvat.Text
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

End Class

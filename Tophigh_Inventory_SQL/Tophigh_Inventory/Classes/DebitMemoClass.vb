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

Public Class DebitMemoClass

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

            DebitMemoForm.cbodata.Items.Clear()
            DebitMemoForm.cbodata.Items.Add("")
            DebitMemoForm.cbodata.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckData()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(DebitMemoForm.cbodata.Text) & "'"), .Connection = conString}

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

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where pro_descrip='" & convertQuotes(DebitMemoForm.cbodata.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                DebitMemoForm.txtid.Text = dr.Item("pro_id")
                DebitMemoForm.txtName.Text = dr.Item("pro_descrip")
                DebitMemoForm.txtamt.Text = dr.Item("sales_price")
                DebitMemoForm.txtrate.Text = dr.Item("sales_price")
                DebitMemoForm.txtunitcost.Text = dr.Item("unit_cost")
                DebitMemoForm.txtutot.Text = dr.Item("unit_cost")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillDataBoxBarcode()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from ware_house_t Where bar_code='" & convertQuotes(DebitMemoForm.cbodata.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                DebitMemoForm.txtid.Text = dr.Item("pro_id")
                DebitMemoForm.txtName.Text = dr.Item("pro_descrip")
                DebitMemoForm.txtamt.Text = dr.Item("sales_price")
                DebitMemoForm.txtrate.Text = dr.Item("sales_price")
                DebitMemoForm.txtunitcost.Text = dr.Item("unit_cost")
                DebitMemoForm.txtutot.Text = dr.Item("unit_cost")

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

            DebitMemoForm.dgvsales.ReadOnly = False
            DebitMemoForm.dgvsales.DataSource = dtInvoice
            DebitMemoForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            DebitMemoForm.dgvsales.Columns(0).Width = 50
            DebitMemoForm.dgvsales.Columns(1).Width = 240
            DebitMemoForm.dgvsales.Columns(2).Width = 100
            DebitMemoForm.dgvsales.Columns(3).Width = 120
            DebitMemoForm.dgvsales.Columns(4).Width = 140
            DebitMemoForm.dgvsales.Columns(5).Visible = False
            DebitMemoForm.dgvsales.Columns(6).Visible = False
            DebitMemoForm.dgvsales.Columns(0).Visible = False
            DebitMemoForm.dgvsales.Columns(3).ReadOnly = True

            DebitMemoForm.dgvsales.ForeColor = Color.Black

            DebitMemoForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            DebitMemoForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            DebitMemoForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DebitMemoForm.dgvsales.AllowUserToResizeColumns = False
            DebitMemoForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            DebitMemoForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try

            DebitMemoForm.dgvsales.AllowUserToAddRows = False

            InsertSupInv()
            InsertPurRet()
            UpdateShelfQty()
            InsertInv()
            InsertCash()

            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                dgvItem = DebitMemoForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = DebitMemoForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = DebitMemoForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = DebitMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertDebitMemoData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = DebitMemoForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@po_num", SqlDbType.Int).Value = DebitMemoForm.txtPO.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = DebitMemoForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@ship_date", SqlDbType.Date).Value = DebitMemoForm.dtshipdate.Text.Trim()
                cmd.Parameters.Add("@pay_terms", SqlDbType.VarChar).Value = DebitMemoForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@vat", SqlDbType.Float).Value = DebitMemoForm.txtvat.Text.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = DebitMemoForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = DebitMemoForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
                cmd.Parameters.Add("@sales_descript", SqlDbType.VarChar).Value = DebitMemoForm.mDescript.Text.Trim()
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

        DebitMemoForm.Close()
        DebitMemoForm.Dispose()

        MainForm.btnDebitMemo.PerformClick()

    End Sub

    Public Sub InsertInv()

        Try

            Dim dgvcogstot As String

            For i As Integer = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                dgvcogstot = DebitMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = DebitMemoForm.mSaleNo.Text
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = DebitMemoForm.dtSalesDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = DebitMemoForm.txtInvAcc.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvcogstot.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = DebitMemoForm.lblTime.Text
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = DebitMemoForm.mSaleNo.Text
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = DebitMemoForm.dtSalesDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = DebitMemoForm.txtcashAcc.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = DebitMemoForm.txtTotal.Text
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = DebitMemoForm.lblTime.Text
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

            For i As Integer = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                dgvid = DebitMemoForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = DebitMemoForm.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateWareRetQty"}
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvid.Trim()
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

    Public Sub InsertPurRet()

        Try


            Dim dgvItem, dgvqty, dgvrate, dgvamount As String

            For i As Integer = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                dgvItem = DebitMemoForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = DebitMemoForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = DebitMemoForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = DebitMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertPurReturnsData"}
                cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = DebitMemoForm.mSaleNo.Text.Trim()
                cmd.Parameters.Add("@cash_date", SqlDbType.Date).Value = DebitMemoForm.dtSalesDate.Text.Trim()
                cmd.Parameters.Add("@pay_meth", SqlDbType.VarChar).Value = DebitMemoForm.cboTerms.Text.Trim()
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvItem.Trim()
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvqty.Trim()
                cmd.Parameters.Add("@rate", SqlDbType.Float).Value = dgvrate.Trim()
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = DebitMemoForm.lblTime.Text.Trim()
                cmd.Parameters.Add("@customer", SqlDbType.VarChar).Value = DebitMemoForm.cboCustomer.Text.Trim()
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = MainForm.lbluser.Text.Trim()
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

    Public Sub InsertSupInv()

        Try

            Dim dgvAcc, dgvdesc As String

            For i As Integer = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                dgvAcc = DebitMemoForm.dgvsales.Rows(i).Cells(1).Value
                dgvdesc = DebitMemoForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertSupInv"}
                cmd.Parameters.Add("@stcode", SqlDbType.Int).Value = DebitMemoForm.txtInvNo.Text
                cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = DebitMemoForm.dtSalesDate.Text
                cmd.Parameters.Add("@duedate", SqlDbType.VarChar).Value = DebitMemoForm.dthistdate.Text
                cmd.Parameters.Add("@terms", SqlDbType.VarChar).Value = DebitMemoForm.cboTerms.Text
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvAcc.Trim()
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = dgvAcc.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvdesc * -1
                cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = DebitMemoForm.cboCustomer.Text
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                cmd.Parameters.Add("@inwords", SqlDbType.VarChar).Value = DebitMemoForm.txtinwords.Text
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

    Public Sub GetData()

        Try


            If DebitMemoForm.txtid.Text <> "" AndAlso DebitMemoForm.txtName.Text <> "" AndAlso DebitMemoForm.txtqty.Text <> "" AndAlso DebitMemoForm.txtrate.Text <> "" AndAlso DebitMemoForm.txtamt.Text <> "" AndAlso DebitMemoForm.txtunitcost.Text <> "" AndAlso DebitMemoForm.txtutot.Text <> "" Then
                dtInvoice.Rows.Add(DebitMemoForm.txtid.Text, DebitMemoForm.txtName.Text, DebitMemoForm.txtqty.Text, DebitMemoForm.txtrate.Text, DebitMemoForm.txtamt.Text, DebitMemoForm.txtunitcost.Text, DebitMemoForm.txtutot.Text)
            End If

            DebitMemoForm.txtName.Text = ""
            DebitMemoForm.txtid.Text = ""
            DebitMemoForm.cbodata.Text = ""
            DebitMemoForm.txtqty.Text = "1"
            DebitMemoForm.txtrate.Text = ""
            DebitMemoForm.txtamt.Text = ""
            DebitMemoForm.txtunitcost.Text = ""
            DebitMemoForm.txtutot.Text = ""

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Double = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = DebitMemoForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = DebitMemoForm.dgvsales.Rows(j).Cells("Rate").Value

                Dim icellResultCost As Double = icell2 * icell3

                DebitMemoForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j

        Catch ex As Exception

        End Try

        Try

            For k As Double = 0 To DebitMemoForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = DebitMemoForm.dgvsales.Rows(k).Cells("Qty").Value
                Dim icell5 As Double = DebitMemoForm.dgvsales.Rows(k).Cells("unitcost").Value

                Dim icellResultCost As Double = icell2 * icell5

                DebitMemoForm.dgvsales.Rows(k).Cells("COSGTotal").Value = icellResultCost.ToString("n2")

            Next k

        Catch ex As Exception

        End Try

        Try


            Dim totalSum As Double

            For i As Double = 0 To DebitMemoForm.dgvsales.Rows.Count - 1
                totalSum += DebitMemoForm.dgvsales.Rows(i).Cells("Amount").Value
            Next i

            DebitMemoForm.txtsubtot.Text = totalSum.ToString("n2")

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
                DebitMemoForm.txtInvNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                DebitMemoForm.txtInvNo.Text = number
            End If

            cmd.Dispose()
            conString.Close()
            conString.Dispose()

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
            cmd.CommandText = "select MAX(cash_num)from debit_memo_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 1
                DebitMemoForm.mSaleNo.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                DebitMemoForm.mSaleNo.Text = number
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

            DebitMemoForm.cboCustomer.Items.Clear()
            DebitMemoForm.cboCustomer.Items.Add("")
            DebitMemoForm.cboCustomer.Items.AddRange(names.ToArray)

        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub GetCash()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='ap'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                DebitMemoForm.txtcashAcc.Text = dr.Item("coa_name")

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

                DebitMemoForm.txtInvAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from beneficiary Where supplier='" & convertQuotes(DebitMemoForm.cboCustomer.Text) & "'group by supplier"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                DebitMemoForm.txtcustid.Text = dr.Item("id")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='" & convertQuotes(DebitMemoForm.cboCustomer.Text) & "'", DebitMemoForm.txtcustid.Text), .Connection = conString}

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

                DebitMemoForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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

                DebitMemoForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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
            Dim cmd As SqlCommand = New SqlCommand("DebitMemoID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cash_num", SqlDbType.Int).Value = DebitMemoForm.mSaleNo.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsInvoice As New DataSet

                        sda.Fill(dsInvoice, "DebitMemoID")

                        Dim report As New DebitNote
                        report.DataSource = dsInvoice
                        report.DataMember = "invoice"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = DebitMemoForm.txtcomp.Text
                        report.Parameters("pCust").Value = DebitMemoForm.txtAddress.Text
                        report.Parameters("pNum").Value = DebitMemoForm.mSaleNo.Text
                        report.Parameters("pDate").Value = DebitMemoForm.dtSalesDate.Text
                        report.Parameters("pVat").Value = DebitMemoForm.txtvat.Text
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

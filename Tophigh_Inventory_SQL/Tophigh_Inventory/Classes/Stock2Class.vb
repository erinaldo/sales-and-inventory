Imports System.Configuration
Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Threading
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Imports DevExpress.Utils
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports DevExpress.XtraReports.UI

Public Class Stock2Class

    Dim dtInvoice As New DataTable("dtInvoice")

    Dim index As Integer

    Shared random As New Random()

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim dtShelBatch As New DataTable("dtShelBatch")


    Public _id As Integer
    Public _product As String
    Public _current_qty As Double
    Public _unit_cost As Double
    Public _sales_price As Double
    Public _hist_date As Date
    Public _qty_add As Double
    Public _ent_time As String
    Public _sys_user As String
    Public _user_location As String
    Public _inv_acc As String
    Public _equ_acc As String

    Public Property equ_acc As String
        Get
            Return _equ_acc
        End Get
        Set(value As String)
            _equ_acc = value
        End Set
    End Property
    Public Property inv_acc As String
        Get
            Return _inv_acc
        End Get
        Set(value As String)
            _inv_acc = value
        End Set
    End Property
    Public Property id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
    Public Property product As String
        Get
            Return _product
        End Get
        Set(value As String)
            _product = value
        End Set
    End Property
    Public Property current_qty As Double
        Get
            Return _current_qty
        End Get
        Set(value As Double)
            _current_qty = value
        End Set
    End Property
    Public Property unit_cost As Double
        Get
            Return _unit_cost
        End Get
        Set(value As Double)
            _unit_cost = value
        End Set
    End Property
    Public Property sales_price As Double
        Get
            Return _sales_price
        End Get
        Set(value As Double)
            _sales_price = value
        End Set
    End Property
    Public Property hist_date As Date
        Get
            Return _hist_date
        End Get
        Set(value As Date)
            _hist_date = value
        End Set
    End Property
    Public Property qty_add As Double
        Get
            Return _qty_add
        End Get
        Set(value As Double)
            _qty_add = value
        End Set
    End Property
    Public Property ent_time As String
        Get
            Return _ent_time
        End Get
        Set(value As String)
            _ent_time = value
        End Set
    End Property
    Public Property sys_user As String
        Get
            Return _sys_user
        End Get
        Set(value As String)
            _sys_user = value
        End Set
    End Property
    Public Property user_location As String
        Get
            Return _user_location
        End Get
        Set(value As String)
            _user_location = value
        End Set
    End Property

    Public _products As String
    Public _qty As Double
    Public _price As Double
    Public _qty_hist As Double
    Public _qty_out As Double
    Public _pu_class As String
    Public _saleId As String
    Public _sale_date As Date
    Public _users As String
    Public _amt_rec As Double
    Public _change As Double
    Public _pup_class As String
    Public _learner As String
    Public _cash_code As Integer
    Public _cashname As String
    Public _debit As Double
    Public _timer As String
    Public _location As String
    Public _revname As String
    Public _comp As String

    Public Property comp As String
        Get
            Return _comp
        End Get
        Set(value As String)
            _comp = value
        End Set
    End Property
    Public Property revname As String
        Get
            Return _revname
        End Get
        Set(value As String)
            _revname = value
        End Set
    End Property
    Public Property location As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property
    Public Property timer As String
        Get
            Return _timer
        End Get
        Set(value As String)
            _timer = value
        End Set
    End Property
    Public Property debit As Double
        Get
            Return _debit
        End Get
        Set(value As Double)
            _debit = value
        End Set
    End Property
    Public Property cashname As String
        Get
            Return _cashname
        End Get
        Set(value As String)
            _cashname = value
        End Set
    End Property
    Public Property cash_code As Int32
        Get
            Return _cash_code
        End Get
        Set(value As Int32)
            _cash_code = value
        End Set
    End Property
    Public Property learner As String
        Get
            Return _learner
        End Get
        Set(value As String)
            _learner = value
        End Set
    End Property
    Public Property pup_class As String
        Get
            Return _pup_class
        End Get
        Set(value As String)
            _pup_class = value
        End Set
    End Property
    Public Property change As Double
        Get
            Return _change
        End Get
        Set(value As Double)
            _change = value
        End Set
    End Property
    Public Property amt_rec As Double
        Get
            Return _amt_rec
        End Get
        Set(value As Double)
            _amt_rec = value
        End Set
    End Property
    Public Property saleId As String
        Get
            Return _saleId
        End Get
        Set(value As String)
            _saleId = value
        End Set
    End Property
    Public Property sale_date As Date
        Get
            Return _sale_date
        End Get
        Set(value As Date)
            _sale_date = value
        End Set
    End Property
    Public Property users As String
        Get
            Return _users
        End Get
        Set(value As String)
            _users = value
        End Set
    End Property

    Public Property pu_class As String
        Get
            Return _pu_class
        End Get
        Set(value As String)
            _pu_class = value
        End Set
    End Property

    Public Property products As String
        Get
            Return _products
        End Get
        Set(value As String)
            _products = value
        End Set
    End Property
    Public Property qty As Double
        Get
            Return _qty
        End Get
        Set(value As Double)
            _qty = value
        End Set
    End Property
    Public Property price As Double
        Get
            Return _price
        End Get
        Set(value As Double)
            _price = value
        End Set
    End Property
    Public Property qty_hist As Double
        Get
            Return _qty_hist
        End Get
        Set(value As Double)
            _qty_hist = value
        End Set
    End Property
    Public Property qty_out As Double
        Get
            Return _qty_out
        End Get
        Set(value As Double)
            _qty_out = value
        End Set
    End Property

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub AddNewWarehouse()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertstock2"}
            cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = _product
            cmd.Parameters.Add("@current_qty", SqlDbType.Float).Value = _current_qty
            cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = _unit_cost
            cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = _sales_price
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _user_location
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            insert_stock_hist()
            cnn.Close()

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
            cmd.Parameters.Add("@hist_date", SqlDbType.Date).Value = _hist_date
            cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = _product
            cmd.Parameters.Add("@qtyonhand", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@qty", SqlDbType.Float).Value = _current_qty
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = _ent_time
            cmd.Parameters.Add("@sys_user", SqlDbType.VarChar).Value = _sys_user
            cmd.Parameters.Add("@user_location", SqlDbType.VarChar).Value = _user_location
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertinvDebit()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = _hist_date
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = _inv_acc
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = _current_qty * _unit_cost
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = _ent_time
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _user_location
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertopCredit()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = _hist_date
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = _equ_acc
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = _current_qty * _unit_cost
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = _ent_time
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _user_location
            cmd.Connection = cnn

            cnn.Open()
            cmd.ExecuteNonQuery()
            cnn.Close()

        Catch ex As Exception

        End Try

        Stock2Form.btnclear.PerformClick()

    End Sub

    Public Sub GetInv()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "SELECT coa_name FROM chart_of_account_t where coa_cogm='inv'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                _inv_acc = dr.Item("coa_name")

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

                _equ_acc = dr.Item("coa_name")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadAvialStock()

        Try

            Stock2ListForm.dgvstock2.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("SELECT product, current_qty, sales_price from store_2_t", Connection)

            ' Create and fill a dataset. 
            Dim dsstock2 As New DataSet()
            Adapter.Fill(dsstock2)

            ' Specify the data source for the grid control. 
            Stock2ListForm.dgvstock2.DataSource = dsstock2.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSalesNum()

        Try

            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
                con.Open()
                Dim cmd = New SqlCommand("select MAX(saleId) from sales_t", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "SAL000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "SAL" + curValue.ToString("D3")
                _saleId = result
                SalesForm.txtCode.Text = _saleId
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetProducts()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select * from store_2_t", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("product").ToString)
            End While
            rd.Close()
            conn.Close()

            SalesForm.cboproduct.Items.Clear()
            SalesForm.cboproduct.Items.Add("")
            SalesForm.cboproduct.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDataBox()

        Try
            Dim conString As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from store_2_t Where product like '%" & convertQuotes(SalesForm.cboproduct.Text) & "%'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SalesForm.txtid.Text = dr.Item("id")
                SalesForm.txtprice.Text = dr.Item("sales_price")
                SalesForm.txtamount.Text = dr.Item("sales_price")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCashAcc()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from chart_of_account_t where coa_cogm = @coa_cogm"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "pt"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                SalesForm.txtcash.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetIncomeAcc()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "select * from chart_of_account_t where coa_cogm = @coa_cogm"}
            'insert product
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = "inc"
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                SalesForm.txtrev.Text = dr.Item("coa_name")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadGridView()

        Try

            dtInvoice.Columns.Add("ID".ToString, GetType(Int32))
            dtInvoice.Columns.Add("Products".ToString, GetType(String))
            dtInvoice.Columns.Add("Qty".ToString, GetType(Double))
            dtInvoice.Columns.Add("Price".ToString, GetType(Double))
            dtInvoice.Columns.Add("Amount".ToString, GetType(Double))

            SalesForm.dgvsales.ReadOnly = False
            SalesForm.dgvsales.DataSource = dtInvoice
            SalesForm.dgvsales.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            SalesForm.dgvsales.Columns(1).ReadOnly = True
            SalesForm.dgvsales.Columns(4).ReadOnly = True
            SalesForm.dgvsales.Columns(0).Visible = False
            SalesForm.dgvsales.Columns(3).ReadOnly = True

            SalesForm.dgvsales.ForeColor = Color.Black

            SalesForm.dgvsales.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            SalesForm.dgvsales.DefaultCellStyle.SelectionForeColor = Color.Black
            SalesForm.dgvsales.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            SalesForm.dgvsales.AllowUserToResizeColumns = False
            SalesForm.dgvsales.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            SalesForm.dgvsales.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalGridData()

        Try

            For j As Integer = 0 To SalesForm.dgvsales.Rows.Count - 1

                Dim icell2 As Double = SalesForm.dgvsales.Rows(j).Cells("Qty").Value
                Dim icell3 As Double = SalesForm.dgvsales.Rows(j).Cells("Price").Value

                Dim icellResultCost As Double = icell2 * icell3

                SalesForm.dgvsales.Rows(j).Cells("Amount").Value = icellResultCost.ToString("n2")

            Next j


        Catch ex As Exception

        End Try

        Try

            Dim totalSum As Double

            For i As Decimal = 0 To SalesForm.dgvsales.Rows.Count - 1
                totalSum += SalesForm.dgvsales.Rows(i).Cells("Amount").Value
            Next

            SalesForm.txtnet.Text = totalSum.ToString("n2")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetData()

        Try

            If SalesForm.txtid.Text <> "" AndAlso SalesForm.cboproduct.Text <> "" AndAlso SalesForm.txtqty.Text <> "" AndAlso SalesForm.txtprice.Text <> "" AndAlso SalesForm.txtamount.Text <> "" Then
                dtInvoice.Rows.Add(SalesForm.txtid.Text, SalesForm.cboproduct.Text, SalesForm.txtqty.Text, SalesForm.txtprice.Text, SalesForm.txtamount.Text)
            End If

            SalesForm.cboproduct.Text = ""
            SalesForm.txtid.Text = ""
            SalesForm.txtqty.Text = "1"
            SalesForm.txtprice.Text = "0.00"
            SalesForm.txtamount.Text = "0.00"

            CalGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCashSales()

        Try


            SalesForm.dgvsales.AllowUserToAddRows = False

            UpdateShelfQty()
            InsertCash()
            InsertIncome()

            Dim dgvItem As String
            Dim dgvqty, dgvrate, dgvamount As Double

            For i As Integer = 0 To SalesForm.dgvsales.Rows.Count

                dgvItem = SalesForm.dgvsales.Rows(i).Cells(1).Value
                dgvqty = SalesForm.dgvsales.Rows(i).Cells(2).Value
                dgvrate = SalesForm.dgvsales.Rows(i).Cells(3).Value
                dgvamount = SalesForm.dgvsales.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into sales_t (saleId, sale_date, product, qty, price, amount, amt_rec, change, users) values(@saleId, @sale_date, @product, @qty, @price, @amount, @amt_rec, @change, @users)"}
                cmd.Parameters.Add("@saleId", SqlDbType.VarChar).Value = _saleId
                cmd.Parameters.Add("@sale_date", SqlDbType.Date).Value = _sale_date
                cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = dgvItem
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvqty
                cmd.Parameters.Add("@price", SqlDbType.Float).Value = dgvrate
                cmd.Parameters.Add("@amount", SqlDbType.Float).Value = dgvamount
                cmd.Parameters.Add("@amt_rec", SqlDbType.Float).Value = _amt_rec
                cmd.Parameters.Add("@change", SqlDbType.Float).Value = _change
                cmd.Parameters.Add("@users", SqlDbType.VarChar).Value = _users
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

    Public Sub UpdateShelfQty()

        Try

            Dim dgvid As Integer
            Dim dgvqty As Double

            For i As Integer = 0 To SalesForm.dgvsales.Rows.Count - 1

                dgvid = SalesForm.dgvsales.Rows(i).Cells(0).Value
                dgvqty = SalesForm.dgvsales.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update store_2_t set current_qty = current_qty - @current_qty where id = @id"}
                cmd.Parameters.Add("@current_qty", SqlDbType.Float).Value = dgvqty
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = dgvid
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = _sale_date
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = _cashname
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = _debit
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = _timer
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _location
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
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = _sale_date
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = _revname
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = _debit
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = _timer
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _location
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

    Public Sub GetSalesOrederData()

        Try

            'Define a connection to the database
            Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            'Create data adapters for retrieving data from the tables
            Dim AdapterCategories As New SqlDataAdapter("SalesOrder_v", connection)
            Dim AdapterProducts As New SqlDataAdapter("SalesOrderDetails_v", connection)

            Dim dataSet11 As New DataSet()
            'Create DataTable objects for representing database's tables
            AdapterCategories.Fill(dataSet11, "SalesOrder_v")
            AdapterProducts.Fill(dataSet11, "SalesOrderDetails_v")

            'Set up a master-detail relationship between the DataTables
            Dim keyColumn As DataColumn = dataSet11.Tables("SalesOrder_v").Columns("ID")
            Dim foreignKeyColumn As DataColumn = dataSet11.Tables("SalesOrderDetails_v").Columns("ID")
            dataSet11.Relations.Add("SalesOrder_vSalesOrderDetails_v", keyColumn, foreignKeyColumn)

            'Bind the grid control to the data source
            SalesReportForm.dgvsalesorder.DataSource = dataSet11.Tables("SalesOrder_v")
            SalesReportForm.dgvsalesorder.ForceInitialize()

            ' Make the grid read-only.
            SalesReportForm.GridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            SalesReportForm.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            SalesReportForm.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        Catch ex As Exception

        End Try

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

            ReceiveOrders2Form.cbolocation.Properties.Items.Clear()
            ReceiveOrders2Form.cbolocation.Properties.Items.Add("")
            ReceiveOrders2Form.cbolocation.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ReceiveWareItems()

        ReceiveOrders2Form.dgvAdjust.Columns.Clear()

        Try

            Dim objConn As New SqlConnection
            Dim objCmd As New SqlCommand
            Dim dtAdapter As New SqlDataAdapter

            Dim ds1 As New DataSet
            Dim dt1 As DataTable
            Dim strConSrc, strSQL1 As String

            strConSrc = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString

            strSQL1 = "Select id As ID, product As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price], current_qty As [Qty On Hand],sum(current_qty-current_qty) As [Qty Received] FROM  store_2_t WHERE location = '" & convertQuotes(ReceiveOrders2Form.cbolocation.Text) & "' group by id, product, unit_cost,sales_price,current_qty"

            objConn.ConnectionString = strConSrc
            With objCmd
                .Connection = objConn
                .CommandText = strSQL1
                .CommandType = CommandType.Text
            End With
            dtAdapter.SelectCommand = objCmd

            dtAdapter.Fill(ds1)
            dt1 = ds1.Tables(0)
            ReceiveOrders2Form.dgvAdjust.DataSource = dt1

            ReceiveOrders2Form.dgvAdjust.Columns(1).ReadOnly = True

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCombo()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select product from store_2_t", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("product").ToString)
            End While
            rd.Close()
            conn.Close()

            ReceiveOrders2Form.cbosearch.Items.Clear()
            ReceiveOrders2Form.cbosearch.Items.Add("")
            ReceiveOrders2Form.cbosearch.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub SearchReceWareItems()

        ReceiveOrders2Form.dgvAdjust.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "Select id As ID, product As Product, CAST(CONVERT(varchar, CAST(unit_cost AS money), 1) AS varchar) As Cost, CAST(CONVERT(varchar, CAST(sales_price AS money), 1) AS varchar) As [Sales Price], current_qty As [Qty On Hand],sum(current_qty-current_qty) As [Qty Received] FROM  store_2_t WHERE product like '%" & convertQuotes(ReceiveOrders2Form.cbosearch.Text) & "%' AND location = '" & convertQuotes(ReceiveOrders2Form.cbolocation.Text) & "' group by id, product, unit_cost,sales_price,current_qty"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "store_2_t")
            sTable = sDs.Tables("store_2_t")
            connection.Close()
            ReceiveOrders2Form.dgvAdjust.DataSource = sDs.Tables("store_2_t")

            ReceiveOrders2Form.dgvAdjust.Columns(1).ReadOnly = True

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertReceiveNewHist()

        Try

            ReceiveOrders2Form.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvonhand As String

            For i As Integer = 0 To ReceiveOrders2Form.dgvAdjust.Rows.Count - 1

                dgvID = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(1).Value
                dgvonhand = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(4).Value
                dgvqty = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "insert into stock_2_history_t (hist_date,product,qtyonhand,qty,ent_time,sys_user,user_location) Values(@hist_date,@product,@qtyonhand,@qty,@ent_time,@sys_user,@user_location)"}
                cmd.Parameters.Add("@hist_date", SqlDbType.Date).Value = ReceiveOrders2Form.dtDate.Text
                cmd.Parameters.Add("@product", SqlDbType.VarChar).Value = dgvID.Trim
                cmd.Parameters.Add("@qtyonhand", SqlDbType.Float).Value = dgvonhand.Trim
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvqty
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = ReceiveOrders2Form.lbltimer.Text
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

    Public Sub UpdateAdjustReceWareQty()

        Try

            ReceiveOrders2Form.dgvAdjust.AllowUserToAddRows = False

            Dim dgvID, dgvqty, dgvpro, dgvcost, dgvprice As String

            For i As Integer = 0 To ReceiveOrders2Form.dgvAdjust.Rows.Count - 1

                dgvID = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(0).Value
                dgvpro = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(1).Value
                dgvcost = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(2).Value
                dgvprice = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(3).Value
                dgvqty = ReceiveOrders2Form.dgvAdjust.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .CommandText = "update store_2_t set  unit_cost = @unit_cost , sales_price = @sales_price, current_qty = current_qty + @current_qty where id = @id"}
                cmd.Parameters.AddWithValue("@unit_cost", SqlDbType.Float).Value = dgvcost.Trim()
                cmd.Parameters.AddWithValue("@sales_price", SqlDbType.Float).Value = dgvprice.Trim()
                cmd.Parameters.AddWithValue("@current_qty", SqlDbType.Float).Value = dgvqty.Trim()
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = dgvID.Trim()
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

        ReceiveOrders2Form.Close()
        Stock2ListForm.btnrecorder.PerformClick()

        'InsertReceiveNew()

    End Sub

    Public Sub GetStockHistory()

        Try

            Stock2HistoryForm.dgvHistory.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetStock2History", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            Stock2HistoryForm.dgvHistory.DataSource = SourceDataSet.Tables(0)

            ' Make the grid read-only.
            Stock2HistoryForm.GridView1.OptionsBehavior.Editable = False
            ' Prevent the focused cell from being highlighted.
            Stock2HistoryForm.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            ' Draw a dotted focus rectangle around the entire row.
            Stock2HistoryForm.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus

        Catch ex As Exception

        End Try

    End Sub

End Class

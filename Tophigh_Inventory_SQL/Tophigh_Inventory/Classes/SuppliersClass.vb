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

Public Class SuppliersClass

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
                EnterSuppliersBillForm.txtRef.Text = number
            Else
                number = cmd.ExecuteScalar + 1
                EnterSuppliersBillForm.txtRef.Text = number
            End If

            cmd.Dispose()
            conString.Close()
            conString.Dispose()

        Catch oEX As Exception

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

            EnterSuppliersBillForm.cboSupplier.Properties.Items.Clear()
            EnterSuppliersBillForm.cboSupplier.Properties.Items.Add("")
            EnterSuppliersBillForm.cboSupplier.Properties.Items.AddRange(names.ToArray)

            SearchSupInv.cbosup.Items.Clear()
            SearchSupInv.cbosup.Items.Add("")
            SearchSupInv.cbosup.Items.AddRange(names.ToArray)

            PayBillsForm.cboventname.Items.Clear()
            PayBillsForm.cboventname.Items.Add("")
            PayBillsForm.cboventname.Items.AddRange(names.ToArray)

            SuppliersStatementForm.cboCust.Items.Clear()
            SuppliersStatementForm.cboCust.Items.Add("")
            SuppliersStatementForm.cboCust.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupid()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select ID from beneficiary where supplier='{0}'", EnterSuppliersBillForm.cboSupplier.Text.Trim), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                EnterSuppliersBillForm.txtsupid.Text = dr.Item("ID")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCustInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='{1}'", EnterSuppliersBillForm.txtsupid.Text, EnterSuppliersBillForm.cboSupplier.Text), .Connection = conString}

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

                EnterSuppliersBillForm.txtAddress.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetCustInfoSch()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='{1}'", SearchSupInv.txtcustid.Text, SearchSupInv.cbosup.Text), .Connection = conString}

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

                SearchSupInv.txtcust.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub


    Public Sub LoadBillsView()

        Try

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("select * from coa_v where coa_sub_group='EXP'", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 

            dtInvoice.Columns.Add("Description".ToString, GetType(String))
            dtInvoice.Columns.Add("Amount".ToString, GetType(String))

            EnterSuppliersBillForm.dgvBills.ReadOnly = False
            EnterSuppliersBillForm.dgvBills.DataSource = dtInvoice
            EnterSuppliersBillForm.dgvBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            Dim stu As New DataGridViewComboBoxColumn()
            stu.HeaderText = "Accounts"
            stu.Name = "stu"
            stu.FlatStyle = FlatStyle.Standard
            stu.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox
            stu.AutoComplete = AutoCompleteMode.Suggest
            stu.AutoComplete = AutoCompleteSource.ListItems
            stu.DisplayMember = "Accounts"
            stu.ValueMember = "Accounts"
            stu.DataSource = SourceDataSet.Tables(0)

            EnterSuppliersBillForm.dgvBills.Columns.Insert(0, stu)

            EnterSuppliersBillForm.dgvBills.ForeColor = Color.Black

            EnterSuppliersBillForm.dgvBills.Columns(0).Width = 200
            EnterSuppliersBillForm.dgvBills.Columns(1).Width = 300
            EnterSuppliersBillForm.dgvBills.Columns(2).Width = 152

            EnterSuppliersBillForm.dgvBills.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            EnterSuppliersBillForm.dgvBills.DefaultCellStyle.SelectionForeColor = Color.Black
            EnterSuppliersBillForm.dgvBills.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            EnterSuppliersBillForm.dgvBills.AllowUserToResizeColumns = False
            EnterSuppliersBillForm.dgvBills.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            EnterSuppliersBillForm.dgvBills.AlternatingRowsDefaultCellStyle.BackColor = Color.White

            EnterSuppliersBillForm.dgvBills.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            EnterSuppliersBillForm.dgvBills.Columns(2).DefaultCellStyle.Format = "n2"

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Calgrid()

        Try


            Dim totalSum As Double

            For i As Double = 0 To EnterSuppliersBillForm.dgvBills.Rows.Count - 1
                totalSum += EnterSuppliersBillForm.dgvBills.Rows(i).Cells("Amount").Value
            Next i

            EnterSuppliersBillForm.txtAmount.Text = totalSum.ToString("n2")

            EnterSuppliersBillForm.dgvBills.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            EnterSuppliersBillForm.dgvBills.Columns(2).DefaultCellStyle.Format = "n2"

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetAPayable()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "Select coa_name from chart_of_account_t Where coa_cogm='ap'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                EnterSuppliersBillForm.txtApAcc.Text = dr.Item("coa_name")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub InsertExpenseBill()

        Try

            Dim dgvAcc, dgvAmt As String

            For i As Integer = 0 To EnterSuppliersBillForm.dgvBills.Rows.Count

                dgvAcc = EnterSuppliersBillForm.dgvBills.Rows(i).Cells(0).Value
                dgvAmt = EnterSuppliersBillForm.dgvBills.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = EnterSuppliersBillForm.dtBillDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = dgvAcc.Trim()
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvAmt.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txttime.Text
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

        InsertPayableBill()

    End Sub

    Public Sub InsertPayableBill()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
            cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
            cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = EnterSuppliersBillForm.dtBillDate.Text
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txtApAcc.Text.Trim()
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = EnterSuppliersBillForm.txtAmount.Text
            cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txttime.Text
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

        EnterSuppliersBillForm.Close()
        EnterSuppliersBillForm.Dispose()

        MainForm.btnCreateBills.PerformClick()

    End Sub

    Public Sub Insertexpbill()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertAPBill"}
            cmd.Parameters.Add("@cust_id", SqlDbType.Int).Value = EnterSuppliersBillForm.txtsupid.Text
            cmd.Parameters.Add("@ent_date", SqlDbType.Date).Value = EnterSuppliersBillForm.dtBillDate.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = EnterSuppliersBillForm.txtAmount.Text
            cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = "Unpaid"
            cmd.Parameters.Add("@timer", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txttime.Text
            cmd.Parameters.Add("@bal_due", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = EnterSuppliersBillForm.cboSupplier.Text
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

    Public Sub Insertdebitstat()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertDebitStatemnt"}
            cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = EnterSuppliersBillForm.dtBillDate.Text
            cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txtMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = EnterSuppliersBillForm.txtAmount.Text
            cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = EnterSuppliersBillForm.cboSupplier.Text
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

        Catch oex As Exception

        End Try

    End Sub

    Public Sub InsertSupInv()

        Try

            EnterSuppliersBillForm.dgvBills.AllowUserToAddRows = False

            Dim dgvAcc, dgvdesc, dgvAmt As String

            For i As Integer = 0 To EnterSuppliersBillForm.dgvBills.Rows.Count

                dgvAcc = EnterSuppliersBillForm.dgvBills.Rows(i).Cells(0).Value
                dgvdesc = EnterSuppliersBillForm.dgvBills.Rows(i).Cells(1).Value
                dgvAmt = EnterSuppliersBillForm.dgvBills.Rows(i).Cells(2).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertSupInv"}
                cmd.Parameters.Add("@stcode", SqlDbType.Int).Value = EnterSuppliersBillForm.txtRef.Text
                cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = EnterSuppliersBillForm.dtBillDate.Text
                cmd.Parameters.Add("@duedate", SqlDbType.VarChar).Value = EnterSuppliersBillForm.dtDueDate.Text
                cmd.Parameters.Add("@terms", SqlDbType.VarChar).Value = EnterSuppliersBillForm.cboTerms.Text
                cmd.Parameters.Add("@items", SqlDbType.VarChar).Value = dgvAcc.Trim
                cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = dgvdesc.Trim
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvAmt.Trim()
                cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = EnterSuppliersBillForm.cboSupplier.Text
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                cmd.Parameters.Add("@inwords", SqlDbType.VarChar).Value = EnterSuppliersBillForm.txtinwords.Text
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

        PrintDirectInvoice()

    End Sub

    Public Sub RefreshData()

        Try

            EnterSuppliersBillForm.cboSupplier.Text = ""
            EnterSuppliersBillForm.cboTerms.Text = ""
            EnterSuppliersBillForm.txtRef.Text = ""
            EnterSuppliersBillForm.txtAddress.Text = ""
            EnterSuppliersBillForm.txtAmount.Text = "0.00"
            EnterSuppliersBillForm.txtMemo.Text = ""
            dtInvoice.Rows.Clear()
            FillBookNo()
            LoadBillsView()

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

                EnterSuppliersBillForm.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SearchSupInv.txtcomp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web
                SuppliersStatementForm.txtComp.Text = Comp + Environment.NewLine + strt + Environment.NewLine + cty + "," + "" + cunt + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

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
            Dim cmd As SqlCommand = New SqlCommand("GetSupInvbyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@stcode", SqlDbType.Int).Value = EnterSuppliersBillForm.txtRef.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsSupInv As New DataSet

                        sda.Fill(dsSupInv, "GetSupInvbyID")

                        Dim report As New SupplierInvoice
                        report.DataSource = dsSupInv
                        report.DataMember = "supinv"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = EnterSuppliersBillForm.txtcomp.Text
                        report.Parameters("pCust").Value = EnterSuppliersBillForm.txtAddress.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("pComp").Visible = False
                        report.Parameters("pCust").Visible = False

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

    Public Sub GetSupBillsbyID()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSupInvbyID")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@stcode", SqlDbType.Int).Value = SearchSupInv.txtbillid.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsSupInv As New DataSet

                        sda.Fill(dsSupInv, "GetSupInvbyID")

                        Dim report As New SupplierInvoice
                        report.DataSource = dsSupInv
                        report.DataMember = "supinv"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = SearchSupInv.txtcomp.Text
                        report.Parameters("pCust").Value = SearchSupInv.txtcust.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("pComp").Visible = False
                        report.Parameters("pCust").Visible = False

                        ' Create report document.

                        report.CreateDocument()
                        SearchSupInv.SupViewer.DocumentSource = report
                        SearchSupInv.SupViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupBillsbyDate()

        Try

            Dim instance As New Printing.PrinterSettings
            Dim DefaultPrinter As String = instance.PrinterName

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSupInvbyDate")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = SearchSupInv.dtDate.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsSupInv As New DataSet

                        sda.Fill(dsSupInv, "GetSupInvbyDate")

                        Dim report As New SupplierInvoice
                        report.DataSource = dsSupInv
                        report.DataMember = "supinv"
                        ' Obtain a parameter, and set its value.
                        report.Parameters("pComp").Value = SearchSupInv.txtcomp.Text
                        report.Parameters("pCust").Value = SearchSupInv.txtcust.Text
                        ' Hide the Parameters UI from end-users.
                        report.Parameters("pComp").Visible = False
                        report.Parameters("pCust").Visible = False

                        ' Create report document.

                        report.CreateDocument()
                        SearchSupInv.SupViewer.DocumentSource = report
                        SearchSupInv.SupViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupidsch()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select ID from beneficiary where supplier='{0}'", SearchSupInv.cbosup.Text.Trim), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                SearchSupInv.txtcustid.Text = dr.Item("ID")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadPayBills()

        Try
            If (Not PayBillsForm.txtID.Text Is Nothing AndAlso String.IsNullOrEmpty(PayBillsForm.txtID.Text)) Then
                Try

                    PayBillsForm.dgvPayBill.Columns.Clear()

                    Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim sql As String = String.Format(CultureInfo.CurrentCulture, "SELECT bill_id AS ID,ent_date AS Date,credit AS [Orig.Amt],SUM(credit - debit) AS [Amt.Due],bal_due AS Payment FROM expense_bills_t WHERE cust_id = '{0}' AND cust_name = '{1}' AND (debit < credit) GROUP BY bill_id, ent_date, credit, bal_due", PayBillsForm.txtID.Text, PayBillsForm.cboventname.Text)
                    Dim connection As New SqlConnection(connectionString)
                    connection.Open()
                    sCommand = New SqlCommand(sql, connection)
                    sAdapter = New SqlDataAdapter(sCommand)
                    sBuilder = New SqlCommandBuilder(sAdapter)
                    sDs = New DataSet()
                    sAdapter.Fill(sDs, "expense_bills_t")
                    sTable = sDs.Tables("expense_bills_t")
                    connection.Close()
                    PayBillsForm.dgvPayBill.DataSource = sDs.Tables("expense_bills_t")

                    Dim chk As New DataGridViewCheckBoxColumn()
                    chk.HeaderText = "Check Data"
                    chk.Name = "chk"

                    PayBillsForm.dgvPayBill.Columns.Insert(0, chk)

                    PayBillsForm.dgvPayBill.Columns(3).DefaultCellStyle.Format = ("n2")
                    PayBillsForm.dgvPayBill.Columns(4).DefaultCellStyle.Format = ("n2")
                    PayBillsForm.dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

                    PayBillsForm.dgvPayBill.Columns(0).Width = 68
                    PayBillsForm.dgvPayBill.Columns(1).Width = 50
                    PayBillsForm.dgvPayBill.Columns(2).Width = 90
                    PayBillsForm.dgvPayBill.Columns(3).Width = 128
                    PayBillsForm.dgvPayBill.Columns(4).Width = 140
                    PayBillsForm.dgvPayBill.Columns(5).Width = 140

                Catch ex As Exception

                End Try
            Else
                Try

                    PayBillsForm.dgvPayBill.Columns.Clear()

                    Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim sql As String = String.Format(CultureInfo.CurrentCulture, "SELECT bill_id AS ID, ent_date AS Date, credit AS [Orig.Amt],SUM(credit - debit) AS [Amt.Due], bal_due AS Payment FROM expense_bills_t WHERE cust_id = '{0}' AND cust_name = '{1}' AND (debit < credit) GROUP BY bill_id, ent_date, credit, bal_due", PayBillsForm.txtID.Text, PayBillsForm.cboventname.Text)
                    Dim connection As New SqlConnection(connectionString)
                    connection.Open()
                    sCommand = New SqlCommand(sql, connection)
                    sAdapter = New SqlDataAdapter(sCommand)
                    sBuilder = New SqlCommandBuilder(sAdapter)
                    sDs = New DataSet()
                    sAdapter.Fill(sDs, "expense_bills_t")
                    sTable = sDs.Tables("expense_bills_t")
                    connection.Close()
                    PayBillsForm.dgvPayBill.DataSource = sDs.Tables("expense_bills_t")


                    Dim chk As New DataGridViewCheckBoxColumn()
                    chk.HeaderText = "Check Data"
                    chk.Name = "chk"

                    PayBillsForm.dgvPayBill.Columns.Insert(0, chk)

                    PayBillsForm.dgvPayBill.Columns(3).DefaultCellStyle.Format = ("n2")
                    PayBillsForm.dgvPayBill.Columns(4).DefaultCellStyle.Format = ("n2")
                    PayBillsForm.dgvPayBill.Columns(5).DefaultCellStyle.Format = ("n2")

                    PayBillsForm.dgvPayBill.Columns(0).Width = 68
                    PayBillsForm.dgvPayBill.Columns(1).Width = 50
                    PayBillsForm.dgvPayBill.Columns(2).Width = 90
                    PayBillsForm.dgvPayBill.Columns(3).Width = 128
                    PayBillsForm.dgvPayBill.Columns(4).Width = 132
                    PayBillsForm.dgvPayBill.Columns(5).Width = 132

                    Try

                        For i As Integer = 0 To PayBillsForm.dgvPayBill.Rows.Count - 1
                            PayBillsForm.dgvPayBill.Rows(i).Cells("Payment").Value = "0.00"
                        Next

                    Catch ex As Exception

                    End Try

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetAccount()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select Accounts from coa_v", conn) With {.CommandTimeout = 60}
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

            PayBillsForm.cboAccount.Items.Clear()
            PayBillsForm.cboAccount.Items.Add("")
            PayBillsForm.cboAccount.Items.AddRange(names.ToArray)

        Catch ex As System.Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub FillAPs()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_name from chart_of_account_t where coa_cogm='ap'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                PayBillsForm.cboPayAccount.Text = dr.Item("coa_name")

                dr.Close()

            End If

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

            PayBillsForm.cboFilter.Items.Clear()
            PayBillsForm.cboFilter.Items.Add("")
            PayBillsForm.cboFilter.Items.AddRange(names.ToArray)

            SuppliersStatementForm.cboCust.Items.Clear()
            SuppliersStatementForm.cboCust.Items.Add("")
            SuppliersStatementForm.cboCust.Items.AddRange(names.ToArray)

        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub Getpayventid()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT ID from beneficiary WHERE supplier = '{0}'", PayBillsForm.cboventname.Text), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                PayBillsForm.txtID.Text = sdr.Item("ID")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getpaycusttid()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT ID from customer_v WHERE supplier = '{0}'", PayBillsForm.cboFilter.Text), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                PayBillsForm.txtID.Text = sdr.Item("ID")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Function TotalPayAmt() As Double

        Dim tot As Double = 0
        Dim i As Integer = 0
        For i = 0 To PayBillsForm.dgvPayBill.Rows.Count - 1
            tot = tot + Convert.ToDouble(PayBillsForm.dgvPayBill.Rows(i).Cells("Payment").Value)
        Next i
        Return tot

    End Function

    Public Function TotalPayAmtDue() As Double

        Dim tot As Double = 0
        Dim i As Integer = 0
        For i = 0 To PayBillsForm.dgvPayBill.Rows.Count - 1
            tot = tot + Convert.ToDouble(PayBillsForm.dgvPayBill.Rows(i).Cells("Amt.Due").Value)
        Next i
        Return tot

    End Function

    Public Sub GetSum()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select sum(debit - credit) As Total  from journal_voucher_t Where coa_name='{0}'", PayBillsForm.cboAccount.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                PayBillsForm.mBal.Text = dr.Item("Total")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub UpdateAPBills()

        Try

            PayBillsForm.dgvPayBill.AllowUserToAddRows = False

            Dim dgvID, dgvPro As String

            For i As Integer = 0 To PayBillsForm.dgvPayBill.Rows.Count

                dgvID = PayBillsForm.dgvPayBill.Rows(i).Cells(1).Value
                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateAPBills"}
                cmd.Parameters.AddWithValue("@bill_id", SqlDbType.Int).Value = dgvID.Trim()
                cmd.Parameters.AddWithValue("@debit", SqlDbType.Float).Value = dgvPro.Trim()
                cmd.Parameters.AddWithValue("@bill_status", SqlDbType.VarChar).Value = PayBillsForm.cbopaystat.Text.Trim()
                cmd.Parameters.AddWithValue("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text.Trim()
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

        CheckPayableBills()

        InsertDebitPayStatement()

        'insert cash on hand
        InsertAPjvAcc()

    End Sub

    Public Sub CheckPayableBills()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * from expense_bills_t WHERE  credit = debit"), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                UpdateAPBillsStatus()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdateAPBillsStatus()

        Try

            PayBillsForm.dgvPayBill.AllowUserToAddRows = False

            Dim dgvID, dgvPro As String

            For i As Integer = 0 To PayBillsForm.dgvPayBill.Rows.Count

                dgvID = PayBillsForm.dgvPayBill.Rows(i).Cells(2).Value
                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateAPBillsStatus"}
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvID.Trim()
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvPro.Trim()
                cmd.Parameters.Add("@bill_status", SqlDbType.VarChar).Value = PayBillsForm.lblpid.Text.Trim()
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

    Public Sub InsertDebitPayStatement()

        Try

            Dim dgvPro As String

            Dim TotalRecords As Integer = PayBillsForm.dgvPayBill.RowCount - 1

            For i As Integer = 0 To TotalRecords


                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(5).Value

                If PayBillsForm.dgvPayBill.Rows(i).Cells(0).Value = True Then

                    Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertDebitStatemnt"}
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = PayBillsForm.DueBeforeDate.Text
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = PayBillsForm.mMemo.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvPro * -1
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = PayBillsForm.cboventname.Text
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

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertDebitPayCustStatement()

        Try


            Dim dgvPro As String

            Dim TotalRecords As Integer = PayBillsForm.dgvPayBill.RowCount - 1

            For i As Integer = 0 To TotalRecords


                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(5).Value

                If PayBillsForm.dgvPayBill.Rows(i).Cells(0).Value = True Then

                    Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                    Dim cnn As SqlConnection = New SqlConnection(connetionString)
                    Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertDebitStatemnt"}
                    cmd.Parameters.Add("@st_date", SqlDbType.Date).Value = PayBillsForm.DueBeforeDate.Text
                    cmd.Parameters.Add("@description", SqlDbType.VarChar).Value = PayBillsForm.mMemo.Text
                    cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                    cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvPro * -1
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = PayBillsForm.cboFilter.Text
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

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertAPjvAcc()

        Try

            Dim dgvID, dgvPro, dgvDes As String

            For i As Integer = 0 To PayBillsForm.dgvPayBill.Rows.Count

                dgvID = PayBillsForm.dgvPayBill.Rows(i).Cells(0).Value
                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(1).Value
                dgvDes = PayBillsForm.dgvPayBill.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = PayBillsForm.PayDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = PayBillsForm.cboPayAccount.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = dgvDes.Trim()
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = PayBillsForm.lbltimer.Text
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


        'insert A/P
        InsertPayFromAcc()

    End Sub

    Public Sub InsertPayFromAcc()

        Try

            Dim dgvID, dgvPro, dgvDes As String

            For i As Integer = 0 To PayBillsForm.dgvPayBill.Rows.Count

                dgvID = PayBillsForm.dgvPayBill.Rows(i).Cells(0).Value
                dgvPro = PayBillsForm.dgvPayBill.Rows(i).Cells(1).Value
                dgvDes = PayBillsForm.dgvPayBill.Rows(i).Cells(5).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insert_Journal"}
                cmd.Parameters.Add("@cash_code", SqlDbType.Int).Value = "0"
                cmd.Parameters.Add("@jv_date", SqlDbType.Date).Value = PayBillsForm.PayDate.Text
                cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = PayBillsForm.cboAccount.Text
                cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
                cmd.Parameters.Add("@credit", SqlDbType.Float).Value = dgvDes.Trim()
                cmd.Parameters.Add("@ent_time", SqlDbType.VarChar).Value = PayBillsForm.lbltimer.Text
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

        PayBillsForm.Close()
        PayBillsForm.Dispose()

        MainForm.btnpaybills.PerformClick()

    End Sub

    Public Sub DebCustStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSupStatement")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = SuppliersStatementForm.txtCust.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsDebitStatement As New DataSet

                        sda.Fill(dsDebitStatement, "GetSupStatement")

                        Dim report As New DebitStatement
                        report.DataSource = dsDebitStatement
                        report.DataMember = "CreditStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SuppliersStatementForm.txtComp.Text
                        report.pCust.Value = SuppliersStatementForm.txtCust.Text
                        report.pCustAdd.Value = SuppliersStatementForm.txtCustAdd.Text

                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pCustAdd.Visible = False

                        report.CreateDocument()
                        SuppliersStatementForm.CustStateViewer.DocumentSource = report
                        SuppliersStatementForm.CustStateViewer.Refresh()

                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetCustdebInfo()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select supplier,contactperson,office_add,mobile,email_add,website from beneficiary Where id='{0}' AND supplier='{1}'", SuppliersStatementForm.txtNum.Text, SuppliersStatementForm.txtCust.Text), .Connection = conString}

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

                SuppliersStatementForm.txtCustAdd.Text = Comp + Environment.NewLine + FName + Environment.NewLine + LName + Environment.NewLine + WorkFon + Environment.NewLine + email + Environment.NewLine + web

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub SearchDebCustStatement()

        Try

            Dim conString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand("GetSupStatement")
            cmd.CommandType = CommandType.StoredProcedure
            Using con As SqlConnection = New SqlConnection(conString)
                Using sda As SqlDataAdapter = New SqlDataAdapter()
                    cmd.Connection = con
                    cmd.Parameters.Add("@cust_name", SqlDbType.VarChar).Value = SuppliersStatementForm.txtCust.Text
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
                    sda.SelectCommand = cmd
                    Using dsDebitStatement As New DataSet

                        sda.Fill(dsDebitStatement, "GetSupStatement")

                        Dim report As New DebitStatement
                        report.DataSource = dsDebitStatement
                        report.DataMember = "CreditStatement"
                        ' Obtain a parameter, and set its value.
                        report.pComp.Value = SuppliersStatementForm.txtComp.Text
                        report.pCust.Value = SuppliersStatementForm.txtCust.Text
                        report.pCustAdd.Value = SuppliersStatementForm.txtCustAdd.Text

                        ' Hide the Parameters UI from end-users.
                        report.pComp.Visible = False
                        report.pCust.Visible = False
                        report.pCustAdd.Visible = False

                        report.CreateDocument()
                        SuppliersStatementForm.CustStateViewer.DocumentSource = report
                        SuppliersStatementForm.CustStateViewer.Refresh()


                    End Using
                End Using
            End Using

        Catch ex As Exception

        End Try


    End Sub

    Public Sub GetCustID()

        Try

            Dim con As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT ID from beneficiary WHERE supplier = '{0}'", SuppliersStatementForm.cboCust.Text), con)
            con.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                SuppliersStatementForm.txtNum.Text = sdr.Item("ID")

            End If

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

    Public Sub bankNumAcc()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select accnum,bank from bank_t where accname='" & PayBillsForm.cboAccount.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                PayBillsForm.txtAcNum.Text = dr.Item("accnum")
                PayBillsForm.txtbank.Text = dr.Item("bank")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub GetBank()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = "select coa_cogm from chart_of_account_t where coa_name='" & PayBillsForm.cboAccount.Text & "'", .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                PayBillsForm.txtcheckbank.Text = dr.Item("coa_cogm")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub InsertBank()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertbank"}
            cmd.Parameters.Add("@depdate", SqlDbType.Date).Value = PayBillsForm.PayDate.Text
            cmd.Parameters.Add("@accname", SqlDbType.VarChar).Value = PayBillsForm.cboAccount.Text
            cmd.Parameters.Add("@accnum", SqlDbType.VarChar).Value = PayBillsForm.txtAcNum.Text
            cmd.Parameters.Add("@details", SqlDbType.VarChar).Value = PayBillsForm.mMemo.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = PayBillsForm.lbltotal.Text
            cmd.Parameters.Add("@bank", SqlDbType.VarChar).Value = PayBillsForm.txtbank.Text
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

    Public Sub autogenerate_ID()

        Try

            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
                con.Open()
                Dim cmd = New SqlCommand("Select Max(cust_code) from supplier_t", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "SUP000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "SUP" + curValue.ToString("D3")
                SuppliersForm.txtcode.Text = result

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub checkcust()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckSup"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersForm.txtgcode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                UpdateCustomer()

            Else

                InsertCustomer()

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCustomer()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertsuppliers"}
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersForm.txtcode.Text
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = SuppliersForm.txtfname.Text
            cmd.Parameters.Add("@mid_name", SqlDbType.VarChar).Value = SuppliersForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = SuppliersForm.txtlname.Text
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = SuppliersForm.cbotitle.Text
            cmd.Parameters.Add("@supname", SqlDbType.VarChar).Value = SuppliersForm.txtcomp.Text
            cmd.Parameters.Add("@office_add", SqlDbType.VarChar).Value = SuppliersForm.txtoffadd.Text
            cmd.Parameters.Add("@land_line", SqlDbType.VarChar).Value = SuppliersForm.txttel.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = SuppliersForm.txtmobile.Text
            cmd.Parameters.Add("@fax_num", SqlDbType.VarChar).Value = SuppliersForm.txtfax.Text
            cmd.Parameters.Add("@email_add", SqlDbType.VarChar).Value = SuppliersForm.txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = SuppliersForm.txtweb.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
                ClearData()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdateCustomer()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatesuppliers"}
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = SuppliersForm.txtfname.Text
            cmd.Parameters.Add("@mid_name", SqlDbType.VarChar).Value = SuppliersForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = SuppliersForm.txtlname.Text
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = SuppliersForm.cbotitle.Text
            cmd.Parameters.Add("@supname", SqlDbType.VarChar).Value = SuppliersForm.txtcomp.Text
            cmd.Parameters.Add("@office_add", SqlDbType.VarChar).Value = SuppliersForm.txtoffadd.Text
            cmd.Parameters.Add("@land_line", SqlDbType.VarChar).Value = SuppliersForm.txttel.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = SuppliersForm.txtmobile.Text
            cmd.Parameters.Add("@fax_num", SqlDbType.VarChar).Value = SuppliersForm.txtfax.Text
            cmd.Parameters.Add("@email_add", SqlDbType.VarChar).Value = SuppliersForm.txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = SuppliersForm.txtweb.Text
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersForm.txtcode.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
                ClearData()
            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearData()

        Try
            SuppliersForm.txtcode.Clear()
            SuppliersForm.txtcomp.Clear()
            SuppliersForm.txtemail.Clear()
            SuppliersForm.txtfax.Clear()
            SuppliersForm.txtfname.Clear()
            SuppliersForm.txtlname.Clear()
            SuppliersForm.txtmname.Clear()
            SuppliersForm.txtmobile.Clear()
            SuppliersForm.txtoffadd.Clear()
            SuppliersForm.txttel.Clear()
            SuppliersForm.txtweb.Clear()
            SuppliersForm.txtgcode.Clear()
            SuppliersForm.cbotitle.Text = ""
            autogenerate_ID()

            SuppliersForm.Close()
            SuppliersForm.Dispose()

            MainForm.btnsup.PerformClick()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadSupList()

        Try

            SuppliersListForm.dgvCustList.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetSupList", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            SuppliersListForm.dgvCustList.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckSupData"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersForm.txtgcode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                SuppliersForm.txtcode.Text = dr.Item("cust_code")
                SuppliersForm.txtcomp.Text = dr.Item("supname")
                SuppliersForm.txtfname.Text = dr.Item("fname")
                SuppliersForm.txtlname.Text = dr.Item("lname")
                SuppliersForm.txtmname.Text = dr.Item("mid_name")
                SuppliersForm.cbotitle.Text = dr.Item("title")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupAddData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckSupAddData"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersForm.txtgcode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                SuppliersForm.txtemail.Text = dr.Item("email_add")
                SuppliersForm.txtfax.Text = dr.Item("fax_num")
                SuppliersForm.txtmobile.Text = dr.Item("mobile")
                SuppliersForm.txtoffadd.Text = dr.Item("office_add")
                SuppliersForm.txttel.Text = dr.Item("land_line")
                SuppliersForm.txtweb.Text = dr.Item("website")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub DeleteSup()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromSuppliers"}
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = SuppliersListForm.txtid.Text.Trim()
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

End Class

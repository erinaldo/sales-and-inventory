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

Public Class SettingsClass

    Dim conn As SqlConnection
    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String
    Dim sBuilder As SqlCommandBuilder
    Dim sTable As DataTable

    Public Sub FillUser()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select emp from emp_v group by emp", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("emp").ToString)
            End While
            rd.Close()
            conn.Close()

            UsersForm.cbouser.Items.Clear()
            UsersForm.cbouser.Items.Add("")
            UsersForm.cbouser.Items.AddRange(names.ToArray)

            LoginForm.cbouser.Items.Clear()
            LoginForm.cbouser.Items.Add("")
            LoginForm.cbouser.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Filllocation()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select location from location_v group by location", conn) With {.CommandTimeout = 60}
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

            UsersForm.cbolocation.Items.Clear()
            UsersForm.cbolocation.Items.Add("")
            UsersForm.cbolocation.Items.AddRange(names.ToArray)

            LoginForm.cbolocation.Items.Clear()
            LoginForm.cbolocation.Items.Add("")
            LoginForm.cbolocation.Items.AddRange(names.ToArray)


        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCustName()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select emp from emp_v", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("emp").ToString)
            End While
            rd.Close()
            conn.Close()

            UserControlForm.cboUsers.Items.Clear()
            UserControlForm.cboUsers.Items.Add("")
            UserControlForm.cboUsers.Items.AddRange(names.ToArray)
        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try

    End Sub

    Public Sub InsertCate()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertCate"}
            cmd.Parameters.Add("@categories", SqlDbType.VarChar).Value = CategoryForm.txtcate.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

            CategoryForm.txtcate.Clear()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertLocation()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertlocation"}
            cmd.Parameters.Add("@locations", SqlDbType.VarChar).Value = AddLocationForm.txtlocation.Text
            cmd.Parameters.Add("@areas", SqlDbType.VarChar).Value = AddLocationForm.txtarea.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

            AddLocationForm.txtlocation.Clear()
            AddLocationForm.txtarea.Clear()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertUsers()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertUSers"}
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UsersForm.cbouser.Text
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = UsersForm.txtpassword.Text
            cmd.Parameters.Add("@userrole", SqlDbType.VarChar).Value = UsersForm.cborole.Text
            cmd.Parameters.Add("@userlocation", SqlDbType.VarChar).Value = UsersForm.cbolocation.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()
            End Try

            UsersForm.cbouser.Text = ""
            UsersForm.txtpassword.Clear()
            UsersForm.cborole.Text = ""
            UsersForm.cbolocation.Text = ""

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertUserControl()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertusercontrol"}
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = UserControlForm.cboUsers.Text
            cmd.Parameters.Add("@chrt", SqlDbType.VarChar).Value = UserControlForm.txtchart.Text
            cmd.Parameters.Add("@demo", SqlDbType.VarChar).Value = UserControlForm.txtdebitmemo.Text
            cmd.Parameters.Add("@cremo", SqlDbType.VarChar).Value = UserControlForm.txtcreditmemo.Text
            cmd.Parameters.Add("@jent", SqlDbType.VarChar).Value = UserControlForm.txtjuornalentry.Text
            cmd.Parameters.Add("@recpay", SqlDbType.VarChar).Value = UserControlForm.txtrecepay.Text
            cmd.Parameters.Add("@paybill", SqlDbType.VarChar).Value = UserControlForm.txtpaybills.Text
            cmd.Parameters.Add("@bnk", SqlDbType.VarChar).Value = UserControlForm.txtBanking.Text
            cmd.Parameters.Add("@pos", SqlDbType.VarChar).Value = UserControlForm.txtpos.Text
            cmd.Parameters.Add("@csale", SqlDbType.VarChar).Value = UserControlForm.txtSalesInv.Text
            cmd.Parameters.Add("@cstate", SqlDbType.VarChar).Value = UserControlForm.txtcuststatement.Text
            cmd.Parameters.Add("@debrep", SqlDbType.VarChar).Value = UserControlForm.txtdeprep.Text
            cmd.Parameters.Add("@adstoqty", SqlDbType.VarChar).Value = UserControlForm.txtshelfAdjust.Text
            cmd.Parameters.Add("@posord", SqlDbType.VarChar).Value = UserControlForm.txtPO.Text
            cmd.Parameters.Add("@billtac", SqlDbType.VarChar).Value = UserControlForm.txtBillTrck.Text
            cmd.Parameters.Add("@adware", SqlDbType.VarChar).Value = UserControlForm.txtNewWare.Text
            cmd.Parameters.Add("@adstore", SqlDbType.VarChar).Value = UserControlForm.txtNewShelf.Text
            cmd.Parameters.Add("@addef", SqlDbType.VarChar).Value = UserControlForm.txtNewDefect.Text
            cmd.Parameters.Add("@adjuwareqty", SqlDbType.VarChar).Value = UserControlForm.txtAdjustWareQty.Text
            cmd.Parameters.Add("@mcunt", SqlDbType.VarChar).Value = UserControlForm.txtInCount.Text
            cmd.Parameters.Add("@whsales", SqlDbType.VarChar).Value = UserControlForm.txtWCash.Text
            cmd.Parameters.Add("@invtrep", SqlDbType.VarChar).Value = UserControlForm.txtInvVal.Text
            cmd.Parameters.Add("@purep", SqlDbType.VarChar).Value = UserControlForm.txtPayTrack.Text
            cmd.Parameters.Add("@salrep", SqlDbType.VarChar).Value = UserControlForm.txtDailyCashSale.Text
            cmd.Parameters.Add("@finstate", SqlDbType.VarChar).Value = UserControlForm.txtFinState.Text
            cmd.Parameters.Add("@sett", SqlDbType.VarChar).Value = UserControlForm.txtSalesByItem.Text

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

    Public Sub UpdateUserControl()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updateusercontrol"}

            cmd.Parameters.Add("@chrt", SqlDbType.VarChar).Value = UserControlForm.txtchart.Text
            cmd.Parameters.Add("@demo", SqlDbType.VarChar).Value = UserControlForm.txtdebitmemo.Text
            cmd.Parameters.Add("@cremo", SqlDbType.VarChar).Value = UserControlForm.txtcreditmemo.Text
            cmd.Parameters.Add("@jent", SqlDbType.VarChar).Value = UserControlForm.txtjuornalentry.Text
            cmd.Parameters.Add("@recpay", SqlDbType.VarChar).Value = UserControlForm.txtrecepay.Text
            cmd.Parameters.Add("@paybill", SqlDbType.VarChar).Value = UserControlForm.txtpaybills.Text
            cmd.Parameters.Add("@bnk", SqlDbType.VarChar).Value = UserControlForm.txtBanking.Text
            cmd.Parameters.Add("@pos", SqlDbType.VarChar).Value = UserControlForm.txtpos.Text
            cmd.Parameters.Add("@csale", SqlDbType.VarChar).Value = UserControlForm.txtSalesInv.Text
            cmd.Parameters.Add("@cstate", SqlDbType.VarChar).Value = UserControlForm.txtcuststatement.Text
            cmd.Parameters.Add("@debrep", SqlDbType.VarChar).Value = UserControlForm.txtdeprep.Text
            cmd.Parameters.Add("@adstoqty", SqlDbType.VarChar).Value = UserControlForm.txtshelfAdjust.Text
            cmd.Parameters.Add("@posord", SqlDbType.VarChar).Value = UserControlForm.txtPO.Text
            cmd.Parameters.Add("@billtac", SqlDbType.VarChar).Value = UserControlForm.txtBillTrck.Text
            cmd.Parameters.Add("@adware", SqlDbType.VarChar).Value = UserControlForm.txtNewWare.Text
            cmd.Parameters.Add("@adstore", SqlDbType.VarChar).Value = UserControlForm.txtNewShelf.Text
            cmd.Parameters.Add("@addef", SqlDbType.VarChar).Value = UserControlForm.txtNewDefect.Text
            cmd.Parameters.Add("@adjuwareqty", SqlDbType.VarChar).Value = UserControlForm.txtAdjustWareQty.Text
            cmd.Parameters.Add("@mcunt", SqlDbType.VarChar).Value = UserControlForm.txtInCount.Text
            cmd.Parameters.Add("@whsales", SqlDbType.VarChar).Value = UserControlForm.txtWCash.Text
            cmd.Parameters.Add("@invtrep", SqlDbType.VarChar).Value = UserControlForm.txtInvVal.Text
            cmd.Parameters.Add("@purep", SqlDbType.VarChar).Value = UserControlForm.txtPayTrack.Text
            cmd.Parameters.Add("@salrep", SqlDbType.VarChar).Value = UserControlForm.txtDailyCashSale.Text
            cmd.Parameters.Add("@finstate", SqlDbType.VarChar).Value = UserControlForm.txtFinState.Text
            cmd.Parameters.Add("@sett", SqlDbType.VarChar).Value = UserControlForm.txtSalesByItem.Text
            cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = UserControlForm.cboUsers.Text

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

    Public Sub CheckUserControl()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from user_control_t Where [user]='{0}'", UserControlForm.cboUsers.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                UpdateUserControl()

            Else

                InsertUserControl()

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub FillUserControl()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select * from user_control_t Where [user]='{0}'", UserControlForm.cboUsers.Text), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                UserControlForm.txtchart.Text = dr.Item("chrt")
                UserControlForm.txtdebitmemo.Text = dr.Item("demo")
                UserControlForm.txtcreditmemo.Text = dr.Item("cremo")
                UserControlForm.txtjuornalentry.Text = dr.Item("jent")
                UserControlForm.txtrecepay.Text = dr.Item("recpay")
                UserControlForm.txtpaybills.Text = dr.Item("paybill")
                UserControlForm.txtBanking.Text = dr.Item("bnk")
                UserControlForm.txtpos.Text = dr.Item("pos")
                UserControlForm.txtSalesInv.Text = dr.Item("csale")
                UserControlForm.txtcuststatement.Text = dr.Item("cstate")
                UserControlForm.txtdeprep.Text = dr.Item("debrep")
                UserControlForm.txtshelfAdjust.Text = dr.Item("adstoqty")
                UserControlForm.txtPO.Text = dr.Item("posord")
                UserControlForm.txtBillTrck.Text = dr.Item("billtac")
                UserControlForm.txtNewWare.Text = dr.Item("adware")
                UserControlForm.txtNewShelf.Text = dr.Item("adstore")
                UserControlForm.txtNewDefect.Text = dr.Item("addef")
                UserControlForm.txtAdjustWareQty.Text = dr.Item("adjuwareqty")
                UserControlForm.txtInCount.Text = dr.Item("mcunt")
                UserControlForm.txtWCash.Text = dr.Item("whsales")
                UserControlForm.txtInvVal.Text = dr.Item("invtrep")
                UserControlForm.txtPayTrack.Text = dr.Item("purep")
                UserControlForm.txtDailyCashSale.Text = dr.Item("salrep")
                UserControlForm.txtFinState.Text = dr.Item("finstate")
                UserControlForm.txtSalesByItem.Text = dr.Item("sett")

            Else

                UserControlForm.txtchart.Text = "0"
                UserControlForm.txtdebitmemo.Text = "0"
                UserControlForm.txtcreditmemo.Text = "0"
                UserControlForm.txtjuornalentry.Text = "0"
                UserControlForm.txtrecepay.Text = "0"
                UserControlForm.txtpaybills.Text = "0"
                UserControlForm.txtBanking.Text = "0"
                UserControlForm.txtpos.Text = "0"
                UserControlForm.txtSalesInv.Text = "0"
                UserControlForm.txtcuststatement.Text = "0"
                UserControlForm.txtdeprep.Text = "0"
                UserControlForm.txtshelfAdjust.Text = "0"
                UserControlForm.txtPO.Text = "0"
                UserControlForm.txtBillTrck.Text = "0"
                UserControlForm.txtNewWare.Text = "0"
                UserControlForm.txtNewShelf.Text = "0"
                UserControlForm.txtNewDefect.Text = "0"
                UserControlForm.txtAdjustWareQty.Text = "0"
                UserControlForm.txtInCount.Text = "0"
                UserControlForm.txtWCash.Text = "0"
                UserControlForm.txtInvVal.Text = "0"
                UserControlForm.txtPayTrack.Text = "0"
                UserControlForm.txtDailyCashSale.Text = "0"
                UserControlForm.txtFinState.Text = "0"
                UserControlForm.txtSalesByItem.Text = "0"

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub LoginDatabase()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetLogin"}
            'insert product
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = LoginForm.cbouser.Text
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = LoginForm.txtpassword.Text
            cmd.Parameters.Add("@userrole", SqlDbType.VarChar).Value = LoginForm.cborole.Text
            cmd.Parameters.Add("@userlocation", SqlDbType.VarChar).Value = LoginForm.cbolocation.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                UserControlForm.cboUsers.Text = LoginForm.cbouser.Text
                POSForm.txtemp.Text = LoginForm.cbouser.Text
                POSForm.txtposition.Text = LoginForm.cborole.Text
                MainForm.txtlocation.Text = LoginForm.cbolocation.Text
                MainForm.lbllocation.Text = LoginForm.cbolocation.Text
                MainForm.txtrole.Text = LoginForm.cborole.Text
                MainForm.lbluser.Text = LoginForm.cbouser.Text

                MainForm.Show()
                LoginForm.Hide()

            Else

                MsgBox("You don't access to this system")

                LoginForm.Close()
                LoginForm.Dispose()

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

End Class

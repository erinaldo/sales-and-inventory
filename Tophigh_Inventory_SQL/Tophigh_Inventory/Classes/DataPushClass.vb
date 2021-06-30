Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports DevExpress.Data
Imports DevExpress.XtraGrid

Public Class DataPushClass

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable
    Dim dtShelBatch As New DataTable("dtShelBatch")

    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub LoadBatchGridView()

        Try

            dtShelBatch.Columns.Add("ID".ToString, GetType(String))
            dtShelBatch.Columns.Add("Product".ToString, GetType(String))
            dtShelBatch.Columns.Add("Sale Price".ToString, GetType(String))
            dtShelBatch.Columns.Add("Pcs".ToString, GetType(String))
            dtShelBatch.Columns.Add("Order Point".ToString, GetType(String))
            dtShelBatch.Columns.Add("Barcode".ToString, GetType(String))
            dtShelBatch.Columns.Add("Type".ToString, GetType(String))
            dtShelBatch.Columns.Add("Unit".ToString, GetType(String))
            dtShelBatch.Columns.Add("totprice".ToString, GetType(String))

            DataPush.dgvData.ReadOnly = False
            DataPush.dgvData.DataSource = dtShelBatch
            DataPush.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            DataPush.dgvData.Columns(1).Width = 418
            DataPush.dgvData.Columns(2).Width = 100
            DataPush.dgvData.Columns(3).Width = 100
            DataPush.dgvData.Columns(4).Width = 100

            DataPush.dgvData.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            DataPush.dgvData.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataPush.dgvData.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DataPush.dgvData.Columns(0).Visible = False
            DataPush.dgvData.Columns(6).Visible = False
            DataPush.dgvData.Columns(5).Visible = False
            DataPush.dgvData.Columns(7).Visible = False
            DataPush.dgvData.Columns(8).Visible = False

            DataPush.dgvData.ForeColor = Color.Black

            DataPush.dgvData.DefaultCellStyle.SelectionBackColor = Color.AliceBlue
            DataPush.dgvData.DefaultCellStyle.SelectionForeColor = Color.Black
            DataPush.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.[True]
            DataPush.dgvData.AllowUserToResizeColumns = False
            DataPush.dgvData.RowsDefaultCellStyle.BackColor = Color.AliceBlue
            DataPush.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.White

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetBatchData()

        Try

            If DataPush.txtid.Text <> "" AndAlso DataPush.cbodata.Text <> "" AndAlso DataPush.txtsaleprice.Text <> "" AndAlso DataPush.txtpcs.Text <> "" AndAlso DataPush.txtreorder.Text <> "" AndAlso DataPush.txtbarcode.Text <> "" AndAlso DataPush.txttype.Text <> "" AndAlso DataPush.txtucost.Text <> "" Then
                dtShelBatch.Rows.Add(DataPush.txtid.Text, DataPush.cbodata.Text, DataPush.txtsaleprice.Text, DataPush.txtpcs.Text, DataPush.txtreorder.Text, DataPush.txtbarcode.Text, DataPush.txttype.Text, DataPush.txtucost.Text)
            End If

            DataPush.txtid.Text = ""
            DataPush.cbodata.Text = ""
            DataPush.txtsaleprice.Text = ""
            DataPush.txtbarcode.Text = ""
            DataPush.txttype.Text = ""
            DataPush.txtucost.Text = ""

            CalBatchGridData()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalBatchGridData()

        Try

            For j As Integer = 0 To DataPush.dgvData.Rows.Count - 1

                Dim icell2 As Double = DataPush.dgvData.Rows(j).Cells("Sale Price").Value
                Dim icell3 As Double = DataPush.dgvData.Rows(j).Cells("Pcs").Value

                Dim icellResultCost As Double = icell2 * icell3

                DataPush.dgvData.Rows(j).Cells("totprice").Value = icellResultCost.ToString

            Next j


        Catch ex As Exception

        End Try

        Try

            Dim totalSum As Double

            For i As Double = 0 To DataPush.dgvData.Rows.Count - 1
                totalSum += DataPush.dgvData.Rows(i).Cells("totprice").Value
            Next i


            DataPush.txtTotals.Text = totalSum.ToString("n2")


        Catch ex As Exception

        End Try


    End Sub

    Public Sub Checkshelfitems()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("select * from low_stock_v where pro_descrip='" & convertQuotes(DataPush.cbodata.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                Waretoshelve()

            Else

                Waretoshelvebar()

                dr.Close()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Waretoshelve()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetitemslistShelve"}
            'insert product
            cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = DataPush.cbodata.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                DataPush.txtid.Text = dr.Item("pro_id")
                DataPush.txttype.Text = dr.Item("cate")
                DataPush.txtbarcode.Text = dr.Item("bar_code")
                DataPush.txtsaleprice.Text = dr.Item("sales_price")
                DataPush.txtucost.Text = dr.Item("unit_cost")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Waretoshelvebar()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetitemslistbarcodeShelve"}
            'insert product
            cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = DataPush.cbodata.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = MainForm.txtlocation.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                DataPush.txtid.Text = dr.Item("pro_id")
                DataPush.txttype.Text = dr.Item("cate")
                DataPush.txtbarcode.Text = dr.Item("bar_code")
                DataPush.txtsaleprice.Text = dr.Item("sales_price")
                DataPush.txtucost.Text = dr.Item("unit_cost")
                DataPush.cbodata.Text = dr.Item("pro_descrip")

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

            DataPush.cbosource.Properties.Items.Clear()
            DataPush.cbosource.Properties.Items.Add("")
            DataPush.cbosource.Properties.Items.AddRange(names.ToArray)

            DataPush.cbodestination.Properties.Items.Clear()
            DataPush.cbodestination.Properties.Items.Add("")
            DataPush.cbodestination.Properties.Items.AddRange(names.ToArray)

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

            DataPush.cbodata.Properties.Items.Clear()
            DataPush.cbodata.Properties.Items.Add("")
            DataPush.cbodata.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub insertBatchshelvePush()

        Try

            DataPush.dgvData.AllowUserToAddRows = False

            Dim dgvcat, dgvbarcod, dgvpro, dgvsalep, dgvucost, dgvpieces, dgvpoint As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1

                dgvcat = DataPush.dgvData.Rows(i).Cells(6).Value
                dgvbarcod = DataPush.dgvData.Rows(i).Cells(5).Value
                dgvpro = DataPush.dgvData.Rows(i).Cells(1).Value
                dgvsalep = DataPush.dgvData.Rows(i).Cells(2).Value
                dgvucost = DataPush.dgvData.Rows(i).Cells(7).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value
                dgvpoint = DataPush.dgvData.Rows(i).Cells(4).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertShelvePush"}
                cmd.Parameters.Add("@cate", SqlDbType.VarChar).Value = dgvcat.Trim
                cmd.Parameters.Add("@bar_code", SqlDbType.VarChar).Value = dgvbarcod.Trim
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvpro.Trim
                cmd.Parameters.Add("@sales_price", SqlDbType.Float).Value = dgvsalep.Trim
                cmd.Parameters.Add("@unit_cost", SqlDbType.Float).Value = dgvucost.Trim
                cmd.Parameters.Add("@pieces", SqlDbType.Float).Value = dgvpieces.Trim
                cmd.Parameters.Add("@re_point", SqlDbType.Float).Value = dgvpoint.Trim
                cmd.Parameters.Add("@psuh_from", SqlDbType.VarChar).Value = DataPush.cbosource.Text
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DataPush.cbodestination.Text
                cmd.Parameters.Add("@push_status", SqlDbType.VarChar).Value = DataPush.cbostatus.Text
                cmd.Parameters.Add("@qty_rece", SqlDbType.Float).Value = "0"
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

    Public Sub updateBatchshelveSouc()

        Try

            Dim dgvid, dgvpieces As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1

                dgvid = DataPush.dgvData.Rows(i).Cells(0).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelvePush"}
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvpieces.Trim
                cmd.Parameters.Add("@pro_id", SqlDbType.Int).Value = dgvid.Trim
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DataPush.cbosource.Text
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

        DataPush.Close()
        DataPush.Dispose()

        MainForm.btnPushData.PerformClick()

    End Sub

    Public Sub updateBatchshelveDest()

        Try

            Dim dgvid, dgvpieces As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1

                dgvid = DataPush.dgvData.Rows(i).Cells(1).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdatePushShelve"}
                cmd.Parameters.Add("@pro_descrip", SqlDbType.VarChar).Value = dgvid.Trim
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DataPush.cbodestination.Text
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvpieces.Trim
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

    End Sub

    Public Sub insertBatchmovement()

        Try

            Dim dgvbarcod, dgvpro, dgvpieces As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1


                dgvbarcod = DataPush.dgvData.Rows(i).Cells(5).Value
                dgvpro = DataPush.dgvData.Rows(i).Cells(1).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertitemmove"}
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = dgvbarcod.Trim
                cmd.Parameters.Add("@items_description", SqlDbType.VarChar).Value = dgvpro.Trim
                cmd.Parameters.Add("@qty", SqlDbType.Float).Value = dgvpieces.Trim
                cmd.Parameters.Add("@itemfrom", SqlDbType.VarChar).Value = DataPush.cbosource.Text
                cmd.Parameters.Add("@itemto", SqlDbType.VarChar).Value = DataPush.cbodestination.Text
                cmd.Parameters.Add("@move_date", SqlDbType.Date).Value = DataPush.dtDate.Text
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

    Public Sub updateBatchshelveSourReverse()

        Try

            Dim dgvid, dgvpieces As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1

                dgvid = DataPush.dgvData.Rows(i).Cells(0).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "UpdateShelve"}
                cmd.Parameters.Add("@pro_id", SqlDbType.VarChar).Value = dgvid.Trim
                cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DataPush.cbosource.Text
                cmd.Parameters.Add("@adjust_qty", SqlDbType.Float).Value = dgvpieces.Trim
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

        DataPush.Close()
        DataPush.Dispose()

        MainForm.btnPushData.PerformClick()

    End Sub

    Public Sub insertBatchmovementReverse()

        Try

            Dim dgvbarcod, dgvpro, dgvpieces As String

            For i As Integer = 0 To DataPush.dgvData.Rows.Count - 1


                dgvbarcod = DataPush.dgvData.Rows(i).Cells(5).Value
                dgvpro = DataPush.dgvData.Rows(i).Cells(1).Value
                dgvpieces = DataPush.dgvData.Rows(i).Cells(3).Value

                Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
                Dim cnn As SqlConnection = New SqlConnection(connetionString)
                Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertitemmove"}
                cmd.Parameters.Add("@barcode", SqlDbType.VarChar).Value = dgvbarcod.Trim
                cmd.Parameters.Add("@items_description", SqlDbType.VarChar).Value = dgvpro.Trim
                cmd.Parameters.Add("@qty", SqlDbType.Int).Value = dgvpieces * -1
                cmd.Parameters.Add("@itemfrom", SqlDbType.VarChar).Value = DataPush.cbosource.Text
                cmd.Parameters.Add("@itemto", SqlDbType.VarChar).Value = DataPush.cbodestination.Text
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

    Public Sub DeletePush()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromPush"}
            cmd.Parameters.Add("@psuh_from", SqlDbType.VarChar).Value = DataPush.cbosource.Text
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = DataPush.cbodestination.Text
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

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
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class CustomerClass

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
    Public Function convertQuotes(ByVal str As String) As String
        convertQuotes = str.Replace("'", "''")
    End Function

    Public Sub autogenerate_ID()

        Try

            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
                con.Open()
                Dim cmd = New SqlCommand("Select Max(cust_code) from customers_t", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "CUS000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "CUS" + curValue.ToString("D3")
                CustomerForm.txtcode.Text = result

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub checkcust()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckCust"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerForm.txtcode.Text
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

    Public Sub InsertOtherCustomer()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertOthercust"}
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = OtherCustForm.txtfname.Text
            cmd.Parameters.Add("@mid_name", SqlDbType.VarChar).Value = OtherCustForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = OtherCustForm.txtlname.Text
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = OtherCustForm.cbotitle.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = OtherCustForm.txtMobile.Text
            cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = OtherCustForm.txtAdd.Text
            cmd.Connection = cnn

            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception

            Finally

                cnn.Close()
                cnn.Dispose()

                ClearOData()

            End Try

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearOData()

        Try

            OtherCustForm.txtfname.Text = ""
            OtherCustForm.txtmname.Text = ""
            OtherCustForm.txtlname.Text = ""
            OtherCustForm.cbotitle.Text = ""
            OtherCustForm.txtMobile.Text = ""
            OtherCustForm.txtAdd.Text = ""

            OtherCustForm.Close()
            OtherCustForm.Dispose()

            MainForm.btnOcust.PerformClick()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertCustomer()

        Try


            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertcustomers"}
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerForm.txtcode.Text
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = CustomerForm.txtfname.Text
            cmd.Parameters.Add("@mid_name", SqlDbType.VarChar).Value = CustomerForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = CustomerForm.txtlname.Text
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = CustomerForm.cbotitle.Text
            cmd.Parameters.Add("@supname", SqlDbType.VarChar).Value = CustomerForm.txtcomp.Text
            cmd.Parameters.Add("@office_add", SqlDbType.VarChar).Value = CustomerForm.txtoffadd.Text
            cmd.Parameters.Add("@land_line", SqlDbType.VarChar).Value = CustomerForm.txttel.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = CustomerForm.txtmobile.Text
            cmd.Parameters.Add("@fax_num", SqlDbType.VarChar).Value = CustomerForm.txtfax.Text
            cmd.Parameters.Add("@email_add", SqlDbType.VarChar).Value = CustomerForm.txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = CustomerForm.txtweb.Text
            cmd.Parameters.Add("@ssnit_num", SqlDbType.VarChar).Value = CustomerForm.txtssnit.Text
            cmd.Parameters.Add("@nhis_num", SqlDbType.VarChar).Value = CustomerForm.txtnhis.Text
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = CustomerForm.dtdob.Text
            cmd.Parameters.Add("@renew_date", SqlDbType.Date).Value = CustomerForm.dtrenew.Text
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

    Public Sub InsertDependants()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertdependants"}
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = DependantsForm.txtdepid.Text
            cmd.Parameters.Add("@full_name", SqlDbType.VarChar).Value = DependantsForm.txtfname.Text
            cmd.Parameters.Add("@nhis_num", SqlDbType.VarChar).Value = DependantsForm.txtnhis.Text
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = DependantsForm.dtdob.Text
            cmd.Parameters.Add("@renew_date", SqlDbType.Date).Value = DependantsForm.dtrenew.Text

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

        DependantsForm.txtdepid.Text = ""
        DependantsForm.txtfname.Text = ""
        DependantsForm.txtnhis.Text = ""
        DependantsForm.cbodependent.Text = ""

    End Sub

    Public Sub UpdateCustomer()

        Try

            Dim ms As New MemoryStream()
            CustomerForm.custpic.Image.Save(ms, CustomerForm.custpic.Image.RawFormat)
            Dim img As Byte() = ms.ToArray()

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatecustomers"}
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = CustomerForm.txtfname.Text
            cmd.Parameters.Add("@mid_name", SqlDbType.VarChar).Value = CustomerForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = CustomerForm.txtlname.Text
            cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = CustomerForm.cbotitle.Text
            cmd.Parameters.Add("@supname", SqlDbType.VarChar).Value = CustomerForm.txtcomp.Text
            cmd.Parameters.Add("@office_add", SqlDbType.VarChar).Value = CustomerForm.txtoffadd.Text
            cmd.Parameters.Add("@land_line", SqlDbType.VarChar).Value = CustomerForm.txttel.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = CustomerForm.txtmobile.Text
            cmd.Parameters.Add("@fax_num", SqlDbType.VarChar).Value = CustomerForm.txtfax.Text
            cmd.Parameters.Add("@email_add", SqlDbType.VarChar).Value = CustomerForm.txtemail.Text
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = CustomerForm.txtweb.Text
            cmd.Parameters.Add("@cust_pic", SqlDbType.VarBinary).Value = img
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerForm.txtgcode.Text
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
            CustomerForm.txtcode.Clear()
            CustomerForm.txtcomp.Clear()
            CustomerForm.txtemail.Clear()
            CustomerForm.txtfax.Clear()
            CustomerForm.txtfname.Clear()
            CustomerForm.txtlname.Clear()
            CustomerForm.txtmname.Clear()
            CustomerForm.txtmobile.Clear()
            CustomerForm.txtoffadd.Clear()
            CustomerForm.txttel.Clear()
            CustomerForm.txtweb.Clear()
            CustomerForm.cbotitle.Text = ""
            autogenerate_ID()


            CustomerForm.Close()
            CustomerForm.Dispose()

            MainForm.btncusto.PerformClick()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadCustList()

        Try

            CustomerListForm.dgvCustList.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetCustList", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            CustomerListForm.dgvCustList.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub LoadOtherCustList()

        Try

            CustomerListForm.dgvCustList.RefreshDataSource()

            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("GetOtherCustList", Connection)

            ' Create and fill a dataset. 
            Dim SourceDataSet As New DataSet()
            Adapter.Fill(SourceDataSet)

            ' Specify the data source for the grid control. 
            OtherCustListForm.dgvEmpList.DataSource = SourceDataSet.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckcustData"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerForm.txtgcode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                CustomerForm.txtcode.Text = dr.Item("cust_code")
                CustomerForm.txtcomp.Text = dr.Item("supname")
                CustomerForm.txtfname.Text = dr.Item("fname")
                CustomerForm.txtlname.Text = dr.Item("lname")
                CustomerForm.txtmname.Text = dr.Item("mid_name")
                CustomerForm.cbotitle.Text = dr.Item("title")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetSupAddData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckCustAddData"}
            'insert product
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerForm.txtgcode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                CustomerForm.txtemail.Text = dr.Item("email_add")
                CustomerForm.txtfax.Text = dr.Item("fax_num")
                CustomerForm.txtmobile.Text = dr.Item("mobile")
                CustomerForm.txtoffadd.Text = dr.Item("office_add")
                CustomerForm.txttel.Text = dr.Item("land_line")
                CustomerForm.txtweb.Text = dr.Item("website")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub DeleteSup()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromCustomer"}
            cmd.Parameters.Add("@cust_code", SqlDbType.VarChar).Value = CustomerListForm.txtid.Text.Trim()
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

    Public Sub getdependents()

        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
        'create the SqlCommand object and set the sql query
        ''<-- optional
        Dim cmd As New SqlCommand("select contactperson from customer_v", conn) With {.CommandTimeout = 60}
        Dim names As New List(Of String)
        Try
            conn.Open()
            'create the SqlDataReader object to connect to our table
            Dim rd As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            While rd.Read()
                names.Add(rd("contactperson").ToString)
            End While
            rd.Close()
            conn.Close()

            DependantsForm.cbodependent.Items.Clear()
            DependantsForm.cbodependent.Items.Add("")
            DependantsForm.cbodependent.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Getcustid()

        Try
            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("Select `cust id` as id from customer_v Where contactperson='" & convertQuotes(DependantsForm.cbodependent.Text) & "'"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                DependantsForm.txtdepid.Text = dr.Item("id")

                dr.Close()

            End If

        Catch oEX As Exception

        End Try

    End Sub

    Public Sub ExportToPDF()

        'Creating iTextSharp Table from the DataTable data
        Dim pdfTable As New PdfPTable(OtherCustListForm.dgvEmpList.ColumnCount)
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 100
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1

        'Adding Header row
        For Each column As DataGridViewColumn In OtherCustListForm.dgvEmpList.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            pdfTable.AddCell(cell)
        Next

        'Adding DataRow
        For Each row As DataGridViewRow In OtherCustListForm.dgvEmpList.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(cell.Value.ToString())
            Next
        Next

        'Exporting to PDF
        Dim folderPath As String = "C:\Other_Customer_PDFs\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & "Other_Customer_List.pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using

    End Sub

End Class

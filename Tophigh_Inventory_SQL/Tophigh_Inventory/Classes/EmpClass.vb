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
Imports System.Reflection
Imports Excel = Microsoft.Office.Interop.Excel
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class EmpClass

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
    Dim index As Integer

    Shared random As New Random()

    Public Sub empno()

        Try

            Dim curValue As Integer
            Dim result As String
            Using con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
                con.Open()
                Dim cmd = New SqlCommand("Select Max(emp_id) from emp_info_t", con)
                result = cmd.ExecuteScalar().ToString()
                If String.IsNullOrEmpty(result) Then
                    result = "EMP000"
                End If

                result = result.Substring(3)
                Int32.TryParse(result, curValue)
                curValue = curValue + 1
                result = "EMP" + curValue.ToString("D3")
                EmployeesForm.txtempid.Text = result

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertEmp()

        Try

            Dim ms As New MemoryStream()
            EmployeesForm.picguest.Image.Save(ms, EmployeesForm.picguest.Image.RawFormat)
            Dim img As Byte() = ms.ToArray()

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertEmpt"}
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempid.Text
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = EmployeesForm.txtfname.Text
            cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = EmployeesForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = EmployeesForm.txtlname.Text
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = EmployeesForm.dtdob.Text
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = EmployeesForm.cboGender.Text
            cmd.Parameters.Add("@id_type", SqlDbType.VarChar).Value = EmployeesForm.cboidtype.Text
            cmd.Parameters.Add("@id_no", SqlDbType.VarChar).Value = EmployeesForm.txtidno.Text
            cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = EmployeesForm.cbodesignation.Text
            cmd.Parameters.Add("@comments", SqlDbType.VarChar).Value = EmployeesForm.txtcomments.Text
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = img
            cmd.Parameters.Add("@add_1", SqlDbType.VarChar).Value = EmployeesForm.txtadd1.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = EmployeesForm.txtcity.Text
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = EmployeesForm.cbocountry.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = EmployeesForm.txtmobile.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = EmployeesForm.txtemail.Text
            cmd.Parameters.Add("@next_of_kin", SqlDbType.VarChar).Value = EmployeesForm.txtnextofkin.Text
            cmd.Parameters.Add("@bisac_sal", SqlDbType.Float).Value = EmployeesForm.txtbasSal.Text
            cmd.Parameters.Add("@allowances", SqlDbType.Float).Value = EmployeesForm.txtAllowa.Text
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

    Public Sub UpdateEmp()

        Try

            Dim ms As New MemoryStream()
            EmployeesForm.picguest.Image.Save(ms, EmployeesForm.picguest.Image.RawFormat)
            Dim img As Byte() = ms.ToArray()

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updateEmpt"}
            cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = EmployeesForm.txtfname.Text
            cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = EmployeesForm.txtmname.Text
            cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = EmployeesForm.txtlname.Text
            cmd.Parameters.Add("@dob", SqlDbType.Date).Value = EmployeesForm.dtdob.Text
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = EmployeesForm.cboGender.Text
            cmd.Parameters.Add("@id_type", SqlDbType.VarChar).Value = EmployeesForm.cboidtype.Text
            cmd.Parameters.Add("@id_no", SqlDbType.VarChar).Value = EmployeesForm.txtidno.Text
            cmd.Parameters.Add("@designation", SqlDbType.VarChar).Value = EmployeesForm.cbodesignation.Text
            cmd.Parameters.Add("@comments", SqlDbType.VarChar).Value = EmployeesForm.txtcomments.Text
            cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = img
            cmd.Parameters.Add("@add_1", SqlDbType.VarChar).Value = EmployeesForm.txtadd1.Text
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = EmployeesForm.txtcity.Text
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = EmployeesForm.cbocountry.Text
            cmd.Parameters.Add("@mobile", SqlDbType.VarChar).Value = EmployeesForm.txtmobile.Text
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = EmployeesForm.txtemail.Text
            cmd.Parameters.Add("@next_of_kin", SqlDbType.VarChar).Value = EmployeesForm.txtnextofkin.Text
            cmd.Parameters.Add("@bisac_sal", SqlDbType.Float).Value = EmployeesForm.txtbasSal.Text
            cmd.Parameters.Add("@allowances", SqlDbType.Float).Value = EmployeesForm.txtAllowa.Text
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempcheck.Text
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

    Public Sub checkEmp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckEmp"}
            'insert product
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempcheck.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                UpdateEmp()

            Else

                InsertEmp()

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetEmpData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "getEmpSeData"}
            'insert product
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempcheck.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                EmployeesForm.txtempid.Text = dr.Item("emp_id")
                EmployeesForm.txtfname.Text = dr.Item("fname")
                EmployeesForm.txtmname.Text = dr.Item("mname")
                EmployeesForm.txtlname.Text = dr.Item("lname")
                EmployeesForm.cboGender.Text = dr.Item("gender")
                EmployeesForm.cboidtype.Text = dr.Item("id_type")
                EmployeesForm.txtidno.Text = dr.Item("id_no")
                EmployeesForm.cbodesignation.Text = dr.Item("designation")
                EmployeesForm.txtcomments.Text = dr.Item("comments")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetEmpAdd()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "getEmpSeAddData"}
            'insert product
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempcheck.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                EmployeesForm.txtadd1.Text = dr.Item("add_1")
                EmployeesForm.txtcity.Text = dr.Item("city")
                EmployeesForm.cbocountry.Text = dr.Item("country")
                EmployeesForm.txtmobile.Text = dr.Item("mobile")
                EmployeesForm.txtemail.Text = dr.Item("email")
                EmployeesForm.txtnextofkin.Text = dr.Item("next_of_kin")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub GetEmpSal()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "getEmpSeSalData"}
            'insert product
            cmd.Parameters.Add("@emp_id", SqlDbType.VarChar).Value = EmployeesForm.txtempcheck.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                EmployeesForm.txtbasSal.Text = dr.Item("bisac_sal")
                EmployeesForm.txtAllowa.Text = dr.Item("allowances")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ClearData()

        Try

            EmployeesForm.txtempid.Text = ""
            EmployeesForm.txtfname.Text = ""
            EmployeesForm.txtmname.Text = ""
            EmployeesForm.txtlname.Text = ""
            EmployeesForm.cboGender.Text = ""
            EmployeesForm.cboidtype.Text = ""
            EmployeesForm.txtidno.Text = ""
            EmployeesForm.cbodesignation.Text = ""
            EmployeesForm.txtcomments.Text = ""
            EmployeesForm.txtadd1.Text = ""
            EmployeesForm.txtcity.Text = ""
            EmployeesForm.cbocountry.Text = ""
            EmployeesForm.txtmobile.Text = ""
            EmployeesForm.txtemail.Text = ""
            EmployeesForm.txtnextofkin.Text = ""
            EmployeesForm.txtbasSal.Text = ""
            EmployeesForm.txtAllowa.Text = ""
            EmployeesForm.picguest.Image = Tophigh_Inventory.My.Resources.image
            empno()

            EmployeesForm.Close()
            EmployeesForm.Dispose()

            MainForm.btnnewemp.PerformClick()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub loadEmpList()

        EmployeeListForm.dgvEmpList.Columns.Clear()

        Try

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim sql As String = "GetEmpInfo"
            Dim connection As New SqlConnection(connectionString)
            connection.Open()
            sCommand = New SqlCommand(sql, connection)
            sAdapter = New SqlDataAdapter(sCommand)
            sBuilder = New SqlCommandBuilder(sAdapter)
            sDs = New DataSet()
            sAdapter.Fill(sDs, "GetEmpInfo")
            sTable = sDs.Tables("GetEmpInfo")
            connection.Close()
            EmployeeListForm.dgvEmpList.DataSource = sDs.Tables("GetEmpInfo")

        Catch ex As Exception

        End Try

    End Sub

    Public Sub ExportToPDF()

        'Creating iTextSharp Table from the DataTable data
        Dim pdfTable As New PdfPTable(EmployeeListForm.dgvEmpList.ColumnCount)
        pdfTable.DefaultCell.Padding = 3
        pdfTable.WidthPercentage = 100
        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT
        pdfTable.DefaultCell.BorderWidth = 1

        'Adding Header row
        For Each column As DataGridViewColumn In EmployeeListForm.dgvEmpList.Columns
            Dim cell As New PdfPCell(New Phrase(column.HeaderText))
            pdfTable.AddCell(cell)
        Next

        'Adding DataRow
        For Each row As DataGridViewRow In EmployeeListForm.dgvEmpList.Rows
            For Each cell As DataGridViewCell In row.Cells
                pdfTable.AddCell(cell.Value.ToString())
            Next
        Next

        'Exporting to PDF
        Dim folderPath As String = "C:\Emp_List_PDFs\"
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If
        Using stream As New FileStream(folderPath & "Employee_List.pdf", FileMode.Create)
            Dim pdfDoc As New Document(PageSize.A2, 10.0F, 10.0F, 10.0F, 0.0F)
            PdfWriter.GetInstance(pdfDoc, stream)
            pdfDoc.Open()
            pdfDoc.Add(pdfTable)
            pdfDoc.Close()
            stream.Close()
        End Using

    End Sub

End Class

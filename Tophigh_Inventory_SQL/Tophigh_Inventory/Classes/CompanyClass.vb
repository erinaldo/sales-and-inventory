Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports DevExpress.Data
Imports DevExpress.XtraGrid
Public Class CompanyClass

    Dim arrImage() As Byte
    Dim mstream As New System.IO.MemoryStream()

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

            CompanyForm.cbolocation.Properties.Items.Clear()
            CompanyForm.cbolocation.Properties.Items.Add("")
            CompanyForm.cbolocation.Properties.Items.AddRange(names.ToArray)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertComp()

        Try

            Dim connetionString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertcompany"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = CompanyForm.txtcompname.Text.Trim()
            cmd.Parameters.Add("@street", SqlDbType.VarChar).Value = CompanyForm.txtstreet.Text.Trim()
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = CompanyForm.txtcity.Text.Trim()
            cmd.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = CompanyForm.txtzipcode.Text.Trim()
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = CompanyForm.txtcountry.Text.Trim()
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = CompanyForm.txtmobile.Text.Trim()
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = CompanyForm.txtemail.Text.Trim()
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = CompanyForm.txtwebsite.Text.Trim()
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = CompanyForm.cbolocation.Text.Trim()
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()
            Catch oex As Exception

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

        InsertComplogo()

    End Sub

    Public Sub InsertComplogo()

        Dim fs As FileStream
        Dim br As BinaryReader

        Dim FileName As String = CompanyForm.txtfilename.Text
        Dim ImageData() As Byte

        fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
        br = New BinaryReader(fs)
        ImageData = br.ReadBytes(CType(fs.Length, Integer))
        br.Close()
        fs.Close()

        Try

            Dim connetionString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "Insertcomplogo"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = CompanyForm.txtcompname.Text.Trim()
            cmd.Parameters.Add("@comp_logo", SqlDbType.VarBinary).Value = ImageData
            cmd.Connection = cnn
            Try
                cnn.Open()
                Dim RowsAffected As Integer = cmd.ExecuteNonQuery()

            Catch oex As Exception

            Finally
                cnn.Close()
                cnn.Dispose()
            End Try
            ClearData()
        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub ClearData()
        Try

            CompanyForm.txtcity.Text = Nothing
            CompanyForm.txtzipcode.Text = Nothing
            CompanyForm.txtcompname.Text = Nothing
            CompanyForm.txtcountry.Text = Nothing
            CompanyForm.txtstreet.Text = Nothing
            CompanyForm.cbolocation.Text = Nothing
            CompanyForm.txtcountry.Text = Nothing
            CompanyForm.piclogo.Image = Nothing
            CompanyForm.txtmobile.Text = Nothing
            CompanyForm.txtemail.Text = Nothing
            CompanyForm.txtwebsite.Text = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CheckComp()

        Try

            Dim connetionString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As SqlCommand = New SqlCommand(String.Format("SELECT * FROM company_t WHERE  comp_id='{0}'", CompanyForm.txtcompid.Text), cnn)
            cnn.Open()

            Dim sdr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (sdr.Read() = True) Then

                UpdateCompany()

            Else

                InsertComp()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Public Sub UpdateCompany()

        Try

            Dim connetionString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatecompany"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = CompanyForm.txtcompname.Text.Trim()
            cmd.Parameters.Add("@street", SqlDbType.VarChar).Value = CompanyForm.txtstreet.Text.Trim()
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = CompanyForm.txtcity.Text.Trim()
            cmd.Parameters.Add("@zip_code", SqlDbType.VarChar).Value = CompanyForm.txtzipcode.Text.Trim()
            cmd.Parameters.Add("@country", SqlDbType.VarChar).Value = CompanyForm.txtcountry.Text.Trim()
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = CompanyForm.txtmobile.Text.Trim()
            cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = CompanyForm.txtemail.Text.Trim()
            cmd.Parameters.Add("@website", SqlDbType.VarChar).Value = CompanyForm.txtwebsite.Text.Trim()
            cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = CompanyForm.cbolocation.Text.Trim()
            cmd.Parameters.Add("@comp_id", SqlDbType.Int).Value = CompanyForm.txtcompid.Text.Trim()
            cmd.Connection = cnn
            Try
                cnn.Open()
                Dim RowsAffected As Integer = cmd.ExecuteNonQuery()

            Catch oex As Exception
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

        UpdateComplogo()

    End Sub

    Public Sub UpdateComplogo()

        Dim fs As FileStream
        Dim br As BinaryReader

        Dim FileName As String = CompanyForm.txtfilename.Text
        Dim ImageData() As Byte

        fs = New FileStream(FileName, FileMode.Open, FileAccess.Read)
        br = New BinaryReader(fs)
        ImageData = br.ReadBytes(CType(fs.Length, Integer))
        br.Close()
        fs.Close()

        Try

            Dim connetionString As String = String.Format(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatecommplogo"}
            cmd.Parameters.Add("@com_name", SqlDbType.VarChar).Value = CompanyForm.txtcompname.Text.Trim()
            cmd.Parameters.Add("@comp_logo", SqlDbType.VarBinary).Value = ImageData
            cmd.Connection = cnn
            Try
                cnn.Open()
                Dim RowsAffected As Integer = cmd.ExecuteNonQuery()

            Catch oex As Exception
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try
            ClearData()
        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub showcomp()

        Try

            Dim conString As New SqlConnection() With {.ConnectionString = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString}

            conString.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("GetCompInfo"), .Connection = conString}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                CompanyForm.txtcompid.Text = dr.Item("comp_id")
                CompanyForm.txtcompname.Text = dr.Item("com_name")
                CompanyForm.txtstreet.Text = dr.Item("street")
                CompanyForm.txtcity.Text = dr.Item("city")
                CompanyForm.txtzipcode.Text = dr.Item("zip_code")
                CompanyForm.txtcountry.Text = dr.Item("country")
                CompanyForm.txtmobile.Text = dr.Item("phone")
                CompanyForm.txtemail.Text = dr.Item("email")
                CompanyForm.txtwebsite.Text = dr.Item("website")
                CompanyForm.cbolocation.Text = dr.Item("location")

                dr.Close()

            End If

        Catch ex As Exception

        End Try

        GetImage()

    End Sub

    Public Sub GetImage()

        Try

            Dim connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)
            Dim command As New SqlCommand(String.Format("SELECT comp_logo FROM company_t WHERE comp_id = '{0}'", CompanyForm.txtcompid.Text.Trim), connection)

            connection.Open()

            Dim pictureData As Byte() = DirectCast(command.ExecuteScalar(), Byte())

            connection.Close()

            Dim picture As Image = Nothing

            'Create a stream in memory containing the bytes that comprise the image.'
            Using stream As New MemoryStream(pictureData)
                'Read the stream and create an Image object from the data.'
                picture = Image.FromStream(stream)
            End Using

            CompanyForm.piclogo.Image = picture

        Catch ex As Exception

        End Try

    End Sub

    Public Sub showcompbyid()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetCompInfobyi"}
            'insert product
            cmd.Parameters.Add("@comp_id", SqlDbType.Int).Value = CompanyForm.txtcompid.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                CompanyForm.txtcompname.Text = dr.Item("com_name")
                CompanyForm.txtstreet.Text = dr.Item("street")
                CompanyForm.txtcity.Text = dr.Item("city")
                CompanyForm.txtzipcode.Text = dr.Item("zip_code")
                CompanyForm.txtcountry.Text = dr.Item("country")
                CompanyForm.txtmobile.Text = dr.Item("phone")
                CompanyForm.txtemail.Text = dr.Item("email")
                CompanyForm.txtwebsite.Text = dr.Item("website")
                CompanyForm.cbolocation.Text = dr.Item("location")
                CompanyForm.txtcompid.Text = dr.Item("comp_id")
                arrImage = dr.Item(“comp_logo”)
                Dim mstream As New System.IO.MemoryStream(arrImage)
                CompanyForm.piclogo.Image = Image.FromStream(mstream)

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class


Imports System.Data.SqlClient
Imports System.Text
Imports System.IO
Imports System.Configuration
Imports System.Globalization
Imports DevExpress.DataAccess.ConnectionParameters
Imports DevExpress.DataAccess.Sql
Imports Microsoft.Office.Interop.Excel
Imports DevExpress.DataAccess
Imports System.Data
Imports System.Reflection
Imports ClosedXML.Excel
Imports DataTable = System.Data.DataTable

Public Class ChartofAccountClass

    Dim cmd As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim itemcoll(100) As String

    Dim sCommand As SqlCommand
    Dim sAdapter As SqlDataAdapter
    Dim sBuilder As SqlCommandBuilder
    Dim sDs As DataSet
    Dim sTable As DataTable


    Public Sub FillCurAssetBox()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbocua.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillRece()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rborc.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillRevBox()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rboinv.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillPreP()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbope.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillFixedA()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbofa.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillAccm()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rboacm.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillCogs()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbocogs.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillPaya()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbopy.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillDetPaya()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbodeb.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillEqu()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rboequ.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillRev()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rborev.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillOpeEx()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rboope.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub FillOthEx()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartGroupings"}
            'insert product
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.rbooex.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CurAssetsCode()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_curass_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Receivables()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_rece_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1200"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Inventories()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_inv_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1300"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub PrepaidEx()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_prexp_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1400"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try


    End Sub

    Public Sub FixedAss()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_fixa_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1500"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub AccMu()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_accum_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "1600"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CogsAc()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_cogs_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "5000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Payables()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_paya_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "2000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub DebtsAc()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_debt_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "2700"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub EquitiesAc()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM acc_equ_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "3000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub RevenuesAc()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_rev_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "4000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub OperatinEX()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_opa_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "6000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub OtherOperatinEX()

        Try

            Dim result As String
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cnn.Open()
            Dim cmd = New SqlCommand("Select MAX(code) FROM coa_opexp_acc_v", cnn)
            result = cmd.ExecuteScalar().ToString()
            If String.IsNullOrEmpty(result) Then
                result = "7000"
                NewChartForm.txtAcCode.Text = result
            Else

                result = result + 2
            End If

            NewChartForm.txtAcCode.Text = result

        Catch ex As Exception

        End Try

    End Sub

    Public Sub CheckAcc()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "CheckCOA"}
            'insert product
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = NewChartForm.txtAcCode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then

                UpdateChartAcct()

            Else

                InsertChartAcct()

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

    Public Sub InsertChartAcct()

        InsertTemp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "InsertchartAcc"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = NewChartForm.txtAcCode.Text.Trim()
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = NewChartForm.txtAcName.Text.Trim()
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.txtAcGroup.Text.Trim()
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = NewChartForm.txtAcSubGroup.Text.Trim()
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = NewChartForm.txtAcCate.Text.Trim()
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = NewChartForm.txtcashtype.Text.Trim()
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = ""
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch oex As Exception
                MsgBox(oex.Message, "Record did not insert error has occur")
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

            NewChartForm.txtAcCode.Text = ""
            NewChartForm.txtAcName.Text = ""
            NewChartForm.txtAcGroup.Text = ""
            NewChartForm.txtAcSubGroup.Text = ""
            NewChartForm.txtAcCate.Text = ""
            NewChartForm.txtcashtype.Text = ""
            NewChartForm.cboFlow.Text = ""

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub InsertTemp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "inserTemp"}
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = NewChartForm.txtAcName.Text
            cmd.Parameters.Add("@debit", SqlDbType.Float).Value = "0"
            cmd.Parameters.Add("@credit", SqlDbType.Float).Value = "0"
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

    Public Sub UpdateChartAcct()

        InsertTemp()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatechartAcc"}
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = NewChartForm.txtAcCode.Text.Trim()
            cmd.Parameters.Add("@coa_name", SqlDbType.VarChar).Value = NewChartForm.txtAcName.Text.Trim()
            cmd.Parameters.Add("@coa_group", SqlDbType.VarChar).Value = NewChartForm.txtAcGroup.Text.Trim()
            cmd.Parameters.Add("@coa_sub_group", SqlDbType.VarChar).Value = NewChartForm.txtAcSubGroup.Text.Trim()
            cmd.Parameters.Add("@coa_cate", SqlDbType.VarChar).Value = NewChartForm.txtAcCate.Text.Trim()
            cmd.Parameters.Add("@coa_cf", SqlDbType.VarChar).Value = NewChartForm.cboFlow.Text.Trim()
            cmd.Parameters.Add("@coa_ocbfy", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@coa_cogm", SqlDbType.VarChar).Value = ""
            cmd.Parameters.Add("@coa_id", SqlDbType.VarChar).Value = NewChartForm.txtid.Text
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()

            Catch oex As Exception
                MsgBox(oex.Message, "Record did not update error has occur")
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

            NewChartForm.txtAcCode.Text = ""
            NewChartForm.txtAcName.Text = ""
            NewChartForm.txtAcGroup.Text = ""
            NewChartForm.txtAcSubGroup.Text = ""
            NewChartForm.txtAcCate.Text = ""
            NewChartForm.txtcashtype.Text = ""
            NewChartForm.cboFlow.Text = ""

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub DeleteCOA()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "DeleteFromCOA"}
            cmd.Parameters.Add("@coa_id", SqlDbType.Int).Value = NewChartForm.txtid.Text.Trim()
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()
                UpdateFiscalYear()
            Catch oex As Exception
                MsgBox(oex.Message, "Record did not delete error has occur")
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub AccountList()

        Try

            ChartofAccountListForm.LvChart.Clear()

            ChartofAccountListForm.LvChart.View = View.Details
            ChartofAccountListForm.LvChart.GridLines = True
            ChartofAccountListForm.LvChart.FullRowSelect = True

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim strQ As String = "GetCOAList"
            cmd = New SqlCommand(strQ, cnn)
            da = New SqlDataAdapter(cmd)
            ds = New DataSet
            da.Fill(ds, "Table")

            Dim i As Integer = 0
            Dim j As Integer = 0

            ' adding the columns in ListView
            For i = 0 To ds.Tables(0).Columns.Count - 1

                ChartofAccountListForm.LvChart.Columns.Add(ds.Tables(0).Columns(i).ColumnName.ToString(CultureInfo.CurrentCulture))

            Next

            'Now adding the Items in Listview
            For i = 0 To ds.Tables(0).Rows.Count - 1

                For j = 0 To ds.Tables(0).Columns.Count - 1

                    itemcoll(j) = ds.Tables(0).Rows(i)(j).ToString()

                Next

                Dim lvi As New ListViewItem(itemcoll)
                ChartofAccountListForm.LvChart.Items.Add(lvi)
                ChartofAccountListForm.LvChart.Columns(0).Width = -0
                ChartofAccountListForm.LvChart.Columns(1).Width = 100
                ChartofAccountListForm.LvChart.Columns(2).Width = 400
                ChartofAccountListForm.LvChart.Columns(3).Width = 400
                ChartofAccountListForm.LvChart.Columns(4).Width = 200

            Next

        Catch Oex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, Oex.Message, Oex.StackTrace))
        End Try

    End Sub

    Public Sub ClearData()
        Try
            NewChartForm.txtAcCode.Clear()
            NewChartForm.txtAcName.Clear()
            NewChartForm.txtAcGroup.Clear()
            NewChartForm.cboFlow.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Public Sub InsertFiscalYear()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "insertfiscalyear"}
            cmd.Parameters.Add("@fis_name", SqlDbType.VarChar).Value = FiscalYearForm.txtYearName.Text.Trim()
            cmd.Parameters.Add("@start_date", SqlDbType.Date).Value = FiscalYearForm.dtStartDate.Text.Trim()
            cmd.Parameters.Add("@end_date", SqlDbType.Date).Value = FiscalYearForm.dtEndDate.Text.Trim()
            cmd.Parameters.Add("@year_status", SqlDbType.VarChar).Value = "Open"
            cmd.Connection = cnn
            Try
                cnn.Open()
                cmd.ExecuteNonQuery()
                UpdateFiscalYear()
                FiscalYearForm.btnCanael.PerformClick()
            Catch oex As Exception
                MsgBox(oex.Message, "Record did not insert error has occur")
            Finally
                cnn.Close()
                cnn.Dispose()
            End Try

        Catch oex As Exception
            Call MsgBox(oex.Message)
        End Try

    End Sub

    Public Sub UpdateFiscalYear()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "updatefiscalyear"}
            cmd.Parameters.Add("@year_status", SqlDbType.VarChar).Value = "Closed"
            cmd.Parameters.Add("@fis_id", SqlDbType.Int).Value = FiscalYearForm.txtID.Text.Trim()
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


    End Sub

    Public Sub GetFiscCode()

        Try

            Dim cmd As New SqlCommand
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            cmd.Connection = cnn
            cnn.Open()

            Dim number As Integer
            cmd.CommandText = "select MAX(fis_id)from fiscal_year_t"

            If IsDBNull(cmd.ExecuteScalar) Then
                number = 0
                FiscalYearForm.txtID.Text = number

            Else
                number = cmd.ExecuteScalar
                FiscalYearForm.txtID.Text = number

            End If
            cmd.Dispose()
            cnn.Close()
            cnn.Dispose()
        Catch ex As Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try


    End Sub

    Public Sub GetEndDate()

        Try
            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)

            cnn.Open()

            Dim cm As New SqlCommand() With {.CommandText = String.Format("SELECT end_date FROM fiscal_year_t WHERE fis_id = '{0}'", FiscalYearForm.txtID.Text), .Connection = cnn}

            Dim dr As SqlDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                FiscalYearForm.dtGetDate.Value = dr.Item("end_date")

                dr.Close()

            End If

        Catch oEX As Exception
            Call MsgBox(oEX.Message)
        End Try

    End Sub

    Public Sub GetChartData()

        Try

            Dim connetionString As String = ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString
            Dim cnn As SqlConnection = New SqlConnection(connetionString)
            Dim cmd As New SqlCommand() With {.CommandType = CommandType.StoredProcedure, .CommandText = "GetChartData"}
            'insert product
            cmd.Parameters.Add("@coa_code", SqlDbType.VarChar).Value = NewChartForm.txtAcCode.Text
            cmd.Connection = cnn
            cnn.Open()

            Dim dr As SqlDataReader = cmd.ExecuteReader()
            ' If the record can be queried, it means passing verification, then open another form.   
            If (dr.Read() = True) Then


                NewChartForm.txtAcName.Text = dr.Item("coa_name")
                NewChartForm.txtAcGroup.Text = dr.Item("coa_group")
                NewChartForm.txtAcSubGroup.Text = dr.Item("coa_sub_group")
                NewChartForm.txtAcCate.Text = dr.Item("coa_cate")
                NewChartForm.txtcashtype.Text = dr.Item("coa_cf")

            End If

            cnn.Close()

        Catch ex As Exception

        End Try

    End Sub

End Class

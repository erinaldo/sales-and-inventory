Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Data.SQLite
Imports DevExpress.XtraGrid

Public Class TestSubsriptionForm

    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private adapter As SQLiteDataAdapter
    Private ds As DataSet = New DataSet()
    Private dt As DataTable = New DataTable()
    Private id As Integer
    Private isDoubleClick As Boolean = False

    Private connectString As String = "Data Source=" & Application.StartupPath & "\syscheck.db"

    Private Sub TestSubsriptionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            sysdate.Value = Date.Now
            GetsubDate()
            LoadAvialStock()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetsubDate()
        Try
            conn = New SQLiteConnection(connectString)
            conn.Open()
            cmd = New SQLiteCommand()
            Dim cm As New SQLiteCommand() With {.CommandText = String.Format("SELECT dateto FROM subscription_t where sub_status ='Subscribed'"), .Connection = conn}

            Dim dr As SQLiteDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                dtto.Text = dr.Item("dateto")

                dr.Close()

            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtto_ValueChanged(sender As Object, e As EventArgs) Handles dtto.ValueChanged
        Try

            If True Then

                Dim dt1 As DateTime = Convert.ToDateTime(sysdate.Text)

                Dim dt2 As DateTime = Convert.ToDateTime(dtto.Text)

                Dim ts As TimeSpan = dt2.Subtract(dt1)

                If Convert.ToInt32(ts.Days) >= 0 Then

                    lbldays.Text = Convert.ToInt32(ts.Days)

                Else

                    MessageBox.Show("Invalid Input")

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadAvialStock()

        Try

            GridControl1.RefreshDataSource()


            ' Create a connection object. 
            Dim Connection As New SqlConnection(ConfigurationManager.ConnectionStrings("dbconnection").ConnectionString)

            ' Create a data adapter. 
            Dim Adapter As New SqlDataAdapter("SELECT TOP(20) items as Product, SUM(qty) AS TotalQuantity,location as Location FROM cash_sales_t GROUP BY items,location ORDER BY SUM(qty) DESC", Connection)

            ' Create and fill a dataset. 
            Dim dsBestPro As New DataSet()
            Adapter.Fill(dsBestPro)

            ' Specify the data source for the grid control. 
            GridControl1.DataSource = dsBestPro.Tables(0)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub
End Class
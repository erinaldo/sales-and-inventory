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

Public Class SubscriptionForm

    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private adapter As SQLiteDataAdapter
    Private ds As DataSet = New DataSet()
    Private dt As DataTable = New DataTable()
    Private id As Integer
    Private isDoubleClick As Boolean = False

    Private connectString As String = "Data Source=" & Application.StartupPath & "\syscheck.db"


    Private Sub SubscriptionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnsubscribe_Click(sender As Object, e As EventArgs) Handles btnsubscribe.Click
        Try

            dtfrom.Format = DateTimePickerFormat.Custom
            dtfrom.CustomFormat = "yyyy-MM-dd"

            dtto.Format = DateTimePickerFormat.Custom
            dtto.CustomFormat = "yyyy-MM-dd"

            conn = New SQLiteConnection(connectString)
            cmd = New SQLiteCommand()
            cmd.CommandText = "INSERT INTO subscription_t (datefrom,dateto,yearint,sub_status) VALUES(@datefrom,@dateto,@yearint,@sub_status)"
            cmd.Connection = conn
            cmd.Parameters.Add(New SQLiteParameter("@datefrom", dtfrom.Text))
            cmd.Parameters.Add(New SQLiteParameter("@dateto", dtto.Text))
            cmd.Parameters.Add(New SQLiteParameter("@yearint", lbldays.Text))
            cmd.Parameters.Add(New SQLiteParameter("@sub_status", cbostatus.Text))
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()

            If i = 1 Then
                MessageBox.Show("Successfully Created!")
                Me.Close()
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtto_ValueChanged(sender As Object, e As EventArgs) Handles dtto.ValueChanged
        Try

            If True Then

                Dim dt1 As DateTime = Convert.ToDateTime(dtfrom.Text)

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

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try

            dtfrom.Format = DateTimePickerFormat.Custom
            dtfrom.CustomFormat = "yyyy-MM-dd"

            dtto.Format = DateTimePickerFormat.Custom
            dtto.CustomFormat = "yyyy-MM-dd"

            conn = New SQLiteConnection(connectString)
            cmd = New SQLiteCommand()
            cmd.CommandText = "Update subscription_t set datefrom = @datefrom,dateto = @dateto,yearint = @yearint where sub_status = @sub_status"
            cmd.Connection = conn
            cmd.Parameters.Add(New SQLiteParameter("@datefrom", dtfrom.Text))
            cmd.Parameters.Add(New SQLiteParameter("@dateto", dtto.Text))
            cmd.Parameters.Add(New SQLiteParameter("@yearint", lbldays.Text))
            cmd.Parameters.Add(New SQLiteParameter("@sub_status", cbostatus.Text))
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()

            If i = 1 Then
                MessageBox.Show("Successfully Update!")
                Me.Close()
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
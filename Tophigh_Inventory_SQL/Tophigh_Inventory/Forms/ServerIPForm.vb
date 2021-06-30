Imports System
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Data.SQLite

Public Class ServerIPForm

    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private adapter As SQLiteDataAdapter
    Private ds As DataSet = New DataSet()
    Private dt As DataTable = New DataTable()
    Private id As Integer
    Private isDoubleClick As Boolean = False

    Private connectString As String = "Data Source=" & Application.StartupPath & "\syscheck.db"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            conn = New SQLiteConnection(connectString)
            cmd = New SQLiteCommand()
            cmd.CommandText = "INSERT INTO connection_t (srv_ip) VALUES(@srv_ip)"
            cmd.Connection = conn
            cmd.Parameters.Add(New SQLiteParameter("@srv_ip", txtipaddress.Text))
            conn.Open()
            Dim i As Integer = cmd.ExecuteNonQuery()

            If i = 1 Then
                MessageBox.Show("Successfully Created!")
                txtipaddress.Text = ""
                StartUpForm.Show()
                StartUpForm.Timer1.Start()
                Me.Close()
                Me.Dispose()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ServerIPForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
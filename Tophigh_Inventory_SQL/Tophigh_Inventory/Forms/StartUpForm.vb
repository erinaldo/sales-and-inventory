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

Public Class StartUpForm

    Public TrialTime As DateTime
    Dim MyDelSync As New DeleteSyncInClass

    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private adapter As SQLiteDataAdapter
    Private ds As DataSet = New DataSet()
    Private dt As DataTable = New DataTable()
    Private id As Integer
    Private isDoubleClick As Boolean = False

    Private connectString As String = "Data Source=" & Application.StartupPath & "\syscheck.db"

    Private Sub StartUpForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblStatus.Text = "System Loading..."
            lblStatus.ForeColor = Color.Red
            Timer1.Start()
            'Process1.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub checkserver()
        Try
            conn = New SQLiteConnection(connectString)
            conn.Open()
            cmd = New SQLiteCommand()
            Dim cm As New SQLiteCommand() With {.CommandText = String.Format("SELECT srv_ip FROM connection_t"), .Connection = conn}

            Dim dr As SQLiteDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                txtserver.Text = dr.Item("srv_ip")

                dr.Close()

            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function IsInternetConnected() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
        End Try
        Return False
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try

            checkserver()

            If txtserver.Text = "" = True Then
                ServerIPForm.Show()
                Me.Hide()
                Timer1.Stop()
                Exit Sub
            End If

            LoginForm.Show()
            Process1.Close()
            Process1.Dispose()
            Timer2.Start()
            Timer1.Stop()
            Me.Hide()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try
            If IsInternetConnected() = True Then
                'BackgroundWorker1.WorkerReportsProgress = True
                'BackgroundWorker1.WorkerSupportsCancellation = True
                'BackgroundWorker1.RunWorkerAsync()
                lblStatus.Text = "Working..."
            Else
                Exit Sub
            End If
        Catch ex As System.Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try

            Timer2.Stop()

            'Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
            'For i As Integer = 1 To 100
            '    'checking to see if you hit the cancel button (need it for safety)

            '    If (worker.CancellationPending = True) Then
            '        e.Cancel = True
            '        Exit For
            '    End If
            '    'Raise the ProgressChanged event in the UI thread. Note the first i is passed to the e.ProgressPercentage later on. The second code i & "iterations complete" passes to the TryCast(e.UserState, String) 

            '    worker.ReportProgress(i, i & " iterations complete")
            '    'Perform some time-consuming operation here.

            '    'MyDelSync.Delete_bank_open_bal_temp_t()

            'Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            Me.ProgressBar1.Value = e.ProgressPercentage
            Me.Label9.Text = TryCast(e.UserState, String)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            'Me.Label9.Text = "Operation complete"
            'BackgroundWorker1.CancelAsync()
            'Timer2.Start()
        Catch ex As Exception

        End Try
    End Sub
End Class
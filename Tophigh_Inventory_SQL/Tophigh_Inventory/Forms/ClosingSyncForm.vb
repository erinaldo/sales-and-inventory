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


Public Class ClosingSyncForm

    Dim MyDelSync As New CloseDeleteSyncInClass

    Private Sub ClosingSyncForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblStatus.Text = "Please Wait System Closing........."
            lblStatus.ForeColor = Color.Red
            Timer2.Start()
        Catch ex As Exception

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

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Try

            SimpleButton1.PerformClick()

            'BackgroundWorker2.WorkerReportsProgress = True
            'BackgroundWorker2.WorkerSupportsCancellation = True
            'BackgroundWorker2.RunWorkerAsync()
            'lblStatus.Text = "Working..."

            Timer2.Stop()

        Catch ex As System.Exception
            MessageBox.Show(String.Format("Error{0}{1}{0}Trace: {0}{2}", vbLf, ex.Message, ex.StackTrace))
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try

            ' Spend 10 seconds doing nothing.
            For i As Integer = 1 To 100
                ' If we should stop, do so.
                If (BackgroundWorker2.CancellationPending) Then
                    ' Indicate that the task was canceled.
                    e.Cancel = True
                    Exit For
                End If


                ' Notify the UI thread of our progress.
                BackgroundWorker2.ReportProgress(i * 1)
            Next i

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Try
            ProgressBar1.Value = e.ProgressPercentage
            Label2.Text = e.ProgressPercentage.ToString() & " %"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Try
            lblStatus.Text = "Synchronization Completed"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClosingSyncForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            LoginForm.Show()
            LoginForm.Close()
            LoginForm.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lblStatus_TextChanged(sender As Object, e As EventArgs) Handles lblStatus.TextChanged
        Try
            If lblStatus.Text = "Synchronization Completed" = True Then
                Me.Close()
                Me.Dispose()
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            StartUpForm.BackgroundWorker1.CancelAsync()
            MyDelSync.Delete_bank_open_bal_temp_t()
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports System.Drawing.Printing
Imports System.IO

Public Class ReceiptForm

    Dim rep As New InvoiceClass

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Time_Timer.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click

        Try


            EstimatePrintDialog.Document = EstimatePrintDocument

            EstimatePrintDialog.PrinterSettings = EstimatePrintDocument.PrinterSettings

            EstimatePrintDialog.AllowSomePages = True

            If EstimatePrintDialog.ShowDialog = DialogResult.OK Then

                EstimatePrintDocument.PrinterSettings = EstimatePrintDialog.PrinterSettings

                EstimatePrintDocument.Print()

            End If

        Catch ex As Exception

        End Try

        rep.InsertReceipt()

        Me.Dispose()
        Me.Close()

    End Sub

    Private Sub EstimatePrintDocument_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles EstimatePrintDocument.PrintPage
        Dim bm As New Bitmap(Me.PnlPOview.Width, Me.PnlPOview.Height)
        PnlPOview.DrawToBitmap(bm, New Rectangle(0, 0, Me.PnlPOview.Width, Me.PnlPOview.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

    Private Sub Time_Timer_Tick(sender As System.Object, e As System.EventArgs) Handles Time_Timer.Tick
        Try
            rep.FillBookNo()
        Catch ex As Exception

        End Try
    End Sub
End Class
Imports DevExpress.Export
Imports DevExpress.Export.Xl
Imports DevExpress.Printing.ExportHelpers
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Views.Base

Public Class CustomerListForm

    Dim cus As New CustomerClass

    Private Sub CustomerListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cus.LoadCustList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            txtid.Clear()
            cus.LoadCustList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CustomerListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try

            ' Ensure that the data-aware export mode is enabled.
            ExportSettings.DefaultExportType = ExportType.DataAware
            ' Create a new object defining how a document is exported to the XLSX format.
            Dim options = New XlsxExportOptionsEx()
            ' Specify a name of the sheet in the created XLSX file.
            options.SheetName = "Cust List"

            ' Export the grid data to the XLSX format.
            dgvCustList.ExportToXlsx("grid-export.xlsx", options)
            ' Open the created document.
            Process.Start("grid-export.xlsx")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCustList_PrintInitialize(sender As System.Object,
            e As DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs) _
            Handles GridView1.PrintInitialize
        Dim pb As PrintingSystemBase = CType(e.PrintingSystem, PrintingSystemBase)
        pb.PageSettings.Landscape = True
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            GridView1.ShowPrintPreview()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCustList_Click(sender As Object, e As EventArgs) Handles dgvCustList.Click
        Try
            Dim cellValue As String = GridView1.GetFocusedDisplayText()
            txtid.Text = cellValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtid_TextChanged(sender As Object, e As EventArgs) Handles txtid.TextChanged
        Try
            Dim result As DialogResult = MessageBox.Show("What do you want to do? Edit or Delete. If delete then click on delete button else click yes to edit data", "Warning !!!!!", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            ElseIf result = DialogResult.No Then
                Exit Sub
            ElseIf result = DialogResult.Yes Then
                CustomerForm.txtgcode.Text = txtid.Text
                cus.GetSupData()
                cus.GetSupAddData()
                MainForm.btncusto.PerformClick()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Try
            cus.DeleteSup()
            cus.LoadCustList()
        Catch ex As Exception

        End Try
    End Sub
End Class
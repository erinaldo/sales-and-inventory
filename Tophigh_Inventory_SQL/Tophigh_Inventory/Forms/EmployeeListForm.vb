Imports System.IO
Imports System.Data
Imports System.Reflection
Imports ClosedXML.Excel
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

Public Class EmployeeListForm

    Dim emp As New EmpClass
    Dim index As Integer

    Private Sub EmployeeListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            emp.loadEmpList()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        Try
            emp.loadEmpList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmployeeListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            emp.ExportToPDF()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtempcode_TextChanged(sender As Object, e As EventArgs) Handles txtempcode.TextChanged
        Try
            EmployeesForm.txtempcheck.Text = txtempcode.Text
            MainForm.btnnewemp.PerformClick()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvEmpList_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEmpList.CellMouseClick
        Try
            If e.RowIndex >= 0 Then
                Dim row As DataGridViewRow = dgvEmpList.Rows(e.RowIndex)
                txtempcode.Text = row.Cells(0).Value.ToString
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvEmpList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpList.CellContentClick

    End Sub
End Class
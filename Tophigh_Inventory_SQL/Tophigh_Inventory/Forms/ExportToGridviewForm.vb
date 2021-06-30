Imports Excel = Microsoft.Office.Interop.Excel

Public Class ExportToGridviewForm


    Dim sFileName As String = ""

    Private Sub ExportToGridviewForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    ' IMPORT EXCEL DATA TO DATAGRIDVIEW.

    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
            ByVal keyData As System.Windows.Forms.Keys) As Boolean

        If keyData = Keys.Enter Then
            SendKeys.Send("{TAB}")      ' MOVE NEXT CELL WHEN YOU PRESS ENTER KEY.
            Return True
        Else
            Return MyBase.ProcessCmdKey(msg, keyData)
        End If
    End Function



    Private Sub dataGridView1_RowStateChanged(sender As Object,
        e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) _
            Handles DataGridView1.RowStateChanged

        ' MAKE THE FIRST CELL (WITH EMPLOYEE NAME) READ ONLY.
        If Trim(e.Row.Cells(0).Value) <> "" Then
            e.Row.Cells(0).Style.ForeColor = Color.Gray
            e.Row.Cells(0).ReadOnly = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class
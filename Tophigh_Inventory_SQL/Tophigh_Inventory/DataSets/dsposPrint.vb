

Partial Class dsposPrint
    Partial Public Class POSDataTable
        Private Sub POSDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.itemsColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

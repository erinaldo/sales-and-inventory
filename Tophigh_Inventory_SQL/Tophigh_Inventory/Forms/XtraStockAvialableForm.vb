Imports DevExpress.XtraGrid.Controls

Public Class XtraStockAvialableForm

    Dim pritm As New ItemsClass

    Private Sub XtraStockAvialableForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            pritm.LoadCount()
            pritm.LoadAvialStock()

            If Not GridView1.IsFindPanelVisible Then
                GridView1.ShowFindPanel()
            Else
                GridView1.HideFindPanel()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub XtraStockAvialableForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        Try
            XtraItemsForm.Show()
            XtraItemsForm.MdiParent = MainForm
            XtraItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        Try
            XtraPuchaseOrderForm.Show()
            XtraPuchaseOrderForm.MdiParent = MainForm
            XtraPuchaseOrderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            pritm.LoadCount()
            pritm.LoadAvialStock()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReceOrder_Click(sender As Object, e As EventArgs) Handles btnReceOrder.Click
        Try
            XtraReceiveOderForm.Show()
            XtraReceiveOderForm.MdiParent = MainForm
            XtraReceiveOderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub
End Class
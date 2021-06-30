Public Class ChartofAccountListForm

    Dim ch As New ChartofAccountClass

    Private Sub ChartofAccountListForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ch.AccountList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnnew.ItemClick
        Try
            NewChartForm.Show()
            NewChartForm.MdiParent = MainForm
            NewChartForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChartofAccountListForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnedit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnedit.ItemClick
        Try

            NewChartForm.btndelete.Enabled = False

            If LvChart.SelectedItems.Count > 0 Then

                With LvChart.SelectedItems(0)

                    NewChartForm.txtid.Text = .SubItems(0).Text

                    NewChartForm.txtAcCode.Text = .SubItems(1).Text

                    NewChartForm.Show()
                    NewChartForm.MdiParent = MainForm
                    NewChartForm.BringToFront()

                End With

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btndelete.ItemClick
        Try

            NewChartForm.btndelete.Enabled = True

            If LvChart.SelectedItems.Count > 0 Then

                With LvChart.SelectedItems(0)

                    NewChartForm.txtid.Text = .SubItems(0).Text

                    NewChartForm.txtAcCode.Text = .SubItems(1).Text

                    NewChartForm.Show()
                    NewChartForm.MdiParent = MainForm
                    NewChartForm.BringToFront()

                End With

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrefresh.ItemClick
        Try
            ch.AccountList()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnclose.ItemClick
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LvChart_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LvChart.SelectedIndexChanged

    End Sub
End Class
Public Class NewChartForm

    Dim ch As New ChartofAccountClass

    Private Sub NewChartForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ch.GetChartData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbocua_CheckedChanged(sender As Object, e As EventArgs) Handles rbocua.CheckedChanged
        Try
            If rbocua.Checked = True Then
                txtAcGroup.Text = rbocua.Text
                ch.CurAssetsCode()
                ch.FillCurAssetBox()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rborc_CheckedChanged(sender As Object, e As EventArgs) Handles rborc.CheckedChanged
        Try
            If rborc.Checked = True Then
                txtAcGroup.Text = rborc.Text
                ch.Receivables()
                ch.FillRece()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rboinv_CheckedChanged(sender As Object, e As EventArgs) Handles rboinv.CheckedChanged
        Try
            If rboinv.Checked = True Then
                txtAcGroup.Text = rboinv.Text
                ch.Inventories()
                ch.FillRevBox()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbope_CheckedChanged(sender As Object, e As EventArgs) Handles rbope.CheckedChanged
        Try
            If rbope.Checked = True Then
                txtAcGroup.Text = rbope.Text
                ch.PrepaidEx()
                ch.FillPreP()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbofa_CheckedChanged(sender As Object, e As EventArgs) Handles rbofa.CheckedChanged
        Try
            If rbofa.Checked = True Then
                txtAcGroup.Text = rbofa.Text
                ch.FixedAss()
                ch.FillFixedA()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rboacm_CheckedChanged(sender As Object, e As EventArgs) Handles rboacm.CheckedChanged
        Try
            If rboacm.Checked = True Then
                txtAcGroup.Text = rboacm.Text
                ch.AccMu()
                ch.FillAccm()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbocogs_CheckedChanged(sender As Object, e As EventArgs) Handles rbocogs.CheckedChanged
        Try
            If rbocogs.Checked = True Then
                txtAcGroup.Text = rbocogs.Text
                ch.CogsAc()
                ch.FillCogs()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbopy_CheckedChanged(sender As Object, e As EventArgs) Handles rbopy.CheckedChanged
        Try
            If rbopy.Checked = True Then
                txtAcGroup.Text = rbopy.Text
                ch.Payables()
                ch.FillPaya()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbodeb_CheckedChanged(sender As Object, e As EventArgs) Handles rbodeb.CheckedChanged
        Try
            If rbodeb.Checked = True Then
                txtAcGroup.Text = rbodeb.Text
                ch.DebtsAc()
                ch.FillDetPaya()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rboequ_CheckedChanged(sender As Object, e As EventArgs) Handles rboequ.CheckedChanged
        Try
            If rboequ.Checked = True Then
                txtAcGroup.Text = rboequ.Text
                ch.EquitiesAc()
                ch.FillEqu()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rborev_CheckedChanged(sender As Object, e As EventArgs) Handles rborev.CheckedChanged
        Try
            If rborev.Checked = True Then
                txtAcGroup.Text = rborev.Text
                ch.RevenuesAc()
                ch.FillRev()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rboope_CheckedChanged(sender As Object, e As EventArgs) Handles rboope.CheckedChanged
        Try
            If rboope.Checked = True Then
                txtAcGroup.Text = rboope.Text
                ch.OperatinEX()
                ch.FillOpeEx()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbooex_CheckedChanged(sender As Object, e As EventArgs) Handles rbooex.CheckedChanged
        Try
            If rbooex.Checked = True Then
                txtAcGroup.Text = rbooex.Text
                ch.OtherOperatinEX()
                ch.FillOthEx()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboFlow_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFlow.SelectedIndexChanged
        Try

            txtcashtype.Text = ""

            If cboFlow.Text = "CASH FLOWS FROM CURRENT ASSETS" Then
                txtcashtype.Text = "CABNE"
            End If

            If cboFlow.Text = "CASH FLOWS FROM OPERATING ACTIVITIES Cash Receipts" Then
                txtcashtype.Text = "OPACR"
            End If

            If cboFlow.Text = "CASH FLOWS FROM OPERATING ACTIVITIES Cash Payments" Then
                txtcashtype.Text = "OPACP"
            End If

            If cboFlow.Text = "CASH FLOWS FROM INVESTING ACTIVITIES Sale of Assets" Then
                txtcashtype.Text = "INASA"
            End If

            If cboFlow.Text = "CASH FLOWS FROM INVESTING ACTIVITIES Purchase of Assets" Then
                txtcashtype.Text = "INAPA"
            End If

            If cboFlow.Text = "CASH FLOWS FROM FINANCING ACTIVITIES Cash Receipts" Then
                txtcashtype.Text = "FINCR"
            End If

            If cboFlow.Text = "CASH FLOWS FROM FINANCING ACTIVITIES Cash Paid" Then
                txtcashtype.Text = "FINCP"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboFlow_TextChanged(sender As Object, e As EventArgs) Handles cboFlow.TextChanged
        Try

            txtcashtype.Text = ""

            If cboFlow.Text = "CASH FLOWS FROM CURRENT ASSETS" Then
                txtcashtype.Text = "CABNE"
            End If

            If cboFlow.Text = "CASH FLOWS FROM OPERATING ACTIVITIES Cash Receipts" Then
                txtcashtype.Text = "OPACR"
            End If

            If cboFlow.Text = "CASH FLOWS FROM OPERATING ACTIVITIES Cash Payments" Then
                txtcashtype.Text = "OPACP"
            End If

            If cboFlow.Text = "CASH FLOWS FROM INVESTING ACTIVITIES Sale of Assets" Then
                txtcashtype.Text = "INASA"
            End If

            If cboFlow.Text = "CASH FLOWS FROM INVESTING ACTIVITIES Purchase of Assets" Then
                txtcashtype.Text = "INAPA"
            End If

            If cboFlow.Text = "CASH FLOWS FROM FINANCING ACTIVITIES Cash Receipts" Then
                txtcashtype.Text = "FINCR"
            End If

            If cboFlow.Text = "CASH FLOWS FROM FINANCING ACTIVITIES Cash Paid" Then
                txtcashtype.Text = "FINCP"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        Try
            ch.CheckAcc()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            ch.ClearData()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Try
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            ch.DeleteCOA()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtAcCode_TextChanged(sender As Object, e As EventArgs) Handles txtAcCode.TextChanged
        Try
            ch.GetChartData()
        Catch ex As Exception

        End Try
    End Sub
End Class
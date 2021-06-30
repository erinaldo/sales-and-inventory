Public Class UserControlForm

    Dim usc As New SettingsClass
    Private Sub UserControlForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            usc.FillCustName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkChart_CheckedChanged(sender As Object, e As EventArgs) Handles chkChart.CheckedChanged
        Try
            If chkChart.Checked = True Then
                txtchart.Text = "1"
                Exit Sub
            Else
                txtchart.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtchart_TextChanged(sender As Object, e As EventArgs) Handles txtchart.TextChanged
        Try
            If txtchart.Text = "0" Then
                MainForm.btnChart.Enabled = False
                chkChart.Checked = False
            Else
                MainForm.btnChart.Enabled = True
                chkChart.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkDemo_CheckedChanged(sender As Object, e As EventArgs) Handles chkDemo.CheckedChanged
        Try
            If chkDemo.Checked = True Then
                txtdebitmemo.Text = "1"
                Exit Sub
            Else
                txtdebitmemo.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtdebitmemo_TextChanged(sender As Object, e As EventArgs) Handles txtdebitmemo.TextChanged
        Try
            If txtdebitmemo.Text = "0" Then
                MainForm.btnDebitMemo.Enabled = False
                chkDemo.Checked = False
            Else
                MainForm.btnDebitMemo.Enabled = True
                chkDemo.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkCreMo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCreMo.CheckedChanged
        Try
            If chkCreMo.Checked = True Then
                txtcreditmemo.Text = "1"
                Exit Sub
            Else
                txtcreditmemo.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcreditmemo_TextChanged(sender As Object, e As EventArgs) Handles txtcreditmemo.TextChanged
        Try
            If txtcreditmemo.Text = "0" Then
                MainForm.btnCreditmemo.Enabled = False
                chkCreMo.Checked = False
            Else
                MainForm.btnCreditmemo.Enabled = True
                chkCreMo.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkJEnt_CheckedChanged(sender As Object, e As EventArgs) Handles chkJEnt.CheckedChanged
        Try
            If chkJEnt.Checked = True Then
                txtjuornalentry.Text = "1"
                Exit Sub
            Else
                txtjuornalentry.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtjuornalentry_TextChanged(sender As Object, e As EventArgs) Handles txtjuornalentry.TextChanged
        Try
            If txtjuornalentry.Text = "0" Then
                MainForm.btnjournal.Enabled = False
                chkJEnt.Checked = False
            Else
                MainForm.btnjournal.Enabled = True
                chkJEnt.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRecPay_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecPay.CheckedChanged
        Try
            If chkRecPay.Checked = True Then
                txtrecepay.Text = "1"
                Exit Sub
            Else
                txtrecepay.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtrecepay_TextChanged(sender As Object, e As EventArgs) Handles txtrecepay.TextChanged
        Try
            If txtrecepay.Text = "0" Then
                MainForm.btnRecPayment.Enabled = False
                MainForm.btnrecpay.Enabled = False
                chkRecPay.Checked = False
            Else
                MainForm.btnRecPayment.Enabled = True
                MainForm.btnrecpay.Enabled = True
                chkRecPay.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkPaySupBill_CheckedChanged(sender As Object, e As EventArgs) Handles chkPaySupBill.CheckedChanged
        Try
            If chkPaySupBill.Checked = True Then
                txtpaybills.Text = "1"
                Exit Sub
            Else
                txtpaybills.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtpaybills_TextChanged(sender As Object, e As EventArgs) Handles txtpaybills.TextChanged
        Try
            If txtpaybills.Text = "0" Then
                MainForm.btnpaysups.Enabled = False
                MainForm.btnpaybills.Enabled = False
                chkPaySupBill.Checked = False
            Else
                MainForm.btnpaysups.Enabled = True
                MainForm.btnpaybills.Enabled = True
                chkPaySupBill.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkBank_CheckedChanged(sender As Object, e As EventArgs) Handles chkBank.CheckedChanged
        Try
            If chkBank.Checked = True Then
                txtBanking.Text = "1"
                Exit Sub
            Else
                txtBanking.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBanking_TextChanged(sender As Object, e As EventArgs) Handles txtBanking.TextChanged
        Try
            If txtBanking.Text = "0" Then
                MainForm.btnbnkDeposit.Enabled = False
                MainForm.btnbnkTransfer.Enabled = False
                MainForm.btnbanksetup.Enabled = False
                MainForm.btnbnkstatement.Enabled = False
                MainForm.btnfundtranfer.Enabled = False
                MainForm.btndeposit.Enabled = False
                MainForm.btnbankRecon.Enabled = False
                chkBank.Checked = False
            Else
                MainForm.btnbnkDeposit.Enabled = True
                MainForm.btnbnkTransfer.Enabled = True
                MainForm.btnbanksetup.Enabled = True
                MainForm.btnbnkstatement.Enabled = True
                MainForm.btnfundtranfer.Enabled = True
                MainForm.btndeposit.Enabled = True
                MainForm.btnbankRecon.Enabled = True
                chkBank.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Chkpos_CheckedChanged(sender As Object, e As EventArgs) Handles chkpos.CheckedChanged
        Try
            If chkpos.Checked = True Then
                txtpos.Text = "1"
                Exit Sub
            Else
                txtpos.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtpos_TextChanged(sender As Object, e As EventArgs) Handles txtpos.TextChanged
        Try
            If txtpos.Text = "0" Then
                MainForm.btnsales.Enabled = False
                MainForm.btnSalesRet.Enabled = False
                MainForm.btnPushData.Enabled = False
                MainForm.btnReceive.Enabled = False
                MainForm.btnSalesReceipt.Enabled = False
                chkpos.Checked = False
            Else
                MainForm.btnsales.Enabled = True
                MainForm.btnSalesRet.Enabled = True
                MainForm.btnPushData.Enabled = True
                MainForm.btnReceive.Enabled = True
                MainForm.btnSalesReceipt.Enabled = True
                chkpos.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkInv_CheckedChanged(sender As Object, e As EventArgs) Handles chkInv.CheckedChanged
        Try
            If chkInv.Checked = True Then
                txtSalesInv.Text = "1"
                Exit Sub
            Else
                txtSalesInv.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSalesInv_TextChanged(sender As Object, e As EventArgs) Handles txtSalesInv.TextChanged
        Try
            If txtSalesInv.Text = "0" Then
                MainForm.btnInv.Enabled = False
                chkInv.Checked = False
            Else
                MainForm.btnInv.Enabled = True
                chkInv.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkCustState_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustState.CheckedChanged
        Try
            If chkCustState.Checked = True Then
                txtcuststatement.Text = "1"
                Exit Sub
            Else
                txtcuststatement.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtcuststatement_TextChanged(sender As Object, e As EventArgs) Handles txtcuststatement.TextChanged
        Try
            If txtcuststatement.Text = "0" Then
                MainForm.btnCustState.Enabled = False
                chkCustState.Checked = False
            Else
                MainForm.btnCustState.Enabled = True
                chkCustState.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkDebRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkDebRep.CheckedChanged
        Try
            If chkDebRep.Checked = True Then
                txtdeprep.Text = "1"
                Exit Sub
            Else
                txtdeprep.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtdeprep_TextChanged(sender As Object, e As EventArgs) Handles txtdeprep.TextChanged
        Try
            If txtdeprep.Text = "0" Then
                MainForm.btndebtors.Enabled = False
                chkDebRep.Checked = False
            Else
                MainForm.btndebtors.Enabled = True
                chkDebRep.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkStoreQty_CheckedChanged(sender As Object, e As EventArgs) Handles chkStoreQty.CheckedChanged
        Try
            If chkStoreQty.Checked = True Then
                txtshelfAdjust.Text = "1"
                Exit Sub
            Else
                txtshelfAdjust.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtshelfAdjust_TextChanged(sender As Object, e As EventArgs) Handles txtshelfAdjust.TextChanged
        Try
            If txtshelfAdjust.Text = "0" Then
                MainForm.btnadjuststqty.Enabled = False
                chkStoreQty.Checked = False
            Else
                MainForm.btnadjuststqty.Enabled = True
                chkStoreQty.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkRecOrdBill_CheckedChanged(sender As Object, e As EventArgs) Handles chkRecOrdBill.CheckedChanged
        Try
            If chkRecOrdBill.Checked = True Then
                txtPO.Text = "1"
                Exit Sub
            Else
                txtPO.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPO_TextChanged(sender As Object, e As EventArgs) Handles txtPO.TextChanged
        Try
            If txtPO.Text = "0" Then
                MainForm.btnPurOrder.Enabled = False
                MainForm.btnReitems.Enabled = False
                MainForm.btnCreateBills.Enabled = False
                MainForm.btnSuppBills.Enabled = False
                MainForm.btnSupState.Enabled = False
                MainForm.btnOrederReceive.Enabled = False
                chkRecOrdBill.Checked = False
            Else
                MainForm.btnPurOrder.Enabled = True
                MainForm.btnReitems.Enabled = True
                MainForm.btnCreateBills.Enabled = True
                MainForm.btnSuppBills.Enabled = True
                MainForm.btnSupState.Enabled = True
                MainForm.btnOrederReceive.Enabled = True
                chkRecOrdBill.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkTrackSupBill_CheckedChanged(sender As Object, e As EventArgs) Handles chkTrackSupBill.CheckedChanged
        Try
            If chkTrackSupBill.Checked = True Then
                txtBillTrck.Text = "1"
                Exit Sub
            Else
                txtBillTrck.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtBillTrck_TextChanged(sender As Object, e As EventArgs) Handles txtBillTrck.TextChanged
        Try
            If txtBillTrck.Text = "0" Then
                MainForm.btnBillTracker.Enabled = False
                chkTrackSupBill.Checked = False
            Else
                MainForm.btnBillTracker.Enabled = True
                chkTrackSupBill.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkAddWare_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddWare.CheckedChanged
        Try
            If chkAddWare.Checked = True Then
                txtNewWare.Text = "1"
                Exit Sub
            Else
                txtNewWare.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNewWare_TextChanged(sender As Object, e As EventArgs) Handles txtNewWare.TextChanged
        Try
            If txtNewWare.Text = "0" Then
                MainForm.btnNewWarehouse.Enabled = False
                chkAddWare.Checked = False
            Else
                MainForm.btnNewWarehouse.Enabled = True
                chkAddWare.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkAddStore_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddStore.CheckedChanged
        Try
            If chkAddStore.Checked = True Then
                txtNewShelf.Text = "1"
                Exit Sub
            Else
                txtNewShelf.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNewShelf_TextChanged(sender As Object, e As EventArgs) Handles txtNewShelf.TextChanged
        Try
            If txtNewShelf.Text = "0" Then
                MainForm.btnNewShelf.Enabled = False
                chkAddStore.Checked = False
            Else
                MainForm.btnNewShelf.Enabled = True
                chkAddStore.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkAddDeffect_CheckedChanged(sender As Object, e As EventArgs) Handles chkAddDeffect.CheckedChanged
        Try
            If chkAddDeffect.Checked = True Then
                txtNewDefect.Text = "1"
                Exit Sub
            Else
                txtNewDefect.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtNewDefect_TextChanged(sender As Object, e As EventArgs) Handles txtNewDefect.TextChanged
        Try
            If txtNewDefect.Text = "0" Then
                MainForm.btnNewDefect.Enabled = False
                chkAddDeffect.Checked = False
            Else
                MainForm.btnNewDefect.Enabled = True
                chkAddDeffect.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkAdjustWareQty_CheckedChanged(sender As Object, e As EventArgs) Handles chkAdjustWareQty.CheckedChanged
        Try
            If chkAdjustWareQty.Checked = True Then
                txtAdjustWareQty.Text = "1"
                Exit Sub
            Else
                txtAdjustWareQty.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtAdjustWareQty_TextChanged(sender As Object, e As EventArgs) Handles txtAdjustWareQty.TextChanged
        Try
            If txtAdjustWareQty.Text = "0" Then
                MainForm.btnWareAdjust.Enabled = False
                chkAdjustWareQty.Checked = False
            Else
                MainForm.btnWareAdjust.Enabled = True
                chkAdjustWareQty.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkManCount_CheckedChanged(sender As Object, e As EventArgs) Handles chkManCount.CheckedChanged
        Try
            If chkManCount.Checked = True Then
                txtInCount.Text = "1"
                Exit Sub
            Else
                txtInCount.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtInCount_TextChanged(sender As Object, e As EventArgs) Handles txtInCount.TextChanged
        Try
            If txtInCount.Text = "0" Then
                MainForm.btnInvCount.Enabled = False
                chkManCount.Checked = False
            Else
                MainForm.btnInvCount.Enabled = True
                chkManCount.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkWholeSales_CheckedChanged(sender As Object, e As EventArgs) Handles chkWholeSales.CheckedChanged
        Try
            If chkWholeSales.Checked = True Then
                txtWCash.Text = "1"
                Exit Sub
            Else
                txtWCash.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtWCash_TextChanged(sender As Object, e As EventArgs) Handles txtWCash.TextChanged
        Try
            If txtWCash.Text = "0" Then
                MainForm.btnWholeCash.Enabled = False
                MainForm.btnWholeCredit.Enabled = False
                chkWholeSales.Checked = False
            Else
                MainForm.btnWholeCash.Enabled = True
                MainForm.btnWholeCredit.Enabled = True
                chkWholeSales.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkInvRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkInvRep.CheckedChanged
        Try
            If chkInvRep.Checked = True Then
                txtInvVal.Text = "1"
                Exit Sub
            Else
                txtInvVal.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtInvVal_TextChanged(sender As Object, e As EventArgs) Handles txtInvVal.TextChanged
        Try
            If txtInvVal.Text = "0" Then
                MainForm.BarSubItem3.Enabled = False
                MainForm.btndefect.Enabled = False
                chkInvRep.Checked = False
            Else
                MainForm.BarSubItem3.Enabled = True
                MainForm.btndefect.Enabled = True
                chkInvRep.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkPurRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkPurRep.CheckedChanged
        Try
            If chkPurRep.Checked = True Then
                txtPayTrack.Text = "1"
                Exit Sub
            Else
                txtPayTrack.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtPayTrack_TextChanged(sender As Object, e As EventArgs) Handles txtPayTrack.TextChanged
        Try
            If txtPayTrack.Text = "0" Then
                MainForm.BarSubItem4.Enabled = False
                chkPurRep.Checked = False
            Else
                MainForm.BarSubItem4.Enabled = True
                chkPurRep.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkSalesRep_CheckedChanged(sender As Object, e As EventArgs) Handles chkSalesRep.CheckedChanged
        Try
            If chkSalesRep.Checked = True Then
                txtDailyCashSale.Text = "1"
                Exit Sub
            Else
                txtDailyCashSale.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtDailyCashSale_TextChanged(sender As Object, e As EventArgs) Handles txtDailyCashSale.TextChanged
        Try
            If txtDailyCashSale.Text = "0" Then
                MainForm.BarSubItem6.Enabled = False
                MainForm.btncascred.Enabled = False
                MainForm.btnMemCashReport.Enabled = False
                MainForm.btnEmpList.Enabled = False
                chkSalesRep.Checked = False
            Else
                MainForm.BarSubItem6.Enabled = True
                MainForm.btncascred.Enabled = True
                MainForm.btnMemCashReport.Enabled = True
                MainForm.btnEmpList.Enabled = True
                chkSalesRep.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkFinState_CheckedChanged(sender As Object, e As EventArgs) Handles chkFinState.CheckedChanged
        Try
            If chkFinState.Checked = True Then
                txtFinState.Text = "1"
                Exit Sub
            Else
                txtFinState.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtFinState_TextChanged(sender As Object, e As EventArgs) Handles txtFinState.TextChanged
        Try
            If txtFinState.Text = "0" Then
                MainForm.btnStatement.Enabled = False
                chkFinState.Checked = False
            Else
                MainForm.btnStatement.Enabled = True
                chkFinState.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkSettings_CheckedChanged(sender As Object, e As EventArgs) Handles chkSettings.CheckedChanged
        Try
            If chkSettings.Checked = True Then
                txtSalesByItem.Text = "1"
                Exit Sub
            Else
                txtSalesByItem.Text = "0"
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtSalesByItem_TextChanged(sender As Object, e As EventArgs) Handles txtSalesByItem.TextChanged
        Try
            If txtSalesByItem.Text = "0" Then
                MainForm.BarSubItem11.Enabled = False
                MainForm.btnUserPass.Enabled = False
                chkSettings.Checked = False
            Else
                MainForm.BarSubItem11.Enabled = True
                MainForm.btnUserPass.Enabled = True
                chkSettings.Checked = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            usc.CheckUserControl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CboUsers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUsers.SelectedIndexChanged
        Try
            usc.FillUserControl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboUsers_TextChanged(sender As Object, e As EventArgs) Handles cboUsers.TextChanged
        Try
            usc.FillUserControl()
        Catch ex As Exception

        End Try
    End Sub
End Class
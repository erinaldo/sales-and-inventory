Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Windows.Forms
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports MySql.Data.MySqlClient
Imports System.Net
Imports System.Data.SQLite

Public Class MainForm

    Private conn As SQLiteConnection
    Private cmd As SQLiteCommand
    Private adapter As SQLiteDataAdapter
    Private ds As DataSet = New DataSet()
    Private dt As DataTable = New DataTable()
    Private id As Integer
    Private isDoubleClick As Boolean = False

    Private connectString As String = "Data Source=" & Application.StartupPath & "\syscheck.db"

    Dim minMaintenance As Integer
    Dim minPurchase As Integer
    Dim minSales As Integer
    Dim critical As Integer

    Dim itm As New ItemsClass
    Dim usc As New SettingsClass

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnValuation.ItemClick
        Try
            BGForm.SendToBack()
            XtraInventoryValuationSummaryForm.Show()
            XtraInventoryValuationSummaryForm.MdiParent = Me
            XtraInventoryValuationSummaryForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCurrentStock.ItemClick
        Try
            BGForm.SendToBack()
            XtraStockAvialableForm.Show()
            XtraStockAvialableForm.MdiParent = Me
            XtraStockAvialableForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Try
            BGForm.SendToBack()
            DeffectiveItemsForm.Show()
            DeffectiveItemsForm.MdiParent = Me
            DeffectiveItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDefectList.ItemClick
        Try
            BGForm.SendToBack()
            XtraDeffectiveListForm.Show()
            XtraDeffectiveListForm.MdiParent = Me
            XtraDeffectiveListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnStockLocation.ItemClick
        Try
            BGForm.SendToBack()
            XtraStockbylocationForm.Show()
            XtraStockbylocationForm.MdiParent = Me
            XtraStockbylocationForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOPPO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOPPO.ItemClick
        Try
            BGForm.SendToBack()
            XtraOpenPORepForm.Show()
            XtraOpenPORepForm.MdiParent = Me
            XtraOpenPORepForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbySupplier.ItemClick
        Try
            BGForm.SendToBack()
            XtraPurchsebySupForm.Show()
            XtraPurchsebySupForm.MdiParent = Me
            XtraPurchsebySupForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInvManuCount_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInvManuCount.ItemClick
        Try
            BGForm.SendToBack()
            StockManualCountForm.Show()
            StockManualCountForm.MdiParent = Me
            StockManualCountForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnlowstock_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnlowstock.ItemClick
        Try
            BGForm.SendToBack()
            LowStockForm.Show()
            LowStockForm.MdiParent = Me
            LowStockForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCount_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCount.ItemClick
        Try
            BGForm.SendToBack()
            XtraWarehouseCountSheetForm.Show()
            XtraWarehouseCountSheetForm.MdiParent = Me
            XtraWarehouseCountSheetForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            sysdate.Value = Date.Now
            GetsubDate()

            POSForm.Show()
            POSForm.MdiParent = Me
            POSForm.BringToFront()

            Timer1.Start()

            usc.FillUserControl()

            txtlocation.Focus()

            If lbluser.Text = "Richmond Kofi Debrah" = True Then
                Me.btnsubsription.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            Else
                Me.btnsubsription.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub GetsubDate()
        Try
            conn = New SQLiteConnection(connectString)
            conn.Open()
            cmd = New SQLiteCommand()
            Dim cm As New SQLiteCommand() With {.CommandText = String.Format("SELECT dateto FROM subscription_t where sub_status ='Subscribed'"), .Connection = conn}

            Dim dr As SQLiteDataReader = cm.ExecuteReader

            If dr.HasRows Then

                dr.Read()

                dtto.Text = dr.Item("dateto")

                dr.Close()

            End If
            conn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dtto_ValueChanged(sender As Object, e As EventArgs) Handles dtto.ValueChanged
        Try

            If True Then

                Dim dt1 As DateTime = Convert.ToDateTime(sysdate.Text)

                Dim dt2 As DateTime = Convert.ToDateTime(dtto.Text)

                Dim ts As TimeSpan = dt2.Subtract(dt1)

                If Convert.ToInt32(ts.Days) >= 0 Then

                    lbldaysleft.Text = Convert.ToInt32(ts.Days)

                Else

                    MessageBox.Show("Invalid Input")

                End If

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Try
            BGForm.SendToBack()
            AddtoStoreShelfForm.Show()
            AddtoStoreShelfForm.MdiParent = Me
            AddtoStoreShelfForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStoreList_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnStoreList.ItemClick
        Try
            BGForm.SendToBack()
            StoreStockListForm.Show()
            StoreStockListForm.MdiParent = Me
            StoreStockListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMovementlist_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMovementlist.ItemClick
        Try
            BGForm.SendToBack()
            ItemMovementListForm.Show()
            ItemMovementListForm.MdiParent = Me
            ItemMovementListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnstorestockalert_Click(sender As Object, e As EventArgs) Handles btnstorestockalert.Click
        Try
            BGForm.SendToBack()
            StoreLowStockAlert.Show()
            StoreLowStockAlert.MdiParent = Me
            StoreLowStockAlert.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncompany_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncompany.ItemClick
        Try
            BGForm.SendToBack()
            CompanyForm.Show()
            CompanyForm.MdiParent = Me
            CompanyForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsales.ItemClick
        Try
            BGForm.SendToBack()
            POSForm.Show()
            POSForm.MdiParent = Me
            POSForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bbtnsalebycust_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsalebycust.ItemClick
        Try
            BGForm.SendToBack()
            SalesbyCustomer.Show()
            SalesbyCustomer.MdiParent = Me
            SalesbyCustomer.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalesbyitems_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalesbyitems.ItemClick
        Try
            BGForm.SendToBack()
            SalesbyItems.Show()
            SalesbyItems.MdiParent = Me
            SalesbyItems.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsalespayments_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsalespayments.ItemClick
        Try
            BGForm.SendToBack()
            SalesbyPayment.Show()
            SalesbyPayment.MdiParent = Me
            SalesbyPayment.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btngendailysales_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btngendailysales.ItemClick
        Try
            BGForm.SendToBack()
            GeneralDailyCashSales.Show()
            GeneralDailyCashSales.MdiParent = Me
            GeneralDailyCashSales.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsalesperf_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsalesperf.ItemClick
        Try
            BGForm.SendToBack()
            SalesChart.Show()
            SalesChart.MdiParent = Me
            SalesChart.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsaleschart_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsaleschart.ItemClick
        Try
            BGForm.SendToBack()
            SalesChart.Show()
            SalesChart.MdiParent = Me
            SalesChart.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInv_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInv.ItemClick
        Try
            BGForm.SendToBack()
            CreditSalesForm.Show()
            CreditSalesForm.MdiParent = Me
            CreditSalesForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearchinv_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsearchinv.ItemClick
        Try
            BGForm.SendToBack()
            Invoice.Show()
            Invoice.MdiParent = Me
            Invoice.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrecpay_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnrecpay.ItemClick
        Try
            BGForm.SendToBack()
            ReceiveBillForm.Show()
            ReceiveBillForm.MdiParent = Me
            ReceiveBillForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCustState_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCustState.ItemClick
        Try
            BGForm.SendToBack()
            CustomerStatementForm.Show()
            CustomerStatementForm.MdiParent = Me
            CustomerStatementForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSearchCustState_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSearchCustState.ItemClick
        Try
            BGForm.SendToBack()
            SearchCustomerStatementForm.Show()
            SearchCustomerStatementForm.MdiParent = Me
            SearchCustomerStatementForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndebtors_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btndebtors.ItemClick
        Try
            BGForm.SendToBack()
            OpenDebtors.Show()
            OpenDebtors.MdiParent = Me
            OpenDebtors.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdjust_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdjust.ItemClick
        Try
            BGForm.SendToBack()
            AdjustItems.Show()
            AdjustItems.MdiParent = Me
            AdjustItems.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnadjuststqty_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnadjuststqty.ItemClick
        Try
            BGForm.SendToBack()
            AdjustItems.Show()
            AdjustItems.MdiParent = Me
            AdjustItems.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnitemslist_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnitemslist.ItemClick
        Try
            BGForm.SendToBack()
            XtraStockAvialableForm.Show()
            XtraStockAvialableForm.MdiParent = Me
            XtraStockAvialableForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPurOrder.ItemClick
        Try
            BGForm.SendToBack()
            XtraPuchaseOrderForm.Show()
            XtraPuchaseOrderForm.MdiParent = Me
            XtraPuchaseOrderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReitems.ItemClick
        Try
            BGForm.SendToBack()
            XtraReceiveOderForm.Show()
            XtraReceiveOderForm.MdiParent = Me
            XtraReceiveOderForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCreateBills_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCreateBills.ItemClick
        Try
            BGForm.SendToBack()
            EnterSuppliersBillForm.Show()
            EnterSuppliersBillForm.MdiParent = Me
            EnterSuppliersBillForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSuppBills_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSuppBills.ItemClick
        Try
            BGForm.SendToBack()
            SearchSupInv.Show()
            SearchSupInv.MdiParent = Me
            SearchSupInv.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnpaybills_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnpaybills.ItemClick
        Try
            BGForm.SendToBack()
            PayBillsForm.Show()
            PayBillsForm.MdiParent = Me
            PayBillsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSupState_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSupState.ItemClick
        Try
            BGForm.SendToBack()
            SuppliersStatementForm.Show()
            SuppliersStatementForm.MdiParent = Me
            SuppliersStatementForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdPhysical_Click(sender As Object, e As EventArgs)
        Try
            BGForm.SendToBack()
            DeffectiveItemsForm.Show()
            DeffectiveItemsForm.MdiParent = Me
            DeffectiveItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalesReceipt_Click(sender As Object, e As EventArgs) Handles btnSalesReceipt.Click
        Try
            BGForm.SendToBack()
            POSForm.Show()
            POSForm.MdiParent = Me
            POSForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndefect_Click(sender As Object, e As EventArgs) Handles btndefect.Click
        Try
            BGForm.SendToBack()
            XtraDeffectiveListForm.Show()
            XtraDeffectiveListForm.MdiParent = Me
            XtraDeffectiveListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncriticalproduct_Click(sender As Object, e As EventArgs) Handles btncriticalproduct.Click
        Try
            BGForm.SendToBack()
            LowStockForm.Show()
            LowStockForm.MdiParent = Me
            LowStockForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPhycCount_Click(sender As Object, e As EventArgs) Handles btnPhycCount.Click
        Try
            BGForm.SendToBack()
            XtraWarehouseCountSheetForm.Show()
            XtraWarehouseCountSheetForm.MdiParent = Me
            XtraWarehouseCountSheetForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOrederReceive_Click(sender As Object, e As EventArgs) Handles btnOrederReceive.Click
        Try
            BGForm.SendToBack()
            XtraStockAvialableForm.Show()
            XtraStockAvialableForm.MdiParent = Me
            XtraStockAvialableForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSalesRet_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSalesRet.ItemClick
        Try
            BGForm.SendToBack()
            SalesReturnForm.Show()
            SalesReturnForm.MdiParent = Me
            SalesReturnForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCreditmemo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCreditmemo.ItemClick
        Try
            BGForm.SendToBack()
            CreditMemoForm.Show()
            CreditMemoForm.MdiParent = Me
            CreditMemoForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDebitMemo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDebitMemo.ItemClick
        Try
            BGForm.SendToBack()
            DebitMemoForm.Show()
            DebitMemoForm.MdiParent = Me
            DebitMemoForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbanksetup_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbanksetup.ItemClick
        Try
            BGForm.SendToBack()
            BankSetupForm.Show()
            BankSetupForm.MdiParent = Me
            BankSetupForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbnkstatement_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbnkstatement.ItemClick
        Try
            BGForm.SendToBack()
            bankstatement.Show()
            bankstatement.MdiParent = Me
            bankstatement.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnfundtranfer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnfundtranfer.ItemClick
        Try
            BGForm.SendToBack()
            Transferforms.Show()
            Transferforms.MdiParent = Me
            Transferforms.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btndeposit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btndeposit.ItemClick
        Try
            BGForm.SendToBack()
            Deposit.Show()
            Deposit.MdiParent = Me
            Deposit.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnbankRecon_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbankRecon.ItemClick
        Try
            BGForm.SendToBack()
            BankReconciliation.Show()
            BankReconciliation.MdiParent = Me
            BankReconciliation.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnjournal_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnjournal.ItemClick
        Try
            BGForm.SendToBack()
            JournalEntry.Show()
            JournalEntry.MdiParent = Me
            JournalEntry.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnaddtoshlbatch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnaddtoshlbatch.ItemClick
        Try
            BGForm.SendToBack()
            AddtoShelve.Show()
            AddtoShelve.MdiParent = Me
            AddtoShelve.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPushData_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPushData.ItemClick
        Try
            BGForm.SendToBack()
            DataPush.Show()
            DataPush.MdiParent = Me
            DataPush.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncusto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncusto.ItemClick
        Try
            CustomerForm.Show()
            CustomerForm.MdiParent = Me
            CustomerForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem17_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncomplist.ItemClick
        Try
            CustomerListForm.Show()
            CustomerListForm.MdiParent = Me
            CustomerListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsup_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsup.ItemClick
        Try
            SuppliersForm.Show()
            SuppliersForm.MdiParent = Me
            SuppliersForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsuplist.ItemClick
        Try
            SuppliersListForm.Show()
            SuppliersListForm.MdiParent = Me
            SuppliersListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReceive_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReceive.ItemClick
        Try
            ReceivedPushForm.Show()
            ReceivedPushForm.MdiParent = Me
            ReceivedPushForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnstocktrans_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnstocktrans.ItemClick
        Try
            StockTransferReportForm.Show()
            StockTransferReportForm.MdiParent = Me
            StockTransferReportForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnnewemp_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnnewemp.ItemClick
        Try
            EmployeesForm.Show()
            EmployeesForm.MdiParent = Me
            EmployeesForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEmpList_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnEmpList.ItemClick
        Try
            EmployeeListForm.Show()
            EmployeeListForm.MdiParent = Me
            EmployeeListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            itm.CheckStockPush()
            itm.CheckStoreStock()
            itm.CheckWarehStock()
            itm.CheckStockExpiryDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOcust_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOcust.ItemClick
        Try
            OtherCustForm.Show()
            OtherCustForm.MdiParent = Me
            OtherCustForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOlist_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnOlist.ItemClick
        Try
            OtherCustListForm.Show()
            OtherCustListForm.MdiParent = Me
            OtherCustListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnExpired_Click(sender As Object, e As EventArgs) Handles btnExpired.Click
        Try
            ExpiringProListForm.Show()
            ExpiringProListForm.MdiParent = Me
            ExpiringProListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCategory_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCategory.ItemClick
        Try
            CategoryForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnWholesale_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWholesale.ItemClick
        Try
            CashSalesForm.Show()
            CashSalesForm.MdiParent = Me
            CashSalesForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnWHCreditSales_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWHCreditSales.ItemClick
        Try
            WCRForm.Show()
            WCRForm.MdiParent = Me
            WCRForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsalesinv_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsalesinv.ItemClick
        Try
            SalesInvoiceForm.Show()
            SalesInvoiceForm.MdiParent = Me
            SalesInvoiceForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncash_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncash.ItemClick
        Try
            CSalesReportForm.Show()
            CSalesReportForm.MdiParent = Me
            CSalesReportForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPTracker_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnPTracker.ItemClick
        Try
            CSalesbyPaymentForm.Show()
            CSalesbyPaymentForm.MdiParent = Me
            CSalesbyPaymentForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncustinv_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncustinv.ItemClick
        Try
            CustomerbillsForm.Show()
            CustomerbillsForm.MdiParent = Me
            CustomerbillsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChart_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnChart.ItemClick
        Try
            ChartofAccountListForm.Show()
            ChartofAccountListForm.MdiParent = Me
            ChartofAccountListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNewWarehouse.ItemClick
        Try
            BGForm.SendToBack()
            XtraItemsForm.Show()
            XtraItemsForm.MdiParent = Me
            XtraItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem20_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNewShelf.ItemClick
        Try
            BGForm.SendToBack()
            AddtoStoreShelfForm.Show()
            AddtoStoreShelfForm.MdiParent = Me
            AddtoStoreShelfForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem21_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnNewDefect.ItemClick
        Try
            BGForm.SendToBack()
            DeffectiveItemsForm.Show()
            DeffectiveItemsForm.MdiParent = Me
            DeffectiveItemsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem22_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWareAdjust.ItemClick
        Try
            BGForm.SendToBack()
            AdjustItems.Show()
            AdjustItems.MdiParent = Me
            AdjustItems.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem23_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInvCount.ItemClick
        Try
            BGForm.SendToBack()
            StockManualCountForm.Show()
            StockManualCountForm.MdiParent = Me
            StockManualCountForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem24_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWholeCash.ItemClick
        Try
            CashSalesForm.Show()
            CashSalesForm.MdiParent = Me
            CashSalesForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem25_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnWholeCredit.ItemClick
        Try
            WCRForm.Show()
            WCRForm.MdiParent = Me
            WCRForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncshbypro_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncshbypro.ItemClick
        Try
            SalesbyProductsForm.Show()
            SalesbyProductsForm.MdiParent = Me
            SalesbyProductsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem26_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsalinv.ItemClick
        Try
            SalesInvoiceForm.Show()
            SalesInvoiceForm.MdiParent = Me
            SalesInvoiceForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnprolist_Click(sender As Object, e As EventArgs) Handles btnprolist.Click
        Try
            ProductListingForm.Show()
            ProductListingForm.MdiParent = Me
            ProductListingForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnManSup_Click(sender As Object, e As EventArgs) Handles btnManSup.Click
        Try
            SuppliersListForm.Show()
            SuppliersListForm.MdiParent = Me
            SuppliersListForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMonitor_Click(sender As Object, e As EventArgs) Handles btnMonitor.Click

    End Sub

    Private Sub btnTB_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnTB.ItemClick
        Try
            TrialBalanceForm.Show()
            TrialBalanceForm.MdiParent = Me
            TrialBalanceForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnInsSate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnInsSate.ItemClick
        Try
            IncomeStatementForm.Show()
            IncomeStatementForm.MdiParent = Me
            IncomeStatementForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnbalsheet_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbalsheet.ItemClick
        Try
            BalanceSheetForm.Show()
            BalanceSheetForm.MdiParent = Me
            BalanceSheetForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCflow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnCflow.ItemClick
        Try
            CashFlowForm.Show()
            CashFlowForm.MdiParent = Me
            CashFlowForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnchangeEqu_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnchangeEqu.ItemClick
        Try
            ChangeInEquityForm.Show()
            ChangeInEquityForm.MdiParent = Me
            ChangeInEquityForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdloca_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnAdloca.ItemClick
        Try
            AddLocationForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnRecPayment_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnRecPayment.ItemClick
        Try
            BGForm.SendToBack()
            ReceiveBillForm.Show()
            ReceiveBillForm.MdiParent = Me
            ReceiveBillForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btnpaysups_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnpaysups.ItemClick
        Try
            BGForm.SendToBack()
            PayBillsForm.Show()
            PayBillsForm.MdiParent = Me
            PayBillsForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnbnkDeposit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbnkDeposit.ItemClick
        Try
            BGForm.SendToBack()
            Deposit.Show()
            Deposit.MdiParent = Me
            Deposit.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUserCont_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUserCont.ItemClick
        Try
            BGForm.SendToBack()
            UserControlForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            'ClosingSyncForm.Show()
            LoginForm.Show()
            LoginForm.Close()
            LoginForm.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMemCashReport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMemCashReport.ItemClick
        Try
            MembersCashSalesReportForm.Show()
            MembersCashSalesReportForm.MdiParent = Me
            MembersCashSalesReportForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMemCredt_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMemCredt.ItemClick
        Try
            MembersSalesInvoiceForm.Show()
            MembersSalesInvoiceForm.MdiParent = Me
            MembersSalesInvoiceForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUserPass_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnUserPass.ItemClick
        Try
            UsersForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnbnkTransfer_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnbnkTransfer.ItemClick
        Try
            BGForm.SendToBack()
            Transferforms.Show()
            Transferforms.MdiParent = Me
            Transferforms.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnMemSalInv_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnMemSalInv.ItemClick
        Try
            MembersSalesInvoiceForm.Show()
            MembersSalesInvoiceForm.MdiParent = Me
            MembersSalesInvoiceForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnStkTrans_Click(sender As Object, e As EventArgs) Handles btnStkTrans.Click

    End Sub

    Private Sub BKStockPushCheck_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BKStockPushCheck.DoWork
        Try
            'itm.CheckStockPush()
            'itm.CheckStoreStock()
            'itm.CheckWarehStock()
            'itm.CheckStockExpiryDate()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BKStockPushCheck_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BKStockPushCheck.ProgressChanged

    End Sub

    Private Sub Btnpos1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btnpos2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Btnpos3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub AddBulktoStore_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AddBulktoStore.ItemClick
        Try
            BGForm.SendToBack()
            AddtoShelve.Show()
            AddtoShelve.MdiParent = Me
            AddtoShelve.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnmovebulk_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnmovebulk.ItemClick
        Try
            BGForm.SendToBack()
            MoveToStoreForm.Show()
            MoveToStoreForm.MdiParent = Me
            MoveToStoreForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReceiveOrders_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnReceiveOrders.ItemClick
        Try
            BGForm.SendToBack()
            Receive_Random_Order.Show()
            Receive_Random_Order.MdiParent = Me
            Receive_Random_Order.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            BGForm.SendToBack()
            POSForm3.Show()
            POSForm3.MdiParent = Me
            POSForm3.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Try
            BGForm.SendToBack()
            POSForm2.Show()
            POSForm2.MdiParent = Me
            POSForm2.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try
            BGForm.SendToBack()
            POSForm.Show()
            POSForm.MdiParent = Me
            POSForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btncashdetails.ItemClick
        Try
            SalesOrderReportForm.Show()
            SalesOrderReportForm.MdiParent = Me
            SalesOrderReportForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnhistory_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnhistory.ItemClick
        Try
            StockHistoryForm.Show()
            StockHistoryForm.MdiParent = Me
            StockHistoryForm.BringToFront()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsubsription_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnsubsription.ItemClick
        Try
            SubscriptionForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbldaysleft_TextChanged(sender As Object, e As EventArgs) Handles lbldaysleft.TextChanged
        Try
            For i As Integer = 90 To 150
                If lbldaysleft.Text < i = True Then
                    lbldaysleft.ForeColor = Color.YellowGreen
                    lblyou.ForeColor = Color.YellowGreen
                    lblsub.ForeColor = Color.YellowGreen
                End If
            Next i

            For j As Integer = 40 To 45
                If lbldaysleft.Text < j = True Then
                    lbldaysleft.ForeColor = Color.Red
                    lblyou.ForeColor = Color.Red
                    lblsub.ForeColor = Color.Red
                End If
            Next j

            For k As Integer = 0 To 0
                If lbldaysleft.Text = k = True Then
                    MsgBox("Subcription expired. Call 059 458 9329 / 020 069 0372")
                    Application.Exit()
                End If
            Next


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Try
            Stock2ListForm.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class
Public Class BankReconciliation

    Dim bnk As New BankClass

    Private Sub BankReconciliation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            bnk.GetEquAccName()
            bnk.GetAccName()
            bnk.GetBanks()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbobank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbobank.SelectedIndexChanged
        Try
            bnk.GetBankReconAccNum()
            bnk.GetBankOpenBal()
            bnk.GetBankCurBal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboaccname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboaccname.SelectedIndexChanged
        Try
            bnk.GetBankReconAccNum()
            bnk.GetBankOpenBal()
            bnk.GetBankCurBal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboinexp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboinexp.SelectedIndexChanged
        Try
            bnk.GetCheckAcc()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsavenew_Click(sender As Object, e As EventArgs) Handles btnsavenew.Click
        Try

            dtdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdate.Properties.CharacterCasing = CharacterCasing.Upper

            If txtcheck.Text = "REV" = True Then
                bnk.InsertBankRecoDebit()
                bnk.InsertTransBnkReconDebit()
                bnk.InsertTransBnkReconCredit()
            End If
        Catch ex As Exception

        End Try

        Try
            If txtcheck.Text = "EXP" = True Then
                bnk.InsertBankRecoCredit()
                bnk.InsertTransBnkReconDebit1()
                bnk.InsertTransBnkReconCredit1()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Try
            bnk.clearRecon()
        Catch ex As Exception

        End Try
    End Sub
End Class
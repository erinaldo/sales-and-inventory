Public Class Deposit

    Dim bnk As New BankClass

    Private Sub Deposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            bnk.GetBanks()
            bnk.GetAccName()
            bnk.GetEquAccName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboaccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboaccount.SelectedIndexChanged
        Try
            bnk.GetDepAccNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsavenew_Click(sender As Object, e As EventArgs) Handles btnsavenew.Click
        Try

            dtdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdate.Properties.CharacterCasing = CharacterCasing.Upper

            If dtdate.Text = "" = True Then
                MsgBox("Select Date")
                dtdate.Focus()
                Exit Sub
            End If

            If cbobank.Text = "" = True Then
                MsgBox("Select Bank")
                cbobank.Focus()
                Exit Sub
            End If

            If cboaccount.Text = "" = True Then
                MsgBox("Select Account Name")
                cboaccount.Focus()
                Exit Sub
            End If

            If cboequity.Text = "" = True Then
                MsgBox("Select Equity Account")
                cboequity.Focus()
                Exit Sub
            End If

            If txtamt.Text = "0.00" = True Then
                MsgBox("Select Emter deposit amount")
                txtamt.Focus()
                Exit Sub
            End If

            If txtMemo.Text = "" = True Then
                MsgBox("Select Emter deposit details")
                txtMemo.Focus()
                Exit Sub
            End If

            bnk.InsertBankDepodit()
            bnk.InsertDepositdebit()
            bnk.InsertDepositcredit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsaveclose_Click(sender As Object, e As EventArgs)
        Try

            dtdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdate.Properties.CharacterCasing = CharacterCasing.Upper

            If dtdate.Text = "" = True Then
                MsgBox("Select Date")
                dtdate.Focus()
                Exit Sub
            End If

            If cbobank.Text = "" = True Then
                MsgBox("Select Bank")
                cbobank.Focus()
                Exit Sub
            End If

            If cboaccount.Text = "" = True Then
                MsgBox("Select Account Name")
                cboaccount.Focus()
                Exit Sub
            End If

            If cboequity.Text = "" = True Then
                MsgBox("Select Equity Account")
                cboequity.Focus()
                Exit Sub
            End If

            If txtamt.Text = "0.00" = True Then
                MsgBox("Select Emter deposit amount")
                txtamt.Focus()
                Exit Sub
            End If

            If txtMemo.Text = "" = True Then
                MsgBox("Select Emter deposit details")
                txtMemo.Focus()
                Exit Sub
            End If

            bnk.InsertBankDepodit()
            bnk.InsertDepositdebit()
            bnk.InsertDepositcredit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        Try
            bnk.ClearDeposit()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbobank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbobank.SelectedIndexChanged
        Try
            bnk.GetDepAccNum()
        Catch ex As Exception

        End Try
    End Sub
End Class
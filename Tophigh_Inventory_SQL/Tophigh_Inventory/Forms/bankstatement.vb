Public Class bankstatement

    Dim bnk As New BankClass
    Private Sub bankstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            bnk.CompInfo()
            bnk.GetBanks()
            bnk.GetAccName()
            bnk.GetBankStatement()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            datefrom.Format = DateTimePickerFormat.Custom
            datefrom.CustomFormat = "yyyy-MM-dd"

            dateto.Format = DateTimePickerFormat.Custom
            dateto.CustomFormat = "yyyy-MM-dd"

            If rboDate.Checked = True Then
                If cboaccount.Text = "" = False And cbobank.Text = "" = False Then
                    bnk.GetBankStatementbyDate()
                Else
                    MsgBox("Select Bank and Account Name")
                    cbobank.Focus()
                    Exit Sub
                End If
            Else
                bnk.GetBankStatement()
            End If

            rboDate.Checked = False

        Catch ex As Exception

        End Try
    End Sub

    Private Sub bankstatement_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboaccount_TextChanged(sender As Object, e As EventArgs) Handles cboaccount.TextChanged
        Try
            bnk.GetAccNum
        Catch ex As Exception

        End Try
    End Sub
End Class
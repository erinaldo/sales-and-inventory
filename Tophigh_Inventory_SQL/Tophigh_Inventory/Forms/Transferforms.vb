Public Class Transferforms

    Dim bnk As New BankClass

    Private Sub Transferforms_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            bnk.GetBanks()
            bnk.GetAccName()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAccFrom_TextChanged(sender As Object, e As EventArgs) Handles cboAccFrom.TextChanged
        Try
            bnk.GetFromAccNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAccTo_TextChanged(sender As Object, e As EventArgs) Handles cboAccTo.TextChanged
        Try
            bnk.GetToAccNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbobnkto_TextChanged(sender As Object, e As EventArgs) Handles cbobnkto.TextChanged
        Try
            bnk.GetToAccNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbobnkfrom_TextChanged(sender As Object, e As EventArgs) Handles cbobnkfrom.TextChanged
        Try
            bnk.GetFromAccNum()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveNew_Click(sender As Object, e As EventArgs) Handles btnSaveNew.Click
        Try

            dtdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdate.Properties.CharacterCasing = CharacterCasing.Upper

            bnk.InsertBankTransTo()
            bnk.InsertBankTransfrom()
            bnk.InsertTransdebit()
            bnk.InsertTransCredit()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveClose_Click(sender As Object, e As EventArgs) Handles btnSaveClose.Click
        Try

            dtdate.Properties.Mask.Culture = New System.Globalization.CultureInfo("en-US")
            dtdate.Properties.Mask.EditMask = "yyyy-MM-dd"
            dtdate.Properties.Mask.UseMaskAsDisplayFormat = True
            dtdate.Properties.CharacterCasing = CharacterCasing.Upper

            bnk.InsertBankTransTo()
            bnk.InsertBankTransfrom()
            bnk.InsertTransdebit()
            bnk.InsertTransCredit()

        Catch ex As Exception

        End Try
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            bnk.clearMeData()
        Catch ex As Exception

        End Try
    End Sub
End Class
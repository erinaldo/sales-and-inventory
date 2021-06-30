Public Class SearchSupInv

    Dim spb As New SuppliersClass

    Private Sub SearchSupInv_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            spb.CompInfo()
            spb.FillSup()
            spb.GetSupBillsbyID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbosup_TextChanged(sender As Object, e As EventArgs) Handles cbosup.TextChanged
        Try
            spb.GetSupidsch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcustid_TextChanged(sender As Object, e As EventArgs) Handles txtcustid.TextChanged
        Try
            spb.GetCustInfoSch()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchSupInv_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try

            dtDate.Format = DateTimePickerFormat.Custom
            dtDate.CustomFormat = "yyyy-MM-dd"

            If rboBill.Checked = True Then
                If cbosup.Text = "" = False And txtbillid.Text = "" = False Then
                    spb.GetSupBillsbyID()
                Else
                    MsgBox("Select Supplier and enter bill ID")
                    Exit Sub
                End If
            End If

            If rboDate.Checked = True Then
                If cbosup.Text = "" = False Then
                    spb.GetSupBillsbyDate()
                Else
                    MsgBox("Select Supplie")
                    Exit Sub
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
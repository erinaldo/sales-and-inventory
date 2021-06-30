Public Class SalesInvoiceForm

    Dim csal As New InvoiceClass

    Private Sub SalesInvoiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            csal.Getlocation()
            csal.CompInfo()
            csal.GetInvoicebyID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Invoice_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Try
            Me.Height = MainForm.sidepanel.Height - 17
            Me.Width = MainForm.toppanel.Width - 7
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcustname_TextChanged(sender As Object, e As EventArgs) Handles txtcustname.TextChanged
        Try
            csal.GetOtherInvcustid()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtcustid_TextChanged(sender As Object, e As EventArgs) Handles txtcustid.TextChanged
        Try
            csal.GetOtherInvCustInfo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click

        dtDate.Format = DateTimePickerFormat.Custom
        dtDate.CustomFormat = "yyyy-MM-dd"

        Try

            If rbodate.Checked = True And cbolocation.Text = "" = False Then

                csal.GetInvoicIDbyDate()
                csal.GetInvoicebyDate()
            End If

            If rboinv.Checked = True And txtInvNo.Text = "" = False And cbolocation.Text = "" = False Then
                csal.GetInvoicIDbyID()
                csal.GetInvoicebyID()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnrefresh_Click(sender As Object, e As EventArgs) Handles btnrefresh.Click
        Try
            csal.GetInvoicIDbyID()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Txtnum_TextChanged(sender As Object, e As EventArgs) Handles txtnum.TextChanged

    End Sub

    Private Sub TxtInvNo_TextChanged(sender As Object, e As EventArgs) Handles txtInvNo.TextChanged

    End Sub
End Class
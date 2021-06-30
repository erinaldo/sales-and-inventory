<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SubscriptionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbldays = New System.Windows.Forms.Label()
        Me.cbostatus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtto = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnupdate = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsubscribe = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnupdate)
        Me.GroupBox1.Controls.Add(Me.btnsubscribe)
        Me.GroupBox1.Controls.Add(Me.cbostatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtfrom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lbldays)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 135)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " System Subdcription "
        '
        'lbldays
        '
        Me.lbldays.AutoSize = True
        Me.lbldays.Location = New System.Drawing.Point(60, 106)
        Me.lbldays.Name = "lbldays"
        Me.lbldays.Size = New System.Drawing.Size(13, 13)
        Me.lbldays.TabIndex = 7
        Me.lbldays.Text = "0"
        '
        'cbostatus
        '
        Me.cbostatus.FormattingEnabled = True
        Me.cbostatus.Items.AddRange(New Object() {"Subscribed", "Expired"})
        Me.cbostatus.Location = New System.Drawing.Point(85, 74)
        Me.cbostatus.Name = "cbostatus"
        Me.cbostatus.Size = New System.Drawing.Size(121, 21)
        Me.cbostatus.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Status :"
        '
        'dtto
        '
        Me.dtto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtto.Location = New System.Drawing.Point(85, 48)
        Me.dtto.Name = "dtto"
        Me.dtto.Size = New System.Drawing.Size(121, 20)
        Me.dtto.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date To :"
        '
        'dtfrom
        '
        Me.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtfrom.Location = New System.Drawing.Point(85, 22)
        Me.dtfrom.Name = "dtfrom"
        Me.dtfrom.Size = New System.Drawing.Size(121, 20)
        Me.dtfrom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date From :"
        '
        'btnupdate
        '
        Me.btnupdate.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.updatefield_16x16
        Me.btnupdate.Location = New System.Drawing.Point(132, 101)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(75, 23)
        Me.btnupdate.TabIndex = 8
        Me.btnupdate.Text = "Update"
        '
        'btnsubscribe
        '
        Me.btnsubscribe.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.bosale_16x162
        Me.btnsubscribe.Location = New System.Drawing.Point(39, 101)
        Me.btnsubscribe.Name = "btnsubscribe"
        Me.btnsubscribe.Size = New System.Drawing.Size(75, 23)
        Me.btnsubscribe.TabIndex = 6
        Me.btnsubscribe.Text = "Subscribe"
        '
        'SubscriptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(337, 162)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SubscriptionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Subscription"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnsubscribe As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cbostatus As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtto As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtfrom As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents lbldays As Label
    Friend WithEvents btnupdate As DevExpress.XtraEditors.SimpleButton
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiscalYearForm
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
        Me.CalendarControl1 = New DevExpress.XtraEditors.Controls.CalendarControl()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.btnCanael = New DevExpress.XtraEditors.SimpleButton()
        Me.btnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.dtGetDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.dtSysDate = New System.Windows.Forms.DateTimePicker()
        Me.dtEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtYearName = New System.Windows.Forms.TextBox()
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CalendarControl1
        '
        Me.CalendarControl1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CalendarControl1.Location = New System.Drawing.Point(41, 166)
        Me.CalendarControl1.Name = "CalendarControl1"
        Me.CalendarControl1.Size = New System.Drawing.Size(257, 227)
        Me.CalendarControl1.TabIndex = 25
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(101, 308)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 24
        Me.txtID.Visible = False
        '
        'btnCanael
        '
        Me.btnCanael.Enabled = False
        Me.btnCanael.Location = New System.Drawing.Point(168, 399)
        Me.btnCanael.Name = "btnCanael"
        Me.btnCanael.Size = New System.Drawing.Size(85, 34)
        Me.btnCanael.TabIndex = 23
        Me.btnCanael.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Enabled = False
        Me.btnOK.Location = New System.Drawing.Point(54, 399)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 34)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        '
        'dtGetDate
        '
        Me.dtGetDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtGetDate.Location = New System.Drawing.Point(54, 199)
        Me.dtGetDate.Name = "dtGetDate"
        Me.dtGetDate.Size = New System.Drawing.Size(200, 20)
        Me.dtGetDate.TabIndex = 21
        Me.dtGetDate.Visible = False
        '
        'txtDays
        '
        Me.txtDays.Location = New System.Drawing.Point(101, 272)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(102, 20)
        Me.txtDays.TabIndex = 20
        Me.txtDays.Visible = False
        '
        'dtSysDate
        '
        Me.dtSysDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtSysDate.Location = New System.Drawing.Point(54, 235)
        Me.dtSysDate.Name = "dtSysDate"
        Me.dtSysDate.Size = New System.Drawing.Size(200, 20)
        Me.dtSysDate.TabIndex = 19
        Me.dtSysDate.Visible = False
        '
        'dtEndDate
        '
        Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtEndDate.Location = New System.Drawing.Point(41, 139)
        Me.dtEndDate.Name = "dtEndDate"
        Me.dtEndDate.Size = New System.Drawing.Size(232, 20)
        Me.dtEndDate.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(38, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Ending Date"
        '
        'dtStartDate
        '
        Me.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStartDate.Location = New System.Drawing.Point(41, 85)
        Me.dtStartDate.Name = "dtStartDate"
        Me.dtStartDate.Size = New System.Drawing.Size(232, 20)
        Me.dtStartDate.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(38, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Starting Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(38, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Fiscal Year Name"
        '
        'txtYearName
        '
        Me.txtYearName.Location = New System.Drawing.Point(41, 34)
        Me.txtYearName.Name = "txtYearName"
        Me.txtYearName.Size = New System.Drawing.Size(232, 20)
        Me.txtYearName.TabIndex = 13
        '
        'FiscalYearForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 450)
        Me.Controls.Add(Me.CalendarControl1)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.btnCanael)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.dtGetDate)
        Me.Controls.Add(Me.txtDays)
        Me.Controls.Add(Me.dtSysDate)
        Me.Controls.Add(Me.dtEndDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtStartDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtYearName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FiscalYearForm"
        Me.Text = "Fiscal Year"
        CType(Me.CalendarControl1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CalendarControl1 As DevExpress.XtraEditors.Controls.CalendarControl
    Friend WithEvents txtID As TextBox
    Friend WithEvents btnCanael As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dtGetDate As DateTimePicker
    Friend WithEvents txtDays As TextBox
    Friend WithEvents dtSysDate As DateTimePicker
    Friend WithEvents dtEndDate As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents dtStartDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtYearName As TextBox
End Class

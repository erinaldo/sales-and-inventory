<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewChartForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewChartForm))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboFlow = New System.Windows.Forms.ComboBox()
        Me.txtAcName = New System.Windows.Forms.TextBox()
        Me.txtAcGroup = New System.Windows.Forms.TextBox()
        Me.txtAcCode = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtid = New System.Windows.Forms.TextBox()
        Me.txtcashtype = New System.Windows.Forms.TextBox()
        Me.txtAcSubGroup = New System.Windows.Forms.TextBox()
        Me.txtAcCate = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbooex = New System.Windows.Forms.RadioButton()
        Me.rbocogs = New System.Windows.Forms.RadioButton()
        Me.rboope = New System.Windows.Forms.RadioButton()
        Me.rborev = New System.Windows.Forms.RadioButton()
        Me.rboequ = New System.Windows.Forms.RadioButton()
        Me.rbodeb = New System.Windows.Forms.RadioButton()
        Me.rbopy = New System.Windows.Forms.RadioButton()
        Me.rboacm = New System.Windows.Forms.RadioButton()
        Me.rbofa = New System.Windows.Forms.RadioButton()
        Me.rbope = New System.Windows.Forms.RadioButton()
        Me.rboinv = New System.Windows.Forms.RadioButton()
        Me.rborc = New System.Windows.Forms.RadioButton()
        Me.rbocua = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btndelete = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsave = New DevExpress.XtraEditors.SimpleButton()
        Me.btnrefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.btnclose = New DevExpress.XtraEditors.SimpleButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboFlow)
        Me.GroupBox1.Controls.Add(Me.txtAcName)
        Me.GroupBox1.Controls.Add(Me.txtAcGroup)
        Me.GroupBox1.Controls.Add(Me.txtAcCode)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtid)
        Me.GroupBox1.Controls.Add(Me.txtcashtype)
        Me.GroupBox1.Controls.Add(Me.txtAcSubGroup)
        Me.GroupBox1.Controls.Add(Me.txtAcCate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 212)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 155)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Account"
        '
        'cboFlow
        '
        Me.cboFlow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboFlow.FormattingEnabled = True
        Me.cboFlow.Items.AddRange(New Object() {"CASH FLOWS FROM OPERATING ACTIVITIES Cash Receipts", "CASH FLOWS FROM OPERATING ACTIVITIES Cash Payments", "CASH FLOWS FROM INVESTING ACTIVITIES Sale of Assets", "CASH FLOWS FROM INVESTING ACTIVITIES Purchase of Assets", "CASH FLOWS FROM FINANCING ACTIVITIES Cash Receipts", "CASH FLOWS FROM FINANCING ACTIVITIES Cash Paid", "CASH FLOWS FROM CURRENT ASSETS"})
        Me.cboFlow.Location = New System.Drawing.Point(115, 110)
        Me.cboFlow.Name = "cboFlow"
        Me.cboFlow.Size = New System.Drawing.Size(526, 21)
        Me.cboFlow.TabIndex = 11
        '
        'txtAcName
        '
        Me.txtAcName.Location = New System.Drawing.Point(115, 58)
        Me.txtAcName.Name = "txtAcName"
        Me.txtAcName.Size = New System.Drawing.Size(526, 20)
        Me.txtAcName.TabIndex = 3
        '
        'txtAcGroup
        '
        Me.txtAcGroup.Location = New System.Drawing.Point(115, 84)
        Me.txtAcGroup.Name = "txtAcGroup"
        Me.txtAcGroup.ReadOnly = True
        Me.txtAcGroup.Size = New System.Drawing.Size(526, 20)
        Me.txtAcGroup.TabIndex = 5
        '
        'txtAcCode
        '
        Me.txtAcCode.Location = New System.Drawing.Point(115, 32)
        Me.txtAcCode.Name = "txtAcCode"
        Me.txtAcCode.ReadOnly = True
        Me.txtAcCode.Size = New System.Drawing.Size(526, 20)
        Me.txtAcCode.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 113)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "A/c Cash Flow :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A/c Group :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "A/c Name :"
        '
        'txtid
        '
        Me.txtid.Location = New System.Drawing.Point(484, 32)
        Me.txtid.Name = "txtid"
        Me.txtid.Size = New System.Drawing.Size(100, 20)
        Me.txtid.TabIndex = 3
        '
        'txtcashtype
        '
        Me.txtcashtype.Location = New System.Drawing.Point(392, 84)
        Me.txtcashtype.Name = "txtcashtype"
        Me.txtcashtype.Size = New System.Drawing.Size(100, 20)
        Me.txtcashtype.TabIndex = 12
        '
        'txtAcSubGroup
        '
        Me.txtAcSubGroup.Location = New System.Drawing.Point(210, 84)
        Me.txtAcSubGroup.Name = "txtAcSubGroup"
        Me.txtAcSubGroup.Size = New System.Drawing.Size(147, 20)
        Me.txtAcSubGroup.TabIndex = 7
        '
        'txtAcCate
        '
        Me.txtAcCate.Location = New System.Drawing.Point(304, 32)
        Me.txtAcCate.Name = "txtAcCate"
        Me.txtAcCate.Size = New System.Drawing.Size(109, 20)
        Me.txtAcCate.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "A/c Code :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbooex)
        Me.GroupBox2.Controls.Add(Me.rbocogs)
        Me.GroupBox2.Controls.Add(Me.rboope)
        Me.GroupBox2.Controls.Add(Me.rborev)
        Me.GroupBox2.Controls.Add(Me.rboequ)
        Me.GroupBox2.Controls.Add(Me.rbodeb)
        Me.GroupBox2.Controls.Add(Me.rbopy)
        Me.GroupBox2.Controls.Add(Me.rboacm)
        Me.GroupBox2.Controls.Add(Me.rbofa)
        Me.GroupBox2.Controls.Add(Me.rbope)
        Me.GroupBox2.Controls.Add(Me.rboinv)
        Me.GroupBox2.Controls.Add(Me.rborc)
        Me.GroupBox2.Controls.Add(Me.rbocua)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(526, 194)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Chart of Accounts Group :"
        '
        'rbooex
        '
        Me.rbooex.AutoSize = True
        Me.rbooex.Location = New System.Drawing.Point(352, 167)
        Me.rbooex.Name = "rbooex"
        Me.rbooex.Size = New System.Drawing.Size(123, 17)
        Me.rbooex.TabIndex = 1
        Me.rbooex.TabStop = True
        Me.rbooex.Text = "OTHER EXPENSES"
        Me.rbooex.UseVisualStyleBackColor = True
        '
        'rbocogs
        '
        Me.rbocogs.AutoSize = True
        Me.rbocogs.Location = New System.Drawing.Point(352, 121)
        Me.rbocogs.Name = "rbocogs"
        Me.rbocogs.Size = New System.Drawing.Size(140, 17)
        Me.rbocogs.TabIndex = 0
        Me.rbocogs.TabStop = True
        Me.rbocogs.Text = "COST of GOODS SOLD"
        Me.rbocogs.UseVisualStyleBackColor = True
        '
        'rboope
        '
        Me.rboope.AutoSize = True
        Me.rboope.Location = New System.Drawing.Point(352, 144)
        Me.rboope.Name = "rboope"
        Me.rboope.Size = New System.Drawing.Size(148, 17)
        Me.rboope.TabIndex = 0
        Me.rboope.TabStop = True
        Me.rboope.Text = "OPERATING EXPENSES"
        Me.rboope.UseVisualStyleBackColor = True
        '
        'rborev
        '
        Me.rborev.AutoSize = True
        Me.rborev.Location = New System.Drawing.Point(352, 98)
        Me.rborev.Name = "rborev"
        Me.rborev.Size = New System.Drawing.Size(77, 17)
        Me.rborev.TabIndex = 0
        Me.rborev.TabStop = True
        Me.rborev.Text = "REVENUE"
        Me.rborev.UseVisualStyleBackColor = True
        '
        'rboequ
        '
        Me.rboequ.AutoSize = True
        Me.rboequ.Location = New System.Drawing.Point(352, 75)
        Me.rboequ.Name = "rboequ"
        Me.rboequ.Size = New System.Drawing.Size(75, 17)
        Me.rboequ.TabIndex = 0
        Me.rboequ.TabStop = True
        Me.rboequ.Text = "EQUITIES"
        Me.rboequ.UseVisualStyleBackColor = True
        '
        'rbodeb
        '
        Me.rbodeb.AutoSize = True
        Me.rbodeb.Location = New System.Drawing.Point(352, 52)
        Me.rbodeb.Name = "rbodeb"
        Me.rbodeb.Size = New System.Drawing.Size(61, 17)
        Me.rbodeb.TabIndex = 1
        Me.rbodeb.TabStop = True
        Me.rbodeb.Text = "DEBTS"
        Me.rbodeb.UseVisualStyleBackColor = True
        '
        'rbopy
        '
        Me.rbopy.AutoSize = True
        Me.rbopy.Location = New System.Drawing.Point(352, 29)
        Me.rbopy.Name = "rbopy"
        Me.rbopy.Size = New System.Drawing.Size(80, 17)
        Me.rbopy.TabIndex = 0
        Me.rbopy.TabStop = True
        Me.rbopy.Text = "PAYABLES"
        Me.rbopy.UseVisualStyleBackColor = True
        '
        'rboacm
        '
        Me.rboacm.AutoSize = True
        Me.rboacm.Location = New System.Drawing.Point(18, 144)
        Me.rboacm.Name = "rboacm"
        Me.rboacm.Size = New System.Drawing.Size(295, 17)
        Me.rboacm.TabIndex = 5
        Me.rboacm.TabStop = True
        Me.rboacm.Text = "ACCUMULATED DEPRECIATION and AMORTIZATION"
        Me.rboacm.UseVisualStyleBackColor = True
        '
        'rbofa
        '
        Me.rbofa.AutoSize = True
        Me.rbofa.Location = New System.Drawing.Point(18, 121)
        Me.rbofa.Name = "rbofa"
        Me.rbofa.Size = New System.Drawing.Size(101, 17)
        Me.rbofa.TabIndex = 4
        Me.rbofa.TabStop = True
        Me.rbofa.Text = "FIXED ASSETS"
        Me.rbofa.UseVisualStyleBackColor = True
        '
        'rbope
        '
        Me.rbope.AutoSize = True
        Me.rbope.Location = New System.Drawing.Point(18, 98)
        Me.rbope.Name = "rbope"
        Me.rbope.Size = New System.Drawing.Size(132, 17)
        Me.rbope.TabIndex = 3
        Me.rbope.TabStop = True
        Me.rbope.Text = "PREPAID EXPENSES"
        Me.rbope.UseVisualStyleBackColor = True
        '
        'rboinv
        '
        Me.rboinv.AutoSize = True
        Me.rboinv.Location = New System.Drawing.Point(18, 75)
        Me.rboinv.Name = "rboinv"
        Me.rboinv.Size = New System.Drawing.Size(98, 17)
        Me.rboinv.TabIndex = 2
        Me.rboinv.TabStop = True
        Me.rboinv.Text = "INVENTORIES"
        Me.rboinv.UseVisualStyleBackColor = True
        '
        'rborc
        '
        Me.rborc.AutoSize = True
        Me.rborc.Location = New System.Drawing.Point(18, 52)
        Me.rborc.Name = "rborc"
        Me.rborc.Size = New System.Drawing.Size(98, 17)
        Me.rborc.TabIndex = 1
        Me.rborc.TabStop = True
        Me.rborc.Text = "RECEIVABLES"
        Me.rborc.UseVisualStyleBackColor = True
        '
        'rbocua
        '
        Me.rbocua.AutoSize = True
        Me.rbocua.Location = New System.Drawing.Point(18, 29)
        Me.rbocua.Name = "rbocua"
        Me.rbocua.Size = New System.Drawing.Size(123, 17)
        Me.rbocua.TabIndex = 0
        Me.rbocua.TabStop = True
        Me.rbocua.Text = "CURRENT ASSETS"
        Me.rbocua.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btndelete)
        Me.GroupBox3.Controls.Add(Me.btnsave)
        Me.GroupBox3.Controls.Add(Me.btnrefresh)
        Me.GroupBox3.Controls.Add(Me.btnclose)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 371)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(686, 78)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btndelete
        '
        Me.btndelete.ImageOptions.Image = CType(resources.GetObject("btndelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btndelete.Location = New System.Drawing.Point(430, 19)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(118, 47)
        Me.btndelete.TabIndex = 3
        Me.btndelete.Text = "Delete"
        '
        'btnsave
        '
        Me.btnsave.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.save_32x322
        Me.btnsave.Location = New System.Drawing.Point(182, 19)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(118, 47)
        Me.btnsave.TabIndex = 2
        Me.btnsave.Text = "Save"
        '
        'btnrefresh
        '
        Me.btnrefresh.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.refresh_32x327
        Me.btnrefresh.Location = New System.Drawing.Point(306, 19)
        Me.btnrefresh.Name = "btnrefresh"
        Me.btnrefresh.Size = New System.Drawing.Size(118, 47)
        Me.btnrefresh.TabIndex = 1
        Me.btnrefresh.Text = "Refresh"
        '
        'btnclose
        '
        Me.btnclose.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.close_32x328
        Me.btnclose.Location = New System.Drawing.Point(554, 19)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(118, 47)
        Me.btnclose.TabIndex = 0
        Me.btnclose.Text = "Close"
        '
        'NewChartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(686, 449)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "NewChartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "New Account"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtcashtype As TextBox
    Friend WithEvents cboFlow As ComboBox
    Friend WithEvents txtAcSubGroup As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAcCate As TextBox
    Friend WithEvents txtAcGroup As TextBox
    Friend WithEvents txtAcName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtAcCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rboacm As RadioButton
    Friend WithEvents rbofa As RadioButton
    Friend WithEvents rbope As RadioButton
    Friend WithEvents rboinv As RadioButton
    Friend WithEvents rborc As RadioButton
    Friend WithEvents rbocua As RadioButton
    Friend WithEvents rbodeb As RadioButton
    Friend WithEvents rbopy As RadioButton
    Friend WithEvents rboequ As RadioButton
    Friend WithEvents rborev As RadioButton
    Friend WithEvents rbocogs As RadioButton
    Friend WithEvents rbooex As RadioButton
    Friend WithEvents rboope As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btndelete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnsave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnrefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnclose As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtid As TextBox
End Class

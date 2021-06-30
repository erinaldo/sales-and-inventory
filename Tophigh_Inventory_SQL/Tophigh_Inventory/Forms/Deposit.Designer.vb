<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Deposit
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cbobank = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.cboaccount = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtaccnum = New DevExpress.XtraEditors.TextEdit()
        Me.txtamt = New DevExpress.XtraEditors.TextEdit()
        Me.cboequity = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtMemo = New DevExpress.XtraEditors.MemoEdit()
        Me.dtdate = New DevExpress.XtraEditors.DateEdit()
        Me.btnclear = New DevExpress.XtraEditors.SimpleButton()
        Me.btnsavenew = New DevExpress.XtraEditors.SimpleButton()
        Me.txtlocation = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cbobank.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtaccnum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtamt.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboequity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cbobank)
        Me.LayoutControl1.Controls.Add(Me.cboaccount)
        Me.LayoutControl1.Controls.Add(Me.txtaccnum)
        Me.LayoutControl1.Controls.Add(Me.txtamt)
        Me.LayoutControl1.Controls.Add(Me.cboequity)
        Me.LayoutControl1.Controls.Add(Me.txtMemo)
        Me.LayoutControl1.Controls.Add(Me.dtdate)
        Me.LayoutControl1.Controls.Add(Me.btnclear)
        Me.LayoutControl1.Controls.Add(Me.btnsavenew)
        Me.LayoutControl1.Controls.Add(Me.txtlocation)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem11})
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(604, 371)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cbobank
        '
        Me.cbobank.Location = New System.Drawing.Point(101, 36)
        Me.cbobank.Name = "cbobank"
        Me.cbobank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cbobank.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbobank.Size = New System.Drawing.Size(199, 20)
        Me.cbobank.StyleController = Me.LayoutControl1
        Me.cbobank.TabIndex = 4
        '
        'cboaccount
        '
        Me.cboaccount.Location = New System.Drawing.Point(393, 36)
        Me.cboaccount.Name = "cboaccount"
        Me.cboaccount.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cboaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboaccount.Size = New System.Drawing.Size(199, 20)
        Me.cboaccount.StyleController = Me.LayoutControl1
        Me.cboaccount.TabIndex = 5
        '
        'txtaccnum
        '
        Me.txtaccnum.Location = New System.Drawing.Point(101, 60)
        Me.txtaccnum.Name = "txtaccnum"
        Me.txtaccnum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtaccnum.Properties.ReadOnly = True
        Me.txtaccnum.Size = New System.Drawing.Size(244, 20)
        Me.txtaccnum.StyleController = Me.LayoutControl1
        Me.txtaccnum.TabIndex = 6
        '
        'txtamt
        '
        Me.txtamt.EditValue = "0.00"
        Me.txtamt.Location = New System.Drawing.Point(101, 84)
        Me.txtamt.Name = "txtamt"
        Me.txtamt.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.txtamt.Properties.Appearance.Options.UseFont = True
        Me.txtamt.Properties.Appearance.Options.UseTextOptions = True
        Me.txtamt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtamt.Properties.AppearanceFocused.Options.UseTextOptions = True
        Me.txtamt.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtamt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtamt.Properties.XlsxFormatString = "n2"
        Me.txtamt.Size = New System.Drawing.Size(145, 20)
        Me.txtamt.StyleController = Me.LayoutControl1
        Me.txtamt.TabIndex = 7
        '
        'cboequity
        '
        Me.cboequity.Location = New System.Drawing.Point(101, 108)
        Me.cboequity.Name = "cboequity"
        Me.cboequity.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.cboequity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboequity.Size = New System.Drawing.Size(491, 20)
        Me.cboequity.StyleController = Me.LayoutControl1
        Me.cboequity.TabIndex = 8
        '
        'txtMemo
        '
        Me.txtMemo.Location = New System.Drawing.Point(12, 161)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.txtMemo.Size = New System.Drawing.Size(580, 146)
        Me.txtMemo.StyleController = Me.LayoutControl1
        Me.txtMemo.TabIndex = 9
        '
        'dtdate
        '
        Me.dtdate.EditValue = Nothing
        Me.dtdate.Location = New System.Drawing.Point(101, 12)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.dtdate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtdate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtdate.Size = New System.Drawing.Size(491, 20)
        Me.dtdate.StyleController = Me.LayoutControl1
        Me.dtdate.TabIndex = 10
        '
        'btnclear
        '
        Me.btnclear.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.deletelist2_32x321
        Me.btnclear.Location = New System.Drawing.Point(462, 321)
        Me.btnclear.Name = "btnclear"
        Me.btnclear.Size = New System.Drawing.Size(130, 38)
        Me.btnclear.StyleController = Me.LayoutControl1
        Me.btnclear.TabIndex = 12
        Me.btnclear.Text = "Clear"
        '
        'btnsavenew
        '
        Me.btnsavenew.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.saveas_32x32
        Me.btnsavenew.Location = New System.Drawing.Point(334, 321)
        Me.btnsavenew.Name = "btnsavenew"
        Me.btnsavenew.Size = New System.Drawing.Size(124, 38)
        Me.btnsavenew.StyleController = Me.LayoutControl1
        Me.btnsavenew.TabIndex = 13
        Me.btnsavenew.Text = "Save && New"
        '
        'txtlocation
        '
        Me.txtlocation.Location = New System.Drawing.Point(117, 297)
        Me.txtlocation.Name = "txtlocation"
        Me.txtlocation.Size = New System.Drawing.Size(475, 20)
        Me.txtlocation.StyleController = Me.LayoutControl1
        Me.txtlocation.TabIndex = 14
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtlocation
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 285)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(584, 24)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(50, 20)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem5, Me.EmptySpaceItem4, Me.EmptySpaceItem6, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(604, 371)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cbobank
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(292, 24)
        Me.LayoutControlItem1.Text = "Bank :"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtaccnum
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(337, 24)
        Me.LayoutControlItem3.Text = "Account # :"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtamt
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(238, 24)
        Me.LayoutControlItem4.Text = "Deposit Amount  :"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.cboequity
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(584, 24)
        Me.LayoutControlItem5.Text = "General A/c :"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtMemo
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 133)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(584, 166)
        Me.LayoutControlItem6.Text = "Details"
        Me.LayoutControlItem6.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.dtdate
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(584, 24)
        Me.LayoutControlItem7.Text = "Date Deposit"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(86, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.btnclear
        Me.LayoutControlItem9.Location = New System.Drawing.Point(450, 309)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(134, 42)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.btnsavenew
        Me.LayoutControlItem10.Location = New System.Drawing.Point(322, 309)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(128, 42)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 309)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(322, 42)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 120)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(584, 13)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(337, 48)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(247, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(238, 72)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(346, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 299)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(584, 10)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.cboaccount
        Me.LayoutControlItem2.Location = New System.Drawing.Point(292, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(292, 24)
        Me.LayoutControlItem2.Text = "Account Name :"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(86, 13)
        '
        'Deposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(604, 371)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.Name = "Deposit"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Deposit"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cbobank.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtaccnum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtamt.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboequity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMemo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtdate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cbobank As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents cboaccount As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtaccnum As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtamt As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cboequity As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtMemo As DevExpress.XtraEditors.MemoEdit
    Friend WithEvents dtdate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnclear As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnsavenew As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents txtlocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
End Class

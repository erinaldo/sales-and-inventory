<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StockTransferReportForm
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
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btnReload = New DevExpress.XtraEditors.SimpleButton()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.dgvPushRep = New System.Windows.Forms.DataGridView()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.dgvPushRep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelControl1
        '
        Me.PanelControl1.Appearance.BackColor = System.Drawing.Color.Navy
        Me.PanelControl1.Appearance.Options.UseBackColor = True
        Me.PanelControl1.Controls.Add(Me.btnReload)
        Me.PanelControl1.Controls.Add(Me.btnExport)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(800, 41)
        Me.PanelControl1.TabIndex = 0
        '
        'btnReload
        '
        Me.btnReload.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnReload.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.replace_32x32
        Me.btnReload.Location = New System.Drawing.Point(618, 2)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(90, 37)
        Me.btnReload.TabIndex = 2
        Me.btnReload.Text = "Reload"
        '
        'btnExport
        '
        Me.btnExport.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExport.ImageOptions.Image = Global.Tophigh_Inventory.My.Resources.Resources.exporttoodt_32x321
        Me.btnExport.Location = New System.Drawing.Point(708, 2)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(90, 37)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "Export"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 456)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'dgvPushRep
        '
        Me.dgvPushRep.AllowUserToAddRows = False
        Me.dgvPushRep.AllowUserToDeleteRows = False
        Me.dgvPushRep.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPushRep.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvPushRep.BackgroundColor = System.Drawing.Color.White
        Me.dgvPushRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPushRep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPushRep.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvPushRep.Location = New System.Drawing.Point(0, 41)
        Me.dgvPushRep.Name = "dgvPushRep"
        Me.dgvPushRep.ReadOnly = True
        Me.dgvPushRep.RowHeadersVisible = False
        Me.dgvPushRep.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPushRep.Size = New System.Drawing.Size(800, 415)
        Me.dgvPushRep.TabIndex = 2
        '
        'StockTransferReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 478)
        Me.Controls.Add(Me.dgvPushRep)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.PanelControl1)
        Me.MaximizeBox = False
        Me.Name = "StockTransferReportForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Sotck Transfer Report"
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        CType(Me.dgvPushRep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btnReload As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents dgvPushRep As DataGridView
End Class

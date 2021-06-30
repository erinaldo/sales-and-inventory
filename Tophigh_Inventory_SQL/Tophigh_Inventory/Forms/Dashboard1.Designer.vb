Namespace Win_Dashboards
    Partial Public Class Dashboard1
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim ChartPane1 As DevExpress.DashboardCommon.ChartPane = New DevExpress.DashboardCommon.ChartPane()
            Dim StoredProcQuery1 As DevExpress.DataAccess.Sql.StoredProcQuery = New DevExpress.DataAccess.Sql.StoredProcQuery()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard1))
            Dim DashboardLayoutGroup1 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutGroup2 As DevExpress.DashboardCommon.DashboardLayoutGroup = New DevExpress.DashboardCommon.DashboardLayoutGroup()
            Dim DashboardLayoutItem1 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem2 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Dim DashboardLayoutItem3 As DevExpress.DashboardCommon.DashboardLayoutItem = New DevExpress.DashboardCommon.DashboardLayoutItem()
            Me.GaugeDashboardItem1 = New DevExpress.DashboardCommon.GaugeDashboardItem()
            Me.ChartDashboardItem1 = New DevExpress.DashboardCommon.ChartDashboardItem()
            Me.DashboardSqlDataSource1 = New DevExpress.DashboardCommon.DashboardSqlDataSource()
            Me.CardDashboardItem1 = New DevExpress.DashboardCommon.CardDashboardItem()
            CType(Me.GaugeDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'GaugeDashboardItem1
            '
            Me.GaugeDashboardItem1.ComponentName = "GaugeDashboardItem1"
            Me.GaugeDashboardItem1.DataItemRepository.Clear()
            Me.GaugeDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.GaugeDashboardItem1.Name = "Gauges 1"
            Me.GaugeDashboardItem1.ShowCaption = True
            '
            'ChartDashboardItem1
            '
            Me.ChartDashboardItem1.AxisX.TitleVisible = False
            Me.ChartDashboardItem1.ComponentName = "ChartDashboardItem1"
            Me.ChartDashboardItem1.DataItemRepository.Clear()
            Me.ChartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.ChartDashboardItem1.Name = "Chart 1"
            ChartPane1.Name = "Pane 1"
            ChartPane1.PrimaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.PrimaryAxisY.ShowGridLines = True
            ChartPane1.PrimaryAxisY.TitleVisible = True
            ChartPane1.SecondaryAxisY.AlwaysShowZeroLevel = True
            ChartPane1.SecondaryAxisY.ShowGridLines = False
            ChartPane1.SecondaryAxisY.TitleVisible = True
            Me.ChartDashboardItem1.Panes.AddRange(New DevExpress.DashboardCommon.ChartPane() {ChartPane1})
            Me.ChartDashboardItem1.ShowCaption = True
            '
            'DashboardSqlDataSource1
            '
            Me.DashboardSqlDataSource1.ComponentName = "DashboardSqlDataSource1"
            Me.DashboardSqlDataSource1.ConnectionName = "tophigh_inventory_dbConnectionString"
            Me.DashboardSqlDataSource1.Name = "SQL Data Source 1"
            StoredProcQuery1.Name = "GetPurchaseBySups"
            StoredProcQuery1.StoredProcName = "GetPurchaseBySups"
            Me.DashboardSqlDataSource1.Queries.AddRange(New DevExpress.DataAccess.Sql.SqlQuery() {StoredProcQuery1})
            Me.DashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("DashboardSqlDataSource1.ResultSchemaSerializable")
            '
            'CardDashboardItem1
            '
            Me.CardDashboardItem1.ComponentName = "CardDashboardItem1"
            Me.CardDashboardItem1.DataItemRepository.Clear()
            Me.CardDashboardItem1.InteractivityOptions.IgnoreMasterFilters = False
            Me.CardDashboardItem1.Name = "Cards 1"
            Me.CardDashboardItem1.ShowCaption = True
            '
            'Dashboard1
            '
            Me.DataSources.AddRange(New DevExpress.DashboardCommon.IDashboardDataSource() {Me.DashboardSqlDataSource1})
            Me.Items.AddRange(New DevExpress.DashboardCommon.DashboardItem() {Me.GaugeDashboardItem1, Me.ChartDashboardItem1, Me.CardDashboardItem1})
            DashboardLayoutItem1.DashboardItem = Me.GaugeDashboardItem1
            DashboardLayoutItem1.Weight = 50.083194675540767R
            DashboardLayoutItem2.DashboardItem = Me.ChartDashboardItem1
            DashboardLayoutItem2.Weight = 49.916805324459233R
            DashboardLayoutGroup2.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutItem1, DashboardLayoutItem2})
            DashboardLayoutGroup2.DashboardItem = Nothing
            DashboardLayoutGroup2.Weight = 50.136986301369866R
            DashboardLayoutItem3.DashboardItem = Me.CardDashboardItem1
            DashboardLayoutItem3.Weight = 49.863013698630134R
            DashboardLayoutGroup1.ChildNodes.AddRange(New DevExpress.DashboardCommon.DashboardLayoutNode() {DashboardLayoutGroup2, DashboardLayoutItem3})
            DashboardLayoutGroup1.DashboardItem = Nothing
            DashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical
            DashboardLayoutGroup1.Weight = 100.0R
            Me.LayoutRoot = DashboardLayoutGroup1
            Me.Title.Text = "Dashboard"
            CType(Me.GaugeDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ChartDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DashboardSqlDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.CardDashboardItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents DashboardSqlDataSource1 As DevExpress.DashboardCommon.DashboardSqlDataSource
        Friend WithEvents GaugeDashboardItem1 As DevExpress.DashboardCommon.GaugeDashboardItem
        Friend WithEvents ChartDashboardItem1 As DevExpress.DashboardCommon.ChartDashboardItem
        Friend WithEvents CardDashboardItem1 As DevExpress.DashboardCommon.CardDashboardItem

#End Region
    End Class
End Namespace
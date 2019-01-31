Imports Microsoft.VisualBasic
Imports System
Namespace DXSample
	Partial Public Class Main
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

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
			Me.ordersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.nwindDataSet = New nwindDataSet()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.colOrderID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colCustomerID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colEmployeeID = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colFreight = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.colShipName = New DevExpress.XtraGrid.Columns.GridColumn()
			Me.gridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
            Me.ordersTableAdapter = New nwindDataSetTableAdapters.OrdersTableAdapter()
            CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Money Twins"
			' 
			' gridControl1
			' 
			Me.gridControl1.DataSource = Me.ordersBindingSource
			Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.gridControl1.Location = New System.Drawing.Point(0, 0)
			Me.gridControl1.MainView = Me.gridView1
			Me.gridControl1.Name = "gridControl1"
			Me.gridControl1.Size = New System.Drawing.Size(910, 485)
			Me.gridControl1.TabIndex = 0
			Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.gridView1})
			' 
			' ordersBindingSource
			' 
			Me.ordersBindingSource.DataMember = "Orders"
			Me.ordersBindingSource.DataSource = Me.nwindDataSet
			' 
			' nwindDataSet
			' 
			Me.nwindDataSet.DataSetName = "nwindDataSet"
			Me.nwindDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' gridView1
			' 
			Me.gridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() { Me.colOrderID, Me.colCustomerID, Me.colEmployeeID, Me.colFreight, Me.colShipName, Me.gridColumn1})
			Me.gridView1.GridControl = Me.gridControl1
			Me.gridView1.Name = "gridView1"
'			Me.gridView1.CustomUnboundColumnData += New DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(Me.OnCustomUnboundColumnData);
			' 
			' colOrderID
			' 
			Me.colOrderID.FieldName = "OrderID"
			Me.colOrderID.Name = "colOrderID"
			Me.colOrderID.Visible = True
			Me.colOrderID.VisibleIndex = 0
			' 
			' colCustomerID
			' 
			Me.colCustomerID.FieldName = "CustomerID"
			Me.colCustomerID.Name = "colCustomerID"
			Me.colCustomerID.Visible = True
			Me.colCustomerID.VisibleIndex = 1
			' 
			' colEmployeeID
			' 
			Me.colEmployeeID.FieldName = "EmployeeID"
			Me.colEmployeeID.Name = "colEmployeeID"
			Me.colEmployeeID.Visible = True
			Me.colEmployeeID.VisibleIndex = 2
			' 
			' colFreight
			' 
			Me.colFreight.FieldName = "Freight"
			Me.colFreight.Name = "colFreight"
			Me.colFreight.Visible = True
			Me.colFreight.VisibleIndex = 3
			' 
			' colShipName
			' 
			Me.colShipName.FieldName = "ShipName"
			Me.colShipName.Name = "colShipName"
			Me.colShipName.Visible = True
			Me.colShipName.VisibleIndex = 4
			' 
			' gridColumn1
			' 
			Me.gridColumn1.Caption = "OrderDetails TotalQuantity"
			Me.gridColumn1.FieldName = "Quantity"
			Me.gridColumn1.Name = "gridColumn1"
			Me.gridColumn1.UnboundType = DevExpress.Data.UnboundColumnType.Integer
			Me.gridColumn1.Visible = True
			Me.gridColumn1.VisibleIndex = 5
			' 
			' ordersTableAdapter
			' 
			Me.ordersTableAdapter.ClearBeforeFill = True
			' 
			' Main
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(910, 485)
			Me.Controls.Add(Me.gridControl1)
			Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
			Me.Name = "Main"
			Me.Text = "AsyncLoading"
'			Me.Load += New System.EventHandler(Me.OnFormLoad);
			CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.ordersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.nwindDataSet, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
		Private gridControl1 As DevExpress.XtraGrid.GridControl
		Private WithEvents gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
		Private nwindDataSet As nwindDataSet
		Private ordersBindingSource As System.Windows.Forms.BindingSource
        Private ordersTableAdapter As nwindDataSetTableAdapters.OrdersTableAdapter
        Private colOrderID As DevExpress.XtraGrid.Columns.GridColumn
		Private colCustomerID As DevExpress.XtraGrid.Columns.GridColumn
		Private colEmployeeID As DevExpress.XtraGrid.Columns.GridColumn
		Private colFreight As DevExpress.XtraGrid.Columns.GridColumn
		Private colShipName As DevExpress.XtraGrid.Columns.GridColumn
		Private gridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
	End Class
End Namespace


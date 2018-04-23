Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports System.Data.OleDb
Imports System.Threading
Imports System.Runtime.Remoting.Messaging


Namespace DXSample
	Partial Public Class Main
		Inherits XtraForm
		Private connectionSting As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\nwind.mdb"
		Private unboundValues As New Dictionary(Of Integer, Object)()
		Private Delegate Function GetDataDelegate(ByVal index As Integer) As KeyValuePair(Of Integer, Object)

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Me.ordersTableAdapter.Fill(Me.nwindDataSet.Orders)
		End Sub

		Private Sub OnCustomUnboundColumnData(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles gridView1.CustomUnboundColumnData
			If e.Column.FieldName = "Quantity" Then
				If e.IsGetData Then
					Dim val As Object = GetSummaryValue(e)
					e.Value = val
				End If
			End If
		End Sub

		Private Function GetSummaryValue(ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) As Object
			If unboundValues.ContainsKey(e.ListSourceRowIndex) Then
				Return unboundValues(e.ListSourceRowIndex)
			End If
			unboundValues.Add(e.ListSourceRowIndex, "Not Loaded")
			GetDataAsync(e.ListSourceRowIndex)
			Return unboundValues(e.ListSourceRowIndex)
		End Function

		Private Sub GetDataAsync(ByVal index As Integer)
			Dim d As New GetDataDelegate(AddressOf GetData)
			d.BeginInvoke(index, New AsyncCallback(AddressOf DataLoaded), Nothing)
		End Sub

		Private Function GetData(ByVal index As Integer) As KeyValuePair(Of Integer, Object)
			Dim id As Integer = Convert.ToInt32(nwindDataSet.Orders(index)("OrderID"))
			Dim connection As New OleDbConnection(connectionSting)
			connection.Open()
			Dim cmdText As String = String.Format("SELECT SUM({0}) FROM {1} WHERE {2} = {3}", "Quantity", "OrderDetails", "OrderID", id)
			Dim command As New OleDbCommand(cmdText, connection)
			Dim val As Object = command.ExecuteScalar()
			Thread.Sleep(500)
			connection.Close()
			Return New KeyValuePair(Of Integer, Object)(index, val)
		End Function

		 Private Sub DataLoaded(ByVal r As IAsyncResult)
			Dim d As GetDataDelegate = TryCast((TryCast(r, AsyncResult)).AsyncDelegate, GetDataDelegate)
			Dim pair As KeyValuePair(Of Integer, Object) = CType(d.EndInvoke(r), KeyValuePair(Of Integer, Object))
			unboundValues(pair.Key) = pair.Value
			UpdateGrid()
		 End Sub

		Private Sub UpdateGrid()
			If gridControl1.InvokeRequired Then
                gridControl1.Invoke(New MethodInvoker(AddressOf gridView1.LayoutChanged))
            Else
                gridView1.LayoutChanged()
			End If
		End Sub
	  
    End Class
End Namespace


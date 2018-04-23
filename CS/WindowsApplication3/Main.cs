using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using System.Threading;
using System.Runtime.Remoting.Messaging;


namespace DXSample {
    public partial class Main: XtraForm {
        string connectionSting = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\nwind.mdb";
        Dictionary<int, object> unboundValues = new Dictionary<int, object>();
        private delegate KeyValuePair<int, object> GetDataDelegate(int index);

        public Main() {
            InitializeComponent();
        }

        private void OnFormLoad(object sender, EventArgs e) {
            this.ordersTableAdapter.Fill(this.nwindDataSet.Orders);
        }

        private void OnCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Quantity")
                if (e.IsGetData)
                {
                    object val = GetSummaryValue(e);
                    e.Value = val;
                }
        }

        private object GetSummaryValue(DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (unboundValues.ContainsKey(e.ListSourceRowIndex)) return unboundValues[e.ListSourceRowIndex];
            unboundValues.Add(e.ListSourceRowIndex, "Not Loaded");
            GetDataAsync(e.ListSourceRowIndex);
            return unboundValues[e.ListSourceRowIndex];
        }

        private void GetDataAsync(int index)
        {
            GetDataDelegate d = new GetDataDelegate(GetData);
            d.BeginInvoke(index, new AsyncCallback(DataLoaded), null);
        }

        KeyValuePair<int, object> GetData(int index) {
            int id = Convert.ToInt32(nwindDataSet.Orders[index]["OrderID"]);
            OleDbConnection connection = new OleDbConnection(connectionSting);
            connection.Open();
            string cmdText = string.Format("SELECT SUM({0}) FROM {1} WHERE {2} = {3}", "Quantity", "OrderDetails", "OrderID", id);
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            object val = command.ExecuteScalar();
            Thread.Sleep(500);
            connection.Close();
            return new KeyValuePair<int, object>(index, val);
        }

         void DataLoaded(IAsyncResult r) {
            GetDataDelegate d = (r as AsyncResult).AsyncDelegate as GetDataDelegate;
            KeyValuePair<int, object> pair = (KeyValuePair<int, object>)d.EndInvoke(r);
            unboundValues[pair.Key] = pair.Value;
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            if (gridControl1.InvokeRequired)
                gridControl1.Invoke(new MethodInvoker(delegate{
                    gridView1.LayoutChanged();
                }));
            else
                gridView1.LayoutChanged();
        }
    }
}

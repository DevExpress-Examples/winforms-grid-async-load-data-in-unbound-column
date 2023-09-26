<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128630165/13.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3140)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WinForms Data Grid - Asynchronously load data into an unbound column

This example handles the `CustomUnboundColumnData` event to load data in the `Quantity` unbound column.

```csharp
private void OnCustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
    if (e.Column.FieldName == "Quantity")
        if (e.IsGetData) {
            object val = GetSummaryValue(e);
            e.Value = val;
        }
}
private object GetSummaryValue(DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e) {
    if (unboundValues.ContainsKey(e.ListSourceRowIndex)) return unboundValues[e.ListSourceRowIndex];
    unboundValues.Add(e.ListSourceRowIndex, "Not Loaded");
    GetDataAsync(e.ListSourceRowIndex);
    return unboundValues[e.ListSourceRowIndex];
}
```

`GetDataAsync` asynchronously loads row data:

```csharp
private void GetDataAsync(int index) {
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
```


## Files to Review

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))

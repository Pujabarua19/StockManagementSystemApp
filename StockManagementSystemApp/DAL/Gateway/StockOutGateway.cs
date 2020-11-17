using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.DAL.Gateway
{
    public class StockOutGateway:Gateway
    {
        public int StockOutEntry(string stockOutReason, double quantity, int itemId)                //Storing stock out Quantity
        {
            Query = "INSERT INTO StockOut(StockOutReason,Quantity,ItemId) VALUES(@stockOutReason, @quantity,@itemId)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("StockOutReason", stockOutReason);
            Command.Parameters.AddWithValue("quantity", quantity);
            Command.Parameters.AddWithValue("itemId", itemId);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
    }
}
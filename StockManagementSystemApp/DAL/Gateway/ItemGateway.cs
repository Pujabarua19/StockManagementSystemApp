using StockManagementSystemApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.DAL.Gateway
{
    public class ItemGateway:Gateway
    {
        public int SaveItem(Item item)
        {
            Query = "INSERT INTO Item(ItemName,CompanyId,CategoryId,ReorderLevel) VALUES(@itemName,@companyId,@categoryId,@reorderlaevel)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@itemName", item.ItemName);
            Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            Command.Parameters.AddWithValue("@categoryId", item.CategoryId);
            Command.Parameters.AddWithValue("@reorderlaevel", item.ReorderLevel);
            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAffected;
        }

        public bool IsItemExist(Item item)
        {
             Query =
                "SELECT * FROM CheckItems WHERE "
                    + "ItemName = '" + item.ItemName + "' AND CompanyId = '" + item.CompanyId + "' AND CatagoryId = '" + item.CategoryId + "'";
            
            //Command.Parameters.AddWithValue("@itemName", item.ItemName);
            //Command.Parameters.AddWithValue("@companyId", item.CompanyId);
            //Command.Parameters.AddWithValue("@catagoryId", item.CategoryId);
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            bool hasRow = false;

            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();
             
            return hasRow;
        }

        public List<ItemVM> GetItemsByCompanyId(int companyId)
        {
            Query = "SELECT * FROM CheckItems WHERE CompanyId = @companyId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@companyId", companyId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<ItemVM> itemList = new List<ItemVM>();
            while (Reader.Read())                                           //Reading database row by row
            {
                ItemVM items = new ItemVM();
                items.Id = Convert.ToInt32(Reader["Id"]);
                items.ItemName = Reader["ItemName"].ToString();
                items.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                items.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                items.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                items.CompanyName = (Reader["CompanyName"]).ToString();
                items.CategoryId = Convert.ToInt32(Reader["CatagoryId"]);
                items.CatagoryName = (Reader["CategoryName"]).ToString();

                itemList.Add(items);
            }
            Connection.Close();

            return itemList;
        }
        public ItemVM GetItemByItemId(int itemId)
        {
            Query = "SELECT * FROM CheckItems WHERE  Id = @itemId";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@itemId", itemId);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();

            ItemVM item = new ItemVM();
            item.Id = Convert.ToInt32(Reader["Id"]);
            item.ItemName = Reader["ItemName"].ToString();
            item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
            item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
            item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
            item.CompanyName = (Reader["CompanyName"]).ToString();
            item.CategoryId = Convert.ToInt32(Reader["CatagoryId"]);
            item.CatagoryName = (Reader["CategoryName"]).ToString();

            Connection.Close();

            return item;
        }

        public int StockUpdate(double totalQuantity, int itemId)
        {
            Query = "UPDATE Item SET AvailableQuantity = @totalQuantity WHERE Id = @id";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@totalQuantity", totalQuantity);
            Command.Parameters.AddWithValue("@id", itemId);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();

            return rowAffected;
        }
    }
}
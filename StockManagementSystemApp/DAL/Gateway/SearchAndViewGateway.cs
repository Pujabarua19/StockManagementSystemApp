using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemApp.DAL.Model;
using System.Data.SqlClient;

namespace StockManagementSystemApp.DAL.Gateway
{
    public class SearchAndViewGateway:Gateway
    {
        public List<ItemVM> GetItemsByCatagoryId(int catagoryId)
        {
            Query = "SELECT * FROM CheckItems WHERE CatagoryId = @catagoryId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@catagoryId", catagoryId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<ItemVM> itemList = new List<ItemVM>();
            while (Reader.Read())                                           //Reading database row by row
            {
                ItemVM item = new ItemVM();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.CompanyName = (Reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(Reader["CatagoryId"]);
                item.CatagoryName = (Reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            Connection.Close();

            return itemList;
        }

        public List<ItemVM> GetItemsByCompanyIdAndCatagoryId(int companyId, int catagoryId)
        {
            Query = "SELECT * FROM CheckItems WHERE CompanyId = @companyId AND CatagoryId = @catagoryId";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@companyId", companyId);
            Command.Parameters.AddWithValue("@catagoryId", catagoryId);
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (!Reader.HasRows)
            {
                Connection.Close();
                return null;
            }
            List<ItemVM> itemList = new List<ItemVM>();
            while (Reader.Read())                                           //Reading database row by row
            {
                ItemVM item = new ItemVM();
                item.Id = Convert.ToInt32(Reader["Id"]);
                item.ItemName = Reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                item.CompanyName = (Reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(Reader["CatagoryId"]);
                item.CatagoryName = (Reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            Connection.Close();

            return itemList;
        }

        //public List<ItemVM> GetAllItems()
        //{
        //    Query = "SELECT * FROM CheckItems";
        //    Command = new SqlCommand(Query, Connection);

        //    Connection.Open();
        //    Reader = Command.ExecuteReader();

        //    if (!Reader.HasRows)
        //    {
        //        Connection.Close();
        //        return null;
        //    }
        //    List<ItemVM> itemList = new List<ItemVM>();
        //    while (Reader.Read())                                           //Reading database row by row
        //    {
        //        ItemVM item = new ItemVM();
        //        item.Id = Convert.ToInt32(Reader["Id"]);
        //        item.ItemName = Reader["ItemName"].ToString();
        //        item.ReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
        //        item.AvailableQuantity = Convert.ToInt32(Reader["AvailableQuantity"]);
        //        item.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
        //        item.CompanyName = (Reader["CompanyName"]).ToString();
        //        item.CategoryId = Convert.ToInt32(Reader["CatagoryId"]);
        //        item.CatagoryName = (Reader["CategoryName"]).ToString();

        //        itemList.Add(item);
        //    }
        //    Connection.Close();

        //    return itemList;
        //}
    }
}
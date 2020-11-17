using StockManagementSystemApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.DAL.Gateway
{
    public class CategoryGateway :Gateway
    {

        public List<Category> GetAllCategorys(string CategoryName)
        {

            Query = "SELECT * FROM Category";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Category> Categorys = new List<Category>();

            while (Reader.Read())
            {
                Category aCategory = new Category();
                aCategory.Id = (int)Reader["Id"];
                aCategory.CategoryName = Reader["CategoryName"].ToString();



                Categorys.Add(aCategory);
            }
            Connection.Close();
            Reader.Close();
            return Categorys;
        }


    }
}
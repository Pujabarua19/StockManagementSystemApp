using StockManagementSystemApp.DAL.Model;
using StockManagementSystemApp.DAL.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class CategoryManager
    {

        CategoryGateway aCategoryGateway = new CategoryGateway();
        public List<Category> GetAllCategorys(string CategoryName)
        {
            return aCategoryGateway.GetAllCategorys(CategoryName);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystemApp.DAL.Gateway;
using StockManagementSystemApp.DAL.Model;

namespace StockManagementSystemApp.BLL
{
    public class SearchAndViewManager
    {
        SearchAndViewGateway searchAndViewGateway = new SearchAndViewGateway();

        public List<ItemVM> GetItemsByCatagoryId(int catagoryId)
        {
            return searchAndViewGateway.GetItemsByCatagoryId(catagoryId);
        }

        public List<ItemVM> GetItemsByCompanyIdAndCatagoryId(int companyId, int catagoryId)
        {
            return searchAndViewGateway.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
        }

        //public List<ItemVM> GetAllItems()
        //{
        //    return searchAndViewGateway.GetAllItems();
        //}
    }
}
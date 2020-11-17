using StockManagementSystemApp.DAL.Gateway;
using StockManagementSystemApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{
    public class ItemManager
    {
        ItemGateway itemGateway = new ItemGateway();
        public string SaveItem(Item item)
        {
            if (itemGateway.IsItemExist(item))
            {
                return "Item Already Exist...";
            }
            int rowAffect = itemGateway.SaveItem(item);
            if (rowAffect > 0)
            {
                return "Item Saved Succesfully";
            }
            return "Item Save Failed";
        }

        public List<ItemVM> GetItemsByCompanyId(int companyId)
        {
            return itemGateway.GetItemsByCompanyId(companyId);
        }
        public ItemVM GetItemByItemId(int itemId)
        {
            return itemGateway.GetItemByItemId(itemId);
        }

        public string StockUpdate(double totalQuantity, int itemId)
        {
            if (itemGateway.StockUpdate(totalQuantity, itemId) > 0)
            {
                return "Item Stocked";
            }

            return "Item Stock Failed";
        }
    }
}
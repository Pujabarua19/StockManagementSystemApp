using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.DAL.Model
{
    [Serializable]
    public class ItemVM:Item
    {
        public string CompanyName { get; set; }
        public string CatagoryName { get; set; }
    }
}
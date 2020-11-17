using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemApp.BLL;
using StockManagementSystemApp.DAL.Model;

namespace StockManagementSystemApp.UI
{
    public partial class ItemUI : System.Web.UI.Page
    {
        CategoryManager aCategoryManager = new CategoryManager();
        CompanyManager aCompanyManager = new CompanyManager();
        ItemManager aItemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Category> catagorys = aCategoryManager.GetAllCategorys(" ");
                categoryDropDownList.DataSource = catagorys;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, "Select Catagory");

                List<Company> companies = aCompanyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");
            }
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            item.ItemName = nameTextBox.Text;
            item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);

            messageLabel.Text = aItemManager.SaveItem(item);
        }
    }
}
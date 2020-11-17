using StockManagementSystemApp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystemApp.DAL.Model;

namespace StockManagementSystemApp.UI
{
    public partial class SearchViewUI : System.Web.UI.Page
    {
        private ItemManager aItemManager = new ItemManager();
        private CompanyManager aCompanyManager = new CompanyManager();
        private CategoryManager aCategoryManager = new CategoryManager();
        private SearchAndViewManager aSearchAndViewManager = new SearchAndViewManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                List<Company> companies = aCompanyManager.GetAllCompanies();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "CompanyName";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, "Select Company");

                List<Category> catagorys = aCategoryManager.GetAllCategorys(" ");
                categoryDropDownList.DataSource = catagorys;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "CategoryName";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, "Select Catagory");
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            messageLabel.Text = String.Empty;
            searchAndViewGridView.DataSource = null;
            searchAndViewGridView.DataBind();

            if (companyDropDownList.SelectedIndex != 0 && categoryDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int catagoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                if (aSearchAndViewManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId) != null)
                {
                    searchAndViewGridView.DataSource = aSearchAndViewManager.GetItemsByCompanyIdAndCatagoryId(companyId, catagoryId);
                    searchAndViewGridView.DataBind();

                    companyDropDownList.SelectedIndex = 0;
                    categoryDropDownList.SelectedIndex = 0;
                }
                else
                {
                    messageLabel.Text = "This Catagory Item not present in this Company";
                }
            }
            else if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                if (aItemManager.GetItemsByCompanyId(companyId) == null)
                {
                    messageLabel.Text = "No Items Exist form this Company";
                    return;
                }
                searchAndViewGridView.DataSource = aItemManager.GetItemsByCompanyId(companyId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                categoryDropDownList.SelectedIndex = 0;
            }
            else if (categoryDropDownList.SelectedIndex != 0)
            {
                int catagoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                if (aSearchAndViewManager.GetItemsByCatagoryId(catagoryId) == null)
                {
                    messageLabel.Text = "No Items Exist Form This Catagory";
                    return;
                }
                searchAndViewGridView.DataSource = aSearchAndViewManager.GetItemsByCatagoryId(catagoryId);
                searchAndViewGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                categoryDropDownList.SelectedIndex = 0;
            }

            else
            {
                messageLabel.Text = "Please Select Company OR Category";
            }
            //else
            //{
            //    searchAndViewGridView.DataSource = aSearchAndViewManager.GetAllItems();
            //    searchAndViewGridView.DataBind();
            //}
        }
    }
}
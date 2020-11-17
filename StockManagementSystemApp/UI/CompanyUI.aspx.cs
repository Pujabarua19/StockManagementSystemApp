using StockManagementSystemApp.BLL;
using StockManagementSystemApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementSystemApp.UI
{
    public partial class CompanyUI : System.Web.UI.Page
    {
        CompanyManager aCompanyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany = new Company();
            aCompany.CompanyName = nameTextBox.Text;
            messageLabel.Text = aCompanyManager.Save(aCompany);
            PopulateGridView();
        }
        public void PopulateGridView()
        {
            List<Company> companies = aCompanyManager.GetAllCompanies();
            companiesGridView.DataSource = companies;
            companiesGridView.DataBind();
        }

        
    }
}
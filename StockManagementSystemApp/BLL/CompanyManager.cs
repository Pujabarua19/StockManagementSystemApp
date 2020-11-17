using StockManagementSystemApp.DAL.Gateway;
using StockManagementSystemApp.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystemApp.BLL
{

    public class CompanyManager
    {
        CompanyGateway aCompanyGateway = new CompanyGateway();
        public string Save(Company aCompany) 
        {

            if (aCompanyGateway.IsCompanyNameExists(aCompany.CompanyName))
            {
                return "Company already exists";
            }
            else
            {
                int rowAffected = aCompanyGateway.Save(aCompany);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                else
                {
                    return "Save failed";
                }
            }
        }
        public List<Company> GetAllCompanies()
        {
            return aCompanyGateway.GetAllCompanies();
        }

    }
}
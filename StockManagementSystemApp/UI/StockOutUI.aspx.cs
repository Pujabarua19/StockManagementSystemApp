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
    public partial class StockOutUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        StockOutManager stockOutManager = new StockOutManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TaskOnFirstLoad();
                companyDropDownList.Items.Insert(0, "Select Company");
                itemDropDownList.Items.Insert(0, "Select Item");
            }

        }

        public void TaskOnFirstLoad()
        {
            companyDropDownList.DataSource = companyManager.GetAllCompanies();
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataTextField = "CompanyName";
            companyDropDownList.DataBind();
            reorderLavelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;
            itemDropDownList.Enabled = false;
            stockOutQuantityTextBox.Enabled = false;
            addButton.Enabled = false;
        }

      
        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                itemDropDownList.Enabled = true;

                itemDropDownList.DataSource = itemManager.GetItemsByCompanyId(companyId);
                itemDropDownList.DataValueField = "Id";
                itemDropDownList.DataTextField = "ItemName";
                itemDropDownList.DataBind();
                itemDropDownList.Items.Insert(0, "Select Item");
            }
            else
            {
                itemDropDownList.SelectedIndex = 0;
                itemDropDownList.Enabled = false;
                stockOutQuantityTextBox.Enabled = false;
                addButton.Enabled = false;
                availableQuantityTextBox.Text = String.Empty;
                reorderLavelTextBox.Text = String.Empty;
            }
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (itemDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                ItemVM itemVM = itemManager.GetItemByItemId(itemId);

                addButton.Enabled = true;
                stockOutQuantityTextBox.Enabled = true;
                reorderLavelTextBox.Text = itemVM.ReorderLevel.ToString();
                availableQuantityTextBox.Text = itemVM.AvailableQuantity.ToString();
                stockOutQuantityTextBox.Focus();

            }
            else
            {
                addButton.Enabled = false;
                stockOutQuantityTextBox.Enabled = false;
                reorderLavelTextBox.Text = String.Empty;
                availableQuantityTextBox.Text = String.Empty;
            }
        }
      
        protected void addButton_Click(object sender, EventArgs e)
        {
            //ItemVM aItemVM = new ItemVM();
            //Company aCompany = new Company();
            //aCompany.CompanyName = companyDropDownList.Text;
            //aItemVM.ItemName = itemDropDownList.Text;
            //int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            //aItemVM.AvailableQuantity -= stockOutQuantity;

            //if (stockOutQuantityTextBox.Text == "")
            //{
            //    messageLabel.Text = "Enter Valid Quantity";
            //    return;
            //}

            //if (aItemVM.AvailableQuantity < 1)
            //{
            //    messageLabel.Text = "Enter Valid Quantity";
            //    return;
            //}
            //else
            //{

            //    stockOutGridView.DataSource = aItemVM;
            //    stockOutGridView.DataBind();
            //    stockOutQuantityTextBox.Text = String.Empty;
            //    ViewState["itemList"] = aItemVM;
            //    messageLabel.Text = String.Empty;
            //}


            if (stockOutQuantityTextBox.Text == "")
            {
                messageLabel.Text = "Enter Valid Quantity";
                return;
            }
            int stockOutQuantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
            if (stockOutQuantity < 1)
            {
                messageLabel.Text = "Enter Valid Quantity";
                return;
            }

            List<ItemVM> itemList = new List<ItemVM>();
            int itemId = Convert.ToInt32(Convert.ToInt32(itemDropDownList.SelectedValue));

            ItemVM itemViewModel = itemManager.GetItemByItemId(itemId);

            itemViewModel.AvailableQuantity -= stockOutQuantity;

            if (ViewState["itemList"] == null)                  //When nothing is in Viewstate
            {
                if (itemViewModel.AvailableQuantity > 0)        //Insert to itemList if present available quanttity is greater then 0
                {
                    itemList.Add(itemViewModel);
                    stockOutGridView.DataSource = itemList;
                    stockOutGridView.DataBind();
                    stockOutQuantityTextBox.Text = String.Empty;
                    ViewState["itemList"] = itemList;
                    messageLabel.Text = String.Empty;
                }
                else
                {
                    messageLabel.Text = "Not enough stock";
                }

            }
            else
            {
                itemList = (List<ItemVM>)ViewState["itemList"];     //Retriving Viewstate when there is Data in ViewState

                int pointer = 0;                                           //Pointer that is used to decide if the given itemId already exist or not

                foreach (ItemVM item in itemList)                  //This loop iterates to detect duplicate Item and update it
                {
                    if (item.Id == itemId)
                    {
                        item.AvailableQuantity -= stockOutQuantity;        //This line update the itemList
                        if (item.AvailableQuantity > 0)
                        {
                            messageLabel.Text = String.Empty;
                            pointer++;
                            break;
                        }

                        messageLabel.Text = "Not enough stock";

                    }
                }

                if (pointer == 0)                                       //This condition will be true if ViewState is not null and Duplicate item not present
                {
                    if (itemViewModel.AvailableQuantity > 0)
                    {
                        messageLabel.Text = String.Empty;
                        itemList.Add(itemViewModel);
                    }
                    else
                    {
                        messageLabel.Text = "Not enough stock";
                    }
                }
                stockOutGridView.DataSource = itemList;
                stockOutGridView.DataBind();
                ViewState["itemList"] = itemList;
                stockOutQuantityTextBox.Text = String.Empty;
            }                            
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<ItemVM> itemList = (List<ItemVM>)ViewState["itemList"];

            if (itemList == null)
            {
                messageLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemVM item in itemList)
            {
                ItemVM itemViewModel = itemManager.GetItemByItemId(item.Id);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                itemManager.StockUpdate(item.AvailableQuantity, item.Id);        //Updating available quantity
                stockOutManager.StockOutEntry("sell", totalStockOut, item.Id);      //Storing Stock Out
            }
            messageLabel.Text = "Item Sold";
            ViewState["itemList"] = null;

            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<ItemVM> itemList = (List<ItemVM>)ViewState["itemList"];

            if (itemList == null)
            {
                messageLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemVM item in itemList)
            {
                ItemVM itemViewModel = itemManager.GetItemByItemId(item.Id);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                itemManager.StockUpdate(item.AvailableQuantity, item.Id);
                stockOutManager.StockOutEntry("damage", totalStockOut, item.Id);
            }
            messageLabel.Text = "Item Damaged";
            ViewState["itemList"] = null;
            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<ItemVM> itemList = (List<ItemVM>)ViewState["itemList"];

            if (itemList == null)
            {
                messageLabel.Text = "Please Take Something in Cart";
                return;
            }
            foreach (ItemVM item in itemList)
            {
                ItemVM itemViewModel = itemManager.GetItemByItemId(item.Id);
                double totalStockOut = itemViewModel.AvailableQuantity - item.AvailableQuantity;
                itemManager.StockUpdate(item.AvailableQuantity, item.Id);
                stockOutManager.StockOutEntry("lost", totalStockOut, item.Id);
            }
            messageLabel.Text = "Lost Item Entry Added";
            ViewState["itemList"] = null;
            TaskOnFirstLoad();
            companyDropDownList.Items.Insert(0, "Select Company");
            itemDropDownList.SelectedIndex = 0;
            stockOutGridView.DataBind();
        }

   
    
    }
}
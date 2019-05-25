using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopWebView;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormCustomers : System.Web.UI.Page
    {
        List<CustomerViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = APIClient.GetRequest<List<CustomerViewModel>>("api/Customer/GetList");
                if (list != null)
                {
                    dataGridView.Columns[0].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormCustomer.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                string index = list[dataGridView.SelectedIndex].Id.ToString();
                Session["id"] = index;
                Server.Transfer("FormCustomer.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                int id = list[dataGridView.SelectedIndex].Id;
                try
                {
                    APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/DelElement", new CustomerBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
                Server.Transfer("FormCustomers.aspx");
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FormCustomers.aspx");
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}
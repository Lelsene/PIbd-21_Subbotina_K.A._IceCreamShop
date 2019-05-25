﻿using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopWebView;
using System;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormCustomer : System.Web.UI.Page
    {
        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CustomerViewModel view = APIClient.GetRequest<CustomerViewModel>("api/Customer/Get/" + id);
                    if (view != null)
                    {
                        name = view.CustomerFIO;
                        APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                        {
                            Id = id,
                            CustomerFIO = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(textBoxName.Text))
                        {
                            textBoxName.Text = name;
                        }
                        APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                        {
                            Id = id,
                            CustomerFIO = name
                        });
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/UpdElement", new CustomerBindingModel
                    {
                        Id = id,
                        CustomerFIO = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<CustomerBindingModel, bool>("api/Customer/AddElement", new CustomerBindingModel
                    {
                        CustomerFIO = textBoxName.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FormCustomers.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FormCustomers.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormCustomers.aspx");
        }
    }
}
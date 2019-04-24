﻿using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormCreateBooking : System.Web.UI.Page
    {
        private readonly ICustomerService serviceC = UnityConfig.Container.Resolve<CustomerServiceDB>();

        private readonly IIceCreamService serviceS = UnityConfig.Container.Resolve<IceCreamServiceDB>();

        private readonly IMainService serviceM = UnityConfig.Container.Resolve<MainServiceDB>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    List<CustomerViewModel> listC = serviceC.GetList();
                    if (listC != null)
                    {
                        DropDownListCustomer.DataSource = listC;
                        DropDownListCustomer.DataBind();
                        DropDownListCustomer.DataTextField = "CustomerFIO";
                        DropDownListCustomer.DataValueField = "Id";
                    }
                    List<IceCreamViewModel> listP = serviceS.GetList();
                    if (listP != null)
                    {
                        DropDownListIceCream.DataSource = listP;
                        DropDownListIceCream.DataBind();
                        DropDownListIceCream.DataTextField = "IceCreamName";
                        DropDownListIceCream.DataValueField = "Id";
                    }
                    Page.DataBind();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        private void CalcSum()
        {

            if (DropDownListIceCream.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(DropDownListIceCream.SelectedValue);
                    IceCreamViewModel product = serviceS.GetElement(id);
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxSum.Text = (count * product.Price).ToString();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListCustomer.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите покупателя');</script>");
                return;
            }
            if (DropDownListIceCream.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите мороженое');</script>");
                return;
            }
            try
            {
                serviceM.CreateBooking(new BookingBindingModel
                {
                    CustomerId = Convert.ToInt32(DropDownListCustomer.SelectedValue),
                    IceCreamId = Convert.ToInt32(DropDownListIceCream.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text),
                    Sum = Convert.ToInt32(TextBoxSum.Text)
                });
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}
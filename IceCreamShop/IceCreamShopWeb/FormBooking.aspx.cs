using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormBooking : System.Web.UI.Page
    {
        private readonly ICustomerService serviceC = new CustomerServiceList();

        private readonly IIceCreamService serviceS = new IceCreamServiceList();

        private readonly IMainService serviceM = new MainServiceList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<CustomerViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    DropDownListCustomer.DataSource = listC;
                    DropDownListCustomer.DataBind();
                    DropDownListCustomer.DataTextField = "CustomerName";
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

        protected void DropDownListService_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите клиента');</script>");
                return;
            }
            if (DropDownListIceCream.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите изделие');</script>");
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
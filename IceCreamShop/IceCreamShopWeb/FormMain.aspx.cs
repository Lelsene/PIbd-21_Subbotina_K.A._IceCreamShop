using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopWebView;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormMain : System.Web.UI.Page
    {
        private List<BookingViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = APIClient.GetRequest<List<BookingViewModel>>("api/Main/GetList");
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCreateBooking_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormCreateBooking.aspx");
        }

        protected void ButtonTakeBookingInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                try
                {
                    int id = list[dataGridView1.SelectedIndex].Id;
                    APIClient.PostRequest<BookingBindingModel, bool>("api/Main/TakeBookingInWork", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                    Server.Transfer("FormMain.aspx");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonFinishBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = list[dataGridView1.SelectedIndex].Id;
                try
                {
                    APIClient.PostRequest<BookingBindingModel, bool>("api/Main/FinishBooking", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                    Server.Transfer("FormMain.aspx");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonBookingPayed_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedIndex >= 0)
            {
                int id = list[dataGridView1.SelectedIndex].Id;
                try
                {
                    APIClient.PostRequest<BookingBindingModel, bool>("api/Main/PayBooking", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                    Server.Transfer("FormMain.aspx");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
            Server.Transfer("FormMain.aspx");
        }
    }
}
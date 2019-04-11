using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceImplement.Implementations;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IceCreamShopWeb
{
    public partial class FormMain : System.Web.UI.Page
    {
        private readonly IMainService service = new MainServiceList();

        List<BookingViewModel> list;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                list = service.GetList();
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
                    //string index = list[dataGridView1.SelectedIndex].Id.ToString();
                    //Session["id"] = index;
                    int id = list[dataGridView1.SelectedIndex].Id;
                    service.TakeBookingInWork(new BookingBindingModel { Id = id });
                    LoadData();
                    Server.Transfer("FormMain.aspx");
                    //Server.Transfer("TakeBookingInWork.aspx");
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
                    service.FinishBooking(new BookingBindingModel { Id = id });
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
                    service.PayBooking(new BookingBindingModel { Id = id });
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
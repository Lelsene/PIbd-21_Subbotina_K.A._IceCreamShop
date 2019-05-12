using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Web.UI;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormCustomerBookingsSave : System.Web.UI.Page
    {
        readonly IRecordService reportService = UnityConfig.Container.Resolve<RecordServiceDB>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=CustomersBookings.pdf");
            Response.ContentType = "application/vnd.ms-word";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                reportService.SaveCustomerBookings(new RecordBindingModel
                {
                    FileName = "C:\\CustomersBookings.pdf",
                    DateFrom = DateTime.Parse(Session["DateFrom"].ToString()),
                    DateTo = DateTime.Parse(Session["DateTo"].ToString())
                });
                Response.WriteFile("C:\\CustomersBookings.pdf");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}
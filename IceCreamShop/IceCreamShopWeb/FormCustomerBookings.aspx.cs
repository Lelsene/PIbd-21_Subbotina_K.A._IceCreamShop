using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplementDataBase.Implementations;
using Microsoft.Reporting.WebForms;
using System;
using System.Web.UI;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormCustomerBookings : System.Web.UI.Page
    {
        private readonly IRecordService service = UnityConfig.Container.Resolve<RecordServiceDB>();

        protected void ButtonMake_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDate", "<script>alert('Дата начала должна быть меньше даты окончания');</script>");
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                                            "c " + Calendar1.SelectedDate.ToShortDateString() +
                                            " по " + Calendar2.SelectedDate.ToShortDateString());


                ReportViewer1.LocalReport.SetParameters(parameter);

                var dataSource = service.GetCustomerBookings(new RecordBindingModel
                {
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                ReportDataSource source = new ReportDataSource("DataSetBookings", dataSource);
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonToPdf_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Шонова\\Desktop\\CustomerBookings.pdf";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=CustomerBookings.pdf");
            Response.ContentType = "application/vnd.ms-word";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                service.SaveCustomerBookings(new RecordBindingModel
                {
                    FileName = path,
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                Response.WriteFile(path);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}
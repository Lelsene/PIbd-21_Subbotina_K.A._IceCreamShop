using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Web.UI;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormStoragesLoadSave : System.Web.UI.Page
    {
        readonly IRecordService reportService = UnityConfig.Container.Resolve<RecordServiceDB>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment; filename=StoragesLoad.xls");
            Response.ContentType = "application/vnd.ms-excel";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                reportService.SaveStoragesLoad(new RecordBindingModel
                {
                    FileName = @"C:\SLoad.xls"
                });
                Response.WriteFile(@"C:\SLoad.xls");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}
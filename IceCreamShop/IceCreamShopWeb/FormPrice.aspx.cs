﻿using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Web.UI;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormPrice : System.Web.UI.Page
    {
        readonly IRecordService reportService = UnityConfig.Container.Resolve<RecordServiceDB>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string path = "C:\\Users\\Шонова\\Desktop\\Price.docx";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=Price.docx");
            Response.ContentType = "application/vnd.ms-word";
            try
            {
                reportService.SaveIceCreamPrice(new RecordBindingModel
                {
                    FileName = path
                });
                Response.WriteFile(path);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }
    }
}
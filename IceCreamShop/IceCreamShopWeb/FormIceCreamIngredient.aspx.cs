using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormIceCreamIngredient : System.Web.UI.Page
    {
        private readonly IIngredientService service = new IngredientServiceList();

        private IceCreamIngredientViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> list = service.GetList();
                if (list != null)
                {
                    DropDownListIngredient.DataSource = list;
                    DropDownListIngredient.DataValueField = "Id";
                    DropDownListIngredient.DataTextField = "IngredientName";
                    DropDownListIngredient.SelectedIndex = -1;
                    Page.DataBind();
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
            if (Session["SEId"] != null)
            {
                DropDownListIngredient.Enabled = false;
                DropDownListIngredient.SelectedValue = (string)Session["SEIngredientId"];
                TextBoxCount.Text = (string)Session["SECount"];
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListIngredient.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите компонент');</script>");
                return;
            }
            try
            {
                if (Session["SEId"] == null)
                {
                    model = new IceCreamIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(DropDownListIngredient.SelectedValue),
                        IngredientName = DropDownListIngredient.SelectedItem.Text,
                        Count = Convert.ToInt32(TextBoxCount.Text)
                    };
                    Session["SEId"] = model.Id;
                    Session["SEIceCreamId"] = model.IceCreamId;
                    Session["SEIngredientId"] = model.IngredientId;
                    Session["SEIngredientName"] = model.IngredientName;
                    Session["SECount"] = model.Count;
                }
                else
                {
                    model.Count = Convert.ToInt32(TextBoxCount.Text);
                    Session["SEId"] = model.Id;
                    Session["SEServiceId"] = model.IceCreamId;
                    Session["SEIngredientId"] = model.IngredientId;
                    Session["SEIngredientName"] = model.IngredientName;
                    Session["SECount"] = model.Count;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormIceCream.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormIceCream.aspx");
        }
    }
}
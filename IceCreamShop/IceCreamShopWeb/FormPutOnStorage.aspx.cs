using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopWebView;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormPutOnStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    List<IngredientViewModel> listI = APIClient.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                    if (listI != null)
                    {
                        DropDownListIngredient.DataSource = listI;
                        DropDownListIngredient.DataBind();
                        DropDownListIngredient.DataTextField = "IngredientName";
                        DropDownListIngredient.DataValueField = "Id";
                    }
                    List<StorageViewModel> listS = APIClient.GetRequest<List<StorageViewModel>>("api/Storage/GetList");
                    if (listS != null)
                    {
                        DropDownListStorage.DataSource = listS;
                        DropDownListStorage.DataBind();
                        DropDownListStorage.DataTextField = "StorageName";
                        DropDownListStorage.DataValueField = "Id";
                    }
                    Page.DataBind();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле количество');</script>");
                return;
            }
            if (DropDownListIngredient.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите компонент');</script>");
                return;
            }
            if (DropDownListStorage.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите склад');</script>");
                return;
            }
            try
            {
                APIClient.PostRequest<StorageIngredientBindingModel, bool>("api/Main/PutIngredientOnStorage", new StorageIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(DropDownListIngredient.SelectedValue),
                    StorageId = Convert.ToInt32(DropDownListStorage.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text)
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
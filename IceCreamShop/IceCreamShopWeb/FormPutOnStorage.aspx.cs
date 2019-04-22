using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormPutOnStorage : System.Web.UI.Page
    {
        private readonly IStorageService serviceS = new StorageServiceList();

        private readonly IIngredientService serviceI = new IngredientServiceList();

        private readonly IMainService serviceM = new MainServiceList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    List<IngredientViewModel> listI = serviceI.GetList();
                    if (listI != null)
                    {
                        DropDownListIngredient.DataSource = listI;
                        DropDownListIngredient.DataBind();
                        DropDownListIngredient.DataTextField = "IngredientName";
                        DropDownListIngredient.DataValueField = "Id";
                    }
                    List<StorageViewModel> listS = serviceS.GetList();
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
                serviceM.PutIngredientOnStorage(new StorageIngredientBindingModel
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
using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Implementations;
using System;
using System.Web.UI;

namespace IceCreamShopWeb
{
    public partial class FormStorage : System.Web.UI.Page
    {
        public int Id { set { id = value; } }

        private readonly IStorageService service = new StorageServiceList();

        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    StorageViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        name = view.StorageName;
                        dataGridView.DataSource = view.StorageIngredients;
                        dataGridView.DataBind();
                        service.UpdElement(new StorageBindingModel
                        {
                            Id = id,
                            StorageName = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(textBoxName.Text))
                        {
                            textBoxName.Text = name;
                        }
                        service.UpdElement(new StorageBindingModel
                        {
                            Id = id,
                            StorageName = name
                        });
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new StorageBindingModel
                    {
                        Id = id,
                        StorageName = textBoxName.Text
                    });
                }
                else
                {
                    service.AddElement(new StorageBindingModel
                    {
                        StorageName = textBoxName.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FormStorages.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FormStorages.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormStorages.aspx");
        }
    }
}
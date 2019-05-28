using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace IceCreamShopWeb
{
    public partial class FormIceCream : System.Web.UI.Page
    {
        private readonly IIceCreamService service = UnityConfig.Container.Resolve<IceCreamServiceDB>();

        private int id;

        private List<IceCreamIngredientViewModel> icecreamIngredients;

        private IceCreamIngredientViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    IceCreamViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            textBoxName.Text = view.IceCreamName;
                            textBoxPrice.Text = view.Price.ToString();
                        }
                        this.icecreamIngredients = view.IceCreamIngredients;
                        LoadData();

                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                this.icecreamIngredients = new List<IceCreamIngredientViewModel>();

            }
            if (Session["SEId"] != null)
            {
                if ((Session["SEIs"] != null) && (Session["Change"].ToString() != "0"))
                {
                    model = new IceCreamIngredientViewModel
                    {
                        Id = (int)Session["SEId"],
                        IceCreamId = (int)Session["SEIceCreamId"],
                        IngredientId = (int)Session["SEIngredientId"],
                        IngredientName = (string)Session["SEIngredientName"],
                        Count = (int)Session["SECount"]
                    };
                    this.icecreamIngredients[(int)Session["SEIs"]] = model;
                    Session["Change"] = "0";
                }
                else
                {
                    model = new IceCreamIngredientViewModel
                    {
                        IceCreamId = (int)Session["SEIceCreamId"],
                        IngredientId = (int)Session["SEIngredientId"],
                        IngredientName = (string)Session["SEIngredientName"],
                        Count = (int)Session["SECount"]
                    };
                    this.icecreamIngredients.Add(model);
                }
                Session["SEId"] = null;
                Session["SEIceCreamId"] = null;
                Session["SEIngredientId"] = null;
                Session["SEIngredientName"] = null;
                Session["SECount"] = null;
                Session["SEIs"] = null;
            }
            List<IceCreamIngredientBindingModel> icecreamIngredientBM = new List<IceCreamIngredientBindingModel>();
            for (int i = 0; i < this.icecreamIngredients.Count; ++i)
            {
                icecreamIngredientBM.Add(new IceCreamIngredientBindingModel
                {
                    Id = this.icecreamIngredients[i].Id,
                    IceCreamId = this.icecreamIngredients[i].IceCreamId,
                    IngredientId = this.icecreamIngredients[i].IngredientId,
                    Count = this.icecreamIngredients[i].Count
                });
            }
            if (icecreamIngredientBM.Count != 0)
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new IceCreamBindingModel
                    {
                        Id = id,
                        IceCreamName = "Введите название",
                        Price = 0,
                        IceCreamIngredients = icecreamIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new IceCreamBindingModel
                    {
                        IceCreamName = "Введите название",
                        Price = 0,
                        IceCreamIngredients = icecreamIngredientBM
                    });
                    Session["id"] = service.GetList().Last().Id.ToString();
                    Session["Change"] = "0";
                }
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (icecreamIngredients != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = icecreamIngredients;
                    dataGridView.DataBind();
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormIceCreamIngredient.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                model = service.GetElement(id).IceCreamIngredients[dataGridView.SelectedIndex];
                Session["SEId"] = model.Id;
                Session["SEIceCreamId"] = model.IceCreamId;
                Session["SEIngredientId"] = model.IngredientId;
                Session["SEIngredientName"] = model.IngredientName;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Session["Change"] = "0";
                Server.Transfer("FormIceCreamIngredient.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    icecreamIngredients.RemoveAt(dataGridView.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните цену');</script>");
                return;
            }
            if (icecreamIngredients == null || icecreamIngredients.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ингредиенты');</script>");
                return;
            }
            try
            {
                List<IceCreamIngredientBindingModel> icecreamIngredientBM = new List<IceCreamIngredientBindingModel>();
                for (int i = 0; i < icecreamIngredients.Count; ++i)
                {
                    icecreamIngredientBM.Add(new IceCreamIngredientBindingModel
                    {
                        Id = icecreamIngredients[i].Id,
                        IceCreamId = icecreamIngredients[i].IceCreamId,
                        IngredientId = icecreamIngredients[i].IngredientId,
                        Count = icecreamIngredients[i].Count
                    });
                }
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new IceCreamBindingModel
                    {
                        Id = id,
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        IceCreamIngredients = icecreamIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new IceCreamBindingModel
                    {
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        IceCreamIngredients = icecreamIngredientBM
                    });
                }
                Session["id"] = null;
                Session["Change"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormIceCreams.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (service.GetList().Count != 0 && service.GetList().Last().IceCreamName == null)
            {
                service.DelElement(service.GetList().Last().Id);
            }
            if (!String.Equals(Session["Change"], null))
            {
                service.DelElement(id);
            }
            Session["id"] = null;
            Session["Change"] = null;
            Server.Transfer("FormIceCreams.aspx");
        }

        protected void DataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}
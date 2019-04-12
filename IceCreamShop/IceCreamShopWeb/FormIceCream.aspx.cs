using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using IceCreamShopServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IceCreamShopWeb
{
    public partial class FormIceCream : System.Web.UI.Page
    {
        private readonly IIceCreamService service = new IceCreamServiceList();

        private int id;

        private List<IceCreamIngredientViewModel> IceCreamIngredient;

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
                        textBoxName.Text = view.IceCreamName;
                        textBoxPrice.Text = view.Price.ToString();
                        this.IceCreamIngredient = view.IceCreamIngredients;
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
                if (service.GetList().Count == 0 || service.GetList().Last().IceCreamName != null)
                {
                    this.IceCreamIngredient = new List<IceCreamIngredientViewModel>();
                    LoadData();
                }
                else
                {
                    this.IceCreamIngredient = service.GetList().Last().IceCreamIngredients;
                    LoadData();
                }
            }
            if (Session["SEId"] != null)
            {
                model = new IceCreamIngredientViewModel
                {
                    Id = (int)Session["SEId"],
                    IceCreamId = (int)Session["SEIceCreamId"],
                    IngredientId = (int)Session["SEIngredientId"],
                    IngredientName = (string)Session["SEIngredientName"],
                    Count = (int)Session["SECount"]
                };
                if (Session["SEIs"] != null)
                {
                    this.IceCreamIngredient[(int)Session["SEIs"]] = model;
                }
                else
                {
                    this.IceCreamIngredient.Add(model);
                }
            }
            List<IceCreamIngredientBindingModel> commodityIngredient = new List<IceCreamIngredientBindingModel>();
            for (int i = 0; i < this.IceCreamIngredient.Count; ++i)
            {
                commodityIngredient.Add(new IceCreamIngredientBindingModel
                {
                    Id = this.IceCreamIngredient[i].Id,
                    IceCreamId = this.IceCreamIngredient[i].IceCreamId,
                    IngredientId = this.IceCreamIngredient[i].IngredientId,
                    Count = this.IceCreamIngredient[i].Count
                });
            }
            if (commodityIngredient.Count != 0)
            {
                if (service.GetList().Count == 0 || service.GetList().Last().IceCreamName != null)
                {
                    service.AddElement(new IceCreamBindingModel
                    {
                        IceCreamName = null,
                        Price = -1,
                        IceCreamIngredients = commodityIngredient
                    });
                }
                else
                {
                    service.UpdElement(new IceCreamBindingModel
                    {
                        Id = service.GetList().Last().Id,
                        IceCreamName = null,
                        Price = -1,
                        IceCreamIngredients = commodityIngredient
                    });
                }

            }
            try
            {
                if (this.IceCreamIngredient != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = this.IceCreamIngredient;
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
            Session["SEId"] = null;
            Session["SEIceCreamId"] = null;
            Session["SEIngredientId"] = null;
            Session["SEIngredientName"] = null;
            Session["SECount"] = null;
            Session["SEIs"] = null;
        }

        private void LoadData()
        {
            try
            {
                if (IceCreamIngredient != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = IceCreamIngredient;
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
                Session["SEId"] = model.Id;
                Session["SEIceCreamId"] = model.IceCreamId;
                Session["SEIngredientId"] = model.IngredientId;
                Session["SEIngredientName"] = model.IngredientName;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Server.Transfer("FormIceCreamIngredient.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    IceCreamIngredient.RemoveAt(dataGridView.SelectedIndex);
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
            if (IceCreamIngredient == null || IceCreamIngredient.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ингредиенты');</script>");
                return;
            }
            try
            {
                List<IceCreamIngredientBindingModel> commodityIngredientBM = new List<IceCreamIngredientBindingModel>();
                for (int i = 0; i < IceCreamIngredient.Count; ++i)
                {
                    commodityIngredientBM.Add(new IceCreamIngredientBindingModel
                    {
                        Id = IceCreamIngredient[i].Id,
                        IceCreamId = IceCreamIngredient[i].IceCreamId,
                        IngredientId = IceCreamIngredient[i].IngredientId,
                        Count = IceCreamIngredient[i].Count
                    });
                }
                service.DelElement(service.GetList().Last().Id);
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new IceCreamBindingModel
                    {
                        Id = id,
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        IceCreamIngredients = commodityIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new IceCreamBindingModel
                    {
                        IceCreamName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        IceCreamIngredients = commodityIngredientBM
                    });
                }
                Session["id"] = null;
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
            Session["id"] = null;
            Server.Transfer("FormIceCreams.aspx");
        }

        protected void dataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}
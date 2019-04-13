using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormIceCreamIngredient : Form
    {
        public IceCreamIngredientViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }

        private IceCreamIngredientViewModel model;

        public FormIceCreamIngredient()
        {
            InitializeComponent();
        }

        private void FormIceCreamIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> list = APICustomer.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                if (list != null)
                {
                    comboBoxIngredient.DisplayMember = "IngredientName";
                    comboBoxIngredient.ValueMember = "Id";
                    comboBoxIngredient.DataSource = list;
                    comboBoxIngredient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxIngredient.Enabled = false;
                comboBoxIngredient.SelectedValue = model.IngredientId;
                textBoxCount.Text = model.Count.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите ингредиент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new IceCreamIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                        IngredientName = comboBoxIngredient.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.ViewModels;
using System;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormIceman : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormIceman()
        {
            InitializeComponent();
        }

        private void FormIceman_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IcemanViewModel customer = APIClient.GetRequest<IcemanViewModel>("api/Iceman/Get/" + id.Value);
                    textBoxFIO.Text = customer.IcemanFIO;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<IcemanBindingModel,
                    bool>("api/Iceman/UpdElement", new IcemanBindingModel
                    {
                        Id = id.Value,
                        IcemanFIO = textBoxFIO.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<IcemanBindingModel,
                    bool>("api/Iceman/AddElement", new IcemanBindingModel
                    {
                        IcemanFIO = textBoxFIO.Text
                    });
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

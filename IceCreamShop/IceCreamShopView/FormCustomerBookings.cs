using IceCreamShopServiceDAL.BindingModels;
using IceCreamShopServiceDAL.Interfaces;
using IceCreamShopServiceDAL.ViewModels;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormCustomerBookings : Form
    {
        public FormCustomerBookings()
        {
            InitializeComponent();
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            recordViewer.RefreshReport();
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("RecordParameterPeriod",
                    "c " + dateTimePickerFrom.Value.ToShortDateString() + " по " +
                    dateTimePickerTo.Value.ToShortDateString());
                recordViewer.LocalReport.SetParameters(parameter);

                List<CustomerBookingsModel> response =
                APICustomer.PostRequest<RecordBindingModel,
                List<CustomerBookingsModel>>("api/Report/GetCustomerBookings", new RecordBindingModel
                {
                    DateFrom = dateTimePickerFrom.Value,
                    DateTo = dateTimePickerTo.Value
                });

                ReportDataSource source = new ReportDataSource("DataSetBookings", response);
                recordViewer.LocalReport.DataSources.Add(source);
                recordViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonToPdf_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания",
                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "pdf|*.pdf"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APICustomer.PostRequest<RecordBindingModel,
                    bool>("api/Report/SaveCustomerBookings", new RecordBindingModel
                    {
                        FileName = sfd.FileName,
                        DateFrom = dateTimePickerFrom.Value,
                        DateTo = dateTimePickerTo.Value
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
    }
}

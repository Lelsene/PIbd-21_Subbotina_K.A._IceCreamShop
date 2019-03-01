namespace IceCreamShopView
{
    partial class FormCreateBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.comboBoxCustomer = new System.Windows.Forms.ComboBox();
            this.labelIceCream = new System.Windows.Forms.Label();
            this.comboBoxIceCream = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelSum = new System.Windows.Forms.Label();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.customerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iceCreamViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iceCreamViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(300, 112);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(211, 112);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(83, 22);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(7, 10);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(70, 13);
            this.labelCustomer.TabIndex = 8;
            this.labelCustomer.Text = "Покупатель:";
            // 
            // comboBoxCustomer
            // 
            this.comboBoxCustomer.DataSource = this.customerViewModelBindingSource;
            this.comboBoxCustomer.DisplayMember = "CustomerFIO";
            this.comboBoxCustomer.FormattingEnabled = true;
            this.comboBoxCustomer.Location = new System.Drawing.Point(93, 7);
            this.comboBoxCustomer.Name = "comboBoxCustomer";
            this.comboBoxCustomer.Size = new System.Drawing.Size(290, 21);
            this.comboBoxCustomer.TabIndex = 9;
            this.comboBoxCustomer.ValueMember = "Id";
            // 
            // labelIceCream
            // 
            this.labelIceCream.AutoSize = true;
            this.labelIceCream.Location = new System.Drawing.Point(8, 38);
            this.labelIceCream.Name = "labelIceCream";
            this.labelIceCream.Size = new System.Drawing.Size(69, 13);
            this.labelIceCream.TabIndex = 10;
            this.labelIceCream.Text = "Мороженое:";
            // 
            // comboBoxIceCream
            // 
            this.comboBoxIceCream.DataSource = this.iceCreamViewModelBindingSource;
            this.comboBoxIceCream.DisplayMember = "IceCreamName";
            this.comboBoxIceCream.FormattingEnabled = true;
            this.comboBoxIceCream.Location = new System.Drawing.Point(93, 35);
            this.comboBoxIceCream.Name = "comboBoxIceCream";
            this.comboBoxIceCream.Size = new System.Drawing.Size(290, 21);
            this.comboBoxIceCream.TabIndex = 11;
            this.comboBoxIceCream.ValueMember = "Id";
            this.comboBoxIceCream.SelectedIndexChanged += new System.EventHandler(this.comboBoxIceCream_SelectedIndexChanged);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(8, 65);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(69, 13);
            this.labelCount.TabIndex = 12;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(93, 62);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(290, 20);
            this.textBoxCount.TabIndex = 13;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(8, 89);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(44, 13);
            this.labelSum.TabIndex = 14;
            this.labelSum.Text = "Сумма:";
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(93, 86);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(290, 20);
            this.textBoxSum.TabIndex = 15;
            // 
            // customerViewModelBindingSource
            // 
            this.customerViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.CustomerViewModel);
            // 
            // iceCreamViewModelBindingSource
            // 
            this.iceCreamViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.IceCreamViewModel);
            // 
            // FormCreateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 144);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxIceCream);
            this.Controls.Add(this.labelIceCream);
            this.Controls.Add(this.comboBoxCustomer);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormCreateBooking";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iceCreamViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.ComboBox comboBoxCustomer;
        private System.Windows.Forms.Label labelIceCream;
        private System.Windows.Forms.ComboBox comboBoxIceCream;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.BindingSource customerViewModelBindingSource;
        private System.Windows.Forms.BindingSource iceCreamViewModelBindingSource;
    }
}
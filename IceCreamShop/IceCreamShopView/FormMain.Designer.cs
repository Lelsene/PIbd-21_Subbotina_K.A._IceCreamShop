namespace IceCreamShopView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer Ingredients = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (Ingredients != null))
            {
                Ingredients.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonTakeBookingInWork = new System.Windows.Forms.Button();
            this.buttonBookingReady = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.bookingViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerFIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iceCreamIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iceCreamNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateImplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(860, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.покупателиToolStripMenuItem,
            this.ингредиентыToolStripMenuItem,
            this.мороженоеToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // покупателиToolStripMenuItem
            // 
            this.покупателиToolStripMenuItem.Name = "покупателиToolStripMenuItem";
            this.покупателиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.покупателиToolStripMenuItem.Text = "Покупатели";
            this.покупателиToolStripMenuItem.Click += new System.EventHandler(this.покупателиToolStripMenuItem_Click);
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.мороженоеToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.customerIdDataGridViewTextBoxColumn,
            this.customerFIODataGridViewTextBoxColumn,
            this.iceCreamIdDataGridViewTextBoxColumn,
            this.iceCreamNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.dateImplementDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.bookingViewModelBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(9, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(665, 337);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(680, 34);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(168, 32);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonTakeBookingInWork
            // 
            this.buttonTakeBookingInWork.Location = new System.Drawing.Point(680, 72);
            this.buttonTakeBookingInWork.Name = "buttonTakeBookingInWork";
            this.buttonTakeBookingInWork.Size = new System.Drawing.Size(168, 32);
            this.buttonTakeBookingInWork.TabIndex = 3;
            this.buttonTakeBookingInWork.Text = "Отдать на выполнение";
            this.buttonTakeBookingInWork.UseVisualStyleBackColor = true;
            this.buttonTakeBookingInWork.Click += new System.EventHandler(this.buttonTakeBookingInWork_Click);
            // 
            // buttonBookingReady
            // 
            this.buttonBookingReady.Location = new System.Drawing.Point(680, 110);
            this.buttonBookingReady.Name = "buttonBookingReady";
            this.buttonBookingReady.Size = new System.Drawing.Size(168, 32);
            this.buttonBookingReady.TabIndex = 4;
            this.buttonBookingReady.Text = "Заказ готов";
            this.buttonBookingReady.UseVisualStyleBackColor = true;
            this.buttonBookingReady.Click += new System.EventHandler(this.buttonBookingReady_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(680, 148);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(168, 32);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(680, 186);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(168, 32);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // bookingViewModelBindingSource
            // 
            this.bookingViewModelBindingSource.DataSource = typeof(IceCreamShopServiceDAL.ViewModels.BookingViewModel);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerIdDataGridViewTextBoxColumn
            // 
            this.customerIdDataGridViewTextBoxColumn.DataPropertyName = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.HeaderText = "CustomerId";
            this.customerIdDataGridViewTextBoxColumn.Name = "customerIdDataGridViewTextBoxColumn";
            this.customerIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerFIODataGridViewTextBoxColumn
            // 
            this.customerFIODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.customerFIODataGridViewTextBoxColumn.DataPropertyName = "CustomerFIO";
            this.customerFIODataGridViewTextBoxColumn.HeaderText = "CustomerFIO";
            this.customerFIODataGridViewTextBoxColumn.Name = "customerFIODataGridViewTextBoxColumn";
            // 
            // iceCreamIdDataGridViewTextBoxColumn
            // 
            this.iceCreamIdDataGridViewTextBoxColumn.DataPropertyName = "IceCreamId";
            this.iceCreamIdDataGridViewTextBoxColumn.HeaderText = "IceCreamId";
            this.iceCreamIdDataGridViewTextBoxColumn.Name = "iceCreamIdDataGridViewTextBoxColumn";
            this.iceCreamIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // iceCreamNameDataGridViewTextBoxColumn
            // 
            this.iceCreamNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.iceCreamNameDataGridViewTextBoxColumn.DataPropertyName = "IceCreamName";
            this.iceCreamNameDataGridViewTextBoxColumn.HeaderText = "IceCreamName";
            this.iceCreamNameDataGridViewTextBoxColumn.Name = "iceCreamNameDataGridViewTextBoxColumn";
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Visible = false;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // dateCreateDataGridViewTextBoxColumn
            // 
            this.dateCreateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.HeaderText = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
            // 
            // dateImplementDataGridViewTextBoxColumn
            // 
            this.dateImplementDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateImplementDataGridViewTextBoxColumn.DataPropertyName = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.HeaderText = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.Name = "dateImplementDataGridViewTextBoxColumn";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 374);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.buttonBookingReady);
            this.Controls.Add(this.buttonTakeBookingInWork);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Лавка мороженого";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem покупателиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мороженоеToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateBooking;
        private System.Windows.Forms.Button buttonTakeBookingInWork;
        private System.Windows.Forms.Button buttonBookingReady;
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceCreamIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iceCreamNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateImplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bookingViewModelBindingSource;
        private System.ComponentModel.IContainer components;
    }
}


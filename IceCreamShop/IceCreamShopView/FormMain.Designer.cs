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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупателиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.хранилищаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.мороженщикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьХранилищеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсМороженогоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьХранилищToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыПокупателейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьХранилищеToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1035, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.покупателиToolStripMenuItem,
            this.ингредиентыToolStripMenuItem,
            this.мороженоеToolStripMenuItem,
            this.хранилищаToolStripMenuItem,
            this.мороженщикиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // покупателиToolStripMenuItem
            // 
            this.покупателиToolStripMenuItem.Name = "покупателиToolStripMenuItem";
            this.покупателиToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.покупателиToolStripMenuItem.Text = "Покупатели";
            this.покупателиToolStripMenuItem.Click += new System.EventHandler(this.покупателиToolStripMenuItem_Click);
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // мороженоеToolStripMenuItem
            // 
            this.мороженоеToolStripMenuItem.Name = "мороженоеToolStripMenuItem";
            this.мороженоеToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.мороженоеToolStripMenuItem.Text = "Мороженое";
            this.мороженоеToolStripMenuItem.Click += new System.EventHandler(this.мороженоеToolStripMenuItem_Click);
            // 
            // хранилищаToolStripMenuItem
            // 
            this.хранилищаToolStripMenuItem.Name = "хранилищаToolStripMenuItem";
            this.хранилищаToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.хранилищаToolStripMenuItem.Text = "Хранилища";
            this.хранилищаToolStripMenuItem.Click += new System.EventHandler(this.хранилищаToolStripMenuItem_Click);
            // 
            // мороженщикиToolStripMenuItem
            // 
            this.мороженщикиToolStripMenuItem.Name = "мороженщикиToolStripMenuItem";
            this.мороженщикиToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.мороженщикиToolStripMenuItem.Text = "Мороженщики";
            this.мороженщикиToolStripMenuItem.Click += new System.EventHandler(this.мороженщикиToolStripMenuItem_Click);
            // 
            // пополнитьХранилищеToolStripMenuItem
            // 
            this.пополнитьХранилищеToolStripMenuItem.Name = "пополнитьХранилищеToolStripMenuItem";
            this.пополнитьХранилищеToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.пополнитьХранилищеToolStripMenuItem.Text = "Пополнить хранилище";
            this.пополнитьХранилищеToolStripMenuItem.Click += new System.EventHandler(this.пополнитьХранилищеToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсМороженогоToolStripMenuItem,
            this.загруженностьХранилищToolStripMenuItem,
            this.заказыПокупателейToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // прайсМороженогоToolStripMenuItem
            // 
            this.прайсМороженогоToolStripMenuItem.Name = "прайсМороженогоToolStripMenuItem";
            this.прайсМороженогоToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.прайсМороженогоToolStripMenuItem.Text = "Прайс мороженого";
            this.прайсМороженогоToolStripMenuItem.Click += new System.EventHandler(this.прайсМороженогоToolStripMenuItem_Click);
            // 
            // загруженностьХранилищToolStripMenuItem
            // 
            this.загруженностьХранилищToolStripMenuItem.Name = "загруженностьХранилищToolStripMenuItem";
            this.загруженностьХранилищToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.загруженностьХранилищToolStripMenuItem.Text = "Загруженность хранилищ";
            this.загруженностьХранилищToolStripMenuItem.Click += new System.EventHandler(this.загруженностьХранилищToolStripMenuItem_Click);
            // 
            // заказыПокупателейToolStripMenuItem
            // 
            this.заказыПокупателейToolStripMenuItem.Name = "заказыПокупателейToolStripMenuItem";
            this.заказыПокупателейToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.заказыПокупателейToolStripMenuItem.Text = "Заказы покупателей";
            this.заказыПокупателейToolStripMenuItem.Click += new System.EventHandler(this.заказыПокупателейToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(9, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(843, 326);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(858, 45);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(168, 32);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(858, 83);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(168, 32);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(858, 339);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(168, 32);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 380);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Лавка мороженого";
            this.Load += new System.EventHandler(this.buttonRef_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
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
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem хранилищаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьХранилищеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсМороженогоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьХранилищToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыПокупателейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem мороженщикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
    }
}


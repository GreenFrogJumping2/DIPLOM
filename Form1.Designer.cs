namespace DIPLOM
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказчикиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фурнитураToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закупкаФурнитурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кожаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остаткиКожиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.остаткиФурнитурыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияЗаМесяцToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списанаяКожаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.заказыToolStripMenuItem,
            this.заказыToolStripMenuItem1,
            this.изделияToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 34);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заказчикиToolStripMenuItem,
            this.видыИзделийToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // заказчикиToolStripMenuItem
            // 
            this.заказчикиToolStripMenuItem.Name = "заказчикиToolStripMenuItem";
            this.заказчикиToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.заказчикиToolStripMenuItem.Text = "Заказчики";
            this.заказчикиToolStripMenuItem.Click += new System.EventHandler(this.заказчикиToolStripMenuItem_Click);
            // 
            // видыИзделийToolStripMenuItem
            // 
            this.видыИзделийToolStripMenuItem.Name = "видыИзделийToolStripMenuItem";
            this.видыИзделийToolStripMenuItem.Size = new System.Drawing.Size(235, 30);
            this.видыИзделийToolStripMenuItem.Text = "Виды изделий";
            this.видыИзделийToolStripMenuItem.Click += new System.EventHandler(this.видыИзделийToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem
            // 
            this.заказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фурнитураToolStripMenuItem,
            this.закупкаФурнитурыToolStripMenuItem,
            this.кожаToolStripMenuItem});
            this.заказыToolStripMenuItem.Name = "заказыToolStripMenuItem";
            this.заказыToolStripMenuItem.Size = new System.Drawing.Size(134, 30);
            this.заказыToolStripMenuItem.Text = "Материалы";
            // 
            // фурнитураToolStripMenuItem
            // 
            this.фурнитураToolStripMenuItem.Name = "фурнитураToolStripMenuItem";
            this.фурнитураToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.фурнитураToolStripMenuItem.Text = "Фурнитура";
            this.фурнитураToolStripMenuItem.Click += new System.EventHandler(this.фурнитураToolStripMenuItem_Click);
            // 
            // закупкаФурнитурыToolStripMenuItem
            // 
            this.закупкаФурнитурыToolStripMenuItem.Name = "закупкаФурнитурыToolStripMenuItem";
            this.закупкаФурнитурыToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.закупкаФурнитурыToolStripMenuItem.Text = "Закупка фурнитуры";
            this.закупкаФурнитурыToolStripMenuItem.Click += new System.EventHandler(this.фурнитураToolStripMenuItem1_Click);
            // 
            // кожаToolStripMenuItem
            // 
            this.кожаToolStripMenuItem.Name = "кожаToolStripMenuItem";
            this.кожаToolStripMenuItem.Size = new System.Drawing.Size(293, 30);
            this.кожаToolStripMenuItem.Text = "Кожа";
            this.кожаToolStripMenuItem.Click += new System.EventHandler(this.кожаToolStripMenuItem_Click);
            // 
            // заказыToolStripMenuItem1
            // 
            this.заказыToolStripMenuItem1.Name = "заказыToolStripMenuItem1";
            this.заказыToolStripMenuItem1.Size = new System.Drawing.Size(93, 30);
            this.заказыToolStripMenuItem1.Text = "Заказы";
            this.заказыToolStripMenuItem1.Click += new System.EventHandler(this.заказыToolStripMenuItem1_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(106, 30);
            this.изделияToolStripMenuItem.Text = "Изделия";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.остаткиКожиToolStripMenuItem,
            this.остаткиФурнитурыToolStripMenuItem,
            this.изделияЗаМесяцToolStripMenuItem,
            this.заказыЗаПериодToolStripMenuItem,
            this.списанаяКожаToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(100, 30);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // остаткиКожиToolStripMenuItem
            // 
            this.остаткиКожиToolStripMenuItem.Name = "остаткиКожиToolStripMenuItem";
            this.остаткиКожиToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.остаткиКожиToolStripMenuItem.Text = "Остатки кожи";
            this.остаткиКожиToolStripMenuItem.Click += new System.EventHandler(this.остаткиКожиToolStripMenuItem_Click);
            // 
            // остаткиФурнитурыToolStripMenuItem
            // 
            this.остаткиФурнитурыToolStripMenuItem.Name = "остаткиФурнитурыToolStripMenuItem";
            this.остаткиФурнитурыToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.остаткиФурнитурыToolStripMenuItem.Text = "Остатки фурнитуры";
            this.остаткиФурнитурыToolStripMenuItem.Click += new System.EventHandler(this.остаткиФурнитурыToolStripMenuItem_Click);
            // 
            // изделияЗаМесяцToolStripMenuItem
            // 
            this.изделияЗаМесяцToolStripMenuItem.Name = "изделияЗаМесяцToolStripMenuItem";
            this.изделияЗаМесяцToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.изделияЗаМесяцToolStripMenuItem.Text = "Изделия за период";
            this.изделияЗаМесяцToolStripMenuItem.Click += new System.EventHandler(this.изделияЗаМесяцToolStripMenuItem_Click);
            // 
            // заказыЗаПериодToolStripMenuItem
            // 
            this.заказыЗаПериодToolStripMenuItem.Name = "заказыЗаПериодToolStripMenuItem";
            this.заказыЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.заказыЗаПериодToolStripMenuItem.Text = "Заказы за период";
            this.заказыЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.заказыЗаПериодToolStripMenuItem_Click);
            // 
            // списанаяКожаToolStripMenuItem
            // 
            this.списанаяКожаToolStripMenuItem.Name = "списанаяКожаToolStripMenuItem";
            this.списанаяКожаToolStripMenuItem.Size = new System.Drawing.Size(343, 30);
            this.списанаяКожаToolStripMenuItem.Text = "Списаная кожа за период";
            this.списанаяКожаToolStripMenuItem.Click += new System.EventHandler(this.списанаяКожаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(88, 30);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(973, 491);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 528);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Учет заказов и материалов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказчикиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фурнитураToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кожаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem закупкаФурнитурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остаткиКожиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem остаткиФурнитурыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияЗаМесяцToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыЗаПериодToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списанаяКожаToolStripMenuItem;
    }
}


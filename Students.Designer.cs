namespace Учёт_студентов
{
    partial class Students
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.группаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьГруппуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.студентToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтудентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.группаToolStripMenuItem,
            this.студентToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // группаToolStripMenuItem
            // 
            this.группаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьГруппуToolStripMenuItem,
            this.уToolStripMenuItem});
            this.группаToolStripMenuItem.Name = "группаToolStripMenuItem";
            this.группаToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.группаToolStripMenuItem.Text = "Группа";
            // 
            // добавитьГруппуToolStripMenuItem
            // 
            this.добавитьГруппуToolStripMenuItem.Name = "добавитьГруппуToolStripMenuItem";
            this.добавитьГруппуToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.добавитьГруппуToolStripMenuItem.Text = "Добавить группу";
            this.добавитьГруппуToolStripMenuItem.Click += new System.EventHandler(this.добавитьГруппуToolStripMenuItem_Click);
            // 
            // уToolStripMenuItem
            // 
            this.уToolStripMenuItem.Name = "уToolStripMenuItem";
            this.уToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.уToolStripMenuItem.Text = "Удалить группу";
            this.уToolStripMenuItem.Click += new System.EventHandler(this.уToolStripMenuItem_Click);
            // 
            // студентToolStripMenuItem
            // 
            this.студентToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьСтудентаToolStripMenuItem,
            this.удалитьСтудентаToolStripMenuItem,
            this.изменитьСтудентаToolStripMenuItem});
            this.студентToolStripMenuItem.Name = "студентToolStripMenuItem";
            this.студентToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.студентToolStripMenuItem.Text = "Студент";
            // 
            // добавитьСтудентаToolStripMenuItem
            // 
            this.добавитьСтудентаToolStripMenuItem.Name = "добавитьСтудентаToolStripMenuItem";
            this.добавитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.добавитьСтудентаToolStripMenuItem.Text = "Добавить студента";
            this.добавитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.добавитьСтудентаToolStripMenuItem_Click);
            // 
            // удалитьСтудентаToolStripMenuItem
            // 
            this.удалитьСтудентаToolStripMenuItem.Name = "удалитьСтудентаToolStripMenuItem";
            this.удалитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.удалитьСтудентаToolStripMenuItem.Text = "Удалить студента";
            this.удалитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.удалитьСтудентаToolStripMenuItem_Click);
            // 
            // изменитьСтудентаToolStripMenuItem
            // 
            this.изменитьСтудентаToolStripMenuItem.Name = "изменитьСтудентаToolStripMenuItem";
            this.изменитьСтудентаToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.изменитьСтудентаToolStripMenuItem.Text = "Изменить студента";
            this.изменитьСтудентаToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтудентаToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(775, 410);
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            this.dataGridView1.TabIndex = 1;
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт студентов";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem группаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьГруппуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem студентToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтудентаToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}


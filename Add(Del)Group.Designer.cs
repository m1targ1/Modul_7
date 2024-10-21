namespace Учёт_студентов
{
    partial class Add_Del_Group
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
            this.comboBox_Group = new System.Windows.Forms.ComboBox();
            this.textBox_Group = new System.Windows.Forms.TextBox();
            this.button_AddGroup = new System.Windows.Forms.Button();
            this.button_DelGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Group
            // 
            this.comboBox_Group.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Group.FormattingEnabled = true;
            this.comboBox_Group.Location = new System.Drawing.Point(12, 12);
            this.comboBox_Group.Name = "comboBox_Group";
            this.comboBox_Group.Size = new System.Drawing.Size(236, 21);
            this.comboBox_Group.TabIndex = 0;
            // 
            // textBox_Group
            // 
            this.textBox_Group.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Group.Location = new System.Drawing.Point(13, 13);
            this.textBox_Group.Name = "textBox_Group";
            this.textBox_Group.Size = new System.Drawing.Size(235, 20);
            this.textBox_Group.TabIndex = 1;
            // 
            // button_AddGroup
            // 
            this.button_AddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_AddGroup.Location = new System.Drawing.Point(13, 39);
            this.button_AddGroup.Name = "button_AddGroup";
            this.button_AddGroup.Size = new System.Drawing.Size(235, 24);
            this.button_AddGroup.TabIndex = 2;
            this.button_AddGroup.Text = "Добавить";
            this.button_AddGroup.UseVisualStyleBackColor = true;
            this.button_AddGroup.Click += new System.EventHandler(this.button_AddGroup_Click);
            // 
            // button_DelGroup
            // 
            this.button_DelGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_DelGroup.Location = new System.Drawing.Point(13, 39);
            this.button_DelGroup.Name = "button_DelGroup";
            this.button_DelGroup.Size = new System.Drawing.Size(235, 24);
            this.button_DelGroup.TabIndex = 3;
            this.button_DelGroup.Text = "Удалить";
            this.button_DelGroup.UseVisualStyleBackColor = true;
            this.button_DelGroup.Click += new System.EventHandler(this.button_DelGroup_Click);
            // 
            // Add_Del_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 72);
            this.Controls.Add(this.button_DelGroup);
            this.Controls.Add(this.button_AddGroup);
            this.Controls.Add(this.textBox_Group);
            this.Controls.Add(this.comboBox_Group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Add_Del_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Группа";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox_Group;
        public System.Windows.Forms.TextBox textBox_Group;
        public System.Windows.Forms.Button button_AddGroup;
        public System.Windows.Forms.Button button_DelGroup;
    }
}
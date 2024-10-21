namespace Учёт_студентов
{
    partial class Add_Del_Students
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
            this.comboBox_Student = new System.Windows.Forms.ComboBox();
            this.textBox_Student = new System.Windows.Forms.TextBox();
            this.button_AddStudent = new System.Windows.Forms.Button();
            this.button_DelStudent = new System.Windows.Forms.Button();
            this.button_EditStudent = new System.Windows.Forms.Button();
            this.comboBox_Group = new System.Windows.Forms.ComboBox();
            this.textBox_Birth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_Student
            // 
            this.comboBox_Student.FormattingEnabled = true;
            this.comboBox_Student.Location = new System.Drawing.Point(10, 33);
            this.comboBox_Student.Name = "comboBox_Student";
            this.comboBox_Student.Size = new System.Drawing.Size(236, 21);
            this.comboBox_Student.TabIndex = 0;
            // 
            // textBox_Student
            // 
            this.textBox_Student.Location = new System.Drawing.Point(11, 34);
            this.textBox_Student.Name = "textBox_Student";
            this.textBox_Student.Size = new System.Drawing.Size(235, 20);
            this.textBox_Student.TabIndex = 1;
            // 
            // button_AddStudent
            // 
            this.button_AddStudent.Location = new System.Drawing.Point(11, 139);
            this.button_AddStudent.Name = "button_AddStudent";
            this.button_AddStudent.Size = new System.Drawing.Size(235, 23);
            this.button_AddStudent.TabIndex = 2;
            this.button_AddStudent.Text = "Добавить";
            this.button_AddStudent.UseVisualStyleBackColor = true;
            this.button_AddStudent.Click += new System.EventHandler(this.button_AddStudent_Click);
            // 
            // button_DelStudent
            // 
            this.button_DelStudent.Location = new System.Drawing.Point(11, 139);
            this.button_DelStudent.Name = "button_DelStudent";
            this.button_DelStudent.Size = new System.Drawing.Size(235, 23);
            this.button_DelStudent.TabIndex = 3;
            this.button_DelStudent.Text = "Удалить";
            this.button_DelStudent.UseVisualStyleBackColor = true;
            this.button_DelStudent.Click += new System.EventHandler(this.button_DelStudent_Click);
            // 
            // button_EditStudent
            // 
            this.button_EditStudent.Location = new System.Drawing.Point(11, 139);
            this.button_EditStudent.Name = "button_EditStudent";
            this.button_EditStudent.Size = new System.Drawing.Size(234, 23);
            this.button_EditStudent.TabIndex = 4;
            this.button_EditStudent.Text = "Изменить";
            this.button_EditStudent.UseVisualStyleBackColor = true;
            this.button_EditStudent.Click += new System.EventHandler(this.button_EditStudent_Click);
            // 
            // comboBox_Group
            // 
            this.comboBox_Group.FormattingEnabled = true;
            this.comboBox_Group.Location = new System.Drawing.Point(10, 73);
            this.comboBox_Group.Name = "comboBox_Group";
            this.comboBox_Group.Size = new System.Drawing.Size(235, 21);
            this.comboBox_Group.TabIndex = 5;
            // 
            // textBox_Birth
            // 
            this.textBox_Birth.Location = new System.Drawing.Point(10, 113);
            this.textBox_Birth.Name = "textBox_Birth";
            this.textBox_Birth.Size = new System.Drawing.Size(236, 20);
            this.textBox_Birth.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Дата рождения:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Группа:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "ФИО студента:";
            // 
            // Add_Del_Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 168);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Birth);
            this.Controls.Add(this.comboBox_Group);
            this.Controls.Add(this.button_EditStudent);
            this.Controls.Add(this.button_DelStudent);
            this.Controls.Add(this.button_AddStudent);
            this.Controls.Add(this.textBox_Student);
            this.Controls.Add(this.comboBox_Student);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Add_Del_Students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Студент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox comboBox_Student;
        public System.Windows.Forms.TextBox textBox_Student;
        public System.Windows.Forms.Button button_AddStudent;
        public System.Windows.Forms.Button button_DelStudent;
        public System.Windows.Forms.Button button_EditStudent;
        public System.Windows.Forms.ComboBox comboBox_Group;
        public System.Windows.Forms.TextBox textBox_Birth;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
    }
}
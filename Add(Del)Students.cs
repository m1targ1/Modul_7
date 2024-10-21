using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Учёт_студентов
{
    public partial class Add_Del_Students : Form
    {
        DataBase dataBase = new DataBase();
        public Add_Del_Students()
        {
            InitializeComponent();
            LoadGroups(); // Загружаем группы в comboBox_Group при загрузке формы
            LoadStudents(); // Загружаем студентов в comboBox_Student
        }

        private void button_AddStudent_Click(object sender, EventArgs e)
        {
            string studentName = textBox_Student.Text;
            string birthDate = textBox_Birth.Text;
            string groupName = comboBox_Group.SelectedItem.ToString();
            dataBase.open();
            SqlCommand command = new SqlCommand(
            "INSERT INTO Студенты (ФИО, ДатаРождения, Группа) VALUES (@ФИО, @ДатаРождения, @Группа)", dataBase.GetConnection());
            command.Parameters.AddWithValue("@ФИО", studentName);
            command.Parameters.AddWithValue("@ДатаРождения", birthDate);
            command.Parameters.AddWithValue("@Группа", groupName);
            command.ExecuteNonQuery();

            MessageBox.Show("Студент добавлен.");
            LoadStudents(); // Обновляем список студентов
        }

        private void button_DelStudent_Click(object sender, EventArgs e)
        {
            string selectedStudent = comboBox_Student.SelectedItem.ToString();

            dataBase.open();
            SqlCommand command = new SqlCommand(
                "DELETE FROM Студенты WHERE ФИО = @ФИО", dataBase.GetConnection());
            command.Parameters.AddWithValue("@ФИО", selectedStudent);
            command.ExecuteNonQuery();
            MessageBox.Show("Студент удалён.");
            LoadStudents(); // Обновляем список студентов

        }

        private void button_EditStudent_Click(object sender, EventArgs e)
        {
            string selectedStudent = comboBox_Student.SelectedItem.ToString();
            StudentView studentView = new StudentView(selectedStudent);
            studentView.Show();
            LoadStudents();
        }

        // Метод для загрузки групп в comboBox_Group
        private void LoadGroups()
        {
                dataBase.open();
                SqlCommand command = new SqlCommand("SELECT group_name FROM Группы", dataBase.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                comboBox_Group.Items.Clear();

                while (reader.Read())
                {
                    comboBox_Group.Items.Add(reader["group_name"].ToString());
                }

                reader.Close();
        }

        // Метод для загрузки студентов в comboBox_Student
        private void LoadStudents()
        {
                dataBase.open();
                SqlCommand command = new SqlCommand("SELECT ФИО FROM Студенты", dataBase.GetConnection());
                SqlDataReader reader = command.ExecuteReader();
                comboBox_Student.Items.Clear();

                while (reader.Read())
                {
                    comboBox_Student.Items.Add(reader["ФИО"].ToString());
                }

                reader.Close();

        }
    }
}

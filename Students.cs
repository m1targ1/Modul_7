using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Учёт_студентов
{
    public partial class Students : Form
    {
        DataBase database = new DataBase();
        public Students()
        {
            InitializeComponent();
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void CreateColumns() // Метод создания колонок
        {
            dataGridView1.Columns.Add("IDгруппы", "Номер"); // на первом месте - название в БД, на втором - отображение на форме
            dataGridView1.Columns.Add("group_name", "Группа");
        }
        private void ReadRow(DataGridView drv, IDataRecord record)
        {
            drv.Rows.Add(record.GetInt32(0), record.GetString(1));
        }

        // Метод для загрузки списка групп из базы данных
        public void RefreshDataGrid(DataGridView drv) // Метод обновления таблицы
        {
            drv.Rows.Clear(); // Очистка строк
            string queryString = $"select * from Группы"; // Выбор таблицы БД для отображения
            SqlCommand command = new SqlCommand(queryString, database.GetConnection()); // SQL запрос на доступ к БД
            database.open(); // Открытие БД
            SqlDataReader reader = command.ExecuteReader(); // Просмотр данных из таблицы в БД
            while (reader.Read()) // Добавление данных в datagridview 
            {
                ReadRow(drv, reader);
            }
            reader.Close(); // Закрытие просмотра
        }

        private void добавитьГруппуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Del_Group add_Del_Group = new Add_Del_Group(this, dataGridView1);
            add_Del_Group.button_DelGroup.Visible = false;
            add_Del_Group.comboBox_Group.Visible = false;
            add_Del_Group.Show(); 
        }

        private void уToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Del_Group add_Del_Group = new Add_Del_Group(this, dataGridView1);
            add_Del_Group.button_AddGroup.Visible = false;
            add_Del_Group.textBox_Group.Visible = false;
            add_Del_Group.Show();
        }

        private void добавитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Del_Students add_Del_Students = new Add_Del_Students();
            add_Del_Students.button_DelStudent.Visible = false;
            add_Del_Students.button_EditStudent.Visible = false;
            add_Del_Students.comboBox_Student.Visible = false;
            add_Del_Students.Show();
        }

        private void удалитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Del_Students add_Del_Students = new Add_Del_Students();
            add_Del_Students.button_AddStudent.Visible = false;
            add_Del_Students.button_EditStudent.Visible = false;
            add_Del_Students.textBox_Student.Visible = false;
            add_Del_Students.textBox_Birth.Visible = false;
            add_Del_Students.Show();
        }

        private void изменитьСтудентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Del_Students add_Del_Students = new Add_Del_Students();
            add_Del_Students.button_AddStudent.Visible = false;
            add_Del_Students.button_DelStudent.Visible = false;
            add_Del_Students.textBox_Student.Visible = false;
            add_Del_Students.textBox_Birth.Visible = false;
            add_Del_Students.comboBox_Group.Visible = false;
            add_Del_Students.Show();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Проверяем, что кликнули по строке, а не по заголовку
                {
                    string groupName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // Получаем название группы
                    GroupView groupView = new GroupView(groupName); // Создаем экземпляр GroupView
                    groupView.Show(); // Показываем форму
                }
            } 
            catch 
            {
                MessageBox.Show("Некорректный выбор.");
            }
        }
    }
}

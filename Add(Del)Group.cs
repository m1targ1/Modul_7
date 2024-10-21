using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Учёт_студентов
{
    public partial class Add_Del_Group : Form
    {
        DataBase database = new DataBase(); // Объект для работы с базой данных
        private Students _studentsForm; // Поле для хранения ссылки на форму студентов
        private DataGridView _dataGridView; // Поле для хранения ссылки на DataGridView

        public Add_Del_Group(Students studentsForm, DataGridView dataGridView1)
        {
            InitializeComponent();
            _studentsForm = studentsForm;
            _dataGridView = dataGridView1;
            LoadComboBox(); // Загрузка данных в comboBox при открытии формы
        }

        // Метод для загрузки списка групп в comboBox_Group
        private void LoadComboBox()
        {
            comboBox_Group.Items.Clear(); // Очищаем comboBox перед добавлением новых элементов
            string queryString = "SELECT group_name FROM Группы"; // Запрос на получение всех групп из БД
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());

            database.open(); // Открываем соединение с базой данных
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox_Group.Items.Add(reader["group_name"].ToString()); // Добавляем группы в comboBox
            }

            reader.Close();
            database.close();
        }

        // Обработчик для кнопки "Добавить группу"
        private void button_AddGroup_Click(object sender, EventArgs e)
        {
            string newGroup = textBox_Group.Text.Trim();

            if (!string.IsNullOrEmpty(newGroup))
            {
                string queryString = $"INSERT INTO Группы (group_name) VALUES ('{newGroup}')"; // Запрос на добавление новой группы
                SqlCommand command = new SqlCommand(queryString, database.GetConnection());

                database.open();
                command.ExecuteNonQuery();
                database.close();

                MessageBox.Show("Группа добавлена успешно!");

                LoadComboBox(); // Обновляем список групп в comboBox
                _studentsForm.RefreshDataGrid(_dataGridView); // Обновляем таблицу на основной форме
            }
            else
            {
                MessageBox.Show("Введите название группы.");
            }
        }

        // Обработчик для кнопки "Удалить группу"
        private void button_DelGroup_Click(object sender, EventArgs e)
        {
            string selectedGroup = comboBox_Group.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedGroup))
            {
                string queryString = $"DELETE FROM Группы WHERE group_name = '{selectedGroup}'"; // Запрос на удаление группы
                SqlCommand command = new SqlCommand(queryString, database.GetConnection());

                database.open();
                command.ExecuteNonQuery();
                database.close();

                MessageBox.Show("Группа удалена успешно!");

                LoadComboBox(); // Обновляем список групп в comboBox
                _studentsForm.RefreshDataGrid(_dataGridView); // Обновляем таблицу на основной форме
            }
            else
            {
                MessageBox.Show("Выберите группу для удаления.");
            }
        }
    }
}

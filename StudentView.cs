using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Учёт_студентов
{
    public partial class StudentView : Form
    {
        DataBase dataBase = new DataBase();
        private string selectedStudentName; // Хранит имя выбранного студента
        public StudentView(string studentName)
        {
            InitializeComponent();
            selectedStudentName = studentName; // Сохраняем имя студента
            label2.Text = selectedStudentName; // Устанавливаем имя в label2
            LoadStudents(); // Загружаем студентов при инициализации формы
        }

        private void LoadStudents()
        {
            try
            {
                dataBase.open();
                DataTable studentsTable = new DataTable();
                string query = "SELECT * FROM Студенты"; // Замените на ваш SQL-запрос
                using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(studentsTable); // Заполняем DataTable
                }
                dataGridView_PersonData.DataSource = studentsTable; // Привязываем данные к DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке студентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.close();
            }
        }

        // Обработчик нажатия на кнопку "Сохранить изменения"
        private void button_SaveEdit_Click(object sender, EventArgs e)
        {
            DataTable changes = ((DataTable)dataGridView_PersonData.DataSource).GetChanges();

            if (changes != null)
            {
                try
                {
                    dataBase.open();

                    foreach (DataRow row in changes.Rows)
                    {
                        if (row.RowState == DataRowState.Modified)
                        {
                            int studentId = (int)row["IDСтудента"]; // Предполагаем, что у вас есть поле Id
                            string name = row["ФИО"].ToString();
                            string birth = row["ДатаРождения"].ToString();
                            string group = row["Группа"].ToString();

                            // SQL-запрос на обновление
                            string query = "UPDATE Студенты SET ФИО = @Name, ДатаРождения = @ДатаРождения, Группа = @Группа WHERE IdСтудента = @Id";
                            using (SqlCommand command = new SqlCommand(query, dataBase.GetConnection()))
                            {
                                command.Parameters.AddWithValue("@Id", studentId);
                                command.Parameters.AddWithValue("@Name", name);
                                command.Parameters.AddWithValue("@ДатаРождения", birth);
                                command.Parameters.AddWithValue("@Группа", group);
                                // Добавьте другие параметры, если нужно
                                command.ExecuteNonQuery();
                            }
                        }
                    }

                    // Применение изменений
                    ((DataTable)dataGridView_PersonData.DataSource).AcceptChanges();
                    MessageBox.Show("Изменения успешно сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    dataBase.close();
                }
            }
            else
            {
                MessageBox.Show("Нет изменений для сохранения.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

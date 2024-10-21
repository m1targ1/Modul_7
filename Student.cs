using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Учёт_студентов
{
    public partial class Student : Form
    {
        private DataBase database = new DataBase();
        private string studentName;
        private SqlConnection connection; // Поле для соединения
        private double overallAverage;

        public Student(string studentName)
        {
            InitializeComponent();
            this.studentName = studentName;
            label2.Text = studentName; // Устанавливаем ФИО студента в label2
            CreateColumns();
            connection = database.GetConnection();
            connection.Open();

            LoadGradesData();
        }

        private void CreateColumns()
        {
            dataGridView_Info.Columns.Add("Предмет", "Предмет");
            dataGridView_Info.Columns.Add("Оценка", "Оценка");
            dataGridView_Info.Columns.Add("СреднийБалл", "Средний балл");
        }

        private void LoadGradesData()
        {
            dataGridView_Info.Rows.Clear(); // Очистка строк перед загрузкой данных

            string queryString = @"
    SELECT 
        p.Название 
    FROM 
        Предметы p";

            var subjectsWithGrades = new List<Tuple<string, List<string>, decimal>>(); // Список предметов, оценок и средних баллов

            using (SqlCommand command = new SqlCommand(queryString, connection)) // Используем открытое соединение
            {
                using (SqlDataReader reader = command.ExecuteReader()) // Выполняем запрос
                {
                    while (reader.Read())
                    {
                        string subject = reader.GetString(0); // Название предмета
                        List<string> gradesList = LoadGradesForSubject(subject); // Загружаем оценки для предмета
                        decimal averageScore = CalculateAverageScore(subject); // Вычисляем средний балл

                        subjectsWithGrades.Add(new Tuple<string, List<string>, decimal>(subject, gradesList, averageScore)); // Сохраняем предмет, оценки и средний балл
                    }
                }
            }
            // Теперь добавляем предметы и их оценки в DataGridView
            foreach (var item in subjectsWithGrades)
            {
                string gradesDisplay = item.Item2.Count > 0 ? string.Join(", ", item.Item2) : "Нет оценок"; // Форматируем отображение оценок
                dataGridView_Info.Rows.Add(item.Item1, gradesDisplay, item.Item3); // Добавляем предмет, оценки и средний балл
            }
            // Вычисляем общий средний балл и обновляем label4
            // Вычисляем общий средний балл и обновляем label4
            overallAverage = CalculateOverallAverage(); // Сохраняем значение в поле
            label4.Text = overallAverage.ToString("F2"); // Форматируем до двух знаков после запятой

            // Сохраняем общий средний балл в БД
            SaveOverallAverage(overallAverage);
        }

        private List<string> LoadGradesForSubject(string subject)
        {
            string queryString = @"
    SELECT Оценка 
    FROM Оценки 
    WHERE Студент = @studentName AND Предмет = @subject";

            var grades = new List<string>(); // Список для хранения оценок

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@studentName", studentName);
                command.Parameters.AddWithValue("@subject", subject);

                using (SqlDataReader reader = command.ExecuteReader()) // Выполняем запрос
                {
                    while (reader.Read())
                    {
                        grades.Add(reader.GetString(0)); // Добавляем каждую оценку в список
                    }
                }
            }

            return grades; // Возвращаем список оценок
        }

        private decimal CalculateAverageScore(string subject)
        {
            string queryString = @"
    SELECT AVG(TRY_CAST(Оценка AS DECIMAL(10, 2))) 
    FROM Оценки 
    WHERE Студент = @studentName AND Предмет = @subject AND Оценка IS NOT NULL AND Оценка <> ''";

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@studentName", studentName);
                command.Parameters.AddWithValue("@subject", subject);

                var result = command.ExecuteScalar(); // Получаем результат

                return result != DBNull.Value ? (decimal)result : 0; // Возвращаем средний балл или 0
            }
        }

        private void SaveGrade(string subject, string grade)
        {
            // Здесь вы можете создать отдельный метод для добавления оценки
            string queryString = @"
        INSERT INTO Оценки (Студент, Предмет, Оценка) 
        VALUES (@studentName, @subject, @grade)";

            using (SqlCommand command = new SqlCommand(queryString, connection)) // Используем открытое соединение
            {
                command.Parameters.AddWithValue("@studentName", studentName);
                command.Parameters.AddWithValue("@subject", subject);
                command.Parameters.AddWithValue("@grade", grade);

                command.ExecuteNonQuery(); // Выполняем запрос
            }
        }

        private void dataGridView_Info_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) // Проверяем, что редактировалась колонка "Оценка"
            {
                string subject = dataGridView_Info.Rows[e.RowIndex].Cells[0].Value.ToString(); // Получаем предмет
                string gradesInput = dataGridView_Info.Rows[e.RowIndex].Cells[1].Value.ToString(); // Получаем введённые оценки
                // Разбиваем введённые оценки по запятой
                string[] grades = gradesInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                // Удаляем старые оценки для данного предмета
                DeleteOldGrades(subject);

                // Сохраняем каждую оценку в БД
                foreach (string grade in grades)
                {
                    string trimmedGrade = grade.Trim(); // Убираем лишние пробелы
                    if (!string.IsNullOrEmpty(trimmedGrade))
                    {
                        SaveGrade(subject, trimmedGrade); // Сохраняем оценку в БД
                    }
                }
                // Перезагружаем данные, чтобы обновить средний балл
                LoadGradesData();
            }
        }

        private double CalculateOverallAverage()
        {
            double totalScore = 0;
            int subjectCount = 0;

            foreach (DataGridViewRow row in dataGridView_Info.Rows)
            {
                if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double averageScore))
                {
                    totalScore += averageScore;
                    subjectCount++;
                }
            }
            return subjectCount > 0 ? totalScore / subjectCount : 0; // Возвращаем общий средний балл или 0
        }

        public void SaveOverallAverage (double overallAverage)
        {
            // Округляем значение до двух знаков после запятой
            double roundedAverage = Math.Round(overallAverage, 2);

            string queryString = @"
        UPDATE Студенты 
        SET СреднийБалл = @overallAverage 
        WHERE ФИО = @studentName";

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                // Явно указываем тип данных для параметра
                command.Parameters.Add("@overallAverage", SqlDbType.Float).Value = roundedAverage;
                command.Parameters.AddWithValue("@studentName", studentName);

                try
                {
                    command.ExecuteNonQuery(); // Выполняем запрос
                }
                catch (SqlException ex)
                {
                    // Обработка исключений для дальнейшего анализа
                    MessageBox.Show("Ошибка при сохранении среднего балла: " + ex.Message);
                }
            }
        }
        private void DeleteOldGrades(string subject)
        {
            string queryString = @"
        DELETE FROM Оценки 
        WHERE Студент = @studentName AND Предмет = @subject";

            using (SqlCommand command = new SqlCommand(queryString, connection))
            {
                command.Parameters.AddWithValue("@studentName", studentName);
                command.Parameters.AddWithValue("@subject", subject);

                command.ExecuteNonQuery(); // Выполняем запрос для удаления старых оценок
            }
        }

        private void button_ОтчётСтудент_Click(object sender, EventArgs e)
        {
            // Собираем данные для печати
            var reportData = GetReportData(); // Предположим, это метод, который собирает нужные данные

            // Открываем диалоговое окно для выбора принтера
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Создаем экземпляр PrintDocument
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, ev) => PrintPageHandler(ev, reportData, overallAverage); // Передаем общий средний балл
                printDocument.PrinterSettings = printDialog.PrinterSettings;

                // Запускаем печать
                printDocument.Print();
            }
        }

        private void PrintPageHandler(PrintPageEventArgs ev, List<ReportItem> reportData, double overallAverage)
        {
            // Настройки шрифта
            Font font = new Font("Times New Roman", 12);
            float lineHeight = font.GetHeight(ev.Graphics) + 4;
            float x = ev.MarginBounds.Left;
            float y = ev.MarginBounds.Top;

            // Заголовок
            ev.Graphics.DrawString($"Отчет по студенту: {studentName}", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, x, y);
            y += lineHeight;
            ev.Graphics.DrawString($"Общий средний балл: {overallAverage:F2}", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, x, y); // Используем форматирование
            y += lineHeight * 2;

            // Заголовки колонок
            ev.Graphics.DrawString("Предмет", font, Brushes.Black, x, y);
            ev.Graphics.DrawString("Оценка", font, Brushes.Black, x + 200, y);
            ev.Graphics.DrawString("Средний балл", font, Brushes.Black, x + 500, y);
            y += lineHeight;

            // Выводим данные
            foreach (var item in reportData)
            {
                ev.Graphics.DrawString(item.StudentName, font, Brushes.Black, x, y);
                ev.Graphics.DrawString(item.Subject, font, Brushes.Black, x + 200, y);
                ev.Graphics.DrawString(item.Grade.ToString(), font, Brushes.Black, x + 500, y);
                y += lineHeight;
            }
        }

        private List<ReportItem> GetReportData()
        {
            var reportData = new List<ReportItem>();

            // Проходим по строкам в dataGridView_Info
            foreach (DataGridViewRow row in dataGridView_Info.Rows)
            {
                // Проверяем, что строка не новая и имеет данные
                if (row.IsNewRow) continue; // Пропускаем новую строку

                // Получаем имя студента, название предмета и оценку
                string studentName = row.Cells[0].Value?.ToString(); // Предполагаем, что ФИО в первом столбце
                string subject = row.Cells[1].Value?.ToString(); // Предполагаем, что предмет во втором столбце
                string gradeValue = row.Cells[2].Value?.ToString(); // Предполагаем, что оценка в третьем столбце

                // Проверяем, что все значения не равны null
                if (!string.IsNullOrEmpty(studentName) && !string.IsNullOrEmpty(subject) && double.TryParse(gradeValue, out double grade))
                {
                    reportData.Add(new ReportItem
                    {
                        StudentName = studentName,
                        Subject = subject,
                        Grade = grade
                    });
                }
            }
            return reportData;
        }
        public class ReportItem
        {
            public string StudentName { get; set; }
            public string Subject { get; set; }
            public double Grade { get; set; }
        }
    }
}

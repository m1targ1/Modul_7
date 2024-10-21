using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Учёт_студентов
{
    public partial class GroupView : Form
    {
        private DataBase database = new DataBase();
        private string groupName;

        public GroupView(string groupName)
        {
            InitializeComponent();
            this.groupName = groupName;
            label2.Text = groupName; // Устанавливаем название группы в label2
            CreateColumns();
            LoadStudentData();
        }

        private void CreateColumns()
        {
            dataGridView_StudentGroup.Columns.Add("ФИОСтудента", "ФИО Студента");
            dataGridView_StudentGroup.Columns.Add("Группа", "Группа");
            dataGridView_StudentGroup.Columns.Add("СреднийБалл", "Средний балл");
        }

        private void LoadStudentData()
        {
            dataGridView_StudentGroup.Rows.Clear(); // Очистка строк перед загрузкой данных

            string queryString = $"SELECT ФИО, Группа, СреднийБалл FROM Студенты WHERE Группа = @groupName";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            command.Parameters.AddWithValue("@groupName", groupName); // Передаем название группы как параметр

            database.open(); // Открываем соединение с БД

            SqlDataReader reader = command.ExecuteReader(); // Выполняем запрос
            while (reader.Read())
            {
                // Получаем ФИО и Группу, которые не могут быть NULL
                string fio = reader.GetString(0);
                string group = reader.GetString(1);
                string averageScore = reader.GetString(2);

                dataGridView_StudentGroup.Rows.Add(fio, group, averageScore);
            }

            reader.Close(); // Закрываем reader
        }

        private void dataGridView_StudentGroup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Проверяем, что кликнули по строке
            {
                string studentName = dataGridView_StudentGroup.Rows[e.RowIndex].Cells[0].Value.ToString(); // Получаем ФИО студента
                Student studentForm = new Student(studentName); // Создаем экземпляр Student
                studentForm.Show(); // Показываем форму
            }
        }

        private double CalculateOverallAverage()
        {
            double totalSum = 0;
            int count = 0;

            foreach (DataGridViewRow row in dataGridView_StudentGroup.Rows)
            {
                if (row.IsNewRow) continue; // Пропускаем новую строку

                string avgValue = row.Cells[2]?.Value?.ToString(); // Индекс 2 — Средний балл

                if (!string.IsNullOrEmpty(avgValue))
                {
                    // Заменяем точки на запятые для корректного преобразования
                    avgValue = avgValue.Replace('.', ',');

                    // Используем русскую культуру для правильного распознавания числа с запятой
                    if (double.TryParse(avgValue, NumberStyles.Any, CultureInfo.GetCultureInfo("ru-RU"), out double average))
                    {
                        totalSum += average;
                        count++;
                    }
                    else
                    {
                        // Выводим сообщение для отладки, если значение не может быть преобразовано
                        MessageBox.Show($"Невозможно преобразовать значение '{avgValue}' в число. Проверьте данные.", "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            // Возвращаем результат, если есть данные, иначе 0
            return count > 0 ? totalSum / count : 0;
        }

        private void button_ОтчётГруппа_Click(object sender, EventArgs e)
        {
            // Собираем данные для печати
            var reportData = GetReportData(); // Метод для сбора данных

            // Вычисляем общий средний балл по группе
            double overallAverage = CalculateOverallAverage();

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
            ev.Graphics.DrawString($"Отчет по группе: {groupName}", new Font("Times New Roman", 16, FontStyle.Bold), Brushes.Black, x, y);
            y += lineHeight;
            ev.Graphics.DrawString($"Общий средний балл по группе: {overallAverage:F2}", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, x, y); // Форматируем средний балл
            y += lineHeight * 2;

            // Заголовки колонок
            ev.Graphics.DrawString("ФИО", font, Brushes.Black, x, y);
            ev.Graphics.DrawString("Средний балл", font, Brushes.Black, x + 500, y);
            y += lineHeight;

            // Выводим данные
            foreach (var item in reportData)
            {
                ev.Graphics.DrawString(item.StudentName, font, Brushes.Black, x, y);
                ev.Graphics.DrawString(item.Average, font, Brushes.Black, x + 500, y); // Средний балл для предмета
                y += lineHeight;
            }
        }

        private List<ReportItem> GetReportData()
        {
            var reportData = new List<ReportItem>();

            foreach (DataGridViewRow row in dataGridView_StudentGroup.Rows)
            {
                if (row.IsNewRow) continue; // Пропускаем новую строку

                // Получаем данные из DataGridView
                string studentName = row.Cells[0].Value?.ToString(); // 0 — это индекс столбца с ФИО
                string avgValue = row.Cells[2]?.Value?.ToString();

                if (!string.IsNullOrEmpty(studentName))
                {
                    reportData.Add(new ReportItem
                    {
                        StudentName = studentName,
                        Average = avgValue
                    });
                }
            }
            return reportData;
        }
      
        public class ReportItem
        {
            public string StudentName { get; set; }
            public string Average { get; set; } // Добавляем средний балл
        }
    }
}

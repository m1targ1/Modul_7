using System.Data.SqlClient;

namespace Учёт_студентов
{
    internal class DataBase // Класс DataBase предназначен для управления подключением к базе данных
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = M1TARG1\M1TARG1SQL; Initial Catalog = Учёт студентов; Integrated Security = True; MultipleActiveResultSets=True"); // Соединение с базой данных

        public void open() // Метод для открытия соединения с базой данных
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) // Проверка, закрыто ли текущее соединение
            {
                sqlConnection.Open(); // Открытие соединения с базой данных
            }
        }
        public void close() // Метод для закрытия соединения с базой данных
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) // Проверка, открыто ли текущее соединение
            {
                sqlConnection.Close(); // Закрытие соединения с базой данных
            }
        }
        public SqlConnection GetConnection() // Метод для получения объекта соединения
        {
            return sqlConnection; // Он возвращает текущий объект SqlConnection, чтобы другие классы могли с ним работать
        }
    }
}

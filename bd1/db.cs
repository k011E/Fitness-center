using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace bd1
{
    class db
    {
        SqlConnection connect;

        public void Close()
        {
            connect.Close();
        }

        public db(){
            connect = new SqlConnection(); // создаём объект класса для подключения к БД
            connect.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Users\k011E\source\repos\bd1\bd1\Database1.mdf;Integrated Security=True; MultipleActiveResultSets=True"; // устанавливаем значение поля отвечающего за строку подключения
            connect.Open(); // Открываем соединение
        }

        public int query(string str) // Запросы без ответа
        {
            if(connect.State != System.Data.ConnectionState.Open) // Проверка, открыто ли соединение
            {
                connect.Open(); // Если закрыто, то открываем
            }

            SqlCommand cmd = new SqlCommand(str, connect); // Создаем объект класса, для отправки запроса в БД, в аргументах передаём запрос и ссылку на соединение

            int reply = cmd.ExecuteNonQuery(); // Выполняем запрос и записываем ответ в переменную
            return reply; // Возвращаем переменную
        }

        public SqlDataReader querySelect(string str) // Запросы с ответом
        {
            SqlCommand cmd = new SqlCommand(str, connect); // Передаём аргументы
            return cmd.ExecuteReader(); // Выполняем и возвращаем результат
        }


    }
}

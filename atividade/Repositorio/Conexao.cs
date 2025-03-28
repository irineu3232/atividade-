using System.Data;
using MySql.Data.MySqlClient;


namespace atividade.Repositorio
{
    public class Conexao : IDisposable
    {
        private MySqlConnection _connection;

        public Conexao(string connectionString)
        {
            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public MySqlCommand MySqlCommand()
        {
            return _connection.CreateCommand();
        }
        
        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}

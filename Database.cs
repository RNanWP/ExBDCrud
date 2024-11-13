using MySql.Data.MySqlClient;
using System;
using System.Data;

public class Database
{
    private MySqlConnection connection;

    public Database()
    {
        string connectionString = "server=localhost;database=CrudRN;user=root;password=root;";
        connection = new MySqlConnection(connectionString);
    }

    // Retorna a conexão
    public MySqlConnection GetConnection()
    {
        return connection;
    }

    // Abre a conexão com o banco de dados, com tratamento de erros
    public bool OpenConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return true;
        }
        catch (Exception ex)
        {
            // Exibe a mensagem de erro caso a conexão falhe
            Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            return false;
        }
    }

    // Fecha a conexão com o banco de dados, com verificação
    public void CloseConnection()
    {
        try
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
        catch (Exception ex)
        {
            // Exibe a mensagem de erro caso a desconexão falhe
            Console.WriteLine($"Erro ao fechar a conexão: {ex.Message}");
        }
    }

    // Método para verificar o estado da conexão
    public bool IsConnectionOpen()
    {
        return connection.State == ConnectionState.Open;
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;

namespace CSMysqlDapper
{
  public class CustomDbResponse
  {
    public string Text { get; set; }
  }

  class Program
  {
    private const string HOST = "127.0.0.1";
    private const string USER = "root";
    private const string PASSWORD = "testdbpass";
    private const string DATABASE = "validator";

    static async Task Main(string[] args)
    {
      var connectionString = $"Server={HOST};User ID={USER};Password={PASSWORD};Database={DATABASE}";

      using (var connection = new MySqlConnection(connectionString)) {
        connection.Open();

        var text = (await connection.QueryAsync<CustomDbResponse>(
          "SELECT @Text as text;", new { Text = "Hello, World!" }
        )).First();

        Console.WriteLine(text.Text);
      }
    }
  }
}
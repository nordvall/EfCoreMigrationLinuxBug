using EfCoreMigrationLinuxBug.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace EfCoreMigrationLinuxBug
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<MyContext>()
                    .UseSqlite(connection)
                    .Options;

            using (var db = new MyContext(options))
            {
                Console.ReadLine();
            }
        }
    }
}

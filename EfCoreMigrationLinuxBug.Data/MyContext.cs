using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreMigrationLinuxBug.Data
{
    public class MyContext : DbContext
    {
        public MyContext()
        { }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        { }

        public DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            optionsBuilder.UseSqlite(connection);
        }
    }
}

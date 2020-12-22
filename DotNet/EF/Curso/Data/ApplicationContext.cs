using System;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=MyCourseEFCore-New;Integrated Security=true; Pooling=true";

            optionsBuilder
                .UseSqlServer(strConnection)
                .EnableSensitiveDataLogging()
                .LogTo(
                    Console.WriteLine,
                    new[] { CoreEventId.ContextInitialized, RelationalEventId.CommandExecuted },
                    LogLevel.Information,
                    DbContextLoggerOptions.LocalTime | DbContextLoggerOptions.SingleLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Departamento>().HasQueryFilter(p => !p.Excluido);
        }
    }
}
using System;
using System.IO;
using Curso.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Curso.Data
{
    public class ApplicationContext : DbContext
    {
        private readonly StreamWriter logFile = new StreamWriter(@"C:\Temp\meu-log-ef.txt", append: true);
        
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=MyCourseEFCore-New;Integrated Security=true; Pooling=true";

            optionsBuilder
                .UseSqlServer(strConnection)
                .EnableSensitiveDataLogging()
                .LogTo(logFile.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Departamento>().HasQueryFilter(p => !p.Excluido);
        }

        public override void Dispose()
        {
            base.Dispose();

            logFile.Dispose();
        }
    }
}
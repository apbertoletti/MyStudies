using System;
using System.IO;
using Curso.Domain;
using DominadoEFCore.Domain;
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
        public DbSet<Cliente> Clientes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string strConnection = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=MyCourseEFCore-New;Integrated Security=true; Pooling=true";

            optionsBuilder
                .UseSqlServer(strConnection, o =>
                {
                    o.CommandTimeout(16);
                    o.EnableRetryOnFailure(4, TimeSpan.FromSeconds(10), null);
                })
                .EnableSensitiveDataLogging()
                .LogTo(logFile.WriteLine, LogLevel.Information)
                .EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(c =>
            {
                c.OwnsOne(p => p.Endereco, end =>
                {
                    end.Property(prop => prop.Bairro).HasColumnName("Bairro");

                    end.ToTable("ClienteEndereco");
                });
            });
        }

        public override void Dispose()
        {
            base.Dispose();

            logFile.Dispose();
        }
    }
}
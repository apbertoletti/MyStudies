using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DominadoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //EnsureCreatingAndDeleting();
            GapEnsureCreated();
        }

        static void EnsureCreatingAndDeleting()
        {
            using var db = new Curso.Data.ApplicationContext();
            //db.Database.EnsureCreated();
            //db.Database.EnsureDeleted();
        }

        static void GapEnsureCreated()
        {
            using var db1 = new Curso.Data.ApplicationContext();
            using var db2 = new Curso.Data.ApplicationContextCidade();

            db1.Database.EnsureCreated();
            db2.Database.EnsureCreated();

            //Abordagem para o EF conseguir criar os objetos do segundo contexto delimitado no BD
            var databaseCreator = db2.GetService<IRelationalDatabaseCreator>();
            databaseCreator.CreateTables();
        }
    }
}

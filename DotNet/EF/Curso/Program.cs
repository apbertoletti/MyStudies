using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DominadoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            //EnsureCreatingAndDeleting();
         
            //GapEnsureCreated();
         
            //HealthCheckDB();
          
            //warmup
            new Curso.Data.ApplicationContext().Departamentos.AsNoTracking().Any();
            _count=0;
            GerenciarEstadoDaConexao(false);
            _count=0;
            GerenciarEstadoDaConexao(true);        
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

        static void HealthCheckDB()
        {
            using var bd = new Curso.Data.ApplicationContext();
            
            if (bd.Database.CanConnect()) 
            {
                Console.WriteLine("Conexão Ok");
            }
            else
            {
                Console.WriteLine($"Erro ao conectar no BD");
            }
        }

        static int _count;
        static void GerenciarEstadoDaConexao(bool gerenciarEstadoConexao)
        {
            using var db = new Curso.Data.ApplicationContext();
            var time = System.Diagnostics.Stopwatch.StartNew();

            var conexao = db.Database.GetDbConnection();

            conexao.StateChange += (_, __) => ++_count;

            if (gerenciarEstadoConexao)
            {
                conexao.Open();
            }

            for (var i = 0; i < 200; i++)
            {
                db.Departamentos.AsNoTracking().Any();
            }

            time.Stop();
            var mensagem = $"Tempo: {time.Elapsed.ToString()}, {gerenciarEstadoConexao}, Contador: {_count}";

            Console.WriteLine(mensagem);
        }
    }
}

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

            // //warmup
            // new Curso.Data.ApplicationContext().Departamentos.AsNoTracking().Any();
            // _count=0;
            // GerenciarEstadoDaConexao(false);
            // _count=0;
            // GerenciarEstadoDaConexao(true);        

            //ExecuteSQL();

            //SqlInjection();

            //MigracoesPendentes();

            //AplicarMigracaoEmTempodeExecucao();

            //TodasMigracoes();

            //MigracoesAplicadas();

            //ScriptGeralDoBancoDeDados();

            //CarregamentoAdiantado();

            CarregamentoExplicito();
        }

        static void CarregamentoExplicito()
        {
            using var db = new Curso.Data.ApplicationContext();
            SetupTiposCarregamentos(db);

            var departamentos = db
                .Departamentos
                .ToList(); // No carregamento explicito é importante fazer o ToList no começo para evitar que a conexão fique aberta.

            foreach (var departamento in departamentos)
            {
                //Carregar os dados do funcionarios somente de acordo com alguma regra de negócio
                if(departamento.Id == 2)
                {
                    ////Carregar todos os funcionários do departamento Id=2
                    //db.Entry(departamento).Collection(p=>p.Funcionarios).Load();
                    
                    ////Carregar todos os funcionários do departamento Id=2 AND Nome comece com Bruno
                    db.Entry(departamento).Collection(p=>p.Funcionarios).Query().Where(p=>p.Nome.StartsWith("Bruno")).ToList();
                }

                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Departamento: {departamento.Descricao}");

                if (departamento.Funcionarios?.Any() ?? false)
                {
                    foreach (var funcionario in departamento.Funcionarios)
                    {
                        Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
                    }
                }
                else
                {
                    Console.WriteLine($"\tNenhum funcionario encontrado!");
                }
            }
        }

        static void CarregamentoAdiantado()
        {
            using var db = new Curso.Data.ApplicationContext();
            SetupTiposCarregamentos(db);

            var departamentos = db
                .Departamentos
                .Include(p => p.Funcionarios);

            foreach (var departamento in departamentos)
            {

                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Departamento: {departamento.Descricao}");

                if (departamento.Funcionarios?.Any() ?? false)
                {
                    foreach (var funcionario in departamento.Funcionarios)
                    {
                        Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
                    }
                }
                else
                {
                    Console.WriteLine($"\tNenhum funcionario encontrado!");
                }
            }
        }
        
        static void SetupTiposCarregamentos(Curso.Data.ApplicationContext db)
        {
            if (!db.Departamentos.Any())
            {
                db.Departamentos.AddRange(
                    new Curso.Domain.Departamento
                    {
                        Descricao = "Departamento 01",
                        Funcionarios = new System.Collections.Generic.List<Curso.Domain.Funcionario>
                        {
                            new Curso.Domain.Funcionario
                            {
                                Nome = "Rafael Almeida",
                                CPF = "99999999911",
                                Rg= "2100062"
                            }
                        }
                    },
                    new Curso.Domain.Departamento
                    {
                        Descricao = "Departamento 02",
                        Funcionarios = new System.Collections.Generic.List<Curso.Domain.Funcionario>
                        {
                            new Curso.Domain.Funcionario
                            {
                                Nome = "Bruno Brito",
                                CPF = "88888888811",
                                Rg = "3100062"
                            },
                            new Curso.Domain.Funcionario
                            {
                                Nome = "Eduardo Pires",
                                CPF = "77777777711",
                                Rg = "1100062"
                            }
                        }
                    },
                    new Curso.Domain.Departamento
                    {
                        Descricao = "Departamento 03",
                    });

                db.SaveChanges();
                db.ChangeTracker.Clear();
            }
        }

        static void ScriptGeralDoBancoDeDados()
        {
            using var db = new Curso.Data.ApplicationContext();
            var script = db.Database.GenerateCreateScript();

            Console.WriteLine(script);
        }

        static void MigracoesAplicadas()
        {
            using var db = new Curso.Data.ApplicationContext();

            var migracoesPendentes = db.Database.GetAppliedMigrations();

            Console.WriteLine($"Total: {migracoesPendentes.Count()}");

            foreach (var migracao in migracoesPendentes)
            {
                Console.WriteLine($"Migração aplicada: {migracao}");
            }
        }

        static void TodasMigracoes()
        {
            using var db = new Curso.Data.ApplicationContext();

            var migracoes = db.Database.GetMigrations();

            Console.WriteLine($"Total: {migracoes.Count()}");

            foreach (var migracao in migracoes)
            {
                Console.WriteLine($"Migração: {migracao}");
            }
        }

        static void AplicarMigracaoEmTempodeExecucao()
        {
            //Cuidado a utilizar esta pratica em contextos onde possa haver várias aplicações
            //concorrendo e tentando aplicação a mesma migração, por exemplo, num container kuberts 
            //com varios pods concorrendo entre si.
            using var db = new Curso.Data.ApplicationContext();

            db.Database.Migrate();
        }

        static void MigracoesPendentes()
        {
            using var db = new Curso.Data.ApplicationContext();

            var migracoesPendentes = db.Database.GetPendingMigrations();

            Console.WriteLine($"Total: {migracoesPendentes.Count()}");

            foreach (var migracao in migracoesPendentes)
            {
                Console.WriteLine($"Migração: {migracao}");
            }
        }

        static void SqlInjection()
        {
            using var db = new Curso.Data.ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Departamentos.AddRange(
                new Curso.Domain.Departamento
                {
                    Descricao = "Departamento 01"
                },
                new Curso.Domain.Departamento
                {
                    Descricao = "Departamento 02"
                });
            db.SaveChanges();

            ////Forma segura (evitar Sql Injection)
            var descricao = "Teste ' or 1='1";
            db.Database.ExecuteSqlRaw("update departamentos set descricao='AtaqueSqlInjection' where descricao={0}",descricao);

            ////Forma insegura, simulando SQL Injection
            //var descricao = "Teste ' or 1='1";
            //db.Database.ExecuteSqlRaw($"update departamentos set descricao='AtaqueSqlInjection' where descricao='{descricao}'");

            foreach (var departamento in db.Departamentos.AsNoTracking())
            {
                Console.WriteLine($"Id: {departamento.Id}, Descricao: {departamento.Descricao}");
            }
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

        static void ExecuteSQL()
        {
            using var db = new Curso.Data.ApplicationContext();

            db.Database.OpenConnection();
            
            // Primeira Opcao
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT 1";
                cmd.ExecuteNonQuery();
            }

            // Segunda Opcao
            var descricao = "TESTE";
            db.Database.ExecuteSqlRaw("update departamentos set descricao={0} where id=1", descricao);

            //Terceira Opcao
            db.Database.ExecuteSqlInterpolated($"update departamentos set descricao={descricao} where id=1");
        }
    }
}

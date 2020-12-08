using System;
using System.Linq;
using Curso.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DominadoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            ///FiltroGlobal();

            //IgnorarFiltroGlobal();

            //ConsultaProjetada();

            DivisaoDeConsulta();
        }
        
        static void DivisaoDeConsulta()
        {
            using var db = new Curso.Data.ApplicationContext();
            SetupDb(db);

            var departamentos = db.Departamentos
                .Include(p => p.Funcionarios)
                .AsSplitQuery()
                .Where(p => p.Id < 3)
                .ToList();

            foreach (var dep in departamentos)
            {
                Console.WriteLine($"Descrição: {dep.Descricao}");
                foreach(var func in dep.Funcionarios)
                {
                    Console.WriteLine($"\tNome: {func.Nome}");
                }
            }   
        }
        static void ConsultaProjetada()
        {
            using var db = new ApplicationContext();
            SetupDb(db);

            var departamentos = db.Departamentos
                .Where(p => p.Id > 0)
                .Select(p => new {
                     p.Descricao, 
                     FuncionarioNomes = p.Funcionarios.Select(f => f.Nome)})
                .ToList();

            foreach(var dep in departamentos)
            {
                Console.WriteLine($"Descrição: {dep.Descricao}");

                foreach(var func in dep.FuncionarioNomes)
                {
                    Console.WriteLine($"\t Nome: {func}");
                }
            }
        }

        static void IgnorarFiltroGlobal()
        {
            using var db = new ApplicationContext();
            SetupDb(db);

            var departamentos = db.Departamentos.IgnoreQueryFilters().Where(p => p.Id > 0).ToList();

            foreach(var dep in departamentos)
            {
                Console.WriteLine($"Descrição: {dep.Descricao} \t Excluido: {dep.Excluido}");
            }
        }

        static void FiltroGlobal()
        {
            using var db = new ApplicationContext();
            SetupDb(db);

            var departamentos = db.Departamentos.Where(p => p.Id > 0).ToList();

            foreach(var dep in departamentos)
            {
                Console.WriteLine($"Descrição: {dep.Descricao} \t Excluido: {dep.Excluido}");
            }
        }
        static void SetupDb(Curso.Data.ApplicationContext db)
        {
            if (db.Database.EnsureCreated())
            {
                if (!db.Departamentos.Any())
                {
                    db.Departamentos.AddRange(
                        new Curso.Domain.Departamento
                        {
                            Ativo = true,
                            Descricao = "Departamento 01",
                            Funcionarios = new System.Collections.Generic.List<Curso.Domain.Funcionario>
                            {
                                new Curso.Domain.Funcionario
                                {
                                    Nome = "Rafael Almeida",
                                    CPF = "99999999911",
                                    Rg= "2100062"
                                }
                            },
                            Excluido = true            
                        },
                        new Curso.Domain.Departamento
                        {
                            Ativo = true,
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
                            Ativo = true,
                            Descricao = "Departamento 03",
                        });

                    db.SaveChanges();
                    db.ChangeTracker.Clear();
                }
            }
        }
    }
}

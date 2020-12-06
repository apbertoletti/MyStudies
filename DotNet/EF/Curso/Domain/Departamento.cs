using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Curso.Domain
{
    public class Departamento
    {
        public Departamento()
        {
        }

        private ILazyLoader _lazyLoader {get;set;}
        private Departamento(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        private List<Funcionario> _funcionarios;
        public List<Funcionario> Funcionarios 
        {
            get => _lazyLoader.Load(this, ref _funcionarios);
            set => _funcionarios = value;
        }
    }
}
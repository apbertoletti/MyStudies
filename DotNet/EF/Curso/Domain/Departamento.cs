using System;
using System.Collections.Generic;

namespace Curso.Domain
{
    public class Departamento
    {
        public Departamento()
        {
        }

        private Action<object,string> _lazyLoader {get;set;}
        private Departamento(Action<object,string> lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }        

        private List<Funcionario> _funcionarios;
        public List<Funcionario> Funcionarios 
        {
            get
            {
                _lazyLoader?.Invoke(this, nameof(Funcionarios));

                return _funcionarios;
            } 
            set => _funcionarios = value;
        }
    }
}
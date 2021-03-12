using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominadoEFCore.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public Profissao Profissao { get; set; }
    }

    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class Profissao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        
        public int ClienteFK { get; set; } //Na entidade que poderá ter registro NULL vc pode colocar a representação da chave estrangeira (por convenção NomeentidadeId)
        public Cliente Cliente { get; set; }
    }
}

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
        public ICollection<Telefone> Telefones { get; } = new List<Telefone>();
        public Endereco Endereco { get; set; }
        public Profissao Profissao { get; set; }
        public ICollection<ContasReceber> Contas { get; } = new List<ContasReceber>();
    }

    public class ContasReceber
    {
        public int Id { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal Valor { get; set; }
    }

    public class Telefone
    {
        public int Id { get; set; }
        public byte DDD { get; set; }
        public int Numero { get; set; }
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

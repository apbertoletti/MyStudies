using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominadoEFCore.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int AnoLancamento { get; set; }
        public ICollection<Cliente> Clientes { get; } = new List<Cliente>();
    }
}

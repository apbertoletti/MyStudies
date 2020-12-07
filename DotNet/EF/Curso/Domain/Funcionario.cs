namespace Curso.Domain
{
    public class Funcionario
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Rg { get; set; }
        public bool Excluido { get; set; }  

        public int DepartamentoId { get; set; } 
        public virtual Departamento Departamento { get; set; }
    }
}
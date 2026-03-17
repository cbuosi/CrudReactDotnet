namespace CrudApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public required string Endereco { get; set; }
        public required string UF { get; set; }
        public int CargoId { get; set; }
    }
}
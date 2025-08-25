namespace VacinaBtgApi.Models
{
    public class Vacina
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime DataAplicacao { get; set; }
        public required string Lote { get; set; }
        public required string Fabricante { get; set; }
    }
}

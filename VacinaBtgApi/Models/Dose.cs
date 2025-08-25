namespace VacinaBtgApi.Models
{
    public class Dose
    {
        public int Id { get; set; }
        public TipoDoseEnum tipo { get; set; }
        public int numero { get; set; }
        public int PessoaId { get; set; }
        public int VacinaId { get; set; }
        public Pessoa Pessoa { get; set; }
        public Vacina Vacina { get; set; }
    }
}

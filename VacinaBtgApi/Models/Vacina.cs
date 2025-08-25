namespace VacinaBtgApi.Models
{
    public class Vacina
    {
        public int Id { get; set; }
        public required string nome { get; set; }
        public TipoVacinaEnum tipo { get; set; }
        public int numeroDose { get; set; }
        public int numeroReforco { get; set; }
        public bool semLimiteDose { get; set; }
        public List<Dose> Doses { get; set; } = new List<Dose>();
    }
}

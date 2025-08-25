namespace VacinaBtgApi.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public required string nome { get; set; }
        public int idade { get; set; }
        public SexoEnum sexo { get; set; }
        public List<Dose> Doses { get; set; } = new List<Dose>(); 
    }
}

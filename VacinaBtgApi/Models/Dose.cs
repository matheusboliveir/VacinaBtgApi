using System.Text.Json.Serialization;

namespace VacinaBtgApi.Models
{
    public class Dose
    {
        public int Id { get; set; }
        public TipoDoseEnum tipo { get; set; }
        public int numero { get; set; }
        [JsonIgnore]
        public int PessoaId { get; set; }
        [JsonIgnore]
        public int VacinaId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
        [JsonIgnore]
        public Vacina Vacina { get; set; }
    }
}

namespace ExemploEF.Models
{
    public class Cliente
    {
        public Guid ClienteID { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}

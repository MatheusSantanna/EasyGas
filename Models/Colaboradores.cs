using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGas.Models
{
    public class Colaboradores
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cargo { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime Idade { get; set; }
        public bool Ativo { get; set; }
        
        public int IdadeCalculada
        {
            get
            {
                var day = DateTime.Today;
                var age = day.Year - Idade.Year;
                if (Idade > day.AddYears(-age)) age--;
                return age;
            }
        }
    }
    
   
}

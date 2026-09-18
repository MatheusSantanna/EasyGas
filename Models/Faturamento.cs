using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGas.Models;

public class Faturamento
{
    public int Id { get; set; }
    public decimal TotalQuinzenal { get; set; }
    public ICollection<OrdemServico> OrdensServiços { get; set; } 
    [Column(TypeName = "date")]
    public DateTime DataFaturamento { get; set; }
    public bool StatusPagamento { get; set; }
}
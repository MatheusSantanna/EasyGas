namespace EasyGas.Models;

public class Faturamento
{
    public int Id { get; set; }
    public decimal TotalQuinzenal { get; set; }
    public ICollection<OrdemServico> OrdensServiços { get; set; } 
    public DateTime DataFaturamento { get; set; }
    public bool StatusPagamento { get; set; }
}
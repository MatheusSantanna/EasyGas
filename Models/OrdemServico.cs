namespace EasyGas.Models;

public class OrdemServico
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public int NumeroOs { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime DataFechamento { get; set; }
    public decimal ValorTotal { get; set; }
}
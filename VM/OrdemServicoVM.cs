namespace EasyGas.VM;

public class OrdemServicoVM
{
    public int Id { get; set; }
    public int NumeroOS { get; set; }
    public int ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public string NomeCliente { get; set; }
    public string NomeExecutor { get; set; }
    public decimal ValorOs { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public bool OsFinalizada { get; set; }  
}
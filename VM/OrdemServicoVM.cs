using EasyGas.Models;

namespace EasyGas.VM;

public class OrdemServicoVM
{
    public int Id { get; set; }
    public int NumeroOS { get; set; }
    public int ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public string NomeCliente { get; set; }
    public string NomeExecutor { get; set; }

    public TipoServico TipoServico { get; set; } // usar o display name Ex: [Display(Name = "Manutenção Preventiva")] Manutencao = 0, 
    public decimal ValorOs { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public bool OsFinalizada { get; set; }  
}
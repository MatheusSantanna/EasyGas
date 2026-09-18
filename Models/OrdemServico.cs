using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGas.Models;

public class OrdemServico
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    public virtual Colaboradores Colaboradores { get; set; }
    public virtual Clientes Clientes { get; set; }
    public int NumeroOs { get; set; }
    public TipoServico TipoServico { get; set; }
    [Column(TypeName = "date")]
    public DateTime DataAbertura { get; set; }
    [Column(TypeName = "date")]
    public DateTime? DataFechamento { get; set; }
    public decimal ValorTotal { get; set; }
    public bool OsFinalizada {  get; set; }
}


public enum TipoServico
{
    Frete,
    Obra,
    ManutencaoPrev,
    AssistenciaTec

}
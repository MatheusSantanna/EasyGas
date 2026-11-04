using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGas.Models;

public class OrdemServico
{
    public int Id { get; set; }
    
    public int ClientesId { get; set; }
    
    public int ColaboradoresId { get; set; }
    
    public virtual Colaboradores? Colaboradores { get; set; }
    public virtual Clientes? Clientes { get; set; }
    public int NumeroOs { get; set; }
    public TipoServico TipoServico { get; set; }
    public DateTime DataAbertura { get; set; }
    public DateTime? DataFechamento { get; set; }
    public decimal ValorTotal { get; set; }
    public bool OsFinalizada {  get; set; }
    public ICollection<AnexoOs> Anexos { get; set; }
        = new List<AnexoOs>();
}


public enum TipoServico
{
    [Display(Name = "Frete")]
    Frete = 0,
    
    [Display(Name = "Obra")]
    Obra = 1,
    
    [Display(Name = "Manutenção Preventiva")]
    ManutencaoPrev = 2,
    
    [Display(Name = "Assistencia Técnica")]
    AssistenciaTec = 3
}
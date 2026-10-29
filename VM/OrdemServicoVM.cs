using System.ComponentModel.DataAnnotations;
using EasyGas.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyGas.VM;

public class OrdemServicoVM
{
    public int Id { get; set; }
    public int NumeroOS { get; set; }
    public int ClienteId { get; set; }
    public int ColaboradorId { get; set; }
    
    public string? NomeCliente { get; set; }
    public string? NomeExecutor { get; set; }

    public TipoServico TipoServico { get; set; } // usar o display name Ex: [Display(Name = "Manutenção Preventiva")] Manutencao = 0, 
    public decimal ValorOs { get; set; }
    
    [Required(ErrorMessage = "Informe a data de abertura")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public bool OsFinalizada { get; set; }
    public IEnumerable<AnexoOs>? Anexos { get; set; }

    public IEnumerable<SelectListItem>? Clientes { get; set; }

    public IEnumerable<SelectListItem>? Colab { get; set; }
}
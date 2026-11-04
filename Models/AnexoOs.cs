using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyGas.Models;

public class AnexoOs
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string NomeOriginal { get; set; } = string.Empty; 

    [Required]
    public byte[] Conteudo { get; set; } = Array.Empty<byte>();
     
    public int OrdemServicoId { get; set; } 
    public OrdemServico OrdemServico { get; set; } = null!;
}
 
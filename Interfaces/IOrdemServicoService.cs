using EasyGas.Models;
using EasyGas.VM;

namespace EasyGas.Interfaces;

public interface IOrdemServicoService
{
    Task<OrdemServico?> GetOsByIdAsync(int id);
    Task<OrdemServico> PostOrdemServico(OrdemServicoVM vm);
    Task<List<OrdemServicoVM>> GetAllOrdensServico(bool? finalizada);
    Task<List<OrdemServicoVM>> GetOrdensAbertas() => GetAllOrdensServico(finalizada: false);
    Task<List<OrdemServicoVM>> GetOrdensFechadas() => GetAllOrdensServico(finalizada: true);
    Task FinalizarOs(int id, List<IFormFile> anexos); 

}
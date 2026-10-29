using EasyGas.Models;
using EasyGas.VM;

namespace EasyGas.Interfaces;

public interface IOrdemServicoService
{
    Task<OrdemServico?> GetOsByIdAsync(int id);
    Task<OrdemServico> PostOrdemServico(OrdemServicoVM vm);
    Task<List<OrdemServicoVM>> GetAllOrdensServico(bool? finalizada);
    Task<List<OrdemServicoVM>> GetOrdensAbertas() => GetAllOrdensServico(finalizada: false);
    public Task<List<OrdemServicoVM>> GetOrdensFechadas() => GetAllOrdensServico(finalizada: true);
}
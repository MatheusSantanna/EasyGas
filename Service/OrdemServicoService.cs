using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Repositorio;
using EasyGas.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyGas.Service;

public class OrdemServicoService : IOrdemServicoService
{
    private readonly IRepository<OrdemServico> _ordemServicoRepository;

    public OrdemServicoService(
        IRepository<OrdemServico> ordemServicoRepository)
    {
        _ordemServicoRepository = ordemServicoRepository;
    }
    
    public async Task<OrdemServico> PostOrdemServico(OrdemServicoVM vm)
    {
        var ordem = new OrdemServico
        {
            Id = vm.Id,
            ClienteId = vm.ClienteId,
            ColaboradorId = vm.ColaboradorId,
            NumeroOs = vm.NumeroOS,
            DataAbertura = vm.DataInicio,
            DataFechamento = vm.DataFim,
            ValorTotal = vm.ValorOs,
            OsFinalizada = false
        };

        await _ordemServicoRepository.AddAsync(ordem);

        return ordem;
    }

    public async Task<List<OrdemServicoVM>> GetAllOrdensServico(bool finalizada)
    {
        return await _ordemServicoRepository
            .GetAllAsync()
            .Where(x => finalizada 
                    ? x.DataFechamento != null 
                    : x.DataFechamento == null)
            .Select(x => new OrdemServicoVM
            {
                Id = x.Id,
                NumeroOS = x.NumeroOs,
                ClienteId = x.ClienteId,
                ColaboradorId = x.ColaboradorId,
                NomeCliente = x.Clientes.RazaoSocial,
                NomeExecutor = x.Colaboradores.Nome,
                ValorOs = x.ValorTotal,
                DataInicio = x.DataAbertura,
                DataFim = x.DataFechamento,
                OsFinalizada = x.DataFechamento != null
            }).ToListAsync();
    }

    public Task<List<OrdemServicoVM>> GetOrdensAbertas() => GetAllOrdensServico(finalizada: false);
    public Task<List<OrdemServicoVM>> GetOrdensFechadas() => GetAllOrdensServico(finalizada: true);
    
    
    public async Task<OrdemServico?> GetOsById(int id)
    {
        return await _ordemServicoRepository.GetByIdAsync(id);
    }
    
    
    
}

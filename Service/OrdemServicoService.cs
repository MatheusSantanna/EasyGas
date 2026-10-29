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
        
        var agora = DateTime.Now;
        
        var ordem = new OrdemServico
        {
            ClientesId = vm.ClienteId,
            ColaboradoresId = vm.ColaboradorId,
            NumeroOs = vm.NumeroOS,
            TipoServico = vm.TipoServico,  
            DataAbertura = DateTime.SpecifyKind(vm.DataInicio.Date + agora.TimeOfDay, DateTimeKind.Local).ToUniversalTime(),
            DataFechamento = vm.DataFim,
            ValorTotal = vm.ValorOs,
            OsFinalizada = false
        };

        await _ordemServicoRepository.AddAsync(ordem);

        return ordem;
    }

    public async Task<List<OrdemServicoVM>> GetAllOrdensServico(bool? finalizada)
    {
        var query = await _ordemServicoRepository
            .GetAllAsync()
            .Where(x => finalizada == null ||
                        (finalizada.Value
                            ? x.DataFechamento != null 
                            : x.DataFechamento == null))
            .OrderByDescending(
                x => x.DataAbertura)
            .Select(x => new OrdemServicoVM
            {
                Id = x.Id,
                NumeroOS = x.NumeroOs,
                ClienteId = x.ClientesId,
                ColaboradorId = x.ColaboradoresId,
                NomeCliente = x.Clientes.RazaoSocial,
                NomeExecutor = x.Colaboradores.Nome,
                ValorOs = x.ValorTotal,
                DataInicio = x.DataAbertura,
                DataFim = x.DataFechamento,
                OsFinalizada = x.DataFechamento != null,
                Anexos = x.Anexos
            }).ToListAsync();
        
        return query;
    }
    
    public Task<List<OrdemServicoVM>> GetOrdensAbertas() => GetAllOrdensServico(finalizada: false);
    public Task<List<OrdemServicoVM>> GetOrdensFechadas() => GetAllOrdensServico(finalizada: true);


    public async Task<OrdemServico?> GetOsByIdAsync(int id)
    {
        return await _ordemServicoRepository
            .GetAllAsync()
            .Include(x => x.Clientes)
            .Include(x => x.Colaboradores)
            .Include(x => x.Anexos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
     

}

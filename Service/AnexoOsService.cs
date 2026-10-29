using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace EasyGas.Service;

public class AnexoOsService : IAnexoOsService
{
    private readonly IRepository<AnexoOs> _anexoOsRepository;

    public AnexoOsService(IRepository<AnexoOs> anexoOsRepository)
    {
        _anexoOsRepository = anexoOsRepository;
    }
    public async Task SalvaAnexoOs(List<AnexoOs> anexo)
    {
        foreach (var item in anexo)
        {
            await _anexoOsRepository.AddAsync(item);
        } 
    }

    //ajustar aqui
    public async Task<List<AnexoOs>> BuscarTodosAnexoOs(int idOs)
    {
        return await _anexoOsRepository.GetAllAsync().ToListAsync();
    }
}
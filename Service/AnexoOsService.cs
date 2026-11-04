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
     
    public async Task<AnexoOs?> BuscarPorId(int id)
    {
        return await _anexoOsRepository.GetByIdAsync(id);
    }
}
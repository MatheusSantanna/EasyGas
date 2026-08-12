using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace EasyGas.Service;

public class ColaboradoresService : IColaboradoresService
{
    private readonly IRepository<Colaboradores>  _colaboradores;

    public ColaboradoresService(IRepository<Colaboradores> colaboradores)
    {
        _colaboradores = colaboradores;
    }

    public async Task<Colaboradores> PostColaborador(Colaboradores colaborador)
    {
        await _colaboradores.AddAsync(colaborador);

        return colaborador;
    }

    public async Task<List<Colaboradores>> GetAllColaboradores()
    {
        return await _colaboradores.GetAllAsync().ToListAsync();
    }

    public async Task<Colaboradores?> GetColaboradoresById(int colaboradorId)
    {
        return await _colaboradores.GetByIdAsync(colaboradorId);
    }
    
    
    
}
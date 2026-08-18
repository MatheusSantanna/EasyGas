using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Repositorio;
using Microsoft.AspNetCore.Mvc;
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
    [HttpPut]
    public void UpdateColaborador(Colaboradores colaborador)
    {
        //esse metodo depois tera que ser criado uma
        //view model aonde iremos poder atualizar somente o cargo o colaborador,
        //fazendo assim uma instancia da VM e retornando um colaborador para o metodo update. 
         _colaboradores.Update(colaborador);
    }


    public async Task DropColaborador(int id)
    {
        var colaborador = await _colaboradores.GetByIdAsync(id);
        if (colaborador != null && colaborador.Id == id)
        {
            await  _colaboradores.DeleteAsync(colaborador.Id);
        }
    }
    
    
}
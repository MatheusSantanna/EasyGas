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

        if (colaborador.Id > 0)
        {
            var existente = await _colaboradores.GetByIdAsync(colaborador.Id);
            if (existente is null)
                throw new InvalidOperationException("Colaborador não encontrado.");
            
            existente.Nome = colaborador.Nome;
            existente.Cargo = colaborador.Cargo;
            existente.Idade = colaborador.Idade.Date;
            existente.Ativo = colaborador.Ativo;
            _colaboradores.Update(existente);
            return existente;
        }
        
        colaborador.Idade = colaborador.Idade.Date;

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
    public async Task  UpdateColaborador(bool status, Colaboradores colaborador)
    {
       
        var colabAtualizado = await _colaboradores.GetByIdAsync(colaborador.Id);
        if (status == true &&  colabAtualizado != null)
        {
            colabAtualizado.Ativo = true;
            _colaboradores.Update(colabAtualizado);
        }
        else
        {
            if (colabAtualizado != null)
            {
                colabAtualizado.Ativo = false;
                _colaboradores.Update(colabAtualizado);
            }
        }
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
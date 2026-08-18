using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace EasyGas.Service;

public class ClientesService : IClientesService
{
    private readonly IRepository<Clientes> _clientesRepository;

    public ClientesService(IRepository<Clientes> clientesRepository)
    {
        _clientesRepository = clientesRepository;
    }

    public async Task<Clientes> PostClientes(Clientes cliente)
    {
        var novoCLiente = new Clientes
        {
            Id = cliente.Id,
            RazaoSocial = cliente.RazaoSocial,
            Cnpj = cliente.Cnpj,
            Ativo = true
        };
        await _clientesRepository.AddAsync(novoCLiente);
        return novoCLiente;
    }
    
    public async Task<List<Clientes>> GetAllClientes(string? termoBusca = null)
    {
        return await _clientesRepository.GetAllAsync().ToListAsync();
    }

    public async Task<Clientes?> GetClientesById(int id)
    {
        return await _clientesRepository.GetByIdAsync(id);
    }
    
    public async Task UpdateClientes(bool status, Clientes cliente)
    {
         var clienteAtualizado = await _clientesRepository.GetByIdAsync(cliente.Id);
        if (status == true &&  clienteAtualizado != null)
        {
            clienteAtualizado.Ativo = true;
            _clientesRepository.Update(clienteAtualizado);
        }
        else
        {
            if (clienteAtualizado != null)
            {
                clienteAtualizado.Ativo = false;
                _clientesRepository.Update(clienteAtualizado);
            }
        }
    }
}
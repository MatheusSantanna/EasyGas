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
        if (cliente.Id > 0)
        {
            var existente = await _clientesRepository.GetByIdAsync(cliente.Id);
            if (existente is null)
                throw new InvalidOperationException("Cliente não encontrado.");

            existente.RazaoSocial = cliente.RazaoSocial;
            existente.Cnpj = cliente.Cnpj;
            existente.Ativo = cliente.Ativo;
            _clientesRepository.Update(existente);
            return existente;
        }

        var novoCliente = new Clientes
        {
            RazaoSocial = cliente.RazaoSocial,
            Cnpj = cliente.Cnpj,
            Ativo = cliente.Ativo
        };
        await _clientesRepository.AddAsync(novoCliente);
        return novoCliente;
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
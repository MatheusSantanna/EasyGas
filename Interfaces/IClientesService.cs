using EasyGas.Models;

namespace EasyGas.Interfaces;

public interface IClientesService
{
    Task UpdateClientes(bool status, Clientes cliente);
    Task<Clientes?> GetClientesById(int id);
    Task<List<Clientes>> GetAllClientes(string? termoBusca = null);
    Task<Clientes> PostClientes(Clientes cliente);
}
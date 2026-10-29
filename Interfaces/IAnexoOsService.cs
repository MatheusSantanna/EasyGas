using EasyGas.Models;
using EasyGas.VM;

namespace EasyGas.Interfaces;

public interface IAnexoOsService
{
    Task SalvaAnexoOs(List<AnexoOs> anexo); 

    Task<List<AnexoOs>> BuscarTodosAnexoOs(int idOs);
}
using EasyGas.Models;
using EasyGas.VM;

namespace EasyGas.Interfaces;

public interface IAnexoOsService
{  
    Task<AnexoOs?> BuscarPorId(int id);
}
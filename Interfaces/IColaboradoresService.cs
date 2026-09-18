using EasyGas.Models;

namespace EasyGas.Interfaces;

public interface IColaboradoresService
{
    Task<Colaboradores> PostColaborador(Colaboradores colaborador);
    Task<List<Colaboradores>> GetAllColaboradores();
    Task<Colaboradores> GetColaboradoresById(int id);
    Task  UpdateColaborador(bool status, Colaboradores colaborador);

    Task DropColaborador(int id);
}
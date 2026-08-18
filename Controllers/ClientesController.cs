using EasyGas.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EasyGas.Controllers;

public class ClientesController : Controller
{
    private readonly IClientesService _clientesService;

    public ClientesController(IClientesService clientesService)
    {
        _clientesService = clientesService;
    }
    [HttpGet]
    public async Task<IActionResult> ListaClientes(string? termoBusca)
    {
        var clientes = await _clientesService.GetAllClientes(termoBusca);

        if (Request.Headers.ContainsKey("HX-Request"))
            return PartialView("_TabelaClientesPartial", clientes);

        return View(clientes);
    }
}
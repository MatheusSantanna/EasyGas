using EasyGas.Interfaces;
using EasyGas.Models;
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

        if(clientes.Count is 0)
        {
            return RedirectToAction(nameof(PostClientes));
        }

        if (Request.Headers.ContainsKey("HX-Request"))
            return PartialView("_TabelaClientesPartial", clientes);

        return View(clientes);
    }

    [HttpGet]
    public async Task<IActionResult> PostClientes(int? id)
    {
        if (id is null or 0)
            return View(new Clientes { Ativo = true });

        var cliente = await _clientesService.GetClientesById(id.Value);
        if (cliente is null)
            return RedirectToAction(nameof(ListaClientes));

        return View(cliente);
    }

    [HttpPost]
    public async Task<IActionResult> PostClientes(Clientes clientes)
    {
        if (string.IsNullOrWhiteSpace(clientes.RazaoSocial))
            ModelState.AddModelError(nameof(clientes.RazaoSocial), "Informe a razão social.");

        if (string.IsNullOrWhiteSpace(clientes.Cnpj))
            ModelState.AddModelError(nameof(clientes.Cnpj), "Informe o CNPJ.");

        if (!ModelState.IsValid)
            return View(clientes);

        await _clientesService.PostClientes(clientes);
        return RedirectToAction(nameof(ListaClientes));
    }
}
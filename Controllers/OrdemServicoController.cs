using EasyGas.Interfaces;
using EasyGas.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyGas.Controllers;

public class OrdemServicoController : Controller
{
    private readonly IOrdemServicoService _ordemServicoService;
    private readonly IClientesService _clientesService;
    private readonly IColaboradoresService _colaboradoresService;

    public OrdemServicoController(IOrdemServicoService ordemServicoService,  IClientesService clientesService, IColaboradoresService colaboradoresService)
    {
        _ordemServicoService = ordemServicoService;
        _clientesService = clientesService;
        _colaboradoresService = colaboradoresService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOs([FromQuery] bool? finalizada)
    {
        var os = await _ordemServicoService.GetAllOrdensServico(finalizada);

        if (Request.Headers.ContainsKey("HX-Request"))
        {
            return PartialView("_TabelaOsPartial", os);
        }
        return View(os);
    }

    public async Task<IActionResult> PostOs()
    {
        var vm = new OrdemServicoVM
        {
            Clientes = new SelectList(await _clientesService.GetAllClientes(), "Id", "RazaoSocial"),
            Colab = new SelectList(await _colaboradoresService.GetAllColaboradores(), "Id", "Nome"),
            DataInicio = DateTime.Today
        };
        
        return View(vm);
    }
    [HttpPost]
    
    public async Task<IActionResult> PostOs(OrdemServicoVM vm)
    {
        if (!ModelState.IsValid)
        {
            vm.Colab = new SelectList(await _colaboradoresService.GetAllColaboradores(), "Id", "Nome");
            vm.Clientes = new SelectList(await _clientesService.GetAllClientes(), "Id", "RazaoSocial");
            
            return View(vm);
        }
        
        await _ordemServicoService.PostOrdemServico(vm);
        return RedirectToAction(nameof(GetOs));
    }
}
using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Mime;

namespace EasyGas.Controllers;

public class OrdemServicoController : Controller
{
    private readonly IOrdemServicoService _ordemServicoService;
    private readonly IClientesService _clientesService;
    private readonly IColaboradoresService _colaboradoresService;
    private readonly IAnexoOsService _anexoOsService;

    public OrdemServicoController(IOrdemServicoService ordemServicoService,  IClientesService clientesService, IColaboradoresService colaboradoresService, IAnexoOsService anexoOsService)
    {
        _ordemServicoService = ordemServicoService;
        _clientesService = clientesService;
        _colaboradoresService = colaboradoresService;
        _anexoOsService = anexoOsService;
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


    public async Task<IActionResult> DetailOs(int id)
    {
        var os = await _ordemServicoService.GetOsByIdAsync(id);
        return PartialView("_ModalDetalheOsPartial", os);
        //return View(os);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FinalizarOs(int id, List<IFormFile> anexos)
    {
        await _ordemServicoService.FinalizarOs(id, anexos);
        return RedirectToAction("GetOs");
    }


    [HttpGet]
    public async Task<IActionResult> BaixarAnexo(int id)
    {
        var anexo = await _anexoOsService.BuscarPorId(id);

        return File(
            anexo.Conteudo,
            MediaTypeNames.Application.Octet,
            anexo.NomeOriginal);
    }
}
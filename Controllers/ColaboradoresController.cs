
using EasyGas.Data;
using EasyGas.Interfaces;
using EasyGas.Models;
using EasyGas.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ColaboradoresController : Controller
{
    private readonly IColaboradoresService _colaboradores;

    public ColaboradoresController(IColaboradoresService colaboradores)
    {
        _colaboradores = colaboradores;
    }

    [HttpGet]
    public async Task<IActionResult> GetColaboradores()
    {
        var colab = await _colaboradores.GetAllColaboradores();

        if (colab.Count is 0)
        {
            return RedirectToAction(nameof(PostColaboradores));
        }

        if (Request.Headers.ContainsKey("HX-Request"))
            return PartialView("_TabelaColabPartial", colab);

        return View(colab);

    }

    [HttpGet]
    public async Task<IActionResult> PostColaboradores(int? id)
    {
        if (id is null or 0)
            return View(new Colaboradores { Ativo = true });

        var colab = await _colaboradores.GetColaboradoresById(id.Value);
        if (colab is null)
            return RedirectToAction(nameof(GetColaboradores));

        return View(colab);

    }

    [HttpPost]
    public async Task<IActionResult> PostColaboradores(Colaboradores colab)
    {
        if (!ModelState.IsValid)
            return View(colab);
        
            var colabExist = await _colaboradores.GetColaboradoresById(colab.Id);
            
        await _colaboradores.PostColaborador(colab);
        return RedirectToAction(nameof(GetColaboradores));
    }

}


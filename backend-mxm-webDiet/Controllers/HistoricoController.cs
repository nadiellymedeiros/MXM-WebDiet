using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mxm_webDiet.Domains.dbContext;
using mxm_webDiet.Domains.Models;
using mxm_webDiet.Infra.Services;

namespace backend_mxm_webDiet.Controllers;

[ApiController]
[Route("api/historico")]

public class HistoricoController : ControllerBase
{
    private readonly DietDbContext _dietDbContext;
    private readonly DietService _dietService;

    public HistoricoController(DietService dietService, DietDbContext dietDbContext)
    {
        _dietDbContext = dietDbContext;
        _dietService = dietService;


    }

    [HttpGet("dietas/{cpf}")]
    public IActionResult GetDietasByCpf(string cpf)
    {
        // Encontrar o usuário com o CPF fornecido
        var user = _dietDbContext.Dietas.FirstOrDefault(d => d.UserCpf == cpf);

        if (user == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        // Obter as dietas associadas a esse usuário
        var dietas = _dietDbContext.Dietas.Include(a => a.responseApiDTO).Include(c => c.responseApiDTO.Choice).Where(d => d.UserCpf == cpf).ToList();

        if (dietas.Count == 0)
        {
            return NotFound("Não foram encontradas dietas para este usuário.");
        }

        return Ok(dietas);
    }

    // [HttpGet("{UserCpf:string}")]
    //     public ActionResult <List<Dietas>> GetAll(int UserCpf)
    //     {
    //         var dietas = _dietDbContext.Dietas.Where(d => d.UserCpf == user.Cpf).ToList();

    //            if(dietas != null){


    //         return Ok(dietas);


    //     }
    //     return  NotFound("Não tem dietas para este usuário");       
    //     }

}
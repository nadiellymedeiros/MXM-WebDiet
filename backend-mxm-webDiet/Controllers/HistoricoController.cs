using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mxm_webDiet.Domains.dbContext;
using mxm_webDiet.Infra.Services;

namespace backend_mxm_webDiet.Controllers;

[ApiController]
[Route("api")]

public class HistoricoController : ControllerBase
{
    private readonly DietDbContext _dietDbContext;
    private readonly DietService _dietService;

    public HistoricoController(DietService dietService, DietDbContext dietDbContext)
    {
        _dietDbContext = dietDbContext;
        _dietService = dietService;


    }

    [HttpGet("historico/{cpf}")]
    public IActionResult GetDietasByCpf(string cpf)
    {

        var user = _dietDbContext.Dietas.FirstOrDefault(d => d.UserCpf == cpf);

        if (user == null)
        {
            return NotFound("Usuário não encontrado.");
        }


        var dietas = _dietDbContext.Dietas.Include(a => a.responseApiDTO).Include(c => c.responseApiDTO.Choice).Where(d => d.UserCpf == cpf).OrderByDescending(d => d.CriadoEm).ToList();

        if (dietas.Count == 0)
        {
            return NotFound("Não foram encontradas dietas para este usuário.");
        }

        return Ok(dietas);
    }

}
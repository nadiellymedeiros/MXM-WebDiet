using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mxm_webDiet.Domains.dbContext;
using mxm_webDiet.Domains.Models;
using mxm_webDiet.Infra.Services;


namespace mxm_webDiet.Controllers;

[ApiController]
[Route("api/historico")]

public class HistoricoController : ControllerBase
{
     private readonly DietDbContext  _dietDbContext;
    private readonly DietService _dietService;
    private readonly IMapper _mapper;


    public HistoricoController(DietService dietService, DietDbContext dietDbContext, IMapper mapper )
    {
         _dietDbContext = dietDbContext;
         _dietService = dietService;
         _mapper = mapper;

    }

    [HttpGet("{UserCpf:string}")]
    public ActionResult <List<Dietas>> GetAll(int UserCpf)
    {
        var user = _dietDbContext.Users.First(u => u.Id == UserCpf);

           if(user != null){

              var dietas = _dietDbContext.Dietas.Where(d => d.UserCpf == user.Cpf).ToList();
        return Ok(dietas);
  
    
    }
    return  NotFound("Usuário não está logado");       
    }


}



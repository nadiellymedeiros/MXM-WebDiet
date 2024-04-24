using Microsoft.AspNetCore.Mvc;
using mxm_webDiet.Domains.dbContext;
using mxm_webDiet.Domains.Dto;
using mxm_webDiet.Domains.Models;
using mxm_webDiet.Infra.Services;


namespace mxm_webDiet.Controllers;

[ApiController]
[Route("api/diet")]

public class DietController : ControllerBase
{
    private readonly DietService _dietService;
    private readonly DietDbContext  _dietDbContext;

    public DietController(DietService dietService, DietDbContext dietDbContext)
    {
         _dietService = dietService;
         _dietDbContext = dietDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User userDto)
    {
        try
        {
            var content = _dietService.CreateContent();
            var response = await _dietService.SendRequestToOpenAI(content);

            var novaDieta = new Dietas
              {
                responseApiDTO = new ResponseApiDTO
                {
                    Choice = new ChoiceDTO
                    {
                        Text = response
                    }
                },
                UserCpf = userDto.Cpf, 
              };
             _dietDbContext.Dietas.Add(novaDieta);
              _dietDbContext.SaveChanges();
            

            if (!string.IsNullOrEmpty(response))
            {
                return  Ok("{\"resposta\": \"" + response + "\"}");;
            }
            return BadRequest("Não foi possível montar sua dieta");
        }
        catch (Exception e)
            {
                return StatusCode(500, "Não foi possível acessar sua dieta: " + e.Message);
            } 
    }
}
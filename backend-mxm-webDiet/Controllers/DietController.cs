using Microsoft.AspNetCore.Mvc;
using mxm_webDiet.Domains.Models;
using mxm_webDiet.Infra.Services;


namespace mxm_webDiet.Controllers;

[ApiController]
[Route("api/diet")]

public class DietController : ControllerBase
{
    private readonly DietService _dietService;

    public DietController(DietService dietService)
    {
         _dietService = dietService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        try
        {
            var content = _dietService.CreateContent();
            var response = await _dietService.SendRequestToOpenAI(content);

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
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public async Task<IActionResult> Get(string text)
    {
        try
        {
            var content = _dietService.CreateContent(text);
            var response = await _dietService.SendRequestToOpenAI(content);

            if (!string.IsNullOrEmpty(response))
            {
                return Ok(response);
            }
            return BadRequest("Não foi possível montar sua dieta");
        }
        catch (Exception e)
            {
                return StatusCode(500, "Não foi possível acessar sua dieta: " + e.Message);
            } 
    }
}
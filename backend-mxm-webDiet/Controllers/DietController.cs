using mxm_webDiet.Domains.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;


namespace mxm_webDiet.Controllers;

[ApiController]
[Route("api/diet")]

public class DietController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public DietController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]

    public async Task<IActionResult> Get(string text, [FromServices] IConfiguration configuration)
    {
        var token = configuration.GetValue<string>("API_KEY");

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var model = new RequestApiModel(text);

        var requestBody = JsonSerializer.Serialize(model);

        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);

        var result = await response.Content.ReadFromJsonAsync<ResponseApiModel>();

        var promptResponse = result?.choices.First();
        
        return Ok(promptResponse?.text?.Replace("\n","").Replace("\t",""));
    }

}
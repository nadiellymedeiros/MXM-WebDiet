using mxm_webDiet.Domains.Models;
using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;

namespace mxm_webDiet.Infra.Services;

public class DietService 
{
    private readonly HttpClient _httpClient;        
    private readonly string _apiKey;

   public DietService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration.GetValue<string>("API_KEY") ?? throw new ArgumentNullException("API_KEY não configurada no arquivo de configuração, appsettings");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
    }

    public StringContent CreateContent(Dieta dieta)
        {
        var model = new RequestApiModel(dieta);    
        var requestBody = JsonSerializer.Serialize(model);         
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        return content;
        }

    public async Task<string> SendRequestToOpenAI(StringContent content)
    {   
        try
        {
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/completions", content);
            var result = await response.Content.ReadFromJsonAsync<ResponseApiModel>();
            var promptResponse = result?.choices.First();
            return promptResponse?.text?.Replace("\n","").Replace("\t","")?? string.Empty;
        }
        catch (Exception ex)
        {
          throw new Exception($"Erro ao enviar solicitação para OpenAI: {ex.Message}");
        }     
    } 

    public async Task<string> GetPrompt(HttpResponseMessage response)
        {
            var result = await response.Content.ReadFromJsonAsync<ResponseApiModel>();
            var prompt = result?.choices.First();
            
             if (prompt != null)
            {
                var sendResponse = prompt?.text?? "";
                return sendResponse;
            }
            return string.Empty;;
        }   
}
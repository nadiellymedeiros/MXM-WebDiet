  namespace mxm_webDiet.Domains.Models;

  
  public class RequestApiModel
    {
public RequestApiModel(string prompt)
{
     model = "gpt-3.5-turbo-instruct";
    this.prompt = $"Preciso de um dieta para emagrecer, para um dia completo, {prompt}";   
    max_tokens = 500;
    temperature = 0;

}

        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public int temperature { get; set; }
    }
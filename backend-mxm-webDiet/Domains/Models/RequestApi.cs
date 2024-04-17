  namespace mxm_webDiet.Domains.Models;

  
  public class RequestApiModel
    {
public RequestApiModel(string prompt)
{
     model = "gpt-3.5-turbo-instruct";
    this.prompt = $"Preciso de um dieta {prompt}";   
    max_tokens = 7;
    temperature = 0;

}

        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public int temperature { get; set; }
    }
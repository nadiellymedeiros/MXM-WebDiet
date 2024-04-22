  namespace mxm_webDiet.Domains.Models;

  
  public class RequestApiModel
    {
public RequestApiModel(Dieta dieta)
{
     model = "gpt-3.5-turbo-instruct";
    this.prompt = $"Preciso de um dieta para um dia completo, tenho{dieta.Idade} anos, peso {dieta.Peso}, tenho {dieta.Peso}m de altura e meu sexo é {dieta.Sexo}";   
    max_tokens = 15;
    temperature = 0;

}

        public string model { get; set; }
        public string prompt { get; set; }
        public int max_tokens { get; set; }
        public int temperature { get; set; }
    }
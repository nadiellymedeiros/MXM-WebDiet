using AutoMapper;
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
    private readonly DietDbContext  _dietDbContext;
    private readonly DietService _dietService;
    private readonly IMapper _mapper;


    public DietController(DietService dietService, DietDbContext dietDbContext, IMapper mapper )
    {
         _dietDbContext = dietDbContext;
         _dietService = dietService;
         _mapper = mapper;

    }


    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserRequestApiDto userDto)
    {        
        try
        {            
            // var user = _mapper.Map<User>(userDto);

            var content = _dietService.CreateContent();
            var response = await _dietService.SendRequestToOpenAI(content);

            if (!string.IsNullOrEmpty(response))
            {
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
                

               
                return  Ok("{\"resposta\": \"" + response + "\"}");
              
            }
            return BadRequest("Não foi possível montar sua dieta");
        }
        catch (Exception e)
            {
                return StatusCode(500, "Não foi possível acessar sua dieta: " + e.Message);
            } 
    }

    // [HttpPost]
    // public async Task<IActionResult> Post([FromBody] User user)
    // {


    //     try
    //     {
    //         var content = _dietService.CreateContent(user);
    //         var response = await _dietService.SendRequestToOpenAI(content);

    //         if (!string.IsNullOrEmpty(response))
    //         {
    //             return  Ok("{\"resposta\": \"" + response + "\"}");;
    //         }
    //         return BadRequest("Não foi possível montar sua dieta");
    //     }
    //     catch (Exception e)
    //         {
    //             return StatusCode(500, "Não foi possível acessar sua dieta: " + e.Message);
    //         } 
    // }

    
}

// [HttpPost]
//     public async Task<IActionResult> Post([FromBody] User user)
//     {        
//         try
//         {
//             var userParaCadastro = _mapper.Map<User>(user);
//             var result = _dietDbContext.Users.Add(userParaCadastro);
//             _dietDbContext.SaveChanges();
//             var UserSalvo = result.Entity;

//             var content = _dietService.CreateContent(user);
//             var response = await _dietService.SendRequestToOpenAI(content);

//             if (!string.IsNullOrEmpty(response))
//             {
//               var novaDieta = new Dietas
//               {
//                 responseApiDTO = new Domains.Dto.ResponseApiDTO
//                 {
//                     Choice = new Domains.Dto.ChoiceDTO
//                     {
//                         Text = response
//                     }
//                 },
//                 UserId = user.Id, 
//               };
//               _dietDbContext.Dietas.Add(novaDieta);
//               _dietDbContext.SaveChanges();                           
                

               
//                 return  Ok("{\"resposta\": \"" + response + "\"}");;
//             }
//             return BadRequest("Não foi possível montar sua dieta");
//         }
//         catch (Exception e)
//             {
//                 return StatusCode(500, "Não foi possível acessar sua dieta: " + e.Message);
//             } 
//     }
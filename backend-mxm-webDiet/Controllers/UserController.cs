using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using mxm_webDiet.Domains.dbContext;
using mxm_webDiet.Domains.Dto;
using mxm_webDiet.Domains.Models;
using mxm_webDiet.Infra.Services;


namespace mxm_webDiet.Controllers;

[ApiController]
[Route("api/users")]

public class UserController : ControllerBase
{
    private readonly DietDbContext  _dietDbContext;
    private readonly DietService _dietService;
    private readonly IMapper _mapper;


    public UserController(DietService dietService, DietDbContext dietDbContext, IMapper mapper )
    {
         _dietDbContext = dietDbContext;
         _dietService = dietService;
         _mapper = mapper;

    }

[HttpGet]
public IActionResult GetAll()
{
    var users = _dietDbContext.Users;    

    return Ok(users);
}


[HttpGet("{cpf:string}")]
public IActionResult GetById(int cpf)
{
    var user = _dietDbContext.Users.Find(cpf);

    if (user == null)
        return NotFound();

    user.Dietas = _dietDbContext.Dietas.Where(d => d.UserCpf == user.Cpf).ToList();

    return Ok(user);
}    


[HttpPost]
    public IActionResult CadastrarUser(UserRequestApiDto novoUser){


        var userExistente = _dietDbContext.Users.FirstOrDefault(u => u.Id == novoUser.Id);
          if (userExistente != null)
            {
                return Ok();
            }

        var userParaCadastro = _mapper.Map<User>(novoUser);

        var result = _dietDbContext.Users.Add(userParaCadastro);
        _dietDbContext.SaveChanges();
        var UserSalvo = result.Entity;

        return CreatedAtAction(nameof(GetById), new { UserSalvo.Id }, UserSalvo);
    }



}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Connections;
using mxm_webDiet.Domains.Dto;
namespace mxm_webDiet.Domains.Models;

public class User
{ 
 [Key]
 [Required]
public int Id { get; set; }

[Required]
public string? Nome { get; set; }

[Required]
public string? Cpf { get; set; }

public List<Dietas> Dietas {get; set;} = new();
}

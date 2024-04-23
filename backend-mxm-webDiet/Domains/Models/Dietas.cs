using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.Connections;
using mxm_webDiet.Domains.Dto;
namespace mxm_webDiet.Domains.Models;

public class Dietas
{ 
    [Key]
    [Required]
    public int Id { get; set; }

    public ResponseApiDTO? responseApiDTO { get; set; }
    public string? UserCpf {get;set;}
    public DateTime? CriadoEm { get; set; } = DateTime.Now;

        

}
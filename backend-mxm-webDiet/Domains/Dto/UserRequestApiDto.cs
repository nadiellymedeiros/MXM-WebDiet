using System.ComponentModel.DataAnnotations;

namespace mxm_webDiet.Domains.Dto;

public class UserRequestApiDto
{ 
 [Key]
 [Required]
public int Id { get; set; }

[Required]
public string? Nome { get; set; }

[Required]
public string? Cpf { get; set; }

}

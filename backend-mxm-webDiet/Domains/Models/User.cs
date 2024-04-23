using System.ComponentModel.DataAnnotations;

namespace mxm_webDiet.Domains.Models;

public class User
{
[Required]
public int Id { get; set; }

[Required]
public string? Nome { get; set; }

[Required]
public string? Cpf { get; set; }
}

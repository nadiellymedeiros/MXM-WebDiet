using System.ComponentModel.DataAnnotations;

namespace mxm_webDiet.Domains.Dto;

public class ResponseApiDTO
{
    [Key]
    [Required]
    public int Id { get; set; }
    public ChoiceDTO? Choice { get; set; }
}
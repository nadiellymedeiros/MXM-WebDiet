using System.ComponentModel.DataAnnotations;

namespace mxm_webDiet.Domains.Dto;

 public class ChoiceDTO
    {
        [Key]
         public int Id { get; set; }
        public string? Text { get; set; }
    }
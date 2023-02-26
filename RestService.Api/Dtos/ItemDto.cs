using System.ComponentModel.DataAnnotations;

namespace RestService.Api.Dtos
{
    public record ItemDto
    {
        [Required]
        public string Name {get; init;}
        
        [Required]
        [Range(1, 1000)]
        public decimal Price {get; init;}
    }
}
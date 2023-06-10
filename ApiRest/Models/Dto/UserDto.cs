using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }
        public int Age { get; set; }
        public int Money { get; set; }
    }
}

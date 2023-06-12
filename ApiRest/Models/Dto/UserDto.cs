using System.ComponentModel.DataAnnotations;

namespace ApiRest.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter your username")]
        [DataType(DataType.Text)]
        [MaxLength(15)]
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string imageUrl { get; set; }
    }
}

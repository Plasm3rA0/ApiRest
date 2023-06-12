using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ApiRest.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string email { get; set; }
        [AllowNull]
        public string username { get; set; }
        [AllowNull]
        public string password { get; set; }
        public string name { get; set; }
        public string surnames { get; set; }
        public int age { get; set; }
        public string imageUrl { get; set; }

        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}

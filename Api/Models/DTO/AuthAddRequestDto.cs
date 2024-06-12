using System.ComponentModel.DataAnnotations ; 

namespace Api.Models.DTO
{

    public class AuthAddRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }

    }

}
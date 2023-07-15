using System.ComponentModel.DataAnnotations;

namespace RestFullAPI.Models.DTOs.User
{
    public class AuthenticationDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

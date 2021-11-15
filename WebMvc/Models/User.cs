using System.ComponentModel.DataAnnotations;

namespace WebMvc.Models
{
    public class User
    {
        public int Id { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Informe o e-mail do usuário", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Informe a senha do usuário", AllowEmptyStrings = false)]
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public User()
        {

        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}

// Models/LoginModel.cs
using System.ComponentModel.DataAnnotations;

public class LoginModel
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Şifre zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}

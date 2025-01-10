
using System.ComponentModel.DataAnnotations;

namespace ProLab.Application.Auth.Commands;
public class CreateUserCommand
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
}

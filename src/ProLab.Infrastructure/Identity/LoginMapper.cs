using ProLab.Application.Auth.Commands;
using ProLab.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab.Infrastructure.Identity;
internal static class LoginMapper
{
    public static User ToEntity(this CreateLoginCommand command, User entity)
    {
        entity.Name = command.UserName;
        entity.PasswordHash = command.PasswordHash;

        return entity;
    }
}

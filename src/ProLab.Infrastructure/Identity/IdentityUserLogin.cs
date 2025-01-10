using ProLab.Domain;
using ProLab.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab.Infrastructure.Identity;
public class IdentityUserLogin : Entity<Guid>
{
    public IdentityUserLogin(string UserName) : this(Guid.NewGuid(), UserName) { }

    public IdentityUserLogin(Guid id, string UserName)
    {
        Id = id;
        this.UserName = UserName;
    }

    public string UserName { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}

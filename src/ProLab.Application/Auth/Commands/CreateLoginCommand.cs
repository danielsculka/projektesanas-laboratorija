using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab.Application.Auth.Commands;
public  class CreateLoginCommand
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    
}

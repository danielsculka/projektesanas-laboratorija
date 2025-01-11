using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProLab.Shared.Auth.Request;
public class CreateLoginRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

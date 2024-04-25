using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upcoursework.Context.Entities.User;
public class AppUser : IdentityUser<Guid>
{
    public required string DisplayName { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastAccessDate { get; set; }
}

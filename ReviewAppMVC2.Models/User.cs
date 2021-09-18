using Microsoft.AspNetCore.Identity;
using System;

namespace ReviewAppMVC2.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}

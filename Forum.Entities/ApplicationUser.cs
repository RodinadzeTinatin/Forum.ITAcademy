using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name {  get; set; }
        public bool Access { get; set; } = true;
        public ICollection<Comment> Comments { get; set; } 
        public ICollection<Topic> Topics { get; set; }
    }
}

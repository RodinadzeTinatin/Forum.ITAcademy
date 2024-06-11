using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class UserNotFoundExcpetion : Exception
    {
        public UserNotFoundExcpetion() : base("User not found")
        {
        }
    }
}

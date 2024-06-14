using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class LockedOutException : Exception
    {
        public LockedOutException():base("The user is currently locked out. Can't perform actions")
        { }
    }
}

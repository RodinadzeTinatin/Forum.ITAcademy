using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class LockOutNotSetException : Exception
    {
        public LockOutNotSetException() : base("Lock out is not set on this user")
        { }
    }
}

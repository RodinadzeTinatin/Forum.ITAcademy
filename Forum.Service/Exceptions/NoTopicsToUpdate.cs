using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class NoTopicsToUpdate:Exception
    {
        public NoTopicsToUpdate() :base("There are no topics to update their status"){ }
    }
}

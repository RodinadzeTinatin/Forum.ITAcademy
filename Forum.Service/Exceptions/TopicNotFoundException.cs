using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class TopicNotFoundException :Exception
    {
        public TopicNotFoundException() : base("Topic not found") 
        {
        }
    }
}

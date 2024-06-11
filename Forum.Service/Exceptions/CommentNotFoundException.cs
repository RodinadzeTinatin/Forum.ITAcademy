using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Exceptions
{
    public class CommentNotFoundException : Exception
    {
        public CommentNotFoundException() :base("Comment not found") { }
    }
}

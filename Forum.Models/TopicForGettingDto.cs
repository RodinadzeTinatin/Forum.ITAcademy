using Forum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class TopicForGettingDto
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public State State { get; set; } 
        public Status Status { get; set; }
        public List<CommentForGettingDto> Comments { get; set; }
        public int CommentCount { get; set; }

        public string UserId { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
    }
}

using Forum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class TopicForCreatingDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        //[Required]
        //public State State { get; set; } = State.Pending;

        //[Required]
        //public Status Status { get; set; } = Status.Active;

        //[Required]
        //[DataType(DataType.Date)]
        //public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; }


    }
}

using Forum.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class CommentForUpdatingDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Content { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}

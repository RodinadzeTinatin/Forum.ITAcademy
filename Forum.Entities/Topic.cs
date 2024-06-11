using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class Topic
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public State State { get; set; } = State.Pending;

        [Required]
        public Status Status { get; set; } = Status.Active;

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public ICollection<Comment> Comments { get; set;}

        
    }
}

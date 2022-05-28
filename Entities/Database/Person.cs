using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Database
{
    [Table("Person")]
    public class Person
    {
        [Column("PersonId")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Address1 is required.")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters.")]
        public string? Address1 { get; set; }
        [MaxLength(255, ErrorMessage = "Maximum 255 characters.")]
        public string? Address2 { get; set; }

        // Foreign keys
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}

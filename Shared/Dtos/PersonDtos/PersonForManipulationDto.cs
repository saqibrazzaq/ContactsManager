using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.PersonDtos
{
    public abstract record PersonForManipulationDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100, ErrorMessage = "Maximum 100 characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Address1 is required.")]
        [MaxLength(255, ErrorMessage = "Maximum 255 characters.")]
        public string? Address1 { get; set; }
        [MaxLength(255, ErrorMessage = "Maximum 255 characters.")]
        public string? Address2 { get; set; }
    }
}

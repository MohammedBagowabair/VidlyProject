using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public short SginUpFee { get; set; }

        [Required]
        public byte DurationInMonth { get; set; }

        [Required]
        public byte DiscountRate { get; set; }
    }
}
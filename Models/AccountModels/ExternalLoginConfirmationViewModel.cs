using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string StudentTicket { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }

    }
}
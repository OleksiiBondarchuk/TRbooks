using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRbooks.Models;
using System.ComponentModel.DataAnnotations; 

namespace TRbooks.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
   
        public byte MembershipTypeId { get; set; }

        //[Min18IfAMember]
        public DateTime? Birthdate { get; set; } 
    }
}
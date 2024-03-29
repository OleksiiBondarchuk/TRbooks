﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }


        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership type")]
        public byte MembershipTypeId { get; set; }

        [Min18IfAMemberAttribute]
        public DateTime? Birthdate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required ]
        [StringLength(255)] // These are called anotations
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")] //this is the annotation for the label to be displayed on the front-end (view). The labelFor method will use it in the views.
        public string BirthDate { get; set; }
    }
}
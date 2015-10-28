using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace The_List_Of_Contacts.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\d{1}\(\d{3}\)\d{7}$")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"\b[a-z0-9._]+@[a-z0-9.-]+\.[a-z]{2,4}\b")]
        public string Email { get; set; }
    }
}

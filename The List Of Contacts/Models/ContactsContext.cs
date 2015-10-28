using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace The_List_Of_Contacts.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext()
            : base("ContactConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
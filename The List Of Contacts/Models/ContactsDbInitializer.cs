using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace The_List_Of_Contacts.Models
{
    public class ContactsDbInitializer : DropCreateDatabaseAlways<ContactsContext>
    {
        protected override void Seed(ContactsContext context)
        {
            context.Contacts.Add(new Contact() { Id = 1, ContactNumber = "СС-000001-SL", Name = "Иван", SecondName = "Сергеевич", LastName = "Петров", PhoneNumber = "8(097)1234567", Email = "petrov@ivan.ua" });
            context.Contacts.Add(new Contact() { Id = 2, ContactNumber = "СС-000002-SL", Name = "Василий", SecondName = "Петрович", LastName = "Сидоров", PhoneNumber = "8(097)7654321", Email = "sidorov@vasiliy.ua" });
            context.Contacts.Add(new Contact() { Id = 3, ContactNumber = "СС-000003-SL", Name = "Ян", SecondName = "Иванович", LastName = "Васин", PhoneNumber = "8(097)7415263", Email = "vasin@yan.ua" });
            
            base.Seed(context);
        }
    }
}
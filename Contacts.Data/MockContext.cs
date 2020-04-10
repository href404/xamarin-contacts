using Contacts.Data.Models;
using System.Collections.Generic;

namespace Contacts.Data
{
    internal class MockContext
    {
        public List<Contact> Contacts = new List<Contact>
        {
            new Contact { Id = 1, LastName = "Doche", FirstName = "Maxime" },
            new Contact { Id = 2, LastName = "Condaminas", FirstName = "Louis" },
            new Contact { Id = 3, LastName = "Julien", FirstName = "Pierre" }
        };
    }
}

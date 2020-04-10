using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Mock;
using Contacts.Models;
using System;
using System.Threading.Tasks;

namespace Contacts.Services
{
    public class ContactService
    {
        private readonly MockContactRepository ContactRepository;

        public ContactService()
        {
            ContactRepository = new MockContactRepository(new MockContext());
        }

        public async Task<ContactModel> ReadAsync(int id)
        {
            Contact contact = await ContactRepository.ReadAsync(id);
            return new ContactModel { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName };
        }

        public async Task UpdateAsync(ContactModel contact)
        {
            await ContactRepository.UpdateAsync(new Contact 
            { 
                Id = contact.Id,
                FirstName = contact.FirstName, 
                LastName = contact.LastName 
            });
        }

        public async Task DeleteAsync(ContactModel contact)
        {
            await ContactRepository.DeleteAsync(contact.Id);
        }
    }
}

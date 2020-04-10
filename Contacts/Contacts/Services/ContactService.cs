using Contacts.Data.Models;
using Contacts.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Contacts.Data.Repositories;
using Contacts.Data.Repositories.SQL;

namespace Contacts.Services
{
    public class ContactService
    {
        private readonly IContactRepository ContactRepository;

        public ContactService() => ContactRepository = new SQLContactRepository();

        public async Task<ContactModel> ReadAsync(int id)
        {
            Contact contact = await ContactRepository.ReadAsync(id);
            return contact != null ? new ContactModel { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName } : null;
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

        public async Task DeleteAsync(ContactModel contact) => await ContactRepository.DeleteAsync(contact.Id);

        public async Task<ObservableCollection<ContactModel>> ReadAsync()
        {
            IEnumerable<Contact> contacts = await ContactRepository.ReadAsync();
            return new ObservableCollection<ContactModel>(contacts.Select(contact => new ContactModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName
            }));
        }

        public async Task AddAsync(ContactModel contact)
        {
            await ContactRepository.AddAsync(new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName
            });
        }
    }
}

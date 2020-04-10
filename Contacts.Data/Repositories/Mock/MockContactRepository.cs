using Contacts.Data.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace Contacts.Data.Repositories.Mock
{
    public class MockContactRepository
    {
        private readonly MockContext Context;

        public MockContactRepository(MockContext context)
        {
            Context = context;
        }

        public async Task<Contact> ReadAsync(int id)
        {
            return await Task.FromResult(Context.Contacts.FirstOrDefault(c => c.Id == id));
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            int indexContact = Context.Contacts.FindIndex(c => c.Id == contact.Id);
            if (indexContact == -1) 
                return await Task.FromResult(false);

            Context.Contacts[indexContact] = contact;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            int indexContact = Context.Contacts.FindIndex(c => c.Id == id);
            if (indexContact == -1)
                return await Task.FromResult(false);

            Context.Contacts.RemoveAt(indexContact);
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Contact>> ReadAsync()
        {
            return await Task.FromResult(Context.Contacts);
        }

        public async Task<bool> AddAsync(Contact contact)
        {
            contact.Id = Context.Contacts.Count != 0 ? Context.Contacts.Max(c => c.Id) + 1 : 1;
            Context.Contacts.Add(contact);

            int indexContact = Context.Contacts.FindIndex(c => c.Id == contact.Id);
            if (indexContact == -1)
                return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
    }
}

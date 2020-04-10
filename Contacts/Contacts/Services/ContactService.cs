using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Data.Repositories.Mock;
using Contacts.Models;
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
            return new ContactModel { LastName = contact.LastName, FirstName = contact.FirstName };
        }
    }
}

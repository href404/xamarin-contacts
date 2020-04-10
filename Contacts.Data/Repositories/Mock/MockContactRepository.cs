using Contacts.Data.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Contacts.Data.Repositories.Mock
{
    internal class MockContactRepository
    {
        private readonly MockContext Context;

        public MockContactRepository(MockContext context)
        {
            Context = context;
        }

        public async Task<Contact> Read(int id)
        {
            return await Task.FromResult(Context.Contacts.FirstOrDefault(contact => contact.Id == id));
        }
    }
}

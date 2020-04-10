using Contacts.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> ReadAsync();
        Task<Contact> ReadAsync(int id);
        Task<bool> AddAsync(Contact contact);
        Task<bool> UpdateAsync(Contact contact);
        Task<bool> DeleteAsync(int id);
    }
}

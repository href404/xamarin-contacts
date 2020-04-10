using Contacts.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Repositories.SQL
{
    public class SQLContactRepository : IContactRepository
    {
        public async Task<bool> AddAsync(Contact contact)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Contacts.Add(contact);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (SQLContext context = new SQLContext())
            {
                Contact contact = await ReadAsync(id);
                context.Contacts.Remove(contact);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }

        public async Task<IEnumerable<Contact>> ReadAsync()
        {
            using (SQLContext context = new SQLContext())
            {
                return await context.Contacts.AsNoTracking().ToListAsync();
            }
        }

        public async Task<Contact> ReadAsync(int id)
        {
            using (SQLContext context = new SQLContext())
            {
                return await context.Contacts.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            }
        }

        public async Task<bool> UpdateAsync(Contact contact)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Contacts.Update(contact);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
        }
    }
}

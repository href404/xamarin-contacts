using Contacts.Models;
using System.Threading.Tasks;

namespace Contacts.ViewModels
{
    public class DisplayContactViewModel : BaseViewModel
    {
        private ContactModel model;

        public ContactModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }

        public DisplayContactViewModel()
        {
            Messaging.Subscribe<int>(Services.MessageType.ReadContact, async (sender, id) => await ReadAsync(id));
        }

        private async Task ReadAsync(int id) => Model = await Service.ReadAsync(id);

        public void EditContact()
        {
            Messaging.Send(Services.MessageType.EditContact, Model);
        }
    }
}

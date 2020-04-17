using Contacts.Models;
using Contacts.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public Command EditCommand { get; }

        public DisplayContactViewModel()
        {
            Messaging.Subscribe<int>(MessageType.ReadContact, async (sender, id) => Model = await Service.ReadAsync(id));
            EditCommand = new Command(async () => await EditContact());
        }

        public async Task EditContact()
        {
            await Navigation.PushAsync(PageKey.EditContact, true);
            Messaging.Send(MessageType.EditContact, Model);
        }
    }
}

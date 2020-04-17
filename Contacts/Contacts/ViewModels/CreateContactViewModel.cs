using Contacts.Models;
using Contacts.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class CreateContactViewModel : BaseViewModel
    {
        public ContactModel Model { get; private set; }
        public Command SaveCommand { get; }

        public CreateContactViewModel()
        {
            Model = new ContactModel();
            SaveCommand = new Command(async () => await SaveAsync());
        }

        private async Task SaveAsync()
        {
            await Service.AddAsync(Model);
            await Navigation.PopAsync();
            Messaging.Send(MessageType.RefreshContact);
        }
    }
}

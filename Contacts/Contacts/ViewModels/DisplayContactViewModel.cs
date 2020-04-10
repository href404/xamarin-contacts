using Contacts.Models;
using Contacts.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class DisplayContactViewModel
    {
        public ContactModel Model { get; private set; }
        public Command LoadCommand { get; }

        private readonly ContactService Service;

        public DisplayContactViewModel()
        {
            Service = new ContactService();
            LoadCommand = new Command(async () => await LoadAsync());
            
            LoadCommand.Execute(null);
        }

        private async Task LoadAsync() => Model = await Service.ReadAsync(1);
    }
}

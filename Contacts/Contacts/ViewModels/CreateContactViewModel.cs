using Contacts.Models;
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
            SaveCommand = new Command(async () => await Service.AddAsync(Model));
        }
    }
}

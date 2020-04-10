using Contacts.Models;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class EditContactViewModel : BaseViewModel
    {
        public ContactModel Model { get; private set; }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public EditContactViewModel(ContactModel model)
        {
            Model = model;
            SaveCommand = new Command(async () => await Service.UpdateAsync(Model));
            DeleteCommand = new Command(async () => await Service.DeleteAsync(Model));
        }
    }
}

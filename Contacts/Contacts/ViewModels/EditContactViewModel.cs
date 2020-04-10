using Contacts.Models;
using System.Threading.Tasks;
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
            SaveCommand = new Command(async () => await SaveAsync());
            DeleteCommand = new Command(async () => await DeleteAsync());
        }
        private async Task SaveAsync() => await Service.UpdateAsync(Model);
        private async Task DeleteAsync() => await Service.DeleteAsync(Model);
    }
}

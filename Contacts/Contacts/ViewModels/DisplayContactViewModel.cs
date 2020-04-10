using Contacts.Models;
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

        public Command LoadCommand { get; }

        public DisplayContactViewModel()
        {
            LoadCommand = new Command(async () => Model = await Service.ReadAsync(1));
        }
    }
}

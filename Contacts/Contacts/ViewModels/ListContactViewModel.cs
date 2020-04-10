using Contacts.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class ListContactViewModel : BaseViewModel
    {
        public ObservableCollection<ContactModel> Models { get; private set; }
        public Command LoadCommand { get; }

        public ListContactViewModel() 
        {
            Models = new ObservableCollection<ContactModel>();
            LoadCommand = new Command(async () => await LoadAsync());
        }

        private async Task LoadAsync()
        {
            Models.Clear();

            foreach (ContactModel contact in await Service.ReadAsync())
                Models.Add(contact);
        }
    }
}

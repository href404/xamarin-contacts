using Contacts.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class ListContactViewModel : BaseViewModel
    {
        public ObservableCollection<ContactModel> Models { get; private set; }
        public Command LoadCommand { get; }

        public ListContactViewModel() 
        {
            LoadCommand = new Command(async () => Models = await Service.ReadAsync());
            LoadCommand.Execute(null);
        }
    }
}

using Contacts.Models;
using Contacts.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class ListContactViewModel : BaseViewModel
    {
        private ContactModel selected;

        public ContactModel Selected
        {
            get { return selected; }
            set 
            { 
                SetProperty(ref selected, value);
                DisplayCommand.Execute(null);
            }
        }
        public ObservableCollection<ContactModel> Models { get; private set; }
        public Command LoadCommand { get; }
        public Command AddCommand { get; }
        public Command DisplayCommand { get; }

        public ListContactViewModel() 
        {
            Models = new ObservableCollection<ContactModel>();
            LoadCommand = new Command(async () => await LoadAsync());
            AddCommand = new Command(async () => await Navigation.PushAsync(PageKey.AddContact));
            DisplayCommand = new Command(async () => await DisplayContactAsync());

            Messaging.Subscribe(MessageType.RefreshContact, async (sender) => await LoadAsync());
            LoadCommand.Execute(null);
        }

        public async Task DisplayContactAsync()
        {
            await Navigation.PushAsync(PageKey.DisplayContact);
            Messaging.Send(MessageType.ReadContact, Selected.Id);
            Selected = null;
        }

        private async Task LoadAsync()
        {
            Models.Clear();
            foreach (ContactModel contact in await Service.ReadAsync())
                Models.Add(contact);
        }
    }
}

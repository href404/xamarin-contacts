using Contacts.Services;
using Contacts.Views;
using Xamarin.Forms;

namespace Contacts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            NavigationService.AddPage(PageKey.ListContact, typeof(ListContactView));
            NavigationService.AddPage(PageKey.DisplayContact, typeof(DisplayContactView));
            NavigationService.AddPage(PageKey.AddContact, typeof(CreateContactView));
            NavigationService.AddPage(PageKey.EditContact, typeof(EditContactView));

            MainPage = new NavigationPage(new ListContactView());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

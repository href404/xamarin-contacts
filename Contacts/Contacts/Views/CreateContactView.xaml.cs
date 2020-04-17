using Contacts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateContactView : ContentPage
    {
        public CreateContactView()
        {
            InitializeComponent();
            BindingContext = new CreateContactViewModel();
        }
    }
}
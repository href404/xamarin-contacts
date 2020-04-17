using Contacts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactView : ContentPage
    {
        public EditContactView()
        {
            InitializeComponent();
            BindingContext = new EditContactViewModel();
        }
    }
}
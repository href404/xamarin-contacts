using Contacts.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactView : ContentPage
    {
        public ListContactView()
        {
            InitializeComponent();
            BindingContext = new ListContactViewModel();
        }
    }
}
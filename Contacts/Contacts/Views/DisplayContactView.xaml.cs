using Contacts.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayContactView : ContentPage
    {
        public DisplayContactView()
        {
            InitializeComponent();
            BindingContext = new DisplayContactViewModel();
        }
    }
}
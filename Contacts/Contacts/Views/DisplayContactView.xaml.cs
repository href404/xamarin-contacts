using Contacts.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayContactView : ContentPage
    {
        private readonly DisplayContactViewModel ViewModel;

        public DisplayContactView()
        {
            InitializeComponent();
            ViewModel = new DisplayContactViewModel();
            BindingContext = ViewModel;
        }

        private async void Edit_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditContactView());
            Navigation.RemovePage(this);
            ViewModel.EditContact();
        }
    }
}
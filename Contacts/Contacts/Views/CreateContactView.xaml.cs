using Contacts.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateContactView : ContentPage
    {
        private readonly CreateContactViewModel ViewModel;

        public CreateContactView()
        {
            InitializeComponent();
            ViewModel = new CreateContactViewModel();
            BindingContext = ViewModel;
        }

        private async void Save_Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute(null);
            await Navigation.PopAsync();
        }
    }
}
using Contacts.Models;
using Contacts.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditContactView : ContentPage
    {
        private readonly EditContactViewModel ViewModel;

        public EditContactView(ContactModel model)
        {
            InitializeComponent();
            ViewModel = new EditContactViewModel(model);
            BindingContext = ViewModel;
        }

        private async void Save_Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.SaveCommand.Execute(null);
            await Navigation.PopAsync();
        }

        private async void Delete_Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.DeleteCommand.Execute(null);
            await Navigation.PopAsync();
        }
    }
}
using Contacts.Models;
using Contacts.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contacts.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListContactView : ContentPage
    {
        private readonly ListContactViewModel ViewModel;

        public ListContactView()
        {
            InitializeComponent();
            ViewModel = new ListContactViewModel();
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadCommand.Execute(null);
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ContactModel contact = (ContactModel) e.Item;
            await Navigation.PushAsync(new DisplayContactView(contact.Id));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateContactView());
        }
    }
}
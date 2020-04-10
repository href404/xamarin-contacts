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

        public DisplayContactView(int id)
        {
            InitializeComponent();
            ViewModel = new DisplayContactViewModel(id);
            BindingContext = ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadCommand.Execute(null);
        }

        private async void Edit_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditContactView(ViewModel.Model));
            Navigation.RemovePage(this);
        }
    }
}
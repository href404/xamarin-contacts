using Contacts.Models;
using Contacts.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.ViewModels
{
    public class EditContactViewModel : BaseViewModel
    {
        private ContactModel model;

        public ContactModel Model
        {
            get { return model; }
            set { SetProperty(ref model, value); }
        }
        public Command SaveCommand { get; }
        public Command DeleteCommand { get; }

        public EditContactViewModel()
        {
            SaveCommand = new Command(async () => await UpdateAsync());
            DeleteCommand = new Command(async () => await DeleteAsync());

            Messaging.Subscribe<ContactModel>(MessageType.EditContact, (sender, model) => Model = model);
        }


        private async Task UpdateAsync()
        {
            await Service.UpdateAsync(Model);
            Messaging.Send(MessageType.RefreshContact);
        }


        private async Task DeleteAsync()
        {
            await Service.DeleteAsync(Model);
            Messaging.Send(MessageType.RefreshContact);
        }
    }
}

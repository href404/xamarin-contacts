using System;
using Xamarin.Forms;

namespace Contacts.Services
{
    public class MessagingService
    {
        public void Send(MessageType messageType) => MessagingCenter.Send(this, ((int)messageType).ToString());
        public void Subscribe(MessageType messageType, Action<MessagingService> callback) => MessagingCenter.Subscribe(this, ((int)messageType).ToString(), callback);
    }

    public enum MessageType
    {
        None,
        RefreshContact,
        EditContact,
        DeleteContact
    }
}

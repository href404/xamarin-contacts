using System;
using Xamarin.Forms;

namespace Contacts.Services
{
    public class MessagingService
    {
        public void Send(MessageType messageType) => MessagingCenter.Send(this, ((int)messageType).ToString());
        public void Send<T>(MessageType messageType, T item) => MessagingCenter.Send(this, ((int)messageType).ToString(), item);
        public void Subscribe(MessageType messageType, Action<MessagingService> callback) => MessagingCenter.Subscribe(this, ((int)messageType).ToString(), callback);
        public void Subscribe<T>(MessageType messageType, Action<MessagingService, T> callback) => MessagingCenter.Subscribe(this, ((int)messageType).ToString(), callback);
    }

    public enum MessageType
    {
        None,
        RefreshContact,
        ReadContact,
        EditContact,
        DeleteContact
    }
}

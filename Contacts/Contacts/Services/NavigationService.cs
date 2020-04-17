using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.Services
{
    public class NavigationService
    {
        private readonly Stack<Page> pages = new Stack<Page>();
        private static readonly Dictionary<PageKey, Type> pageTypes = new Dictionary<PageKey, Type>();

        public NavigationService() => pages.Push(Application.Current.MainPage);
        
        public static void AddPage(PageKey key, Type type) => pageTypes[key] = type;

        public async Task PushAsync(PageKey pageKey)
        {
            Page page = (Page) Activator.CreateInstance(pageTypes[pageKey]);
            await pages.Peek().Navigation.PushAsync(page);
            pages.Push(page);
        }

        public async Task PopAsync()
        {
            Page page = pages.Pop();
            await page.Navigation.PopAsync();
        }

        public void Remove(object page) { }
    }

    public enum PageKey
    {
        None,
        ListContact,
        DisplayContact,
        AddContact,
        EditContact
    }
}

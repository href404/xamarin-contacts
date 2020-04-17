using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Contacts.Services
{
    public class NavigationService
    {
        private static readonly Stack<Page> pages = new Stack<Page>();
        private static readonly Dictionary<PageKey, Type> pageTypes = new Dictionary<PageKey, Type>();

        public static void SetMainPage() => pages.Push(Application.Current.MainPage);
        public static void AddPage(PageKey key, Type type) => pageTypes[key] = type;

        public async Task PushAsync(PageKey pageKey, bool remove = false)
        {
            CleanStack();

            Page parent = pages.Peek();
            Page page = (Page) Activator.CreateInstance(pageTypes[pageKey]);
            await parent.Navigation.PushAsync(page);

            if (remove)
                Remove(parent, page);

            pages.Push(page);
        }

        private void CleanStack()
        {
            while (pages.Count > 1 && ((NavigationPage)Application.Current.MainPage).CurrentPage != pages.Peek())
                pages.Pop();
        }

        public async Task PopAsync()
        {
            Page page = pages.Pop();
            await page.Navigation.PopAsync();
        }

        private void Remove(Page parent, Page page)
        {
            parent.Navigation.RemovePage(page);
            pages.Pop();
        }
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

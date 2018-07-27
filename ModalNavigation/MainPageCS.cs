using System.Collections.Generic;
using Xamarin.Forms;

namespace ModalNavigation
{
    public class MainPageCS : ContentPage
    {
        ListView listView;
        List<Contact> contacts;

        public MainPageCS()
        {
            SetupData();

            listView = new ListView
            {
                ItemsSource = contacts
            };
            listView.ItemSelected += OnItemSelected;

            Thickness padding;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    padding = new Thickness(0, 40, 0, 0);
                    break;
                default:
                    padding = new Thickness();
                    break;
            }

            Padding = padding;
            Content = new StackLayout
            {
                Children = {
                    listView
                }
            };
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                var detailPage = new DetailPageCS();
                detailPage.BindingContext = e.SelectedItem as Contact;
                listView.SelectedItem = null;
                await Navigation.PushModalAsync(detailPage);
            }
        }

        void SetupData()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact
            {
                Name = "Justin Jackson",
                Age = 40,
                Occupation = "Nurse",
                Country = "China"
            });
            contacts.Add(new Contact
            {
                Name = "David Poarch",
                Age = 35,
                Occupation = "Civil Engineer",
                Country = "Japan"
            });
            contacts.Add(new Contact
            {
                Name = "Cashier",
                Age = 27,
                Occupation = "PM",
                Country = "Virginia"
            });
            contacts.Add(new Contact
            {
                Name = "Richard Vandolf",
                Age = 46,
                Occupation = "Accountant",
                Country = "Australia"
            });
            contacts.Add(new Contact
            {
                Name = "James Junior",
                Age = 25,
                Occupation = "Developer",
                Country = "North Korea"
            });
        }
    }
}

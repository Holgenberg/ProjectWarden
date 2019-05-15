using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectWarden
{
    public partial class MainPage : ContentPage
    {
        List<string> country = new List<string>
        {
            "India",
            "pakistan",
            "Srilanka",
            "Bangladesh",
            "Afghanistan"
        };

        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchContent.Text;
            if (keyword.Length >= 1)
            {
                var suggestion = country.Where(c => c.ToLower().Contains(keyword.ToLower()));
                CountryList.ItemsSource = suggestion;
                CountryList.IsVisible = true;
            }
            else
            {
                CountryList.IsVisible = false;
            }
        }

        private void CountryList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item as string == null)
            {
                return;
            }
            else
            {
                CountryList.ItemsSource = country.Where(c => c.Equals(e.Item as string));
                CountryList.IsVisible = true;
                SearchContent.Text = e.Item as string;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjectWarden.Models;
using System.Collections;
using System.Globalization;

namespace ProjectWarden
{
    public partial class MainPage : ContentPage
    {
        List<PropertyAddress> _propertyAddresses;

        public MainPage()
        {
            InitializeComponent();
            _propertyAddresses = SetPropertyAddresses();
        }

        private List<PropertyAddress> SetPropertyAddresses()
        {
            var propertyAddresses = new List<PropertyAddress>()
            {
                new PropertyAddress(){Address="37 Bagpipe Lane, Shamrock, Ireland", Postcode="A54 F4R2"},
                new PropertyAddress(){Address="54 Guiness Avenue, Potato, Ireland", Postcode="T45 B4R2"}
            };

            return propertyAddresses;
        }

        private void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                SubmitReviewBtn.IsVisible = true;
                AddressAndPostcodeList.IsVisible = false;
                AbsoluteLayout.SetLayoutFlags(StckLayout, AbsoluteLayoutFlags.PositionProportional);
            }

            else
            {
                AbsoluteLayout.SetLayoutFlags(StckLayout, AbsoluteLayoutFlags.None);
                SubmitReviewBtn.IsVisible = false;
                AddressAndPostcodeList.IsVisible = true;
                AddressAndPostcodeList.ItemsSource = GetRelevantPropertyAddresses(e);                         
            }
        }

        private IEnumerable GetRelevantPropertyAddresses(TextChangedEventArgs e)
        {
            var relevantPropertyAdressesAndPostcodes = new List<PropertyAddress>();

            CultureInfo culture = new CultureInfo("es-ES", false);

            relevantPropertyAdressesAndPostcodes.AddRange(_propertyAddresses.Where(pAddress => 
                culture.CompareInfo.IndexOf(pAddress.Address, e.NewTextValue, CompareOptions.IgnoreCase) >= 0));
            relevantPropertyAdressesAndPostcodes.AddRange(_propertyAddresses.Where(pPostcode =>
                culture.CompareInfo.IndexOf(pPostcode.Postcode, e.NewTextValue, CompareOptions.IgnoreCase) >= 0));
            relevantPropertyAdressesAndPostcodes = relevantPropertyAdressesAndPostcodes.Distinct().ToList();

            return relevantPropertyAdressesAndPostcodes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjectWarden.Models;

namespace ProjectWarden
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var propertyAddresses = SetPropertyAddresses();
            //addressAndPostcodeList.ItemsSource = propertyAddresses;
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
    }
}

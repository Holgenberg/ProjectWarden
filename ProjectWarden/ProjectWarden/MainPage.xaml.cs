using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjectWarden.Models;
using System.Collections;
using System.Globalization;
using Xamarin.Essentials;

namespace ProjectWarden
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {            
            InitializeComponent();
        }

        private async void SearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                BackgroundImageSource = "AppBackground.jpg";
                SubmitReviewBtn.IsVisible = true;
                AddressListingsSearchAnimation.IsVisible = false;
                AddressListingsList.IsVisible = false;
                AddressListingsList.ItemsSource = null;
                AbsoluteLayout.SetLayoutFlags(StckLayout, AbsoluteLayoutFlags.PositionProportional);
            }

            else
            {
                AbsoluteLayout.SetLayoutFlags(StckLayout, AbsoluteLayoutFlags.None);
                BackgroundImageSource = null;
                SubmitReviewBtn.IsVisible = false;
                AddressListingsList.IsVisible = true;

                AddressListingsSearchAnimation.IsVisible = true;

                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    AddressListingsList.ItemsSource = await GetRelevantAddressListingsAsync(e);
                }

                AddressListingsSearchAnimation.IsVisible = false;
            }
        }

        async void SubmitReviewBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewSubmissionPage());
        }

        private async Task<List<AddressListing>> GetRelevantAddressListingsAsync(TextChangedEventArgs e)
        {
            var addressListings = await Task.Run(() => WebAPIHandler.GetRelevantAddressListings(e));
            return addressListings;
        }
    }
}

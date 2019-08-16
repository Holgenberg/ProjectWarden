using ProjectWarden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectWarden
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewsPage : ContentPage
	{
        private AddressListing AddressListing;

        public ReviewsPage (AddressListing addressListing)
		{
			InitializeComponent ();

            AddressListing = addressListing;
            HandleReviewsToDisplay();
		}

        private void DisplayReviews(List<DisplayReview> displayReviews)
        {
            ReviewsSearchAnimation.IsVisible = false;
            ReviewsScroller.IsVisible = true;

            foreach (var review in displayReviews)
            {
                review.ImageSource = review.Liked ? "SmileyButton.png" : "SadButton.png";
            }

            ReviewsList.ItemsSource = displayReviews;
        }

        private async void HandleReviewsToDisplay()
        {
            ReviewsSearchAnimation.IsVisible = true;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var displayReviews = await GetRelevantDisplayReviewsAsync();
                DisplayReviews(displayReviews);
            }

            else
            {
                await Navigation.PopAsync();
            }
        }

        private async Task<List<DisplayReview>> GetRelevantDisplayReviewsAsync()
        {
            var displayReviews = await Task.Run(() => WebAPIHandler.GetRelevantDisplayReviews(AddressListing));
            return displayReviews;
        }
    }
}
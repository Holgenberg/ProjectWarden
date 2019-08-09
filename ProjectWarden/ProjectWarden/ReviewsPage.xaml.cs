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

        private async void HandleReviewsToDisplay()
        {
            ReviewsSearchAnimation.IsVisible = true;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var reviews = await GetRelevantReviewsAsync();
            }

            ReviewsSearchAnimation.IsVisible = false;
        }

        private async Task<List<ReviewForm>> GetRelevantReviewsAsync()
        {
            var reviews = await Task.Run(() => WebAPIHandler.GetRelevantReviews(AddressListing));
            return reviews;
        }
    }
}
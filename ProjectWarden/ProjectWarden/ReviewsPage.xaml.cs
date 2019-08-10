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

        private void DisplayReviews(List<ReviewForm> reviews)
        {
            ReviewsSearchAnimation.IsVisible = false;
            ReviewsScroller.IsVisible = true;

            var displayReviews = new List<DisplayReview>();

            foreach (var review in reviews)
            {
                var displayReview = new DisplayReview();
                displayReview.Review = review.Review;
                displayReview.Username = review.Name;

                if (review.SmileyClicked)
                {
                    displayReview.ImageSource = "SmileyButton.png";
                }

                else if (review.SadClicked)
                {
                    displayReview.ImageSource = "SadButton.png";
                }

                displayReviews.Add(displayReview);
            }

            ReviewsList.ItemsSource = displayReviews;
        }

        private async void HandleReviewsToDisplay()
        {
            ReviewsSearchAnimation.IsVisible = true;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var reviews = await GetRelevantReviewsAsync();
                DisplayReviews(reviews);
            }

            else
            {
                await Navigation.PopAsync();
            }
        }

        private async Task<List<ReviewForm>> GetRelevantReviewsAsync()
        {
            var reviews = await Task.Run(() => WebAPIHandler.GetRelevantReviews(AddressListing));
            return reviews;
        }
    }
}
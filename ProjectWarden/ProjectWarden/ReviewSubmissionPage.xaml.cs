using ProjectWarden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectWarden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewSubmissionPage : ContentPage
    {
        ReviewForm reviewForm;

        public ReviewSubmissionPage()
        {
            InitializeComponent();
            SetBindingContextToReviewForm();

            VisualStateManager.GoToState(SmileyButton, "Unclicked");
            VisualStateManager.GoToState(SadButton, "Unclicked");
        }

        private void SetBindingContextToReviewForm()
        {
            reviewForm = new ReviewForm();
            BindingContext = reviewForm;
        }

        protected override bool OnBackButtonPressed()
        {
            HideThisPageContent();
            Navigation.PopAsync(true);
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            HideThisPageContent();
            base.OnDisappearing();
        }

        private void HideThisPageContent()
        {
            StckLayout.IsVisible = false;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void SmileyBtn_Clicked(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(SmileyButton, "Clicked");
            VisualStateManager.GoToState(SadButton, "Unclicked");
        }

        private void SadBtn_Clicked(object sender, EventArgs e)
        {
            VisualStateManager.GoToState(SadButton, "Clicked");
            VisualStateManager.GoToState(SmileyButton, "Unclicked");
        }

        private void SubmitBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reviewForm.AddressLine1))
            {
                VisualStateManager.GoToState(AddressLine1, "HasNoText");
            }

            if (string.IsNullOrEmpty(reviewForm.Postcode))
            {
                VisualStateManager.GoToState(CityTown, "HasNoText");
            }
        }

        private void AddressLine1_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(AddressLine1, "HasText");
        }

        private void CityTown_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(CityTown, "HasNoText");
        }
    }
}
using ProjectWarden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace ProjectWarden
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewSubmissionPage : ContentPage
    {
        ReviewForm reviewForm;

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
            reviewForm.SmileyClicked = true;
            reviewForm.SadClicked = false;

            ChangeButtonVisualStates(SmileyButton, SadButton);
        }

        private void ChangeButtonVisualStates(ImageButton clickedButton, ImageButton unclickedButton)
        {
            VisualStateManager.GoToState(SadOrSmileyButtonClickInformer, "Clicked");

            VisualStateManager.GoToState(clickedButton, "Clicked");
            VisualStateManager.GoToState(unclickedButton, "Unclicked");
        }

        private void SadBtn_Clicked(object sender, EventArgs e)
        {
            reviewForm.SadClicked = true;
            reviewForm.SmileyClicked = false;

            ChangeButtonVisualStates(SadButton, SmileyButton);
        }

        private void SubmitBtn_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(reviewForm.AddressLine1))
            {
                VisualStateManager.GoToState(AddressLine1, "HasNoText");
            }

            else if (string.IsNullOrEmpty(reviewForm.CityTown))
            {
                VisualStateManager.GoToState(CityTown, "HasNoText");
            }

            else if (string.IsNullOrEmpty(reviewForm.CountyRegionState))
            {
                VisualStateManager.GoToState(CountyRegionState, "HasNoText");
            }

            else if (string.IsNullOrEmpty(reviewForm.Postcode))
            {
                VisualStateManager.GoToState(Postcode, "HasNoText");
            }

            else if (reviewForm.ValidUKPostcode() == false)
            {
                VisualStateManager.GoToState(Postcode, "InvalidPostcode");
            }

            else if (string.IsNullOrEmpty(reviewForm.Name))
            {
                reviewForm.Name = "anonymous";
            }         
            
            else if (reviewForm.SadClicked == false && reviewForm.SmileyClicked == false)
            {
                VisualStateManager.GoToState(SadOrSmileyButtonClickInformer, "UnclickedAndSumbitted");
            }

            else if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                NoAccessToInternetInformer.IsVisible = true;
            }

            else
            {
                WebAPIHandler.SendToDatabase(reviewForm);
                Navigation.PopAsync();
            }
        }

        private void AddressLine1_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(AddressLine1, "HasText");
        }

        private void CityTown_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(CityTown, "HasText");
        }

        private void CountyRegionState_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(CountyRegionState, "HasText");
        }

        private void Postcode_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            VisualStateManager.GoToState(Postcode, "HasText");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NavigationPage.SetHasNavigationBar(this, true);

            InitializeComponent();

            VisualStateManager.GoToState(SmileyButton, "Unclicked");
            VisualStateManager.GoToState(SadButton, "Unclicked");

            if (reviewForm == null)
            {
                SetBindingContextToReviewForm();

                reviewForm.SadClicked = false;
                reviewForm.SmileyClicked = false;
            }

            else
            {
                PopulateFormEntriesFromSavedForm();
            }
        }

        private void PopulateFormEntriesFromSavedForm()
        {
            AddressLine1.Text = reviewForm.AddressLine1;
            AddressLine2.Text = reviewForm.AddressLine2;
            CityTown.Text = reviewForm.CityTown;
            CountyRegionState.Text = reviewForm.CountyRegionState;
            Postcode.Text = reviewForm.Postcode;
            Name.Text = reviewForm.Name;
            Review.Text = reviewForm.Review;

            if (reviewForm.SmileyClicked)
            {
                ChangeButtonVisualStates(SmileyButton, SadButton);
            }

            else if (reviewForm.SadClicked)
            {
                ChangeButtonVisualStates(SadButton, SmileyButton);
            }
        }
    }
}
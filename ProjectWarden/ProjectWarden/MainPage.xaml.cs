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
        public MainPage()
        {
            InitializeComponent();
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
                AddressAndPostcodeList.ItemsSource = WebAPIHandler.GetRelevantPropertyAddresses(e);                         
            }
        }

        async void SubmitReviewBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewSubmissionPage());
        }
    }
}

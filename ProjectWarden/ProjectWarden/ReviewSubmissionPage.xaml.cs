﻿using System;
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
		public ReviewSubmissionPage ()
		{
			InitializeComponent ();
            SadButton.Opacity = 0.8;
            SmileyButton.Opacity = 0.8;
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

        }

        private void SadBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}
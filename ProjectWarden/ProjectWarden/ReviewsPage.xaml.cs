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
	public partial class ReviewsPage : ContentPage
	{
        public AddressListing ReviewsAddressListing { get; set; }

        public ReviewsPage ()
		{
			InitializeComponent ();
		}
	}
}
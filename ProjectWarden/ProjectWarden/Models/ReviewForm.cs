using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace ProjectWarden.Models
{
    class ReviewForm
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityTown { get; set; }
        public string CountyRegionState { get; set; }
        public string Postcode { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public bool SadClicked { get; set; }
        public bool SmileyClicked { get; set; }

        public bool ValidUKPostcode()
        {
            var ukPostcodePattern = @"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY]))))\s?[0-9][A-Z-[CIKMOV]]{2})";
            var ukPostRegex = new Regex(ukPostcodePattern, RegexOptions.IgnoreCase);

            if (ukPostRegex.IsMatch(Postcode))
            {
                return true;
            }

            else return false;
        }

        public async void SendToDatabase()
        {
            string liked = SetLikedValue();

            var desinationUri = "https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review";

            var values = new Dictionary<string, string>
                {
                    { "addressLine1", AddressLine1 },
                    { "addressLine2", AddressLine2 },
                    { "cityTown", CityTown},
                    { "countyRegionState",  CountyRegionState},
                    { "postcode", Postcode},
                    { "reviewerName", Name},
                    { "liked",  liked}
                };

            var content = new FormUrlEncodedContent(values);

            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync(desinationUri, content);
                var responseString = await response.Content.ReadAsStringAsync();
            }
        }

        private string SetLikedValue()
        {
            string liked = string.Empty;

            if (SmileyClicked)
            {
                liked = "1";
            }

            else if (SadClicked)
            {
                liked = "0";
            }

            return liked;
        }
    }
}

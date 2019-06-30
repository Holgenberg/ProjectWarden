using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;
using Xamarin.Forms;

namespace ProjectWarden.Models
{
    class WebAPIHandler
    {
        public static async void SendToDatabase(ReviewForm reviewForm)
        {
            var destinationUri = new Uri("https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review/submitreview");

            var json = JsonConvert.SerializeObject(reviewForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PostAsync(destinationUri, content);
            }
        }

        public static IEnumerable GetRelevantPropertyAddresses(TextChangedEventArgs e)
        {
            var destinationUri = new Uri("https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review/getreviews");

            var searchQueryText = e.NewTextValue;

            var json = JsonConvert.SerializeObject(searchQueryText);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            throw new NotImplementedException();
        }
    }
}

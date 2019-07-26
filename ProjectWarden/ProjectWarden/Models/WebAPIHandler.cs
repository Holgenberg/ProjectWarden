using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Net;

namespace ProjectWarden.Models
{
    class WebAPIHandler
    {
        public static async void SendToDatabase(ReviewForm reviewForm)
        {
            var destinationUri = new Uri("https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review/submitreview");

            var json = JsonConvert.SerializeObject(reviewForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {                
                await httpClient.PostAsync(destinationUri, content);
            }
        }

        public static async Task<List<AddressListing>> GetRelevantAddressListingsAsync(TextChangedEventArgs e)
        {
            var addressListings = await Task.Run(() => GetRelevantAddressListings(e));
            return addressListings;
        }

        public static List<AddressListing> GetRelevantAddressListings(TextChangedEventArgs e)
        {
            var searchQuery = e.NewTextValue;

            HttpResponseMessage response = null;

            using (HttpClient httpClient = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                httpClient.BaseAddress = new Uri("https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review/");
                response = httpClient.GetAsync($"getreviews?searchquery={searchQuery}").Result;
            }

            var addressListingsJson = response.Content.ReadAsStringAsync().Result;
            var addressListings = JsonConvert.DeserializeObject<List<AddressListing>>(addressListingsJson);

            return addressListings;
        }
    }
}

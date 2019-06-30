using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;

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
    }
}

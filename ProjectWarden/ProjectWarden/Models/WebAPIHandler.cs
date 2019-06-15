﻿using System;
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
            var desinationUri = new Uri("https://projectwardendatabaseapi20190611073151.azurewebsites.net/api/review/submitreview");

            var json = JsonConvert.SerializeObject(reviewForm);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PostAsync(desinationUri, content);
            }

            if (response.IsSuccessStatusCode)
            {
                System.Diagnostics.Debug.WriteLine(@"\tTodoItem successfully saved.");
            }
        }
    }
}

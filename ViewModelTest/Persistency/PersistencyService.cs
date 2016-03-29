using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ViewModelTest.Model;

namespace ViewModelTest.Persistency
{
    internal class PersistencyService
    {
        public static async Task<List<Event>> LoadEvents()
        {
            const string serverUrl = "http://localhost:12345";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.GetAsync("api/events").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var events = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                        return events.ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;

            }
        }

        public static async void SaveEvent(Event myevent)
        {
            const string serverUrl = "http://localhost:12345";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsJsonAsync("api/events", myevent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        /*var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;*/
                    }

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static async void DeleteEvent(Event myevent)
        {
            const string serverUrl = "http://localhost:12345";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    await client.DeleteAsync("api/events/"+myevent.Id);
                    /*if (response.IsSuccessStatusCode)
                    {
                        var hotels = response.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;
                    }*/

                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public static async void UpdateEvent(Event myevent)
        {
            const string serverUrl = "http://localhost:12345";
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PutAsJsonAsync("api/events/"+myevent.Id,myevent).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var events = response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                    }

                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}


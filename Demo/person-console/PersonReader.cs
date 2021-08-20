using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace person_console
{
    public class PersonReader
    {
        HttpClient client = new();

        public PersonReader()
        {
            client.BaseAddress = new Uri("http://localhost:9874");
        }

        public async Task<List<Person>> GetAsync()
        {
            HttpResponseMessage response = await client.GetAsync("people");
            if (!response.IsSuccessStatusCode) return new List<Person>();

            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Person>>(stringResult);
        }        
    }
}
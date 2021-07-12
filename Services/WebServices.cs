using CRMGuru.TestTask.Interfaces.Models;
using CRMGuru.TestTaskWpf.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTask.WebApiClient
{
    public class WebServices : IWebServices
    {
        private readonly HttpClient _httpClient;

        public WebServices(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<Restcountries> GetAsync(string name, CancellationToken cancel = default)
        {
            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<Restcountries>(name, cancel).ConfigureAwait(false);
            }
            else
            {                     
                throw new Exception(await res.Content.ReadAsStringAsync());
            }          
        }

        public async Task<IEnumerable<Restcountries>> GetArrayAsync(string name, CancellationToken cancel = default)
        {
            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<Restcountries[]>(name, cancel).ConfigureAwait(false);
            }
            else
            {                              
                throw new Exception(await res.Content.ReadAsStringAsync());
            }         
        }
    }
}

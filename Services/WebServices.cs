using CRMGuru.TestTaskWpf.Models;
using CRMGuru.TestTaskWpf.Services.Interrfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CRMGuru.TestTaskWpf.Services
{
    public class WebServices : IWebService
    {
        private readonly HttpClient _httpClient;

        public WebServices(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<RestСountry> GetAsync(string name, CancellationToken cancel = default)
        {
            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<RestСountry>(name, cancel).ConfigureAwait(false);
            }
            else
            {                     
                throw new Exception(await res.Content.ReadAsStringAsync());
            }          
        }

        public async Task<IEnumerable<RestСountry>> GetArrayAsync(string name, CancellationToken cancel = default)
        {
            var res = await _httpClient.GetAsync(name, cancel).ConfigureAwait(false);
            
            if (res.IsSuccessStatusCode)
            {
                return await _httpClient.GetFromJsonAsync<RestСountry[]>(name, cancel).ConfigureAwait(false);
            }
            else
            {                              
                throw new Exception(await res.Content.ReadAsStringAsync());
            }         
        }
    }
}

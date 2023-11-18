using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FormulaApp.Api.Configuration;
using FormulaApp.Api.Models;
using FormulaApp.Api.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace FormulaApp.Api.Services
{
    public class FanService : IFanService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiServiceConfig _config;

        public FanService(HttpClient httpClient, IOptions<ApiServiceConfig> config)
        {
            _httpClient = httpClient;
            _config = config.Value;
        }
        
        public async Task<List<Fan>?> GetAllFans()
        {
            var response = await _httpClient.GetAsync(_config.Url);
            if(response.StatusCode == HttpStatusCode.NotFound)
                return new List<Fan>();

            if(response.StatusCode == HttpStatusCode.BadRequest)
                throw new Exception("Bad Request");
            
            var fans = await response.Content.ReadFromJsonAsync<List<Fan>>();
            return fans;
        }
    }
}
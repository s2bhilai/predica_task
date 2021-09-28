using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trip_Management_Api.Extensions;
using Trip_Management_Entities;
using Trip_Management_Entities.Entities;
using Trip_Management_Entities.Models;

namespace Trip_Management_Api
{
    public class CountryLayerDataSeeder
    {
        private TripContext _tripContext;
        private IHttpClientFactory _httpclientFactory;
        private IConfiguration _configuration;
        private IServiceProvider _serviceProvider;

        public CountryLayerDataSeeder(TripContext tripContext, 
            IHttpClientFactory httpClientFactory,IConfiguration configuration
            ,IServiceProvider serviceProvider)
        {
            _tripContext = tripContext;
            _httpclientFactory = httpClientFactory;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task<List<CountryLayer>> SeedCountryData()
        {
            List<CountryLayer> countryLayerDetails = 
                new List<CountryLayer>();

            var httpClient = _httpclientFactory.CreateClient("countryLayerApi");

            string accesskey = string.Format("access_key={0}",
               _configuration.GetSection("CountryLayer_API_Info:ApiKey").Value);

            var request = new HttpRequestMessage(HttpMethod.Get, $"/v2/all?{accesskey}");
            request.Headers.Accept.Add(new System.Net.Http.Headers
                .MediaTypeWithQualityHeaderValue("application/json"));

            using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                try
                {
                    countryLayerDetails = 
                        stream.ReadAndDeserializeFromJson<List<CountryLayer>>();
                }
                catch(Exception ex)
                {

                }

                return countryLayerDetails;
            }
        }
    }
}

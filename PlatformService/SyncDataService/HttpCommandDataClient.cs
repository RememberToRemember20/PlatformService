using PlatformService.ModelDTOs;
using System.Text;
using System.Text.Json;

namespace PlatformService.SyncDataService
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient http,IConfiguration configuration)
        {
            _http=http;
            _configuration=configuration;
        }
        public async Task SendPlatformToCommnad(PlatformReadDTO platform)
        {
            var httpcontent = new StringContent(JsonSerializer.Serialize(platform),Encoding.UTF8
                ,"application/json");
            var responce = await _http.PostAsync($"{_configuration["CommanedService"]}"
                , httpcontent);
            if(responce.IsSuccessStatusCode)
            {
                Console.WriteLine("--> sync post to commandservice was ok");
            }
            else
            {
                Console.WriteLine("--> sync post to commandservice was not ok");
            }
        }
    }
}

using Web.Models.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Web.Services.BattleNet
{
    public class BaseBattleNetProxy<T>
    {
        protected BattleNetOptions BattleNetOptions { get; set; }


        public BaseBattleNetProxy(IOptions<BattleNetOptions> battleNetOptions)
        {
            BattleNetOptions = battleNetOptions.Value;
        }

        protected async Task<T> Get(string apiPath)
        {
            var url = $"{BattleNetOptions.BaseApiUrl}wow/{apiPath}"
                     + $"?locale=en_US&apikey={BattleNetOptions.ClientId}";


            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            using (HttpWebResponse response = (await request.GetResponseAsync()) as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }

                var sr = new StreamReader(response.GetResponseStream());
                return JsonConvert.DeserializeObject<T>(await sr.ReadToEndAsync());
            }
        }
    }

    
}

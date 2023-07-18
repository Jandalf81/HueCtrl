using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace HueCtrl
{
    internal class HueBridge
    {
        private string IP;

        private HttpClient client;

        public HueBridge(string IP)
        {
            this.IP = IP;

            // ignore SSL validation errors
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
            client = new HttpClient(handler);

            client.BaseAddress = new Uri("https://" + this.IP + "/");
        }

        public async void getDevices(HueUser hueUser)
        {
            client.DefaultRequestHeaders.Add("hue-application-key", hueUser.getName());
            HttpResponseMessage response = await client.GetAsync("clip/v2/resource/device");

            if (response.IsSuccessStatusCode) 
            {
                JsonObject retjson = await response.Content.ReadFromJsonAsync<JsonObject>();
                Console.Out.Write(retjson.ToString());
            }
        }
    }
}

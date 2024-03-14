using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Encodings;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using App.Front.Examen.BusinessLogic.Services.Interfaces;
using Newtonsoft.Json.Serialization;

namespace App.Front.Examen.BusinessLogic.Services
{
    public class CallApiService : ICallApiService
    {
        private HttpClient _callCliente;
        private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings();
        public CallApiService(IHttpClientFactory callCliente)
        {
            _callCliente = callCliente.CreateClient("ApiExamen");
            _serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public async Task<T> Post<T>(string url, T data)
        {
            T list;
            string json = JsonConvert.SerializeObject(data, _serializerSettings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _callCliente.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var objresult = JsonConvert.DeserializeObject<T>(result);
                return objresult;
            }
            return default;
        }

    }
}

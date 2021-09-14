using Entidades.Dominio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Empresas.Servicio
{
    public class ConsumirApi
    {
   
        public Task<IEnumerable<T>> ConsumirServicioGET<T>(int id)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:44382/") };

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(string.Format("/ObtenerEmpleados/{0}", id)).Result;

            if (response.IsSuccessStatusCode)
            {
                var datosEmpleados = response.Content.ReadAsStringAsync();
                 return JsonConvert.DeserializeObject<Task<IEnumerable<T>>>(datosEmpleados.Result);
            }
            else
            {
                return default;
            }
        }
    }
}

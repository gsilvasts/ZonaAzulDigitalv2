using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ZonaAzulDigital.Core.Models;
using Newtonsoft.Json;

namespace ZonaAzulDigital.Core.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Cliente>> GetClienteAsync()
        {
            try
            {
                string url = "http://zonaazuldigitalwebapi.azurewebsites.net/";
                var response = await client.GetStringAsync(url);
                var cliente = JsonConvert.DeserializeObject<List<Cliente>>(response);
                return cliente;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task AddClienteAsync(Cliente cliente)
        {
            try
            {
                string url = "http://zonaazuldigitalwebapi.azurewebsites.net/";

                var uri = new Uri(string.Format(url, cliente.Cd_Cliente));

                var data = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir cliente");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            string url = "http://zonaazuldigitalwebapi.azurewebsites.net/";
            var uri = new Uri(string.Format(url, cliente.Cd_Cliente));

            var data = JsonConvert.SerializeObject(cliente);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar cliente");

            }
        }

        public async Task DeletaClienteAsync(Cliente cliente)
        {
            string url = "http://zonaazuldigitalwebapi.azurewebsites.net/";
            var uri = new Uri(string.Format(url, cliente.Cd_Cliente));
            await client.DeleteAsync(uri);
        }
    }
}

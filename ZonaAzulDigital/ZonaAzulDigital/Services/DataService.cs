﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ZonaAzulDigital.Core.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ZonaAzulDigital.Core.Services
{
    public class DataService
    {
        HttpClient client = new HttpClient();
        private string url;
        public string Url { get => url; set => url = value; }

        public DataService()
        {
            Url = "http://zonaazuldigitalwebapi.azurewebsites.net/api/";
        }

        public string TablePath(string table)
        {
            return (Url + table + '/');
        }

        public async Task<List<Cliente>> GetClienteAsync()
        {
            try
            {
                var response = await client.GetStringAsync(TablePath("cliente"));
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
                var uri = new Uri(string.Format(TablePath("cliente"), cliente.CPF));

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
            var uri = new Uri(string.Format(TablePath("cliente"), cliente.CPF));

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
            var uri = new Uri(string.Format(TablePath("cliente"), cliente.CPF));
            await client.DeleteAsync(uri);
        }

        public async Task<Response> LoginAsync(string txtCPF, string txtSenha)
        {   

            try
            {
                var loginRequest = new LoginRequest
                {
                    CPF = txtCPF,
                    Senha = txtSenha,

                };

                var request = JsonConvert.SerializeObject(loginRequest);
                var content = new StringContent(request, Encoding.UTF8, "application/Json");
                var client = new HttpClient();

                client.BaseAddress = new Uri("http://zonaazuldigitalwebapi.azurewebsites.net/");
                var url = "/api/cliente/";
                var response = await client.PostAsync(url, content);

                var result = await response.Content.ReadAsStringAsync();
                var cliente = JsonConvert.DeserializeObject<Cliente>(result);

                return new Response
                {
                    IsSuccess = true,
                    Message = "Login Ok",
                    Result = cliente,
                };
                
            }

            catch(Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

            //var keyValues = new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("CPF", txtCPF),
            //    new KeyValuePair<string, string>("Senha", txtSenha)
            //};

            //var request = new HttpRequestMessage(
            //    HttpMethod.Post, "http://zonaazuldigitalwebapi.azurewebsites.net/api/cliente/");

            //request.Content = new FormUrlEncodedContent(keyValues);

            //var client = new HttpClient();
            //var response = await client.SendAsync(request);

            //var content = await response.Content.ReadAsStringAsync();

            //Debug.WriteLine(content);
        }
    }
}

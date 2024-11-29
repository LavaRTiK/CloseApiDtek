﻿using Svitlo.ObjectModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Svitlo.Component
{
    public class DataLoderAPI
    {
        private HttpClient client = new HttpClient();
        //private object lockObject = new object();
        public async Task<List<City>> SearchCityAsync(string data)
        {
            try
            {
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_city?q={data}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                #if DEBUG
                MessageBox.Show("запрос SearchCityAsync");
                #endif
                return content;
            }
            catch(Exception ex)
            {
                #if DEBUG
                MessageBox.Show("Виникла помилка \n" + ex.Message);
                #endif
            }
            return null;
        }
        public async Task<List<City>> SearchStreetAsync(int idCity, string data)
        {
            try
            {
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_street/{idCity}?q={data}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                #if DEBUG
                MessageBox.Show("запрос SeatchStreetAsync");
                #endif
                return content;
            }
            catch (Exception ex)
            {
                #if DEBUG
                MessageBox.Show("Помилка спробуте знову статус помилки \n" + ex.Message);
                #endif
            }
            return null;
        }
        public async Task<List<City>> SearchHouseAsync(int idStreet,string data)
        {
            try
            {
                using HttpResponseMessage reponse = await client.GetAsync(@$"https://www.voe.com.ua/disconnection/detailed/autocomplete/read_house/{idStreet}?q={data}");
                reponse.EnsureSuccessStatusCode();
                var content = await reponse.Content.ReadFromJsonAsync<List<City>>();
                #if DEBUG
                MessageBox.Show("запрос SearchHouseAsync");
                #endif
                return content;
            }
            catch(Exception ex)
            {
                #if DEBUG
                MessageBox.Show("Помилка спробуйте знову статус помилки \n" + ex.Message);
                #endif
            }
            return null;
        }
    }
}
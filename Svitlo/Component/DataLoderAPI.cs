using Svitlo.ObjectModels;
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
        public async Task<List<Test>> DisconnectDataAsync(string readCity,int idCity,string readStreet,int idStreet,string readHouse,int idHouse)
        {
            var values = new Dictionary<string, string>
            {
                { "ajax_form", "1" },
                { "_wrapper_format", "drupal_ajax" },
                { "city", $"{readCity}" },
                { "city_id", $"{idCity}" },
                { "street", $"{readStreet}" },
                { "street_id", $"{idStreet}" },
                { "house", $"{readHouse}" },
                { "house_id", $"{idHouse}" },
                { "form_build_id", "form-EFDfea_so3Y5mQ-JvwI3zwkyv-5zihfkWDo38QPy3is" },
                { "form_id", "disconnection_detailed_search_form" },
                { "_triggering_element_name", "op" },
                { "_triggering_element_value", "Show" },
                { "_drupal_ajax", "1" },
                { "ajax_page_state[theme]", "personal" },
                { "ajax_page_state[theme_token]", "" },
                { "ajax_page_state[libraries]", "ajax_forms/main,classy/base,classy/messages,core/drupal.autocomplete,core/internal.jquery.form,core/normalize,custom/custom,drupal_noty_messages/drupal_noty_messages,extlink/drupal.extlink,filter/caption,paragraphs/drupal.paragraphs.unpublished,personal/global-styling,personal/sticky,personal/toggle_info,personal/type_navigation_unit,poll/drupal.poll-links,search_block/search_block.styles,styling_form_errors/styling_form_errors,system/base" }
            };

            var data = new FormUrlEncodedContent(values);
            HttpClient client = new HttpClient();
            using HttpResponseMessage reponse = await client.PostAsync($@"https://www.voe.com.ua/disconnection/detailed?ajax_form=1&_wrapper_format=drupal_ajax&_wrapper_format=drupal_ajax", data);
            reponse.EnsureSuccessStatusCode();
            var content = await reponse.Content.ReadFromJsonAsync<List<Test>>();
        }
    }
}

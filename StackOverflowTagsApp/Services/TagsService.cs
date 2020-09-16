using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using StackOverflowTagsApp.Interfaces;
using StackOverflowTagsApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflowTagsApp.Services
{
    public class TagsService : ITagsFromSite
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TagsService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public TagsListModel DeserializeJSON(string JSONresult)
        {
            var tags = JsonConvert.DeserializeObject<TagsListModel>(JSONresult);
            return tags;
        }

        public async Task<string> GetTagsJSON(int page)
        {
            try
            {
                //GET Method
                var _httpClient = _httpClientFactory.CreateClient("myTagServiceClient");
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(_httpClient.BaseAddress + "tags?page="+ page + "&pagesize=100&order=desc&sort=popular&site=stackoverflow");
                if (responseMessage.IsSuccessStatusCode)
                {
                    string response = await responseMessage.Content.ReadAsStringAsync();
                    return response;
                }

            }
            catch(Exception ex)
            {
                return "Something was wrong...:" + ex;
            }

            return null;
        }

        public List<TagModel> CheckShare(List<TagModel> tagsList)
        {
            int count = 0;
            foreach (var tag in tagsList)
            {
                count += tag.count;
            }
            foreach (var tag in tagsList)
            {
                tag.share = (Convert.ToDecimal(tag.count) / count * 100);
            }

            return tagsList;
        }

        public List<TagModel> GetTagsTOP()
        {
            List<TagModel> tagsList = new List<TagModel>();
            for (int page = 1; page < 11; page++)
            {
                var JSONresult = GetTagsJSON(page).Result;
                var tags = DeserializeJSON(JSONresult);
                tagsList.AddRange(tags.tagsModel);
                if(tags.tagsModel.Count < 100 || page == 10)
                {
                    var result = CheckShare(tagsList);
                    return result;
                }
            }
            return null;
        }
    }
}

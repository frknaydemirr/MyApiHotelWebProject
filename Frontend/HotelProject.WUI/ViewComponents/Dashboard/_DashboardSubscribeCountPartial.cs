using HotelProject.WUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HotelProject.WUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
      
        public async Task<IViewComponentResult> InvokeAsync()
        {

           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/murattycedag"),
                Headers =
    {
        { "x-rapidapi-key", "a36c6ee4cfmshc9269ffa9c21abfp187d19jsnaed6b4df9064" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
             ResultInstagramFollowersDto   resultInstagramFollowersDtos = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.v1= resultInstagramFollowersDtos.followers;
                ViewBag.v1 = resultInstagramFollowersDtos.following;

            }


    //        var client2 = new HttpClient();
    //        var request2 = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://twitter32.p.rapidapi.com/profile?username=murattyucedag"),
    //            Headers =
    //{
    //    { "x-rapidapi-key", "a36c6ee4cfmshc9269ffa9c21abfp187d19jsnaed6b4df9064" },
    //    { "x-rapidapi-host", "twitter32.p.rapidapi.com" },
    //},
    //        };
    //        using (var response2 = await client2.SendAsync(request))
    //        {
    //            response2.EnsureSuccessStatusCode();
    //            var body2 = await response2.Content.ReadAsStringAsync();
                
    //        }

            return View();
        }
    }
}

using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    public class GetSchoolUserInfo
    {
        public static async Task<SchoolUserInfo> GetInfo(string token)
        {
            var options = new RestClientOptions("https://gateway.ewt360.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 Edg/114.0.1823.82",
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/eteacherproduct/school/getSchoolUserInfo", Method.Get);
            request.AddHeader("authority", "gateway.ewt360.com");
            request.AddHeader("accept", "application/json, text/plain, */*");
            request.AddHeader("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.AddHeader("access-control-allow-origin", "*");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "text/plain");
            request.AddHeader("origin", "https://teacher.ewt360.com");
            request.AddHeader("pragma", "no-cache");
            request.AddHeader("referer", "https://teacher.ewt360.com/");
            request.AddHeader("referurl", "https://teacher.ewt360.com/ewtbend/bend/index/index.html^#/holiday/student/home?sceneId=104&grade=0");
            request.AddHeader("sec-ch-ua", "\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"114\", \"Microsoft Edge\";v=\"114\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-site");
            request.AddHeader("token", token);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return JsonConvert.DeserializeObject<SchoolUserInfo>(response.Content);
        }
    }
}

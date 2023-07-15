using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AnotherEWT.Tools
{
    public class JsonInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string latest_version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string more_info { get; set; }

    }

    public class JsonInfoWrapper
    {
        public bool exception { get; set; }
        public string error_message { get; set; }

        public JsonInfo Info { get; set; }
    }

    public class InfoChecker
    {
        private string infoURL = "https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json";

        public string InfoURL { get => infoURL;}

        public async Task<JsonInfoWrapper> Check()
        {
            JsonInfoWrapper wrapper = new JsonInfoWrapper();
            try
            {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(infoURL);
                if (response != null)
                {
                    JsonInfo info = JsonSerializer.Deserialize<JsonInfo> (response);
                    wrapper.Info = info;
                }
            }
            catch (Exception ex)
            {
                wrapper.exception = true;
                wrapper.error_message = ex.Message;
            }
            return wrapper;
        }
    }
}

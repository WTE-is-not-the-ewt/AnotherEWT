using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Text.Json;
using AnotherEWT.Pages;
using AnotherEWT.Tools;
using CommunityToolkit.Maui.Core.Views;
using System.Net;
using Newtonsoft.Json;

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
        private string infoURL = Configs.current.infoGetUrl;

        public string InfoURL { get => infoURL; }

        public async Task<JsonInfoWrapper> Check()
        {
            JsonInfoWrapper wrapper = new JsonInfoWrapper();
            try
            {
                HttpClient client = new HttpClient();
                string response = await client.GetStringAsync(infoURL);
                if (response != null)
                {
                    JsonInfo info = JsonConvert.DeserializeObject<JsonInfo>(response);
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

    public static class VersionChecker
    {
        public static async void CheckAppVersion(Page page)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = "";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;


            InfoChecker checker = new InfoChecker();
            JsonInfoWrapper wrapper = await checker.Check();
            if (wrapper != null)
            {
                if (wrapper.exception)
                {
                    await page.DisplayAlert("错误", "出现了一些错误。无法检查版本文件，这可能是网络问题。你可以前往设置更改版本文件地址。", "确定");
                }
                else if (wrapper.Info.latest_version != AppInfo.Current.VersionString)
                {
                    text += "有更新版本的应用程序\r\n";
                }
                else
                {
                    switch (wrapper.Info.condition)
                    {
                        case "Success":
                            text += "Another EWT的API访问暂无已知问题。" + $"版本{wrapper.Info.latest_version},API访问可用性:{wrapper.Info.more_info}";
                            break;
                        case "Warning":
                            text += "Another EWT的API访问存在已知缺陷。" + $"版本{wrapper.Info.latest_version},{wrapper.Info.more_info}";
                            break;
                        case "Error":
                            text += "Another EWT的API访问有致命问题。" + $"版本{wrapper.Info.latest_version},{wrapper.Info.more_info}。由于API存在的问题，建议不要再使用本程序";
                            break;
                        case "Void":
                            text += "你使用的版本应用程序已被移除" + "由于某些不可抗拒力因素，我们选择关闭此应用。再见！(你可以重新自行部署)";
                            var _toast = Toast.Make(text, duration, fontSize);

                            await _toast.Show(cancellationTokenSource.Token);
                            App.Current.Quit();
                            break;
                        default:
                            break;
                    }
                }
            }
            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
            Configs.current.LastCheckedTime = DateTime.Now;

        }
    }
}

using RestSharp;

namespace AnotherEWT.Pages;

public partial class UserInfo : ContentPage
{
    string c;
	public UserInfo(string usercookie)
	{
		InitializeComponent();
        c = usercookie;
	}

	private async Task<string> GetInfo(string token)
	{
        var options = new RestClientOptions("https://gateway.ewt360.com")
        {
            MaxTimeout = -1,
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36 Edg/114.0.1823.82",
        };
        var client = new RestClient(options);
        var request = new RestRequest("/api/usercenter/user/login/getUser?platform=1", Method.Get);
        request.AddHeader("authority", "gateway.ewt360.com");
        request.AddHeader("accept", "application/json");
        request.AddHeader("accept-language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
        request.AddHeader("cache-control", "no-cache");
        request.AddHeader("content-type", "application/json;charset=UTF-8");
        request.AddHeader("origin", "https://www.ewt360.com");
        request.AddHeader("platform", "1");
        request.AddHeader("pragma", "no-cache");
        request.AddHeader("referer", "https://www.ewt360.com/");
        request.AddHeader("sec-ch-ua", "\"Not.A/Brand\";v=\"8\", \"Chromium\";v=\"114\", \"Microsoft Edge\";v=\"114\"");
        request.AddHeader("sec-ch-ua-mobile", "?0");
        request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
        request.AddHeader("sec-fetch-dest", "empty");
        request.AddHeader("sec-fetch-mode", "cors");
        request.AddHeader("sec-fetch-site", "same-site");
        request.AddHeader("secretid", "2");
        request.AddHeader("timestamp", DateTime.Now.ToUniversalTime().Subtract(new DateTime(1970, 1, 1)).TotalMicroseconds.ToString("F0"));
        request.AddHeader("token", token);
        RestResponse response = await client.ExecuteAsync(request);
        return response.Content;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string[] cookies = c.Split(';');
        string token;
        Dictionary<string, string> cookietable = new Dictionary<string, string>();
        foreach (string cookie in cookies)
        {
            string[] sin = cookie.Split("=");
            cookietable[sin[0]] = sin[1];
        }
        token = cookietable[" token"];
        DataText.Text = await GetInfo(token);
        
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
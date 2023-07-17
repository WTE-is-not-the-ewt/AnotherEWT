using System.Net;
using AnotherEWT.Tools;
using CommunityToolkit.Maui.Alerts;

namespace AnotherEWT.Pages;

public partial class LoginPage : ContentPage
{
    public string usercookie { get; set; } = "";
	public LoginPage()
	{
		InitializeComponent();
        webpage.Source = "http://www.ewt360.com/";
        webpage.Reload();
    }

    private void webpage_Navigated(object sender, WebNavigatedEventArgs e)
    {
        webpage.Eval("document.getElementById(\"header\").style.display=\"none\";" +
            "document.getElementById(\"net_box\").style.display=\"none\";" +
            "document.getElementById(\"siteFloor\").style.display=\"none\";" +
            "document.getElementsByClassName(\"W1000 clearfix\")[0].style.display=\"none\";" +
            "document.getElementsByClassName(\"pushFooter\")[0].style.display=\"none\";" +
            "document.getElementsByClassName(\"ewt-common-footer-wrapper\")[0].style.display=\"none\";" +
            "document.getElementsByClassName(\"login fr\")[0].style.float = \"left\";" +
            "document.getElementsByClassName(\"banner mrgB30\")[0].removeAttribute(\"class\");" +
            "document.getElementsByClassName(\"flex1 text-right\")[0].children[0].text = \"Ç§Íò²»Òª¹ºÂò\";" +
            "document.getElementsByClassName(\"flex1 text-right\")[0].children[0].href = \"http://cyberpolice.mps.gov.cn/wfjb/\";" +
            "document.getElementsByClassName(\"login__qrcode_des animate__animated animate__bounce\")[0].textContent = \"É¨ÂëµÇÂ¼\";");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        webpage.Reload();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        webpage_Navigated(null, null);
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        Configs.current.savedCookie = await webpage.EvaluateJavaScriptAsync("document.cookie");
        Configs.current.LastCookieRefreshTime = DateTime.Now;
        await Navigation.PopAsync();
    }
}
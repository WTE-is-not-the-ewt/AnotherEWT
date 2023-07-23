using AnotherEWT.Pages;
using AnotherEWT.Tools;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using System.Net;

namespace AnotherEWT;

public partial class MainPage : ContentPage
{
    LoginPage loginPage = new();

    public MainPage()
    {
        InitializeComponent();
    }

    private async void ContentPage_Loaded(object sender, EventArgs e)
    {
        if (ConfigReader.FirstStartup())
        {
            bool result = await DisplayAlert("第一次使用Another EWT", "Another EWT是一个第三方EWT客户端，大量精简了EWT的功能与界面，旨在为用户提供更好的听课体验。你需要同意我们的用户协议(见Github)，并且登录你的EWT账户。", "同意协议并登录", "不同意并退出");
            if (result)
                await Navigation.PushAsync(loginPage);
            else
                App.Current.Quit();
        }
        if (Configs.current.savedCookie != null)
        {
            FullUserData userData = await UserInfoGetter.GetInfo(TokenGetter.GetToken(Configs.current.savedCookie));
            if (userData != null)
            {
                if (userData.success)
                {
                    UserName.Text = userData.data.realName;
                    UserId.Text = userData.data.userId;
                }
                else
                {
                    UserName.Text = "获取用户名失败";
                    UserId.Text = "你可以在设置里试着刷新cookie或重新登录";
                    GoToLessons.IsEnabled = false;
                }
            }
        }
        if (Configs.current.ShouldCheckVersion())
            VersionChecker.CheckAppVersion(this);
        if (Configs.current.ShouldRefreshCookie())
        {
            bool result = await DisplayAlert("设置的Cookie刷新时间已到", $"你的cookie已经存在超过{Configs.current.CookieRefreshTime}，需要刷新", "前往刷新", "取消");
            if (result)
                await Navigation.PushAsync(loginPage);
        }

    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (!(Configs.current is null))
        {
            FullUserData userData = await UserInfoGetter.GetInfo(TokenGetter.GetToken(Configs.current.savedCookie));
            if (userData != null)
            {
                if (userData.success)
                {
                    UserName.Text = userData.data.realName;
                    UserId.Text = userData.data.userId;
                }
                else
                {
                    UserName.Text = "获取用户名失败";
                    UserId.Text = "你可以在设置里试着刷新cookie或重新登录";
                    GoToLessons.IsEnabled = false;
                }
            }
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage());
    }
}


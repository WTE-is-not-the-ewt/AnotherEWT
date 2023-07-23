using AnotherEWT.Tools;

namespace AnotherEWT.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
        
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        switch (((RadioButton)sender).Content.ToString())
        {
            case "Github":
                Configs.current.infoGetUrl = "https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json";
                break;
            case "Github Proxy":
                Configs.current.infoGetUrl = "https://ghproxy.com/https://raw.githubusercontent.com/WTE-is-not-the-ewt/AnotherEWT/master/Update/Info.json";
                break;
        }
    }

    private void VersionCheckButton_Clicked(object sender, EventArgs e)
    {
        VersionChecker.CheckAppVersion(this);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Launcher.OpenAsync("https://github.com/WTE-is-not-the-ewt/AnotherEWT");

    }
}
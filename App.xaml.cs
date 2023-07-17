using AnotherEWT.Tools;

namespace AnotherEWT;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
	protected override Window CreateWindow(IActivationState activationState)
	{
		Window window = base.CreateWindow(activationState);
		window.Created += (s, e) =>
		{
			ConfigReader configReader = new ConfigReader();
			configReader.InitConfigs();
		};
		window.Destroying += (s, e) =>
		{
			ConfigSaver configSaver = new ConfigSaver();
			configSaver.SaveConfig();
		};
		return window;
	}

}

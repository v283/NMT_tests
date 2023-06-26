using NMT_tests.Data;
namespace NMT_tests.Pages;

public partial class SettingsPage : ContentPage
{

	public SettingsPage()
	{
		InitializeComponent();
		myFontSizeLabel.Text = "����� ������ " + Settings.MainFontSize;
		myFontSizeLabel.FontSize = Settings.MainFontSize;

        fontStepper.Value = Settings.MainFontSize;
		reloadallBtn.Clicked += OnReload;
	}

    private async void OnReload(object sender, EventArgs args)
    {
        bool answer = await DisplayAlert("�� ����� ������ �������� ���?", "�� ���� ��� ������ �������.", "ϳ���������", "���������");
		if (answer)
		{
            DbProvider.FirstRunDb();
			AboutPage.reloadAboutPage();
			TimeAccountant.UserTime = 0;
        }
    }

	private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
	{
		Settings.MainFontSize = (int)e.NewValue;
        myFontSizeLabel.Text = "����� ������ " + Settings.MainFontSize;
        myFontSizeLabel.FontSize = Settings.MainFontSize;
		DbProvider.SetProjectSettings((int)Settings.MainFontSize);
    }



}
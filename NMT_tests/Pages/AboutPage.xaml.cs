using NMT_tests.Data;

namespace NMT_tests.Pages;

public partial class AboutPage : ContentPage
{
    public static ReloadAboutPage reloadAboutPage;
	public AboutPage()
	{
		InitializeComponent();
		rulesBtn.Clicked += async (s, e) => Shell.Current.GoToAsync("rulespage");
		settingsBtn.Clicked += async (s, e) => Shell.Current.GoToAsync("settingspage");
        instagramBtn.Clicked += InstagranBrowserOpen_Clicked;
        telegramBtn.Clicked += TelegramBrowserOpen_Clicked;
        viberBtn.Clicked += ViberBrowserOpen_Clicked;
        reloadAboutPage += SetDayBoxVies;
        reloadAboutPage += SetSubjectsBar;
        reloadAboutPage();

    }

    private void SetSubjectsBar()
    {
        int ukrCount = 0;
        int mathCount = 0;
        int histCount = 0;
        //int engCount = 0;

        int ukrIsDoneCount = 0;
        int mathIsDoneCount = 0;
        int histIsDoneCount = 0;
        //int engIsDoneCount = 0;
        //List<SubjectsStatisticsModel> subjects = DbProvider.GetSubjectsStatistics();
        foreach (var item in DbProvider.GetTopicsListFromDbTable("UkrTopics"))
        {
            if (!item.Topic.Contains('h'))
            {
                ukrCount += 1;
            }
            if (item.IsDone == "True")
            {
                ukrIsDoneCount += 1;
            }
        }

        foreach (var item in DbProvider.GetTopicsListFromDbTable("MathTopics"))
        {
            if (!item.Topic.Contains('h'))
            {
                mathCount += 1;
            }
            if (item.IsDone == "True")
            {
                mathIsDoneCount += 1;
            }
        }

        foreach (var item in DbProvider.GetTopicsListFromDbTable("HistTopics"))
        {
            if (!item.Topic.Contains('h'))
            {
                histCount += 1;
            }
            if (item.IsDone == "True")
            {
                histIsDoneCount += 1;
            }
        }

        //foreach (var item in DbProvider.GetTopicsListFromDbTable("EnglishTopics"))
        //{
        //    if (!item.Topic.Contains('h'))
        //    {
        //        engCount += 1;
        //    }
        //if (item.IsDone == "True")
        //{
        //    ingIsDoneCount += 1;
        //}
        //}

        ukrBar.WidthRequest = ukrBar.MaximumWidthRequest / ukrCount* ukrIsDoneCount;
        mathBar.WidthRequest = mathBar.MaximumWidthRequest / mathCount * mathIsDoneCount;
        histBar.WidthRequest = histBar.MaximumWidthRequest / histCount * histIsDoneCount;
        //engBar.WidthRequest = engBar.MaximumWidthRequest;

        ukrBarNumber.Text = $"{ukrIsDoneCount}/{ukrCount}";
        mathBarNumber.Text = $"{mathIsDoneCount}/{mathCount}";
        histBarNumber.Text = $"{histIsDoneCount}/{histCount}";
        //engBarNumber.Text = $"{engIsDoneCount}/{engCount}";
    }

    private void SetDayBoxVies()
    {
        AboutPageDataHelper.SetWeek();

        double h = 0;
        Color c = new Color();
        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Monday, out c, out h);
        monday.HeightRequest = h;
        monday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Tuesday, out c, out h);
        tuesday.HeightRequest = h;
        tuesday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Wednesday, out c, out h);
        wednesday.HeightRequest = h;
        wednesday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Thursday, out c, out h);
        thursday.HeightRequest = h;
        thursday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Friday, out c, out h);
        friday.HeightRequest = h;
        friday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Saturday, out c, out h);
        saturday.HeightRequest = h;
        saturday.Color = c;

        AboutPageDataHelper.FindOutColorAndHeigh(AboutPageDataHelper.MyWeek.Sunday, out c, out h);
        sunday.HeightRequest = h;
        sunday.Color = c;

    }

    private async void InstagranBrowserOpen_Clicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri("https://www.instagram.com/gandribidav/");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            
        }
    }

    private async void TelegramBrowserOpen_Clicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri("https://t.me/VVG15");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {

        }
    }

    private async void ViberBrowserOpen_Clicked(object sender, EventArgs e)
    {
        try
        {
            Uri uri = new Uri("");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {

        }
    }
    
}
public delegate void ReloadAboutPage();
using NMT_tests.Data;
using NMT_tests.Pages;
namespace NMT_tests;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("subjecttopics", typeof(SubjectTopicsPage));
		Routing.RegisterRoute("taskpage", typeof(TaskPage));
		Routing.RegisterRoute("settingspage", typeof(SettingsPage));
        Routing.RegisterRoute("rulespage", typeof(RulesPage));

       

        MessagingCenter.Subscribe<SubjectTopicsPage>(this, "tapped", (sender) =>
        {
			Shell.Current.CurrentItem = btnTaskPage;				
        });

        MessagingCenter.Subscribe<LikePage>(this, "tapped", (sender) =>
        {
            Shell.Current.CurrentItem = btnTaskPage;
        });
        
    }




}

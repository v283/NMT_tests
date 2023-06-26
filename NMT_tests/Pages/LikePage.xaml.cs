using NMT_tests.Data;
using System.Text.Json;

namespace NMT_tests.Pages;


public partial class LikePage : ContentPage
{
	private static List<SavedModel> savedmodels;
	private static UpdateUI updateLikePage;
    public static List<SavedModel> savedModels
	{
		get => savedmodels;
		set
		{
			savedmodels = value;
			if (updateLikePage != null)
			{
                updateLikePage();
            }						
		}
		
	}

	public LikePage()
	{
		InitializeComponent();
		likeListView.ItemsSource = DbProvider.GetSavedTests();
        likeListView.ItemTapped += OnTestTapped;
		updateLikePage += OnUpdateUI;
	}

    private void OnTestTapped(object sender, ItemTappedEventArgs args)
	{
		var saved = args.Item as SavedModel;

        MessagingCenter.Send<LikePage>(this, "tapped");
        TaskPageViewModel.IsLoadSaved = true;
        TaskPageViewModel.SavedId = saved.Id;
        var selectedAnswerGrid = JsonSerializer.Deserialize<Dictionary<int, Dictionary<int, string[]>>>(saved.UserAnswers);
        TaskPageViewModel.selectedAnswerGrid = selectedAnswerGrid;

        TaskPageViewModel.TableName = saved.RefTable;

    }

    private void OnUpdateUI()
	{
		likeListView.ItemsSource = savedmodels;
	}

}
public delegate void UpdateUI();
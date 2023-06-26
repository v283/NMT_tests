using NMT_tests.Data;
using System.Linq;
using NMT_tests;

namespace NMT_tests.Pages;

[QueryProperty(nameof(SubjectName), "subjectName")]
public partial class SubjectTopicsPage : ContentPage
{
    string subjectName;
    public string SubjectName
    {
        get => subjectName;
        set
        {
            subjectName = value;
            UpdateSubjectTopicsUI(subjectName);
        }
    }

    private Label changeColorLabel = new Label();
    private Color prevColor = Color.FromRgb(0, 0, 0);

    public SubjectTopicsPage()
	{
		InitializeComponent();
        
	}

    void UpdateSubjectTopicsUI(string subject)
    {
        List<TopicModel> body = FindSubjectTopicsData(subject); 

        foreach(var b in body)
        {
            Color color = Color.FromRgb(0, 0, 0);
            if (b.IsDone=="True")
            {
                color = Pages.PagesColors.myGreenColor;
            }
            if (b.Topic.Contains('h'))
            {
                Label header = new Label() {FontAttributes = FontAttributes.Bold, TextDecorations = TextDecorations.None , Text = b.Topic.Trim('h'), Padding = 3 , FontSize = Settings.MainFontSize + 3};
                SbjectTopicsStack.Add(header);
                
            }
            else
            {
                Label topic = new Label()
                {
                    Text = b.Topic,
                    TextColor = color,
                    FontSize = Settings.MainFontSize
                    
                };
                topic.GestureRecognizers.Add(CreateGestureTap(b.Reference));

                SbjectTopicsStack.Add(topic);
            }            
            
        }
    }
    

    //this you should use to send data to TaskPage
    private TapGestureRecognizer CreateGestureTap(string dataFileName)
    {

        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
        tapGestureRecognizer.Tapped += (s, e) =>
        {
            //create color library
            changeColorLabel.TextColor = prevColor;
            changeColorLabel = s as Label;
            prevColor = changeColorLabel.TextColor;
                        
            MessagingCenter.Send<SubjectTopicsPage>(this, "tapped");
            TaskPageViewModel.IsLoadSaved = false;
            TaskPageViewModel.TableName = dataFileName;
            

            changeColorLabel.TextColor = Color.FromRgb(255, 191, 0);
        };
        return tapGestureRecognizer;
    }

    private List<TopicModel> FindSubjectTopicsData(string subjectName)
    {
        SubjectsTopicsData.LoadSubjectsTopicsData();
        return subjectName switch
        {
            "Ukr" => SubjectsTopicsData.Ukr,
            "Math" => SubjectsTopicsData.Math,
            "History" => SubjectsTopicsData.History,
            "NMT" => SubjectsTopicsData.NMT,
            _ => throw new ArgumentException()
        };
    }
}
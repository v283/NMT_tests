using NMT_tests.Data;
using System.Text.Json;
using static NMT_tests.Pages.ViewHelper;
using static NMT_tests.Pages.PagesColors;
namespace NMT_tests.Pages;

public partial class TaskPage : ContentPage
{
    Button[] btnAnswerGrid;
    public static TaskPageViewModel taskPageView;

    public TaskPage()
	{
        InitializeComponent();
        btnAnswerGrid = new Button[] { chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1, chbtnA2, chbtnB2, chbtnC2 , chbtnD2, chbtnE2, chbtnA3, chbtnB3,chbtnC3, chbtnD3,
             chbtnE3, chbtnA4, chbtnB4, chbtnC4,chbtnD4,  chbtnE4, chbtnA5, chbtnB5, chbtnC5, chbtnD5, chbtnE5 };
        AnswerButton.Clicked += OnPressAnswerButton;
        CommentButton.Clicked += OnPressCommentButton;
        MissButton.Clicked += OnPressMissButton;
        FinishButton.Clicked += OnPressFinishButton;
        markAsDoneButton.Clicked += OnPressMarkAsDoneButton;
        markAsNotDoneButton.Clicked += OnPressMarkAsNotDoneButton;
        saveButton.Clicked += OnPressSaveButton;
        deleteButton.Clicked += OnPressDeleteButton;

        Settings.changeFont += ChangeFot;

        LoadPageData();
	}
    private void ChangeFot()
    {
        YourResult.FontSize = Settings.MainFontSize + 5;
        topicLabel.FontSize = Settings.MainFontSize + 1;
        takenMark.FontSize = Settings.MainFontSize + 1;
        maxMark.FontSize = Settings.MainFontSize + 1;
        rightPrcent.FontSize = Settings.MainFontSize + 1;
        totalScore.FontSize = Settings.MainFontSize + 1;
        userScore.FontSize = Settings.MainFontSize + 1;
        correctPerCent.FontSize = Settings.MainFontSize + 1;
        Counter.FontSize = Settings.MainFontSize + 2;
        TaskText.FontSize = Settings.MainFontSize +1;
        (l1.FontSize, l2.FontSize, l3.FontSize, l4.FontSize, l5.FontSize, l6.FontSize, l7.FontSize, l8.FontSize) = (Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize);
        (a1.FontSize, a2.FontSize, a3.FontSize, a4.FontSize, a5.FontSize, a6.FontSize, a7.FontSize, a8.FontSize) = (Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize);

        (lA.FontSize, lB.FontSize, lC.FontSize,lD.FontSize, lE.FontSize) = (Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize);
        (A.FontSize, B.FontSize, C.FontSize, D.FontSize, E.FontSize) = (Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize, Settings.MainFontSize);
        CommentLabel.FontSize = Settings.MainFontSize - 3;
        ent1.FontSize = Settings.MainFontSize - 1;
        ent2.FontSize = Settings.MainFontSize - 1;
        ent3.FontSize = Settings.MainFontSize - 1;

    }


    public void LoadPageData()
    {
        if (TaskPageViewModel.TableName != "")
        {
            resultGrid.IsVisible = false;
            resultButtonsGrid.IsVisible = false;
            AnswerGridEnable(chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1, chbtnA2, chbtnB2, chbtnC2, chbtnD2, chbtnE2, chbtnA3, chbtnB3, chbtnC3, chbtnD3, chbtnE3, chbtnA4, chbtnB4, chbtnC4, chbtnD4, chbtnE4,
chbtnA5, chbtnB5, chbtnC5, chbtnD5, chbtnE5, ent1, ent2, ent3, AnswerButton, MissButton, FinishButton);

            taskPageView = new TaskPageViewModel(LoadPageData);
            taskPageView.CreateButtonBar(OnQuestionButtonSelect, ChangeQuestionHandler, ref ButtonsBar);
            PlugInCheckButtonsEvents();

            foreach (var item in btnAnswerGrid)
            {

                item.TextColor = blackColor;
                item.BackgroundColor = whiteColor;
            }
            taskPageView.currentQuestion = 0;
            OnQuestionButtonSelect(null,null);

            if (TaskPageViewModel.IsLoadSaved)
            {
                if (TaskPageViewModel.SavedId != 0)
                {
                    saveButton.IsVisible = false;
                    deleteButton.IsVisible = true;
                }
                Finish();
            }
            
        }
        
    }

	

    private void PlugInCheckButtonsEvents()
    {
        chbtnA1.Clicked += (s, e) => 
        {
            chbtnA1.Text = "X";
            chbtnB1.Text = "";
            chbtnC1.Text = "";
            chbtnD1.Text = "";
            chbtnE1.Text = "";
        };
        chbtnA2.Clicked += (s, e) =>
        {
            chbtnA2.Text = "X";
            chbtnB2.Text = "";
            chbtnC2.Text = "";
            chbtnD2.Text = "";
            chbtnE2.Text = "";
        };
        chbtnA3.Clicked += (s, e) =>
        {
            chbtnA3.Text = "X";
            chbtnB3.Text = "";
            chbtnC3.Text = "";
            chbtnD3.Text = "";
            chbtnE3.Text = "";
        };
        chbtnA4.Clicked += (s, e) =>
        {
            chbtnA4.Text = "X";
            chbtnB4.Text = "";
            chbtnC4.Text = "";
            chbtnD4.Text = "";
            chbtnE4.Text = "";
        };
        chbtnA5.Clicked += (s, e) =>
        {
            chbtnA5.Text = "X";
            chbtnB5.Text = "";
            chbtnC5.Text = "";
            chbtnD5.Text = "";
            chbtnE5.Text = "";
        };

        chbtnB1.Clicked += (s, e) =>
        {
            chbtnA1.Text = "";
            chbtnB1.Text = "X";
            chbtnC1.Text = "";
            chbtnD1.Text = "";
            chbtnE1.Text = "";
        };

        chbtnB2.Clicked += (s, e) =>
        {
            chbtnA2.Text = "";
            chbtnB2.Text = "X";
            chbtnC2.Text = "";
            chbtnD2.Text = "";
            chbtnE2.Text = "";
        };
        chbtnB3.Clicked += (s, e) =>
        {
            chbtnA3.Text = "";
            chbtnB3.Text = "X";
            chbtnC3.Text = "";
            chbtnD3.Text = "";
            chbtnE3.Text = "";
        };
        chbtnB4.Clicked += (s, e) =>
        {
            chbtnA4.Text = "";
            chbtnB4.Text = "X";
            chbtnC4.Text = "";
            chbtnD4.Text = "";
            chbtnE4.Text = "";
        };
        chbtnB5.Clicked += (s, e) =>
        {
            chbtnA5.Text = "";
            chbtnB5.Text = "X";
            chbtnC5.Text = "";
            chbtnD5.Text = "";
            chbtnE5.Text = "";
        };

        chbtnC1.Clicked += (s, e) =>
        {
            chbtnA1.Text = "";
            chbtnB1.Text = "";
            chbtnC1.Text = "X";
            chbtnD1.Text = "";
            chbtnE1.Text = "";
        };
        chbtnC2.Clicked += (s, e) =>
        {
            chbtnA2.Text = "";
            chbtnB2.Text = "";
            chbtnC2.Text = "X";
            chbtnD2.Text = "";
            chbtnE2.Text = "";
        };
        chbtnC3.Clicked += (s, e) =>
        {
            chbtnA3.Text = "";
            chbtnB3.Text = "";
            chbtnC3.Text = "X";
            chbtnD3.Text = "";
            chbtnE3.Text = "";
        };
        chbtnC4.Clicked += (s, e) =>
        {
            chbtnA4.Text = "";
            chbtnB4.Text = "";
            chbtnC4.Text = "X";
            chbtnD4.Text = "";
            chbtnE4.Text = "";
        };
        chbtnC5.Clicked += (s, e) =>
        {
            chbtnA5.Text = "";
            chbtnB5.Text = "";
            chbtnC5.Text = "X";
            chbtnD5.Text = "";
            chbtnE5.Text = "";
        };

        chbtnD1.Clicked += (s, e) =>
        {
            chbtnA1.Text = "";
            chbtnB1.Text = "";
            chbtnC1.Text = "";
            chbtnD1.Text = "X";
            chbtnE1.Text = "";
        };
        chbtnD2.Clicked += (s, e) =>
        {
            chbtnA2.Text = "";
            chbtnB2.Text = "";
            chbtnC2.Text = "";
            chbtnD2.Text = "X";
            chbtnE2.Text = "";
        };
        chbtnD3.Clicked += (s, e) =>
        {
            chbtnA3.Text = "";
            chbtnB3.Text = "";
            chbtnC3.Text = "";
            chbtnD3.Text = "X";
            chbtnE3.Text = "";
        };
        chbtnD4.Clicked += (s, e) =>
        {
            chbtnA4.Text = "";
            chbtnB4.Text = "";
            chbtnC4.Text = "";
            chbtnD4.Text = "X";
            chbtnE4.Text = "";
        };
        chbtnD5.Clicked += (s, e) =>
        {
            chbtnA5.Text = "";
            chbtnB5.Text = "";
            chbtnC5.Text = "";
            chbtnD5.Text = "X";
            chbtnE5.Text = "";
        };

        chbtnE1.Clicked += (s, e) =>
        {
            chbtnA1.Text = "";
            chbtnB1.Text = "";
            chbtnC1.Text = "";
            chbtnD1.Text = "";
            chbtnE1.Text = "X";
        };
        chbtnE2.Clicked += (s, e) =>
        {
            chbtnA2.Text = "";
            chbtnB2.Text = "";
            chbtnC2.Text = "";
            chbtnD2.Text = "";
            chbtnE2.Text = "X";
        };
        chbtnE3.Clicked += (s, e) =>
        {
            chbtnA3.Text = "";
            chbtnB3.Text = "";
            chbtnC3.Text = "";
            chbtnD3.Text = "";
            chbtnE3.Text = "X";
        };
        chbtnE4.Clicked += (s, e) =>
        {
            chbtnA4.Text = "";
            chbtnB4.Text = "";
            chbtnC4.Text = "";
            chbtnD4.Text = "";
            chbtnE4.Text = "X";
        };
        chbtnE5.Clicked += (s, e) =>
        {
            chbtnA5.Text = "";
            chbtnB5.Text = "";
            chbtnC5.Text = "";
            chbtnD5.Text = "";
            chbtnE5.Text = "X";
        };

    }

    private void RememberSelectedAnswerGrid()
    {
        if (checkboxGrid.IsVisible)
        {
            Dictionary<int, string[]> tempDict = new Dictionary<int, string[]>
            {
                { 0, new string[5] { chbtnA1.Text, chbtnB1.Text, chbtnC1.Text, chbtnD1.Text, chbtnE1.Text } },
                { 1, new string[5] { chbtnA2.Text, chbtnB2.Text, chbtnC2.Text, chbtnD2.Text, chbtnE2.Text } },
                { 2, new string[5] { chbtnA3.Text, chbtnB3.Text, chbtnC3.Text, chbtnD3.Text, chbtnE3.Text } },
                { 3, new string[5] { chbtnA4.Text, chbtnB4.Text, chbtnC4.Text, chbtnD4.Text, chbtnE4.Text } },
                { 4, new string[5] { chbtnA5.Text, chbtnB5.Text, chbtnC5.Text, chbtnD5.Text, chbtnE5.Text } }
            };
            TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion] = tempDict;
        }
        else if(entryGrid.IsVisible)
        {
            Dictionary<int, string[]> tempDict = new Dictionary<int, string[]>
            {
                { 0, new string[5] { ent1.Text, ent2.Text, ent3.Text,"", "" } },
                { 1, new string[5] { "", "", "", "", "" } },
                { 2, new string[5] { "", "", "", "", "" } },
                { 3, new string[5] { "", "", "", "", "" } },
                { 4, new string[5] { "", "", "", "", "" } }
            };
            TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion] = tempDict;
        }
        else
        {

        }

    }

    private void UseSelectedAnswerGrid()
    {

        if (resultGrid.IsVisible)
        {
            if (checkboxGrid.IsVisible)
            {
                if (TaskPageViewModel.selectedAnswerGrid.ContainsKey(taskPageView.currentQuestion))
                {
                    Dictionary<int, string[]> tempDict = taskPageView.answerGrid[taskPageView.currentQuestion];
                    Dictionary<int, string[]> tempDict1 = TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion];

                    chbtnA1.Text = tempDict[0][0];
                    chbtnB1.Text = tempDict[0][1];
                    chbtnC1.Text = tempDict[0][2];
                    chbtnD1.Text = tempDict[0][3];
                    chbtnE1.Text = tempDict[0][4];

                    chbtnA2.Text = tempDict[1][0];
                    chbtnB2.Text = tempDict[1][1];
                    chbtnC2.Text = tempDict[1][2];
                    chbtnD2.Text = tempDict[1][3];
                    chbtnE2.Text = tempDict[1][4];

                    chbtnA3.Text = tempDict[2][0];
                    chbtnB3.Text = tempDict[2][1];
                    chbtnC3.Text = tempDict[2][2];
                    chbtnD3.Text = tempDict[2][3];
                    chbtnE3.Text = tempDict[2][4];

                    chbtnA4.Text = tempDict[3][0];
                    chbtnB4.Text = tempDict[3][1];
                    chbtnC4.Text = tempDict[3][2];
                    chbtnD4.Text = tempDict[3][3];
                    chbtnE4.Text = tempDict[3][4];

                    chbtnA5.Text = tempDict[4][0];
                    chbtnB5.Text = tempDict[4][1];
                    chbtnC5.Text = tempDict[4][2];
                    chbtnD5.Text = tempDict[4][3];
                    chbtnE5.Text = tempDict[4][4];

                    foreach (var item in btnAnswerGrid)
                    {
                        item.BackgroundColor = whiteColor;
                        if (item.Text=="X")
                        {
                            item.TextColor = myGreenColor;
                        }
                        else
                        {
                            item.TextColor = myRedColor; 
                        }
                    }

                    chbtnA1.Text += tempDict1[0][0];
                    chbtnB1.Text += tempDict1[0][1];
                    chbtnC1.Text += tempDict1[0][2];
                    chbtnD1.Text += tempDict1[0][3];
                    chbtnE1.Text += tempDict1[0][4];

                    chbtnA2.Text += tempDict1[1][0];
                    chbtnB2.Text += tempDict1[1][1];
                    chbtnC2.Text += tempDict1[1][2];
                    chbtnD2.Text += tempDict1[1][3];
                    chbtnE2.Text += tempDict1[1][4];

                    chbtnA3.Text += tempDict1[2][0];
                    chbtnB3.Text += tempDict1[2][1];
                    chbtnC3.Text += tempDict1[2][2];
                    chbtnD3.Text += tempDict1[2][3];
                    chbtnE3.Text += tempDict1[2][4];

                    chbtnA4.Text += tempDict1[3][0];
                    chbtnB4.Text += tempDict1[3][1];
                    chbtnC4.Text += tempDict1[3][2];
                    chbtnD4.Text += tempDict1[3][3];
                    chbtnE4.Text += tempDict1[3][4];

                    chbtnA5.Text += tempDict1[4][0];
                    chbtnB5.Text += tempDict1[4][1];
                    chbtnC5.Text += tempDict1[4][2];
                    chbtnD5.Text += tempDict1[4][3];
                    chbtnE5.Text += tempDict1[4][4];

                    foreach (var item in btnAnswerGrid)
                    {
                        if (item.Text == "XX")
                        {
                            item.BackgroundColor = myYellowColor;
                            item.Text = "X";
                        }
                    }
                }

            }
            else if (entryGrid.IsVisible)
            {
                if (TaskPageViewModel.selectedAnswerGrid.ContainsKey(taskPageView.currentQuestion))
                {
                    Dictionary<int, string[]> tempDict = TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion];

                    ent1.Text = tempDict[0][0];
                    ent2.Text = tempDict[0][1];
                    ent3.Text = tempDict[0][2];
                }

            }

        }
        else
        {
            if (checkboxGrid.IsVisible)
            {
                if (TaskPageViewModel.selectedAnswerGrid.ContainsKey(taskPageView.currentQuestion))
                {
                    Dictionary<int, string[]> tempDict = TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion];

                    chbtnA1.Text = tempDict[0][0];
                    chbtnB1.Text = tempDict[0][1];
                    chbtnC1.Text = tempDict[0][2];
                    chbtnD1.Text = tempDict[0][3];
                    chbtnE1.Text = tempDict[0][4];

                    chbtnA2.Text = tempDict[1][0];
                    chbtnB2.Text = tempDict[1][1];
                    chbtnC2.Text = tempDict[1][2];
                    chbtnD2.Text = tempDict[1][3];
                    chbtnE2.Text = tempDict[1][4];

                    chbtnA3.Text = tempDict[2][0];
                    chbtnB3.Text = tempDict[2][1];
                    chbtnC3.Text = tempDict[2][2];
                    chbtnD3.Text = tempDict[2][3];
                    chbtnE3.Text = tempDict[2][4];

                    chbtnA4.Text = tempDict[3][0];
                    chbtnB4.Text = tempDict[3][1];
                    chbtnC4.Text = tempDict[3][2];
                    chbtnD4.Text = tempDict[3][3];
                    chbtnE4.Text = tempDict[3][4];

                    chbtnA5.Text = tempDict[4][0];
                    chbtnB5.Text = tempDict[4][1];
                    chbtnC5.Text = tempDict[4][2];
                    chbtnD5.Text = tempDict[4][3];
                    chbtnE5.Text = tempDict[4][4];
                }

            }

            else if (entryGrid.IsVisible)
            {
                if (TaskPageViewModel.selectedAnswerGrid.ContainsKey(taskPageView.currentQuestion))
                {
                    Dictionary<int, string[]> tempDict = TaskPageViewModel.selectedAnswerGrid[taskPageView.currentQuestion];

                    ent1.Text = tempDict[0][0];
                    ent2.Text = tempDict[0][1];
                    ent3.Text = tempDict[0][2];
                }

            }

        }
        
    }
    private void Finish()
    {
        int totalsore = 0;
        int userscore = 0;
        taskPageView.GetResult(out totalsore, out userscore, ref ButtonsBar);
        resultGrid.IsVisible = true;
        resultButtonsGrid.IsVisible = true;
        if (DbProvider.SelectIsDoneFromTopicsTable(TaskPageViewModel.TopicsTable, TaskPageViewModel.TableName) == "True")
        {
            markAsDoneButton.IsVisible = false;
            markAsNotDoneButton.IsVisible = true;
        }
        else
        {
            markAsDoneButton.IsVisible = true;
            markAsNotDoneButton.IsVisible = false;
        }

        totalScore.Text = totalsore.ToString();
        userScore.Text = userscore.ToString();
        correctPerCent.Text = (Math.Round(((double)userscore / (double)totalsore) * 100)).ToString() + "%";
        topicLabel.Text = "Тема: " + TaskPageViewModel.CurrentTopic;
        AnswerGridUnEnable(chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1, chbtnA2, chbtnB2, chbtnC2, chbtnD2, chbtnE2, chbtnA3, chbtnB3, chbtnC3, chbtnD3, chbtnE3, chbtnA4, chbtnB4, chbtnC4, chbtnD4, chbtnE4,
        chbtnA5, chbtnB5, chbtnC5, chbtnD5, chbtnE5, ent1, ent2, ent3, AnswerButton, MissButton, FinishButton);

    }

    private void OnPressAnswerButton(object sender, EventArgs args)
    {
        RememberSelectedAnswerGrid();
        Button btn = ButtonsBar[taskPageView.currentQuestion] as Button;
        btn.BackgroundColor = answeredColor;
        taskPageView.currentQuestion += 1;
        OnQuestionButtonSelect(sender, args);

    }
    private void OnPressMissButton(object sender, EventArgs args)
    {
        taskPageView.currentQuestion += 1;
        OnQuestionButtonSelect(sender, args);
    }

    private void OnPressCommentButton(object sender, EventArgs args)
    {
        CommentLabel.IsVisible = true;
        commentImage.IsVisible = true;
        CommentLabel.Text = taskPageView.Questions[taskPageView.currentQuestion].Comment;
  
    }

    private void OnPressFinishButton(object sender, EventArgs args)
    {
        RememberSelectedAnswerGrid();
        OnQuestionButtonSelect(sender, args);

        Finish();
        
        UseSelectedAnswerGrid();
        deleteButton.IsVisible = false;
        saveButton.IsVisible = true;

    }

    

    private void OnPressSaveButton(object sender, EventArgs args)
    {
       
        string jsonString = JsonSerializer.Serialize<Dictionary<int, Dictionary<int, string[]>>>(TaskPageViewModel.selectedAnswerGrid);
        DbProvider.SetSavedTestList(TaskPageViewModel.TableName, TaskPageViewModel.CurrentTopic, jsonString, $"{DateTime.Now.ToString("d")} набрано {correctPerCent.Text}");
        saveButton.IsVisible = false;
        deleteButton.IsVisible = true;
        LikePage.savedModels = DbProvider.GetSavedTests();
    }

    private void OnPressDeleteButton(object sender, EventArgs args)
    {
        if (TaskPageViewModel.IsLoadSaved)
        {
            DbProvider.DeleteSavedTestList(TaskPageViewModel.SavedId);
            TaskPageViewModel.IsLoadSaved = false;
        }
        else
        {
            DbProvider.DeleteSavedTestList(LikePage.savedModels[LikePage.savedModels.Count - 1].Id);
        }
        saveButton.IsVisible = true;
        deleteButton.IsVisible = false;

        LikePage.savedModels = DbProvider.GetSavedTests();

    }
    private void OnPressMarkAsDoneButton(object sender, EventArgs args)
    {
        DbProvider.UpdateTopicsTable(TaskPageViewModel.TopicsTable, "True", TaskPageViewModel.TableName);
        markAsNotDoneButton.IsVisible = true;
        markAsDoneButton.IsVisible = false;
    }

    private void OnPressMarkAsNotDoneButton(object sender, EventArgs args)
    {        
        DbProvider.UpdateTopicsTable(TaskPageViewModel.TopicsTable, "False", TaskPageViewModel.TableName);
        markAsNotDoneButton.IsVisible = false;
        markAsDoneButton.IsVisible = true;
    }

    private void OnQuestionButtonSelect(object sender, EventArgs args)
    {
        Counter.Text = $"Завдання {taskPageView.currentQuestion + 1} з {taskPageView.Questions.Count}";
        TaskText.Text = @taskPageView.Questions[taskPageView.currentQuestion].Task; // !!!!

        if (taskPageView.Questions[taskPageView.currentQuestion].ImageData != "")
        {
            TaskImage.IsVisible = true;
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(taskPageView.Questions[taskPageView.currentQuestion].ImageData));
            TaskImage.Source = ImageSource.FromStream(() => stream);
        }
        else
        {
            TaskImage.IsVisible = false;
        }

        a1.Text = taskPageView.Questions[taskPageView.currentQuestion].a1;
        IsRowVisible(ref a1, ref l1);
        a2.Text = taskPageView.Questions[taskPageView.currentQuestion].a2;
        IsRowVisible(ref a2, ref l2);
        a3.Text = taskPageView.Questions[taskPageView.currentQuestion].a3;
        IsRowVisible(ref a3, ref l3);
        a4.Text = taskPageView.Questions[taskPageView.currentQuestion].a4;
        IsRowVisible(ref a4, ref l4);
        a5.Text = taskPageView.Questions[taskPageView.currentQuestion].a5;
        IsRowVisible(ref a5, ref l5);
        a6.Text = taskPageView.Questions[taskPageView.currentQuestion].a6;
        IsRowVisible(ref a6, ref l6);
        a7.Text = taskPageView.Questions[taskPageView.currentQuestion].a7;
        IsRowVisible(ref a7, ref l7);
        a8.Text = taskPageView.Questions[taskPageView.currentQuestion].a8;
        IsRowVisible(ref a8, ref l8);

        A.Text = taskPageView.Questions[taskPageView.currentQuestion].b1;
        IsRowVisible(ref A, ref lA);
        B.Text = taskPageView.Questions[taskPageView.currentQuestion].b2;
        IsRowVisible(ref B, ref lB);
        C.Text = taskPageView.Questions[taskPageView.currentQuestion].b3;
        IsRowVisible(ref C, ref lC);
        D.Text = taskPageView.Questions[taskPageView.currentQuestion].b4;
        IsRowVisible(ref D, ref lD);
        E.Text = taskPageView.Questions[taskPageView.currentQuestion].b5;
        IsRowVisible(ref E, ref lE);

        UseSelectedAnswerGrid();

        if (taskPageView.Questions[taskPageView.currentQuestion].CorrectAnswer.Length == 1)
        {
            entryGrid.IsVisible = false;
            checkboxGrid.IsVisible = true;
            CheckRowVisible(chA, chB, chC, chE, chD, chF);
            CheckRowVisible(chl1, chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1);
            CheckRowUnvisible(chl2, chbtnA2, chbtnB2, chbtnC2, chbtnD2, chbtnE2);
            CheckRowUnvisible(chl3, chbtnA3, chbtnB3, chbtnC3, chbtnD3, chbtnE3);
            CheckRowUnvisible(chl4, chbtnA4, chbtnB4, chbtnC4, chbtnD4, chbtnE4);
            CheckRowUnvisible(chl5, chbtnA5, chbtnB5, chbtnC5, chbtnD5, chbtnE5);
        }
        else if (taskPageView.Questions[taskPageView.currentQuestion].CorrectAnswer.Length == 4)
        {
            entryGrid.IsVisible = false;
            checkboxGrid.IsVisible = true;
            CheckRowVisible(chA, chB, chC, chE, chD, chF);
            CheckRowVisible(chl1, chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1);
            CheckRowVisible(chl2, chbtnA2, chbtnB2, chbtnC2, chbtnD2, chbtnE2);
            CheckRowVisible(chl3, chbtnA3, chbtnB3, chbtnC3, chbtnD3, chbtnE3);
            CheckRowVisible(chl4, chbtnA4, chbtnB4, chbtnC4, chbtnD4, chbtnE4);
        }
        else if (taskPageView.Questions[taskPageView.currentQuestion].CorrectAnswer.Length == 5)
        {
            entryGrid.IsVisible = false;
            checkboxGrid.IsVisible = true;
            CheckRowVisible(chA, chB, chC, chE, chD, chF);
            CheckRowVisible(chl1, chbtnA1, chbtnB1, chbtnC1, chbtnD1, chbtnE1);
            CheckRowVisible(chl2, chbtnA2, chbtnB2, chbtnC2, chbtnD2, chbtnE2);
            CheckRowVisible(chl3, chbtnA3, chbtnB3, chbtnC3, chbtnD3, chbtnE3);
            CheckRowVisible(chl4, chbtnA4, chbtnB4, chbtnC4, chbtnD4, chbtnE4);
            CheckRowVisible(chl5, chbtnA5, chbtnB5, chbtnC5, chbtnD5, chbtnE5);
        }
        else if (taskPageView.Questions[taskPageView.currentQuestion].CorrectAnswer.Length == 3)
        {
            entryGrid.IsVisible = true;
            checkboxGrid.IsVisible = false;
        }
        CommentLabel.IsVisible = false;

        if (taskPageView.Questions[taskPageView.currentQuestion].CommentImage != "" || taskPageView.Questions[taskPageView.currentQuestion].CommentImage != null)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(taskPageView.Questions[taskPageView.currentQuestion].CommentImage));
            commentImage.Source = ImageSource.FromStream(() => stream);
        }
        commentImage.IsVisible = false;

    }
    private void ChangeQuestionHandler(int prv, int curr)
    {
        var t = ButtonsBar.Children[prv];
        var t1 = ButtonsBar.Children[curr];
        Color prvcolor = new Color();
        if (t1 is Button btn1)
        {
            prvcolor = btn1.BorderColor;
        }


        if (t is Button btn)
        {
            btn.BorderColor = prvcolor;
        }
        if (t1 is Button btn2)
        {            
            btn2.BorderColor = selectedBtnColor;
        }

       

        if(curr == ButtonsBar.Count - 1)
        {
            FinishButton.IsVisible = true;
            AnswerButton.IsVisible = false;
            MissButton.IsVisible = false;

        }
        else
        {
            FinishButton.IsVisible = false;
            AnswerButton.IsVisible = true;
            MissButton.IsVisible = true;
        }


    }

}

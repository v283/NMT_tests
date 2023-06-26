using NMT_tests.Data;
using static NMT_tests.Pages.TaskPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NMT_tests.Pages.PagesColors;

namespace NMT_tests.Pages
{
    public class TaskPageViewModel
    {
        private int currentquestion = 0;
        private static string tableName = "";

        private QuestionNumberChanhed numberChanhed;
        private static ReloadTaskPage? reloadTaskPage = null;

        private List<string> selectedAnswer = new List<string>();
        public List<QuestionModel> Questions;
        public static Dictionary<int, Dictionary<int, string[]>> selectedAnswerGrid = new Dictionary<int, Dictionary<int, string[]>>();
        public Dictionary<int, Dictionary<int, string[]>>  answerGrid = new Dictionary<int, Dictionary<int, string[]>>(); //correct answers
        public static bool IsLoadSaved = false;
        public static int SavedId = 0;

        public static string CurrentTopic = "";
        public static string TopicsTable;
        public static string TableName
        {
            get => tableName;
            set
            {
                tableName = value;
                if (reloadTaskPage != null)
                {
                    reloadTaskPage();
                }
            }
        }

        public int currentQuestion
        {
            get { return currentquestion; }
            set
            {
                numberChanhed(currentquestion, value);
                currentquestion = value;                
            }
        }


        public TaskPageViewModel(ReloadTaskPage reload)
        {
            Questions = DbProvider.GetQuestionsListFomDbTable(TableName);
            reloadTaskPage = reload;
            if (!IsLoadSaved)
            {
                selectedAnswerGrid = new Dictionary<int, Dictionary<int, string[]>>();
                for (int i = 0; i < Questions.Count; i++)
                {
                    Dictionary<int, string[]> tempDic = new Dictionary<int, string[]>
                    {
                        { 0, new string[5] { "", "", "", "", "" } },
                        { 1, new string[5] { "", "", "", "", "" } },
                        { 2, new string[5] { "", "", "", "", "" } },
                        { 3, new string[5] { "", "", "", "", "" } },
                        { 4, new string[5] { "", "", "", "", "" } }
                     };
                                       
                    selectedAnswerGrid.Add(i, tempDic);
                }
            }

            for (int i = 0; i < Questions.Count; i++)
            {
                Dictionary<int, string[]> tempDict1 = new Dictionary<int, string[]>
                {
                    { 0, new string[5] { "", "", "", "", "" } },
                    { 1, new string[5] { "", "", "", "", "" } },
                    { 2, new string[5] { "", "", "", "", "" } },
                    { 3, new string[5] { "", "", "", "", "" } },
                    { 4, new string[5] { "", "", "", "", "" } }
                };
                answerGrid.Add(i, tempDict1);
                
            }
            if (TableName.Contains("Hist"))
            {
                TopicsTable = "HistTopics";
            }
            else if (TableName.Contains("Ukr"))
            {
                TopicsTable = "UkrTopics";
            }
            else if (TableName.Contains("Math"))
            {
                TopicsTable = "MathTopics";
            }
            else if (TableName.Contains("NMT"))
            {
                TopicsTable = "NMTTopics";
            }

            CurrentTopic = DbProvider.SelectCurrentTopicFromTopicsTable(TaskPageViewModel.TopicsTable, TaskPageViewModel.TableName);
        }
      

        public void CreateButtonBar(EventHandler e, QuestionNumberChanhed d, ref HorizontalStackLayout view)
        {
            view.Children.Clear();
            for (int i = 0; i < Questions.Count; i++)
            {
                Button button = new Button();
                button.Text = (i + 1).ToString();
                button.Clicked += (sender, args) => currentQuestion = Convert.ToInt32(button.Text) - 1;
                button.Clicked += e;
                view.Add(button);
            }

            numberChanhed = d;
        }

        public void GetResult(out int totalScores, out int userResult, ref HorizontalStackLayout btnbar)
        {
            for (int i = 0; i < Questions.Count; i++)
            {
                Dictionary<int, string[]> tempDict = answerGrid[i];
                string answ = Questions[i].CorrectAnswer;
                for (int j = 0; j < answ.Length; j++)
                {
                    if (answ[j].ToString() == "А")
                    {
                        tempDict[j] = new string[5] { "X", "", "", "", "" };
                    }
                    else if (answ[j].ToString() == "Б")
                    {
                        tempDict[j] = new string[5] { "", "X", "", "", "" };
                    }
                    else if (answ[j].ToString() == "В")
                    {
                        tempDict[j] = new string[5] { "", "", "X", "", "" };
                    }
                    else if (answ[j].ToString() == "Г")
                    {
                        tempDict[j] = new string[5] { "", "", "", "X", "" };
                    }
                    else if (answ[j].ToString() == "Д")
                    {
                        tempDict[j] = new string[5] { "", "", "", "", "X" };
                    }

                }

            }


            userResult = 0;
            totalScores = 0;
            for (int i = 0; i < Questions.Count; i++)
            {
                Dictionary<int, string[]> tempDict = new Dictionary<int, string[]>();
                tempDict = selectedAnswerGrid[i];
                string result = "";
                for (int t = 0; t < tempDict.Count; t++)
                {
                    string[] temp = tempDict[t];
                    
                    if (temp[0] == "X")
                    {
                        result += "А";
                    }
                    else if (temp[1] == "X")
                    {
                        result += "Б";
                    }
                    else if (temp[2] == "X")
                    {
                        result += "В";
                    }
                    else if (temp[3] == "X")
                    {
                        result += "Г";
                    }
                    else if (temp[4] == "X")
                    {
                        result += "Д";
                    }
                    else
                    {
                        result += temp[0] + temp[1] + temp[2] + temp[3] + temp[4];
                    }
                }

                selectedAnswer.Add(result);
                totalScores += Questions[i].CorrectAnswer.Length;



                if (Questions[i].CorrectAnswer == selectedAnswer[i])
                {
                    userResult += Questions[i].CorrectAnswer.Length;
                    Button button = btnbar[i] as Button;
                    button.BackgroundColor = myGreenColor;
                }
                else
                {
                    Button button = btnbar[i] as Button;
                    button.BackgroundColor = myRedColor;

                    if (Questions[i].CorrectAnswer.Length == 3)
                    {
                        int b = 0;
                        for (int h = 0; h < selectedAnswer[i].Length; h++)
                        {
                            
                            if (selectedAnswer[i].Contains(Questions[i].CorrectAnswer[h]))
                            {
                                b += 1;
                            } 
                        }

                        if (b == 3)
                        {
                            button.BackgroundColor = myGreenColor;
                            userResult += b;
                        }
                        else if (b>0 || b<3)
                        {
                            button.BackgroundColor = myOrangeColor;
                            userResult += b;
                        }

                        
                    }
                    else if (Questions[i].CorrectAnswer.Length > 3)
                    {
                        int b = 0;
                        for (int h = 0; h < selectedAnswer[i].Length; h++)
                        {

                            if (selectedAnswer[i][h].ToString() == Questions[i].CorrectAnswer[h].ToString())
                            {
                                b += 1;
                            }
                        }
                        if (b > 0)
                        {
                            button.BackgroundColor = myOrangeColor;
                            userResult += b;
                        }

                    }

                }

            }
        }


        public delegate void QuestionNumberChanhed(int prv, int curr);

        public  delegate void ReloadTaskPage();


    }
}

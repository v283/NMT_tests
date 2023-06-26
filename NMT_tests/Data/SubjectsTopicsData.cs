using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Data
{
    class SubjectsTopicsData
    {
        public static List<TopicModel> Ukr = new List<TopicModel>()
        {

        };

        public static List<TopicModel> Math = new List<TopicModel>()
        {


        };
        public static List<TopicModel> History = new List<TopicModel>()
        {


        };
        public static List<TopicModel> NMT = new List<TopicModel>()
        {


        };

        public static void  LoadSubjectsTopicsData()
        {
            Ukr  = DbProvider.GetTopicsListFromDbTable("UkrTopics");
            Math  = DbProvider.GetTopicsListFromDbTable("MathTopics");
            History  = DbProvider.GetTopicsListFromDbTable("HistTopics");
            NMT = DbProvider.GetTopicsListFromDbTable("UkrTopics");

        }


    }
}

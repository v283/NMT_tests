using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Data
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string ImageData { get; set; }

        public string Task { get; set; }
        public string a1 { get; set; }
        public string a2 { get; set; }
        public string a3 { get; set; }
        public string a4 { get; set; }
        public string a5 { get; set; }
        public string a6 { get; set; }
        public string a7 { get; set; }
        public string a8 { get; set; }

        public string b1 { get; set; }
        public string b2 { get; set; }
        public string b3 { get; set; }
        public string b4 { get; set; }
        public string b5 { get; set; }

        public string CorrectAnswer { get; set; }

        public string Comment { get; set; }
        public string CommentImage { get; set; }

    }
}

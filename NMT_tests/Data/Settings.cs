using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Data
{
    public class Settings
    {
        public static ChangeFont changeFont;
        private static int mainFontSize = 18;
        public static int MainFontSize
        {
            get
            {
                return mainFontSize;
            }
            set
            {
                mainFontSize = value;
                if (changeFont != null)
                {
                    changeFont();
                }
            }
        }

        public delegate void ChangeFont();

    }
}

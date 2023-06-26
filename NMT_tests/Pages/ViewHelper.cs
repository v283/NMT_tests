using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMT_tests.Pages
{
    public static class ViewHelper
    {
        public static void CheckRowUnvisible(VisualElement b, VisualElement b1, VisualElement b2, VisualElement b3, VisualElement b4, VisualElement b5)
        {
            b.IsVisible = false;
            b1.IsVisible = false;
            b2.IsVisible = false;
            b3.IsVisible = false;
            b4.IsVisible = false;
            b5.IsVisible = false;
        }
        public static void CheckRowVisible(VisualElement b, VisualElement b1, VisualElement b2, VisualElement b3, VisualElement b4, VisualElement b5)
        {
            b.IsVisible = true;
            b1.IsVisible = true;
            b2.IsVisible = true;
            b3.IsVisible = true;
            b4.IsVisible = true;
            b5.IsVisible = true;
        }

        public static void CheckRowUnvisible(VisualElement b, VisualElement b1, VisualElement b2)
        {
            b.IsVisible = false;
            b1.IsVisible = false;
            b2.IsVisible = false;
        }
        public static void CheckRowVisible(VisualElement b, VisualElement b1, VisualElement b2)
        {
            b.IsVisible = true;
            b1.IsVisible = true;
            b2.IsVisible = true;

        }

        public static void CheckRowUnvisible(VisualElement b)
        {
            b.IsVisible = false;
        }
        public static void CheckRowVisible(VisualElement b)
        {
            b.IsVisible = true;
        }

        public static void AnswerGridUnEnable(VisualElement b, VisualElement b1, VisualElement b2, VisualElement b3, VisualElement b4, VisualElement b5,
            VisualElement b6, VisualElement b7, VisualElement b8, VisualElement b9, VisualElement b10, VisualElement b11, VisualElement b12,VisualElement b13, VisualElement b14, VisualElement b15, VisualElement b16, 
            VisualElement b17, VisualElement b18, VisualElement b19, VisualElement b20, VisualElement b21, VisualElement b22, VisualElement b23, VisualElement b24, VisualElement b25, VisualElement b26, VisualElement b27, VisualElement b28, VisualElement b29, VisualElement b30)
        {
            b.IsEnabled = false;
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            b7.IsEnabled = false;
            b8.IsEnabled = false;
            b9.IsEnabled = false;
            b10.IsEnabled = false;
            b11.IsEnabled = false;
            b12.IsEnabled = false;
            b13.IsEnabled = false;
            b14.IsEnabled = false;
            b15.IsEnabled = false;
            b16.IsEnabled = false;
            b17.IsEnabled = false;
            b18.IsEnabled = false;
            b19.IsEnabled = false;
            b20.IsEnabled = false;
            b21.IsEnabled = false;
            b22.IsEnabled = false;
            b23.IsEnabled = false;
            b24.IsEnabled = false;
            b25.IsEnabled = false;
            b26.IsEnabled = false;
            b27.IsEnabled = false;
            b28.IsEnabled = false;
            b29.IsEnabled = false;
            b30.IsEnabled = false;
        }
        public static void AnswerGridEnable(VisualElement b, VisualElement b1, VisualElement b2, VisualElement b3, VisualElement b4, VisualElement b5,
    VisualElement b6, VisualElement b7, VisualElement b8, VisualElement b9, VisualElement b10, VisualElement b11, VisualElement b12, VisualElement b13, VisualElement b14, VisualElement b15, VisualElement b16,
    VisualElement b17, VisualElement b18, VisualElement b19, VisualElement b20, VisualElement b21, VisualElement b22, VisualElement b23, VisualElement b24, VisualElement b25, VisualElement b26, VisualElement b27, VisualElement b28, VisualElement b29, VisualElement b30)
        {
            b.IsEnabled = true;
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            b10.IsEnabled = true;
            b11.IsEnabled = true;
            b12.IsEnabled = true;
            b13.IsEnabled = true;
            b14.IsEnabled = true;
            b15.IsEnabled = true;
            b16.IsEnabled = true;
            b17.IsEnabled = true;
            b18.IsEnabled = true;
            b19.IsEnabled = true;
            b20.IsEnabled = true;
            b21.IsEnabled = true;
            b22.IsEnabled = true;
            b23.IsEnabled = true;
            b24.IsEnabled = true;
            b25.IsEnabled = true;
            b26.IsEnabled = true;
            b27.IsEnabled = true;
            b28.IsEnabled = true;
            b29.IsEnabled = true;
            b30.IsEnabled = true;
        }


        public static void IsRowVisible(ref Label l, ref Label n)
        {
            if (l.Text == "")
            {
                n.IsVisible = false;
                l.IsVisible = false;
            }
            else
            {
                n.IsVisible = true;
                l.IsVisible = true;
            }
        }

        public static void ChangeFontSize(Label b, Label b1, Label b2, Label b3, Label b4, Label b5,
           Label b6, Label b7, Label b8, Label b9, Label b10, Label b11, Label b12, Label b13, Label b14, Label b15, Label b16,
           Label b17, Label b18, Label b19, Label b20, Label b21, Label b22, Label b23, Label b24, Label b25, Label b26, Label b27, Label b28, Label b29, Label b30)
        {
            b.FontSize = Data.Settings.MainFontSize;
            b1.FontSize = Data.Settings.MainFontSize;
            b2.FontSize = Data.Settings.MainFontSize;
            b3.FontSize = Data.Settings.MainFontSize;
            b4.FontSize = Data.Settings.MainFontSize;
            b5.FontSize = Data.Settings.MainFontSize;
            b6.FontSize = Data.Settings.MainFontSize;
            b7.FontSize = Data.Settings.MainFontSize;
            b8.FontSize = Data.Settings.MainFontSize;
            b9.FontSize = Data.Settings.MainFontSize;
            b10.FontSize = Data.Settings.MainFontSize;
            b11.FontSize = Data.Settings.MainFontSize;
            b12.FontSize = Data.Settings.MainFontSize;
            b13.FontSize = Data.Settings.MainFontSize;
            b14.FontSize = Data.Settings.MainFontSize;
            b15.FontSize = Data.Settings.MainFontSize;
            b16.FontSize = Data.Settings.MainFontSize;
            b17.FontSize = Data.Settings.MainFontSize;
            b18.FontSize = Data.Settings.MainFontSize;
            b19.FontSize = Data.Settings.MainFontSize;
            b20.FontSize = Data.Settings.MainFontSize;
            b21.FontSize = Data.Settings.MainFontSize;
            b22.FontSize = Data.Settings.MainFontSize;
            b23.FontSize = Data.Settings.MainFontSize;
            b24.FontSize = Data.Settings.MainFontSize;
            b25.FontSize = Data.Settings.MainFontSize;
            b26.FontSize = Data.Settings.MainFontSize;
            b27.FontSize = Data.Settings.MainFontSize;
            b28.FontSize = Data.Settings.MainFontSize;
            b29.FontSize = Data.Settings.MainFontSize;
            b30.FontSize = Data.Settings.MainFontSize;
        }

    }
}

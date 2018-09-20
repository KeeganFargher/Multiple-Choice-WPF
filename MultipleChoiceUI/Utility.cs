using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace MultipleChoiceUI
{
    public static class Utility
    {
        private static Color correctColor = Color.FromRgb(0, 148, 50);
        private static Color incorrectColor = Color.FromRgb(194, 54, 22);

        public static readonly Brush CorrectAnswer = new SolidColorBrush(correctColor);
        public static readonly Brush IncorrectAnswer = new SolidColorBrush(incorrectColor);

        public static BlurEffect Blur => new BlurEffect { Radius = 5 };
        public static DropShadowEffect DropShadowEffect => new DropShadowEffect { ShadowDepth = 50, BlurRadius = 5};
    }
}

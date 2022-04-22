using System.Collections.Generic;
using System.Windows.Media;

namespace Mastermind.Common
{
    public static class ColorPegs
    {
        //Avaliable Code pegs colors
        public static Brush[] Codepegs_Color = new Brush[] { Brushes.Blue, Brushes.Green, Brushes.DeepPink, Brushes.Red, Brushes.Lavender, Brushes.Yellow };
        //Description and color Key pegs
        public static Dictionary<string, Brush> KeyPegs_Color = new Dictionary<string, Brush>
        { { "None", Brushes.Gray },{ "Color", Brushes.White }, {"Pos",Brushes.Orange } };
    }
}

using Mastermind.Common;
using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mastermind.CodeBreaker
{
    /// <summary>
    /// Users flags to determinate the rigth position & color
    /// </summary>
    public class ColorItem
    {
        public bool RightPosition { get; set; }
        public Int16 UserPos { get; set; }
        public Int16 CodePos { get; set; }
        public bool UserColosExist { get; set; }
    }
    /// <summary>
    /// Interaction logic for CheckCodeBreaker.xaml
    /// </summary>
    public partial class CheckCodeBreaker : UserControl
    {
        ColorItem[] flags = new ColorItem[4];
        //Right color, wrong position
        private Int16 whiteCnt = 0;
        public Int16 WhiteCnt => whiteCnt;

        //Right color, rigth position
        private Int16 orangeCnt = 0;
        public Int16 OrangeCnt => orangeCnt;

        //Initialize  the Key pegs
        Brush[] keycolors = new Brush[4] { Brushes.Gray, Brushes.Gray, Brushes.Gray, Brushes.Gray };
        public Brush[] KeyColors => keycolors;

        public CheckCodeBreaker()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The key pegs after the btn ok
        /// </summary>
        /// <param name="keysColor"></param>
        public CheckCodeBreaker(Brush[] keysColor)
        {
            InitializeComponent();
            Key1.Fill = keysColor[0];
            Key2.Fill = keysColor[1];
            Key3.Fill = keysColor[2];
            Key4.Fill = keysColor[3];

        }
        /// <summary>
        /// Righth Position, Right Color  or not found
        /// </summary>
        /// <param name="userColors"></param>
        /// <param name="codePegs"></param>
        public void PostionColor(Brush[] userColors, Brush[] codePegs)
        {
            keycolors = new Brush[4] { Brushes.Gray, Brushes.Gray, Brushes.Gray, Brushes.Gray };
            int keyCnt = 0;
            whiteCnt = orangeCnt = 0;
            Int16 cnt = 4;


            //Right position
            for (int i = 0; i < 4; i++)
            {

                flags[i] = new ColorItem();
                flags[i].RightPosition = false;
                flags[i].UserPos = flags[i].CodePos = -1;

                // Rigth Color & Right position -only pegs with thr rigth color & position
                if ((userColors[i] as SolidColorBrush).Color == (codePegs[i] as SolidColorBrush).Color)
                {
                    flags[i].RightPosition = true;
                    flags[i].UserPos = flags[i].CodePos = Int16.Parse(i.ToString());
                    keycolors[keyCnt] = ColorPegs.KeyPegs_Color["Pos"];
                    keyCnt++;
                    orangeCnt++;
                    cnt--;
                }
                //The color does not exist in the Code maker

                flags[i].UserPos = codePegs.Where(p => (p as SolidColorBrush).Color == (userColors[i] as SolidColorBrush).Color).Any() ? flags[i].UserPos: Int16.Parse(i.ToString()) ;
                
                
            }

            //Check for the rigth color And wrong position
            if (cnt > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    if ((!flags[i].RightPosition) && (flags[i].UserPos == -1))
                    {

                        //Get the time & indexes of the same color
                        var codeIndexes = codePegs
                        .Select((v, indx) => new { Index = indx, Value = v })
                        .Where(x => (x.Value as SolidColorBrush).Color == (userColors[i] as SolidColorBrush).Color)
                        .Select(x => x.Index)
                        .ToList();

                        
                        int cntCodePeg = codeIndexes.Count;
                        bool isAlreadyTaken = false;
                        
                       
                        while (cntCodePeg > 0)
                        {
                            //Is position taken?
                            int rigtPos = codeIndexes[cntCodePeg - 1];
                            isAlreadyTaken = flags.Where(x => x.CodePos == rigtPos).Any();
                            
                            if (!isAlreadyTaken)
                            {
                                //Write the color should be and where it is
                                 flags[i].CodePos = Int16.Parse(rigtPos.ToString());
                                 flags[i].UserPos = Int16.Parse(i.ToString());
                                 cntCodePeg = 0; //Do not continue While


                                //flags[i].CodePos = Int16.Parse((cntCodePeg - 1).ToString());
                                keycolors[keyCnt] = ColorPegs.KeyPegs_Color["Color"];
                                keyCnt++;
                                whiteCnt++;
                            }
                            cntCodePeg--;
                        }

                    }
                }
            }

        }
    }
}

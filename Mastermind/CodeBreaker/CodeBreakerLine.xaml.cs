using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mastermind.CodeBreaker
{
    public class NotifiyStatusArgs : EventArgs
    {
        public bool Succees = false;
    }
    /// <summary>
    /// Interaction logic for CodeBreakerLine.xaml
    /// </summary>
    public partial class CodeBreakerLine : UserControl
    {
        Brush[] result;
        CodeBreakerItem codeBreakerPos1;
        CodeBreakerItem codeBreakerPos2;
        CodeBreakerItem codeBreakerPos3;
        CodeBreakerItem codeBreakerPos4;
        CheckCodeBreaker CheckCode;

        public virtual event EventHandler<NotifiyStatusArgs> NotifyResult = delegate { };
        public CodeBreakerLine(Brush[] codePegResult)
        {
            InitializeComponent();
            result = codePegResult;
            InitialCodeBreaketLine();
        }
        void InitialCodeBreaketLine()
        {
            //the four user code pegs
            codeBreakerPos1 = new CodeBreakerItem();
            codeBreakerPos1.ColorsCbx.SelectionChanged += (s,e) => FillCodeBreakerLine();

            codeBreakerPos2 = new CodeBreakerItem();
            codeBreakerPos2.ColorsCbx.SelectionChanged += (s, e) => FillCodeBreakerLine();

            codeBreakerPos3 = new CodeBreakerItem();
            codeBreakerPos3.ColorsCbx.SelectionChanged += (s, e) => FillCodeBreakerLine();

            codeBreakerPos4 = new CodeBreakerItem();
            codeBreakerPos4.ColorsCbx.SelectionChanged += (s, e) => FillCodeBreakerLine();

            //The code to break
            CheckCode = new CheckCodeBreaker();
            CheckCodeStck.Children.Add(CheckCode);

            FillCodeBreakerLine();
        }


        void FillCodeBreakerLine()
        {
            Pos1Stck.Children.Clear();
            Pos2Stck.Children.Clear();
            Pos3Stck.Children.Clear();
            Pos4Stck.Children.Clear();

            Pos1Stck.Children.Add(codeBreakerPos1);
            Pos2Stck.Children.Add(codeBreakerPos2);
            Pos3Stck.Children.Add(codeBreakerPos3);
            Pos4Stck.Children.Add(codeBreakerPos4);
        }

        private void okBtn_Click(object sender, RoutedEventArgs e)
        {
            bool areAllSelected = ((codeBreakerPos1.IsColorSet >= 0) && (codeBreakerPos2.IsColorSet >= 0) && (codeBreakerPos3.IsColorSet >= 0) && (codeBreakerPos4.IsColorSet >= 0));
            //Only if all the code  pegs are selected
            if (areAllSelected)
            {
                //Get the Key pegs colors
                Brush[] colorsSelectedArray = new Brush[] { codeBreakerPos1.ColorSelected, codeBreakerPos2.ColorSelected, codeBreakerPos3.ColorSelected, codeBreakerPos4.ColorSelected };
                CheckCode.PostionColor(colorsSelectedArray, result);

                int orange = CheckCode.OrangeCnt;
                int white = CheckCode.WhiteCnt;
                var keyColors = CheckCode.KeyColors;

                CheckCodeStck.Children.Clear();
                CheckCode = new CheckCodeBreaker(keyColors);
                CheckCodeStck.Children.Add(CheckCode);

                //Hide all the cbBx & disable the line, no more changes are allowed
                codeBreakerPos1.ColorsCbx.Visibility =
                    codeBreakerPos2.ColorsCbx.Visibility =
                    codeBreakerPos3.ColorsCbx.Visibility =
                    codeBreakerPos4.ColorsCbx.Visibility =
                    Visibility.Collapsed;
                ColorsGrid.IsEnabled = false;
                var notifyLineStatus = new NotifiyStatusArgs();
                //Send status result
                notifyLineStatus.Succees = orange == 4 ? true : false;
                NotifyResult(this, notifyLineStatus);
            }

        }
    }
}

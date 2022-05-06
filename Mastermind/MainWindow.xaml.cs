//using Mastermind.Common;
using Mastermind.CodeBreaker;
using System;
using System.Windows;
using System.Windows.Media;
namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const Int16 maxNumberOfAttempts = 8;
        Int16 userAttempts = 0;
        Brush[] result;

        public MainWindow()
        {
            InitializeComponent();

        }

        public void AddLine()
        {
            //Add a new line to the board
            if (userAttempts < maxNumberOfAttempts)
            {
                var userLine = new CodeBreakerLine(result);
                userLine.NotifyResult += UserLine_NotifyResult;
                CodePegsLinesStck.Children.Add(userLine);
                userAttempts++;
            }
            else // No more attempts
            {
                CodeToBreakStck.Visibility = Visibility.Visible;
                TestResultlb.Content = "Sorry, you failed!";
                TestResultlb.Visibility = Visibility.Visible;
                PlayBtn.Content = "Play again";
                PlayBtn.Visibility = Visibility.Visible;
                CodePegsLinesStck.Children.Clear();
                CodePegsLinesStck.Visibility = Visibility.Collapsed;
            }
        }

        private void UserLine_NotifyResult(object sender, NotifiyStatusArgs e)
        {
            if (e.Succees)
            {
                CodeToBreakStck.Visibility = Visibility.Visible;
                TestResultlb.Content = "Success!!!";
                TestResultlb.Visibility = Visibility.Visible;
                PlayBtn.Content = "Play again";
                PlayBtn.Visibility = Visibility.Visible;
                CodePegsLinesStck.Children.Clear();
                

            }
            else
            {//Add more lines to the board
                AddLine();
            }
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            //Reset attempts counter
            userAttempts = 0;
            //Remove Users result
            ShowCode.Visibility = Visibility.Visible;
            TestResultlb.Visibility = Visibility.Collapsed;
            TestResultlb.Content = "";

            //Show Info
            Information.Visibility = Visibility.Visible;
            TryagainBtn.Visibility = Visibility.Visible;
            //Remove the old code, if it exists
            CodeToBreakStck.Children.Clear();
            CodeToBreakStck.Visibility = Visibility.Collapsed;

            //Clean Board
            CodePegsLinesStck.Children.Clear();
            CodePegsLinesStck.Visibility = Visibility.Visible;

            //Generate Code to break
            var codeTobreak = new CodeMaker.CodeMaker();
            result = codeTobreak.CodePegResult;
            CodeToBreakStck.Children.Add(codeTobreak);

            //Remove Start again
            PlayBtn.Visibility = Visibility.Collapsed;
            //Add the first Line
            AddLine();
        }


        private void Expand_Click(object sender, RoutedEventArgs e)
        {
            ShowCode.Visibility = ShowCode.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            HideCode.Visibility = HideCode.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            CodeToBreakStck.Visibility = ShowCode.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

        }

       
        private void TryagainBtn_Click(object sender, RoutedEventArgs e)
        {
            PlayBtn_Click(null, null);
        }
    }
}

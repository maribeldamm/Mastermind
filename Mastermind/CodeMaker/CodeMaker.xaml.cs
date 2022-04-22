using Mastermind.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mastermind.CodeMaker
{
    /// <summary>
    /// Interaction logic for CodeMaker.xaml
    /// </summary>
    public partial class CodeMaker : UserControl
    {
        public Brush[] CodePegResult { get; private set; }
        public List<Brush> colorPegs;
        public CodeMaker()
        {
            InitializeComponent();
            //Generate the array with Code to break
            GenerateCodePeggs();
            //Generate the UI with Code to break

        }

        public void GenerateCodePeggs()
        {
            try
            {
                colorPegs = new List<Brush>();
                
                var rnd = new Random();
               
               // The Colors Pegs - Array with 4 elements - random colors selected by the six colors allowed
                var colorPegsArray = Enumerable.Range(0, 4).Select(x => new SolidColorBrush()
                {
                    Color = ((System.Windows.Media.SolidColorBrush)ColorPegs.Codepegs_Color[rnd.Next(0, 5)]).Color
                }).ToArray();
 
                CodePegResult = colorPegsArray;

                //Fill the color with random selected colors
                pos1.Fill = CodePegResult[0];
                pos2.Fill = CodePegResult[1];
                pos3.Fill = CodePegResult[2];
                pos4.Fill = CodePegResult[3];

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GenerateCodePeggs() " + ex.Message);
            }

        }
    }
}

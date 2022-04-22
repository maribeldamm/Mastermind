using Mastermind.Common;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Mastermind.CodeBreaker
{
    /// <summary>
    /// Interaction logic for CodeBreaker.xaml
    /// </summary>
    public partial class CodeBreakerItem : UserControl
    {

        private int isColorset = -1;
        public int IsColorSet => isColorset;

        private Brush colorSelected = Brushes.Gray;
        public Brush ColorSelected => colorSelected;
        public CodeBreakerItem()
        {
            InitializeComponent();

            PopulateCbBox();
        }


        private void CodePeg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //If a item has been selected, it shows/changes the color
            ColorsCbx.SelectedItem =((ColorsCbx.SelectedItem !=null)&&ColorsCbx.HasItems && (ColorsCbx.SelectedIndex > -1))?ColorsCbx.Items[ColorsCbx.SelectedIndex]: ColorsCbx.Items[0];
            ColorsCbx.Visibility = Visibility.Visible;
        }


        void PopulateCbBox()
        {
            try
            {

                //Populate the list with colors allowed
                ColorsCbx.ItemsSource = ColorPegs.Codepegs_Color.OfType<Brush>()
                    .Select(c => new ComboBoxItem()
                    {
                        Tag = c,
                        Content = GetColorName((SolidColorBrush)c)
                    }).ToList();

                ColorsCbx.SelectedIndex = -1;


            }
            catch (Exception ex)
            {

            }
        }

        private string GetColorName(SolidColorBrush brush)
        {
            var results = typeof(Colors).GetProperties().Where(
             p => (Color)p.GetValue(null, null) == brush.Color).Select(p => p.Name);
            return results.Count() > 0 ? results.First() : String.Empty;
        }

        public void ColorsCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ColorsCbx.SelectedValue != null)
            {
                isColorset = ColorsCbx.SelectedIndex;
                colorSelected = (Brush)((ComboBoxItem)ColorsCbx.SelectedItem).Tag;
                CodePeg.Fill = colorSelected;
            }
            ColorsCbx.Visibility = Visibility.Collapsed;

        }
    }
}

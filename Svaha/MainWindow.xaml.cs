using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Svaha
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FindMatchesButton_Click(object sender, RoutedEventArgs e)
        {
            int k = int.Parse(KTextBox.Text);
            List<int> grooms = GroomsTextBox.Text.Split(' ').Select(int.Parse).ToList();
            List<int> brides = BridesTextBox.Text.Split(' ').Select(int.Parse).ToList();

            grooms.Sort();
            brides.Sort();

            List<string> matches = FindMatches(grooms, brides, k);

            MatchesTextBox.Text = string.Join(Environment.NewLine, matches);
        }

        private List<string> FindMatches(List<int> grooms, List<int> brides, int k)
        {
            List<string> matches = new List<string>();
            int groomIndex = 0;
            int brideIndex = 0;

            while (groomIndex < grooms.Count && brideIndex < brides.Count)
            {
                if (Math.Abs(grooms[groomIndex] - brides[brideIndex]) <= k)
                {
                    matches.Add($"Жених: {grooms[groomIndex]}, Невеста: {brides[brideIndex]}");
                    groomIndex++;
                    brideIndex++;
                }
                else if (grooms[groomIndex] < brides[brideIndex])
                {
                    groomIndex++;
                }
                else
                {
                    brideIndex++;
                }
            }

            return matches;
        }
    }
}



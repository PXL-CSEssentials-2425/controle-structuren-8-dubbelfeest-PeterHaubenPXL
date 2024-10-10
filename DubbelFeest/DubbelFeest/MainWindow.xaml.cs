using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DubbelFeest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            bool isNumber = int.TryParse(numberTextBox.Text, out int countOfPersons);
            double result = 1.0;
            if (isNumber)
            {
                if (countOfPersons > 1)
                {
                    for (int i = 2; i <= countOfPersons; i++)
                    {
                        result = result * (365 - i + 1)/365;
                    }

                    result = (1 - result)*100;
                    result = Math.Round(result, 4);

                    resultTextBox.Text = $"De kans op gelijke verjaardagen is {result}%";
                }
                else
                {
                    MessageBox.Show("Aantal personen moet minimum 2 zijn", "foutieve ingave");
                    numberTextBox.Text = "";
                    numberTextBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Geef een getal in (min: 2)", "foutieve ingave");
                numberTextBox.Text = "";
                numberTextBox.Focus();
            }
                
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            numberTextBox.Text = "";
            numberTextBox.Focus();

            resultTextBox.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
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

// Calculator test
namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;

        public MainWindow()
        {
            InitializeComponent();

            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;

        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = Convert.ToDouble(resultLabel.Content);

            /*
            if (selectedOperator == SelectedOperator.Multiplication)
            result = lastNumber * newNumber;

            if (selectedOperator == SelectedOperator.Division)
                result = lastNumber / newNumber;

            if (selectedOperator == SelectedOperator.Addition)
                result = lastNumber + newNumber;

            if (selectedOperator == SelectedOperator.Sustraction)
                result = lastNumber - newNumber;
            */

            switch (selectedOperator)
            {
                case SelectedOperator.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case SelectedOperator.Sustraction:
                    result = SimpleMath.Sustraction(lastNumber, newNumber);
                    break;
                case SelectedOperator.Multiplication:
                    result = SimpleMath.Multiplication(lastNumber, newNumber);
                    break;
                case SelectedOperator.Division:
                    result = SimpleMath.Division(lastNumber, newNumber);
                    break;         
            }

            resultLabel.Content = result.ToString();
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            /*//if (Enum.IsDefined(typeof(SelectedOperator), selectedOperator))
            if(selectedOperator == SelectedOperator.Addition)
            {
                tempNumber = Convert.ToDouble(resultLabel.Content);
                resultLabel.Content = (lastNumber / 100) * tempNumber;
            }*/
                

            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);

                if(lastNumber != 0)
                {
                    tempNumber = tempNumber * lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
            }
        }

        // 50 + 5% (2.5) = 52.5
        // 80 + 10% (8) = 88


        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
                         
        }
            
            
        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }


        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
               
                resultLabel.Content = "0";
            }

            if (sender == multiplyButton)
                selectedOperator = SelectedOperator.Multiplication;
            if (sender == divisionButton)
                selectedOperator = SelectedOperator.Division;
            if (sender == plusButton)
                selectedOperator = SelectedOperator.Addition;
            if (sender == differenceButton)
                selectedOperator = SelectedOperator.Sustraction;

        }


        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if(!resultLabel.Content.ToString().Contains("."))
            resultLabel.Content = $"{resultLabel.Content}.";
        }


        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = Convert.ToInt32((sender as Button).Content);

            

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedValue}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
        
        

    }

    public enum SelectedOperator
    {
        Addition, 
        Sustraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Sustraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiplication(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Division(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
                       
            return n1 / n2;
            
            
        }
    }
}

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

namespace HW._6._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double[] operandsArray = new double[2];
        int operandsIterator = 0;

        private int[] operatorsArray = new int[2];
        int operatorsIterator = 0;

        string Text;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Buttons 0, 1 ,2 ,3 ,4 ,5 ,6 ,7 ,8 ,9 ,,
        private void Buttons_Click_1(object sender, RoutedEventArgs e)
        {
            Button HandlerButton = sender as Button;

            Text += HandlerButton.Content;
            BigText.Text += HandlerButton.Content;
        }

        // Button =
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(operatorsArray[0] == 3)
            {
                operandsArray[0] *= -1;
            }
            SmallText.Text = BigText.Text;

            double buf = 0;
            switch (operatorsArray[1])
            {
                case 1:  // /
                    buf = operandsArray[0] / operandsArray[1];
                    break;
                case 2:  // *
                    buf = operandsArray[0] * operandsArray[1];
                    break;
                case 3:  // -
                    buf = operandsArray[0] - operandsArray[1];
                    break;
                case 4:  // +
                    buf = operandsArray[0] + operandsArray[1];
                    break;
            }
            BigText.Text = Convert.ToString(buf);
        }

        // Button C
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string newStr = BigText.Text;
            int j = BigText.Text.Length;
            BigText.Text = "";

            for (int i = 0; i < j-1; i++)
            {
                BigText.Text += newStr[i];
            }
        }

        // Button CE
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BigText.Text = "";
            SmallText.Text = "";

            Text = "";

            operandsArray = new double[41];
            operandsIterator = 0;

            operatorsArray = new int[40];
            operatorsIterator = 0;
        }

        // Button /, *, -, +
        private void Buttons_Click_2(object sender, RoutedEventArgs e)
        {
            Button HandlerButton = sender as Button;

            operandsArray[operandsIterator] = Convert.ToDouble(Text);
            operandsIterator++;

            switch(HandlerButton.Content)
            {
                case '/':
                    operatorsArray[operatorsIterator] = 1;
                    break;
                case '*':
                    operatorsArray[operatorsIterator] = 2;
                    break;
                case '-':
                    operatorsArray[operatorsIterator] = 3;
                    break;
                case '+':
                    operatorsArray[operatorsIterator] = 4;
                    break;
            }
            operatorsIterator++;

            BigText.Text += HandlerButton.Content;
        }
    }
}

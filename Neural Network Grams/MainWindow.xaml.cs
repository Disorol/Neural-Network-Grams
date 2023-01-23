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

namespace Neural_Network_Grams
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            var neuron = Neuron.GetNeuron();
            TextBlock1.Text = neuron.RestoreInputData(decimal.Parse(TextBox1.Text)).ToString() + " кг";
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            var neuron = Neuron.GetNeuron();
            TextBlock2.Text = neuron.ProcessInputData(decimal.Parse(TextBox2.Text)).ToString() + " г";
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            var neuron = Neuron.GetNeuron();
            do
            {
                neuron.Train(decimal.Parse(TextBox4.Text), decimal.Parse(TextBox3.Text));
                Console.WriteLine(neuron.LastError);
            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);
            TextBlock3.Text = "Нейрон обучен!";
        }
    }
}

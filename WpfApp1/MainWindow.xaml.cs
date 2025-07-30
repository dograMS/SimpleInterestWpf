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

namespace WpfApp1
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

        private void OnBtnClear(object sender, RoutedEventArgs e)
        {
            tb_principle.Text = "";
            tb_interest_rate.Text = "";
            tb_no_year.Text = "";

            lb_interest_amount.Content = "0.0";
            lb_total_amount.Content = "0.0";
        }

        private void OnBtnCalc(object sender, RoutedEventArgs e)
        {
            double principle = 0.0;
            double rate = 0.0;
            double time = 0.0;

            try
            {
                principle = int.Parse(tb_principle.Text);
                rate = int.Parse(tb_interest_rate.Text);
                time = int.Parse(tb_no_year.Text);
                double interest_amount = principle * rate * time /100;

                lb_interest_amount.Content = interest_amount.ToString();
                lb_total_amount.Content = (interest_amount + principle).ToString();

                
            }
            catch (Exception){

            }
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

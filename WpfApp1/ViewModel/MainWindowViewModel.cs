using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using WpfApp1.MVVM;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

        }

        private string principle;

        public string Principle
        {
            get { return principle; }
            set {
                try
                {
                    principle = value;
                }catch(Exception e)
                {
                    principle = "";
                }
                OnPropertyChanged();
            }
        }

        private string interest;

        public string Interest
        {
            get { return interest; }
            set { interest = value;
                OnPropertyChanged();
            }
        }

        private string year;

        public string Year
        {
            get { return year; }
            set { year = value;
                OnPropertyChanged();
            }
        }

        private string interestAmount = "-";

        public string InterestAmount
        {
            get { return interestAmount; }
            set { interestAmount = value;
                OnPropertyChanged();
            }
        }

        private string totalAmount = "-";

        public string TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CalcCommand => new RelayCommand(
            execute => { CalcAmount(); },
            canExecute => { return true; }
            );

        public RelayCommand ClearCommand => new RelayCommand(
            execute => { ClearFields(); },
            canExecute => { return true; }
            );

        private void CalcAmount()
        {
           
            double p = 0.0, r = 0.0, t = 0.0;

            try
            {
                p = double.Parse(Principle);
                r = double.Parse(Year);
                t = double.Parse(Interest);
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show("Please Enter Valid Data!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ClearFields();
                return;
            }

            InterestAmount = (p * r * t/100).ToString();
            TotalAmount = (double.Parse(InterestAmount) + double.Parse(Principle)).ToString();

            TotalAmount = "₹" + TotalAmount;
            InterestAmount = "₹" + InterestAmount;
        }

        private void ClearFields()
        {
            Principle = "";
            Year = "";
            Interest = "";
            InterestAmount = "-";
            TotalAmount = "-";
        }
    }
}

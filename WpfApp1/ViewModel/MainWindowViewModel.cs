using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.MVVM;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

        }

        private double principle;

        public double Principle
        {
            get { return principle; }
            set {
                principle = value;
                OnPropertyChanged();
            }
        }

        private double interest;

        public double Interest
        {
            get { return interest; }
            set { interest = value;
                OnPropertyChanged();
            }
        }

        private double year;

        public double Year
        {
            get { return year; }
            set { year = value;
                OnPropertyChanged();
            }
        }

        private double interestAmount;

        public double InterestAmount
        {
            get { return interestAmount; }
            set { interestAmount = value;
                OnPropertyChanged();
            }
        }

        private double totalAmount;

        public double TotalAmount
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
            InterestAmount = Principle * Year * Interest / 100;
            TotalAmount = InterestAmount + Principle;
        }

        private void ClearFields()
        {
            Principle = 0;
            Year = 0;
            Interest = 0;
            InterestAmount = 0;
            TotalAmount = 0;
        }
    }
}

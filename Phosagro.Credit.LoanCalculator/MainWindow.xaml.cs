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

namespace Phosagro.Credit.LoanCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            list.Items.Add("Аннуитетный");
            list.Items.Add("Дифференцированный");
        }

        private void btn(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(tbSum.Text, out double sum) &&
                double.TryParse(tbRate.Text, out double annualRate) &&
                int.TryParse(tbMonth.Text, out int months) &&
                double.TryParse(tbDown.Text, out double downPayment)
                )
            {
                Credit credit;
                if (tbDown.Text == null)
                {
                    credit = new Credit(sum, annualRate, months);
                }
                else {
                   credit = new Mortgage(sum, annualRate, months, downPayment);
                
                }

                List<double> paymentPlan;
                string select = list.SelectedItem.ToString();
                if (select == "Аннуитетный")
                {
                    
                    paymentPlan = credit.AnnuityPayment();
                }
                else
                {
                    paymentPlan = credit.DifferentiatedPayment();
                }

                tbResult.Text = $"{paymentPlan[0]:F2}"; ;
                tbResult2.Text = $"{paymentPlan[1]:F2}"; ;
            }
            
            else
            {
               
            }
        }
    }
}

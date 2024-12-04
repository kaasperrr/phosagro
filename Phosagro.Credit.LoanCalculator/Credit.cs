using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Phosagro.Credit.LoanCalculator
{
    internal class Credit
    {
        private double _sum, _annualRate, _monthRate, _monthlyPayment, _overpaymentMonth, _overpaymentSum, creditBody, _fixed, _sumMonthlyPayment;
        private int _months;

        public Credit(double sum, double annualRate, int months)
        {
            _sum = sum;
            _annualRate = annualRate;
            _months = months;
            _monthRate = _annualRate / 12 / 100;
            creditBody = sum;
            _overpaymentSum = 0;
            _sumMonthlyPayment = 0;
        }

        public virtual List<double> AnnuityPayment()
        {

            _monthlyPayment = _sum * (_monthRate * Math.Pow(1 + _monthRate, _months) / (Math.Pow(1 + _monthRate, _months) - 1));
            List<double> annuityPayment = new List<double>();

            for (int i = 0; i < _months; i++)
            {
                //double[] table = new double[3];
                _overpaymentMonth = creditBody * _monthRate;
                creditBody -= _monthlyPayment - _overpaymentMonth;
                _overpaymentSum += _overpaymentMonth;
                _sumMonthlyPayment += _monthlyPayment;

            }
            annuityPayment.Add(_sumMonthlyPayment);
            annuityPayment.Add(_overpaymentSum);
            return annuityPayment;

        }


        public virtual List<double> DifferentiatedPayment()
        {
            _fixed = _sum / _months;
            List<double> differentiatedPayment = new List<double>();
            for (int i = 0; i < _months; i++)
            {
                //double[] table = new double[3];
                _overpaymentMonth = creditBody * _monthRate;
                _monthlyPayment = _fixed + _overpaymentMonth;
                creditBody -= _fixed;
                _overpaymentSum += _overpaymentMonth;
                _sumMonthlyPayment += _monthlyPayment;

                //table[0] = _monthlyPayment;
                //table[1] = _overpaymentMonth;
                //table[2] = creditBody;

            }
            differentiatedPayment.Add(_sumMonthlyPayment);
            differentiatedPayment.Add(_overpaymentSum);
            return differentiatedPayment;

        }
    }
}

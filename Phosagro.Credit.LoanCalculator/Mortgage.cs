using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phosagro.Credit.LoanCalculator
{
    internal class Mortgage : Credit
    {
        private double _downPayment;
       
        public Mortgage(double sum, double annualRate, int months, double downPayment)
            : base(sum - downPayment, annualRate, months)
        {
            
            _downPayment = downPayment;
        }

    }
}

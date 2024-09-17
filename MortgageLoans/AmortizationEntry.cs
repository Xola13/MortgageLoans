using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoans
{
    internal class AmortizationEntry
    {
        public double Payment { get; set; }
        public double Principal { get; set; }
        public double Interest {  get; set; }
        public double RemainingBalance { get; set; }
    }
}

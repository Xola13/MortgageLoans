using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLoans
{
    internal class MortgageCalculator
    {
        public double LoanAmount {  get; set; }
        public double AnualInterestRate {  get; set; }
        public int LoanTermYears {  get; set; }


        public MortgageCalculator(double loanAmount, double anualInterestRate, int loanTermYears)
        {
            LoanAmount = loanAmount;
            AnualInterestRate = anualInterestRate;
            LoanTermYears = loanTermYears;
        }

        // Monthly Repayment Function

        public double CalculatorMonthlyRepayment()
        {
            double monthlyRate = AnualInterestRate / 100 / 12;
            int numberOfPayments = LoanTermYears * 12;
            return LoanAmount * monthlyRate / (1 - Math.Pow(1 + monthlyRate, - numberOfPayments));
        }

        // Total Interest Calculation Function

        public double CalculateTotalInterest() 
        {
            double monthlyPayment = CalculatorMonthlyRepayment();
            int numberOfPayments = LoanTermYears * 12;
            return (monthlyPayment * numberOfPayments) - LoanAmount;
        }

        // Total Amount Paid Function

        public double CalculateTotalAmountPaid()
        {
            return CalculatorMonthlyRepayment() * LoanTermYears * 12;
        }

        // Amortization Creation Schedule Function

        public List<AmortizationEntry> GenerateAmortizationEntries()
        {
            double monthlyPayment = CalculatorMonthlyRepayment();
            double monthlyRate = (AnualInterestRate / 100) / 12;
            double remainingPrincipal = LoanAmount;

            var schedule = new List<AmortizationEntry>();

			int totalMonths = LoanTermYears * 12;

			for (int i = 0; i < LoanTermYears; i++) 
            {
                double interestPayment = remainingPrincipal * monthlyRate;
                double principalPayment = monthlyPayment - interestPayment;

				if (remainingPrincipal < monthlyPayment)
				{
					principalPayment = remainingPrincipal;
					monthlyPayment = principalPayment + interestPayment;
				}

				remainingPrincipal -= principalPayment;

                schedule.Add(new AmortizationEntry
                {
                    
                    Payment = monthlyPayment,
                    Interest = interestPayment,
                    Principal = principalPayment,
                    RemainingBalance = Math.Max(remainingPrincipal, 0)
                });
            }
            return schedule;
        }
    }
}
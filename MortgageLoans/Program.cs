using System;

namespace MortgageLoans
{
    class  Program
    {
        static void Main(string[] args) 
        {
            // PROMPTS OF USER INPUTS

            Console.Write("Enter the loan amount: ");
            double loanAmount = double.Parse(Console.ReadLine());

            Console.Write("Enter the annual interest rate: ");
            double annualInterestRate = double.Parse(Console.ReadLine());

            Console.Write("Enter the loan term in years: ");
            int loanTermYears = int.Parse(Console.ReadLine());


            // CALLING OF CREATED METHODS

            var calculator = new MortgageCalculator(loanAmount, annualInterestRate, loanTermYears);

            double monthlyPayment = calculator.CalculatorMonthlyRepayment();
            Console.WriteLine($"\nMonthly Payment: R{monthlyPayment:F2}");

            double totalInterestPaid = calculator.CalculateTotalInterest();
            Console.WriteLine($"\nTotal interest paid: R{totalInterestPaid:F2}");

            double totalAmountPaid = calculator.CalculateTotalAmountPaid();
            Console.WriteLine($"\nTotal amount paid: R{totalAmountPaid:F2}");


            var schedule = calculator.GenerateAmortizationEntries();
            Console.WriteLine("\nAmortization Schedule: ");
            Console.WriteLine("Payment | \tPrincipal \tInterest \tRemainingBalance");

            foreach (var entry in schedule) 
            {
                Console.WriteLine($"R{entry.Payment:F2} | \tR{entry.Principal:F2} | \tR{entry.Interest:F2} | \tR{entry.RemainingBalance:F2}");
            }
        }
    }
}
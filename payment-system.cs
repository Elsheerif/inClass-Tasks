using System;
using System.Collections.Generic;

interface IPayment
{
    bool ProcessPayment(decimal amount);
    string GetPaymentType();
}
// Bonus: a class can implement more than one interface
interface ILoggable
{
    void Log();
}
class CreditCard : IPayment, ILoggable
{
    public bool ProcessPayment(decimal amount)
    {
        if (amount <= 0)
            return false;
        Console.WriteLine("Processing {0:F2} by credit card.", amount);
        Log();
        return true;
    }
    public string GetPaymentType()
    {
        return "Credit Card";
    }
    public void Log()
    {
        Console.WriteLine("Log: credit card payment processed.");
    }
}
class PayPal : IPayment
{
    public bool ProcessPayment(decimal amount)
    {
        if (amount <= 0)
            return false;
        Console.WriteLine("Processing {0:F2} through PayPal.", amount);
        return true;
    }
    public string GetPaymentType()
    {
        return "PayPal";
    }
}
class BankTransfer : IPayment
{
    public bool ProcessPayment(decimal amount)
    {
        if (amount <= 0)
            return false;

        Console.WriteLine("Processing {0:F2} by bank transfer.", amount);
        return true;
    }
    public string GetPaymentType()
    {
        return "Bank Transfer";
    }
}
class BankAccount
{
    private decimal _balance;
    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException("value", "Balance cant be negative");
            _balance = value;
        }
    }
    public BankAccount(decimal initialBalance = 0)
    {
        Balance = initialBalance;
    }
    public void Deposit(decimal amount, IPayment payment)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("amount", "Deposit must be positive");

        if (payment == null)
            throw new ArgumentNullException("payment");
        if (payment.ProcessPayment(amount))
        {
            Balance += amount;
            Console.WriteLine("Deposited {0:F2} using {1}. Balance: {2:F2}",
                amount, payment.GetPaymentType(), Balance);
        }
        else
        {
            Console.WriteLine("{0} payment failed. Balance: {1:F2}",
                payment.GetPaymentType(), Balance);
        }
    }
}
class PaymentProgram
{static void Main()
    {
        BankAccount account = new BankAccount();
        List<IPayment> payments = new List<IPayment>
        {
            new CreditCard(),
            new PayPal(),
            new BankTransfer()
        };
        foreach (IPayment payment in payments)
        {
            account.Deposit(100m, payment);
            Console.WriteLine();
        }
        Console.WriteLine("Final balance: {0:F2}", account.Balance);
    }
}

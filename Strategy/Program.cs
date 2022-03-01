
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CustomerManager customerManager = new CustomerManager();
customerManager.CreditCalculatorBase = new After2010CreditCalculator();

CustomerManager customerManager2 = new CustomerManager();
customerManager2.CreditCalculatorBase = new Before2010CreditCalculator();

customerManager2.SaveCredit();
customerManager.SaveCredit();

abstract class CreditCalculatorBase
{
    public abstract void Calculate();
}

class Before2010CreditCalculator:CreditCalculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Credit calculated using before 2010");
    }
}

class After2010CreditCalculator : CreditCalculatorBase
{
    public override void Calculate()
    {
        Console.WriteLine("Credit calculated using after 2010");
    }
}

class CustomerManager
{

    public CreditCalculatorBase CreditCalculatorBase { get; set; }
    public void SaveCredit()
    {
        Console.WriteLine("Customer manager business");
        CreditCalculatorBase.Calculate();
    }
}
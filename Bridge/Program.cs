// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Contracts;
using System.Reflection;

Console.WriteLine("Hello, World!");
CustomerManager customerManager= new CustomerManager();
customerManager.MessageSenderBase = new EmailSender();
customerManager.UpdateCustomer();


abstract class MessageSender
{
    public void Save()
    {
        Console.WriteLine("Message saved!");
    }

    public abstract void Send(Body body);
}

internal class Body
{
    public string Tittle { get; set; }
    public string Text { get; set; }
}

class SmsSender:MessageSender
{


    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via SmsSender",body.Tittle);
    }
}

class EmailSender:MessageSender
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via EmailSender",body.Tittle);
    }
}

class CustomerManager
{       
    public MessageSender MessageSenderBase { get; set; }
    public void UpdateCustomer()
    {
        MessageSenderBase.Send(new Body{Tittle = "About Of Course"});
        Console.WriteLine("Customer Updated");
    }
}

class NewCustomerManager:CustomerManager
{
                
}
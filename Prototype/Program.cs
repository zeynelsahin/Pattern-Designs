// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
Customer customer1 = new Customer()
{
    FirstName = "Zeynel", LastName = "Şahin", City = "Trabzon", Id = 1
};

Console.WriteLine(customer1.FirstName);

Customer customer2 = (Customer)customer1.Clone();

customer2.FirstName = "Salih";


Console.WriteLine(customer1.FirstName);

Console.WriteLine(customer2.FirstName);
public abstract class Person
{
    public abstract Person Clone();
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Customer : Person
{
    public string City { get; set; }

    public override Person Clone()
    {
        return (Person) MemberwiseClone();
    }
}

public class Employee : Person
{
    public string Salary { get; set; }

    public override Person Clone()
    {
        return (Person)MemberwiseClone();
    }
}
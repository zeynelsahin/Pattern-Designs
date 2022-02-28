// See https://aka.ms/new-console-template for more information

using System.Collections;

Console.WriteLine("Hello, World!");


Employee zeynel = new Employee
{
    Name = "Zeynel Şahin"
};
Employee muharrem = new Employee
{
    Name = "Muharrrem Şahin"
};

zeynel.AddSubordinate(muharrem);

Employee erkan = new Employee
{
    Name = "Erkan Uluocak"
};
zeynel.AddSubordinate(erkan);

Employee ahmet = new Employee
{
    Name = "Ahmet Şahin"
};

muharrem.AddSubordinate(ahmet);

Console.WriteLine(zeynel.Name);
foreach (Employee manager in zeynel)
{
    Console.WriteLine("  {0}",manager.Name);
    foreach (Employee employee in manager)
    {
        Console.WriteLine("     " +employee.Name);
    }
}
interface IPerson
{
     string Name { get; set; }
}

class Contractor
{
    
}

class Employee:IPerson,IEnumerable<IPerson>
{
    private List<IPerson> _subordinates = new List<IPerson>();

    public void AddSubordinate(IPerson person)
    {
        _subordinates.Add(person);
    }

    public void RemoveSubordinate(IPerson person)
    {
        _subordinates.Remove(person);
    }

    public IPerson GetSubordinate(int index)
    {
        return _subordinates[index];
    }
    public string Name { get; set; }
    public IEnumerator<IPerson> GetEnumerator()
    {
        foreach (var subordinate in _subordinates)
        {
            yield return subordinate;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
ProductManager productManager = new ProductManager();

productManager.Attach(new CustomerObserver());
productManager.UpdatePrice();


class ProductManager
{
    private List<Observer> _observers = new List<Observer>();
    public void UpdatePrice()
    {
        Console.WriteLine("Product price changed");
        Notify();
    }

    public void Attach(Observer observer)
    {
        _observers.Add(observer);
    }
    public void Detach(Observer observer)
    {
        _observers.Remove(observer);
    }

    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }
}


abstract class Observer
{
    public abstract void Update();
}

class CustomerObserver:Observer
{
    public override void Update()
    {
        Console.WriteLine("Message to employee : Product price changed!");
    }
}
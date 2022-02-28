// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

CustomerManager customerManager = new CustomerManager();
customerManager.Save();

class Logging:ILogging
{
    public void Log()
    {
        Console.WriteLine("Logged");
    }
}

internal interface ILogging
{

    void Log();
}

class Caching:ICaching
{
    public void Cache()
    {
        Console.WriteLine("Cached");
    }
}

internal interface ICaching
{
    void Cache();
}

class Authorize:IAuthorize
{
    public void CheckUser()
    {
        Console.WriteLine("Authorized");
    }
}

internal interface IAuthorize
{
    void CheckUser();
}

class Validiton:IValidate
{
    public void Validate()
    {
        Console.WriteLine("Validated");
    }
}

internal interface IValidate
{
    void Validate();
}

class CustomerManager
{
    private CrossCuttingConcernsFacade concerns;
    public CustomerManager()
    {
        concerns= new CrossCuttingConcernsFacade();
    }

    public void Save()
    {
        concerns.Caching.Cache();
        concerns.Logging.Log();
        concerns.Authorize.CheckUser();
        concerns.Validate.Validate();
        Console.WriteLine("Saved");
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validate;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validiton();
        }
    }
}
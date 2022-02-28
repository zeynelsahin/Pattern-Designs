// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ProductManager manager = new ProductManager(new Factory1());
manager.GetAll();

public abstract class Logging
{
    public abstract void Log(string message);
}

public class Log4NetLogeer:Logging
{
    public override void Log(string message)
    {
        Console.WriteLine("Logged with log4net");
    }
}

public class NLogger : Logging
{
    public override void Log(string message)
    {
        Console.WriteLine("Logged with nlogger");
    }
}

public abstract class Caching
{
    public abstract void Cache(string data);
}

public class MemCache : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("Cached with MemCache");
    }
}
public class RedisCache : Caching
{
    public override void Cache(string data)
    {
        Console.WriteLine("Cached with MemCache");
    }
}

public abstract class CrosCuttingConcernsFactory
{
    public abstract Logging CreateLogger();
    public abstract Caching CreateCaching();
}

public class Factory1 : CrosCuttingConcernsFactory
{
    public override Logging CreateLogger()
    {
        return new NLogger();
    }

    public override Caching CreateCaching()
    {
        return new MemCache();
    }
}

public class Factory2 : CrosCuttingConcernsFactory
{
    public override Logging CreateLogger()
    {
        return new Log4NetLogeer();
    }

    public override Caching CreateCaching()
    {
        return new RedisCache();
    }

   
}
public class ProductManager : IProductService
{
    private CrosCuttingConcernsFactory _crosCuttingConcernsFactory;
    private Logging _logging;
    private Caching _caching;
    public ProductManager(CrosCuttingConcernsFactory crosCuttingConcernsFactory)
    {
        _crosCuttingConcernsFactory = crosCuttingConcernsFactory;
        _logging = _crosCuttingConcernsFactory.CreateLogger();
        _caching = _crosCuttingConcernsFactory.CreateCaching();
    }

    public void GetAll()
    {
        _caching.Cache("Data");
        _logging.Log("Deneme");
        Console.WriteLine("Products listed!");
    }
}

public interface IProductService
{
    void GetAll();
}
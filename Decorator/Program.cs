
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var personelCar = new PersonalCare{Make = "BMW",Model = "3.20",HirePrice = 2500};

SpicialOffer spicialOffer = new SpicialOffer(personelCar);
spicialOffer.DiscountPercentage = 10;
Console.WriteLine("Concrate : "+personelCar.HirePrice);
Console.WriteLine("Special Offer: " + spicialOffer.HirePrice);
abstract class CarBase
{
    public abstract string Make { get; set; }
    public abstract string Model { get; set; }
    public abstract int HirePrice { get; set; }
}

class PersonalCare:CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override int HirePrice { get; set; }
}

class ComercialCar:CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override int HirePrice { get; set; }
}

abstract class CarDecoraterBase:CarBase
{
    private CarBase _carBase;

    protected CarDecoraterBase(CarBase carBase)
    {
        _carBase = carBase;
    }
}

class SpicialOffer:CarDecoraterBase
{
    public int DiscountPercentage { get; set; }
    private CarBase _carBase;
    public SpicialOffer(CarBase carBase) : base(carBase)
    {
        _carBase = carBase;
    }

    public override string Make { get; set; }
    public override string Model { get; set; }

    public override int HirePrice
    {
        get
        {
            return _carBase.HirePrice-_carBase.HirePrice*DiscountPercentage/100;
        }
        set
        {

        }
    }
}
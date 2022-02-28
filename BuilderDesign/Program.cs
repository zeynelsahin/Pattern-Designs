// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


ProductDirector productDirector = new ProductDirector();

var builder = new OldCustomerBUilder();
    productDirector.GenerateProduct(builder);

var model = builder.GetModel();

Console.WriteLine(model.Id);

Console.WriteLine(model.CategoryName);
Console.WriteLine(model.ProductName);
Console.WriteLine(model.UnitPrice);
Console.WriteLine(model.DiscountPrice);
Console.WriteLine(model.DiscountApplied);


class ProductViewModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountPrice { get; set; }
    public bool DiscountApplied { get; set; }
}

 abstract class ProductBuilder
 {
     public abstract void GetProductData();
     public abstract void ApplyDiscount();
     public abstract ProductViewModel GetModel();
 }


class NewCustomerBUilder:ProductBuilder
{
    private ProductViewModel model = new ProductViewModel(); 
    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;
    }

    public override void ApplyDiscount()
    {
        model.DiscountPrice = (model.UnitPrice*(decimal)0.90);
        model.DiscountApplied = true;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }
}
class OldCustomerBUilder : ProductBuilder
{
    private ProductViewModel model = new ProductViewModel();
    public override void GetProductData()
    {
        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;
    }

    public override void ApplyDiscount()
    {
        model.DiscountPrice = (model.UnitPrice );
        model.DiscountApplied = false;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }
}

class ProductDirector
{
    public void GenerateProduct(ProductBuilder productBuilder)
    {
        productBuilder.GetProductData();
        productBuilder.ApplyDiscount();
    }
}
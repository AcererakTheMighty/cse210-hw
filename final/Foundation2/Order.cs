public class Product
{
    private string name;
    private string productID;
    private double price;
    private int quantity;

    public Product(string name, string productID, double price, int quantity)
    {
        this.name = name;
        this.productID = productID;
        this.price = price;
        this.quantity = quantity;
    }

    public string Name => name;
    public string ProductID => productID;
    public double Price => price;
    public int Quantity => quantity;

    public double GetTotalCost()
    {
        return price * quantity;
    }
}
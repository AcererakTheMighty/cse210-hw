using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create Address instances
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Elm St", "Vancouver", "BC", "Canada");

        // Create Customer instances
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create Product instances
        Product product1 = new Product("Laptop", "P001", 999.99, 1);
        Product product2 = new Product("Mouse", "P002", 19.99, 2);
        Product product3 = new Product("Keyboard", "P003", 49.99, 1);
        Product product4 = new Product("Monitor", "P004", 199.99, 1);

        // Create Order instances
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        // Display the packing label, shipping label, and total price for each order
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine();

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.CalculateTotalCost():F2}");
    }
}
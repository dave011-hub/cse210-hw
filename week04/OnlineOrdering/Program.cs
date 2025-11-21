using System;

class Program
{
    static void Main(string[] args)
    {

        Address a1 = new Address("Accra", "Tema ", "Lapaz", "School Junction");
        Customer c1 = new Customer("John Walker", a1);

        Order o1 = new Order(c1);
        o1.AddProduct(new Product("Keyboard", "K100", 29.99, 2));
        o1.AddProduct(new Product("Mouse", "M200", 19.99, 1));

        
        Address a2 = new Address("77 Lime Ave", "Toronto", "Ontario", "Canada");
        Customer c2 = new Customer("Maria Lopez", a2);

        Order o2 = new Order(c2);
        o2.AddProduct(new Product("Headphones", "H500", 59.99, 1));
        o2.AddProduct(new Product("Webcam", "W900", 89.99, 1));
        o2.AddProduct(new Product("Microphone", "MIC40", 39.99, 2));

        Console.WriteLine(o1.GetPackingLabel());
        Console.WriteLine(o1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${o1.GetTotalCost()}\n");

        
        Console.WriteLine(o2.GetPackingLabel());
        Console.WriteLine(o2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${o2.GetTotalCost()}");
    }
}


using System.Collections.Generic;
using System.Text;

public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        total += _customer.LivesInUSA() ? 5 : 35;

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL:");

        foreach (Product p in _products)
        {
            sb.AppendLine($"{p.GetName()} (ID: {p.GetId()})");
        }

        return sb.ToString();
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress()}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ferreteria.Classes;

namespace ferreteria.Extensions;

public class Core
{
    List<Client> _Client = new List<Client>()
    {
        new Client() { Id = 101, Name = "Lenin", Email = "lenin@gmail.com" },
        new Client() { Id = 102, Name = "Iker", Email = "iker@gmail.com" },
        new Client() { Id = 103, Name = "Brayan", Email = "brayan@gmail.com" }
    };

    List<DetailInvoice> _DetailInvoice = new List<DetailInvoice>()
    {
        new DetailInvoice() { Id = 201, Quantity = 100, Value = 3000, IdInvoice = 301, IdProduct = new List<int>() { 401, 402 } },
        new DetailInvoice() { Id = 202, Quantity = 200, Value = 4000, IdInvoice = 302, IdProduct = new List<int>() { 402, 403 } },
        new DetailInvoice() { Id = 203, Quantity = 250, Value = 5000, IdInvoice = 303, IdProduct = new List<int>() { 403, 401 } }
    };

    List<Invoice> _Invoice = new List<Invoice>()
    {
        new Invoice() { Id = 301, Date = new DateOnly(2023, 1, 24), Total = 3000, IdClient = 101 },
        new Invoice() { Id = 302, Date = new DateOnly(2023, 2, 14), Total = 4000, IdClient = 102 },
        new Invoice() { Id = 303, Date = new DateOnly(2023, 1, 9), Total = 5000, IdClient = 103 }
    };

    List<Product> _Product = new List<Product>()
    {
        new Product() { Id = 401, Name = "Hammer", Price = 30, Quantity = 3100, StockMin = 100, StockMax = 10000 },
        new Product() { Id = 402, Name = "Screwdriver", Price = 20, Quantity = 4000, StockMin = 100, StockMax = 10000 },
        new Product() { Id = 403, Name = "Sandpaper", Price = 15, Quantity = 7000, StockMin = 100, StockMax = 10000 },
        new Product() { Id = 404, Name = "Gloves", Price = 40, Quantity = 60, StockMin = 100, StockMax = 10000 },
        new Product() { Id = 405, Name = "Screw", Price = 5, Quantity = 90, StockMin = 100, StockMax = 10000 }
    };

    public void GoBack()
    {
        Console.Write("\nPress Enter to go to Main Menu... ");
        Console.ReadKey();
    }

    public void InvalidOption()
    {
        Console.Clear();
        Console.Write("Invalid option... \nPress Enter to go back... ");
        Console.ReadKey();
    }

    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("--- Main Menu ---\n");
        Console.Write("1. Products List \n2. Products Almost Running Out \n3. Products to Buy \n4. January Invoices \n5. Products Sold in an Invoice \n6. Total Inventory \n\n0. Exit \n\nOption: ");
    }

    public void ProductsList()
    {
        Console.Clear();
        var products = _Product.OrderBy(x => x.Id).ToList();
        Console.WriteLine("Products: ");
        products.ForEach(x => Console.WriteLine($"\n- {x.Id} - {x.Name} \n    Price: {x.Price} \n    Quantity: {x.Quantity} \n    Stock Min: {x.StockMin} \n    Stock Max: {x.StockMax}"));
        GoBack();
    }

    public void ProductsRunOut()
    {
        Console.Clear();
        var products = _Product.Where(x => x.Quantity < x.StockMin).ToList();
        Console.WriteLine("Products Almost Running Out: ");
        products.ForEach(x => Console.WriteLine($"\n- {x.Id} - {x.Name}"));
        GoBack();
    }

    public void ProductsToBuy()
    {
        Console.Clear();
        var products = _Product.Where(x => x.Quantity < x.StockMin).ToList();
        Console.WriteLine("Products To Buy: ");
        products.ForEach(x => Console.WriteLine($"\n- {x.Id} - {x.Name} \n    Quantity: {x.Quantity} \n    Price: {x.Price} \n    Buy: {x.StockMax - x.Quantity}"));
        GoBack();
    }

    public void JanuaryInvoices()
    {
        Console.Clear();
        var invoices = _Invoice.Where(x => x.Date.Month.Equals(1)).ToList();
        Console.WriteLine("January Invoices: ");
        invoices.ForEach(x => Console.WriteLine($"\n- {x.Id} \n    Date: {x.Date} \n    Total: {x.Total}"));
        GoBack();
    }

    public void ProductsSold()
    {
        bool loop = true;
        int option = 0;
        while (loop)
        {
            try
            {
                Console.Clear();
                var invoices = _Invoice.ToList();
                Console.WriteLine("--- Invoices ---\n");
                invoices.ForEach(x => Console.WriteLine($"- {x.Id}"));
                Console.Write("\nOption: ");
                option = int.Parse(Console.ReadLine());
                var clause = _Invoice.Where(x => x.Id == option);
                if (clause.Count() == 0)
                {
                    InvalidOption();
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Id Invoice: {_Invoice[option - 301].Id} \n    Date Invoice: {_Invoice[option - 301].Date} \n    Id Client: {_Invoice[option - 301].IdClient} \n    Products Quantity: {_DetailInvoice[option - 301].Quantity} \n    Value Adding Product: {_DetailInvoice[option - 301].Value} \n");
                    foreach (int productId in _DetailInvoice[option - 301].IdProduct)
                    {
                        var p = _Product.Where(x => x.Id == productId);
                        foreach (Product pr in p)
                        {
                            Console.Write($"    Id Product: {pr.Id} \n        Name Product: {pr.Name} \n        Price Product: {pr.Price} \n");
                        }
                    }
                    Console.WriteLine($"    Total Invoice: {_Invoice[option - 301].Total}");
                    GoBack();
                    loop = false;
                }
            }
            catch (Exception)
            {
                InvalidOption();
            }
        }
    }

    public void TotalInventory()
    {
        var total = 0;
        foreach (var p in _Product)
        {
            total += p.Quantity * (int)p.Price;
        }
        Console.Clear();
        Console.WriteLine($"Total Inventory: {total}");
        GoBack();
    }
}
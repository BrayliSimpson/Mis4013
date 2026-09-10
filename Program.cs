List<Product> products = new List<Product>
{
    new Product { Name = "Computer", Category = "Electronics", Price = 19.99, InStock = true },
    new Product { Name = "Apple Watch", Category = "Electronics", Price = 59.99, InStock = true },
    new Product { Name = "Mouse", Category = "Electronics", Price = 8.99, InStock = false },
    new Product { Name = "Bluetooth Speaker", Category = "Electronics", Price = 34.99, InStock = true },
    new Product { Name = "Nike Shoes", Category = "Apparel", Price = 64.99, InStock = true },
    new Product { Name = "Graphic T-Shirt", Category = "Apparel", Price = 15.99, InStock = true },
    new Product { Name = "Puffer Jacket", Category = "Apparel", Price = 89.99, InStock = false },
    new Product { Name = "Throw Pillows", Category = "Home", Price = 42.50, InStock = true },
    new Product { Name = "Small Lamp", Category = "Home", Price = 22.75, InStock = true },
    new Product { Name = "Throw Blanket", Category = "Home", Price = 27.99, InStock = false },
    new Product { Name = "Notebook", Category = "Office", Price = 6.49, InStock = true },
    new Product { Name = "Pens (12-pack)", Category = "Office", Price = 4.99, InStock = true }
};

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("1 - View all products");
    Console.WriteLine("2 - Search products by name");
    Console.WriteLine("3 - Filter products by category");
    Console.WriteLine("4 - Filter products by maximum price");
    Console.WriteLine("5 - Show only products currently in stock");
    Console.WriteLine("6 - Exit");
    Console.WriteLine("Select an option:");

    string choice = Console.ReadLine();

    if (choice == "1")
    {
        DisplayProducts(products);
    }
    else if (choice == "2")
    {
        SearchProducts(products);
    }
    else if (choice == "3")
    {
        FilterByCategory(products);
    }
    else if (choice == "4")
    {
        FilterByPrice(products);
    }
    else if (choice == "5")
    {
        FilterInStock(products);
    }
    else if (choice == "6")
    {
        isRunning = false;
    }
    else
    {
        Console.WriteLine("Invalid option. Please select 1-6.");
    }
}

void DisplayProducts(List<Product> productList)
{
    if (productList.Count == 0)
    {
        Console.WriteLine("No products match your criteria.");
        return;
    }

    Console.WriteLine();
    foreach (Product product in productList)
    {
        string status = product.InStock ? "In Stock" : "Out of Stock";
        Console.WriteLine($"{product.Name} | {product.Category} | {product.Price:C2} | {status}");
    }
}

void SearchProducts(List<Product> productList)
{
    Console.WriteLine("Enter a product name (or part of it) to search:");
    string searchTerm = Console.ReadLine().ToLower();

    List<Product> results = new List<Product>();
    foreach (Product product in productList)
    {
        if (product.Name.ToLower().Contains(searchTerm))
        {
            results.Add(product);
        }
    }

    DisplayProducts(results);
}

void FilterByCategory(List<Product> productList)
{
    Console.WriteLine("Enter a category to filter by:");
    string category = Console.ReadLine().ToLower();

    List<Product> results = new List<Product>();
    foreach (Product product in productList)
    {
        if (product.Category.ToLower() == category)
        {
            results.Add(product);
        }
    }

    DisplayProducts(results);
}

void FilterByPrice(List<Product> productList)
{
    Console.WriteLine("Enter maximum price:");
    string priceInput = Console.ReadLine();
    double maxPrice;
    bool isValidPrice = double.TryParse(priceInput, out maxPrice);

    if (!isValidPrice || maxPrice < 0)
    {
        Console.WriteLine("Invalid price entered.");
        return;
    }

    List<Product> results = new List<Product>();
    foreach (Product product in productList)
    {
        if (product.Price <= maxPrice)
        {
            results.Add(product);
        }
    }

    DisplayProducts(results);
}

void FilterInStock(List<Product> productList)
{
    List<Product> results = new List<Product>();
    foreach (Product product in productList)
    {
        if (product.InStock)
        {
            results.Add(product);
        }
    }

    DisplayProducts(results);
}

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public bool InStock { get; set; }

    public Product()
    {
        Name = string.Empty;
        Category = string.Empty;
        Price = 0;
        InStock = true;
    }
}
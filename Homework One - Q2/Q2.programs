Dictionary<string, double> menu = new Dictionary<string, double>
{
    { "Burger", 10.99 },
    { "Chicken Sandwich", 9.99 },
    { "Salad", 8.49 },
    { "Fries", 3.49 },
    { "Drink", 2.49 }
};

List<string> menuOrder = new List<string> { "Burger", "Chicken Sandwich", "Salad", "Fries", "Drink" };
List<string> order = new List<string>();

bool isOrdering = true;

while (isOrdering)
{
    DisplayMenu(menuOrder, menu);

    Console.WriteLine("Enter the number of the item to add, or 0 when you are finished:");
    string choiceInput = Console.ReadLine();
    int choice;
    bool isValidChoice = int.TryParse(choiceInput, out choice);

    if (!isValidChoice)
    {
        Console.WriteLine("Invalid input. Please enter a number.");
    }
    else if (choice == 0)
    {
        isOrdering = false;
    }
    else
    {
        AddItemToOrder(choice, menuOrder, order);
    }
}

double subtotal = CalculateSubtotal(order, menu);
double discount = subtotal >= 30 ? subtotal * 0.10 : 0;
double tax = (subtotal - discount) * 0.085;
double total = CalculateFinalTotal(subtotal, discount, tax);

Console.WriteLine();
Console.WriteLine("Order Summary");
foreach (string item in order)
{
    Console.WriteLine($"- {item}: {menu[item]:C2}");
}
Console.WriteLine($"Subtotal: {subtotal:C2}");
Console.WriteLine($"Discount: {discount:C2}");
Console.WriteLine($"Tax: {tax:C2}");
Console.WriteLine($"Final Total: {total:C2}");

void DisplayMenu(List<string> items, Dictionary<string, double> prices)
{
    Console.WriteLine();
    Console.WriteLine("Menu:");
    for (int i = 0; i < items.Count; i++)
    {
        string item = items[i];
        Console.WriteLine($"{i + 1} - {item} ({prices[item]:C2})");
    }
}

void AddItemToOrder(int choice, List<string> items, List<string> order)
{
    if (choice >= 1 && choice <= items.Count)
    {
        order.Add(items[choice - 1]);
    }
    else
    {
        Console.WriteLine("Invalid menu selection. Item was not added.");
    }
}

double CalculateSubtotal(List<string> order, Dictionary<string, double> prices)
{
    double subtotal = 0;
    foreach (string item in order)
    {
        subtotal += prices[item];
    }
    return subtotal;
}

double CalculateFinalTotal(double subtotal, double discount, double tax)
{
    return subtotal - discount + tax;
}

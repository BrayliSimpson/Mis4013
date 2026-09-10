Console.WriteLine("What is the order subtotal?");
string subtotalInput = Console.ReadLine();
double subtotal;
bool isValidSubtotal = double.TryParse(subtotalInput, out subtotal);

while (!isValidSubtotal || subtotal <= 0)
{
    Console.WriteLine("Invalid input. Please enter a subtotal greater than $0.");
    subtotalInput = Console.ReadLine();
    isValidSubtotal = double.TryParse(subtotalInput, out subtotal);
}

Console.WriteLine("Are you a rewards member? (yes/no)");
string rewardsInput = Console.ReadLine();
bool isRewardsMember = rewardsInput.ToLower() == "yes";

Console.WriteLine("Select a shipping method:");
Console.WriteLine("1 - Standard");
Console.WriteLine("2 - Two-Day");
Console.WriteLine("3 - Overnight");
string methodInput = Console.ReadLine();
int shippingMethod;
bool isValidMethod = int.TryParse(methodInput, out shippingMethod);

while (!isValidMethod || shippingMethod < 1 || shippingMethod > 3)
{
    Console.WriteLine("Invalid selection. Please enter 1, 2, or 3.");
    methodInput = Console.ReadLine();
    isValidMethod = int.TryParse(methodInput, out shippingMethod);
}

double shippingCost = CalculateShipping(subtotal, shippingMethod, isRewardsMember);
double finalTotal = subtotal + shippingCost;

Console.WriteLine();
Console.WriteLine($"Order Subtotal: {subtotal:C2}");
Console.WriteLine($"Shipping Method: {GetShippingMethodName(shippingMethod)}");
Console.WriteLine($"Shipping Cost: {shippingCost:C2}");
Console.WriteLine($"Final Order Total: {finalTotal:C2}");

double CalculateShipping(double orderSubtotal, int method, bool rewardsMember)
{
    double cost = 0;

    if (orderSubtotal <= 0)
    {
        throw new Exception("Shipping cannot be calculated for an order subtotal less than or equal to $0.");
    }

    if (method == 1)
    {
        cost = orderSubtotal >= 75 ? 0 : 5.99;
    }
    else if (method == 2)
    {
        cost = 12.99;
        if (rewardsMember)
        {
            cost = cost * 0.80;
        }
    }
    else if (method == 3)
    {
        cost = 24.99;
        if (rewardsMember)
        {
            cost = cost * 0.80;
        }
    }
    else
    {
        throw new Exception("The shipping method must be valid.");
    }

    return cost;
}

string GetShippingMethodName(int method)
{
    string name = "Unknown";

    if (method == 1)
    {
        name = "Standard";
    }
    else if (method == 2)
    {
        name = "Two-Day";
    }
    else if (method == 3)
    {
        name = "Overnight";
    }

    return name;
}

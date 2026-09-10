Console.WriteLine("First name:");
string firstName = Console.ReadLine();

Console.WriteLine("Last name:");
string lastName = Console.ReadLine();

Console.WriteLine("Email address:");
string email = Console.ReadLine();

Console.WriteLine("Password:");
string password = Console.ReadLine();

Console.WriteLine("Confirm password:");
string confirmPassword = Console.ReadLine();

Console.WriteLine("Age:");
string ageInput = Console.ReadLine();
int age;
bool isValidAgeNumber = int.TryParse(ageInput, out age);

List<string> errors = new List<string>();

if (string.IsNullOrWhiteSpace(firstName))
{
    errors.Add("First name cannot be blank.");
}

if (string.IsNullOrWhiteSpace(lastName))
{
    errors.Add("Last name cannot be blank.");
}

if (!IsValidEmail(email))
{
    errors.Add("Email address is invalid.");
}

if (!MeetsLengthRequirement(password))
{
    errors.Add("Password must be at least 8 characters long.");
}

if (!MeetsUppercaseRequirement(password))
{
    errors.Add("Password must contain an uppercase letter.");
}

if (!MeetsNumberRequirement(password))
{
    errors.Add("Password must contain at least one number.");
}

if (password != confirmPassword)
{
    errors.Add("Passwords do not match.");
}

if (!isValidAgeNumber || age < 18)
{
    errors.Add("You must be at least 18 years old to register.");
}

if (errors.Count == 0)
{
    Console.WriteLine();
    Console.WriteLine("Account Successfully Created!");
    Console.WriteLine();
    Console.WriteLine($"Welcome, {firstName} {lastName}!");
}
else
{
    Console.WriteLine();
    Console.WriteLine("Registration Failed");
    Console.WriteLine();
    foreach (string error in errors)
    {
        Console.WriteLine($"- {error}");
    }
}

bool IsValidEmail(string? email)
{
    bool hasAtSymbol = email.Contains("@");
    bool hasPeriod = email.Contains(".");
    bool isLongEnough = email.Length >= 6;

    return hasAtSymbol && hasPeriod && isLongEnough;
}

bool MeetsLengthRequirement(string? password)
{
    bool isValid = false;

    if (password.Length >= 8)
    {
        isValid = true;
    }

    return isValid;
}

bool MeetsUppercaseRequirement(string? password)
{
    bool isValid = false;

    foreach (var character in password)
    {
        if (char.IsUpper(character) == true)
        {
            isValid = true;
            break;
        }
    }

    return isValid;
}

bool MeetsNumberRequirement(string? password)
{
    bool isValid = false;

    foreach (var character in password)
    {
        if (char.IsDigit(character) == true)
        {
            isValid = true;
            break;
        }
    }

    return isValid;
}

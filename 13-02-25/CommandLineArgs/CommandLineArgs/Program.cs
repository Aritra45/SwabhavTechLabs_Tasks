internal class Program
{
    private static void Main(string[] args)
    {
        string Name = args[0];
        int Age = Convert.ToInt32(args[1]);
        string Address = args[2];
        long PhoneNumber = Convert.ToInt64(args[3]);
        Console.WriteLine($"Details of {args[0]}:->");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Address: {Address}");
        Console.WriteLine($"Phone Number: {PhoneNumber}");
    }
}

/* 1st to program ta likhbo then right e "CommandLineAgrs" nam tar upor right click kore properties e jete hobe 
 then left e debug lekha tay jete hobe then "open debug launch profiles UI" link tay click korte hobe then
comment line arguments er j box ta ache okhene values gulo dite hobe space diye ebar run korte hobe program ta
 */
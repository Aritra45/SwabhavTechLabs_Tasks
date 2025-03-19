using MutableAndImmutable;

internal class Program
{
    private static void Main(string[] args)
    {
        MutableAndImmutablePerson person = new MutableAndImmutablePerson("Aritra", "Deb", 23);
        Console.WriteLine($"Before Name: {person.Name} Surname: {person.Surname} Age: {person.Age}");
        Console.WriteLine(" ");

        person.Age = 24;
        Console.WriteLine($"After Name: {person.Name} Surname: {person.Surname} Age: {person.Age}");
    }
}
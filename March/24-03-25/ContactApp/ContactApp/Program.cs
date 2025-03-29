using ContactApp;
using ContactApp.Database;
using ContactApp.Model;

internal class Program
{
    public static void AddUser()
    {
        using (var context = new MyContext()) // Create DbContext instance
        {
            // Define the new user
            User newUser = new User
            {
                Name = "Aritra",
                IsAdmin = true, // true for Admin, false for Staff
                IsActive = true,
            };

            // Add the user to the DbSet
            context.User.Add(newUser);

            // Save changes to the database
            context.SaveChanges();

            Console.WriteLine("User added successfully!");
        }
    }
    private static void Main(string[] args)
    {
        //AddUser();
        ContactApplication contactApp = new ContactApplication();
        contactApp.TakeInput();

    }
  
}
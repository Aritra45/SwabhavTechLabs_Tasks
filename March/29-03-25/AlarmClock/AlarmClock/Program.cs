using System;

internal class Program
{
    private static void Main(string[] args)
    {
        DateTime currentTime = DateTime.Now;
        Console.WriteLine($"Current Date and Time: {currentTime:yyyy-MM-dd HH:mm:ss}");
        Console.Write("Enter Your Time Increment: ");
        int time = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Unit (HH/MM/SS): ");
        string unit = Console.ReadLine().ToUpper();
        DateTime alarm = currentTime;

        if (unit == "MM")
        {
            if (time >= 0 && time <= 59)
            {
                alarm = alarm.AddMinutes(time);
                Console.WriteLine($"Alarm Date and Time: {alarm:yyyy-MM-dd HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Invalid minute value. Enter a value between 0 and 59.");
            }
        }
        else if (unit == "HH")
        {
            if (time >= 0 && time <= 23)
            {
                alarm = alarm.AddHours(time);
                Console.WriteLine($"Alarm Date and Time: {alarm:yyyy-MM-dd HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Invalid hour value. Enter a value between 0 and 23.");
            }
        }
        else if (unit == "SS")
        {
            if (time >= 0 && time <= 59)
            {
                alarm = alarm.AddSeconds(time);
                Console.WriteLine($"Alarm Date and Time: {alarm:yyyy-MM-dd HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Invalid second value. Enter a value between 0 and 59.");
            }
        }
        else
        {
            Console.WriteLine("Invalid unit. Please enter HH, MM, or SS.");
        }
    }
}
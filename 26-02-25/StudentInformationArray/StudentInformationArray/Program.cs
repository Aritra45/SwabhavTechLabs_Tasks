using StudentInformationArray.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Student[] details = new Student[100];
        bool isAddMore = true;
        int index = 0;
        while (isAddMore)
        {
            Console.WriteLine("Enter Name of the Student");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Age of the Student");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Roll of the Student");
            int roll = Convert.ToInt32(Console.ReadLine());

            //Student student;
            if (index < 100)
            {
                details[index] = new Student(name, age, roll);
                index++;
            }
            else
            {
                Console.WriteLine ("Array Full");
            }
            Console.WriteLine("Wanna Add One More Student");
            string response = "";
            bool isInvalid = true;
            
            while (isInvalid)
            {
                if (response != "Y" || response != "N")
                {
                    response = Console.ReadLine().ToUpper();
                    if (response == "Y")
                    {
                        isAddMore = true;
                        break;
                    }
                    else if (response == "N")
                    {
                        isAddMore = false;
                        break;
                    }
                    else if (response != "Y" || response != "N")
                    {
                        Console.WriteLine("Invalid");
                        isInvalid = true;  
                    }
                }
            }
            
        }
        foreach (Student student in details)
        {
            if (student == null)
            {
                break;
            }
            else
            {
                Console.WriteLine(student.Name);
                Console.WriteLine(student.Age);
                Console.WriteLine(student.Roll);
            }
        }






        //Student s01 = new Student("Aritra",23, 01);
        //Student s02 = new Student("Abhishek", 21, 02);
        //Student[] detail = { s01, s02 };
        //foreach (Student student in detail) { 
        //    Console.WriteLine(student.Name);
        //    Console.WriteLine(student.Age);
        //    Console.WriteLine(student.Roll);
        //}
    }
}
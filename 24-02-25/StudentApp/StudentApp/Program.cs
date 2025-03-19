using System.Xml.Linq;
using StudentApp.Model;

internal class Program
{
   
    private static void Main(string[] args)
    {
        //Student s = new Student();
        bool calculateAgain = true;
        Console.WriteLine("!!!Welcome!!!");
        while (calculateAgain)
        {
            while (true)
            {
                string[] rangeForName = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
                bool isInvalidName = true;
                string name = "";
                while (isInvalidName)
                {
                    Console.Write("Enter Name: ");
                    name = Console.ReadLine().ToUpper();
                    foreach (char c in name)
                    {
                        for (int i = 0; i < rangeForName.Length; i++)
                        {
                            if (rangeForName[i] == c.ToString())
                            {
                                isInvalidName = false;
                                break;
                            }
                            else
                            {
                                isInvalidName = true;
                            }
                        }
                        if (isInvalidName)
                        {
                            Console.WriteLine("!!!Invalid Name!!!");
                            break;
                        }
                    }
                    if (name.Length < 5)
                    {
                        name = " ";
                    }

                }
                //s.StudentName(name);

                string[] rangeForRoll = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                bool isInvalidRoll = true;
                string rollNo = "";
                while (isInvalidRoll)
                {
                    Console.Write("Enter Roll: ");
                    rollNo = Console.ReadLine();
                    foreach (char c in rollNo)
                    {
                        for (int i = 0; i < rangeForRoll.Length; i++)
                        {
                            if (rangeForRoll[i] == c.ToString())
                            {
                                isInvalidRoll = false;
                                break;
                            }
                            else
                            {
                                isInvalidRoll = true;
                            }
                        }
                        if (isInvalidRoll)
                        {
                            Console.WriteLine("!!!Invalid Roll!!! Roll number must be Possitive.");
                            break;
                        }
                    }
                }
                int roll = Convert.ToInt32(rollNo);

                string[] rangeForCgpa = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "." };
                bool isInvalidCgpa = true;
                string cgpaNo = "";
                double cgpa = 0;
                while (isInvalidCgpa)
                {
                    Console.Write("Enter Cgpa: ");
                    cgpaNo = Console.ReadLine();
                    if ('.' != cgpaNo[0])
                    {
                        foreach (char c in cgpaNo)
                        {
                            for (int i = 0; i < rangeForCgpa.Length; i++)
                            {
                                if (rangeForCgpa[i] == c.ToString())
                                {
                                    isInvalidCgpa = false;
                                    break;
                                }
                                else
                                {
                                    isInvalidCgpa = true;
                                }
                            }
                            if (isInvalidCgpa)
                            {
                                Console.WriteLine("!!!Invalid Cgpa!!!");
                                break;
                            }
                            else
                            {
                                cgpa = Convert.ToDouble(cgpaNo);
                            }
                        }
                        if (cgpa < 1 || cgpa > 10)
                        {
                            Console.WriteLine("CGPA: Invalid CGPA. CGPA must be in the range of 1 to 10.");
                            isInvalidCgpa = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("!!!Invalid Cgpa!!!");
                    }
                    
                    
                }


                //s.StudentCgpa(cgpa);
                Student s = new Student(name, cgpa, roll);
                Console.WriteLine("\nPercentage Details & Percentage");
                Console.WriteLine($"Name: {s.Name}");

                Console.WriteLine($"Roll No: {s.Roll}");

                Console.WriteLine($"Cgpa: {s.Cgpa}");

                Console.WriteLine($"percentage: {s.Persentage}");

                break;
            }
            Console.WriteLine("Would You Like To Calculate Again?(Y/N)");
            string response = "";
            bool isInvalidResponse = true;
            while (isInvalidResponse) {
                while (response != "Y" && response != "N")
                {
                    isInvalidResponse = false;
                    response = Console.ReadLine().ToUpper();
                    Console.WriteLine(" ");
                    if (response == "Y")
                    {
                        calculateAgain = true;
                        break;
                    }
                    else if (response == "N")
                    {
                        Console.WriteLine("!!!Bye!!!");
                        calculateAgain = false;
                        break;
                    }
                    else if (response != "Y" && response != "N")
                    {
                        Console.WriteLine("Invalid response. Please Choose between Y or N");
                        isInvalidResponse=true;
                    }
                }
            }
        }
    }
}
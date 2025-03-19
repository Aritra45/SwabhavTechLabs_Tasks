using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Configuration;
using StudentAppUsingDB.Model;

namespace StudentAppWithDB
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            studentManager.ChooseMenu();
        }

        
    }
}

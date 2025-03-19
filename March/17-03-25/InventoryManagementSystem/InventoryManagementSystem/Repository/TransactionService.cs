using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Repository
{
    internal interface TransactionService
    {
        public void ChooseMenu();
        public void Add_Stock(SqlConnection connection);
        public void Delete_Stock(SqlConnection connection);
        public void ViewAllDetails(SqlConnection connection);
    }
}

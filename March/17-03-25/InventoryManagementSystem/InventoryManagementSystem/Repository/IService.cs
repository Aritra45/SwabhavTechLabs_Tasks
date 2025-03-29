using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace InventoryManagementSystem.Repository
{
    internal interface IService
    {
        public void ChooseMenu();
        public void Add(SqlConnection connection);

        public void Update(SqlConnection connection);

        public void Delete(SqlConnection connection);
        public void ViewSpecificDetails(SqlConnection connection);

    }
}

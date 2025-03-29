using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeMethodDesignPatterns.Repository;

namespace CompositeMethodDesignPatterns.Service
{
    internal class Files : I_FileSystem
    {
        private decimal Size {  get; set; }
        public Files(decimal size)
        {
            Size = size;
        }
        public decimal GetSize()
        {
            return Size;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeMethodDesignPatterns.Repository;

namespace CompositeMethodDesignPatterns.Service
{
    internal class Folder : I_FileSystem
    {
        private List<I_FileSystem> children = new List<I_FileSystem>();
        decimal Size {  get; set; }
        public Folder() { }
        public Folder(decimal size)
        {
            Size = size;
        }
        public decimal GetSize()
        {
            decimal size = 0;
            foreach (I_FileSystem child in children)
            {
                size += child.GetSize();
            }
            return Size + size;
        }
        public void AddChild(I_FileSystem element)
        {
            children.Add(element);
        }
    }
}

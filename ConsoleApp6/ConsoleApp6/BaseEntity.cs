using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class BaseEntity
    {
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}

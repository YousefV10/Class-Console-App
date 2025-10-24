using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Rectangle
    {

         public float Length;
        public float Width; 


        public Rectangle (float length , float width)
        {
            if (length <=0 || width <= 0)
            {
                Length = 1;
                Width = 1;
                Console.WriteLine("Teref menfi ola bilmez ");
            }
            else
            {
                Length = length;
                Width = width; 
            }

            Console.WriteLine("Rengi daxil edin ");
            string color = Console.ReadLine(); 

            Shape shape = new Shape(color); 


        }
    }
}

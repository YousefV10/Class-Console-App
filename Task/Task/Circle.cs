

using System.Globalization;

namespace Task
{
    internal class Circle
    {
       public  float Radius; 
        public Circle (float radius)
        {
            if (radius <=0)
            {
                Radius = 1; 
            }

            else
            {
                Radius = radius;  
            }

                Console.WriteLine("Enter the Colour ");
            string colour = Console.ReadLine();


            Shape shape = new Shape(colour);


            float area = float.Pi * Radius * Radius;

            Console.WriteLine(area);


        }


    }
}

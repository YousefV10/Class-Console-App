

namespace Task
{
    internal class Shape
    {
        public string Colour;
        public float Area;

        public Shape(string shapeColour)
        {

            Colour = shapeColour;

        }


        public void GetInfo()
        {
            Console.WriteLine(Area );
            Console.WriteLine(Colour);
        }

    }
}

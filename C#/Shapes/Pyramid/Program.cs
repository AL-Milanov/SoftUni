namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape pyramid = new Pyramid(4);
            Shape rectangle = new Rectangle(4, 5);

            rectangle.Draw();
            pyramid.Draw();
        }
    }
}

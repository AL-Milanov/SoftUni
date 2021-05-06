namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape pyramid = new Pyramid(4);
            Shape rectangle = new Rectangle(6);

            rectangle.Draw();
            pyramid.Draw();
        }
    }
}

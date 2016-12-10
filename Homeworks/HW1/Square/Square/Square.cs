namespace Square
{
    public class Square
    {
        private int length;
        public Square(int a)
        {
            length = a;
        }
        public int Perimeter()
        {
            return length * 4;
        }
        public int Area()
        {
            return length * length;
        }
    }
}

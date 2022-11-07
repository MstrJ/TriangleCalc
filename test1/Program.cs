
interface IFigure
{
    double Area();
    double Perimeter();
}

interface IPointMovement
{
    void MoveUp();
    void MoveDown();
    void MoveLeft();
    void MoveRight();
}
class PointCenter : IPointMovement
{
    public int x;
    public int y;
    int yMove;
    int xMove;

    public PointCenter(int x, int y)
    {
        this.x = x;
        this.y = y;
        yMove = 0;
        xMove = 0;
    }
    public PointCenter(int x, int y, int yMove, int xMove)
    {
        this.x = x;
        this.y = y;
        this.yMove = yMove;
        this.xMove = xMove;
    }
    public void MoveUp()
    {
        y += yMove;
    }
    public void MoveDown()
    {
        y -= yMove;
    }
    public void MoveLeft()
    {
        x -= xMove;
    }
    public void MoveRight()
    {
        x += xMove;
    }

    public void View()
    {
        Console.WriteLine($"x: {x}, y: {y}\t xMove: {xMove}, yMove: {yMove}");
    }
}

class Triangle : IFigure
{
    PointCenter punktA;
    PointCenter punktB;
    PointCenter punktC;

    double bokAB;
    double bokBC;
    double bokCA;
    public Triangle(PointCenter punktA, PointCenter punktB, PointCenter punktC)
    {
        this.punktA = punktA;
        this.punktB = punktB;
        this.punktC = punktC;
    }
    public void Boki()
    {
        bokAB = Math.Sqrt(Math.Pow((punktA.x - punktB.x), 2) + Math.Pow((punktA.y - punktB.y), 2));
        bokBC = Math.Sqrt(Math.Pow((punktB.x - punktC.x), 2) + Math.Pow((punktB.y - punktC.y), 2));
        bokCA = Math.Sqrt(Math.Pow((punktC.x - punktA.x), 2) + Math.Pow((punktC.y - punktA.y), 2));
    }
    public double Area()
    {
        Boki();
        double p = Perimeter()/2;
        double P = Math.Sqrt(p*(p-bokAB)*(p-bokBC)*(p-bokCA));
        return P;
    }

    public double Perimeter()
    {
        Boki();
        return bokAB + bokBC + bokCA;
    }

    public void View()
    {
        Console.WriteLine($"bokA: {punktA.x},{punktA.y}; bokB: {punktB.x},{punktB.y}, bokC: {punktC.x},{punktC.y}");
    }

    public void Viewboki()
    {
        Boki();
        Console.WriteLine($"{bokAB}, {bokBC}, {bokCA}");
    }

}
class Program
{

    public static void Main()
    {
        //var a = new PointCenter(0, 4, 5, 5);
        //a.View();
        //a.MoveUp();
        //a.View();


        var a = new PointCenter(0, 0);
        var b = new PointCenter(2, 0);
        var c = new PointCenter(0, 2);

        var trojkat = new Triangle(a,b,c);
        trojkat.View();
        //Console.WriteLine(trojkat.Perimeter());
        trojkat.Viewboki();

        //Console.WriteLine($"wynik: {2*2/2}");
    }
}
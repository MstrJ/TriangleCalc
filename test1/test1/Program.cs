
interface IFigure
{
    double Area();
    double Perimeter();
}

interface IPointMovement
{
    void MoveUp(int yMove);
    void MoveDown(int yMove);
    void MoveLeft(int xMove);
    void MoveRight(int xMove);
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
        yMove = 2;
        xMove = 2;
    }
    public PointCenter(int x, int y, int yMove, int xMove)
    {
        this.x = x;
        this.y = y;
        this.yMove = yMove;
        this.xMove = xMove;
    }
    public void MoveUp(int yMove)
    {
        y += this.yMove;
    }
    public void MoveDown(int yMove)
    {
        y -= yMove;
    }
    public void MoveLeft(int xMove)
    {
        x -= xMove;
    }
    public void MoveRight(int xMove)
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

    int xMove;
    int yMove;
    public Triangle(PointCenter punktA, PointCenter punktB, PointCenter punktC,int xMove,int yMove)
    {
        this.punktA = punktA;
        this.punktB = punktB;
        this.punktC = punktC;
        this.xMove = xMove;
        this.yMove = yMove;
    }
    public double PointsRange(PointCenter p1, PointCenter p2)
    {
        return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
    }
    public void Boki()
    {
        bokAB = PointsRange(punktA, punktB);
        bokBC = PointsRange(punktB, punktC);
        bokCA = PointsRange(punktC, punktA);
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

    public void ViewResult()
    {
        Console.WriteLine($"Area: {Area():F2}, Perimeter: {Perimeter():F2}");
    }

    public void ViewPoint()
    {
        Boki();
        Console.WriteLine($"a: {punktA.x}, {punktA.y}; b: {punktB.x}, {punktB.y}; c: {punktC.x}, {punktC.y}");
    }
    public void MoveUp()
    {
        punktA.MoveUp(yMove);
        punktB.MoveUp(yMove);
        punktC.MoveUp(yMove);
    }

    public void MoveDown()
    {
        punktA.MoveDown(yMove);
        punktB.MoveDown(yMove);
        punktC.MoveDown(yMove);
    }

    public void MoveLeft()
    {
        punktA.MoveLeft(xMove);
        punktB.MoveLeft(xMove);
        punktC.MoveLeft(xMove);
    }

    public void MoveRight()
    {
        punktA.MoveRight(xMove);
        punktB.MoveRight(xMove);
        punktC.MoveRight(xMove);
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
        var b = new PointCenter(0, 4);
        var c = new PointCenter(-4, 4);

        var trojkat = new Triangle(a,b,c,2,2);
        //trojkat.Viewboki();
        trojkat.ViewPoint();

        
        trojkat.MoveUp();
        trojkat.ViewPoint();
        trojkat.ViewResult();
        //Console.WriteLine(trojkat.Perimeter());
        //Console.WriteLine(trojkat.Area());

        //Console.WriteLine($"wynik: {2*2/2}");
    }
}
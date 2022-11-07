interface IFigure
{
    double Area();
    double Perimeter();
    public void Boki();
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
    public double x;
    public double y;
    int yMove;
    int xMove;

    public PointCenter(double x, double y)
    {
        this.x = x;
        this.y = y;
        yMove = 2;
        xMove = 2;
    }
    public PointCenter(double x, double y, int yMove, int xMove)
    {
        this.x = x;
        this.y = y;
        this.yMove = yMove;
        this.xMove = xMove;
    }
    public void MoveUp()
    {
        y += this.yMove;
    }
    public void MoveDown()
    {
        y -= this.yMove;
    }
    public void MoveLeft()
    {
        x -= this.xMove;
    }
    public void MoveRight()
    {
        x += this.xMove;
    }

    public void View()
    {
        Console.WriteLine($"{this}\n x: {x}, y: {y}\t xMove: {xMove}, yMove: {yMove}");
    }
}

class Triangle : PointCenter,IFigure
{
    PointCenter punktA;
    PointCenter punktB;
    PointCenter punktC;

    double bokAB;
    double bokBC;
    double bokCA;

    public Triangle(PointCenter punktA, PointCenter punktB, PointCenter punktC,int xMove,int yMove) : base(xMove,yMove)
    {
        this.punktA = punktA;
        this.punktB = punktB;
        this.punktC = punktC;
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
        Console.WriteLine($"{this}\n Area: {Area():F2}, Perimeter: {Perimeter():F2}");
    }

    public void ViewPoints()
    {
        Boki();
        Console.WriteLine($"{this}\n a: {punktA.x}, {punktA.y}; b: {punktB.x}, {punktB.y}; c: {punktC.x}, {punktC.y}");
    }
    public new void MoveUp()
    {
        punktA.MoveUp();
        punktB.MoveUp();
        punktC.MoveUp();
    }

    public new void MoveDown()
    {
        punktA.MoveDown();
        punktB.MoveDown();
        punktC.MoveDown();
    }

    public new void MoveLeft()
    {
        punktA.MoveLeft();
        punktB.MoveLeft();
        punktC.MoveLeft();
    }

    public new void MoveRight()
    {
        punktA.MoveRight();
        punktB.MoveRight();
        punktC.MoveRight();
    }

}
class Rectangle : PointCenter,IFigure, IPointMovement
{
    PointCenter punktA;
    PointCenter punktB;
    PointCenter punktC;
    PointCenter punktD;

    double bokAB;
    double bokBC;

    public Rectangle(PointCenter punktA, PointCenter punktB, PointCenter punktC, PointCenter punktD, int xMove,int yMove) : base(xMove,yMove)
    {
        this.punktA = punktA;
        this.punktB = punktB;
        this.punktC = punktC;
        this.punktD = punktD;
        
    }
    public double PointsRange(PointCenter p1, PointCenter p2)
    {
        return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
    }
    public void Boki()
    {
        bokAB = PointsRange(punktA, punktB);
        bokBC = PointsRange(punktB, punktC);
    }
    public double Area()
    {
        Boki();
        return bokAB*bokBC;
    }

    public double Perimeter()
    {
        Boki();
        return bokAB * 2 + bokBC * 2;
    }

    public void ViewResult()
    {
        Console.WriteLine($"{this}\n Area: {Area():F2}, Perimeter: {Perimeter():F2}");
    }

    public void ViewPoints()
    {
        Boki();
        Console.WriteLine($"{this}\n a: {punktA.x}, {punktA.y}; b: {punktB.x}, {punktB.y}; c: {punktC.x}, {punktC.y}; d: {punktD.x}, {punktD.y}");
    }
    public new void MoveUp()
    {
        punktA.MoveUp();
        punktB.MoveUp();
        punktC.MoveUp();
    }

    public new void MoveDown()
    {
        punktA.MoveDown();
        punktB.MoveDown();
        punktC.MoveDown();
    }

    public new void MoveLeft()
    {
        punktA.MoveLeft();
        punktB.MoveLeft();
        punktC.MoveLeft();
    }

    public new void MoveRight()
    {
        punktA.MoveRight();
        punktB.MoveRight();
        punktC.MoveRight();
    }

}
class Program
{

    public static void Main()
    {
        var p1 = new PointCenter(0, 0, 1, 2);
        p1.View();
        p1.MoveUp();
        p1.View();

        Console.WriteLine();
        var a1 = new PointCenter(0, 0);
        var b1 = new PointCenter(0, 4);
        var c1 = new PointCenter(-4, 4);

        var trojkat = new Triangle(a1,b1,c1,2,2);
        trojkat.ViewPoints();
        trojkat.MoveUp();
        trojkat.ViewPoints();
        trojkat.ViewResult();


        var a2 = new PointCenter(0, 0);
        var b2 = new PointCenter(-2, 0);
        var c2 = new PointCenter(-2, 2);
        var d2 = new PointCenter(0, 2);

        var prostokat = new Rectangle(a2, b2, c2,d2,4,4);
        prostokat.ViewPoints();
        prostokat.ViewResult();
    }
}
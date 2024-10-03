Point pointA = new Point(2,3);
Point pointB = new Point(-4, 0);

Console.WriteLine($"PointA: {pointA}, PointB: {pointB}");
class Point
{
    public int X { get; } 
    public int Y { get; } 

    public Point() :this(0,0) {}
 
    public Point(int x, int y)
    
    {
        X = x;
        Y = y;
    }

    public override string  ToString()
    {
        return $"({X}, {Y})";
    }
    
}


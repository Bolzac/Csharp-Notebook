class Methods
{
    public static double FindDistance(Coordinate one, Coordinate two)
    {
        return Math.Sqrt(Math.Pow((one.x - two.x), 2) + Math.Pow((one.y - two.y), 2) + Math.Pow((one.z - two.z), 2));
    }
}

struct Coordinate
{
    public string Name { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int z { get; set; }
    public void SetCoordinate(string name, int x, int y, int z)
    {
        this.Name = Name;
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

class User
{
    public static void Main(string[] args)
    {
        int x1, y1, z1;
        int x2, y2, z2;
        Console.WriteLine("Please enter coordinates of first point : ");
        Console.Write("x1 :");
        x1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("y1 :");
        y1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("z1 :");
        z1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter coordinates of second point : ");
        Console.Write("x2 :");
        x2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("y2 :");
        y2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("z2 :");
        z2 = Convert.ToInt32(Console.ReadLine());
        Coordinate point1 = new Coordinate();
        Coordinate point2 = new Coordinate();
        point1.SetCoordinate("point1", x1, y1, z1);
        point2.SetCoordinate("point2", x2, y2, z2);
        double distance = Methods.FindDistance(point1, point2);
        Console.WriteLine("Distance between these two point is " + distance);
    }
}
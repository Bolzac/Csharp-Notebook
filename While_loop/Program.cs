class Function
{
    public static void Limit(int initial, int limit)
    {
        int sum = initial;
        Console.Write(initial);
        while (sum < limit)
        {
            initial++;
            sum += initial;
            Console.Write(" + " + initial);
        }
        Console.Write(" = " + sum + " > " + limit);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int a, b;
        Console.WriteLine("Please enter an integer number : ");
        a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please enter an integer number to limit : ");
        b = Convert.ToInt32(Console.ReadLine());
        Function.Limit(a, b);
    }
}
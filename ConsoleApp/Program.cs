public static class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine("hello world");
        Console.Write(addNumbers(2, 3));
        
    }
     
    public static Func<DateTime> Now = () => DateTime.Now;
    {
        Entity.LastChange = SystemTime.Now();
    }


    public static int addNumbers(int a, int b)
    {
        return a + b;
    }
}

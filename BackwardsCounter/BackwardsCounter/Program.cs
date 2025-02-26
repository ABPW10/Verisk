class BackwardsCounter
{
    static void Main(string[] args)
    {
        if (args.Length != 2 || !int.TryParse(args[0], out int countStart) || !int.TryParse(args[1], out int countStep))
        {
            Console.WriteLine("Invalid input");
            return;
        }
        if (countStart < 2 || countStep < 0)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        if (countStart >= 1000)
        {
            Console.WriteLine("Out of range");
            return;
        }
        if (countStep == 0)
        {
            Console.WriteLine("Division by zero error");
            return;
        }
        if (countStart % countStep != 0)
        {
            Console.WriteLine("Invalid input");
            return;
        }
        for (int count = countStart; count > 0; count -= countStep)
        {
            if (count < countStart)
            {
                Console.Write(" ");
            }
            Console.Write(count);
        }
        Console.WriteLine();
    }
}
class MultiThreading
{
    /**
     * Method that squares the given number
     */
    static int Square(int number)
    {
        return number * number;
    }
    static void Main(string[] args)
    {
        if (args.Length == 1)
        {
            Console.WriteLine("Output file not specified.");
            return;
        }
        else if (args.Length == 0)
        {
            Console.WriteLine("Input file not specified.");
            return;
        }

        // Input is invalid if not an integer
        List<int?> numbers = [];
        StreamReader? reader = null;
        try
        {
            reader = new StreamReader(args[0]);
            while (reader.Peek() != -1)
            {
                if (int.TryParse(reader.ReadLine(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    numbers.Add(null);
                }
            }
        }
        catch
        {
            Console.WriteLine("Input file does not exist");
        }
        finally
        {
            reader?.Close();
        }

        if (reader == null)
        {
            return;
        }

        List<Thread> threadsStarted = [];
        for (int index = 0; index < numbers.Count; index++)
        {
            int? number = numbers[index];
            int currentIndexOfNumber = index; // index value will change in asynchronized execution
            if (number.HasValue)
            {
                // Start a new thread to write the squared number back into the collection
                Thread squareThread = new Thread(void () => numbers[currentIndexOfNumber] = Square(number.Value));
                squareThread.Start();
                threadsStarted.Add(squareThread);
            }
        }

        // The main thread should wait until all numbers are processed before writing the output file
        foreach (Thread th in threadsStarted)
        {
            th.Join();
        }

        StreamWriter? writer = null;
        try
        {
            writer = new StreamWriter(args[1]);
        }
        catch
        {
            Console.WriteLine("Output directory does not exist");
        }

        if (writer == null)
        {
            return;
        }

        foreach (int? number in numbers)
        {
            if (number.HasValue)
            {
                writer.WriteLine(number);
            } 
            else
            {
                writer.WriteLine("Invalid Input"); 
            }
        }

        writer.Close();
    }
}
using System.Text;

class Program
{
    static void Main()
    {
        // Concatenation.Example();
        // Concatenation.Prog();
        // CatchExceptions.Example();Files.Example();
        Files.Example();
    }
}

class Concatenation
{
    public static void Example()
    {
        StringBuilder sb = new StringBuilder();
        Console.Write("Type in your name: ");
        string userName = Console.ReadLine();

        sb.Append("I'd like to say ");
        sb.AppendFormat("Hello {0}", userName);

        Console.WriteLine(sb.ToString());
    }

    public static void Prog()
    {
        int baseValue = getUserInt("Enter a base: ");
        string multiplicand = getUserInput("Enter multiplicand: ");
        string minMultiplier = getUserInput("Enter minimum multiplier: ");
        string maxMultiplier = getUserInput("Enter maximum multiplier: ");
        
        BaseMultiplier tableBuilder = new BaseMultiplier(baseValue);

        tableBuilder.Multiplicand = multiplicand;
        
        try
        {
            tableBuilder.getMultiplicationTable(minMultiplier, maxMultiplier);
            Console.WriteLine(tableBuilder.TableString);
        } catch (Exception e)
        {
            Console.WriteLine($"Something went wrong generating the table. {e.Message}");
        }
    }

    static int getUserInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine().Trim(), out int userInputInt))
            {
                return userInputInt;
            }

            Console.WriteLine("Please enter a valid integer!");
        }
    }

    static string getUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine().Trim();
    }
}

class CatchExceptions
{
    public static void Example()
    {
        int[] items = new int[10];
        try
        {
            for (int i = 0; i < 11; i++)
            {
                items[i] = i * 2;
            }
        } catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"An IndexOutOfRangeException '{e.Message}' was trapped!");
        } catch (Exception e)
        {
            Console.WriteLine($"Some other Exception '{e.Message}' was trapped!");
        }
    }
}

class Files
{
    public static void Example()
    {
        string filePath = @"K:\FifthProgram\FifthProgram\lipsum.txt";
        string writeFilePath = @"K:\FifthProgram\FifthProgram\new.txt";

        try
        {
            using (StreamReader sr = new StreamReader(filePath)) // 'using' will close fh when it goes out of scope (even if exception is thrown)
            {
                string lineContent;

                while (!sr.EndOfStream)
                {
                    lineContent = sr.ReadLine();
                    Console.WriteLine(lineContent);
                }
            }
        } catch (IOException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }

        try
        {
            using (StreamWriter sw = new StreamWriter(writeFilePath))
            {
                string userInput;
                do
                {
                    Console.Write(">>> ");
                    userInput = Console.ReadLine().Trim();
                    sw.WriteLine(userInput);
                } while (userInput != "");
            }

            Console.WriteLine("Sucessfully written to file!");
        } catch (IOException e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
}
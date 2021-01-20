using System;

namespace ClaimsTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Here is an example of how to run this program from command prompt:");
                Console.WriteLine(@"ClaimsTriangle c:\temp\data.csv c:\temp\dataout.csv");
                return;
            }
            try
            {
                string fileIn = args[0].ToString();
                string fileOut = args[1].ToString();
                new ProcessTriangle(new LoadCsv(fileIn), fileOut, ",");
                Console.WriteLine("Output file generated successfully. File details:- " + fileOut);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error has occured! Error details:- ");
                Console.WriteLine(e.Message);
            }
        }
    }
}

using System;

namespace I2C2DMP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("I2C2DMP");
            Console.WriteLine("Author: Cra0 (cra0.net)");
            Console.WriteLine(string.Empty);

            if (args.Count() < 1)
            {
                Console.WriteLine("Usage: I2C2DMP path/to/consoleOutput.txt");
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            string workingDirectory = Utilities.GetApplicationDirectory();
            string inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                //Check the working directory
                string newWorkingDirPath = Path.Combine(workingDirectory, inputFile);
                if (File.Exists(newWorkingDirPath))
                    inputFile = newWorkingDirPath;
                else
                {
                    Console.WriteLine($"Error Input file {inputFile} doesn't seem to exist!");
                    return;
                }
            }

            //Create the output filepath
            string workingDir = Path.GetDirectoryName(inputFile);
            string outputFilePath = Path.Combine(workingDir, Path.ChangeExtension(inputFile, "bin"));
            if (Parser.ParseAndExportData(inputFile, outputFilePath))
            {
                Console.WriteLine($"Successfully parsed and wrote data to {outputFilePath}");
            }

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
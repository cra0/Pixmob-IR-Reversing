using System;
using System.Reflection;

namespace DMP2I2C
{
    class Program
    {
        public static string GetApplicationDirectory()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists(dir))
                return dir;
            else
                return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("DMP2I2C");
            Console.WriteLine("Author: Cra0 (cra0.net)");
            Console.WriteLine(string.Empty);

            if (args.Count() < 1)
            {
                Console.WriteLine("Usage: DMP2I2C path/to/data.bin");
                Console.WriteLine(" ");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
                return;
            }

            string workingDirectory = GetApplicationDirectory();
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
            string outputFilePath = Path.Combine(workingDir, Path.ChangeExtension(inputFile, "txt"));

            CommandWritter writter = new CommandWritter();
            if (writter.OpenFile(outputFilePath))
            {
                byte[] data = File.ReadAllBytes(inputFile);
                if (!writter.WriteData(0xA0, data))
                {
                    Console.WriteLine("Failed to write data.");
                }
                else
                {
                    Console.WriteLine("Data written!");
                }
                writter.Close();
            }
            else
            {
                Console.WriteLine("Failed to open file.");
            }

            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
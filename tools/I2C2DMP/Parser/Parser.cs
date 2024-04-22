using System;

namespace I2C2DMP
{
    public static class Parser
    {
        public static bool ParseAndExportData(string inputFilePath, string outputFilePath)
        {
            try
            {
                // Read the contents of the input file
                string inputContent = File.ReadAllText(inputFilePath);
                List<byte> byteList = new List<byte>();

                // Split the input contents into lines
                string[] lines = inputContent.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                // Process each line
                foreach (var line in lines)
                {
                    string[] parts = line.Trim().Split(' ');
                    foreach (var part in parts)
                    {
                        if (part.StartsWith("0x"))
                        {
                            string hexValue = part.Substring(2, 2); // Get the two hex digits
                            if (byte.TryParse(hexValue, System.Globalization.NumberStyles.HexNumber, null, out byte result))
                            {
                                byteList.Add(result);
                            }
                            else
                            {
                                Console.WriteLine($"Warning: Failed to parse '{hexValue}' as byte.");
                            }
                        }
                    }
                }

                // Convert List<byte> to byte array
                byte[] bytes = byteList.ToArray();

                // Write the cleaned bytes to the output binary file
                File.WriteAllBytes(outputFilePath, bytes);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }
    }
}

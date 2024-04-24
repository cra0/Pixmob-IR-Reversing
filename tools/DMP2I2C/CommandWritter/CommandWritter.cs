using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMP2I2C
{
    public class CommandWritter
    {
        private StreamWriter? _writer;

        public CommandWritter()
        {
            _writer = null;
        }

        public bool OpenFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            try
            {
                _writer = new StreamWriter(new FileStream(filePath, FileMode.CreateNew, FileAccess.Write));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool WriteData(byte writeAddress, byte[] data)
        {
            if (_writer == null)
            {
                return false;
            }

            try
            {
                for (int i = 0; i < data.Length; i += 8)
                {
                    // Calculate how many bytes to read (handling the case where there may be fewer than 8 bytes left)
                    int bytesToWrite = Math.Min(8, data.Length - i);

                    // Start the command string
                    string command = $"[0x{writeAddress:X2} 0x{i:X2} ";

                    // Append each byte in this block
                    for (int j = 0; j < bytesToWrite; j++)
                    {
                        command += $"0x{data[i + j]:X2} ";
                    }

                    // Close the command string and write the delay
                    command += $"] D:100 ";
                    _writer.WriteLine(command);

                    // Update writeAddress for EEPROM continuation (if needed)
                    // EEPROM pages are usually continued by incrementing the second byte of the address after every 8 bytes
                    if (i % 256 == 248) // Adjust the base address after each 256 bytes page
                    {
                        writeAddress += 2;
                    }
                }
                _writer.Flush();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Close()
        {
            _writer?.Close();
        }
    }
}

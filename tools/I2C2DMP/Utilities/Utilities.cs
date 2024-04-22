using System.Reflection;

namespace I2C2DMP
{
    static class Utilities
    {
        public static string GetApplicationDirectory()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            if (Directory.Exists(dir))
                return dir;
            else
                return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }
    }
}

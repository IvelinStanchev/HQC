using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling
{
    public static class FileManager
    {
        public static string GetFileExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            string extension = path.Substring(lastDotIndex + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int indexOfLastDot = path.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return path;
            }

            string extension = path.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}

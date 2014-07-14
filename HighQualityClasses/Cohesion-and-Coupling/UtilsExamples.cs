using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileManager.GetFileExtension("example"));
            Console.WriteLine(FileManager.GetFileExtension("example.pdf"));
            Console.WriteLine(FileManager.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileManager.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                DistanceCalculator.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                DistanceCalculator.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", parallepiped.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", parallepiped.CalculateDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", parallepiped.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", parallepiped.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", parallepiped.CalculateDiagonalYZ());
        }
    }
}

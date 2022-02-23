using System;
using System.IO;

namespace FileProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory (full path name): ");
            string mainDirectory = DoesDirectoryExist();

            Console.WriteLine("Enter the CSV file location to view results (full path name): ");
            string csvFile = DoesCSVFileExist();

            DirectoryProcessor dp = new DirectoryProcessor();
            dp.ProcessFilesInDirectory(mainDirectory, csvFile);
        }

        public static string DoesDirectoryExist()
        {
            string mainDirectory = Console.ReadLine();
            while (Directory.Exists(mainDirectory) == false)
            {
                Console.WriteLine("Directory does not exist. Please enter another directory (full path name): ");
                mainDirectory = Console.ReadLine();
            }
            Console.WriteLine("Directory exists.");
            return mainDirectory;
        }

        public static string DoesCSVFileExist()
        {
            string csvFile = Console.ReadLine();
            while (File.Exists(csvFile) == false)
            {
                Console.WriteLine("CSV File does not exist. Please enter another CSV file (full path name): ");
                csvFile = Console.ReadLine();
            }
            Console.WriteLine("CSV File exists.");
            return csvFile;
        }
    }
}


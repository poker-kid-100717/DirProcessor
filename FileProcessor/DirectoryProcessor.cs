using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class DirectoryProcessor
    {
        public void ProcessFilesInDirectory(string directory, string csvFile)
        {
            foreach (string path in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
            {
                if (File.Exists(path))
                {
                    ProcessIndividualFile(path, csvFile);
                }

                else if (Directory.Exists(path))
                {
                    ProcessFilesInDirectory(path, csvFile);
                }
            }
        }

        public void ProcessIndividualFile(string path, string csvFile)
        {
            FileProcessor fp = new FileProcessor();
            string fileSignature = fp.GetFileSignature(path);
            string fileType = fp.GetFileType(fileSignature);
            string hash = fp.GetMD5Hash(path);
            fp.CsvFill(path, fileType, hash, csvFile);
        }
    }
}


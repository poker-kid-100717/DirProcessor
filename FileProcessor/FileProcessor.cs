using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileProcessor
{
    public class FileProcessor
    {
        public string GetFileSignature(string path)
        {
            int bytesUsed = 4;
            byte[] buffer;
            using (FileStream filesStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(filesStream))
                {
                    buffer = binaryReader.ReadBytes(bytesUsed);
                }
            }
            string fileSignature = BitConverter.ToString(buffer);
            return fileSignature.Replace("-", String.Empty).ToLower();
        }

        public string GetFileType(string fileSignature)
        {
            if (fileSignature == "ffd8ffe0")
            {
                return "This is a JPG file";
            }
            else if (fileSignature == "25504446")
            {
                return "This is a PDF file";
            }
            else
            {
                return "Other file";
            }
        }

        public string GetMD5Hash(string path)
        {
            MD5 md5hash = MD5.Create();
            byte[] bytedata = md5hash.ComputeHash(Encoding.Default.GetBytes(path));
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < bytedata.Length; i++)
            {
                stringBuilder.Append(bytedata[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }

        public void CsvFill(string fullPath, string fileType, string hash, string csvFile)
        {
            string columnSeperator = ",";
            string[][] fileInformation = new string[][] { new string[] { fullPath, fileType, hash } };
            int length = fileInformation.GetLength(0);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                sb.AppendLine(string.Join(columnSeperator, fileInformation[i]));
            }

            File.AppendAllText(csvFile, sb.ToString());
        }
    }
}



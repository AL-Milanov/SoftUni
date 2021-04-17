using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = Environment.CurrentDirectory;
            string[] files = Directory.GetFiles(directoryPath);
            Dictionary<string, Dictionary<string, double>> filesData =
                new Dictionary<string, Dictionary<string, double>>();

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                string fileExtension = fileInfo.Extension;
                string fileName = fileInfo.Name;
                double fileSize = fileInfo.Length / 1024.0;

                if (filesData.ContainsKey(fileExtension) == false)
                {
                    filesData.Add(fileExtension, new Dictionary<string, double>());
                }

                filesData[fileExtension].Add(fileName, fileSize);
            }

            Dictionary<string, Dictionary<string, double>> softedFilesData =
                filesData.OrderByDescending(kvp => kvp.Value.Count)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            List<string> result = new List<string>();

            foreach (var file in softedFilesData)
            {
                result.Add(file.Key);

                foreach (var fileData in file.Value)
                {
                    result.Add($"--{fileData.Key} - {fileData.Value:F3}kb");
                }
            }
            string filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "output.txt");
            File.WriteAllLines(filePath, result);
        }
    }
}

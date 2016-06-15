using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace DuplicateFileCleanUp
{
    public class StandardFileIdentifier : IFileIdentifier
    {
        public void Clean(string[] files, out Flag flags)
        {
            flags = Flag.Ok;
            if (files == null || files.Length <= 0)
            {
                flags = Flag.NoFilesCleaned;
                return;
            }

            foreach (var file in files)
            {
                Directory.Delete(file);
            }
        }

        public void CleanAll(out Flag flags)
        {
            Directory.GetCurrentDirectory();   
            throw new NotImplementedException();
        }

        public string[] Search(string path, out Flag flags)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException();

            string[] files = Directory.GetFiles(path);
            var filtered = new List<string>();
            var regex = new Regex(@"(\d+)");
            foreach (var file in files)
            {
                if (regex.IsMatch(file))
                    filtered.Add(file);
            }

            flags = Flag.Ok;
            return filtered.ToArray();
        }
    }
}

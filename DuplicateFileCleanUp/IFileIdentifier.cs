using System.Collections.Generic;

namespace DuplicateFileCleanUp
{
    public interface IFileIdentifier
    {
        string[] Search(string path, out Flag flags);
        void CleanAll(out Flag flags);
        void Clean(string[] files, out Flag flags);
    }
}

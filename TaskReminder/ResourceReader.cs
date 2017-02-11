using System.IO;

namespace TaskReminder
{
    public class ResourceReader
    {
        public ResourceReader(string path)
        {
            if (IsSuccess = File.Exists(path))
            {
                Content = File.ReadAllText(path);
            }
        }
        public string Content { get; set; }
        public bool IsSuccess { get; }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder
{
    public class HtmlTemplate
    {
        public HtmlTemplate(string path)
        {
            if (IsSuccess = File.Exists(path))
            {
                Content = File.ReadAllText(path);
            }
        }

        public string Content { get; }
        public bool IsSuccess { get; }
    }
}

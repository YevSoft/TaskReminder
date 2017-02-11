using CommandLine;
using CommandLine.Text;

namespace TaskReminder
{
    public class Options
    {
        public Options()
        {
            HtmlTemplate = "HtmlTemplate.html";
            Task = "Tasks.txt";
            Timeout = 5;
            Width = 800;
            Height = 600;
            JHead = string.Empty;
            JBody = string.Empty;
            LogDate = false;
            DateFile = "DateLog.txt";
        }

        [Option('x', "html", HelpText = "Input html template file to be processed.")]
        public string HtmlTemplate { get; set; }

        [Option('d', "task", HelpText = "Input tasks file to be processed.")]
        public string Task { get; set; }

        [Option('t', "timeout", HelpText = "Timeout for displaying dashboard before closing.")]
        public int Timeout { get; set; }

        [Option('w', "width", HelpText = "Window width in px.")]
        public int Width { get; set; }

        [Option('h', "height", HelpText = "Window height in px.")]
        public int Height { get; set; }

        [Option('j', "jhead", HelpText = "Java script for head tag.")]
        public string JHead { get; set; }

        [Option('s', "jbody", HelpText = "Java script for body tag.")]
        public string JBody { get; set; }

        [Option('l', "logdate", HelpText = "Write date time to log.")]
        public bool LogDate { get; set; }

        [Option('d', "datefile", HelpText = "File name for logging current date in mode 2.")]
        public string DateFile { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}

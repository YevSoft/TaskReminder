using CommandLine;
using CommandLine.Text;

namespace TaskReminder
{
    public class Options
    {
        public Options()
        {
            HtmlTemplate = "HtmlTemplate.html";
            Task = "Task.txt";
            Timeout = 5;
            Width = 800;
            Height = 600;
        }

        [Option('x', "html", Required = true, HelpText = "Input html template file to be processed.")]
        public string HtmlTemplate { get; set; }

        [Option('d', "task", Required = true, HelpText = "Input tasks file to be processed.")]
        public string Task { get; set; }

        [Option('t', "timeout", Required = true, HelpText = "Timeout for displaying dashboard before closing.")]
        public int Timeout { get; set; }

        [Option('w', "width", HelpText = "Window width in px.")]
        public int Width { get; set; }

        [Option('h', "height", HelpText = "Window height in px.")]
        public int Height { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}

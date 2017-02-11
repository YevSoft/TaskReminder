using CommandLine;
using CommandLine.Text;

namespace TaskReminder
{
    public class Options
    {
        [Option('h', "html", Required = true, HelpText = "Input html template file to be processed.")]
        public string HtmlTemplate { get; set; }

        [Option('d', "task", Required = true, HelpText = "Input tasks file to be processed.")]
        public string Task { get; set; }

        [Option('t', "timeout", Required = true, HelpText = "Timeout for displaying dashboard before closing.")]
        public string Timeout { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}

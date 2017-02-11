using System;
using System.Windows.Forms;

namespace TaskReminder
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Dashboard(options));
            }
        }
    }
}

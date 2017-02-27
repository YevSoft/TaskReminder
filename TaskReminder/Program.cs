using IniParser;
using IniParser.Exceptions;
using System;
using System.IO;
using System.Windows.Forms;

namespace TaskReminder
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var options = new Options();
            IniParser.FileIniDataParser parser = null;
            try
            {
                parser = new FileIniDataParser();
                var config = parser.ReadFile(Constants.Config);

                if (CommandLine.Parser.Default.ParseArguments(args, options))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    if (!options.LogDate)
                    {
                        // Mode 1
                        Application.Run(new Dashboard(options, config));
                    }
                    else
                    {
                        // Mode 2
                        using (StreamWriter w = File.AppendText(options.DateFile))
                        {
                            w.WriteLine(DateTime.Now.ToString());
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TaskReminder
{
    public partial class Dashboard : Form
    {
        private Options options;
        private HtmlTemplate html;
        private Task task;

        public System.Timers.Timer timer { get; set; }

        public Dashboard(Options options)
        {
            this.options = options;
            InitializeComponent();

            this.Size = new Size(options.Width, options.Height);

            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Event);

            html = new HtmlTemplate(options.HtmlTemplate);
            task = new Task(options);
            
            if (html.IsSuccess && task.IsSuccess)
            {
                html.Content = Regex.Replace(html.Content, "{" + Constants.Today + "}", task.Tables[Constants.Today]);
                html.Content = Regex.Replace(html.Content, "{" + Constants.Tomorrow + "}", task.Tables[Constants.Tomorrow]);
                html.Content = Regex.Replace(html.Content, "{" + Constants.AfterTomorrow + "}", task.Tables[Constants.AfterTomorrow]);

                string lastDate = "var " + Constants.LastDate + " = '" + ReadLastDate() + "';";
                html.Content = Regex.Replace(html.Content, "{" + Constants.JHead + "}", lastDate + options.JHead);
                html.Content = Regex.Replace(html.Content, "{" + Constants.JBody + "}", options.JBody);
                wbDashboard.DocumentText = html.Content;
            }

            timer = new System.Timers.Timer();
            timer.Interval = options.Timeout * 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(myTimer_Elapsed);
            timer.Start();
        }

        private string ReadLastDate()
        {
            if (File.Exists(options.DateFile))
                return File.ReadLines(options.DateFile).Last();
            return string.Empty;
        }

        private void Event(object sender, EventArgs e)
        {
            this.Close();
        }

        private void myTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Close();
        }
    }
}

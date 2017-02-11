using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TaskReminder
{
    public partial class Dashboard : Form
    {
        private Options options;
        private HtmlTemplate html;
        private Task task;

        public Dashboard(Options options)
        {
            this.options = options;
            InitializeComponent();

            MouseHook.Start();
            MouseHook.MouseAction += new EventHandler(Event);

            html = new HtmlTemplate(options.HtmlTemplate);
            task = new Task(options.Task);

            if (html.IsSuccess && task.IsSuccess)
            {
                html.Content = Regex.Replace(html.Content, "{" + Constants.Today + "}", task.Tables[Constants.Today]);
                html.Content = Regex.Replace(html.Content, "{" + Constants.Tomorrow + "}", task.Tables[Constants.Tomorrow]);
                html.Content = Regex.Replace(html.Content, "{" + Constants.AfterTomorrow + "}", task.Tables[Constants.AfterTomorrow]);
                wbDashboard.DocumentText = html.Content;
            }
        }

        private void Event(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

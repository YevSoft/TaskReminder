using System.Windows.Forms;

namespace TaskReminder
{
    public partial class Dashboard : Form
    {
        private Options options;
        private HtmlTemplate html;

        public Dashboard(Options options)
        {
            this.options = options;
            InitializeComponent();

            html = new HtmlTemplate(options.HtmlTemplate);

            if (html.IsSuccess)
            {
                wbDashboard.DocumentText = html.Content;

            }
        }
    }
}

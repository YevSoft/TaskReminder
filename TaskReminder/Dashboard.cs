using System.Windows.Forms;

namespace TaskReminder
{
    public partial class Dashboard : Form
    {
        private Options options;

        public Dashboard(Options options)
        {
            this.options = options;
            InitializeComponent();
        }
    }
}

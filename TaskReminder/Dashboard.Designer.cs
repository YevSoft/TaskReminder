namespace TaskReminder
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wbDashboard = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbDashboard
            // 
            this.wbDashboard.AllowNavigation = false;
            this.wbDashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbDashboard.IsWebBrowserContextMenuEnabled = false;
            this.wbDashboard.Location = new System.Drawing.Point(0, 0);
            this.wbDashboard.Margin = new System.Windows.Forms.Padding(0);
            this.wbDashboard.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbDashboard.Name = "wbDashboard";
            this.wbDashboard.ScrollBarsEnabled = false;
            this.wbDashboard.Size = new System.Drawing.Size(784, 561);
            this.wbDashboard.TabIndex = 0;
            this.wbDashboard.Url = new System.Uri("", System.UriKind.Relative);
            this.wbDashboard.WebBrowserShortcutsEnabled = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.wbDashboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbDashboard;
    }
}


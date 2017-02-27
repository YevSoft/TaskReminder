using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TaskReminder
{
    public class TaskItem
    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
    }

    public class Task : ResourceReader
    {
        private Options options { get; set; }
        private IniData config { get; set; }

        public Task(Options options, IniData config) : base(options.Task)
        {
            this.options = options;
            this.config = config;
            Items = new List<TaskItem>();
            Tables = new Dictionary<string, string>();
            
            if (IsSuccess)
            {
                // Parse lines
                var lines = Regex.Split(Content, Constants.KeySplitLines);
                foreach (var line in lines)
                {
                    var parts = line.Split(Constants.KeySplitLine);
                    if (parts.Length != Constants.MaxItemsInTaskLine)
                        continue;

                    try
                    {
                        Items.Add(new TaskItem()
                        {
                            Date = DateTime.ParseExact(parts[0], Constants.DateFormat, System.Globalization.CultureInfo.InvariantCulture),
                            Text = parts[1]
                        });
                    }
                    catch(System.FormatException e)
                    {
                    }
                }
                PutToHtml(Items);
            }
        }

        private void PutToHtml(List<TaskItem> items)
        {
            if (null == items)
                return;

            DateTime day = DateTime.Today;
            var todayItems = Items.Where(i => i.Date.Month == day.Month && i.Date.Day == day.Day).OrderBy(i => i.Date).ToList();
            Tables.Add(Constants.Today, "<table>" + ToTableLines(todayItems, Constants.Today, config.GetKey(Constants.Today)) + "</table>");

            DateTime tomorrow = DateTime.Today.AddDays(1);
            var tomorrowItems = Items.Where(i => i.Date.Month == tomorrow.Month && i.Date.Day == tomorrow.Day).OrderBy(i => i.Date).ToList();
            Tables.Add(Constants.Tomorrow, "<table>" + ToTableLines(tomorrowItems, Constants.Tomorrow, config.GetKey(Constants.Tomorrow)) + "</table>");

            DateTime aftertomorrow = DateTime.Today.AddDays(2);
            var afterTomorrowItems = Items.Where(i => i.Date.Month == aftertomorrow.Month && i.Date.Day == aftertomorrow.Day).OrderBy(i => i.Date).ToList();
            Tables.Add(Constants.AfterTomorrow, "<table>" + ToTableLines(afterTomorrowItems, Constants.AfterTomorrow, config.GetKey(Constants.AfterTomorrow)) + "</table>");
        }

        private string ToTableLines(List<TaskItem> items, string className, string block_title)
        {
            string html = string.Empty;
            foreach (var line in items)
            {
                html += string.Format("<tr class=\"" + className + "\"><td class=\"title\">{0}</td><td class=\"years\">{1}</td><td>{2}</td></tr>", block_title, BuildRuYearsLabel(line.Date), line.Text);
                block_title = string.Empty;
            }
            return html;
        }

        private string BuildRuYearsLabel(DateTime date)
        {
            var years = DateTime.Now.Year - date.Year;
            if (years <= 0)
                return string.Empty;
            var lastdigit = (years % 100);
            var ext = string.Empty;
            if (lastdigit > 4 && lastdigit < 21)
                ext = "лет";
            else
                lastdigit = (years % 10);

            if (lastdigit == 1)
                ext = "год";
            else if (lastdigit > 1 && lastdigit < 5)
                ext = "года";
            else
                ext = "лет";

            return string.Format(" {0} {1} ", years.ToString(), ext);
        }

        public List<TaskItem> Items { get; }

        public Dictionary<string, string> Tables { get; protected set; }
    }
}

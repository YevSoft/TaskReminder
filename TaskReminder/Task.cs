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
        public Task(string path) : base(path)
        {
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

                    Items.Add(new TaskItem()
                    {
                        Date = DateTime.ParseExact(parts[0], Constants.DateFormat, System.Globalization.CultureInfo.InvariantCulture),
                        Text = parts[1]
                    });
                }
                PutToHtml(Items);
            }
        }

        private void PutToHtml(List<TaskItem> items)
        {
            if (null == items)
                return;
            
            var todayItems = Items.Where(i => i.Date == DateTime.Today).ToList();
            Tables.Add(Constants.Today, "<table>" + ToTableLines(todayItems, Constants.Today) + "</table>");

            var tomorrowItems = Items.Where(i => i.Date == DateTime.Today.AddDays(1)).ToList();
            Tables.Add(Constants.Tomorrow, "<table>" + ToTableLines(todayItems, Constants.Tomorrow) + "</table>");

            var afterTomorrowItems = Items.Where(i => i.Date == DateTime.Today.AddDays(2)).ToList();
            Tables.Add(Constants.AfterTomorrow, "<table>" + ToTableLines(todayItems, Constants.AfterTomorrow) + "</table>");
        }

        private string ToTableLines(List<TaskItem> items, string className)
        {
            string html = string.Empty;
            foreach (var line in items)
            {
                html += string.Format("<tr class=\"" + className + "\"><td class=\"title\">{0}</td><td>{1}</td></tr>", line.Date.ToString(Constants.DateFormat), line.Text);
            }
            return html;
        }

        public List<TaskItem> Items { get; }

        public Dictionary<string, string> Tables { get; protected set; }
    }
}

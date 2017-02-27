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

        public Task(Options options) : base(options.Task)
        {
            this.options = options;
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
            
            var todayItems = Items.Where(i => i.Date == DateTime.Today).ToList();
            Tables.Add(Constants.Today, "<table>" + ToTableLines(todayItems, Constants.Today, options.DayToday) + "</table>");

            var tomorrowItems = Items.Where(i => i.Date == DateTime.Today.AddDays(1)).ToList();
            Tables.Add(Constants.Tomorrow, "<table>" + ToTableLines(todayItems, Constants.Tomorrow, options.DayTomorrow) + "</table>");

            var afterTomorrowItems = Items.Where(i => i.Date == DateTime.Today.AddDays(2)).ToList();
            Tables.Add(Constants.AfterTomorrow, "<table>" + ToTableLines(todayItems, Constants.AfterTomorrow, options.DayAfterTomorrow) + "</table>");
        }

        private string ToTableLines(List<TaskItem> items, string className, string block_title)
        {
            string html = string.Empty;
            foreach (var line in items)
            {
                html += string.Format("<tr class=\"" + className + "\"><td class=\"title\">{0}</td><td></td><td>{1}</td></tr>", block_title, line.Text);
                block_title = string.Empty;
            }
            return html;
        }

        public List<TaskItem> Items { get; }

        public Dictionary<string, string> Tables { get; protected set; }
    }
}

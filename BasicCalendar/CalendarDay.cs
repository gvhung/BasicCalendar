using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCalendar
{
    public partial class CalendarDay : UserControl
    {
        private DateTime _currentDay;
        public DateTime CurrentDay
        {
            get
            {
                return _currentDay;
            }
            set
            {
                _currentDay = value;
            }
        }

        private bool _inCurrentMonth;
        public bool InCurrentMonth
        {
            get
            {
                return _inCurrentMonth;
            }
            set
            {
                _inCurrentMonth = value;
            }
        }

        public List<DayItemPanel> Items
        {
            get
            {
                return pnlDayContents.Controls.Cast<DayItemPanel>().ToList();
            }
        }

        public CalendarDay()
        {
            InitializeComponent();
            AntiAliasDayNumberLabel();
            CurrentDay = DateTime.Now;
        }

        public CalendarDay(DateTime day, bool inCurrentMonth = true)
        {
            InitializeComponent();
            AntiAliasDayNumberLabel();
            SetDay(day, InCurrentMonth);   
        }

        private void AntiAliasDayNumberLabel()
        {
            lblDayNumber.Paint += delegate (object sender, PaintEventArgs e)
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                base.OnPaint(e);
            };
        }


        public void SetDay(DateTime day, bool inCurrentMonth = true)
        {
            CurrentDay = day;
            InCurrentMonth = inCurrentMonth;
            _updateDayHeader();
        }

        public void ClearItems()
        {
            pnlDayContents.Controls.Clear();
        }

        public void AddItem(DateTime dtTime, string Entry)
        {
            // Create new DayItemPanel and add it
            pnlDayContents.Controls.Add(new DayItemPanel(dtTime, Entry));

            // Sort controls by ascending time
            SortDayItems();
        }

        /// <summary>
        ///  Sort the current day's items in ascending time
        /// </summary>
        private void SortDayItems()
        {
            IEnumerable<DayItemPanel> sortedlist = from dayitem in pnlDayContents.Controls.Cast<DayItemPanel>() orderby dayitem.Time descending select dayitem;

            int counter = 0;
            bool EvenNumberOfItems = ((sortedlist.Count() % 2) == 0);
            foreach (DayItemPanel dayitem in sortedlist)
            {
                pnlDayContents.Controls.SetChildIndex(dayitem, counter);

                // Alternating BG colors
                bool isAlternateRow = (EvenNumberOfItems ? ((counter % 2) == 0) : ((counter % 2) != 0));
                dayitem.BackColor = (isAlternateRow ? Color.WhiteSmoke : Color.Silver);
                counter++;
            }
        }

        private void _updateDayHeader()
        {
            lblDayNumber.Text = CurrentDay.ToString("MMM d").ToUpper();
            if(!InCurrentMonth)
            {
                pnlDayLabel.BackColor = Theme.OutOfMonthDayBG;
                lblDayNumber.ForeColor = Theme.OutOfMonthDayFG;
            }
            else if(DateTime.Now.ToString("MMM d").ToUpper() == lblDayNumber.Text)
            {
                pnlDayLabel.BackColor = Theme.TodayBG;
                lblDayNumber.ForeColor = Theme.TodayFG;
            }
            else
            {
                pnlDayLabel.BackColor = Theme.InMonthDayBG;
                lblDayNumber.ForeColor = Theme.InMonthDayFG;
            }
        }

        public override string ToString()
        {
            return lblDayNumber.Text;
        }
    }

    public class DayItemPanel : Panel
    {
        public DateTime Time;
        public Label lblTime = new Label();
        public Label lblText = new Label();
        public DayItemPanel(DateTime dtTime, string Entry)
        {
            // Set panel properties
            Dock = DockStyle.Top;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Time = dtTime;

            // Create labels for time and text
            lblTime.Text = "22:22 AM";
            lblTime.Dock = DockStyle.Left;
            lblTime.TextAlign = ContentAlignment.TopRight;
            lblTime.AutoSize = true;
            lblTime.Width = 1;


            lblText.Text = Entry;
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = true;
            lblText.AutoEllipsis = true;


            // Add labels to the panel
            Controls.Add(lblText);
            Controls.Add(lblTime);

            // Now remove autosize and keep width
            int timeWidth = lblTime.Width;
            lblTime.AutoSize = false;
            lblTime.Width = timeWidth;
            lblTime.Text = dtTime.ToString("t");
        }

        public override string ToString()
        {
            return lblTime.Text + " :: " + lblText.Text;
        }
    }
}

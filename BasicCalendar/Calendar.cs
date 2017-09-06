using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BasicCalendar
{
    public partial class Calendar : UserControl
    {
        public event EventHandler<CalendarDayEventArgs> OnDayRefreshed;

        private DateTime _currentMonth;
        public DateTime CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
                UpdateCalendarLayout(_currentMonth);
            }
        }

        public Calendar()
        {
            InitializeComponent();
            CurrentMonth = DateTime.Now;
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }

        private void UpdateCalendarLayout(DateTime day)
        {
            SuspendDrawing(this);
            bool firstRender = (tlpDays.Controls.Count == 0);

            // Get first and last days of current month
            DateTime monthStart = new DateTime(day.Year, day.Month, 1);
            DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);

            // Determine what day of the week is the 1st (Sunday = 0)
            int daysOfWeekRendered = 0;
            int weeksRendered = 0;
            int totalDaysRendered = 0;
            DateTime currentlyRenderingDay = monthStart.AddDays(0 - (int)monthStart.DayOfWeek);
            DateTime calendarEndDay = currentlyRenderingDay.AddDays(41); //  (6 - (int)monthEnd.DayOfWeek));
            Console.WriteLine("START: " + currentlyRenderingDay.ToString("o"));
            Console.WriteLine("END: " + calendarEndDay.ToString("o"));


            CalendarDay calendarDay = null;
            while (currentlyRenderingDay <= calendarEndDay)
            {
                // Is the current day being rendered within the current month?
                bool inCurrentMonth = ((currentlyRenderingDay >= monthStart) && (currentlyRenderingDay <= monthEnd));

                // Are we creating new days or just updating them?
                if (firstRender)
                {
                    calendarDay = new CalendarDay(currentlyRenderingDay, inCurrentMonth);
                    calendarDay.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                    tlpDays.Controls.Add(calendarDay, daysOfWeekRendered, weeksRendered);

                    if (OnDayRefreshed != null)
                    {
                        OnDayRefreshed(this, new CalendarDayEventArgs() { Day = calendarDay });
                    }
                    
                    totalDaysRendered++;
                }
                else
                {
                    calendarDay = (CalendarDay)tlpDays.GetControlFromPosition(daysOfWeekRendered, weeksRendered);
                    calendarDay.SetDay(currentlyRenderingDay, inCurrentMonth);

                    if (OnDayRefreshed != null)
                    {
                        OnDayRefreshed(this, new CalendarDayEventArgs() { Day = calendarDay });
                    }
                }

                // Increment day/week
                daysOfWeekRendered++;
                if(daysOfWeekRendered == 7)
                {
                    daysOfWeekRendered = 0;
                    weeksRendered++;
                }
                currentlyRenderingDay = currentlyRenderingDay.AddDays(1);
            }
            
            ResumeDrawing(this);
        }
    }

    public class CalendarDayEventArgs : EventArgs
    {
        public CalendarDay Day;
    }
}

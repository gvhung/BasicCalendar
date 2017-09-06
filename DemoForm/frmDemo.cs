using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BasicCalendar;

namespace DemoForm
{
    public partial class frmDemo : Form
    {
        public frmDemo()
        {
            InitializeComponent();
            calendar1.OnDayRefreshed += Calendar1_OnDayRefreshed;
            calendar1.CurrentMonth = DateTime.Now;
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            calendar1.CurrentMonth = dateTimePicker1.Value;
        }

        Random rnd = new Random();

        private void Calendar1_OnDayRefreshed(object sender, CalendarDayEventArgs e)
        {
            CalendarDay calendarDay = e.Day;
            calendarDay.ClearItems();


            if (rnd.Next(1, 100) >= 30)
            {
                calendarDay.AddItem(calendarDay.CurrentDay.AddMinutes(rnd.Next(1, 100)), "Lorem ipsum");
                if (rnd.Next(1, 100) >= 50)
                {
                    calendarDay.AddItem(calendarDay.CurrentDay.AddMinutes(rnd.Next(100, 500)), "Dolor sit amet");
                    if (rnd.Next(1, 100) >= 60)
                    {
                        calendarDay.AddItem(calendarDay.CurrentDay.AddMinutes(rnd.Next(500, 600)), "Consectetur");
                        if (rnd.Next(1, 100) >= 70)
                        {
                            calendarDay.AddItem(calendarDay.CurrentDay.AddMinutes(rnd.Next(600, 900)), "Adipiscing elit");
                            if (rnd.Next(1, 100) >= 80)
                            {
                                calendarDay.AddItem(calendarDay.CurrentDay.AddMinutes(rnd.Next(900, 1400)), "Proin mi libero, tempor sit amet fermentum");
                            }
                        }
                    }
                }
            }
        }
    }
}

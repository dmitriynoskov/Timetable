using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class TimetableDateForm : Form
    {
        public TimetableDateForm()
        {
            InitializeComponent();
            DateLoad();
        }

        private void DateLoad()
        {
             
            for (int i = 1960; i <= DateTime.Now.Year; i++)
            {
                cmbxYear.Items.Add(i);
            }

            for (int i = 1; i <= 12; i++)
            {
                cmbxMonth.Items.Add(string.Format("{0:MMMM}", new DateTime(DateTime.Now.Year, i, 1)));
            }

            cmbxYear.SelectedItem = DateTime.Now.Year;

            cmbxMonth.SelectedItem = string.Format("{0:MMMM}", new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            string year = cmbxYear.SelectedItem.ToString();
            int month = cmbxMonth.SelectedIndex+1;

            TimetableForm timetableForm = new TimetableForm(year, month);

            timetableForm.MdiParent = this.MdiParent;

            timetableForm.Show();
        }
    }
}

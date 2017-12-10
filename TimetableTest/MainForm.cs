using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessToDL;
using TimetableTest;

namespace Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void WorkersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffForm staff = new StaffForm();
            staff.MdiParent = this;
            staff.Show();
        }

        private void TimetableMenuItem_Click(object sender, EventArgs e)
        {
            TimetableDateForm timetableDateForm = new TimetableDateForm();
            timetableDateForm.MdiParent = this;
            timetableDateForm.Show();
        }

        private void btnExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

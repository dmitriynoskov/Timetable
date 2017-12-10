using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccessToDL;

namespace Client
{
    public partial class WorkerInfoForm : Form
    {
        private bool _edit;
        public PersonProxy Worker { get; private set; }
        public WorkerInfoForm(PersonProxy workerToUpdate, bool edit)
        {
            InitializeComponent();

            Worker = workerToUpdate;

            _edit = edit;
        }

        public WorkerInfoForm(bool edit)
        {
            InitializeComponent();

            _edit = edit;

            Worker = new PersonProxy();

            cmbxGender.SelectedIndex = 0;
        }

        private void FillData()
        {
            if (_edit)
            {
                txbxId.Text = Worker.ID.ToString();
                txbxId.ReadOnly = true;
                txbxLastName.Text = Worker.LastName;
                txbxFirstName.Text = Worker.FirstName;
                txbxPatronymic.Text = Worker.Patronymic;
                cmbxGender.SelectedIndex = Worker.Gender ? 0 : 1;
                dtpBirthDate.Value = Worker.BirthDate;
            }
        }

        private void WorkerInfo_Shown(object sender, EventArgs e)
        {
            FillData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbxLastName.Text.Trim()) || string.IsNullOrEmpty(txbxFirstName.Text.Trim()) ||
                string.IsNullOrEmpty(txbxPatronymic.Text.Trim()))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка редактирования");
                return;
            }

            Worker.LastName = txbxLastName.Text.Trim();
            Worker.FirstName = txbxFirstName.Text.Trim();
            Worker.Patronymic = txbxPatronymic.Text.Trim();
            Worker.BirthDate = dtpBirthDate.Value.Date;
            Worker.Gender = cmbxGender.SelectedIndex == 0;

            if (_edit)
            {
                Worker.UpdatePerson();
            }
            else
            {
                Worker.ID = int.Parse(txbxId.Text.Trim());
                Worker.AddNewPerson();
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            this.Close();
        }

        private void txbxId_Leave(object sender, EventArgs e)
        {
            if (_edit)
            {
                if (Worker.CheckId(int.Parse(txbxId.Text.Trim())))
                {
                    Worker.ID = int.Parse(txbxId.Text.Trim());
                }
            }
        }
    }
}

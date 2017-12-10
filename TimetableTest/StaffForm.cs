using AccessToDL;
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
    public partial class StaffForm : Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Заполнение таблицы списком сотрудников,
        /// отсоритованных по табельному номеру
        /// </summary>
        private void FillDataGridView()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
            }

            foreach (Person person in PersonProxy.GetPersons())
            {
                dataGridView1.Rows.Add(person.ID, person.LastName, person.FirstName, person.Patronymic,
                    person.Gender ? "Муж" : "Жен", person.BirthDate.ToShortDateString());
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateWorker();
        }

        private void UpdateWorker()
        {
            PersonProxy workerToUpdate = new PersonProxy();

            workerToUpdate.ID = int.Parse(dataGridView1.CurrentRow.Cells["PersonId"].Value.ToString());
            workerToUpdate.LastName = dataGridView1.CurrentRow.Cells["PersonLastName"].Value.ToString();
            workerToUpdate.FirstName = dataGridView1.CurrentRow.Cells["PersonFirstName"].Value.ToString();
            workerToUpdate.Patronymic = dataGridView1.CurrentRow.Cells["PersonPatronymic"].Value.ToString();
            switch (dataGridView1.CurrentRow.Cells["PersonGender"].Value.ToString())
            {
                case "Муж":
                {
                    workerToUpdate.Gender = true;
                    break;
                }
                case "Жен":
                {
                    workerToUpdate.Gender = false;
                    break;
                }
            }
            workerToUpdate.BirthDate =
                DateTime.Parse(dataGridView1.CurrentRow.Cells["PersonBirthDate"].Value.ToString());

            WorkerInfoForm workerInfo = new WorkerInfoForm(workerToUpdate, true);
            //workerInfo.MdiParent = this.MdiParent;
            workerInfo.Text = "Редактирование сотрудника";
            if (workerInfo.ShowDialog() == DialogResult.OK)
            {
                FillDataGridView();
            }
        }

        private void Staff_Activated(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            WorkerInfoForm workerInfo = new WorkerInfoForm(false);
            //workerInfo.MdiParent = this.MdiParent;
            workerInfo.Text = "Добавление сотрудника";
            if (workerInfo.ShowDialog() == DialogResult.OK)
            {
                FillDataGridView();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PersonProxy workerToDelete = new PersonProxy();

            workerToDelete.ID = int.Parse(dataGridView1.CurrentRow.Cells["PersonId"].Value.ToString());
            workerToDelete.DeletePerson();

            FillDataGridView();
        }
    }
}

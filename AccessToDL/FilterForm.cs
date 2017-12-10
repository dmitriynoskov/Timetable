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
    public partial class FilterForm : Form
    {
        public event EventHandler<FilterEventArgs> PersonSelected;

        public DataGridView DataGrid { get; set; }
        public PersonProxy PersonProxy { get; set; }
        public FilterForm(DataGridView dgv)
        {
            InitializeComponent();
            PersonProxy = new PersonProxy();
            FillGrid();

            DataGrid = dgv;
        }

        public void OnPersonSelected(FilterEventArgs e)
        {
            EventHandler<FilterEventArgs> personSelected = PersonSelected;

            if (personSelected != null)
            {
                personSelected(this, e);
            }
        }

        /// <summary>
        /// Заполнение формы сотрудниками
        /// </summary>
        private void FillGrid()
        {
            int i = 0;
            IEnumerable<Person> list = PersonProxy.GetPersonsForFilter();
            foreach (Person person in list)
            {
                listView1.Items.Add(person.ID.ToString());
                listView1.Items[i].SubItems.Add(string.Format("{0} {1} {2}", person.LastName, person.FirstName, person.Patronymic));
                ++i;
            }
        }

        /// <summary>
        /// Установка фокуса на текущего сотрудника
        /// </summary>
        /// <param name="id">ТН работника</param>
        public void SetFocusToListView(int id)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == id.ToString())
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        public void SetFocusToListView(string text)
        {
            this.Deactivate -= new System.EventHandler(this.FilterForm_Deactivate);

            foreach (ListViewItem item in listView1.Items)
            {
                if (item.SubItems[1].Text.Contains(text))
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }

        /// <summary>
        /// Автозакрытие формы при потере фокуса на нее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterForm_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int id = int.Parse(listView1.SelectedItems[0].Text);

            int rowCount = DataGrid.RowCount - 1;

            Person person = PersonProxy.SearchPersonById(id);

            bool exists = false;
            for (int i = 0; i < rowCount; i++)
            {
                object rowValue = DataGrid.Rows[i].Cells[0].Value;

                if (rowValue != null)
                {
                    int cellValue = int.Parse(rowValue.ToString());

                    if (cellValue != person.ID)
                    {
                        continue;
                    }
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                DataGrid.CurrentRow.Cells[0].Value = person.ID;
                DataGrid.CurrentRow.Cells[1].Value =
                    string.Format("{0} {1} {2}", person.LastName, person.FirstName, person.Patronymic);

                this.Deactivate += new System.EventHandler(this.FilterForm_Deactivate);
            }

            OnPersonSelected(new FilterEventArgs(id));
        }
    }
}

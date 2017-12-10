using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client;

namespace DataGridViewEditControl
{
    public partial class DataGridViewEditButton: UserControl, IDataGridViewEditingControl
    {
        private DataGridView _dataGridView;
        private bool _valueChanged;
        private int _rowIndex;
        private FilterForm filterForm;

        public DataGridViewEditButton()
        {
            InitializeComponent();
        }

        public DataGridView EditingControlDataGridView
        {
            get { return this._dataGridView; }

            set { this._dataGridView = value; }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                this.textBox1.Text = this._dataGridView.CurrentCell.Value.ToString();
                return this.textBox1.Text;
            }

            set
            {
            }
        }

        public int EditingControlRowIndex
        {
            get { return this._rowIndex; }

            set
            {
                this._rowIndex = value;
            }
        }

        public bool EditingControlValueChanged
        {
            get { return this._valueChanged; }

            set { this._valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.textBox1.Font = dataGridViewCellStyle.Font;
            this.MinimumSize = this.Size;
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            return true;
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        private void OnValueChanged()
        {
            _valueChanged = true;
            this.Text = this.textBox1.Text;
            DataGridView dgv = this.EditingControlDataGridView;
            if (dgv != null)
            {
                dgv.NotifyCurrentCellDirty(true);
            }

            FilterFormCreate();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                FocusToItemList(textBox1.Text);
            }
            else
            {
                FocusToItemList();

            }
        }

        private void FocusToItemList()
        {
            object cellValue = _dataGridView.CurrentRow.Cells[0].Value;

            if (cellValue != null)
            {
                string id = cellValue.ToString();

                if (filterForm != null)
                {
                    filterForm.SetFocusToListView(int.Parse(id));
                }
            }
        }

        private void FocusToItemList(string text)
        {
            if (filterForm != null)
            {
                filterForm.SetFocusToListView(text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterFormCreate();

            FocusToItemList();

            //Form f = _dataGridView.FindForm();
            //Type t = f.GetType();
        }

        private void FilterFormCreate()
        {
            filterForm = new FilterForm(_dataGridView);
            filterForm.Location = new Point(0, Parent.Location.Y + button1.Size.Height + _dataGridView.ColumnHeadersHeight);
            filterForm.Show();
        }
    }
}

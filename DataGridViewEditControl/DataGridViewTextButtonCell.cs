using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewEditControl
{
    public class DataGridViewTextButtonCell : DataGridViewTextBoxCell
    {
        private int _heightOfRowBeforeEditMode;
        private int _widthOfRowBeforeEditMode;

        public DataGridViewTextButtonCell()
            : base()
        {

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewEditButton dgvebCtrl = this.DataGridView.EditingControl as DataGridViewEditButton;
            this._heightOfRowBeforeEditMode = this.OwningRow.Height;
            this._widthOfRowBeforeEditMode = this.OwningColumn.Width;
            this.OwningRow.Height = dgvebCtrl.Height;
            if (_widthOfRowBeforeEditMode <= this.OwningColumn.Width)
            {
                dgvebCtrl.Width = new Size(_widthOfRowBeforeEditMode, this.OwningRow.Height).Width;
            }
            
        }

        public override Type EditType
        {
            get { return typeof(DataGridViewEditButton); }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);

            }
        }

        public override void DetachEditingControl()
        {
            if (this._heightOfRowBeforeEditMode > 0)
                this.OwningRow.Height = this._heightOfRowBeforeEditMode;

            base.DetachEditingControl();
        }

        public override Type FormattedValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return "";
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }
}

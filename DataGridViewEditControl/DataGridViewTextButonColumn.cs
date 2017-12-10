using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewEditControl
{
    public class DataGridViewTextButonColumn : DataGridViewColumn
    {
        public DataGridViewTextButonColumn()
            : base(new DataGridViewTextButtonCell())
        {
            
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewTextButtonCell)))
                {
                    throw new InvalidCastException("Cell must be TextButtonCell");
                }

                base.CellTemplate = value;
            }
        }
    }
}

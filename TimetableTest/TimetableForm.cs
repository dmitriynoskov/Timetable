using AccessToDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class TimetableForm : Form
    {
        int _columns;
        public string Year { get; private set; }
        public int Month { get; private set; }

        public PersonProxy PersonProxy { get; set; }
        public NetProxy NetProxy { get; set; }

        public FilterForm FilterForm { get; set; }
        public TimetableForm(string year, int month)
        {
            InitializeComponent();
            PersonProxy = new PersonProxy();
            NetProxy = new NetProxy();

            Year = year;
            Month = month;

            PaintGrid();
            //FilterForm = Application.OpenForms["filterForm"] as FilterForm;
            //FilterForm = new FilterForm();
            //FilterForm.PersonSelected += new EventHandler<FilterEventArgs>(filterForm_PersonSelected);
            
        }

        private void filterForm_PersonSelected(object sender, FilterEventArgs e)
        {
            if (e is FilterEventArgs)
            {
                FilterEventArgs filterEventArgs = e as FilterEventArgs;
                Person person = PersonProxy.SearchPersonById(filterEventArgs.ID);

                dataGridView1.Rows.Add(person.ID, person.LastName + " " + person.FirstName + " " + person.Patronymic);
            }
        }


        /// <summary>
        /// Автозаполнение таблицы работниками
        /// </summary>
        private void FillGrid(bool clear)
        {
            //если таблица пуста - добавляем первого работника
            if (dataGridView1.RowCount <= 1)
            {
                if (!clear)
                {
                    if (NetProxy.IsShifted(int.Parse(Year), Month))
                    {
                        foreach (Person person in PersonProxy.GetPersons())
                        {
                            dataGridView1.Rows.Add(person.ID, person.LastName + " " + person.FirstName + " " + person.Patronymic);
                        }
                    }
                }
                else
                {
                    foreach (Person person in PersonProxy.GetPersons())
                    {
                        dataGridView1.Rows.Add(person.ID, person.LastName + " " + person.FirstName + " " + person.Patronymic);
                    }
                }
            }
            else
            {
                //проверка на уже введеного сотрудника
                //во избежание дублирования
                int rowCount = dataGridView1.RowCount - 1;

                foreach (Person person in PersonProxy.GetPersons())
                {
                    bool exists = false;
                    for (int i = 0; i < rowCount; i++)
                    {
                        object idCellValue = dataGridView1.Rows[i].Cells[0].Value;

                        if (idCellValue != null)
                        {
                            int cellValue = int.Parse(idCellValue.ToString());

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
                        dataGridView1.Rows.Add(person.ID, person.LastName + " " + person.FirstName + " " + person.Patronymic);
                    }
                }
            }
        }

        /// <summary>
        /// Отрисовка таблицы:
        /// На основании введеного переиода времени происходит просчет кол-ва дней в месяце
        /// и их нумерация в Header каждой колонки
        /// </summary>
        private void PaintGrid()
        {
            for (int i = 1; i <= DateTime.DaysInMonth(int.Parse(Year), Month); i++)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                dataGridView1.Columns[i + 1].Width = 30;
                dataGridView1.Columns[i + 1].HeaderText = string.Format("{0}  {1:ddd}", i, new DateTime(int.Parse(Year), Month, i));
            }

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].Width = 40;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].ReadOnly = true;
            dataGridView1.Columns[dataGridView1.ColumnCount - 1].HeaderText = "Итого факт";

            _columns = dataGridView1.ColumnCount;

            FillGrid(false);
            FillTheShifts();
        }

        private void TimetableForm_Load(object sender, EventArgs e)
        {
            this.Text = string.Format("График выходов сотрудников за {0:MMMM} {1} года", new DateTime(int.Parse(Year), Month, 1), Year);
        }

        /// <summary>
        /// Обработка клавиши Заполнить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFill_Click(object sender, EventArgs e)
        {
            FillGrid(true);         //Заполняем таблицу работниками
            FillTheShifts();    //Заполняем таблицу отработанными сменами
        }

        /// <summary>
        /// Подсчет общего отработанного времени по всем работникам
        /// </summary>
        private void CountTotalTime()
        {
            double total = 0;
            int rowCount = dataGridView1.RowCount;

            for (int i = 0; i < rowCount; i++)
            {
                CountTotalTime(dataGridView1.Rows[i]);
                total = 0;
            }
        }

        /// <summary>
        /// Подсчет общего отработанного времени по конкретному работнику
        /// </summary>
        /// <param name="row"></param>
        private void CountTotalTime(DataGridViewRow row) //передать только одну строку
        {
            double total = 0;
            int columnsToCount = _columns - 1;
            int rowCount = dataGridView1.RowCount;

            for (int i = 2; i < columnsToCount; i++)
            {
                if (row.Cells[i].Value != null)
                {
                    if (!char.IsLetter(row.Cells[i].Value.ToString().ToCharArray()[0]))
                    {
                        total += double.Parse(row.Cells[i].Value.ToString());
                    }
                    row.Cells[columnsToCount].Value = total;
                }
            }
        }

        /// <summary>
        /// Обработка отредактированной ячейки:
        /// Работа с записанной сменой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 1)
            {
                SetWorkedTimeToTimetable(); //сохранение введеной смены

                CountTotalTime((sender as DataGridView).CurrentRow); //подсчет итогового отработанного времени
            }
        }

        /// <summary>
        /// обработка ввода значений с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimetableForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (dataGridView1.CurrentCell.ColumnIndex > 1 && dataGridView1.CurrentCell.ColumnIndex < dataGridView1.ColumnCount - 1)
            {
                if (char.IsLetter(e.KeyChar))
                {
                    switch (e.KeyChar)
                    {
                        case 'о':
                        case 'О':
                        case 'к':
                        case 'К':
                        case 'б':
                        case 'Б':
                            {
                                dataGridView1.CurrentCell.Value = char.ToUpper(e.KeyChar);
                                break;
                            }
                        default:
                            {
                                e.Handled = true;
                                break;
                            }
                    }
                }
                if (char.IsSymbol(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            foreach (var row in dataGridView1.Rows)
            {
                //для каждого добавленного ряда устанавливаем значение колонки "Итого" в 0
                (row as DataGridViewRow).Cells[dataGridView1.ColumnCount - 1].Value = 0;
            }
        }

        /// <summary>
        /// Сохранение введеной смены
        /// </summary>
        private void SetWorkedTimeToTimetable()
        {
            //проходим по каждой записи
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
                object rowValue = dataGridView1.CurrentRow.Cells[0].Value;   //ТН работника

                if (rowValue != null)
                {
                    Person person = PersonProxy.SearchPersonById(int.Parse(rowValue.ToString())); //текущий работник
                    Dictionary<DateTime, string> timeWorked = new Dictionary<DateTime, string>(); //пара Дата-Время

                    for (int i = 2; i < dataGridView1.ColumnCount - 1; i++)
                    {
                        object timeValue = dataGridView1.CurrentRow.Cells[i].Value;
                        if (timeValue != null)
                        {
                            DateTime date = new DateTime(int.Parse(Year), Month, dataGridView1.CurrentRow.Cells[i].ColumnIndex - 1).Date;
                            timeWorked.Add(date, timeValue.ToString()); //добавляем дату и отработанное время
                            PersonProxy.SetWorkingTime(timeWorked, person); //отправляем данные на обработку
                        }
                    }
                //}
            }
        }

        /// <summary>
        /// Заполнение таблицы смен
        /// </summary>
        private void FillTheShifts()
        {
            //Проходим каждый ряд работника
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    Person person = PersonProxy.SearchPersonById(int.Parse(row.Cells[0].Value.ToString()));     //текущий работник

                    dataGridView2.DataSource = NetProxy.GetShifts(person, int.Parse(Year), Month);

                    IEnumerable<Net> shifts = NetProxy.GetShifts(person, int.Parse(Year), Month);   //список всех отработанных дней

                    //проходим по каждой смене
                    foreach (Net shift in shifts)
                    {
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            //сверяем отработанную дату с датой, введеной в таблицу
                            if (column.HeaderText.Contains(' '))
                            {
                                string headerDate = column.HeaderText.Split(' ')[0];
                                if (headerDate.Length <= 2)
                                {
                                    if (int.Parse(headerDate) == shift.DateWorked.Day)
                                    {
                                        //если дата совпадает - вводим значение
                                        row.Cells[column.Index].Value = shift.TimeWorked;
                                    }
                                }
                            }
                        }
                    }

                    CountTotalTime();
                    person = null;
                }
            }
        }

        /// <summary>
        /// Изменение ТН при переключении сотрудника в табеле
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            object rowValue = dataGridView1.CurrentRow.Cells[0].Value;

            if (rowValue != null)
            {
                PersonProxy.ID = int.Parse(rowValue.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToDL
{
    public class NetProxy : Net
    {
        /// <summary>
        /// Генерация смен по текущему работнику
        /// и заданной дате
        /// </summary>
        /// <param name="person">Работник</param>
        /// <param name="year">Год поиска</param>
        /// <param name="month">Месяц поиска</param>
        /// <returns></returns>
        public IEnumerable<Net> GetShifts(Person person, int year, int month)
        {
            var context = new TimetableContext();
            var net = from n in context.Net
                where n.PersonID == person.ID && n.DateWorked.Year == year && n.DateWorked.Month == month
                select n;

            return net.ToList();
        }

        public bool IsShifted(int year, int month)
        {
            var context = new TimetableContext();
            bool res = context.Net.Any<Net>(n => n.DateWorked.Year == year && n.DateWorked.Month == month);

            return res;
        }
    }
}

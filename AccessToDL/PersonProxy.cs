using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToDL
{
    public class PersonProxy : Person
    {
        /// <summary>
        /// Генерация списка всех работников
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Person> GetPersons()
        {
            var context = new TimetableContext();
            return context.Person.OrderBy(p => p.ID).AsNoTracking();
        }

        /// <summary>
        /// Поиск работника по табельному номеру
        /// </summary>
        /// <param name="id">Табельный номер</param>
        /// <returns>Работник</returns>
        public Person SearchPersonById(int id)
        {
            var context = new TimetableContext();
            var person = context.Person.Single(p => p.ID == id);
            return person;
        }

        /// <summary>
        /// Проверка на наличие занятого табельного номера
        /// </summary>
        /// <param name="id">Желаемый табельный номер</param>
        /// <returns>Статус свободен/занят</returns>
        public bool CheckId(int id)
        {
            var context = new TimetableContext();
            var person = from p in context.Person
                where p.ID == id
                select p;

            if (person as PersonProxy != null)
            {
                return true; //если такого ТН нет в базе, то вернуть true и возможность для введения его в БД
            }
            return false;
        }

        /// <summary>
        /// Редактирование данных текущего сотрудника
        /// </summary>
        public void UpdatePerson()
        {
            var context = new TimetableContext();

            var person = context.Person.Single(p => p.ID == ID);

            person.BirthDate = BirthDate;
            person.FirstName = FirstName;
            person.Gender = Gender;
            person.LastName = LastName;
            person.Patronymic = Patronymic;

            context.SaveChanges();
        }

        /// <summary>
        /// Добавление нового работника
        /// </summary>
        public void AddNewPerson()
        {
            var context = new TimetableContext();

            var person = context.Person.Add(new Person
            {
                ID = this.ID,
                Gender = this.Gender,
                FirstName = this.FirstName,
                LastName = this.LastName,
                BirthDate = this.BirthDate,
                Patronymic = this.Patronymic
            });

            context.SaveChanges();
        }

        /// <summary>
        /// Удаление работника из БД
        /// </summary>
        public void DeletePerson()
        {
            var context = new TimetableContext();

            Person person = context.Person
                .FirstOrDefault(c => c.ID == ID);

            context.Person.Remove(person);

            context.SaveChanges();
        }

        /// <summary>
        /// Запись рабочего времени в расписание
        /// </summary>
        /// <param name="timeWorked">Запись в словаре: пара Дата-время</param>
        /// <param name="worker">Работник</param>
        public void SetWorkingTime(Dictionary<DateTime, string> timeWorked, Person worker)
        {
            var context = new TimetableContext();

            var person = context.Person.Single(p => p.ID == worker.ID);

            foreach (KeyValuePair<DateTime, string> pair in timeWorked)
            {
                //Проверка существует ли уже данный день в расписании
                bool net = context.Net.Any<Net>(w => w.PersonID == person.ID && w.DateWorked == pair.Key.Date);

                //если нет, то добавить смену текущему работнику за текущий день
                if (!net)
                {
                    var shift = context.Net.Add(new Net
                    {
                        Person = person,
                        DateWorked = pair.Key,
                        TimeWorked = pair.Value,
                    });

                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Person> GetPersonsForFilter()
        {
            var context = new TimetableContext();

            var persons = from p in context.Person
                          orderby p.ID
                          select p;

            return persons;
        }
    }
}

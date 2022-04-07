using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_system
{
    public class User
    {
        //Класс пользователя, который проходит тест
        private string surname;
        private string name;
        private string group;
        private int score;
        private int mark;
        private DateTime start;
        private DateTime finish;
        
        public string Surname { get { return surname; } }
        public string Name { get { return name; } }
        public string Group  { get { return group; } }
        public DateTime Start { get { return start; }  }
        //Оценка пользователя по итогам прохождения теста
        public int Mark
        { get { return (score < 16) ? 2 
                     : (score < 24) ? 3 
                     : (score < 32) ? 4 : 5; } }
        public DateTime Finish
        { get { return finish; }
          set { finish = value;
              
            } }
        //Время прохождения теста
        public TimeSpan Elapsed
        { get { return (finish == null) ? (TimeSpan.Zero) : (finish - start); } }
        public int Score
        { get { return score; }
          set { score = value; } }

        public User(string surname, string name, string group, DateTime start)
        {
            
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.start = start;
            
        }
        public User(string surname, string name, string group, DateTime start, TimeSpan elapsed)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.start = start;
            this.finish = start;
            this.finish.Add(elapsed);
        }
        public User(string surname, string name, string group, string start)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.start = DateTime.MinValue;
            DateTime.TryParse(start, out this.start);
        }
        public User(string surname, string name, string group, string start, string elapsed)
        {
           
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.start = DateTime.MinValue;
            DateTime.TryParse(start, out this.start);
            
            TimeSpan tmp;
            if (TimeSpan.TryParse(elapsed, out tmp))
            {
               
                this.finish = this.start;
                finish = finish.Add(tmp);
               
            }
        }
    }
}

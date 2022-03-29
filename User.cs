﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_system
{
    class User
    {
        public User(string surname, string name, string group, DateTime start)
        {
            this.surname = surname;
            this.name = name;
            this.group = group;
            this.start = start;
        }
        private string surname;
        private string name;
        private string group;
        private int score;
        private int mark;
        private DateTime start;
        private DateTime finish;
        public string Surname
        { get { return surname; } } //set нету потому что мы только единожды создаём пользователя
        public string Name
        { get { return name; } }
        public string Group
        { get { return group; } }
        public DateTime Start
        { get { return start; }  }
        public int Mark
        { get { return mark; }  }
        public DateTime Finish // а эти поля заполняются потом, после прохождения теста
        { get { return finish; } set { finish = value; } }
        public int Score
        { get { return score; } set { score = value; } }
        public void ScoreToMark()
        {
            mark = score < 16 ? 2 : (score >= 16 && score < 24) ? 3 : (score >= 25 && score < 32) ? 4 : 5;
        }

    }
}

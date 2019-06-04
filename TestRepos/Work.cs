using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos
{
    public class Work //Сущность работ (лабы, практики и т.д.)
    {
        public string Name { get; set; }
        public int Point { get; set; }

        public Work(string name, int point)
        {
            Name = name;
            Point = point;
        }

    }
}

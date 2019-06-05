using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos
{
    public class Teacher
    {
        public string Name { get; set; }
        public string NameDiscipline { get; set; }        
        public long Id { get; set; }                

        public Teacher() { }

        public Teacher(string name)
        {
            Name = name;                                   
        }

        public Teacher(long id, string name)
        {
            Name = name;                       
            Id = id;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos
{
    public class Group
    {
        public string Number { get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
        public int Id { get; set; }
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public List<string> NameDiscipline { get; set; }

        public Group(List<string> nameDiscipline, string number, int course, string faculty)
        {            
            NameDiscipline = nameDiscipline;
            Number = number;
            Course = course;           
            Faculty = faculty;
        }        

        public Group(string number, string faculty, int course, int id)
        {
            Number = number;
            Faculty = faculty;
            Course = course;
            Id = id;            
        }

        public override string ToString()
        {
            return $"{Number}";
        }
    }
}

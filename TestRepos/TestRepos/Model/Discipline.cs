using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos
{
    public class Discipline
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public int ID { get; set; }
        public int TeachersId { get; set; }

        public Discipline(string name, string teacherName)
        {
            TeacherName = teacherName;
            Name = name;            
        }

        public Discipline(int id, string name, int teacherId)
        {
            ID = id;
            Name = name;
            TeachersId = teacherId;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRepos.Model
{
    public class Term
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string StudyYear { get; set; }

        public Term(string name, string studyYear)
        {           
            Name = name;
            StudyYear = studyYear;
        }

        public Term(long id, string name, string studyYear)
        {
            ID = id;
            Name = name;
            StudyYear = studyYear;
        }

        public override string ToString()
        {
            return $"{Name}|{StudyYear}";
        }
    }
}
